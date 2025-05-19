using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using Datos.Conexiones;
using System.Data.SQLite;

namespace Datos.Modelos
{
    public class ProductoMétodos
    {
        private Datos.Conexiones.Conexiones ConexionDB = new Datos.Conexiones.Conexiones();

        /// <summary>
        /// Añade un nuevo producto a la base de datos PostgreSQL.
        /// </summary>
        /// <param name="producto">El producto que se desea añadir.</param>
        /// <returns><c>true</c> si la inserción fue exitosa; de lo contrario, <c>false</c>.</returns>
        public bool AñadirProducto(ProductoDatos producto)
        {
            using (var conexion = ConexionDB.ObtenerConexion())
            using (var cmd = new NpgsqlCommand("INSERT INTO productos (imagen, nombre, precio, categoria) VALUES (@imagen, @nombre, @precio, @categoria)", conexion))
            {
                cmd.Parameters.AddWithValue("@imagen", producto.Imagen ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@categoria", producto.Categoria);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Actualiza los datos de un producto existente en la base de datos PostgreSQL.
        /// </summary>
        /// <param name="producto">El producto con los datos actualizados.</param>
        /// <returns><c>true</c> si la actualización fue exitosa; de lo contrario, <c>false</c>.</returns>
        public bool EditarProducto(ProductoDatos producto)
        {
            using (var conexion = ConexionDB.ObtenerConexion())
            using (var cmd = new NpgsqlCommand("UPDATE productos SET imagen = @imagen, nombre = @nombre, precio = @precio, categoria = @categoria WHERE id = @id", conexion))
            {
                cmd.Parameters.AddWithValue("@id", producto.Id);
                cmd.Parameters.AddWithValue("@imagen", producto.Imagen ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@categoria", producto.Categoria);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Elimina un producto de la base de datos PostgreSQL según su identificador.
        /// </summary>
        /// <param name="id">El identificador único del producto a eliminar.</param>
        /// <returns><c>true</c> si se eliminó correctamente; de lo contrario, <c>false</c>.</returns>
        public bool EliminarProducto(int id)
        {
            using (var conexion = ConexionDB.ObtenerConexion())
            using (var cmd = new NpgsqlCommand("DELETE FROM productos WHERE id = @id", conexion))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Obtiene una lista de todos los productos almacenados en la base de datos.
        /// Intenta primero desde PostgreSQL, y si falla, recurre a SQLite.
        /// </summary>
        /// <returns>Lista de objetos <see cref="ProductoDatos"/> con los datos obtenidos.</returns>
        public List<ProductoDatos> ObtenerProductos()
        {
            List<ProductoDatos> productos = new List<ProductoDatos>();

            try
            {
                // postgre
                using (var conexion = ConexionDB.ObtenerConexion())
                using (var cmd = new NpgsqlCommand("SELECT id, imagen, nombre, precio, categoria FROM productos", conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productos.Add(new ProductoDatos
                        {
                            Id = reader.GetInt32(0),
                            Imagen = reader.IsDBNull(1) ? null : (byte[])reader["imagen"],
                            Nombre = reader.GetString(2),
                            Precio = reader.GetDecimal(3),
                            Categoria = reader.GetString(4)
                        });
                    }

                    return productos;
                }
            }
            catch (Exception exPg)
            {
                try
                {
                    // sqlite
                    using (var conexion = ConexionDB.ObtenerConexionSql())
                    using (var cmd = new SQLiteCommand("SELECT id, imagen, nombre, precio, categoria FROM productos", conexion))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new ProductoDatos
                            {
                                Id = reader.GetInt32(0),
                                Imagen = reader.IsDBNull(1) ? null : (byte[])reader["imagen"],
                                Nombre = reader.GetString(2),
                                Precio = Convert.ToDecimal(reader.GetDouble(3)),
                                Categoria = reader.GetString(4)
                            });
                        }

                        return productos;
                    }
                }
                catch (Exception exSql)
                {
                    Console.WriteLine("❌ También falló SQLite: " + exSql.Message);
                    return new List<ProductoDatos>(); 
                }
            }
        }

        /// <summary>
        /// Obtiene un producto por su ID desde la base de datos SQLite.
        /// </summary>
        /// <param name="productoId">ID del producto a consultar.</param>
        /// <returns>Instancia de <see cref="ProductoDatos"/> o <c>null</c> si no se encuentra.</returns>
        public ProductoDatos ObtenerProductoPorId(int productoId)
        {
            ProductoDatos producto = null;

            try
            {
                using (SQLiteConnection connection = ConexionDB.ObtenerConexionSql())
                {
                    string query = "SELECT Id, Nombre, Precio, Categoria FROM Productos WHERE Id = @ProductoId";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductoId", productoId);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                producto = new ProductoDatos
                                {
                                    Id = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    Precio = reader.GetDecimal(2),
                                    Categoria = reader.GetString(3)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return producto;
        }


    }
}
