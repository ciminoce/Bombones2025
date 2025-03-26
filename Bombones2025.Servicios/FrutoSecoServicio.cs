using Bombones2025.Datos.Repositorios;
using Bombones2025.Entidades;

namespace Bombones2025.Servicios
{
    public class FrutoSecoServicio
    {
        private readonly FrutoSecoRepositorio _frutoRepositorio = null!;
        public FrutoSecoServicio(string ruta)
        {
            _frutoRepositorio = new FrutoSecoRepositorio(ruta);
        }


        public List<FrutoSeco> GetLista()
        {
            return _frutoRepositorio.GetLista();
        }
    }
}
