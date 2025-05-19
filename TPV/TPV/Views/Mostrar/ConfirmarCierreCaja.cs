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

namespace TPV.Views.Mostrar
{
    public partial class ConfirmarCierreCaja : Form
    {
        String ubicacion;
        /// <summary>
        /// Constructor del formulario ConfirmarCierreCaja.
        /// Inicializa el formulario y almacena la ubicación actual del terminal.
        /// </summary>
        /// <param name="ubi">Cadena con la ubicación.</param>
        public ConfirmarCierreCaja(string ubi)
        {
            InitializeComponent();
            ubicacion = ubi;
        }

        /// <summary>
        /// Servicio para gestionar las operaciones relacionadas con facturas.
        /// </summary>
        FacturaServicio facturaServicio = new FacturaServicio();

        /// <summary>
        /// Servicio para gestionar los registros de cierre de caja (facpos).
        /// </summary>
        FacPosServicio facPosServicio = new FacPosServicio();

        /// <summary>
        /// Evento ejecutado al hacer clic en el botón "Guardar".
        /// Obtiene todas las facturas no marcadas como guardadas, calcula el total de ingresos,
        /// crea un nuevo registro de cierre en la base de datos y actualiza el estado de las facturas.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            List<FacturaNegocio> listfacnegocio = await facturaServicio.CargarFacturas();
            List<FacturaNegocio> facturasNoGuardadas = listfacnegocio.Where(f => !f.Guardada).ToList();
         
            if (facturasNoGuardadas.Count == 0)
            {
                MessageBox.Show("No hay facturas no guardadas para procesar.");
                return;
            }
            decimal total = facturasNoGuardadas.Sum(f => f.Total);
            FacPosNegocio facPos = new FacPosNegocio
            {
                Ganancias = total,
                Fecha = DateTime.Now,
                Concepto = txbxConcepto.Text,
                Ubicacion = ubicacion
            };
            bool resultado = facPosServicio.AñadirRegistro(facPos);
            if (resultado)
            {
               
                foreach (var factura in facturasNoGuardadas)
                {
                    facturaServicio.MarcarFacturaComoGuardada(factura.Id);
                }

                MessageBox.Show("Cierre de caja guardado correctamente.");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error al guardar el cierre de caja. Estás en el modo Offline.");
            }
        }

        /// <summary>
        /// Evento ejecutado al hacer clic en el botón "Cancelar".
        /// Cierra el formulario sin realizar cambios ni guardar datos.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
