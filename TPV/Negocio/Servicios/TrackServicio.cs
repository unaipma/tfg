using Datos.Modelos;
using Datos.Servicios;
using Negocio.Modelos;
using System.Collections.Generic;

namespace Negocio.Servicios
{
    public class TrackServicio
    {
        private readonly TrackingMetodos trackingMetodos;

        public TrackServicio()
        {
            trackingMetodos = new TrackingMetodos();
        }

        /// <summary>
        /// Agrega un nuevo registro de seguimiento en la base de datos con el correo especificado.
        /// </summary>
        /// <param name="correo">Correo electrónico del usuario a registrar.</param>
        /// <returns>Devuelve <c>true</c> si el registro fue añadido correctamente; en caso contrario, <c>false</c>.</returns>
        public bool AñadirTrack(string correo)
        {
            return trackingMetodos.AñadirTrack(correo);
        }

        /// <summary>
        /// Elimina un registro de seguimiento de la base de datos por su identificador.
        /// </summary>
        /// <param name="id">Identificador del registro a eliminar.</param>
        /// <returns>Devuelve <c>true</c> si el registro fue eliminado correctamente; en caso contrario, <c>false</c>.</returns>
        public bool EliminarTrack(int id)
        {
            return trackingMetodos.EliminarTrack(id);
        }

        /// <summary>
        /// Obtiene todos los registros de seguimiento disponibles desde la base de datos
        /// y los convierte en una lista de objetos de negocio.
        /// </summary>
        /// <returns>Lista de <see cref="TrackNegocio"/> con los datos cargados.</returns>
        public List<TrackNegocio> ObtenerTracks()
        {
            List<TrackNegocio> lista = new List<TrackNegocio>();
            List<TrackDatos> tracks = trackingMetodos.ObtenerTracks();
            foreach (var track in tracks)
            {
                lista.Add(new TrackNegocio
                {
                    Id = track.Id,
                    Correo = track.Correo,
                    Fecha = track.Fecha
                });
            }
            return lista;
        }
    }
}
