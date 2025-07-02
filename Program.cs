using AutoInsurance.Bootstrap;
using AutoInsurance.Common.Settings;
using AutoInsurance.Domian.AutoInsurance.Infrastructure.Persistence;
using AutoInsurance.Domian.Orchestration.PolicyIssuance;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using WorkflowCore.Interface;

var builder = WebApplication.CreateBuilder(args);
var assemblyName = Assembly.GetExecutingAssembly().GetName();
var serviceName = assemblyName.Name;
var serviceVersion = Environment.GetEnvironmentVariable("DD_VERSION") ??
                     Assembly.GetExecutingAssembly().GetName().Version?.ToString();


builder
.Configuration
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
.AddUserSecrets<Program>()
.AddEnvironmentVariables();

builder.Services
    .AddCors()
    .AddFastEndpoints()
    .SwaggerDocument()
    .AddHttpContextAccessor()
    .AddOptions()
    .AddDependencyInjection(builder.Configuration)
    .AddWorkflow(/*x => x.UsePostgreSQL(builder.Configuration.GetConnectionString("DefaultConnection"), true, true)*/);

var app = builder.Build();
var basePath = builder.Configuration["BasePath"];
app
    .UseCors(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
    .UseDefaultExceptionHandler()
    .UseFastEndpoints(config =>
    {
        if (!string.IsNullOrWhiteSpace(basePath)) config.Endpoints.RoutePrefix = basePath;
    })
    .UseSwaggerGen(config =>
    {
        if (!string.IsNullOrWhiteSpace(basePath)) config.Path = $"/{basePath}/{config.Path}";
    },
        settings =>
        {
            if (!string.IsNullOrWhiteSpace(basePath))
            {
                settings.Path = $"/{basePath}/swagger";
                settings.DocumentPath = $"/{basePath}/{settings.DocumentPath}";
            }
        });
using var scope = app.Services.CreateScope();
await scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.MigrateAsync();

app.Services.GetService<IWorkflowHost>().RegisterWorkflow<PolicyIssuanceWorkflowDefinition, PolicyIssuanceWorkflowData>();
app.Services.GetService<IWorkflowHost>().Start();

await app.RunAsync();

return 0;


