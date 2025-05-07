using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Entidades.Entidades
{
    public class Relleno
    {
        public int RellenoId { get; set; }
        public string Descripcion { get; set; } = null!;
        public override string ToString()
        {
            return $"{Descripcion}";
        }

        public Relleno Clonar()
        {
            return new Relleno()
            {
                RellenoId = RellenoId,
                Descripcion = Descripcion,
            };
        }

    }
}
