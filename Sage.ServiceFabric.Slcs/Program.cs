using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SumoLogic;

namespace Sage.ServiceFabric.Slcs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var builtConfig = config.Build();

                    var vault = builtConfig["Slcs:AzureKeyVault:Url"];
                    var clientId = builtConfig["Slcs:AzureKeyVault:ApplicationId"];
                    var clientSecret = builtConfig["Slcs:AzureKeyVault:SecretKey"];

                    config.AddAzureKeyVault(vault, clientId, clientSecret);
                })
                //.UseSerilog()
                .UseStartup<Startup>();
    }
}
