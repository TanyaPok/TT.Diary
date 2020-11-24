using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using Serilog;
using Microsoft.EntityFrameworkCore;
using TT.Diary.BusinessLogic.MappingConfigurations;
using TT.Diary.DataAccessLogic;
using AutoMapper;
using FluentValidation;
using TT.Diary.BusinessLogic.Configurations.PipelineBehavior;

namespace TT.Diary.WebAPI
{
    public class Startup
    {
        public const string CONNECTION_STRING = "DefaultConnection";

        public const string CATEGORY_LIST = "CategoryTitleList";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var businessLogicAssembly = typeof(BusinessLogic.DTO.Lists.AbstractItem).Assembly;

            services.AddMediatR(businessLogicAssembly);

            services.AddValidatorsFromAssembly(businessLogicAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddSingleton<ICategoryTitleList>(sp => Configuration.GetSection(CATEGORY_LIST).Get<CategoryTitleList>());

            services.AddDbContext<DiaryDBContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString(CONNECTION_STRING), b => b.MigrationsAssembly(typeof(DiaryDBContext).Assembly.FullName));
                options.EnableSensitiveDataLogging();
                options.AddInterceptors(new BaseDbCommandInterceptor());
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AllowNullCollections = true;
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new ToDoListProfile());
                mc.AddProfile(new HabitProfile());
                mc.AddProfile(new WishProfile());
                mc.AddProfile(new NoteProfile());
                mc.AddProfile(new CategoryProfile());
                mc.AddProfile(new ScheduleSettingsProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
