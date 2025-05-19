using Negocio.Modelos;
using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPV.Views.Landings;

namespace TPV.Views.Mostrar
{
    public partial class Cobrar : Form
    {
        private List<ProductoNegocio> listaproductos;
        private UsuarioNegocio usuario;
        private decimal total;  
        private FacturaServicio fs = new FacturaServicio();
        private LandingUsuario landingUsuario;
        AjustesNegocio ajustes;
        AjustesServicio ajser = new AjustesServicio();


        /// <summary>
        /// Constructor del formulario de cobro. Inicializa los controles y datos del formulario con la información proporcionada.
        /// </summary>
        /// <param name="landingUsuario">Formulario principal de LandingUsuario.</param>
        /// <param name="total">Total de la factura.</param>
        /// <param name="listaproductos">Lista de productos que forman la factura.</param>
        /// <param name="usuario">Usuario que realiza el cobro.</param>
        public Cobrar(LandingUsuario landingUsuario, Decimal total, List<ProductoNegocio> listaproductos, UsuarioNegocio usuario)
        {
            this.landingUsuario = landingUsuario;
            InitializeComponent();
            if (usuario.Foto != null) { 
            picPerfil.BackgroundImage = usuario.Foto;
            }
            lblUsername.Text = usuario.Nombre;
            lblPrecio.Text = total.ToString("C2");
            this.listaproductos = listaproductos;
            this.usuario = usuario;
            this.total = total;
            this.ajustes = ajser.CargarAjustes();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de selección de tipo de pago (Efectivo/Tarjeta).
        /// Cambia el tipo de pago y el icono correspondiente.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btntarjetaefectivo_Click(object sender, EventArgs e)
        {
            if (lblefectivotarjeta.Text.Equals("Efectivo"))
            {
                lblefectivotarjeta.Text = "Tarjeta";
                btntarjetaefectivo.BackgroundImage = Properties.Resources.tarjeta;
            }
            else
            {
                lblefectivotarjeta.Text = "Efectivo";
                btntarjetaefectivo.BackgroundImage = Properties.Resources.efectivo;
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de cobrar.
        /// Guarda la factura y, si está configurado, imprime el ticket.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private async void btnCobrar_Click(object sender, EventArgs e)
        {
            bool resul;
            if (lblefectivotarjeta.Text == "Tarjeta")
            {
                resul = true;
            }
            else
            {
                resul = false;
            }

            FacturaNegocio factura = new FacturaNegocio(0, usuario, total, listaproductos, resul);

           
            if (fs.GuardarFactura(factura))
            {
                landingUsuario.AnularTodo();
                this.Hide();               
                if (ajustes.Ticket)
                {
                    await Task.Run(() => landingUsuario.imprimir());
                }
            }
            else
            {
                MessageBox.Show("Error al guardar la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           landingUsuario.SetCantidadSeleccionada(1);
            this.Close();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de volver.
        /// Cierra el formulario actual sin realizar ninguna acción.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btnAtrás_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}