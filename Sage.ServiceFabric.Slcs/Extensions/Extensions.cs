using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sage.ServiceFabric.ServiceFabric.Core;
using Sage.ServiceFabric.Slcs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Sage.ServiceFabric.Slcs
{
    public static class Extensions
    {
        public static void AddSlcs(this IServiceCollection services)
        {
            services.AddTransient<IValuesService, ValuesService>();
            services.AddScoped<IValuesRepository, ValuesRepository>();
            services.AddScoped<CallContext>();
        }
        public static void Information(this ILogger logger,
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            logger.LogInformation("{message}{newLine}memberName:{memberName}, sourceFilePath: {sourceFilePath}, lineNumber: {sourceLineNumber}", message, Environment.NewLine, memberName, sourceFilePath, sourceLineNumber);
        }
    }
}
