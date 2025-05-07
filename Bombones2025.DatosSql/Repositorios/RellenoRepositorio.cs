using Bombones2025.Entidades.Entidades;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Bombones2025.DatosSql.Repositorios
{
    public class RellenoRepositorio
    {
        private List<Relleno> rellenos = new();
        private readonly string _connectionString = null!;
        public RellenoRepositorio()
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
                    var query = @"SELECT RellenoId, Descripcion FROM Rellenos ORDER BY Descripcion";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Relleno relleno = ConstruirRelleno(reader);
                                rellenos.Add(relleno);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar leer los rellenos", ex);
            }
        }

        private Relleno ConstruirRelleno(SqlDataReader reader)
        {
            return new Relleno
            {
                RellenoId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }
        public List<Relleno> GetLista()
        {
            return rellenos;
        }

        public bool Existe(Relleno relleno)
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = relleno.RellenoId == 0 ? @"SELECT COUNT(*) FROM Rellenos
                                WHERE LOWER(Descripcion)=@Descripcion"
                        : @"SELECT COUNT(*) FROM Rellenos
                                WHERE LOWER(Descripcion)=@Descripcion
                                AND RellenoId<>@RellenoId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", relleno.Descripcion);
                        if (relleno.RellenoId > 0)
                        {
                            cmd.Parameters.AddWithValue("@RellenoId", relleno.RellenoId);
                        }
                        return (int)cmd.ExecuteScalar() > 0;
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar ver si existe un relleno", ex);
            }
        }

        public void Agregar(Relleno relleno)
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = @"INSERT INTO Rellenos (Descripcion) VALUES (@Descripcion);
                                SELECT SCOPE_IDENTITY();";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", relleno.Descripcion);
                        int id = (int)(decimal)cmd.ExecuteScalar();
                        relleno.RellenoId = id;
                    }
                }
                rellenos.Add(relleno);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar agregar un relleno", ex);
            }
        }

        public void Borrar(int chocolateId)
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = @"DELETE FROM Rellenos WHERE RellenoId=@RellenoId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@RellenoId", chocolateId);
                        cmd.ExecuteNonQuery();
                    }
                }
                Relleno? rellenoBorrar = rellenos.FirstOrDefault(f => f.RellenoId == chocolateId);
                if (rellenoBorrar is null) return;
                rellenos.Remove(rellenoBorrar);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar borrar un relleno", ex);
            }
        }

        public void Editar(Relleno relleno)
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = @"UPDATE Rellenos SET Descripcion=@Descripcion
                    WHERE RellenoId=@RellenoId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", relleno.Descripcion);
                        cmd.Parameters.AddWithValue("@RellenoId", relleno.RellenoId);
                        cmd.ExecuteNonQuery();
                    }

                }
                Relleno? rellenoEditar = rellenos.FirstOrDefault(f => f.RellenoId == relleno.RellenoId);
                if (rellenoEditar is null) return;
                rellenoEditar.Descripcion = relleno.Descripcion;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar editar un relleno", ex);
            }
        }
    }
}
