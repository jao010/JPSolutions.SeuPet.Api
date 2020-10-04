using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace JPSolutions.SeuPet.Api.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection SwaggerConfigureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Seu Pet API",
                    Description = "API para comunicação como site www.seupet.com.br",
                    Contact = new OpenApiContact
                    {
                        Name = configuration["DadosParaContato:Nome"],
                        Email = configuration["DadosParaContato:Email"],
                        Url = new Uri(configuration["DadosParaContato:Linkedin"]),
                    }
                });
            });
            return services;
        }

        public static IApplicationBuilder SwaggerConfigure(this IApplicationBuilder app)
        {
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Seu Pet V1");
            });
            return app;
        }
    }
}
