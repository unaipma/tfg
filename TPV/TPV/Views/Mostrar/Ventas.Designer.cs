namespace TPV.Views.Mostrar
{
    partial class Ventas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventas));
            this.btnIzquierda = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnDerecha = new System.Windows.Forms.Button();
            this.btnBorrarFactura = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.pnlProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.lbll = new System.Windows.Forms.Label();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIzquierda
            // 
            this.btnIzquierda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIzquierda.BackgroundImage = global::TPV.Properties.Resources.flechaizquierda;
            this.btnIzquierda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIzquierda.Location = new System.Drawing.Point(65, 317);
            this.btnIzquierda.Name = "btnIzquierda";
            this.btnIzquierda.Size = new System.Drawing.Size(102, 81);
            this.btnIzquierda.TabIndex = 2;
            this.btnIzquierda.UseVisualStyleBackColor = true;
            this.btnIzquierda.Click += new System.EventHandler(this.btnIzquierda_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.BackgroundImage = global::TPV.Properties.Resources.atras;
            this.btnAtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAtras.Location = new System.Drawing.Point(13, 31);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(91, 80);
            this.btnAtras.TabIndex = 1;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnDerecha
            // 
            this.btnDerecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDerecha.BackgroundImage = global::TPV.Properties.Resources.flechaderecha;
            this.btnDerecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDerecha.Location = new System.Drawing.Point(622, 317);
            this.btnDerecha.Name = "btnDerecha";
            this.btnDerecha.Size = new System.Drawing.Size(102, 81);
            this.btnDerecha.TabIndex = 0;
            this.btnDerecha.UseVisualStyleBackColor = true;
            this.btnDerecha.Click += new System.EventHandler(this.btnDerecha_Click);
            // 
            // btnBorrarFactura
            // 
            this.btnBorrarFactura.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBorrarFactura.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarFactura.Location = new System.Drawing.Point(335, 331);
            this.btnBorrarFactura.Name = "btnBorrarFactura";
            this.btnBorrarFactura.Size = new System.Drawing.Size(118, 52);
            this.btnBorrarFactura.TabIndex = 3;
            this.btnBorrarFactura.Text = "Borrar factura";
            this.btnBorrarFactura.UseVisualStyleBackColor = true;
            this.btnBorrarFactura.Click += new System.EventHandler(this.btnBorrarFactura_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(150, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Venta realizada por:";
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(347, 58);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(63, 20);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "nombre";
            // 
            // picUser
            // 
            this.picUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picUser.BackgroundImage = global::TPV.Properties.Resources.usernophoto;
            this.picUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picUser.Location = new System.Drawing.Point(476, 31);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(95, 80);
            this.picUser.TabIndex = 6;
            this.picUser.TabStop = false;
            // 
            // lblHora
            // 
            this.lblHora.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(347, 149);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(18, 20);
            this.lblHora.TabIndex = 7;
            this.lblHora.Text = "0";
            // 
            // lbl
            // 
            this.lbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(250, 144);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(62, 25);
            this.lbl.TabIndex = 8;
            this.lbl.Text = "Hora:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.BackColor = System.Drawing.Color.Black;
            this.lblPrecio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.ForeColor = System.Drawing.Color.Red;
            this.lblPrecio.Location = new System.Drawing.Point(335, 237);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(33, 34);
            this.lblPrecio.TabIndex = 9;
            this.lblPrecio.Text = "0";
            // 
            // pnlProductos
            // 
            this.pnlProductos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlProductos.AutoScroll = true;
            this.pnlProductos.BackColor = System.Drawing.Color.Silver;
            this.pnlProductos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlProductos.Location = new System.Drawing.Point(510, 132);
            this.pnlProductos.Name = "pnlProductos";
            this.pnlProductos.Size = new System.Drawing.Size(245, 125);
            this.pnlProductos.TabIndex = 10;
            this.pnlProductos.WrapContents = false;
            // 
            // lbll
            // 
            this.lbll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbll.AutoSize = true;
            this.lbll.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbll.Location = new System.Drawing.Point(250, 195);
            this.lbll.Name = "lbll";
            this.lbll.Size = new System.Drawing.Size(78, 25);
            this.lbll.TabIndex = 11;
            this.lbll.Text = "Tarjeta:";
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Location = new System.Drawing.Point(347, 198);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(23, 20);
            this.lblTarjeta.TabIndex = 12;
            this.lblTarjeta.Text = "Sí";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(250, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Fecha:";
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(347, 108);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(18, 20);
            this.lblFecha.TabIndex = 13;
            this.lblFecha.Text = "0";
            this.lblFecha.Click += new System.EventHandler(this.lblFecha_Click);
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(800, 484);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblTarjeta);
            this.Controls.Add(this.lbll);
            this.Controls.Add(this.pnlProductos);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.picUser);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBorrarFactura);
            this.Controls.Add(this.btnIzquierda);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnDerecha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(822, 506);
            this.Name = "Ventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas";
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDerecha;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnIzquierda;
        private System.Windows.Forms.Button btnBorrarFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.FlowLayoutPanel pnlProductos;
        private System.Windows.Forms.Label lbll;
        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFecha;
    }
}