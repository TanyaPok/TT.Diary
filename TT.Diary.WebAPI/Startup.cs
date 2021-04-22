using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using Serilog;
using TT.Diary.DataAccessLogic;
using FluentValidation;
using TT.Diary.BusinessLogic.Configurations.PipelineBehavior;

namespace TT.Diary.WebAPI
{
    public class Startup
    {
        private readonly string CONNECTION_STRING = "DefaultConnection";
        private readonly string CATEGORY_LIST = "CategoryTitleList";

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddLogging();

            var businessLogicAssembly = typeof(BusinessLogic.DTO.Lists.AbstractCategoryItem).Assembly;

            services.AddMediatR(businessLogicAssembly);

            services.AddValidatorsFromAssembly(businessLogicAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddSingleton<ICategoryTitleList>(sp =>
                Configuration.GetSection(CATEGORY_LIST).Get<CategoryTitleList>());
            
            services.AddScoped(d =>
                new DiaryDBContext(Configuration.GetConnectionString(CONNECTION_STRING), Environment.IsDevelopment()));
            services.ConfigureDiaryRepositories();
            services.ConfigureDiaryAutomapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}