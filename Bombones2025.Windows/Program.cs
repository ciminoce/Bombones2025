using Bombones2025.Infraestructura;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Servicios.Servicios;
using Microsoft.Extensions.DependencyInjection;

namespace Bombones2025.Windows
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            AppServices.Inicializar();
            IUsuarioServicio usuarioServicio = AppServices.ServiceProvider
                .GetRequiredService<IUsuarioServicio>();
            Application.Run(new FrmLogin(usuarioServicio));
        }
    }
}