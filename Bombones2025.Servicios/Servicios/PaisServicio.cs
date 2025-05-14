using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Utilidades;

namespace Bombones2025.Servicios.Servicios
{
    public class PaisServicio
    {
        private readonly PaisRepositorio _paisRepositorio = null!;
        public PaisServicio()
        {
            try
            {
                _paisRepositorio = new PaisRepositorio(ConstantesDelSistema.umbralCache);

            }
            catch (Exception ex)
            {

                throw ex;
            } 
        }

        public void Borrar(int paisId)
        {
            _paisRepositorio.Borrar(paisId);
        }

        public bool Existe(Pais pais)
        {
            return _paisRepositorio.Existe(pais);
        }

        public List<Pais> Filtrar(string textoParaFiltrar)
        {
            return _paisRepositorio.Filtrar(textoParaFiltrar);
        }

        public List<Pais> GetLista()
        {
            return _paisRepositorio.GetLista();
        }

        public void Guardar(Pais pais)
        {
            if (pais.PaisId == 0)
            {
                _paisRepositorio.Agregar(pais);

            }
            else
            {
                _paisRepositorio.Editar(pais);
            }
        }
    }
}
