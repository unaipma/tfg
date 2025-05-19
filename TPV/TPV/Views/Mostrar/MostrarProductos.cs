using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negocio.Modelos;
using Negocio.Servicios;

namespace TPV.Views.Productos
{
    public partial class MostrarProductos : Form
    {
        private ProductoServicio productoServicio;
        private List<ProductoNegocio> productosOriginales;

        /// <summary>
        /// Inicializa el formulario, configura eventos y carga los productos en el DataGridView.
        /// </summary>
        public MostrarProductos()
        {
            InitializeComponent();
            productoServicio = new ProductoServicio();
            dgProductos.AllowUserToAddRows = false;
            dgProductos.AllowUserToDeleteRows = false;
            dgProductos.CellValidating += dgProductos_CellValidating;
            CargarProductos();
        }

        /// <summary>
        /// Carga todos los productos desde la base de datos y los muestra en la tabla.
        /// </summary>
        private void CargarProductos()
        {
            productosOriginales = productoServicio.ObtenerProductos();
            dgProductos.DataSource = productosOriginales; 

            if (dgProductos.Columns["Id"] != null)
            {
                dgProductos.Columns["Id"].Visible = false; 
            }
            if (dgProductos.Columns["Imagen"] is DataGridViewImageColumn imgCol)
            {
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom; 
            }

            CargarCategorias();
        }




        /// <summary>
        /// Cierra el formulario actual.
        /// </summary>
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Abre el formulario de registro de productos y recarga los productos tras cerrarlo.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Views.Registros.RegistroProducto registroProducto = new Views.Registros.RegistroProducto();
            registroProducto.ShowDialog();
            CargarProductos();
        }

        /// <summary>
        /// Recarga la lista de productos desde la base de datos.
        /// </summary>
        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }


        /// <summary>
        /// Elimina el producto seleccionado después de confirmar con el usuario.
        /// </summary>
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dgProductos.SelectedRows[0];
            int id = Convert.ToInt32(fila.Cells["id"].Value);
            string nombre = fila.Cells["nombre"].Value.ToString();

            var confirm = MessageBox.Show($"¿Está seguro de eliminar el producto \"{nombre}\"?", "Confirmación",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool eliminado = productoServicio.EliminarProducto(id);
                if (eliminado)
                {
                    MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Guarda los cambios realizados en la tabla de productos.
        /// </summary>
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            guardar();
        }

        /// <summary>
        /// Permite seleccionar una nueva imagen al hacer clic en la celda de imagen.
        /// </summary>
        private void dgProductos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgProductos.Columns["imagen"].Index && e.RowIndex >= 0)
            {

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string filePath = openFileDialog.FileName;
                    Image newImage = Image.FromFile(filePath);

                    dgProductos.Rows[e.RowIndex].Cells["imagen"].Value = newImage;
                }
            }
        }


        /// <summary>
        /// Recorre cada fila del DataGridView y actualiza los productos en la base de datos.
        /// </summary>
        private void guardar()
        {
            foreach (var producto in productosOriginales)
            {
                bool actualizado = productoServicio.ActualizarProducto(producto);

                if (!actualizado)
                {
                    MessageBox.Show($"Error al guardar los cambios para el producto {producto.Nombre}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show("Cambios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarProductos();
        }


        /// <summary>
        /// Valida que el precio ingresado sea un número válido.
        /// </summary>
        private void dgProductos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgProductos.Columns[e.ColumnIndex].Name == "Precio")
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out _))
                {
                    MessageBox.Show("El precio debe ser un valor numérico.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }


        /// <summary>
        /// Filtra los productos por nombre conforme el usuario escribe en el cuadro de búsqueda.
        /// </summary>
        private void txbxProducto_TextChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
        }



        /// <summary>
        /// Filtra por nombre y categoria
        /// </summary>
        private void FiltrarProductos()
        {
            string textoBusqueda = txbxProducto.Text.Trim().ToLower();
            string categoriaSeleccionada = cmbcategoria.SelectedItem?.ToString();

            var productosFiltrados = productosOriginales
                .Where(p =>
                    p.Nombre.ToLower().Contains(textoBusqueda) &&
                    (categoriaSeleccionada == "Todas" || p.Categoria == categoriaSeleccionada)
                )
                .ToList();

            dgProductos.DataSource = productosFiltrados;

            if (dgProductos.Columns["Id"] != null)
            {
                dgProductos.Columns["Id"].Visible = false;
            }
            if (dgProductos.Columns["Imagen"] is DataGridViewImageColumn imgCol)
            {
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }
        }



        /// <summary>
        /// Carga las categorías únicas de los productos en el ComboBox de categoría.
        /// </summary>
        private void CargarCategorias()
        {
            var categorias = productosOriginales
                .Select(p => p.Categoria)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            categorias.Insert(0, "Todas");

            cmbcategoria.DataSource = categorias;
        }

        /// <summary>
        /// Filtra cuando cambia la categoría
        /// </summary>
        private void cmbcategoria_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            FiltrarProductos();
        }
    }
}