using Negocio.Modelos;
using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPV.Views.Mostrar;
using System.IO;

namespace TPV.Views.Landings
{
    public partial class LandingUsuario : Form
    {
        public string ubi;
        private readonly ProductoServicio prser = new ProductoServicio();
        private readonly List<ProductoNegocio> productos;
        private readonly List<UsuarioNegocio> usuarios;
        UsuarioServicio usuarioser = new UsuarioServicio();
        private int cantidadSeleccionada = 1;
        private Cantidad ventanaCantidad;
        private FacturaServicio facser= new FacturaServicio();
        AjustesServicio aj = new AjustesServicio();
       


        private List<ProductoNegocio> productosEnFactura = new List<ProductoNegocio>();


        /// <summary>
        /// Inicializa una nueva instancia del formulario LandingUsuario, cargando productos, empleados y configurando la interfaz de factura.
        /// </summary>
        /// <param name="ubicacion">Ubicación actual del usuario, utilizada para filtrar empleados visibles.</param>
        public LandingUsuario(string ubicacion)
        {
            InitializeComponent();
            ubi = ubicacion;
            productos = prser.ObtenerProductos();
            usuarios = usuarioser.ObtenerUsuarios()
                     .Where(u => u.Rol.Equals("empleado", StringComparison.OrdinalIgnoreCase))
                     .ToList();

            CargarUsuarios();
            CargarCategorias();
            InicializarFactura();
            PanelFactura.AutoScroll = true;
            PanelFactura.FlowDirection = FlowDirection.TopDown;
            PanelFactura.WrapContents = false;
            PanelFactura.HorizontalScroll.Maximum = 0; 
            PanelFactura.AutoScrollMinSize = new Size(0, 0);
            PanelFactura.HorizontalScroll.Visible = false;
           

            paneltotal.BorderStyle = BorderStyle.FixedSingle;

           


        }

        /// <summary>
        /// Carga en el combo box los nombres de los empleados disponibles en la ubicación actual.
        /// </summary>
        public void CargarUsuarios()
        {
            cmboxUsuarios.Items.Clear();
            foreach (var usuario in usuarios)
            {
                if (usuario.Rol == "empleado" && usuario.Localizacion == ubi)
                {
                    cmboxUsuarios.Items.Add(usuario); 
                }
            }
        }


        /// <summary>
        /// Carga las categorías únicas de productos como botones en el panel de categorías.
        /// </summary>
        public void CargarCategorias()
        {
            panelCategorias.Controls.Clear(); 

            HashSet<string> categoriasUnicas = new HashSet<string>();

            foreach (var producto in productos)
            {
                if (categoriasUnicas.Add(producto.Categoria)) 
                {
                    Button btnCategoria = new Button
                    {
                        Text = producto.Categoria,
                        Width = 120,
                        Height = 40,
                        Margin = new Padding(5),
                        BackColor = Color.LightGray
                    };



                    btnCategoria.Click += BtnCategoria_Click;
                    panelCategorias.Controls.Add(btnCategoria);
                }
            }
        }

        /// <summary>
        /// Muestra los productos que pertenecen a la categoría seleccionada.
        /// </summary>
        private void BtnCategoria_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            panelProductos.Controls.Clear();

            foreach (var producto in productos)
            {
                if (producto.Categoria == btn.Text)
                {
                    Panel panelProducto = new Panel
                    {
                        Width = 100,
                        Height = 130, 
                        Margin = new Padding(5)
                    };

                 
                    Button btnProducto = new Button
                    {
                        Width = 100,
                        Height = 100, 
                        BackColor = Color.LightGray,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag=producto.Nombre
                    };

                    if (producto.Imagen != null)
                    {
                        btnProducto.BackgroundImage = producto.Imagen ;
                    }
                    else
                    {
                        btnProducto.BackgroundImage = Properties.Resources.sinimagen;
                    }

                    btnProducto.Click += BtnProducto_Click;

                  
                    Label lblNombre = new Label
                    {
                        Text = producto.Nombre,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Bottom,
                        AutoSize = false,
                        Width = 120,
                        Height = 30 
                    };

                    
                    panelProducto.Controls.Add(btnProducto);
                    panelProducto.Controls.Add(lblNombre);

               
                    panelProductos.Controls.Add(panelProducto);
                }
            }
        }


        private decimal totalFactura = 0;

       
        private Label lblTotal;

        /// <summary>
        /// Inicializa el panel de factura agregando la etiqueta de total inicial.
        /// </summary>
        private void InicializarFactura()
        {
            lblTotal = new Label
            {
                Text = "Total: 0€",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 40,
                AutoSize = true
            };

            paneltotal.Controls.Add(lblTotal);
            paneltotal.Controls.SetChildIndex(lblTotal, 0); 
        }

        /// <summary>
        /// Añade un producto seleccionado a la factura actual y actualiza el total.
        /// </summary>
        private void BtnProducto_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string nombreProducto = btn.Tag as string;

            if (string.IsNullOrEmpty(nombreProducto))
            {
                MessageBox.Show("Error: No se pudo obtener el producto.");
                return;
            }

            ProductoNegocio productoSeleccionado = productos.FirstOrDefault(p => p.Nombre == nombreProducto);

            if (productoSeleccionado != null)
            {
                for (int i = 0; i < cantidadSeleccionada; i++)
                {
                    productosEnFactura.Add(productoSeleccionado);

                    totalFactura += productoSeleccionado.Precio;

                    Panel panelItem = new Panel
                    {
                        Width = PanelFactura.Width - 30,
                        Height = 20,
                        Margin = new Padding(5),
                        BorderStyle = BorderStyle.Fixed3D,
                        BackColor = Color.Black,
                        Tag = productoSeleccionado
                    };

                    Label lblNombre = new Label
                    {
                        Text = productoSeleccionado.Nombre,
                        Width = panelItem.Width / 3,
                        Height = 40,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Dock = DockStyle.Left,
                        ForeColor = Color.Red,
                        Font = new Font("Arial", 9, FontStyle.Bold),
                    };

                    Label lblPrecio = new Label
                    {
                        Text = $"{productoSeleccionado.Precio:0.00}€",
                        Width = panelItem.Width / 4,
                        Height = 40,
                        TextAlign = ContentAlignment.MiddleRight,
                        Dock = DockStyle.Right,
                        ForeColor = Color.Red,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                    };

                    panelItem.Controls.Add(lblNombre);
                    panelItem.Controls.Add(lblPrecio);
                    PanelFactura.Controls.Add(panelItem);
                }

                lblTotal.Text = $"Total: {totalFactura:0.00}€";
                lblTotal.Refresh();

                cantidadSeleccionada = 1;
            }
            else
            {
                MessageBox.Show("Producto no encontrado en la lista.");
            }
        }

        /// <summary>
        /// Confirma si se desea cerrar la aplicacion
        /// </summary>
        private void LandingUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// Abre la calculadora auxiliar en una nueva ventana.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            WindowsFormsAppCalculadora.Calculadora calculadora = new WindowsFormsAppCalculadora.Calculadora();
            calculadora.Show();
        }


        /// <summary>
        /// Muestra la imagen del usuario seleccionado en el ComboBox, si está disponible.
        /// </summary>
        private void cmboxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmboxUsuarios.SelectedIndex != -1)
            {
                var usuario = usuarios[cmboxUsuarios.SelectedIndex];

                if (usuario.Foto != null)
                {
                   
                        picPerfil.BackgroundImage = usuario.Foto;
                    
                }
                else
                {
                    picPerfil.BackgroundImage = Properties.Resources.usernophoto;
                }

                
            }
            else
            {
                picPerfil.BackgroundImage = Properties.Resources.usernophoto;
            }
        }



        /// <summary>
        /// Manejador del botón "Anular Todo". 
        /// Limpia todos los productos de la factura y reinicia el total.
        /// </summary>
        private void btnAnuarTodo_Click(object sender, EventArgs e)
        {
            AnularTodo();
            
        }

        /// <summary>
        /// Elimina todos los productos de la factura actual y reinicia su estado.
        /// </summary>
        public void AnularTodo()
        {
            productosEnFactura.Clear();

         
            totalFactura = 0;
            lblTotal.Text = "Total: 0.00€";

         
            PanelFactura.Controls.Clear();
            paneltotal.Controls.Clear();
            InicializarFactura();
        }

        /// <summary>
        /// Elimina el último producto añadido a la factura y actualiza el total.
        /// </summary>
        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {
            if (productosEnFactura.Count > 0)
            {
            
                ProductoNegocio productoEliminar = productosEnFactura.Last();

               
                totalFactura -= productoEliminar.Precio;
                lblTotal.Text = $"Total: {totalFactura:0.00}€";

           
                productosEnFactura.RemoveAt(productosEnFactura.Count - 1);

            
                if (PanelFactura.Controls.Count > 0)
                {
                    var ultimoPanel = PanelFactura.Controls[PanelFactura.Controls.Count - 1];
                    PanelFactura.Controls.Remove(ultimoPanel);
                    ultimoPanel.Dispose();
                }
            }
           
        }

        /// <summary>
        /// Abre el formulario de cobro si hay productos y un usuario seleccionado.
        /// </summary>
        private void BtnCobrar_Click(object sender, EventArgs e)
        {
            if (productosEnFactura.Count == 0)
            {
               
                return;
            }

           
            if (cmboxUsuarios.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona un usuario antes de cobrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuarioNegocio usuarioSeleccionado = (UsuarioNegocio)cmboxUsuarios.SelectedItem; 

            Views.Mostrar.Cobrar cobrar = new Views.Mostrar.Cobrar(this,totalFactura, productosEnFactura, usuarioSeleccionado);
            cobrar.Show();

            
        }

        /// <summary>
        /// Abre una ventana para seleccionar la cantidad de producto a añadir.
        /// </summary>
        private void btncantidad_Click(object sender, EventArgs e)
        {
                ventanaCantidad = new Cantidad(this);
                ventanaCantidad.Show();        
        }

        /// <summary>
        /// Establece la cantidad seleccionada para añadir a la factura.
        /// </summary>
        /// <param name="cantidad">Cantidad de productos seleccionada.</param>

        public void SetCantidadSeleccionada(int cantidad)
        {
            cantidadSeleccionada = cantidad;
        }

        /// <summary>
        /// Elimina la referencia de la ventana de cantidad para permitir su recreación.
        /// </summary>
        public void LimpiarReferenciaCantidad()
        {
            ventanaCantidad = null;
        }

        /// <summary>
        /// Muestra las ventas del día actual que no han sido guardadas y pertenecen a la ubicación actual.
        /// </summary>
        private async void btnCadenaVentas_Click(object sender, EventArgs e)
        {
            List<FacturaNegocio> facturas = new List<FacturaNegocio>();

             facturas = (await facser.CargarFacturas())
                .Where(f => !f.Guardada && f.Vendedor.Localizacion == ubi)
                .OrderByDescending(f => f.FechaVenta)
                .ToList();

            if (facturas.Count != 0)
            {
                Views.Mostrar.Ventas ventas = new Views.Mostrar.Ventas(facturas);
                ventas.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se han realizado ventas en el día de hoy", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        /// <summary>
        /// Abre el formulario de ajustes personalizados del usuario.
        /// </summary>
        private void btnajustes_Click(object sender, EventArgs e)
        {
            Views.Mostrar.AjustesLandingUsuario ajustes = new Views.Mostrar.AjustesLandingUsuario(ubi,this);
            ajustes.ShowDialog();
        }

        /// <summary>
        /// Abre el formulario para ingresar cantidades con decimales personalizados.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            Views.Mostrar.cantidaddecimales decimales = new Views.Mostrar.cantidaddecimales(this);
            decimales.ShowDialog();
        }

        /// <summary>
        /// Añade un producto genérico con un precio específico como "Varios" a la factura actual.
        /// </summary>
        /// <param name="numero">Importe a añadir como línea genérica en la factura.</param>

        public void AñadirVarios(decimal numero)
        {
            ProductoNegocio producto = new ProductoNegocio();
            producto.Precio = numero;
            productosEnFactura.Add(producto);
            totalFactura += numero;
            lblTotal.Text = $"Total: {totalFactura:0.00}€";
            lblTotal.Refresh();
            Panel panelItem = new Panel
            {
                Width = PanelFactura.Width - 30,
                Height = 20,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.Fixed3D,
                BackColor = Color.Black,
                Tag = producto
            };
            Label lblNombre = new Label
            {
                Text = "Varios",
                Width = panelItem.Width / 3,
                Height = 40,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Left,
                ForeColor = Color.Red,
                Font = new Font("Arial", 9, FontStyle.Bold),
            };
            Label lblPrecio = new Label
            {
                Text = $"{numero:0.00}€",
                Width = panelItem.Width / 3,
                Height = 40,
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Right,
                ForeColor = Color.Red,
                Font = new Font("Arial", 10, FontStyle.Bold),
            };
            panelItem.Controls.Add(lblNombre);
            panelItem.Controls.Add(lblPrecio);
            PanelFactura.Controls.Add(panelItem);
        }

        /// <summary>
        /// Inicia la impresión de una copia de la última factura registrada.
        /// </summary>
        private async void btnImprimirCopia_Click(object sender, EventArgs e)
        {
            await Task.Run(() => imprimir());
        }

        /// <summary>
        /// Busca la última factura disponible y la envía a imprimir.
        /// </summary>
        public async void imprimir()
        {
            FacturaNegocio ultimaFactura = (await facser.CargarFacturas())
    .OrderByDescending(f => f.FechaVenta)
    .FirstOrDefault();

            if (ultimaFactura != null)
            {
                ImprimirFactura(ultimaFactura);
            }
            else
            {
                MessageBox.Show("No se encontró ninguna factura para imprimir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Construye el contenido en texto plano de una factura para su impresión.
        /// </summary>
        /// <param name="factura">Factura a imprimir.</param>
        /// <returns>Cadena con el contenido de la factura formateada.</returns>

        private string CrearFacturaParaImprimir(FacturaNegocio factura)
        {
            AjustesNegocio ajustes = aj.CargarAjustes();

            var sb = new StringBuilder();

            sb.AppendLine("==============================================");
            sb.AppendLine("                     FACTURA");
            sb.AppendLine("==============================================");
            sb.AppendLine($"Fecha: {factura.FechaVenta.ToString("dd/MM/yyyy HH:mm")}");
            sb.AppendLine($"Atendido por: {factura.Vendedor.Nombre}");
            sb.AppendLine($"Ubicación: {ubi}");
            sb.AppendLine($"Forma de pago: {(factura.tarjeta ? "Tarjeta" : "Efectivo")}");
            sb.AppendLine($"Información adicional: {ajustes.Ubicacion}");
            sb.AppendLine("==============================================");
            sb.AppendLine("Productos:");

      
            foreach (var producto in factura.ProductosVendidos)
            {
                sb.AppendLine($"{producto.Nombre} - {producto.Precio:0.00}€");
            }

         
            sb.AppendLine("----------------------------------------------");
            sb.AppendLine($"Total: {factura.Total:0.00}€");
            sb.AppendLine("==============================================");

            return sb.ToString();
        }

        /// <summary>
        /// Imprime el contenido textual de una factura en la impresora predeterminada.
        /// </summary>
        /// <param name="factura">Factura a imprimir.</param>

        private void ImprimirFactura(FacturaNegocio factura)
        {
            string facturaTexto = CrearFacturaParaImprimir(factura);

          
            PrintDocument printDoc = new PrintDocument();

         
            printDoc.PrintPage += (sender, e) =>
            {
              
                Font font = new Font("Arial", 10);
                e.Graphics.DrawString(facturaTexto, font, Brushes.Black, 10, 10);
            };

          
            PrinterSettings settings = new PrinterSettings();
            printDoc.PrinterSettings = settings;

          
            printDoc.Print();
        }

        private void lblCalculadora_Click(object sender, EventArgs e)
        {

        }
    }
}
