using Bombones2025.Entidades.Entidades;

namespace Bombones2025.DatosSql.Interfaces
{
    public interface IFrutoSecoRepositorio
    {
        void Agregar(FrutoSeco fruto);
        void Borrar(int frutoId);
        void Editar(FrutoSeco fruto);
        bool Existe(FrutoSeco fruto);
        List<FrutoSeco> GetLista();
        void RecargarCache();
        int GetCantidad();
    }
}