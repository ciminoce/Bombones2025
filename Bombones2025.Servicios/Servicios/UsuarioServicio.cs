using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Servicios.Servicios
{
    public class UsuarioServicio
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
