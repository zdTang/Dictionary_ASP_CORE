using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Dictionary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();// Originally 
            Log.log("@@@@====MAIN====@@@@");
            CreateHostBuilder(args).Build().Run();
            //var logger = host.Services.GetRequiredService<ILogger<Program>>();
            //logger.LogInformation("Seeded the database.");
            //host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-3.0
                // TO USE LOG
                //.ConfigureLogging(logging =>
                //{
                    
                //    logging.ClearProviders();
                //    //logging.SetMinimumLevel(LogLevel.Information);
                //    logging.AddConsole();
                //    //logging.AddDebug();
                //    //logging.AddEventSourceLogger();
                //})
            
                //===================================
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
