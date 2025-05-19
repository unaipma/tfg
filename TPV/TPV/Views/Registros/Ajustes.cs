using Negocio.Modelos;
using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPV.Views.Registros
{
    public partial class Ajustes : Form
    {
        private UsuarioNegocio usu;
        UsuarioServicio us = new UsuarioServicio();

        /// <summary>
        /// Constructor del formulario de ajustes. Inicializa el formulario con los datos del usuario recibido.
        /// </summary>
        /// <param name="user">Instancia del usuario logueado cuyos datos se van a modificar.</param>
        public Ajustes(UsuarioNegocio user)
        {
            InitializeComponent();
            usu = user;

            txboxCorreo.Text = usu.Correo;
            txbxNombre.Text = usu.Nombre;
            txbxLocalizacion.Text = usu.Localizacion;
            btnImage.BackgroundImage = usu.Foto;
        }



        /// <summary>
        /// Evento ejecutado al hacer clic en el botón "Actualizar".
        /// Actualiza los datos del usuario en el sistema con los valores actuales del formulario.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {

            usu.Correo = txboxCorreo.Text;
            usu.Nombre = txbxNombre.Text;
            usu.Localizacion = txbxLocalizacion.Text;
            usu.Foto = btnImage.BackgroundImage;


            if (us.ActualizarUsuario(usu))
            {
                MessageBox.Show("Usuario actualizado correctamente");
            }
        }

        /// <summary>
        /// Evento ejecutado al hacer clic en el botón de imagen.
        /// Permite al usuario seleccionar una nueva imagen desde su sistema de archivos.
        /// </summary>
        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Seleccionar imagen",
                Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                btnImage.BackgroundImage = new Bitmap(openFileDialog.FileName);
                btnImage.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        /// <summary>
        /// Evento ejecutado al hacer clic en el botón "Atrás".
        /// Cierra el formulario actual y abre la vista Landing del administrador.
        /// </summary>
        private void btnAtras_Click(object sender, EventArgs e)
        {
            Views.Landings.LandingAdmin landing = new Views.Landings.LandingAdmin(usu);
            landing.Show();
            this.Hide();
            
           
        }
    }
}
