using Bombones2025.Entidades.Entidades;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Bombones2025.DatosSql.Repositorios
{
    public class ChocolateRepositorio
    {
        private List<Chocolate> chocolates = new();
        private readonly string _connectionString = null!;
        public ChocolateRepositorio()
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
                    var query = @"SELECT ChocolateId, Descripcion FROM Chocolates ORDER BY Descripcion";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Chocolate chocolate = ConstruirChocolate(reader);
                                chocolates.Add(chocolate);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar leer los chocolates", ex);
            }
        }

        private Chocolate ConstruirChocolate(SqlDataReader reader)
        {
            return new Chocolate
            {
                ChocolateId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }
        public List<Chocolate> GetLista()
        {
            return chocolates;
        }

        public bool Existe(Chocolate chocolate)
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = chocolate.ChocolateId == 0 ? @"SELECT COUNT(*) FROM Chocolates
                                WHERE LOWER(Descripcion)=@Descripcion"
                        : @"SELECT COUNT(*) FROM Chocolates
                                WHERE LOWER(Descripcion)=@Descripcion
                                AND ChocolateId<>@ChocolateId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", chocolate.Descripcion);
                        if (chocolate.ChocolateId > 0)
                        {
                            cmd.Parameters.AddWithValue("@ChocolateId", chocolate.ChocolateId);
                        }
                        return (int)cmd.ExecuteScalar() > 0;
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar ver si existe un chocolate", ex);
            }
        }

        public void Agregar(Chocolate chocolate)
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = @"INSERT INTO Chocolates (Descripcion) VALUES (@Descripcion);
                                SELECT SCOPE_IDENTITY();";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", chocolate.Descripcion);
                        int id = (int)(decimal)cmd.ExecuteScalar();
                        chocolate.ChocolateId = id;
                    }
                }
                chocolates.Add(chocolate);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar agregar un chocolate", ex);
            }
        }

        public void Borrar(int chocolateId)
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = @"DELETE FROM Chocolates WHERE ChocolateId=@ChocolateId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@ChocolateId", chocolateId);
                        cmd.ExecuteNonQuery();
                    }
                }
                Chocolate? chocolateBorrar = chocolates.FirstOrDefault(f => f.ChocolateId == chocolateId);
                if (chocolateBorrar is null) return;
                chocolates.Remove(chocolateBorrar);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar borrar un chocolate", ex);
            }
        }

        public void Editar(Chocolate chocolate)
        {
            try
            {
                using (var cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = @"UPDATE Chocolates SET Descripcion=@Descripcion
                    WHERE ChocolateId=@ChocolateId";
                    using (var cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Descripcion", chocolate.Descripcion);
                        cmd.Parameters.AddWithValue("@ChocolateId", chocolate.ChocolateId);
                        cmd.ExecuteNonQuery();
                    }

                }
                Chocolate? chocolateEditar = chocolates.FirstOrDefault(f => f.ChocolateId == chocolate.ChocolateId);
                if (chocolateEditar is null) return;
                chocolateEditar.Descripcion = chocolate.Descripcion;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar editar un chocolate", ex);
            }
        }
    }
}
