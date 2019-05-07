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
                    
                    var clientId = builtConfig["Slcs:AzureKeyVault:ClientId"];
                    var clientSecret = builtConfig["Slcs:AzureKeyVault:Secret"];
                    var vaultName = builtConfig["Slcs:AzureKeyVault:VaultName"];
                    var vaultUrl = $"https://{vaultName}.vault.azure.net/";

                    config.AddAzureKeyVault(vaultUrl, clientId, clientSecret);
                })
                //.UseSerilog()
                .UseStartup<Startup>();
    }
}
