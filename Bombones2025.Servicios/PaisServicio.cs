using Bombones2025.Datos.Repositorios;
using Bombones2025.Entidades;

namespace Bombones2025.Servicios
{
    public class PaisServicio
    {
        private readonly PaisRepositorio _paisRepositorio = null!;
        public PaisServicio(string ruta)
        {
            _paisRepositorio = new PaisRepositorio(ruta);
        }


        public List<Pais> GetPaises()
        {
            return _paisRepositorio.GetPaises();
        }
    }
}
