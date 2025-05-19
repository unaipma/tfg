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
    public partial class RegistroProducto : Form
    {


        ProductoNegocio productoNegocio = new ProductoNegocio();
        ProductoServicio productoServicio = new ProductoServicio();
        /// <summary>
        /// Constructor del formulario. Inicializa los componentes de la interfaz.
        /// </summary>
        public RegistroProducto()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de registro.
        /// Valida los campos (nombre, precio, categoría) e inserta el producto en la base de datos si los datos son válidos.
        /// Limpia los campos del formulario y cierra la ventana tras registrar correctamente.
        /// </summary>
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            // nombr
            if (txbxNombre.Text.Length == 0)
            {
                lblError.Text = "El nombre no puede estar vacío";
                return;
            }
            // precio
            else if (numPrecio.Value < 0)
            {
                lblError.Text = "El precio no puede ser 0";
                return;
            }
            // categoria
            else if (txboxCategoria.Text.Length == 0)
            {
                lblError.Text = "La categoría no puede estar vacía";
            }
            else
            {

                productoNegocio.Nombre = txbxNombre.Text;
                productoNegocio.Precio = numPrecio.Value;
                productoNegocio.Categoria = txboxCategoria.Text;


                productoServicio.AñadirProducto(productoNegocio);


                txbxNombre.Text = "";
                numPrecio.Value = 0;
                txboxCategoria.Text = "";
                MessageBox.Show("Producto añadido correctamente");
                this.Close();
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de imagen.
        /// Abre un cuadro de diálogo para seleccionar una imagen del producto.
        /// Asigna la imagen seleccionada al modelo y la muestra en el botón.
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
                productoNegocio.Imagen = new Bitmap(openFileDialog.FileName);
                btnImage.BackgroundImage = productoNegocio.Imagen;
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
