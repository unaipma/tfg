using Negocio.Modelos;
using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Colors;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Image;
using TPV.Properties;
using System.Drawing;
using System.Drawing.Imaging;


namespace TPV.Views.Mostrar
{
    public partial class MostrarFacturas : Form
    {
        private List<FacPosNegocio> listaFacturas;
        private FacPosServicio facPosServicio = new FacPosServicio();
        public MostrarFacturas()
        {
            InitializeComponent();
            Cargar();
        }

        /// <summary>
        /// Carga todas las facturas POS en el DataGridView.
        /// </summary>
        private void Cargar()
        {
            listaFacturas = facPosServicio.ObtenerRegistros();
            dgvFacturas.DataSource = listaFacturas.Select(f => new
            {
                f.Id,
                f.Ganancias,
                f.Fecha,
                f.Concepto,
                f.Ubicacion
            }).ToList();

            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturas.MultiSelect = false;
        }

        /// <summary>
        /// Cierra el formulario actual.
        /// </summary>
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Genera un PDF individual para la factura seleccionada en el DataGridView.
        /// </summary>
        private void btnVerfactura_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count > 0)
            {
                int idSeleccionado = (int)dgvFacturas.SelectedRows[0].Cells["Id"].Value;
                FacPosNegocio registroSeleccionado = listaFacturas.FirstOrDefault(f => f.Id == idSeleccionado);

                if (registroSeleccionado != null)
                {

                    GenerarFacturaPosIndividual(registroSeleccionado);

                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona un registro primero.");
            }
        }

        /// <summary>
        /// Filtra las facturas según la fecha seleccionada en el DatePicker.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = datePick.Value.Date;

            var facturasFiltradas = listaFacturas
                .Where(f => f.Fecha.Date == fechaSeleccionada)
                .Select(f => new
                {
                    f.Id,
                    f.Ganancias,
                    f.Fecha,
                    f.Concepto,
                    f.Ubicacion
                }).ToList();

            dgvFacturas.DataSource = facturasFiltradas;
        }

        /// <summary>
        /// Restaura el DataGridView a su estado inicial mostrando todas las facturas.
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        /// <summary>
        /// Elimina la factura seleccionada en el DataGridView.
        /// </summary>
        private void btnEliminarFactura_Click(object sender, EventArgs e)
        {
            facPosServicio.EliminarRegistro((int)dgvFacturas.SelectedRows[0].Cells["Id"].Value);
            Cargar();
        }


        /// <summary>
        /// Genera un informe PDF con las facturas del mes y año seleccionados en el DatePicker.
        /// </summary>
        private void btnInforme_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = datePick.Value;
            int mes = fechaSeleccionada.Month;
            int año = fechaSeleccionada.Year;

            var facturasFiltradas = listaFacturas
                .Where(f => f.Fecha.Month == mes && f.Fecha.Year == año)
                .ToList();

            if (facturasFiltradas.Count == 0)
            {
                MessageBox.Show($"No hay facturas registradas en {fechaSeleccionada.ToString("MMMM yyyy")}.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GenerarFacPos(facturasFiltradas);
            MessageBox.Show($"Informe de {fechaSeleccionada.ToString("MMMM yyyy")} exportado correctamente en tu Escritorio.", "Informe generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }





        /// <summary>
        /// Genera un informe global en PDF con todas las facturas POS.
        /// Incluye una tabla con ID, ganancias, fecha, concepto y ubicación.
        /// </summary>
        /// <param name="facturasPos">Lista de facturas POS a incluir en el informe.</param>
        public static void GenerarFacPos(List<FacPosNegocio> facturasPos)
        {
            if (facturasPos == null || facturasPos.Count == 0)
            {
                Console.WriteLine("No hay registros de facturas para exportar.");
                return;
            }


            bool mismoMes = facturasPos.All(f => f.Fecha.Month == facturasPos[0].Fecha.Month && f.Fecha.Year == facturasPos[0].Fecha.Year);


            string nombreArchivo = mismoMes ? "FacturasMensual.pdf" : "FacturasGlobal.pdf";
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo);


            using (var writer = new PdfWriter(ruta))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf))
            {
                var azulOscuro = new DeviceRgb(30, 50, 80);
                var azulClaro = new DeviceRgb(230, 240, 255);
                var grisClaro = new DeviceRgb(245, 245, 245);


                if (Properties.Resources.logo != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        Properties.Resources.logo.Save(ms, ImageFormat.Png);
                        var imageData = ImageDataFactory.Create(ms.ToArray());

                        var logo = new iText.Layout.Element.Image(imageData)
                            .ScaleToFit(120, 120)
                            .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER)
                            .SetMarginBottom(10);

                        document.Add(logo);
                    }
                }


                var titulo = new Paragraph(" Informe de Facturas POS")
                    .SetFontSize(26)
                    .SetFontColor(azulOscuro)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginBottom(20);
                document.Add(titulo);


                var linea = new LineSeparator(new SolidLine()).SetStrokeColor(azulOscuro).SetMarginBottom(15);
                document.Add(linea);


                var tabla = new Table(new float[] { 1, 2, 2, 3, 2 }).UseAllAvailableWidth();
                string[] headers = { "ID", "Ganancias", "Fecha", "Concepto", "Ubicación" };

                foreach (var header in headers)
                {
                    var headerCell = new Cell()
                        .Add(new Paragraph(header).SetFontColor(ColorConstants.WHITE))
                        .SetBackgroundColor(azulOscuro)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetPadding(5);
                    tabla.AddHeaderCell(headerCell);
                }

                decimal total = 0;
                bool alternar = false;

                foreach (var fac in facturasPos)
                {
                    var bgColor = alternar ? grisClaro : ColorConstants.WHITE;
                    alternar = !alternar;

                    tabla.AddCell(new Cell().Add(new Paragraph(fac.Id.ToString())).SetBackgroundColor(bgColor));
                    tabla.AddCell(new Cell().Add(new Paragraph($"{fac.Ganancias:C}")).SetBackgroundColor(bgColor));
                    tabla.AddCell(new Cell().Add(new Paragraph(fac.Fecha.ToString("dd/MM/yyyy HH:mm"))).SetBackgroundColor(bgColor));
                    tabla.AddCell(new Cell().Add(new Paragraph(fac.Concepto)).SetBackgroundColor(bgColor));
                    tabla.AddCell(new Cell().Add(new Paragraph(fac.Ubicacion)).SetBackgroundColor(bgColor));

                    total += fac.Ganancias;
                }

                document.Add(tabla);


                var totalGanancias = new Paragraph($"\n Total general: {total:C}")
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetFontSize(13)
                    .SetFontColor(azulOscuro)
                    .SetMarginTop(20);
                document.Add(totalGanancias);


                var fechaGenerado = new Paragraph($" Generado el {DateTime.Now:dd/MM/yyyy HH:mm}")
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetFontSize(9)
                    .SetFontColor(ColorConstants.GRAY);

                document.Add(fechaGenerado);
            }

            Console.WriteLine("PDF de Facturas generado correctamente en: " + ruta);
        }


        /// <summary>
        /// Genera un PDF individual para una factura POS espcífica.
        /// El archivo se guarda en el Escritorio con nAombre FacturaPOS_{ID}.pdf.
        /// </summary>
        /// <param name="factura">Factura POS que se desea exportar.</param>
        public static void GenerarFacturaPosIndividual(FacPosNegocio factura)
        {
            if (factura == null)
            {
                Console.WriteLine("Factura no encontrada.");
                return;
            }

            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"FacturaIndividual_{factura.Id}.pdf");

            using (var writer = new PdfWriter(ruta))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf))
            {
                var azulOscuro = new DeviceRgb(30, 50, 80);
                var grisFondo = new DeviceRgb(245, 245, 245);



                Bitmap foto = Resources.logo;
                using (var ms = new MemoryStream())
                {
                    foto.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    var imgData = ImageDataFactory.Create(ms.ToArray());
                    var logo = new iText.Layout.Element.Image(imgData)
                        .ScaleToFit(100, 100)
                        .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER)
                        .SetMarginBottom(10);
                    document.Add(logo);
                }


                var titulo = new Paragraph($" Factura  #{factura.Id}")
                    .SetFontSize(24)
                    .SetFontColor(azulOscuro)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginBottom(20);
                document.Add(titulo);


                document.Add(new LineSeparator(new SolidLine()).SetStrokeColor(azulOscuro).SetMarginBottom(15));


                var tabla = new Table(UnitValue.CreatePercentArray(new float[] { 30, 70 }))
                    .UseAllAvailableWidth()
                    .SetBackgroundColor(grisFondo)
                    .SetPadding(5)
                    .SetMarginBottom(20);

                void AñadirFila(string campo, string valor)
                {
                    tabla.AddCell(new Cell().Add(new Paragraph(campo)).SetBackgroundColor(ColorConstants.WHITE));
                    tabla.AddCell(new Cell().Add(new Paragraph(valor)).SetBackgroundColor(ColorConstants.WHITE));
                }

                AñadirFila(" Fecha", factura.Fecha.ToString("dd/MM/yyyy HH:mm"));
                AñadirFila(" Ganancias", $"{factura.Ganancias:C}");
                AñadirFila(" Concepto", factura.Concepto);
                AñadirFila(" Ubicación", factura.Ubicacion);

                document.Add(tabla);

                var total = new Paragraph($"Total: {factura.Ganancias:C}")
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetFontSize(14)
                    .SetFontColor(azulOscuro)
                    .SetMarginBottom(10);
                document.Add(total);


                var generado = new Paragraph($" Generado el {DateTime.Now:dd/MM/yyyy HH:mm}")
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetFontSize(9)
                    .SetFontColor(ColorConstants.GRAY);
                document.Add(generado);
            }

            MessageBox.Show($"Factura individual generada correctamente en: {ruta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Obtiene un informe de todas las facturas existentes
        /// </summary>
        private void btnglobal_Click(object sender, EventArgs e)
        {
            if (listaFacturas.Count == 0)
            {
                MessageBox.Show($"No hay facturas registradas", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GenerarFacPos(listaFacturas);
            MessageBox.Show($"Informe global exportado correctamente en tu Escritorio.", "Informe generado", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }

}

