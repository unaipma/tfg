using Negocio.Modelos;
using Negocio.Servicios;
using System;
using System.Windows.Forms;
using TPV.Views.Landings;

namespace TPV.Views.Mostrar
{
    public partial class AjustesLandingUsuario : Form
    {
        AjustesServicio ajustesServicio = new AjustesServicio(); // Instancia del servicio de ajustes
        String ubicacion;
        LandingUsuario la;

        /// <summary>
        /// Constructor de la clase AjustesLandingUsuario.
        /// Inicializa el formulario con la ubicación y la referencia al formulario principal.
        /// </summary>
        /// <param name="ubi">Ubicación del usuario.</param>
        /// <param name="lan">Referencia al formulario principal (LandingUsuario).</param>
        public AjustesLandingUsuario(string ubi, LandingUsuario lan)
        {
            InitializeComponent();
            AjustesLandingUsuario_Load();
            ubicacion = ubi;
            la = lan;
        }

        /// <summary>
        /// Carga los ajustes guardados previamente en el sistema y los muestra en los controles del formulario.
        /// </summary>
        private void AjustesLandingUsuario_Load()
        {
            // Carga los ajustes desde el servicio
            AjustesNegocio ajustes = ajustesServicio.CargarAjustes();
            if (ajustes != null)
            {
                // Muestra la ubicación y la opción de ticket en los controles del formulario
                txbxUbicacion.Text = ajustes.Ubicacion.ToString();
                checkCopia.Checked = ajustes.Ticket;
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de guardar ajustes.
        /// Guarda los ajustes ingresados por el usuario.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            AjustesNegocio ajustes = new AjustesNegocio
            {
                // Asigna los valores de los controles a los atributos de los ajustes
                Ubicacion = txbxUbicacion.Text,
                Ticket = checkCopia.Checked
            };
            // Intenta guardar los ajustes
            bool resultado = ajustesServicio.GuardarAjustes(ajustes);
            if (resultado)
            {
                // Muestra un mensaje indicando que los ajustes fueron guardados correctamente
                MessageBox.Show("Ajustes guardados correctamente.");
            }
            else
            {
                // Muestra un mensaje de error si no se pudo guardar los ajustes
                MessageBox.Show("Error al guardar los ajustes.");
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de descartar cambios.
        /// Restaura los valores de los controles a los ajustes guardados previamente.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btnDescartar_Click(object sender, EventArgs e)
        {
            AjustesLandingUsuario_Load();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de volver.
        /// Cierra el formulario actual sin realizar cambios.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de cerrar caja.
        /// Abre el formulario de confirmación para cerrar la caja.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            Views.Mostrar.ConfirmarCierreCaja confirmarCierreCaja = new Views.Mostrar.ConfirmarCierreCaja(ubicacion);
            confirmarCierreCaja.ShowDialog();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de ir al inicio.
        /// Navega al formulario principal de inicio y oculta el formulario actual.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btnIrInicio_Click(object sender, EventArgs e)
        {
            Inicio ini = new Inicio();
            ini.Show();
            this.Hide();
            la.Hide();
        }
    }
}
