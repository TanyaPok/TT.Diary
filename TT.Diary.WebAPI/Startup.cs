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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var businessLogicAssembly = typeof(TT.Diary.BusinessLogic.ViewModel.IComponent).Assembly;

            services.AddMediatR(businessLogicAssembly);

            services.AddValidatorsFromAssembly(businessLogicAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddDbContext<DiaryDBContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString(CONNECTION_STRING),
                    b => b.MigrationsAssembly(typeof(TT.Diary.DataAccessLogic.DiaryDBContext).Assembly.FullName)));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AllowNullCollections = true;
                mc.AddProfile(new WishProfile());
                mc.AddProfile(new CategoryProfile());
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
