namespace TPV.Views.Registros
{
    partial class RegistroProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroProducto));
            this.lblError = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.btnImage = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txbxNombre = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txboxCategoria = new System.Windows.Forms.TextBox();
            this.btnRegistro = new System.Windows.Forms.Button();
            this.numPrecio = new System.Windows.Forms.NumericUpDown();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Black;
            this.lblError.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lblError.Location = new System.Drawing.Point(369, 251);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 21);
            this.lblError.TabIndex = 35;
            // 
            // lblImage
            // 
            this.lblImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(323, 290);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(226, 20);
            this.lblImage.TabIndex = 34;
            this.lblImage.Text = "Elige una foto para el producto";
            // 
            // btnImage
            // 
            this.btnImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImage.BackgroundImage = global::TPV.Properties.Resources.gallery;
            this.btnImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImage.Location = new System.Drawing.Point(216, 290);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(84, 77);
            this.btnImage.TabIndex = 33;
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(229, 84);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(71, 20);
            this.lblNombre.TabIndex = 30;
            this.lblNombre.Text = "Nombre";
            // 
            // txbxNombre
            // 
            this.txbxNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbxNombre.Location = new System.Drawing.Point(394, 84);
            this.txbxNombre.Name = "txbxNombre";
            this.txbxNombre.Size = new System.Drawing.Size(189, 26);
            this.txbxNombre.TabIndex = 29;
            // 
            // lblCategoria
            // 
            this.lblCategoria.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(229, 133);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(87, 20);
            this.lblCategoria.TabIndex = 28;
            this.lblCategoria.Text = "Categoría";
            // 
            // txboxCategoria
            // 
            this.txboxCategoria.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txboxCategoria.Location = new System.Drawing.Point(394, 133);
            this.txboxCategoria.Name = "txboxCategoria";
            this.txboxCategoria.Size = new System.Drawing.Size(189, 26);
            this.txboxCategoria.TabIndex = 27;
            // 
            // btnRegistro
            // 
            this.btnRegistro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegistro.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.Location = new System.Drawing.Point(437, 331);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Size = new System.Drawing.Size(99, 36);
            this.btnRegistro.TabIndex = 26;
            this.btnRegistro.Text = "Registrar";
            this.btnRegistro.UseVisualStyleBackColor = true;
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // numPrecio
            // 
            this.numPrecio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numPrecio.DecimalPlaces = 2;
            this.numPrecio.Location = new System.Drawing.Point(422, 189);
            this.numPrecio.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numPrecio.Name = "numPrecio";
            this.numPrecio.Size = new System.Drawing.Size(120, 26);
            this.numPrecio.TabIndex = 36;
            // 
            // lblPrecio
            // 
            this.lblPrecio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(255, 189);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(61, 22);
            this.lblPrecio.TabIndex = 37;
            this.lblPrecio.Text = "Precio";
            // 
            // btnAtras
            // 
            this.btnAtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAtras.BackgroundImage = global::TPV.Properties.Resources.atras;
            this.btnAtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAtras.Location = new System.Drawing.Point(12, 12);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(73, 54);
            this.btnAtras.TabIndex = 38;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // RegistroProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(800, 484);
            this.ControlBox = false;
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.numPrecio);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txbxNombre);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txboxCategoria);
            this.Controls.Add(this.btnRegistro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(822, 506);
            this.Name = "RegistroProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo producto";
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txbxNombre;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txboxCategoria;
        private System.Windows.Forms.Button btnRegistro;
        private System.Windows.Forms.NumericUpDown numPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Button btnAtras;
    }
}