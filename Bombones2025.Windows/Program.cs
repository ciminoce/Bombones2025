using Bombones2025.Servicios.Servicios;

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
            UsuarioServicio usuarioServicio = new UsuarioServicio();
            Application.Run(new FrmLogin(usuarioServicio));
        }
    }
}