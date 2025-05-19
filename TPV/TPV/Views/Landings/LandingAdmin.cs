using Negocio.Modelos;
using System;
using System.Windows.Forms;
using TPV.Properties;

namespace TPV.Views.Landings
{
    /// <summary>
    /// Formulario de panel principal para administradores.
    /// Permite acceder a funciones como agregar usuarios, ver productos y gestionar facturas.
    /// </summary>
    public partial class LandingAdmin : Form
    {
        private UsuarioNegocio usuarioNegocio;

        /// <summary>
        /// Constructor que inicializa el panel de administrador con los datos del usuario logueado.
        /// </summary>
        /// <param name="usuario">Objeto UsuarioNegocio con la información del administrador.</param>
        public LandingAdmin(UsuarioNegocio usuario)
        {
            usuarioNegocio = usuario;
            InitializeComponent();

            pictureAdmin.SizeMode = PictureBoxSizeMode.Zoom;
            pictureAdmin.Image = Resources.usernophoto;
            lblBienvenido.Text = "Bienvenido " + usuarioNegocio.Nombre;

            if (usuario.Foto != null)
            {
                pictureAdmin.Image = usuario.Foto;
            }
        }

        /// <summary>
        /// Evento al cargar el formulario (sin lógica actualmente).
        /// </summary>
        private void LandingAdmin_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Cierra sesión del administrador y vuelve al formulario de inicio.
        /// </summary>
        private void btnCerrarSesión_Click(object sender, EventArgs e)
        {
            Inicio landingInicio = new Inicio();
            landingInicio.Show();
            this.Hide();
        }

        /// <summary>
        /// Abre el formulario para mostrar y gestionar los usuarios registrados.
        /// </summary>
        private void btnVerUsuarios_Click(object sender, EventArgs e)
        {
            Views.Usuarios.MostrarUsuarios mostrarUsuarios = new Views.Usuarios.MostrarUsuarios(usuarioNegocio);
            mostrarUsuarios.ShowDialog();
        }

        /// <summary>
        /// Abre el formulario para mostrar y editar los productos.
        /// </summary>
        private void btnEditarProductos_Click(object sender, EventArgs e)
        {
            Views.Productos.MostrarProductos mostrarProductos = new Views.Productos.MostrarProductos();
            mostrarProductos.ShowDialog();
        }

        /// <summary>
        /// Abre el formulario de ajustes del administrador actual.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Views.Registros.Ajustes ajustes = new Views.Registros.Ajustes(usuarioNegocio);
          
            ajustes.ShowDialog();
            this.Hide();

        }

        /// <summary>
        /// Abre el formulario para visualizar y gestionar facturas.
        /// </summary>
        private void btnFactura_Click(object sender, EventArgs e)
        {
            Views.Mostrar.MostrarFacturas mostrarFacturas = new Views.Mostrar.MostrarFacturas();
            mostrarFacturas.ShowDialog();
        }

        /// <summary>
        /// Abre el formulario correspondiente para agregar un nuevo usuario (admin o empleado).
        /// </summary>
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show($"¿El usuario que va a agregar es administrador?", "Confirmación",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (confirm == DialogResult.Yes)
            {
                Views.Registros.RegistroUsuario agregarUsuario = new Views.Registros.RegistroUsuario();
                agregarUsuario.ShowDialog();
            }
            else
            {
                Views.Registros.RegistroEmpleado agregarUsuario = new Views.Registros.RegistroEmpleado();
                agregarUsuario.ShowDialog();
            }
        }

        /// <summary>
        /// Cierra completamente la aplicación si el usuario cierra manualmente la ventana.
        /// </summary>
        private void LandingAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        
        private void btnTrack_Click(object sender, EventArgs e)
        {
            Views.Mostrar.Tracking mostrarTracks = new Views.Mostrar.Tracking();
            mostrarTracks.ShowDialog();
        }
    }
}
