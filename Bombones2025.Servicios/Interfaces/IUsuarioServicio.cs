using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IUsuarioServicio
    {
        Usuario? Login(string username);
    }
}