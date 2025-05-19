namespace TPV.Views.Registros
{
    partial class RegistroEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroEmpleado));
            this.lblError = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.btnImage = new System.Windows.Forms.Button();
            this.txbxLocalizacion = new System.Windows.Forms.TextBox();
            this.lblLocalización = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txbxNombre = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txboxCorreo = new System.Windows.Forms.TextBox();
            this.btnRegistro = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Black;
            this.lblError.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lblError.Location = new System.Drawing.Point(427, 266);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 21);
            this.lblError.TabIndex = 25;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(369, 307);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(197, 20);
            this.lblImage.TabIndex = 24;
            this.lblImage.Text = "Elige una foto para el perfil";
            // 
            // btnImage
            // 
            this.btnImage.BackgroundImage = global::TPV.Properties.Resources.gallery;
            this.btnImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImage.Location = new System.Drawing.Point(227, 307);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(84, 77);
            this.btnImage.TabIndex = 23;
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // txbxLocalizacion
            // 
            this.txbxLocalizacion.Location = new System.Drawing.Point(388, 204);
            this.txbxLocalizacion.Name = "txbxLocalizacion";
            this.txbxLocalizacion.Size = new System.Drawing.Size(189, 26);
            this.txbxLocalizacion.TabIndex = 22;
            // 
            // lblLocalización
            // 
            this.lblLocalización.AutoSize = true;
            this.lblLocalización.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalización.Location = new System.Drawing.Point(212, 210);
            this.lblLocalización.Name = "lblLocalización";
            this.lblLocalización.Size = new System.Drawing.Size(108, 20);
            this.lblLocalización.TabIndex = 21;
            this.lblLocalización.Text = "Localización";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(223, 101);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(71, 20);
            this.lblNombre.TabIndex = 20;
            this.lblNombre.Text = "Nombre";
            // 
            // txbxNombre
            // 
            this.txbxNombre.Location = new System.Drawing.Point(388, 101);
            this.txbxNombre.Name = "txbxNombre";
            this.txbxNombre.Size = new System.Drawing.Size(189, 26);
            this.txbxNombre.TabIndex = 19;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.Location = new System.Drawing.Point(223, 150);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(63, 20);
            this.lblCorreo.TabIndex = 16;
            this.lblCorreo.Text = "Correo";
            // 
            // txboxCorreo
            // 
            this.txboxCorreo.Location = new System.Drawing.Point(388, 150);
            this.txboxCorreo.Name = "txboxCorreo";
            this.txboxCorreo.Size = new System.Drawing.Size(189, 26);
            this.txboxCorreo.TabIndex = 15;
            // 
            // btnRegistro
            // 
            this.btnRegistro.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.Location = new System.Drawing.Point(431, 348);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Size = new System.Drawing.Size(99, 36);
            this.btnRegistro.TabIndex = 14;
            this.btnRegistro.Text = "Registrar";
            this.btnRegistro.UseVisualStyleBackColor = true;
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAtras.BackgroundImage = global::TPV.Properties.Resources.atras;
            this.btnAtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAtras.Location = new System.Drawing.Point(37, 34);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(73, 54);
            this.btnAtras.TabIndex = 28;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // RegistroEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.txbxLocalizacion);
            this.Controls.Add(this.lblLocalización);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txbxNombre);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.txboxCorreo);
            this.Controls.Add(this.btnRegistro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistroEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo empleado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.TextBox txbxLocalizacion;
        private System.Windows.Forms.Label lblLocalización;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txbxNombre;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txboxCorreo;
        private System.Windows.Forms.Button btnRegistro;
        private System.Windows.Forms.Button btnAtras;
    }
}