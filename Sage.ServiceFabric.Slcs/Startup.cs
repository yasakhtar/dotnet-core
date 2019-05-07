using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sage.ServiceFabric.ServiceFabric.Core;
using Sage.ServiceFabric.Slcs.Services;
using Serilog;
using Serilog.Enrichers.AspnetcoreHttpcontext;
using Serilog.Events;
using Serilog.Sinks.SumoLogic;

namespace Sage.ServiceFabric.Slcs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Config.AppSettings>(Configuration.GetSection("Slcs"));

            services.AddSlcs();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime applicationLifetime)
        {
            ConfigureSerilog(loggerFactory, applicationLifetime);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void ConfigureSerilog(ILoggerFactory loggerFactory, IApplicationLifetime applicationLifetime)
        {
            var sumoUrl = @"https://endpoint2.collection.sumologic.com/receiver/v1/http/ZaVnC4dhaV3LWI_amXizPs4gb9vYI5KduDd0qCNPjkvgSymJlIu7NeQ7cg3sFSNl79QTEi_cvMnf6vVzUzbHc9S2oe8AMfMaR8xvupIDDnWFsicu3atcBQ==";

            // Create the logger
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .WriteTo.ColoredConsole(
                    LogEventLevel.Information,
                    "{NewLine}{Timestamp:HH:mm:ss} [{Level}] ({CorrelationToken}) {Message}{NewLine}{Exception}")
                .WriteTo.Debug(LogEventLevel.Information,
                    "{NewLine}{Timestamp:HH:mm:ss} [{Level}] ({CorrelationToken}) {Message}{NewLine}{Exception}")
                .WriteTo.SumoLogic(sumoUrl, restrictedToMinimumLevel: LogEventLevel.Information, sourceName: "Dev-serilog-test")
                .CreateLogger();

            loggerFactory.AddSerilog();

            applicationLifetime.ApplicationStopped.Register(Log.CloseAndFlush);
        }
    }
}
