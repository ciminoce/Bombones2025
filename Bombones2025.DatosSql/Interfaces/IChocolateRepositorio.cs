using Bombones2025.Entidades.Entidades;

namespace Bombones2025.DatosSql.Interfaces
{
    public interface IChocolateRepositorio
    {
        void Agregar(Chocolate chocolate);
        void Borrar(int chocolateId);
        void Editar(Chocolate chocolate);
        bool Existe(Chocolate chocolate);
        List<Chocolate> GetLista();
        int GetCantidad();
    }
}