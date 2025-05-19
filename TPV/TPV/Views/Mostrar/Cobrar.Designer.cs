namespace TPV.Views.Mostrar
{
    partial class Cobrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cobrar));
            this.lblCobrar = new System.Windows.Forms.Label();
            this.lblefectivotarjeta = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.pnlPrecio = new System.Windows.Forms.Panel();
            this.btnAtrás = new System.Windows.Forms.Button();
            this.picPerfil = new System.Windows.Forms.PictureBox();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btntarjetaefectivo = new System.Windows.Forms.Button();
            this.pnlPrecio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCobrar
            // 
            this.lblCobrar.AutoSize = true;
            this.lblCobrar.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCobrar.Location = new System.Drawing.Point(719, 521);
            this.lblCobrar.Name = "lblCobrar";
            this.lblCobrar.Size = new System.Drawing.Size(59, 22);
            this.lblCobrar.TabIndex = 2;
            this.lblCobrar.Text = "Cobrar";
            // 
            // lblefectivotarjeta
            // 
            this.lblefectivotarjeta.AutoSize = true;
            this.lblefectivotarjeta.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblefectivotarjeta.Location = new System.Drawing.Point(313, 510);
            this.lblefectivotarjeta.Name = "lblefectivotarjeta";
            this.lblefectivotarjeta.Size = new System.Drawing.Size(67, 22);
            this.lblefectivotarjeta.TabIndex = 3;
            this.lblefectivotarjeta.Text = "Efectivo";
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.lblUsername.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(512, 65);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(83, 39);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "User";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(384, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 36);
            this.label1.TabIndex = 6;
            this.label1.Text = "Va a realizar un cobro de:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.BackColor = System.Drawing.Color.Black;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft YaHei", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.ForeColor = System.Drawing.Color.Crimson;
            this.lblPrecio.Location = new System.Drawing.Point(3, 21);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(52, 58);
            this.lblPrecio.TabIndex = 7;
            this.lblPrecio.Text = "0";
            // 
            // pnlPrecio
            // 
            this.pnlPrecio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlPrecio.BackColor = System.Drawing.Color.Black;
            this.pnlPrecio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPrecio.Controls.Add(this.lblPrecio);
            this.pnlPrecio.Location = new System.Drawing.Point(455, 219);
            this.pnlPrecio.Name = "pnlPrecio";
            this.pnlPrecio.Size = new System.Drawing.Size(200, 100);
            this.pnlPrecio.TabIndex = 8;
            // 
            // btnAtrás
            // 
            this.btnAtrás.BackgroundImage = global::TPV.Properties.Resources.atras;
            this.btnAtrás.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAtrás.Location = new System.Drawing.Point(27, 65);
            this.btnAtrás.Name = "btnAtrás";
            this.btnAtrás.Size = new System.Drawing.Size(111, 93);
            this.btnAtrás.TabIndex = 9;
            this.btnAtrás.UseVisualStyleBackColor = true;
            this.btnAtrás.Click += new System.EventHandler(this.btnAtrás_Click);
            // 
            // picPerfil
            // 
            this.picPerfil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picPerfil.BackgroundImage = global::TPV.Properties.Resources.usernophoto;
            this.picPerfil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picPerfil.Location = new System.Drawing.Point(348, 17);
            this.picPerfil.Name = "picPerfil";
            this.picPerfil.Size = new System.Drawing.Size(138, 136);
            this.picPerfil.TabIndex = 4;
            this.picPerfil.TabStop = false;
            // 
            // btnCobrar
            // 
            this.btnCobrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCobrar.BackColor = System.Drawing.Color.Silver;
            this.btnCobrar.BackgroundImage = global::TPV.Properties.Resources.euro;
            this.btnCobrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCobrar.Location = new System.Drawing.Point(681, 382);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(146, 111);
            this.btnCobrar.TabIndex = 1;
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // btntarjetaefectivo
            // 
            this.btntarjetaefectivo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btntarjetaefectivo.BackColor = System.Drawing.Color.Silver;
            this.btntarjetaefectivo.BackgroundImage = global::TPV.Properties.Resources.efectivo;
            this.btntarjetaefectivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btntarjetaefectivo.Location = new System.Drawing.Point(291, 370);
            this.btntarjetaefectivo.Name = "btntarjetaefectivo";
            this.btntarjetaefectivo.Size = new System.Drawing.Size(130, 111);
            this.btntarjetaefectivo.TabIndex = 0;
            this.btntarjetaefectivo.UseVisualStyleBackColor = false;
            this.btntarjetaefectivo.Click += new System.EventHandler(this.btntarjetaefectivo_Click);
            // 
            // Cobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(1049, 579);
            this.ControlBox = false;
            this.Controls.Add(this.btnAtrás);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.picPerfil);
            this.Controls.Add(this.lblefectivotarjeta);
            this.Controls.Add(this.lblCobrar);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.btntarjetaefectivo);
            this.Controls.Add(this.pnlPrecio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1071, 635);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1071, 635);
            this.Name = "Cobrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobrar";
            this.pnlPrecio.ResumeLayout(false);
            this.pnlPrecio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPerfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btntarjetaefectivo;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Label lblCobrar;
        private System.Windows.Forms.Label lblefectivotarjeta;
        private System.Windows.Forms.PictureBox picPerfil;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Panel pnlPrecio;
        private System.Windows.Forms.Button btnAtrás;
    }
}