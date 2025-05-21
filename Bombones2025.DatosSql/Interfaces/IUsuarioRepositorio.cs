using Bombones2025.Entidades.Entidades;

namespace Bombones2025.DatosSql.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario? Login(string userName);
    }
}