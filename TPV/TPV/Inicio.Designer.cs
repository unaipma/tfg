namespace TPV
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.lblInicio = new System.Windows.Forms.Label();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInicio
            // 
            this.lblInicio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInicio.AutoSize = true;
            this.lblInicio.BackColor = System.Drawing.Color.Gray;
            this.lblInicio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInicio.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblInicio.Location = new System.Drawing.Point(203, 77);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(477, 32);
            this.lblInicio.TabIndex = 0;
            this.lblInicio.Text = "Bienvenido al TPV. Seleccione una opción";
            // 
            // btnUsuario
            // 
            this.btnUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuario.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.Location = new System.Drawing.Point(567, 363);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(170, 76);
            this.btnUsuario.TabIndex = 1;
            this.btnUsuario.Text = "Usuario";
            this.btnUsuario.UseVisualStyleBackColor = false;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdmin.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.Location = new System.Drawing.Point(179, 363);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(170, 77);
            this.btnAdmin.TabIndex = 2;
            this.btnAdmin.Text = "Administrador";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // pictureLogo
            // 
            this.pictureLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureLogo.BackgroundImage = global::TPV.Properties.Resources.logo;
            this.pictureLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureLogo.Location = new System.Drawing.Point(341, 157);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(217, 160);
            this.pictureLogo.TabIndex = 3;
            this.pictureLogo.TabStop = false;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(883, 514);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.pictureLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(905, 570);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inicio_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.PictureBox pictureLogo;
    }
}