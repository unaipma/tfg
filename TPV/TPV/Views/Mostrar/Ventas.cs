using Negocio.Modelos;
using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TPV.Properties;
using TPV.Views.Landings;

namespace TPV.Views.Mostrar
{
    public partial class Ventas : Form
    {
        List<FacturaNegocio> facturas = new List<FacturaNegocio>();
        FacturaServicio fser = new FacturaServicio();
        int facturaIndex = 0;
        private string ubicacion;


        /// <summary>
        /// Constructor del formulario. Carga y muestra las facturas que todavía no han sido guardadas.
        /// </summary>
        public Ventas(List<FacturaNegocio> lista )
        {
            InitializeComponent();
           

           facturas= lista;

            lblHora.Text = DateTime.Now.ToString("HH:mm");
            MostrarFactura(facturaIndex);

        }

        /// <summary>
        /// Muestra en la interfaz la factura indicada por su índice.
        /// </summary>
        /// <param name="index">Índice de la factura a mostrar.</param>
        private void MostrarFactura(int index)
        {
            if (facturas.Count == 0)
            {
                MessageBox.Show("No hay facturas disponibles para hoy.");
                return;
            }

            if (index >= 0 && index < facturas.Count)
            {
                var factura = facturas[index];

                lblPrecio.Text = $"{factura.Total:C}";
                lblNombre.Text = factura.Vendedor.Nombre;
                lblFecha.Text = factura.FechaVenta.ToString("dd/MM/yyyy");
                lblHora.Text = factura.FechaVenta.ToString("HH:mm");
                if(factura.Vendedor.Foto != null)
                {
                    picUser.BackgroundImage = factura.Vendedor.Foto;
                }
                else
                {
                    picUser.BackgroundImage = Resources.usernophoto;
                }
                   
                lblTarjeta.Text = factura.tarjeta ? "Sí" : "No";

                // cargar productos
                pnlProductos.Controls.Clear();
                foreach (var producto in factura.ProductosVendidos)
                {
                    Panel panelItem = new Panel
                    {
                        Width = pnlProductos.Width - 30,
                        Height = 20,
                        Margin = new Padding(5),
                        BorderStyle = BorderStyle.Fixed3D,
                        BackColor = Color.Black
                    };

                    Label lblNombreProducto = new Label
                    {
                        Text = producto.Nombre,
                        Width = panelItem.Width / 2,
                        Height = 40,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Dock = DockStyle.Left,
                        ForeColor = Color.Red,
                        Font = new Font("Arial", 9, FontStyle.Bold),
                    };

                    Label lblPrecioProducto = new Label
                    {
                        Text = $"{producto.Precio:0.00}€",
                        Width = panelItem.Width / 3,
                        Height = 40,
                        TextAlign = ContentAlignment.MiddleRight,
                        Dock = DockStyle.Right,
                        ForeColor = Color.Red,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                    };

                    panelItem.Controls.Add(lblNombreProducto);
                    panelItem.Controls.Add(lblPrecioProducto);
                    pnlProductos.Controls.Add(panelItem);
                }
            }
        }

        /// <summary>
        /// Cierra el formulario actual.
        /// </summary>
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Navega a la siguiente factura (si existe).
        /// </summary>
        private void btnDerecha_Click(object sender, EventArgs e)
        {
            if (facturaIndex < facturas.Count - 1)
            {
                facturaIndex++;
                MostrarFactura(facturaIndex);
            }
            else
            {
                MessageBox.Show("Has llegado al final de las facturas.");
            }
        }

        /// <summary>
        /// Navega a la factura anterior (si existe).
        /// </summary>
        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            if (facturaIndex > 0)
            {
                facturaIndex--;
                MostrarFactura(facturaIndex);
            }
            else
            {
                MessageBox.Show("Estás en la primera factura.");
            }
        }

        /// <summary>
        /// Elimina la factura actualmente mostrada y actualiza la lista.
        /// </summary>
        private async void btnBorrarFactura_Click(object sender, EventArgs e)
        {
            var factura = facturas[facturaIndex];
            if (fser.EliminarFactura(factura.Id))
            {
                MessageBox.Show("Factura eliminada correctamente.");

                facturas.Remove(factura);

                if (facturas.Count == 0)
                {
                    this.Hide();
                }
                else
                {
                    facturaIndex = 0;
                    MostrarFactura(facturaIndex);
                }
            }
            else
            {
                MessageBox.Show("Error al eliminar la factura.");
            }
        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }
    }
}
