using Datos.Conexiones;
using Datos.Modelos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq.Expressions;
using System.Windows.Forms;


namespace Datos.AccesoDatos
{
    public class UsuarioMetodos
    {
        private Datos.Conexiones.Conexiones ConexionDB = new Datos.Conexiones.Conexiones();

        /// <summary>
        /// Obtiene el hash de contraseña almacenado de un usuario administrador por su correo.
        /// </summary>
        /// <param name="correo">Correo electrónico del usuario.</param>
        /// <returns>Hash de la contraseña si se encuentra, de lo contrario null.</returns>
        public string ObtenerHashUsuario(string correo)
        {
            try
            {
                string hashAlmacenado = null;

                using (var conexion = ConexionDB.ObtenerConexion())
                using (var cmd = new NpgsqlCommand("SELECT contrasena FROM users WHERE correo = @correo AND rol = 'admin'", conexion))
                {
                    cmd.Parameters.AddWithValue("@correo", correo);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        hashAlmacenado = result.ToString();
                }

                return hashAlmacenado;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene la lista de ubicaciones distintas registradas por los usuarios.
        /// </summary>
        /// <returns>Lista de cadenas con las ubicaciones únicas.</returns>
        public List<string> ObtenerUbicacionesDesdeUsuarios()
        {
            List<string> ubicaciones = new List<string>();

            try
            {
                // Postgre
                using (var conexion = ConexionDB.ObtenerConexion())
                   
                using (var cmd = new NpgsqlCommand("SELECT DISTINCT localizacion FROM users WHERE localizacion IS NOT NULL", conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ubicaciones.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception exPostgre)
            {
                try
                {
                    // Sqlite
                    using (var conexionSqlite = ConexionDB.ObtenerConexionSql())
                    using (var cmd = new SQLiteCommand("SELECT DISTINCT localizacion FROM users WHERE localizacion IS NOT NULL", conexionSqlite))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ubicaciones.Add(reader.GetString(0));
                        }
                    }
                }
                catch (Exception exSqlite)
                {
                    // Puedes mostrar o loguear el error si quieres
                    MessageBox.Show("Error al obtener ubicaciones desde ambas bases de datos.\nPostgreSQL: " + exPostgre.Message + "\nSQLite: " + exSqlite.Message);
                }
            }

            return ubicaciones;
        }


        /// <summary>
        /// Obtiene todos los usuarios desde la base de datos, intentando primero con PostgreSQL y luego con SQLite.
        /// </summary>
        /// <returns>Lista de objetos UsuarioDatos.</returns>
        public List<UsuarioDatos> ObtenerUsuarios()
        {
            List<UsuarioDatos> usuarios = new List<UsuarioDatos>();

            try
            {
                // Primer intento con PostgreSQL
                using (var conexion = ConexionDB.ObtenerConexion())
                using (var cmd = new NpgsqlCommand("SELECT id, nombre, rol, correo, localizacion, foto FROM users", conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UsuarioDatos usuario = new UsuarioDatos
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Rol = reader.GetString(2),
                            Correo = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            Localizacion = reader.IsDBNull(4) ? "Sin ubicación" : reader.GetString(4),
                            Foto = reader.IsDBNull(5) ? null : (byte[])reader[5]
                        };

                        usuarios.Add(usuario);
                    }
                }
            }
            catch (Exception exPostgre)
            {
                try
                {
                    // Si falla PostgreSQL, intenta con SQLite
                    using (var conexionSqlite = ConexionDB.ObtenerConexionSql())
                    using (var cmd = new SQLiteCommand("SELECT id, nombre, rol, correo, localizacion, foto FROM users", conexionSqlite))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UsuarioDatos usuario = new UsuarioDatos
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nombre = reader["nombre"].ToString(),
                                Rol = reader["rol"].ToString(),
                                Correo = reader["correo"] != DBNull.Value ? reader["correo"].ToString() : "",
                                Localizacion = reader["localizacion"] != DBNull.Value ? reader["localizacion"].ToString() : "Sin ubicación",
                                Foto = reader["foto"] != DBNull.Value ? (byte[])reader["foto"] : null
                            };

                            usuarios.Add(usuario);
                        }
                    }
                }
                catch (Exception exSqlite)
                {
                    MessageBox.Show("Error al obtener usuarios desde ambas bases de datos.\nPostgreSQL: " + exPostgre.Message + "\nSQLite: " + exSqlite.Message);
                }
            }

            return usuarios;
        }

        /// <summary>
        /// Registra un nuevo usuario en la base de datos PostgreSQL.
        /// </summary>
        /// <param name="usuario">Objeto UsuarioDatos con la información del usuario a registrar.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        public bool RegistrarUsuario(UsuarioDatos usuario)
        {
            using (var conexion = ConexionDB.ObtenerConexion())
            using (var cmd = new NpgsqlCommand("INSERT INTO users (nombre, correo, contrasena, rol, localizacion, foto) VALUES (@nombre, @correo, @contrasena, @rol, @localizacion, @foto)", conexion))
            {
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@contrasena", usuario.Contraseña ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@rol", usuario.Rol);
                cmd.Parameters.AddWithValue("@localizacion", usuario.Localizacion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@foto", usuario.Foto ?? (object)DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Obtiene un usuario específico por su ID, intentando con PostgreSQL y luego con SQLite.
        /// </summary>
        /// <param name="id">ID del usuario.</param>
        /// <returns>Objeto UsuarioDatos correspondiente al usuario encontrado, o null si no se encuentra.</returns>
        public UsuarioDatos ObtenerUsuarioporId(int id)
        {
            UsuarioDatos usuario = null;

            try
            {
                using (var conexion = ConexionDB.ObtenerConexion())
                using (var cmd = new NpgsqlCommand("SELECT id ,nombre, rol, correo, localizacion, foto FROM users WHERE id = @id", conexion))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new UsuarioDatos
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Rol = reader.GetString(2),
                                Correo = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Localizacion = reader.IsDBNull(4) ? "Sin ubicación" : reader.GetString(4),
                                Foto = reader.IsDBNull(5) ? null : (byte[])reader[5]
                            };
                        }
                    }
                }
            }
            catch (Exception exPg)
            {
               

                try
                {
                    using (var conexion = ConexionDB.ObtenerConexionSql())
                    using (var cmd = new SQLiteCommand("SELECT id ,nombre, rol, correo, localizacion, foto FROM users WHERE id = @id", conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuario = new UsuarioDatos
                                {
                                    Id = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    Rol = reader.GetString(2),
                                    Correo = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                    Localizacion = reader.IsDBNull(4) ? "Sin ubicación" : reader.GetString(4),
                                    Foto = reader.IsDBNull(5) ? null : (byte[])reader[5]
                                };
                            }
                        }
                    }
                }
                catch (Exception exSql)
                {
                    Console.WriteLine("❌ También falló SQLite: " + exSql.Message);
                }
            }

            return usuario;
        }


        /// <summary>
        /// Obtiene un usuario específico por su correo, intentando con PostgreSQL y luego con SQLite.
        /// </summary>
        /// <param name="correo">Correo electrónico del usuario.</param>
        /// <returns>Objeto UsuarioDatos correspondiente al usuario encontrado, o null si no se encuentra.</returns>
        public UsuarioDatos ObtenerUsuario(string correo)
        {
            UsuarioDatos usuario = null;

            try
            {
                using (var conexion = ConexionDB.ObtenerConexion())
                using (var cmd = new NpgsqlCommand("SELECT id ,nombre, rol, correo, localizacion, foto FROM users WHERE correo = @correo", conexion))
                {
                    cmd.Parameters.AddWithValue("@correo", correo);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new UsuarioDatos
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Rol = reader.GetString(2),
                                Correo = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Localizacion = reader.IsDBNull(4) ? "Sin ubicación" : reader.GetString(4),
                                Foto = reader.IsDBNull(5) ? null : (byte[])reader[5]
                            };
                        }
                    }
                }
            }
            catch (Exception exPg)
            {
               
                try
                {
                    using (var conexion = ConexionDB.ObtenerConexionSql())
                    using (var cmd = new SQLiteCommand("SELECT id ,nombre, rol, correo, localizacion, foto FROM users WHERE correo = @correo", conexion))
                    {
                        cmd.Parameters.AddWithValue("@correo", correo);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuario = new UsuarioDatos
                                {
                                    Id = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    Rol = reader.GetString(2),
                                    Correo = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                    Localizacion = reader.IsDBNull(4) ? "Sin ubicación" : reader.GetString(4),
                                    Foto = reader.IsDBNull(5) ? null : (byte[])reader[5]
                                };
                            }
                        }
                    }
                }
                catch (Exception exSql)
                {
                    Console.WriteLine("❌ También falló SQLite: " + exSql.Message);
                }
            }

            return usuario;
        }




        /// <summary>
        /// Actualiza los datos de un usuario existente en la base de datos PostgreSQL.
        /// </summary>
        /// <param name="usuario">Objeto UsuarioDatos con los nuevos datos del usuario.</param>
        /// <returns>True si la actualización fue exitosa, false en caso contrario.</returns>
        public bool ActualizarUsuario(UsuarioDatos usuario)
        {
            using (var conexion = ConexionDB.ObtenerConexion())
            {
                try
                {
                   
                    string query = "UPDATE users SET nombre = @nombre, correo = @correo, rol = @rol, localizacion = @localizacion , foto = @foto WHERE id = @id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conexion))
                    {
                        
                        cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                        cmd.Parameters.AddWithValue("@rol", usuario.Rol);
                        cmd.Parameters.AddWithValue("@localizacion", usuario.Localizacion ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@foto", usuario.Foto ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@id", usuario.Id);


                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar usuario: " + ex.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// Elimina un usuario de la base de datos PostgreSQL por su correo electrónico.
        /// </summary>
        /// <param name="correo">Correo del usuario a eliminar.</param>
        /// <returns>True si se eliminó correctamente, false en caso de error.</returns>
        public bool EliminarUsuario(string correo)
        {
            try
            {
                using (var conexion = ConexionDB.ObtenerConexion())
                {
                    using (var comando = new NpgsqlCommand("DELETE FROM users WHERE correo = @correo", conexion))
                    {
                        comando.Parameters.AddWithValue("@correo", correo);
                        int filasAfectadas = comando.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar usuario con correo {correo}: {ex.Message}");
                return false;
            }
        }

        










    }
}
    

