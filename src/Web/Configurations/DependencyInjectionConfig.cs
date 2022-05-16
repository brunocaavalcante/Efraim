using Business.Core.Intefaces;
using Business.Core.Notificacoes;
using Business.Interfaces;
using Business.Services;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolverDependencias(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<ICaixaService, CaixaService>();
            services.AddScoped<ICaixaRepository, CaixaRepository>();
            services.AddScoped<IPermissaoService, PermissaoService>();
            services.AddScoped<IPermissaoRepository, PermissaoRepository>();
            services.AddScoped<IPerfilService, PerfilService>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();

            return services;
        }
    }
}