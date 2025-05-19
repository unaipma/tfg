namespace TPV.Views.Registros
{
    partial class Ajustes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ajustes));
            this.lblError = new System.Windows.Forms.Label();
            this.txbxLocalizacion = new System.Windows.Forms.TextBox();
            this.lblLocalización = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txbxNombre = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txboxCorreo = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
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
            this.lblError.Location = new System.Drawing.Point(373, 266);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 21);
            this.lblError.TabIndex = 26;
            // 
            // txbxLocalizacion
            // 
            this.txbxLocalizacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbxLocalizacion.Location = new System.Drawing.Point(334, 224);
            this.txbxLocalizacion.Name = "txbxLocalizacion";
            this.txbxLocalizacion.Size = new System.Drawing.Size(189, 26);
            this.txbxLocalizacion.TabIndex = 23;
            // 
            // lblLocalización
            // 
            this.lblLocalización.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLocalización.AutoSize = true;
            this.lblLocalización.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalización.Location = new System.Drawing.Point(169, 230);
            this.lblLocalización.Name = "lblLocalización";
            this.lblLocalización.Size = new System.Drawing.Size(108, 20);
            this.lblLocalización.TabIndex = 22;
            this.lblLocalización.Text = "Localización";
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(169, 135);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(71, 20);
            this.lblNombre.TabIndex = 21;
            this.lblNombre.Text = "Nombre";
            // 
            // txbxNombre
            // 
            this.txbxNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbxNombre.Location = new System.Drawing.Point(334, 135);
            this.txbxNombre.Name = "txbxNombre";
            this.txbxNombre.Size = new System.Drawing.Size(189, 26);
            this.txbxNombre.TabIndex = 20;
            // 
            // lblCorreo
            // 
            this.lblCorreo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.Location = new System.Drawing.Point(169, 181);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(63, 20);
            this.lblCorreo.TabIndex = 17;
            this.lblCorreo.Text = "Correo";
            // 
            // txboxCorreo
            // 
            this.txboxCorreo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txboxCorreo.Location = new System.Drawing.Point(334, 181);
            this.txboxCorreo.Name = "txboxCorreo";
            this.txboxCorreo.Size = new System.Drawing.Size(189, 26);
            this.txboxCorreo.TabIndex = 16;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnActualizar.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(361, 337);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(99, 36);
            this.btnActualizar.TabIndex = 15;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnImage
            // 
            this.btnImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImage.BackgroundImage = global::TPV.Properties.Resources.gallery;
            this.btnImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImage.Location = new System.Drawing.Point(589, 123);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(131, 106);
            this.btnImage.TabIndex = 24;
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAtras.BackgroundImage = global::TPV.Properties.Resources.atras;
            this.btnAtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAtras.Location = new System.Drawing.Point(12, 384);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(73, 54);
            this.btnAtras.TabIndex = 27;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // Ajustes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(800, 484);
            this.ControlBox = false;
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.txbxLocalizacion);
            this.Controls.Add(this.lblLocalización);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txbxNombre);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.txboxCorreo);
            this.Controls.Add(this.btnActualizar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(822, 506);
            this.Name = "Ajustes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajustes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.TextBox txbxLocalizacion;
        private System.Windows.Forms.Label lblLocalización;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txbxNombre;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txboxCorreo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAtras;
    }
}