namespace Bombones2025.Windows.Helpers
{
    public static class SeguridadHelper
    {
        // Genera un hash seguro con salt
        public static string GenerarHash(string clave)
        {
            return BCrypt.Net.BCrypt.HashPassword(clave);
        }

        // Verifica la clave ingresada contra el hash almacenado
        public static bool VerificarHash(string claveIngresada, string hashAlmacenado)
        {
            return BCrypt.Net.BCrypt.Verify(claveIngresada, hashAlmacenado);
        }
    }
}
