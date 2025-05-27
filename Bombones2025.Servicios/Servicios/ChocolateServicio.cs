using Bombones2025.DatosSql.Interfaces;
using Bombones2025.Entidades.Entidades;
using Bombones2025.Servicios.Interfaces;

namespace Bombones2025.Servicios.Servicios
{
    public class ChocolateServicio : IChocolateServicio
    {
        private readonly IChocolateRepositorio? _chocolateRepositorio;
        public ChocolateServicio(IChocolateRepositorio? chocolateRepositorio)
        {
            if(chocolateRepositorio == null)
            {
                throw new InvalidOperationException("El repositorio de chocolates no ha sido inicializado.");
            }
            _chocolateRepositorio = chocolateRepositorio;
        }

        public bool Existe(Chocolate chocolate)
        {
            return _chocolateRepositorio!.Existe(chocolate);
        }

        public List<Chocolate> GetLista()
        {
            return _chocolateRepositorio!.GetLista();
        }

        public bool Borrar(int chocolateId, out List<string> errores)
        {
            errores=new List<string>();
            _chocolateRepositorio!.Borrar(chocolateId);
            return true;
        }

        public bool Agregar(Chocolate chocolate, out List<string> errores)
        {
            errores=new List<string>();
            if (_chocolateRepositorio!.Existe(chocolate))
            {
                errores.Add("Chocolate existente!!!");
                return false;
            }
            _chocolateRepositorio.Agregar(chocolate);
            return true;
        }

        public bool Editar(Chocolate chocolate, out List<string> errores)
        {
            errores = new List<string>();
            if (_chocolateRepositorio!.Existe(chocolate))
            {
                errores.Add("Chocolate existente!!! " + Environment.NewLine + "Edición denegada");
                return false;
            }
            _chocolateRepositorio.Editar(chocolate);
            return true;
        }
    }
}
