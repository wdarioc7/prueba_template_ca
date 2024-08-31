using Microsoft.Extensions.DependencyInjection;
using rdt_ms_template_netcore_ca.Infraestructure;
using rdt_ms_template_netcore_ca.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace rdt_ms_template_netcore_ca.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            services.AddApplicationDI().AddInfraestructureDI().AddCoreDI(); 
            return services;
        }
    }
}
