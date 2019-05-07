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
                    var partialConfig = config.Build();
                    
                    var clientId = partialConfig["AzureKeyVault:ClientId"];
                    var clientSecret = partialConfig["AzureKeyVault:Secret"];
                    var vaultName = partialConfig["AzureKeyVault:VaultName"];
                    var vaultUrl = $"https://{vaultName}.vault.azure.net/";

                    if (!string.IsNullOrWhiteSpace(clientSecret))                    
                        config.AddAzureKeyVault(vaultUrl, clientId, clientSecret);
                    
                })
                //.UseSerilog()
                .UseStartup<Startup>();

    }
}
