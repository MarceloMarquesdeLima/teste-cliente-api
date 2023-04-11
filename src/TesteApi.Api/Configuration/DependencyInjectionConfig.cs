using Opea.Data.Context;
using Opea.Domain.Interfaces;
using Opea.Domain.Interfaces.Repositorio;
using Opea.Domain.Notificacoes;
using TesteApi.Data.Repositorio;

namespace TesteApi.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
