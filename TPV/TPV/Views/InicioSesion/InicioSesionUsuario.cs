using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TPV.Views
{
    
    public partial class InicioSesionUsuario : Form
    {
        private Form parent;

        /// <summary>
        /// Constructor que inicializa el formulario y oculta el formulario padre.
        /// </summary>
        /// <param name="parent">Formulario desde el cual se accede a este formulario.</param>
        public InicioSesionUsuario(Form parent)
        {
            this.parent = parent;
            parent.Visible = false;

            InitializeComponent();
            CargarUbicaciones();
        }

        /// <summary>
        /// Carga las ubicaciones disponibles desde la base de datos y las añade al combo box.
        /// </summary>
        private void CargarUbicaciones()
        {
            try
            {
                UsuarioServicio usuarioser = new UsuarioServicio();
                List<string> ubicaciones = usuarioser.ObtenerUbicaciones();

                cmboxubicaciones.Items.Clear();

                foreach (var ubicacion in ubicaciones)
                {
                    cmboxubicaciones.Items.Add(ubicacion);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ubicaciones: " + ex.Message);
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de login.
        /// Valida si se ha seleccionado una ubicación y abre el panel correspondiente.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string ubicacionSeleccionada = string.Empty;

            if (cmboxubicaciones.SelectedItem != null)
            {
                ubicacionSeleccionada = cmboxubicaciones.SelectedItem.ToString();

                this.Hide();
                Views.Landings.LandingUsuario landingUsuario = new Views.Landings.LandingUsuario(ubicacionSeleccionada);
                landingUsuario.Show();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una ubicación.");
            }
        }

        /// <summary>
        /// Cierra completamente la aplicación si el usuario cierra la ventana manualmente.
        /// </summary>
        private void InicioSesionUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Maneja el botón "Atrás", vuelve al formulario padre.
        /// </summary>
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            parent.Show();
        }
    }
}
