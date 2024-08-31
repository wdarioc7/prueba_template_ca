using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using rdt_ms_template_netcore_ca.Application.Queries;
using rdt_ms_template_netcore_ca.Core.Entities;
using rdt_ms_template_netcore_ca.Core.Interfaces;
using rdt_ms_template_netcore_ca.Infraestructure.Data;
using rdt_ms_template_netcore_ca.Infraestructure.Helpers;
using rdt_ms_template_netcore_ca.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace rdt_ms_template_netcore_ca.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructureDI(this IServiceCollection services)
        {
            //si se requiere se puede manejar la cadena de conexion en el lado de la infraestructura
            var root = Directory.GetCurrentDirectory();
            var dotenv = Path.Combine(root, ".env");
            Helpers.DotEnv.Load(dotenv);
            var dbHost = DotNetEnv.Env.GetString("DB_HOST_TECNICAL");
            var dbPort = DotNetEnv.Env.GetString("DB_PORT_TECNICAL");
            var dbName = DotNetEnv.Env.GetString("DB_NAME_TECNICAL");
            var dbUser = DotNetEnv.Env.GetString("DB_USER_TECNICAL");
            var dbPass = DotNetEnv.Env.GetString("DB_PASS_TECNICAL");

            services.AddDbContext<UsersContext>(options =>
            options.UseMySQL("Server=dbcafe.c8dbwo8eypho.us-east-1.rds.amazonaws.com;Port=3306;Database=INV_SYS;User Id=admin;Password=Formula2025**99"));


            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IProductRepository), typeof(ProductRepository));
                cfg.AddBehavior(typeof(IRequest<IEnumerable<ProductEntity>>), typeof(GetAllProductQuery));
                cfg.AddBehavior(typeof(IRequestHandler<GetAllProductQuery, IEnumerable<ProductEntity>>), typeof(GetAllProductQueryHandler));
            });

            return services;
        }
    }
}
