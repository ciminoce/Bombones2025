namespace Bombones2025.Entidades.Entidades
{
    public class FrutoSeco
    {
        public int FrutoSecoId { get; set; }
        public string Descripcion { get; set; } = null!;
        public override string ToString()
        {
            return $"{Descripcion}";
        }

        public FrutoSeco Clonar()
        {
            return new FrutoSeco()
            {
                FrutoSecoId = FrutoSecoId,
                Descripcion = Descripcion,
            };
        }
    }
}
