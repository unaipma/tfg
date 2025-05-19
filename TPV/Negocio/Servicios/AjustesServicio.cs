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
    public class AjustesServicio
    {
        AjustesMetodos ajustesMetodos = new AjustesMetodos();

        /// <summary>
        /// Constructor de la clase <see cref="AjustesServicio"/>.
        /// </summary>
        public AjustesServicio()
        { }

        /// <summary>
        /// Guarda los ajustes proporcionados en la base de datos.
        /// </summary>
        /// <param name="ajuneg">Instancia de <see cref="AjustesNegocio"/> con los ajustes a guardar.</param>
        /// <returns>True si se guardaron correctamente; de lo contrario, false.</returns>
        public bool GuardarAjustes(AjustesNegocio ajuneg)
        {
            AjustesDatos ajustesDatos = parsetoDatos(ajuneg);
            bool resultado = ajustesMetodos.GuardarAjustes(ajustesDatos);
            return resultado;
        }

        /// <summary>
        /// Carga los ajustes desde la base de datos y los convierte al modelo de negocio.
        /// </summary>
        /// <returns>Instancia de <see cref="AjustesNegocio"/> con los ajustes cargados.</returns>
        public AjustesNegocio CargarAjustes()
        {
            AjustesMetodos ajustesMetodos = new AjustesMetodos();
            AjustesDatos ajustesDatos = ajustesMetodos.CargarAjustes();
            AjustesNegocio ajustesNegocio = parsetonegocio(ajustesDatos);
            return ajustesNegocio;
        }

        /// <summary>
        /// Convierte una instancia del modelo de datos <see cref="AjustesDatos"/> al modelo de negocio <see cref="AjustesNegocio"/>.
        /// </summary>
        /// <param name="ajdatos">Instancia de <see cref="AjustesDatos"/>.</param>
        /// <returns>Instancia de <see cref="AjustesNegocio"/> correspondiente.</returns>
        public AjustesNegocio parsetonegocio(AjustesDatos ajdatos)
        {
            AjustesNegocio ajustesNegocio = new AjustesNegocio();
            ajustesNegocio.Ubicacion = ajdatos.Ubicacion;
            ajustesNegocio.Ticket = ajdatos.Ticket;
            return ajustesNegocio;
        }

        /// <summary>
        /// Convierte una instancia del modelo de negocio <see cref="AjustesNegocio"/> al modelo de datos <see cref="AjustesDatos"/>.
        /// </summary>
        /// <param name="ajNegocio">Instancia de <see cref="AjustesNegocio"/>.</param>
        /// <returns>Instancia de <see cref="AjustesDatos"/> correspondiente.</returns>
        public AjustesDatos parsetoDatos(AjustesNegocio ajNegocio)
        {
            AjustesDatos ajustesDatos = new AjustesDatos();
            ajustesDatos.Ubicacion = ajNegocio.Ubicacion;
            ajustesDatos.Ticket = ajNegocio.Ticket;
            return ajustesDatos;
        }
    }
}
