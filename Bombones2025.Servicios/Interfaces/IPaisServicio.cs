using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Interfaces
{
    public interface IPaisServicio
    {
        void Borrar(int paisId);
        bool Existe(Pais pais);
        List<Pais> Filtrar(string textoParaFiltrar);
        List<Pais> GetLista();
        void Guardar(Pais pais);
    }
}