using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IFrutoSecoServicio
    {
        void Borrar(int frutoId);
        bool Existe(FrutoSeco fruto);
        List<FrutoSeco> GetLista();
        void Guardar(FrutoSeco fruto);
    }
}