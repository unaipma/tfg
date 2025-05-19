using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppCalculadora
{
    public partial class Calculadora : Form
    {
        private string _valorActual = "";
        private double _resultado;
        private char _operacionPendiente;
        private readonly TextBox _display;

        public Calculadora()
        {
            InitializeComponent();

            _display = new TextBox { Left = 10, Top = 10, Width = 240, ReadOnly = true, TabStop = false };
            Controls.Add(_display);

            EventHandler btnClick = (sender, args) => { TeclaPulsada((char)((Button)sender).Tag); };

            for (int i = 1, btnLeft = 10, btnTop = 190;
                i < 10;
                i++, btnLeft += btnLeft == 110 ? -100 : 50, btnTop -= btnLeft == 10 ? 50 : 0)
            {
                var btn = new Button { Left = btnLeft, Top = btnTop, Width = 40, Height = 40, Text = i.ToString(), Tag = char.Parse(i.ToString()), TabStop = false };
                btn.Click += btnClick;
                Controls.Add(btn);
            }
            var btn0 = new Button { Left = 10, Top = 240, Width = 90, Height = 40, Text = @"0", Tag = '0', TabStop = false };
            btn0.Click += btnClick;
            Controls.Add(btn0);
            var btnDot = new Button { Left = 110, Top = 240, Width = 40, Height = 40, Text = @".", Tag = '.', TabStop = false };
            btnDot.Click += btnClick;
            Controls.Add(btnDot);
            char[] operaciones = { '±', '/', '*', '-', '+' };
            for (var i = 0; i < operaciones.Length; i++)
            {
                var btnOperation = new Button { Left = 160, Top = 40 + 50 * i, Width = 40, Height = 40, Text = operaciones[i].ToString(), Tag = operaciones[i], TabStop = false };
                btnOperation.Click += btnClick;
                Controls.Add(btnOperation);
            }
            var btnRaiz = new Button { Left = 210, Top = 40, Width = 40, Height = 40, Text = @"raíz", Tag = 'r', TabStop = false };
            btnRaiz.Click += btnClick;
            Controls.Add(btnRaiz);
            var btnPorcentaje = new Button { Left = 210, Top = 90, Width = 40, Height = 40, Text = @"%", Tag = '%', TabStop = false };
            btnPorcentaje.Click += btnClick;
            Controls.Add(btnPorcentaje);
            var btnInverso = new Button { Left = 210, Top = 140, Width = 40, Height = 40, Text = @"1/x", Tag = 'i', TabStop = false };
            btnInverso.Click += btnClick;
            Controls.Add(btnInverso);

            var btnEnter = new Button { Left = 210, Top = 190, Width = 40, Height = 90, Text = @"=", Tag = '=', TabStop = false };
            btnEnter.Click += btnClick;
            Controls.Add(btnEnter);
            var btnBack = new Button { Left = 10, Top = 40, Width = 40, Height = 40, Text = @"<--", Tag = '\b', TabStop = false };
            btnBack.Click += btnClick;
            Controls.Add(btnBack);
            var btnCe = new Button { Left = 60, Top = 40, Width = 40, Height = 40, Text = @"CE", Tag = 'e', TabStop = false };
            btnCe.Click += btnClick;
            Controls.Add(btnCe);
            var btnC = new Button { Left = 110, Top = 40, Width = 40, Height = 40, Text = @"C", Tag = 'c', TabStop = false };
            btnC.Click += btnClick;
            Controls.Add(btnC);

            KeyPreview = true;
            KeyPress += (sender, args) => { TeclaPulsada(args.KeyChar); };
            KeyDown += (sender, args) =>
            {
                switch (args.KeyCode)
                {
                    case Keys.Delete:
                        TeclaPulsada('e');
                        break;
                    case Keys.Escape:
                        TeclaPulsada('c');
                        break;
                }
            };
            Width = 280;
            Height = 350;
        }

        private void TeclaPulsada(char key)
        {
            // Es un número
            if (char.IsDigit(key))
            {
                if (_valorActual.Length >= 25) return;
                _valorActual += key.ToString();
                _display.Text = _valorActual;
                return;
            }


            switch (key)
            {
                // Punto decimal (si ya hay uno no hace nada)
                case '.':
                    if (!_valorActual.Contains("."))
                    {
                        _valorActual += _valorActual.Length == 0 ? "0." : ".";
                        _display.Text = _valorActual;
                    }
                    break;
                // Operaciones binarias. Ejecuta la operación pendiente (si la hay)
                // y se establece como pendiente la pulsada
                case '+':
                case '-':
                case '*':
                case '/':
                    EjecutarOperacionPendiente();
                    _operacionPendiente = key;
                    break;
                // Otras operaciones
                // Cambio de signo
                case '±':
                case 's':
                case 'S':
                    EjecutarOperacionInmediata('±');
                    break;
                // raíz cuadrada
                case 'r':
                case 'R':
                    EjecutarOperacionInmediata('r');
                    break;
                // inverso (1/x)
                case 'i':
                case 'I':
                    EjecutarOperacionInmediata('i');
                    break;
                case '%':
                    // Es un caso particular: de ejecución inmediata
                    // pero utiliza dos variables para el cálculo
                    EjecutarPorcentaje();
                    break;
                // Igual/Enter (resultado)
                case '=':
                case '\r':
                    EjecutarOperacionPendiente();
                    break;
                // Retroceso (backspace)
                case '\b':
                    if (_valorActual.Length > 0)
                    {
                        _valorActual = _valorActual.Remove(_valorActual.Length - 1);
                        _display.Text = _valorActual;
                    }
                    break;
                // Suprimir/E. Eliminar valor actual
                case 'e':
                case 'E':
                    _valorActual = "";
                    _display.Text = @"0";
                    break;
                // Escape/C. Resetear (reiniciar)
                case 'c':
                case 'C':
                    _resultado = 0;
                    _valorActual = "";
                    _display.Text = @"0";
                    break;
            }
        }

        private void EjecutarPorcentaje()
        {
            if (string.IsNullOrEmpty(_display.Text) || _display.Text == @"0")
                return;

            var valor = double.Parse(_display.Text, CultureInfo.InvariantCulture);
            valor = _resultado * valor / 100;
            _valorActual = valor.ToString(CultureInfo.InvariantCulture);
            _display.Text = _valorActual;
        }

        private void EjecutarOperacionPendiente()
        {
            if (_valorActual.Length <= 0) return;

            var valor = double.Parse(_valorActual, CultureInfo.InvariantCulture);
            switch (_operacionPendiente)
            {
                case '+':
                    _resultado += valor;
                    break;
                case '-':
                    _resultado -= valor;
                    break;
                case '*':
                    _resultado *= valor;
                    break;
                case '/':
                    _resultado /= valor;
                    break;
                default:
                    _resultado = valor;
                    break;
            }
            _valorActual = "";
            _operacionPendiente = char.MinValue;
            _display.Text = _resultado.ToString(CultureInfo.InvariantCulture);
        }

        private void EjecutarOperacionInmediata(char operacion)
        {
            if (!string.IsNullOrEmpty(_valorActual) && _valorActual != @"0")
            {
                _valorActual = AplicarAValor(operacion, _valorActual);
                _display.Text = _valorActual;
            }
            else
            {
                if (!string.IsNullOrEmpty(_display.Text) && _display.Text != @"0")
                {
                    _resultado = AplicarAValor(operacion, _resultado);
                    _display.Text = _resultado.ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        private string AplicarAValor(char operacion, string valor)
        {
            switch (operacion)
            {
                case '±':
                    return valor.StartsWith("-") ? valor.Substring(1) : $"-{valor}";
                case 'r':
                case 'i':
                    var numerico = double.Parse(valor, CultureInfo.InvariantCulture);
                    return AplicarAValor(operacion, numerico).ToString(CultureInfo.InvariantCulture);
                default:
                    return valor;
            }
        }

        private double AplicarAValor(char operacion, double valor)
        {
            switch (operacion)
            {
                case '±':
                    return -valor;
                case 'r':
                    return Math.Sqrt(valor);
                case 'i':
                    return 1 / valor;
                default:
                    return valor;
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculadora));
            this.SuspendLayout();
            // 
            // Calculadora
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(280, 257);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Calculadora";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
