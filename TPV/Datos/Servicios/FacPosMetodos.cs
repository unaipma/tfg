using Datos.Modelos;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Datos.Servicios
{
    public class FacPosMetodos
    {
        private Conexiones.Conexiones ConexionDB = new Conexiones.Conexiones();

        /// <summary>
        /// Añade una factura a la tabla 'facturacion' de PostgreSQL.
        /// </summary>
        /// <param name="registro">El objeto <see cref="FacPosDatos"/> que contiene los datos a insertar.</param>
        /// <returns><c>true</c> si la inserción fue exitosa; de lo contrario, <c>false</c>.</returns>
        public bool AñadirRegistro(FacPosDatos registro)
        {
            try
            {
                using (var conexion = ConexionDB.ObtenerConexion())
                using (var cmd = new NpgsqlCommand("INSERT INTO facturacion (ganancias, fecha, concepto, ubicacion) VALUES (@ganancias, @fecha, @concepto, @ubicacion)", conexion))
                {
                    cmd.Parameters.AddWithValue("@ganancias", registro.Ganancias);
                    cmd.Parameters.AddWithValue("@fecha", registro.Fecha);
                    cmd.Parameters.AddWithValue("@concepto", registro.Concepto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ubicacion", registro.Ubicacion ?? (object)DBNull.Value);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Edita una factura existente en la tabla 'facturacion' de postgre usando su ID.
        /// </summary>
        /// <param name="registro">El objeto <see cref="FacPosDatos"/> con los datos actualizados.</param>
        /// <returns><c>true</c> si la actualización fue exitosa; de lo contrario, <c>false</c>.</returns>
        public bool EditarRegistro(FacPosDatos registro)
        {
            using (var conexion = ConexionDB.ObtenerConexion())
            using (var cmd = new NpgsqlCommand("UPDATE facturacion SET ganancias = @ganancias, fecha = @fecha, concepto = @concepto, ubicacion = @ubicacion WHERE id = @id", conexion))
            {
                cmd.Parameters.AddWithValue("@id", registro.Id);
                cmd.Parameters.AddWithValue("@ganancias", registro.Ganancias);
                cmd.Parameters.AddWithValue("@fecha", registro.Fecha);
                cmd.Parameters.AddWithValue("@concepto", registro.Concepto ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ubicacion", registro.Ubicacion ?? (object)DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Elimina una factura de la tabla 'facturacion' de PostgreSQL por su ID.
        /// </summary>
        /// <param name="id">El ID del registro a eliminar.</param>
        /// <returns><c>true</c> si la eliminación fue exitosa; de lo contrario, <c>false</c>.</returns>
        public bool EliminarRegistro(int id)
        {
            using (var conexion = ConexionDB.ObtenerConexion())
            using (var cmd = new NpgsqlCommand("DELETE FROM facturacion WHERE id = @id", conexion))
            {
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Obtiene todas las facturas almacenadas en la tabla 'facturacion' de PostgreSQL.
        /// </summary>
        /// <returns>Lista de objetos <see cref="FacPosDatos"/> que representan los registros encontrados.</returns>
        public List<FacPosDatos> ObtenerRegistros()
        {
            List<FacPosDatos> registros = new List<FacPosDatos>();

            using (var conexion = ConexionDB.ObtenerConexion())
            using (var cmd = new NpgsqlCommand("SELECT id, ganancias, fecha, concepto, ubicacion FROM facturacion", conexion))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    registros.Add(new FacPosDatos
                    {
                        Id = reader.GetInt32(0),
                        Ganancias = reader.GetDecimal(1),
                        Fecha = reader.GetDateTime(2),
                        Concepto = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Ubicacion = reader.IsDBNull(4) ? null : reader.GetString(4)
                    });
                }
            }

            return registros;
        }
    }
}
