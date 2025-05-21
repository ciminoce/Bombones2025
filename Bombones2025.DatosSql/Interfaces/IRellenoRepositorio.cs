using Bombones2025.Entidades.Entidades;

namespace Bombones2025.DatosSql.Interfaces
{
    public interface IRellenoRepositorio
    {
        void Agregar(Relleno relleno);
        void Borrar(int chocolateId);
        void Editar(Relleno relleno);
        bool Existe(Relleno relleno);
        List<Relleno> GetLista();
        int GetCantidad();
    }
}