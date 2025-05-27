using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;

namespace Bombones2025.Servicios.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio? _usuarioRepositorio;

        public UsuarioServicio(IUsuarioRepositorio? usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public Usuario? Login(string username)
        {
            return _usuarioRepositorio.Login(username);
        }

    }
}
