using Microsoft.Data.SqlClient;
using System;
namespace ExamenBi

{
    public class ConexionDB
    {
        private string connectionString = "Server=localhost;Database=LigaApi;User Id=sa;Password=Your_password123;TrustServerCertificate=True;";
    

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        public void ProbarConexion()
        {
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión exitosa a la base de datos.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                }
            }
        }
    }
}

