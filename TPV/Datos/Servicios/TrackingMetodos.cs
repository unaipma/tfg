using Datos.Modelos;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Datos.Servicios
{
    public class TrackingMetodos
    {
        private Conexiones.Conexiones ConexionDB = new Conexiones.Conexiones();

        /// <summary>
        /// Añade un registro de acceso (track) del usuario en la tabla logintrack.
        /// </summary>
        /// <param name="correo">Correo electrónico del usuario que inicia sesión.</param>
        /// <returns>True si el track fue añadido exitosamente, false en caso contrario.</returns>
        public bool AñadirTrack(string correo)
        {
            try
            {
                using (var conexion = ConexionDB.ObtenerConexion())
                {
                    using (var comando = new NpgsqlCommand("INSERT INTO logintrack (correo,fecha) VALUES (@correo,@fecha)", conexion))
                    {
                        comando.Parameters.AddWithValue("@correo", correo);
                        comando.Parameters.AddWithValue("@fecha", DateTime.Now);
                        int filasAfectadas = comando.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al añadir track para el correo {correo}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina un registro de seguimiento de la tabla <c>logintrack</c> según su identificador único.
        /// </summary>
        /// <param name="id">Identificador del track a eliminar.</param>
        /// <returns><c>true</c> si el registro fue eliminado correctamente; en caso contrario, <c>false</c>.</returns>
        public bool EliminarTrack(int id)
        {
            using (var conexion = ConexionDB.ObtenerConexion())
            using (var cmd = new NpgsqlCommand("DELETE FROM logintrack WHERE id = @id", conexion))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Obtiene todos los registros de la tabla <c>logintrack</c> desde la base de datos.
        /// </summary>
        /// <returns>Lista de objetos <see cref="TrackDatos"/> que representan los registros almacenados.</returns>
        public List<TrackDatos> ObtenerTracks()
        {
            List<TrackDatos> registros = new List<TrackDatos>();

            using (var conexion = ConexionDB.ObtenerConexion())
            using (var cmd = new NpgsqlCommand("SELECT id, correo, fecha FROM logintrack", conexion))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    registros.Add(new TrackDatos
                    {
                        Id = reader.GetInt32(0),
                        Correo = reader.GetString(1),
                        Fecha = reader.GetDateTime(2)
                    });
                }
            }

            return registros;
        }
    }
}
