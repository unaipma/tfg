using Datos.Modelos;
using Datos.Servicios;
using Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicios
{
    public class FacPosServicio
    {
        private readonly FacPosMetodos datos = new FacPosMetodos();

        /// <summary>
        /// Añade un nuevo registro de facturación al sistema.
        /// </summary>
        /// <param name="registro">Instancia de <see cref="FacPosNegocio"/> con los datos del registro.</param>
        /// <returns>True si se añadió correctamente; false en caso contrario.</returns>
        public bool AñadirRegistro(FacPosNegocio registro)
        {
            var datosRegistro = ConvertirADatos(registro);
            return datos.AñadirRegistro(datosRegistro);
        }

        /// <summary>
        /// Edita un registro de facturación existente.
        /// </summary>
        /// <param name="registro">Instancia actualizada de <see cref="FacPosNegocio"/>.</param>
        /// <returns>True si se editó correctamente; false en caso contrario.</returns>
        public bool EditarRegistro(FacPosNegocio registro)
        {
            var datosRegistro = ConvertirADatos(registro);
            return datos.EditarRegistro(datosRegistro);
        }

        /// <summary>
        /// Elimina un registro de facturación por su identificador.
        /// </summary>
        /// <param name="id">Identificador del registro a eliminar.</param>
        /// <returns>True si se eliminó correctamente; false en caso contrario.</returns>
        public bool EliminarRegistro(int id)
        {
            return datos.EliminarRegistro(id);
        }

        /// <summary>
        /// Obtiene todos los registros de facturación.
        /// </summary>
        /// <returns>Lista de registros en formato <see cref="FacPosNegocio"/>.</returns>
        public List<FacPosNegocio> ObtenerRegistros()
        {
            var datosRegistros = datos.ObtenerRegistros();
            List<FacPosNegocio> listaNegocio = new List<FacPosNegocio>();

            foreach (var registro in datosRegistros)
            {
                listaNegocio.Add(ConvertirANegocio(registro));
            }

            return listaNegocio;
        }

        /// <summary>
        /// Convierte una instancia de <see cref="FacPosDatos"/> a <see cref="FacPosNegocio"/>.
        /// </summary>
        /// <param name="datos">Instancia del modelo de datos.</param>
        /// <returns>Instancia del modelo de negocio.</returns>
        private FacPosNegocio ConvertirANegocio(FacPosDatos datos)
        {
            return new FacPosNegocio
            {
                Id = datos.Id,
                Ganancias = datos.Ganancias,
                Fecha = datos.Fecha,
                Concepto = datos.Concepto,
                Ubicacion = datos.Ubicacion
            };
        }

        /// <summary>
        /// Convierte una instancia de <see cref="FacPosNegocio"/> a <see cref="FacPosDatos"/>.
        /// </summary>
        /// <param name="negocio">Instancia del modelo de negocio.</param>
        /// <returns>Instancia del modelo de datos.</returns>
        private FacPosDatos ConvertirADatos(FacPosNegocio negocio)
        {
            return new FacPosDatos
            {
                Id = negocio.Id,
                Ganancias = negocio.Ganancias,
                Fecha = negocio.Fecha,
                Concepto = negocio.Concepto,
                Ubicacion = negocio.Ubicacion
            };
        }
    }
}
