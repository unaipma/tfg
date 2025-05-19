using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPV.Views.Landings;

namespace TPV.Views.Mostrar
{
    public partial class Cantidad : Form
    {
        public int CantidadSeleccionada { get; private set; } = 1; 

        private LandingUsuario landing;

        /// <summary>
        /// Constructor de la clase.
        /// Inicializa el formulario y establece la referencia al formulario principal (LandingUsuario).
        /// Además, posiciona el formulario de forma manual en relación al formulario principal.
        /// </summary>
        /// <param name="parent">Referencia al formulario principal (LandingUsuario).</param>
        public Cantidad(LandingUsuario parent)
        {
            InitializeComponent();
            landing = parent;

           
            this.StartPosition = FormStartPosition.Manual;

            int x = parent.Location.X + 20;
            int y = parent.Location.Y + parent.Height - this.Height - 80;

            this.Location = new Point(x, y);
        }

        /// <summary>
        /// Establece la cantidad seleccionada y la comunica al formulario principal.
        /// </summary>
        /// <param name="cantidad">Cantidad seleccionada por el usuario.</param>
        private void SeleccionarCantidad(int cantidad)
        {
            landing.SetCantidadSeleccionada(cantidad);
            this.Hide();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "1". Establece la cantidad seleccionada a 1.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn1_Click(object sender, EventArgs e) => SeleccionarCantidad(1);

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "2". Establece la cantidad seleccionada a 2.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn2_Click(object sender, EventArgs e) => SeleccionarCantidad(2);

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "3". Establece la cantidad seleccionada a 3.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn3_Click(object sender, EventArgs e) => SeleccionarCantidad(3);

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "4". Establece la cantidad seleccionada a 4.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn4_Click(object sender, EventArgs e) => SeleccionarCantidad(4);

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "5". Establece la cantidad seleccionada a 5.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn5_Click(object sender, EventArgs e) => SeleccionarCantidad(5);

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "6". Establece la cantidad seleccionada a 6.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn6_Click(object sender, EventArgs e) => SeleccionarCantidad(6);

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "7". Establece la cantidad seleccionada a 7.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn7_Click(object sender, EventArgs e) => SeleccionarCantidad(7);

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "8". Establece la cantidad seleccionada a 8.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn8_Click(object sender, EventArgs e) => SeleccionarCantidad(8);

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "9". Establece la cantidad seleccionada a 9.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de clic.</param>
        private void btn9_Click(object sender, EventArgs e) => SeleccionarCantidad(9);

        /// <summary>
        /// Evento que se ejecuta cuando el formulario de cantidad se cierra.
        /// Limpia la referencia de la cantidad seleccionada en el formulario principal (LandingUsuario).
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento de cierre del formulario.</param>
        private void cantidad_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Owner is LandingUsuario parent)
            {
                parent.LimpiarReferenciaCantidad();
            }
        }
    }
}
