namespace Bombones2025.Entidades.Entidades
{
    public class Pais
    {
        public int PaisId { get; set; }
        public string NombrePais { get; set; } = null!;
        public override string ToString()
        {
            return $"{NombrePais}";
        }
        public Pais Clonar()
        {
            return new Pais
            {
                PaisId = PaisId,
                NombrePais = NombrePais
            };
        }
    }
}
