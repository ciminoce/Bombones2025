using Bombones2025.Entidades;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Bombones2025.DatosSql.Repositorios
{
    public class FrutoSecoRepositorio
    {
        private List<FrutoSeco> frutos = new();
        private readonly string _connectionString = null!;
        public FrutoSecoRepositorio()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
            LeerDatos();
        }

        private void LeerDatos()
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    var query = @"SELECT FrutoSecoId, Descripcion FROM FrutosSecos ORDER BY Descripcion";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FrutoSeco fs = ConstruirFrutoSeco(reader);
                                frutos.Add(fs);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar leer los frutos secos", ex);
            }
        }

        private FrutoSeco ConstruirFrutoSeco(SqlDataReader reader)
        {
            return new FrutoSeco
            {
                FrutoSecoId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }
        public List<FrutoSeco> GetLista()
        {
            return frutos;
        }

        public bool Existe(FrutoSeco fruto)
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = fruto.FrutoSecoId == 0 ? @"SELECT COUNT(*) FROM FrutosSecos
                                WHERE LOWER(Descripcion)=@Descripcion"
                        : @"SELECT COUNT(*) FROM FrutosSecos
                                WHERE LOWER(Descripcion)=@Descripcion
                                AND FrutoSecoId<>@FrutoSecoId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", fruto.Descripcion);
                        if (fruto.FrutoSecoId > 0)
                        {
                            cmd.Parameters.AddWithValue("@FrutoSecoId", fruto.FrutoSecoId);
                        }
                        return (int)cmd.ExecuteScalar() > 0;
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar ver si existe un fruto seco", ex);
            }
        }

        public void Agregar(FrutoSeco fruto)
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = @"INSERT INTO FrutosSecos (Descripcion) VALUES (@Descripcion);
                                SELECT SCOPE_IDENTITY();";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", fruto.Descripcion);
                        int id = (int)(decimal)cmd.ExecuteScalar();
                        fruto.FrutoSecoId = id;
                    }
                }
                frutos.Add(fruto);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar agregar un fruto seco", ex);
            }
        }

        public void Borrar(int frutoId)
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = @"DELETE FROM FrutosSecos WHERE FrutoSecoId=@FrutoSecoId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@FrutoSecoId", frutoId);
                        cmd.ExecuteNonQuery();
                    }
                }
                FrutoSeco? fsBorrar = frutos.FirstOrDefault(f => f.FrutoSecoId == frutoId);
                if (fsBorrar is null) return;
                frutos.Remove(fsBorrar);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar borrar un fruto seco", ex);
            }
        }

        public void Editar(FrutoSeco fruto)
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = @"UPDATE FrutosSecos SET Descripcion=@Descripcion
                    WHERE FrutoSecoId=@FrutoSecoId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", fruto.Descripcion);
                        cmd.Parameters.AddWithValue("@FrutoSecoId", fruto.FrutoSecoId);
                        cmd.ExecuteNonQuery();
                    }

                }
                FrutoSeco? fsEditar = frutos.FirstOrDefault(f => f.FrutoSecoId == fruto.FrutoSecoId);
                if (fsEditar is null) return;
                fsEditar.Descripcion = fruto.Descripcion;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar editar un fruto seco", ex);
            }
        }
    }
}
