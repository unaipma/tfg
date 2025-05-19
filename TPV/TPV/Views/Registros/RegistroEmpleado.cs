using Negocio.Modelos;
using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPV.Properties;

namespace TPV.Views.Registros
{
    public partial class RegistroEmpleado : Form
    {
        UsuarioNegocio user = new UsuarioNegocio();
        /// <summary>
        /// Constructor del formulario. Inicializa los componentes gráficos.
        /// </summary>
        public RegistroEmpleado()
        {

            InitializeComponent();
           
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de registro.
        /// Valida que el correo, nombre y localización no estén vacíos y que el correo tenga un formato válido.
        /// Si los datos son correctos y el correo no está registrado, guarda al nuevo usuario con rol "empleado".
        /// </summary>
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            UsuarioServicio us = new UsuarioServicio();

            // Verifica que el correo no esté ya registrado
            if (us.obtenerusuario(txboxCorreo.Text) == null)
            {
                // Validación del formato del correo
                if (Regex.IsMatch(txboxCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    // Validación del nombre
                    if (txbxNombre.Text.Length != 0)
                    {
                        // Validación de la localización
                        if (txbxLocalizacion.Text.Length != 0)
                        {
                            user.Correo = txboxCorreo.Text;
                            user.Nombre = txbxNombre.Text;
                            user.Localizacion = txbxLocalizacion.Text;
                            user.Rol = "empleado";

                            // Intenta registrar el usuario
                            if (us.RegistrarUsuario(user))
                            {
                                lblError.Text = "";
                                txboxCorreo.Text = "";
                                txbxNombre.Text = "";
                                txbxLocalizacion.Text = "";

                                MessageBox.Show("Registro exitoso");
                            }
                        }
                        else
                        {
                            lblError.Text = "Localización inválida";
                        }
                    }
                    else
                    {
                        lblError.Text = "Nombre inválido";
                    }
                }
                else
                {
                    lblError.Text = "Correo inválido";
                }
            }
            else
            {
                lblError.Text = "Correo ya registrado";
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de selección de imagen.
        /// Permite al usuario seleccionar una imagen desde el sistema de archivos y la asigna al nuevo empleado.
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
                user.Foto = new Bitmap(openFileDialog.FileName);
                btnImage.BackgroundImage = user.Foto;
                btnImage.BackgroundImageLayout = ImageLayout.Zoom;
                lblImage.Text = openFileDialog.FileName;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
