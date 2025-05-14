using Bombones2025.Entidades.Entidades;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Bombones2025.DatosSql.Repositorios
{
    public class PaisRepositorio
    {
        private readonly bool _usarCache;
        private List<Pais> paises = new();
        private readonly string? _connectionString;
        public PaisRepositorio(int umbralCache=30)
        {
            _connectionString = ConfigurationManager
                    .ConnectionStrings["MiConexion"].ToString();
            var cantidadRegistros = ObtenerCantidadRegistros();
            _usarCache = cantidadRegistros <= umbralCache;
            if (_usarCache)
            {
                LeerDatos();

            }
        }
        /// <summary>
        /// Método privado por ahora para obtener la cantidad de registros
        /// de la tabla
        /// </summary>
        /// <returns>un int con la cantidad de registros</returns>
        private int ObtenerCantidadRegistros()
        {
            using (var cnn=new SqlConnection(_connectionString))
            {
                cnn.Open();
                string query = @"SELECT COUNT(*) FROM Paises";
                using (var cmd = new SqlCommand(query, cnn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// Método privado para leer los registros de la tabla de Paises
        /// y almacenarlos en la lista del repositorio
        /// </summary>
        private void LeerDatos()
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
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
        public List<Pais> GetLista()
        {
            if (_usarCache)
            {
                return paises.OrderBy(p => p.NombrePais).ToList();
            }
            List<Pais> lista = new List<Pais>();
            using (var cnn=new SqlConnection(_connectionString))
            {
                cnn.Open();
                var query = "SELECT PaisId, NombrePais FROM Paises ORDER BY NombrePais";
                using (var cmd=new SqlCommand(query,cnn))
                {
                    using (var reader=cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pais p = ConstruirPais(reader);
                            lista.Add(p);
                        }
                    }
                }
            }
            return lista;
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
                using (var cnn = new SqlConnection(_connectionString))
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
                if (_usarCache)
                {
                    paises.Add(pais);

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex);
            } 
        }

        public bool Existe(Pais pais)
        {
            if (_usarCache)
            {
                return pais.PaisId==0?paises.Any(p=>p.NombrePais==pais.NombrePais)
                    : paises.Any(p=>p.NombrePais==pais.NombrePais
                        && p.PaisId!=pais.PaisId);
            }
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query;
                    if (pais.PaisId == 0)
                    {
                        query = @"SELECT COUNT(*) FROM Paises 
                            WHERE LOWER(NombrePais)=LOWER(@NombrePais)";

                    }
                    else
                    {
                        query = @"SELECT COUNT(*) FROM Paises 
                            WHERE LOWER(NombrePais)=LOWER(@NombrePais) AND 
                                PaisId<>@PaisId";
                    }
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        if (pais.PaisId != 0)
                        {
                            cmd.Parameters.AddWithValue("@PaisId", pais.PaisId);
                        }
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
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = @"DELETE FROM Paises WHERE PaisId=@PaisId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@PaisId", paisId);
                        cmd.ExecuteNonQuery();
                    }
                }
                if (_usarCache)
                {
                    Pais? paisBorrar = paises.FirstOrDefault(p => p.PaisId == paisId);
                    if (paisBorrar == null) return;
                    paises.Remove(paisBorrar);

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar borrar el registro", ex);
            }
        }

        public void Editar(Pais pais)
        {
            try
            {
                using (var cnn=new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    var query = @"UPDATE Paises SET NombrePais=@NombrePais
                               WHERE PaisId=@PaisId";
                    using (var cmd=new SqlCommand(query,cnn))
                    {
                        cmd.Parameters.AddWithValue("@NombrePais", pais.NombrePais);
                        cmd.Parameters.AddWithValue("@PaisId", pais.PaisId);
                        cmd.ExecuteNonQuery();
                    }
                    if (_usarCache)
                    {
                        Pais? paisEditar = paises.FirstOrDefault(p => p.PaisId == pais.PaisId);
                        if (paisEditar == null) return;
                        paisEditar.NombrePais = pais.NombrePais;

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar editar el registro",ex);
            }
        }

        public List<Pais> Filtrar(string textoParaFiltrar)
        {
            if (_usarCache)
            {
                return paises
                    .Where(p => p.NombrePais
                        .StartsWith(textoParaFiltrar)).ToList();
            }
            var listaFiltrada = new List<Pais>();

            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    var query = @"select * from Paises WHERE NombrePais LIKE @texto";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        textoParaFiltrar += "%";
                        cmd.Parameters.AddWithValue("@texto", textoParaFiltrar);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var pais = ConstruirPais(reader);
                                listaFiltrada.Add(pais);
                            }
                        }
                    }
                }
                return listaFiltrada;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar filtrar los países",ex);
            }
        }
    }
}
