using System;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using Npgsql;

namespace Datos.Conexiones
{
    public class Conexiones
    {
        
        public Conexiones()
        {
        }


        private readonly string connectionString = "Host=ep-still-brook-a2m8tgov-pooler.eu-central-1.aws.neon.tech;" +
                                           "Username=tfg_owner;" +
                                           "Password=npg_ElXtVLGa6ZP1;" +
                                           "Database=tfg;" +
                                           "SslMode=Require;" +
                                           "Trust Server Certificate=true";


        private readonly string RutaBD = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TPV.db"));

        /// <summary>
        /// Abre y devuelve una conexión activa a la base de datos PostgreSQL (NeonDB).
        /// </summary>
        /// <returns>Instancia abierta de <see cref="NpgsqlConnection"/> conectada a la base de datos PostgreSQL.</returns>
        /// <exception cref="Exception">Se lanza si ocurre un error al intentar abrir la conexión.</exception>
        public NpgsqlConnection ObtenerConexion()
        {
            try
            {
                var conexion = new NpgsqlConnection(connectionString);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Abre y devuelve una conexión activa a la base de datos SQLite (local).
        /// </summary>
        /// <returns>Instancia abierta de <see cref="SQLiteConnection"/> conectada a la base de datos local.</returns>
        /// <exception cref="Exception">Se lanza si ocurre un error al intentar abrir la conexión.</exception>
        public SQLiteConnection ObtenerConexionSql()
        {
            try
            {
                var conexion = new SQLiteConnection($"Data Source={RutaBD};Version=3;");
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
