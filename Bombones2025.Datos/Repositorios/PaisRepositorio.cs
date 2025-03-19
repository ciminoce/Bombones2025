using Bombones2025.Entidades;

namespace Bombones2025.Datos.Repositorios
{
    public class PaisRepositorio
    {
        //Atributo privado del repo donde se almacenan los paises
        private List<Pais> paises = new();
        private readonly string ruta = null!;
        public PaisRepositorio(string rutaArchivo)
        {
            ruta=rutaArchivo;
            LeerDatos();
        }
        /// <summary>
        /// Método para enviar la lista de países a otra capa
        /// </summary>
        /// <returns></returns>
        public List<Pais> GetPaises()
        {
            return paises;
        }
        /// <summary>
        /// Método para leer los países desde el archivo secuencial
        /// </summary>
        /// <param name="ruta">Se pasa el nombre del archivo</param>
        private void LeerDatos()
        {
            if (!File.Exists(ruta))
            {
                return;
            }
            var registros = File.ReadAllLines(ruta);
            foreach (var registro in registros)
            {
                Pais pais = ConstruirPais(registro);
                paises.Add(pais);
            }

        }
        /// <summary>
        /// Método privado para obtener un país
        /// </summary>
        /// <param name="registro">Recibe un string con los datos del país separados por |</param>
        /// <returns>Un pais</returns>
        private Pais ConstruirPais(string registro)
        {
            var campos = registro.Split('|');
            var paisId = int.Parse(campos[0]);
            var nombrePais = campos[1];
            return new Pais()
            {
                NombrePais = nombrePais,
                PaisId = paisId,
            };
        }
    }
}
