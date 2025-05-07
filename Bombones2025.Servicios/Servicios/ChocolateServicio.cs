using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Entidades.Entidades;

namespace Bombones2025.Servicios.Servicios
{
    public class ChocolateServicio
    {
        private readonly ChocolateRepositorio _chocolateRepositorio = null!;
        public ChocolateServicio()
        {
            _chocolateRepositorio = new ChocolateRepositorio();
        }

        public bool Existe(Chocolate chocolate)
        {
            return _chocolateRepositorio.Existe(chocolate);
        }

        public List<Chocolate> GetLista()
        {
            return _chocolateRepositorio.GetLista();
        }

        public void Guardar(Chocolate chocolate)
        {
            if (chocolate.ChocolateId == 0){
                _chocolateRepositorio.Agregar(chocolate);
            }
            else
            {
                _chocolateRepositorio.Editar(chocolate);
            }
        }

        public void Borrar(int frutoId)
        {
            _chocolateRepositorio.Borrar(frutoId);
        }
    }
}
