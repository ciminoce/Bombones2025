using Bombones2025.Entidades.Entidades;

namespace Bombones2025.DatosSql.Interfaces
{
    public interface IPaisRepositorio
    {
        void Agregar(Pais pais);
        void Borrar(int paisId);
        void Editar(Pais pais);
        bool Existe(Pais pais);
        List<Pais> Filtrar(string textoParaFiltrar);
        List<Pais> GetLista();
        int GetCantidad();
    }
}