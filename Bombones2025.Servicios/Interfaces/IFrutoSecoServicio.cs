using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IFrutoSecoServicio
    {
        bool Borrar(int frutoId, out List<string> errores);
        bool Existe(FrutoSeco fruto);
        List<FrutoSeco> GetLista();
        bool Agregar(FrutoSeco fruto, out List<string> errores);
        bool Editar(FrutoSeco fruto, out List<string> errores);
    }
}