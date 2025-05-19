using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPV.Views;

namespace TPV
{
    public partial class Inicio : Form
    {
        /// <summary>
        /// Constructor del formulario. Inicializa los componentes gráficos y ajusta el logotipo.
        /// </summary>
        public Inicio()
        {
            InitializeComponent();
            pictureLogo.SizeMode = PictureBoxSizeMode.Zoom; 
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón "Usuario".
        /// Abre el formulario de inicio de sesión para usuarios en modo diálogo.
        /// </summary>
        private void btnUsuario_Click(object sender, EventArgs e)
        {
            Views.InicioSesionUsuario inicioSesion = new Views.InicioSesionUsuario(this);
            inicioSesion.ShowDialog(); 
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón "Administrador".
        /// Abre el formulario de inicio de sesión para administradores.
        /// </summary>
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Views.InicioSesiónAdmin inicioSesion = new Views.InicioSesiónAdmin(this);
            inicioSesion.Show(); 
        }

        /// <summary>
        /// Evento que se ejecuta cuando el formulario está a punto de cerrarse.
        /// Se asegura de que se cierre toda la aplicación TPV al cerrar esta ventana.
        /// </summary>
        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}