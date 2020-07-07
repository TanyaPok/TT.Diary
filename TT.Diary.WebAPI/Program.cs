using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace TT.Diary.WebAPI
{
    public class Program
    {
        public const string APP_SETTINGS = "appsettings.json";
        public const string LOG_FILE = "Logging:FilePath";
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builtConfig = new ConfigurationBuilder()
                .AddJsonFile(APP_SETTINGS)
                .AddCommandLine(args)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo
                .File(builtConfig[LOG_FILE], rollingInterval: RollingInterval.Day, shared: true)
                .CreateLogger();

            try
            {
                return Host.CreateDefaultBuilder(args)
                     .UseSerilog(Log.Logger, true)
                     .ConfigureWebHostDefaults(webBuilder =>
                     {
                         webBuilder.UseStartup<Startup>();
                     });
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host builder error");
                Log.CloseAndFlush();
                throw;
            }
        }
    }
}
