using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SeguroAutomotivo.Domian.PropostasPessoaFisica.Infrastructure.Persistence;
using SeguroAutomotivo.Domian.SeguroAutomotivo.PropostasPessoaFisica;
using SeguroAutomotivo.Domian.SeguroAutomotivo.PropostasPessoaFisica.Cadastrar;

namespace SeguroAutomotivo.Bootstrap
{
    internal static class ServiceExtensions
    {
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(x => x.ToString());
                c.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description =
                            "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey
                    }
                );

                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                    }
                );

                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Cdc Consumer",
                        Description = "Consumer consolidator worker.",
                        Version = "v1"
                    }
                );
            });
            return services;
        }

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
               configuration.GetConnectionString("DefaultConnection"),
               x => x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddScoped<UnitOfWork>();

            services.AddScoped<CadastrarPropostasPessoaFisicaHandler>();
            services.AddScoped<SimularPropostasPessoaFisicaHandler>();
            services.AddScoped<PropostaPessoaFisicaRepository>();
            
            return services;
        }
    }
}
