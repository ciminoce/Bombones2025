using Bombones2025.Entidades;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Bombones2025.DatosSql.Repositorios
{
    public class PaisRepositorio
    {
        private List<Pais> paises = new();
        private readonly string? connectionString;
        public PaisRepositorio()
        {
            connectionString = ConfigurationManager
                    .ConnectionStrings["MiConexion"].ToString();
            LeerDatos();
        }
        /// <summary>
        /// Método privado para leer los registros de la tabla de Paises
        /// y almacenarlos en la lista del repositorio
        /// </summary>
        private void LeerDatos()
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = "SELECT PaisId, NombrePais FROM Paises";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Pais pais = ConstruirPais(reader);
                                paises.Add(pais);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex);
            } 
        }
        /// <summary>
        /// Método para devolver la lista de paises ordenada por nombre
        /// de país
        /// </summary>
        /// <returns></returns>
        public List<Pais> GetPaises()
        {
            return paises.OrderBy(p => p.NombrePais).ToList();
        }
        /// <summary>
        /// Método privado para construir un objeto de tipo pais
        /// </summary>
        /// <param name="reader">Registro del SqlDataReader que contiene los datos</param>
        /// <returns>un nuevo país con los datos del reader</returns>
        private Pais ConstruirPais(SqlDataReader reader)
        {
            return new Pais
            {
                PaisId = reader.GetInt32(0),
                NombrePais = reader.GetString(1)
            };
        }
        public void Agregar(Pais pais)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"INSERT INTO Paises (NombrePais)
                    VALUES(@NombrePais); SELECT SCOPE_IDENTITY();";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@NombrePais", pais.NombrePais);
                        int paisId = (int)(decimal)cmd.ExecuteScalar();
                        pais.PaisId = paisId;
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex);
            } 
        }

        public bool Existe(Pais pais)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"SELECT COUNT(*) FROM Paises 
                        WHERE LOWER(NombrePais)=LOWER(@NombrePais)";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@NombrePais", pais.NombrePais);
                        int cantidad = (int)cmd.ExecuteScalar();
                        return cantidad > 0;
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex);
            } 
        }

        public void Borrar(int paisId)
        {
            try
            {
                using (var cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string query = @"DELETE FROM Paises WHERE PaisId=@PaisId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@PaisId", paisId);
                        cmd.ExecuteNonQuery();
                    }
                }
                Pais? paisBorrar=paises.FirstOrDefault(p=>p.PaisId==paisId);
                if (paisBorrar == null) return;
                paises.Remove(paisBorrar);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
