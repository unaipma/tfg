using Datos.Modelos;
using System;
using System.Data.SQLite;

namespace Datos.Servicios
{
    public class AjustesMetodos
    {
        private Datos.Conexiones.Conexiones ConexionDB = new Datos.Conexiones.Conexiones();

        /// <summary>
        /// Constructor de la clase. Crea la tabla 'Ajustes' si no existe
        /// y garantiza que haya una única fila con Id = 1 como configuración base.
        /// </summary>
        public AjustesMetodos()
        {
           
            try
            {
                using (var connection = ConexionDB.ObtenerConexionSql())
                {
                    string query = @"
                    CREATE TABLE IF NOT EXISTS Ajustes (
                        Id INTEGER PRIMARY KEY CHECK (Id = 1),
                        Ubicacion TEXT,
                        Ticket INTEGER
                    );
                    
                   
                    INSERT OR IGNORE INTO Ajustes (Id, Ubicacion, Ticket)
                    VALUES (1, '', 0);";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la tabla Ajustes: " + ex.Message);
            }
        }

        /// <summary>
        /// Carga los ajustes actuales desde la base de datos SQLite.
        /// </summary>
        /// <returns>Un objeto <see cref="AjustesDatos"/> con la configuración cargada o null si ocurre un error.</returns>
        public AjustesDatos CargarAjustes()
        {
            AjustesDatos ajustes = null;

            try
            {
                using (var connection = ConexionDB.ObtenerConexionSql())
                {
                    string query = "SELECT Ubicacion, Ticket FROM Ajustes WHERE Id = 1";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ajustes = new AjustesDatos
                            {
                                Ubicacion = reader.GetString(0),
                                Ticket = reader.GetInt32(1) == 1
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los ajustes: " + ex.Message);
            }

            return ajustes;
        }

        /// <summary>
        /// Guarda los ajustes proporcionados en la base de datos,
        /// actualizando la única fila existente.
        /// </summary>
        /// <param name="ajustesDatos">Objeto con los datos de configuración a guardar.</param>
        /// <returns><c>true</c> si la operación fue exitosa, <c>false</c> si falló.</returns>
        public bool GuardarAjustes(AjustesDatos ajustesDatos)
        {
            try
            {
                using (var connection = ConexionDB.ObtenerConexionSql())
                {
                    string query = @"
                    UPDATE Ajustes
                    SET Ubicacion = @Ubicacion, Ticket = @Ticket
                    WHERE Id = 1";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Ubicacion", ajustesDatos.Ubicacion);
                        command.Parameters.AddWithValue("@Ticket", ajustesDatos.Ticket ? 1 : 0);

                        int rows = command.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar los ajustes: " + ex.Message);
                return false;
            }
        }
    }
}
