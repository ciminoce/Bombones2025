namespace Bombones2025.Entidades.Entidades
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; } = null!;
        public string ClaveHash { get; set; } = null!;
    }
}
