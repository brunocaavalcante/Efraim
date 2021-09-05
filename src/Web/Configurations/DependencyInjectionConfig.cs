using Microsoft.Extensions.DependencyInjection;
using Business.Interfaces;
using Business.Services;
using Business.Core.Intefaces;
using Business.Core.Notificacoes;
using Data.Repository;

namespace Web.Configurations
{
    public static class DependencyInjectionConfig
    {     
        public static IServiceCollection ResolverDependencias(this IServiceCollection services)
        {
            services.AddScoped<IMembroService, MembroService>();
            services.AddScoped<IMembroRepository, MembroRepository>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();

            return services;
        }
    }
}