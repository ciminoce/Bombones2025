using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Utilidades;

namespace Bombones2025.Servicios.Servicios
{
    public class RellenoServicio
    {
        private readonly RellenoRepositorio _rellenoRepositorio = null!;
        public RellenoServicio()
        {
            _rellenoRepositorio = new RellenoRepositorio(ConstantesDelSistema.umbralCache);
        }

        public bool Existe(Relleno relleno)
        {
            return _rellenoRepositorio.Existe(relleno);
        }

        public List<Relleno> GetLista()
        {
            return _rellenoRepositorio.GetLista();
        }

        public void Guardar(Relleno relleno)
        {
            if (relleno.RellenoId == 0){
                _rellenoRepositorio.Agregar(relleno);
            }
            else
            {
                _rellenoRepositorio.Editar(relleno);
            }
        }

        public void Borrar(int frutoId)
        {
            _rellenoRepositorio.Borrar(frutoId);
        }
    }
}
