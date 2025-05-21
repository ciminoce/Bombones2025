using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IRellenoServicio
    {
        void Borrar(int frutoId);
        bool Existe(Relleno relleno);
        List<Relleno> GetLista();
        void Guardar(Relleno relleno);
    }
}