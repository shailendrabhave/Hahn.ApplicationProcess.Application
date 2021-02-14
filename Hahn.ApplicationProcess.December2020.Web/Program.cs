using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Hahn.ApplicationProcess.December2020.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configSettings = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            using (var log = new LoggerConfiguration()
             .WriteTo.File(configSettings["Logging:LogPath"], rollOnFileSizeLimit: true, fileSizeLimitBytes: 100000)
             .CreateLogger())
                {                   
                    return Host.CreateDefaultBuilder(args)
                        .ConfigureWebHostDefaults(webBuilder =>
                        {
                            webBuilder.UseStartup<Startup>();
                        })
                        .ConfigureAppConfiguration(config =>
                        {
                            config.AddConfiguration(configSettings);
                        })
                        .ConfigureLogging(logging =>
                        {
                            logging.AddFilter("Microsoft", LogLevel.Warning)
                            .AddFilter("System", LogLevel.Error);

                            logging.AddSerilog();
                        });
                }
        }
    }
}
