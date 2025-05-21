using Bombones2025.DatosSql.Interfaces;
using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Servicios.Servicios;
using Microsoft.Extensions.DependencyInjection;

namespace Bombones2025.Infraestructura
{
    public static class AppServices
    {
        private static IServiceProvider? _serviceProvider;

        public static void Inicializar()
        {
            var services = new ServiceCollection();

            services.AddScoped<IPaisRepositorio, PaisRepositorio>();
            services.AddScoped<IRellenoRepositorio, RellenoRepositorio>();
            services.AddScoped<IChocolateRepositorio, ChocolateRepositorio>();
            services.AddScoped<IFrutoSecoRepositorio, FrutoSecoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddScoped<IPaisServicio, PaisServicio>();
            services.AddScoped<IRellenoServicio, RellenoServicio>();
            services.AddScoped<IChocolateServicio, ChocolateServicio>();
            services.AddScoped<IFrutoSecoServicio, FrutoSecoServicio>();
            services.AddScoped<IUsuarioServicio, UsuarioServicio>();

            _serviceProvider = services.BuildServiceProvider();

        }
        public static IServiceProvider? ServiceProvider =>
            _serviceProvider ?? throw new NotImplementedException("Dependencias no establecidas");
    }
}
