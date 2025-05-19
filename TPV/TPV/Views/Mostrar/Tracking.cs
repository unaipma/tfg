using Negocio.Modelos;
using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TPV.Views.Mostrar
{
    public partial class Tracking : Form
    {
        private List<TrackNegocio> lista = new List<TrackNegocio>();
        private TrackServicio trackser = new TrackServicio();

        public Tracking()
        {
            InitializeComponent();
            CargarDatos();
        }

        /// <summary>
        /// Carga todos los registros de seguimiento desde la base de datos
        /// y los muestra en el <see cref="DataGridView"/> principal.
        /// </summary>
        private void CargarDatos()
        {
            lista = trackser.ObtenerTracks();
            dgvTracking.DataSource = lista.Select(t => new
            {
                t.Id,
                t.Correo,
                Fecha = t.Fecha.ToString("g") // formato general corto
            }).ToList();

            dgvTracking.Columns["Id"].Visible = false;
        }

        /// <summary>
        /// Oculta el formulario actual y vuelve a la vista anterior.
        /// </summary>
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Filtra los registros por la fecha seleccionada en el control DatePicker
        /// y actualiza el <see cref="DataGridView"/> con los resultados.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = date.Value.Date;

            var filtrados = lista
                .Where(t => t.Fecha.Date == fechaSeleccionada)
                .Select(t => new
                {
                    t.Id,
                    t.Correo,
                    Fecha = t.Fecha.ToString("g")
                }).ToList();

            dgvTracking.DataSource = filtrados;
            dgvTracking.Columns["Id"].Visible = false;
        }

        /// <summary>
        /// Restaura el <see cref="DataGridView"/> con todos los registros sin filtros aplicados.
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvTracking.DataSource = lista;
            dgvTracking.Columns["Id"].Visible = false;
        }
    }
}
