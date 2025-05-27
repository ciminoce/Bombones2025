using Bombones2025.DatosSql.Interfaces;
using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Utilidades;

namespace Bombones2025.Servicios.Servicios
{
    public class RellenoServicio : IRellenoServicio
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
            if (relleno.RellenoId == 0)
            {
                _rellenoRepositorio.Agregar(relleno);
            }
            else
            {
                _rellenoRepositorio.Editar(relleno);
            }
        }

        public bool Borrar(int rellenoId, out List<string> errores)
        {
            errores = new List<string>();
            _rellenoRepositorio.Borrar(rellenoId);
            return true;
        }

        public bool Agregar(Relleno relleno, out List<string> errores)
        {
            errores = new List<string>();
            if (_rellenoRepositorio.Existe(relleno))
            {
                errores.Add("País existente!!!");
                return false;
            }
            _rellenoRepositorio.Agregar(relleno);
            return true;
        }

        public bool Editar(Relleno relleno, out List<string> errores)
        {
            errores = new List<string>();
            if (_rellenoRepositorio.Existe(relleno))
            {
                errores.Add("Relleno existente!!! " + Environment.NewLine + "Edición denegada");
                return false;
            }
            _rellenoRepositorio.Editar(relleno);
            return true;
        }
    }
}
