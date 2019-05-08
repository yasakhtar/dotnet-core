using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
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
                .ConfigureAppConfiguration((context, configBuilder) =>
                {
                    //
                    // An example of using a Config Provider that needs configured before we can use it!
                    //
                    // Adding AzureKeyVault as as ConfigProvider. We read the AzureKeyVaultUrl from config, if we haven't
                    // configured one then just proceed. An alternative would be to not use KeyVault when Environment is Development.
                    //
                    var config = configBuilder.Build();

                    var azureKeyVaultUrl = config["AzureKeyVaultUrl"];
                    if (string.IsNullOrWhiteSpace(azureKeyVaultUrl))
                        return;

                    var tokenProvider = new AzureServiceTokenProvider();
                    var kvClient = new KeyVaultClient((authority, resource, scope) => tokenProvider.KeyVaultTokenCallback(authority, resource, scope));
                    
                    configBuilder.AddAzureKeyVault(azureKeyVaultUrl, kvClient, new DefaultKeyVaultSecretManager());
                })
                //.UseSerilog()
                .UseStartup<Startup>();

    }

}
