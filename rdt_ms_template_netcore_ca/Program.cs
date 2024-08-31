using System.Diagnostics.CodeAnalysis;
using System;
using rdt_ms_template_netcore_ca.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using rdt_ms_template_netcore_ca.Infraestructure;
using rdt_ms_template_netcore_ca.Infraestructure.Data;
using rdt_ms_template_netcore_ca.Infraestructure.Helpers;
using MediatR;
using rdt_ms_template_netcore_ca.Application;
using System.Reflection;
using rdt_ms_template_netcore_ca.Core.Interfaces;
using rdt_ms_template_netcore_ca.Infraestructure.Repositories;
using rdt_ms_template_netcore_ca.Core.Entities;
using rdt_ms_template_netcore_ca.Application.Queries;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "PRUEBA DARIO CAMPAÑA-TEMPLATE", Version = "v1" });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("*");
        });
});
var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, ".env");
rdt_ms_template_netcore_ca.Helpers.DotEnv.Load(dotenv);
var dbHost = DotNetEnv.Env.GetString("DB_HOST_TECNICAL");
var dbPort = DotNetEnv.Env.GetString("DB_PORT_TECNICAL");
var dbName = DotNetEnv.Env.GetString("DB_NAME_TECNICAL");
var dbUser = DotNetEnv.Env.GetString("DB_USER_TECNICAL");
var dbPass = DotNetEnv.Env.GetString("DB_PASS_TECNICAL");
//builder.Services.AddDbContext<UsersContext>(options =>
//    options.UseMySQL("Host=" + dbHost + ":" + dbPort + "; Database=" + dbName + "; Username=" + dbUser + "; Password=" + dbPass));
builder.Services.AddDbContext<UsersContext>(options =>
    options.UseMySQL("Server=dbcafe.c8dbwo8eypho.us-east-1.rds.amazonaws.com;Port=3306;Database=INV_SYS;User Id=admin;Password=Formula2025**99"));

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.AddBehavior(typeof(IProductRepository), typeof(ProductRepository));
    cfg.AddBehavior(typeof(IRequest<IEnumerable<ProductEntity>>), typeof(GetAllProductQuery));
    cfg.AddBehavior(typeof(IRequestHandler<GetAllProductQuery, IEnumerable<ProductEntity>>), typeof(GetAllProductQueryHandler));
});
builder.Services.AddAppDI();
//builder.Services.AddDependencies();
builder.Services.AddHealthChecks();

builder.Services.AddControllers().AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddHealthChecks();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI(c =>
{
c.SwaggerEndpoint("/swagger/v1/swagger.json", "MICROSERVICIOS TEMPLATE PRUEBA TECNICA NET CORE V1 DARIO CAMPAÑA");
});
}

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("Health");
app.Run();


///<summary>
/// Extensión para Unit Test
/// </summary>
public partial class Program { }
