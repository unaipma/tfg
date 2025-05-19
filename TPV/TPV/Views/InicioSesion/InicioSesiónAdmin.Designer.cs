namespace TPV.Views
{
    partial class InicioSesiónAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicioSesiónAdmin));
            this.lblinicioadmin = new System.Windows.Forms.Label();
            this.txbxCorreo = new System.Windows.Forms.TextBox();
            this.lblgmail = new System.Windows.Forms.Label();
            this.txbxContraseña = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInicioSesion = new System.Windows.Forms.Button();
            this.btnatras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblinicioadmin
            // 
            this.lblinicioadmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblinicioadmin.AutoSize = true;
            this.lblinicioadmin.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinicioadmin.Location = new System.Drawing.Point(124, 117);
            this.lblinicioadmin.Name = "lblinicioadmin";
            this.lblinicioadmin.Size = new System.Drawing.Size(620, 30);
            this.lblinicioadmin.TabIndex = 0;
            this.lblinicioadmin.Text = "Bienvenido administrador, introduzca sus credenciales";
            // 
            // txbxCorreo
            // 
            this.txbxCorreo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbxCorreo.Location = new System.Drawing.Point(334, 204);
            this.txbxCorreo.Name = "txbxCorreo";
            this.txbxCorreo.Size = new System.Drawing.Size(201, 26);
            this.txbxCorreo.TabIndex = 1;
            // 
            // lblgmail
            // 
            this.lblgmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblgmail.AutoSize = true;
            this.lblgmail.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgmail.Location = new System.Drawing.Point(192, 209);
            this.lblgmail.Name = "lblgmail";
            this.lblgmail.Size = new System.Drawing.Size(66, 21);
            this.lblgmail.TabIndex = 2;
            this.lblgmail.Text = "Correo:";
            // 
            // txbxContraseña
            // 
            this.txbxContraseña.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbxContraseña.Location = new System.Drawing.Point(334, 274);
            this.txbxContraseña.Name = "txbxContraseña";
            this.txbxContraseña.PasswordChar = '*';
            this.txbxContraseña.Size = new System.Drawing.Size(201, 26);
            this.txbxContraseña.TabIndex = 3;
            // 
            // lblContraseña
            // 
            this.lblContraseña.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseña.Location = new System.Drawing.Point(180, 276);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(101, 21);
            this.lblContraseña.TabIndex = 4;
            this.lblContraseña.Text = "Contraseña:";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClear.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(261, 330);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(144, 39);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Borrar campos";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnInicioSesion
            // 
            this.btnInicioSesion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInicioSesion.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicioSesion.Location = new System.Drawing.Point(430, 330);
            this.btnInicioSesion.Name = "btnInicioSesion";
            this.btnInicioSesion.Size = new System.Drawing.Size(151, 39);
            this.btnInicioSesion.TabIndex = 6;
            this.btnInicioSesion.Text = "Iniciar Sesión";
            this.btnInicioSesion.UseVisualStyleBackColor = true;
            this.btnInicioSesion.Click += new System.EventHandler(this.btnInicioSesion_Click);
            // 
            // btnatras
            // 
            this.btnatras.BackColor = System.Drawing.Color.Honeydew;
            this.btnatras.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnatras.ForeColor = System.Drawing.Color.Transparent;
            this.btnatras.Image = global::TPV.Properties.Resources.atras;
            this.btnatras.Location = new System.Drawing.Point(9, 9);
            this.btnatras.Margin = new System.Windows.Forms.Padding(0);
            this.btnatras.MinimumSize = new System.Drawing.Size(97, 100);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(97, 100);
            this.btnatras.TabIndex = 7;
            this.btnatras.UseVisualStyleBackColor = false;
            this.btnatras.Click += new System.EventHandler(this.button1_Click);
            // 
            // InicioSesiónAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnatras);
            this.Controls.Add(this.btnInicioSesion);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.txbxContraseña);
            this.Controls.Add(this.lblgmail);
            this.Controls.Add(this.txbxCorreo);
            this.Controls.Add(this.lblinicioadmin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(822, 506);
            this.Name = "InicioSesiónAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar sesión";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InicioSesiónAdmin_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblinicioadmin;
        private System.Windows.Forms.TextBox txbxCorreo;
        private System.Windows.Forms.Label lblgmail;
        private System.Windows.Forms.TextBox txbxContraseña;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInicioSesion;
        private System.Windows.Forms.Button btnatras;
    }
}