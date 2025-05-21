using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IChocolateServicio
    {
        bool Borrar(int chocolateId, out List<string> errores);
        bool Existe(Chocolate chocolate);
        List<Chocolate> GetLista();
        bool Agregar(Chocolate chocolate, out List<string> errores);
        bool Editar(Chocolate chocolate, out List<string> errores);
    }
}