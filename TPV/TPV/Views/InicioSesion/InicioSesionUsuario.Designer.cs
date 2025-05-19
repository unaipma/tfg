namespace TPV.Views
{
    partial class InicioSesionUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicioSesionUsuario));
            this.lblInicioSesión = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.cmboxubicaciones = new System.Windows.Forms.ComboBox();
            this.btnAtras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInicioSesión
            // 
            this.lblInicioSesión.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInicioSesión.AutoSize = true;
            this.lblInicioSesión.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicioSesión.Location = new System.Drawing.Point(233, 113);
            this.lblInicioSesión.Name = "lblInicioSesión";
            this.lblInicioSesión.Size = new System.Drawing.Size(330, 37);
            this.lblInicioSesión.TabIndex = 0;
            this.lblInicioSesión.Text = "Selecciona localización";
            // 
            // btnLogin
            // 
            this.btnLogin.AllowDrop = true;
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(363, 284);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(81, 43);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // cmboxubicaciones
            // 
            this.cmboxubicaciones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmboxubicaciones.FormattingEnabled = true;
            this.cmboxubicaciones.Location = new System.Drawing.Point(297, 186);
            this.cmboxubicaciones.Name = "cmboxubicaciones";
            this.cmboxubicaciones.Size = new System.Drawing.Size(203, 28);
            this.cmboxubicaciones.TabIndex = 3;
            // 
            // btnAtras
            // 
            this.btnAtras.Image = global::TPV.Properties.Resources.atras;
            this.btnAtras.Location = new System.Drawing.Point(28, 38);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(121, 101);
            this.btnAtras.TabIndex = 4;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // InicioSesionUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.cmboxubicaciones);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblInicioSesión);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(822, 506);
            this.Name = "InicioSesionUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar sesión";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InicioSesionUsuario_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInicioSesión;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ComboBox cmboxubicaciones;
        private System.Windows.Forms.Button btnAtras;
    }
}