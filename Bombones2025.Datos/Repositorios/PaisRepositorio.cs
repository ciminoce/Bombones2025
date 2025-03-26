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
            return paises.OrderBy(p=>p.NombrePais).ToList();
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
        /// <summary>
        /// Método para retornar el id  más alto  que tengo
        /// dentro de la lista de Paises, sumándole 1
        /// </summary>
        /// <returns></returns>
        private int SetearPaisId()
        {
            return paises.Max(p => p.PaisId) + 1;
        }

        public bool Existe(Pais pais)
        {
            return pais.PaisId == 0 ? paises.Any(p => p.NombrePais == pais.NombrePais) :
                paises.Any(p => p.NombrePais == pais.NombrePais && p.PaisId != pais.PaisId);
        }
        public void Agregar(Pais pais)
        {
            pais.PaisId = SetearPaisId();
            paises.Add(pais);
            if (File.Exists(ruta))
            {
                var registros= File.ReadAllText(ruta);
                if(!string.IsNullOrEmpty(registros) && !registros.EndsWith(Environment.NewLine))
                {
                    File.WriteAllText(ruta, Environment.NewLine);

                }
            }
            using (var escritor=new StreamWriter(ruta,true))
            {
                string linea = ConstruirLinea(pais);
                escritor.WriteLine(linea);
            }
        }

        private string ConstruirLinea(Pais pais)
        {
            return $"{pais.PaisId}|{pais.NombrePais}";
        }

        public void Borrar(Pais pais)
        {
            Pais? paisBorrar = paises.FirstOrDefault(p => p.NombrePais == pais.NombrePais);
            if (paisBorrar is null)
            {
                return;
            }
            paises.Remove(paisBorrar);

            var registros = paises.Select(p => ConstruirLinea(p)).ToArray();
            File.WriteAllLines(ruta, registros);

        }

        public void Editar(Pais pais)
        {
            var paisEditado = paises.FirstOrDefault(p => p.PaisId == pais.PaisId);
            if (paisEditado is null)
            {
                return;
            }
            paisEditado.NombrePais = pais.NombrePais;
            var registros = paises.Select(p => ConstruirLinea(p)).ToArray();
            File.WriteAllLines(ruta, registros);


        }
    }
}
