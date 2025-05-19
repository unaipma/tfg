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
    public partial class RegistroUsuario : Form
    {

        UsuarioNegocio user = new UsuarioNegocio();
        /// <summary>
        /// Constructor del formulario. Inicializa los componentes de la interfaz.
        /// </summary>
        public RegistroUsuario()
        {
            InitializeComponent();
           
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón de registro.
        /// Realiza validaciones de los datos introducidos (correo, nombre, contraseña, localización),
        /// registra el usuario en la base de datos si todo es válido,
        /// y muestra mensajes de error o confirmación según corresponda.
        /// </summary>
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            UsuarioServicio us = new UsuarioServicio();

            // correo
            if (us.obtenerusuario(txboxCorreo.Text) == null)
            {
                // formato correo
                if (Regex.IsMatch(txboxCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    // nombre vacio
                    if (txbxNombre.Text.Length != 0)
                    {
                        // contraseña
                        if (Regex.IsMatch(txbxContraseña.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$"))
                        {
                            //localización
                            if (txbxLocalizacion.Text.Length != 0)
                            {
                              
                                user.Correo = txboxCorreo.Text;
                                user.Nombre = txbxNombre.Text;
                                user.Contraseña = txbxContraseña.Text;
                                user.Localizacion = txbxLocalizacion.Text;
                                user.Rol = "admin";

                                // registro
                                if (us.RegistrarUsuario(user))
                                {
                                    lblError.Text = "";
                                    txboxCorreo.Text = "";
                                    txbxNombre.Text = "";
                                    txbxContraseña.Text = "";
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
                            lblError.Text = "Contraseña inválida (mínimo 6 caracteres, mayúscula, minúscula y número)";
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
        /// Evento que se ejecuta al hacer clic en el botón de imagen.
        /// Permite al usuario seleccionar una imagen desde su sistema,
        /// y la asigna como foto de perfil del nuevo usuario.
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

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de imagen.
        /// Permite al usuario seleccionar volver hacia atras.
        /// </summary>
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
