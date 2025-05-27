using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IPaisServicio
    {
        bool Borrar(int paisId, out List<string> errores);
        bool Existe(Pais pais);
        List<Pais> Filtrar(string textoParaFiltrar);
        List<Pais> GetLista();
        bool Agregar(Pais pais, out List<string> errores);
        bool Editar(Pais pais, out List<string> errores);
    }
}