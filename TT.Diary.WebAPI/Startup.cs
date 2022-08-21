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
        private readonly string ACCESS_CONTROL_ALLOW_ORIGIN = "Access-Control-Allow-Origin";

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

            services.AddCors(options =>
            {
                options.AddPolicy(name: ACCESS_CONTROL_ALLOW_ORIGIN,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                    });
            });

            services.AddMediatR(businessLogicAssembly);

            services.AddValidatorsFromAssembly(businessLogicAssembly);
            
            /*при каждом обращении к сервису создается новый объект сервиса
             В течение одного запроса может быть несколько обращений к сервису, соответственно при каждом обращении 
             будет создаваться новый объект. Подобная модель жизненного цикла наиболее подходит для легковесных сервисов, 
             которые не хранят данных о состоянии*/
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            /*объект сервиса создается при первом обращении к нему, все последующие запросы используют один и тот же
             ранее созданный объект сервиса*/
            services.AddSingleton<ICategoryTitleList>(sp =>
                Configuration.GetSection(CATEGORY_LIST).Get<CategoryTitleList>());

           /*для каждого запроса создается свой объект сервиса. То есть если в течение одного запроса есть несколько
            обращений к одному сервису, то при всех этих обращениях будет использоваться один и тот же объект сервиса.*/
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
                app.UseCors(ACCESS_CONTROL_ALLOW_ORIGIN);
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}