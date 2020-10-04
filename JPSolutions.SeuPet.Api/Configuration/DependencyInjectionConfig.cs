using JPSolutions.SeuPet.Api.Domain.Extensions;
using JPSolutions.SeuPet.Api.Domain.Interfaces;
using JPSolutions.SeuPet.Api.Infra.Contexts;
using JPSolutions.SeuPet.Api.Infra.Repository;
using JPSolutions.SeuPet.Api.Service;
using JPSolutions.SeuPet.Api.Service.Services;
using JPSolutions.SeuPet.Api.Service.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JPSolutions.SeuPet.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.AddScoped<INotificador, Notificador>();
            services.Repository(configuration);
            services.Services();
            return services;
        }

        private static IServiceCollection Repository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SeuPetContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICategoriaPetRepository, CategoriaPetRepository>();
            return services;
        }

        private static IServiceCollection Services(this IServiceCollection services)
        {
            services.AddScoped<GerarJwtService>();
            services.AddScoped<UsuarioService>();
            services.AddScoped<PetService>();
            return services;
        }

        public static IApplicationBuilder ResolveDependencyConfigure(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
