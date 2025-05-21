using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;

namespace Bombones2025.Servicios.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly UsuarioRepositorio usuarioRepositorio;

        public UsuarioServicio()
        {
            usuarioRepositorio = new UsuarioRepositorio();
        }

        public Usuario? Login(string username)
        {
            return usuarioRepositorio.Login(username);
        }

    }
}
