using Bombones2025.Entidades.Entidades;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Bombones2025.DatosSql.Repositorios
{
    public class ChocolateRepositorio
    {
        private readonly bool _usarCache;
        private List<Chocolate> chocolatesCache = new();
        private readonly string _connectionString = null!;
        public ChocolateRepositorio(bool usarCache=false)
        {
            _usarCache= usarCache;
            _connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
            if (usarCache)
            {
                LeerDatos();
            }
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
                                chocolatesCache.Add(chocolate);
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
            if (_usarCache)
            {
                return chocolatesCache;

            }
            List<Chocolate> lista = new List<Chocolate>();
            using (var cnn=new SqlConnection(_connectionString))
            {
                cnn.Open();
                string query = @"SELECT ChocolateId, Descripcion
                        FROM Chocolates ORDER BY Descripcion";
                using (var cmd=new SqlCommand(query,cnn))
                {
                    using (var reader=cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Chocolate chocolate = ConstruirChocolate(reader);
                            lista.Add(chocolate);
                        }
                    }
                }
            }
            return lista;
        }

        public bool Existe(Chocolate chocolate)
        {
            if (_usarCache)
            {
                return chocolate.ChocolateId == 0 ? chocolatesCache
                    .Any(c => c.Descripcion.ToLower() == chocolate.Descripcion.ToLower())
                    : chocolatesCache.Any(c => c.Descripcion.ToLower() == chocolate.Descripcion.ToLower()
                    && c.ChocolateId != chocolate.ChocolateId);
            }
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
                if (_usarCache)
                {
                    chocolatesCache.Add(chocolate);

                } 
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
                if (_usarCache)
                {
                    Chocolate? chocolateBorrar = chocolatesCache.FirstOrDefault(f => f.ChocolateId == chocolateId);
                    if (chocolateBorrar is null) return;
                    chocolatesCache.Remove(chocolateBorrar);

                }
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
                if (_usarCache)
                {
                    Chocolate? chocolateEditar = chocolatesCache.FirstOrDefault(f => f.ChocolateId == chocolate.ChocolateId);
                    if (chocolateEditar is null) return;
                    chocolateEditar.Descripcion = chocolate.Descripcion;

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar editar un chocolate", ex);
            }
        }
    }
}
