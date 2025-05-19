using System;
using System.Windows.Forms;
using Negocio.Servicios;

namespace TPV.Views
{
    public partial class InicioSesiónAdmin : Form
    {
        private Form parent;
        private UsuarioServicio usuarioServicio = new UsuarioServicio();

        /// <summary>
        /// Inicializa el formulario y oculta el formulario padre.
        /// </summary>
        /// <param name="parent">Formulario principal desde donde se abre este.</param>
        public InicioSesiónAdmin(Form parent)
        {
            this.parent = parent;
            parent.Visible = false;
            InitializeComponent();
        }

        /// <summary>
        /// Limpia los campos de correo y contraseña.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txbxContraseña.Clear();
            txbxCorreo.Clear();
        }

        /// <summary>
        /// Maneja el evento de clic del botón de inicio de sesión.
        /// Verifica las credenciales y, si son válidas, abre el panel de administración.
        /// </summary>
        private void btnInicioSesion_Click(object sender, EventArgs e)
        {
            string usuario = txbxCorreo.Text;
            string contraseña = txbxContraseña.Text;

            if (usuarioServicio.IniciarSesion(usuario, contraseña))
            {
                try
                {
                    TrackServicio trackServicio = new TrackServicio();
                    trackServicio.AñadirTrack(usuario);

                    this.Hide();
                    Views.Landings.LandingAdmin landingAdmin = new Views.Landings.LandingAdmin(usuarioServicio.obtenerusuario(usuario));
                    landingAdmin.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al iniciar sesión");
                }
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas o no eres administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Regresa al formulario principal ocultando el formulario de inicio de sesión.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            parent.Show();
        }

        /// <summary>
        /// Cierra completamente la aplicación si el usuario intenta cerrar el formulario directamente.
        /// </summary>
        private void InicioSesiónAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}
