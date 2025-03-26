namespace Bombones2025.Entidades
{
    public class FrutoSeco
    {
        public int FrutoSecoId { get; set; }
        public string Descripcion { get; set; } = null!;
        public override string ToString()
        {
            return $"{Descripcion}";
        }
    }
}
