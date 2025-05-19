using System;
using System.Drawing;
using System.Windows.Forms;

namespace TPV.Views.Mostrar
{
    public partial class cantidaddecimales : Form
    {
        private string entradaActual = "0";
        private bool puntoUsado = false;
        private dynamic landing;

        /// <summary>
        /// Constructor de la clase.
        /// Inicializa el formulario y establece el origen al que se enviará el valor ingresado.
        /// </summary>
        /// <param name="origen">Objeto que recibirá el valor ingresado.</param>
        public cantidaddecimales(dynamic origen)
        {
            InitializeComponent();
            landing = origen;
        }

        /// <summary>
        /// Evento que se ejecuta cuando se carga el formulario.
        /// Establece el valor inicial del campo de entrada.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void cantidaddecimales_Load(object sender, EventArgs e)
        {
            lblTotal.Text = entradaActual;
        }

        /// <summary>
        /// Añade un dígito al valor ingresado. Controla el formato con respecto al número de decimales y enteros.
        /// </summary>
        /// <param name="digito">Dígito o punto a añadir al valor actual.</param>
        private void AñadirDigito(string digito)
        {
            if (entradaActual == "0" && digito != ".")
                entradaActual = "";

            if (digito == ".")
            {
                if (puntoUsado) return;
                puntoUsado = true;
            }

            int puntoIndex = entradaActual.IndexOf('.');
            int enteros = (puntoIndex == -1) ? entradaActual.Length : puntoIndex;
            int decimales = (puntoIndex == -1) ? 0 : entradaActual.Length - puntoIndex - 1;

            if (puntoIndex == -1 && enteros >= 3 && digito != ".") return;
            if (puntoIndex != -1 && decimales >= 2 && digito != ".") return;

            entradaActual += digito;
            lblTotal.Text = entradaActual;
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "0". Añade el dígito "0" al valor ingresado.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn0_Click(object sender, EventArgs e) => AñadirDigito("0");

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "1". Añade el dígito "1" al valor ingresado.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn1_Click(object sender, EventArgs e) => AñadirDigito("1");

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "2". Añade el dígito "2" al valor ingresado.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn2_Click(object sender, EventArgs e) => AñadirDigito("2");

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "3". Añade el dígito "3" al valor ingresado.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn3_Click(object sender, EventArgs e) => AñadirDigito("3");

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "4". Añade el dígito "4" al valor ingresado.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn4_Click(object sender, EventArgs e) => AñadirDigito("4");

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "5". Añade el dígito "5" al valor ingresado.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn5_Click(object sender, EventArgs e) => AñadirDigito("5");

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "6". Añade el dígito "6" al valor ingresado.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn6_Click(object sender, EventArgs e) => AñadirDigito("6");

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "7". Añade el dígito "7" al valor ingresado.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn7_Click(object sender, EventArgs e) => AñadirDigito("7");

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "8". Añade el dígito "8" al valor ingresado.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn8_Click(object sender, EventArgs e) => AñadirDigito("8");

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "9". Añade el dígito "9" al valor ingresado.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn9_Click(object sender, EventArgs e) => AñadirDigito("9");

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "punto". Añade el punto decimal al valor ingresado.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btnpunto_Click(object sender, EventArgs e) => AñadirDigito(".");

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Borrar". Restablece el valor a "0" y resetea el estado del punto decimal.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            entradaActual = "0";
            puntoUsado = false;
            lblTotal.Text = entradaActual;
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Aceptar". Valida y transfiere el valor ingresado al origen.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string texto = lblTotal.Text.Replace(",", ".");

            if (decimal.TryParse(texto, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal valor))
            {
                landing.AñadirVarios(valor);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Valor inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Volver". Cierra el formulario sin realizar cambios.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        
    }
}