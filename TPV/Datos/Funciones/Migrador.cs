using System;
using System.Data.SQLite;
using System.IO;
using Npgsql;


public class Migrador
{
    
    private Datos.Conexiones.Conexiones ConexionDB = new Datos.Conexiones.Conexiones();

    /// <summary>
    /// Migra productos desde PostgreSQL a SQLite, evitando duplicados basados en el ID.
    /// </summary>
    public void MigrarProductos()
    {
        try
        {
            using (var pgConn = ConexionDB.ObtenerConexion())
            using (var sqliteConn = ConexionDB.ObtenerConexionSql())
            {
                var selectQuery = "SELECT id, imagen, nombre, precio, categoria FROM productos";

                using (var pgCmd = new NpgsqlCommand(selectQuery, pgConn))
                using (var reader = pgCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);

                     
                        using (var checkCmd = new SQLiteCommand("SELECT COUNT(*) FROM productos WHERE id = @id", sqliteConn))
                        {
                            checkCmd.Parameters.AddWithValue("@id", id);
                            long count = (long)checkCmd.ExecuteScalar();
                            if (count > 0)
                                continue; 
                        }

                       
                        using (var insertCmd = new SQLiteCommand("INSERT INTO productos (id, imagen, nombre, precio, categoria) VALUES (@id, @imagen, @nombre, @precio, @categoria)", sqliteConn))
                        {
                            insertCmd.Parameters.AddWithValue("@id", id);
                            insertCmd.Parameters.AddWithValue("@imagen", reader["imagen"] == DBNull.Value ? null : (byte[])reader["imagen"]);
                            insertCmd.Parameters.AddWithValue("@nombre", reader.GetString(2));
                            insertCmd.Parameters.AddWithValue("@precio", reader.GetDouble(3));
                            insertCmd.Parameters.AddWithValue("@categoria", reader.GetString(4));
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }

                Console.WriteLine("Migración de productos completada sin duplicados.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error al conectar con PostgreSQL. No se realizó la migración de productos.");
            Console.WriteLine("Detalles: " + ex.Message);
        }
    }

    /// <summary>
    /// Migra usuarios desde PostgreSQL a SQLite, evitando duplicados basados en el ID.
    /// </summary>
    public void MigrarUsuarios()
    {
        try
        {
            using (var pgConn = ConexionDB.ObtenerConexion())
            using (var sqliteConn = ConexionDB.ObtenerConexionSql())
            {
                var selectQuery = "SELECT id, nombre, rol, correo, contrasena, localizacion, foto FROM users";

                using (var pgCmd = new NpgsqlCommand(selectQuery, pgConn))
                using (var reader = pgCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);

                       
                        using (var checkCmd = new SQLiteCommand("SELECT COUNT(*) FROM users WHERE id = @id", sqliteConn))
                        {
                            checkCmd.Parameters.AddWithValue("@id", id);
                            long count = (long)checkCmd.ExecuteScalar();
                            if (count > 0)
                                continue; 
                        }

                        using (var insertCmd = new SQLiteCommand("INSERT INTO users (id, nombre, rol, correo, contrasena, localizacion, foto) VALUES (@id, @nombre, @rol, @correo, @contrasena, @localizacion, @foto)", sqliteConn))
                        {
                            insertCmd.Parameters.AddWithValue("@id", id);
                            insertCmd.Parameters.AddWithValue("@nombre", reader.GetString(1));
                            insertCmd.Parameters.AddWithValue("@rol", reader.GetString(2));
                            insertCmd.Parameters.AddWithValue("@correo", reader.IsDBNull(3) ? null : reader.GetString(3));
                            insertCmd.Parameters.AddWithValue("@contrasena", reader.IsDBNull(4) ? null : reader.GetString(4));
                            insertCmd.Parameters.AddWithValue("@localizacion", reader.IsDBNull(5) ? null : reader.GetString(5));
                            insertCmd.Parameters.AddWithValue("@foto", reader.IsDBNull(6) ? null : (byte[])reader["foto"]);

                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }

                Console.WriteLine("Migración de usuarios completada sin duplicados.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error al conectar con PostgreSQL. No se realizó la migración.");
            Console.WriteLine("Detalles: " + ex.Message);
        }
    }
}
