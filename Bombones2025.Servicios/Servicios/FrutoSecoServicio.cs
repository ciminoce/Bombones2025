using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Servicios
{
    public class FrutoSecoServicio
    {
        private readonly FrutoSecoRepositorio _frutoRepositorio = null!;
        public FrutoSecoServicio()
        {
            _frutoRepositorio = new FrutoSecoRepositorio(true);
        }

        public bool Existe(FrutoSeco fruto)
        {
            return _frutoRepositorio.Existe(fruto);
        }

        public List<FrutoSeco> GetLista()
        {
            return _frutoRepositorio.GetLista();
        }

        public void Guardar(FrutoSeco fruto)
        {
            if (fruto.FrutoSecoId == 0){
                _frutoRepositorio.Agregar(fruto);
            }
            else
            {
                _frutoRepositorio.Editar(fruto);
            }
        }

        public void Borrar(int frutoId)
        {
            _frutoRepositorio.Borrar(frutoId);
        }
    }
}
