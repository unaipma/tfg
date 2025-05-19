using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SQLite;
using Datos.AccesoDatos;
using System.Threading.Tasks;
using System.Linq;

namespace Datos.Modelos
{
    
    public class FacturaMetodos
    {
        UsuarioMetodos usuarioMetodos = new UsuarioMetodos();
        private Datos.Conexiones.Conexiones ConexionDB = new Datos.Conexiones.Conexiones();

        /// <summary>
        /// Guarda una factura junto con sus productos asociados en la base de datos.
        /// </summary>
        /// <param name="factura">La factura que se desea guardar.</param>
        /// <returns><c>true</c> si la operación fue exitosa; de lo contrario, <c>false</c>.</returns>
        public bool GuardarFactura(FacturaDatos factura)
        {
            try
            {
                using (SQLiteConnection connection = ConexionDB.ObtenerConexionSql())
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "INSERT INTO Facturas (VendedorId, Total, FechaVenta, Tarjeta) VALUES (@VendedorId, @Total, @FechaVenta, @Tarjeta)";
                        using (SQLiteCommand command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@VendedorId", factura.Vendedor.Id);
                            command.Parameters.AddWithValue("@Total", factura.Total);
                            command.Parameters.AddWithValue("@FechaVenta", factura.FechaVenta);
                            command.Parameters.AddWithValue("@Tarjeta", factura.Tarjeta);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                long facturaId = connection.LastInsertRowId;

                                foreach (var producto in factura.ProductosVendidos)
                                {
                                    string productoQuery = "INSERT INTO FacturaProductos (FacturaID, ProductoId) VALUES (@FacturaID, @ProductoId)";
                                    using (SQLiteCommand productoCommand = new SQLiteCommand(productoQuery, connection))
                                    {
                                        productoCommand.Parameters.AddWithValue("@FacturaID", facturaId);
                                        productoCommand.Parameters.AddWithValue("@ProductoId", producto.Id);
                                        productoCommand.ExecuteNonQuery();
                                    }
                                }

                                transaction.Commit();
                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.WriteLine(e.Message);
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Carga todas las facturas desde la base de datos, incluyendo sus productos asociados.
        /// </summary>
        /// <returns>Lista de objetos <see cref="FacturaDatos"/>.</returns>
        public async Task<List<FacturaDatos>> CargarFacturas()
        {
            ProductoMétodos productoMetodos = new ProductoMétodos();
            List<FacturaDatos> facturas = new List<FacturaDatos>();

            try
            {
                using (SQLiteConnection connection = ConexionDB.ObtenerConexionSql())
                {
                    string query = "SELECT Id, VendedorId, Total, FechaVenta, Tarjeta, Guardada FROM Facturas";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        List<Task<FacturaDatos>> tareasFactura = new List<Task<FacturaDatos>>();

                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            int vendedorId = reader.GetInt32(1);
                            decimal total = reader.GetDecimal(2);
                            DateTime fechaVenta = reader.GetDateTime(3);
                            bool tarjeta = reader.GetInt32(4) == 1;
                            bool guardada = reader.GetInt32(5) == 1;

                            tareasFactura.Add(Task.Run(() =>
                            {
                                UsuarioDatos vendedor = usuarioMetodos.ObtenerUsuarioporId(vendedorId);

                                
                                List<ProductoDatos> productosVendidos = new List<ProductoDatos>();
                                decimal sumaProductos = 0;

                                using (SQLiteConnection connProd = ConexionDB.ObtenerConexionSql())
                                {
                                    string productoQuery = "SELECT ProductoId FROM FacturaProductos WHERE FacturaID = @FacturaID";
                                    using (SQLiteCommand cmdProd = new SQLiteCommand(productoQuery, connProd))
                                    {
                                        cmdProd.Parameters.AddWithValue("@FacturaID", id);
                                        using (SQLiteDataReader readerProd = cmdProd.ExecuteReader())
                                        {
                                            while (readerProd.Read())
                                            {
                                                int productoId = readerProd.GetInt32(0);
                                                ProductoDatos producto = productoMetodos.ObtenerProductoPorId(productoId);

                                                if (producto != null)
                                                {
                                                    productosVendidos.Add(producto);
                                                    sumaProductos += producto.Precio;
                                                }
                                            }
                                        }
                                    }
                                }

                                decimal diferencia = total - sumaProductos;
                                if (Math.Round(diferencia, 2) != 0)
                                {
                                    productosVendidos.Add(new ProductoDatos
                                    {
                                        Nombre = "Varios",
                                        Precio = Math.Round(diferencia, 2),
                                        Categoria = "Otro"
                                    });
                                }

                                return new FacturaDatos
                                {
                                    Id = id,
                                    Vendedor = vendedor,
                                    Total = total,
                                    FechaVenta = fechaVenta,
                                    Tarjeta = tarjeta,
                                    Guardada = guardada,
                                    ProductosVendidos = productosVendidos
                                };
                            }));
                        }

                        var resultados = await Task.WhenAll(tareasFactura);
                        facturas = resultados.ToList();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al cargar facturas: " + e.Message);
            }

            return facturas;
        }


        /// <summary>
        /// Elimina una factura y sus productos relacionados de la base de datos.
        /// </summary>
        /// <param name="facturaId">ID de la factura a eliminar.</param>
        /// <returns><c>true</c> si se eliminó correctamente; de lo contrario, <c>false</c>.</returns>
        public bool BorrarFacturaPorId(int facturaId)
        {
            try
            {
                using (SQLiteConnection connection = ConexionDB.ObtenerConexionSql())
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string deleteProductosQuery = "DELETE FROM FacturaProductos WHERE FacturaID = @FacturaID";
                        using (SQLiteCommand deleteProductosCommand = new SQLiteCommand(deleteProductosQuery, connection))
                        {
                            deleteProductosCommand.Parameters.AddWithValue("@FacturaID", facturaId);
                            deleteProductosCommand.ExecuteNonQuery();
                        }

                        string deleteFacturaQuery = "DELETE FROM Facturas WHERE Id = @FacturaID";
                        using (SQLiteCommand deleteFacturaCommand = new SQLiteCommand(deleteFacturaQuery, connection))
                        {
                            deleteFacturaCommand.Parameters.AddWithValue("@FacturaID", facturaId);
                            int rowsAffected = deleteFacturaCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                transaction.Commit();
                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error al eliminar la factura: " + ex.Message);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la conexión: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Marca una factura como guardada en la base de datos.
        /// </summary>
        /// <param name="idFactura">ID de la factura a actualizar.</param>
        /// <returns><c>true</c> si se actualizó correctamente; de lo contrario, <c>false</c>.</returns>
        public bool MarcarFacturaComoGuardada(int idFactura)
        {
            try
            {
                using (var conexion = ConexionDB.ObtenerConexionSql())
                {
                    string query = "UPDATE Facturas SET Guardada = 1 WHERE Id = @Id";
                    using (var comando = new SQLiteCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Id", idFactura);
                        return comando.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al marcar la factura como guardada: " + ex.Message);
                return false;
            }
        }

        
    }
}
