using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Entidades.Entidades
{
    public class Chocolate
    {
        public int ChocolateId { get; set; }
        public string Descripcion { get; set; } = null!;
        public override string ToString()
        {
            return $"{Descripcion}";
        }

        public Chocolate Clonar()
        {
            return new Chocolate()
            {
                ChocolateId = ChocolateId,
                Descripcion = Descripcion,
            };
        }

    }
}
