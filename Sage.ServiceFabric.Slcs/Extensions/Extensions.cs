using Microsoft.Extensions.DependencyInjection;
using Sage.ServiceFabric.ServiceFabric.Core;
using Sage.ServiceFabric.Slcs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
            
    }
}
