using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;

namespace Bombones2025.Servicios.Servicios
{
    public class PaisServicio : IPaisServicio
    {
        private readonly IPaisRepositorio? _paisRepositorio;
        public PaisServicio(IPaisRepositorio? paisRepositorio)
        {
            _paisRepositorio = paisRepositorio;
        }

        public bool Agregar(Pais pais, out List<string> errores)
        {
            errores = new List<string>();
            if (_paisRepositorio.Existe(pais))
            {
                errores.Add("País existente!!!");
                return false;
            }
            _paisRepositorio.Agregar(pais);
            return true;
        }

        public bool Borrar(int paisId, out List<string> errores)
        {
            errores = new List<string>();
            _paisRepositorio.Borrar(paisId);
            return true;
        }

        public bool Editar(Pais pais, out List<string> errores)
        {
            errores = new List<string>();
            if (_paisRepositorio.Existe(pais))
            {
                errores.Add("País existente!!! " + Environment.NewLine + "Edición denegada");
                return false;
            }
            _paisRepositorio.Editar(pais);
            return true;
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
