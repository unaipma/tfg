namespace TPV.Views.Mostrar
{
    partial class MostrarFacturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MostrarFacturas));
            this.btnVerfactura = new System.Windows.Forms.Button();
            this.btnEliminarFactura = new System.Windows.Forms.Button();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.datePick = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnInforme = new System.Windows.Forms.Button();
            this.btnglobal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVerfactura
            // 
            this.btnVerfactura.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVerfactura.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerfactura.Location = new System.Drawing.Point(797, 95);
            this.btnVerfactura.Name = "btnVerfactura";
            this.btnVerfactura.Size = new System.Drawing.Size(148, 66);
            this.btnVerfactura.TabIndex = 0;
            this.btnVerfactura.Text = "Ver factura";
            this.btnVerfactura.UseVisualStyleBackColor = true;
            this.btnVerfactura.Click += new System.EventHandler(this.btnVerfactura_Click);
            // 
            // btnEliminarFactura
            // 
            this.btnEliminarFactura.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEliminarFactura.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarFactura.Location = new System.Drawing.Point(797, 200);
            this.btnEliminarFactura.Name = "btnEliminarFactura";
            this.btnEliminarFactura.Size = new System.Drawing.Size(148, 64);
            this.btnEliminarFactura.TabIndex = 1;
            this.btnEliminarFactura.Text = "Eliminar factura";
            this.btnEliminarFactura.UseVisualStyleBackColor = true;
            this.btnEliminarFactura.Click += new System.EventHandler(this.btnEliminarFactura_Click);
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Location = new System.Drawing.Point(12, 95);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.RowHeadersWidth = 62;
            this.dgvFacturas.RowTemplate.Height = 28;
            this.dgvFacturas.Size = new System.Drawing.Size(779, 379);
            this.dgvFacturas.TabIndex = 2;
            // 
            // datePick
            // 
            this.datePick.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.datePick.Location = new System.Drawing.Point(42, 57);
            this.datePick.Name = "datePick";
            this.datePick.Size = new System.Drawing.Size(200, 26);
            this.datePick.TabIndex = 4;
            this.datePick.Value = new System.DateTime(2025, 4, 23, 10, 33, 55, 0);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.BackgroundImage = global::TPV.Properties.Resources.lupa;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.Location = new System.Drawing.Point(268, 37);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(59, 46);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAtras.BackgroundImage = global::TPV.Properties.Resources.atras;
            this.btnAtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAtras.Location = new System.Drawing.Point(12, 480);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(69, 65);
            this.btnAtras.TabIndex = 3;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Filtrar por fecha:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLimpiar.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(345, 40);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(133, 41);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Quitar filtros";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnInforme
            // 
            this.btnInforme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInforme.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInforme.Location = new System.Drawing.Point(797, 296);
            this.btnInforme.Name = "btnInforme";
            this.btnInforme.Size = new System.Drawing.Size(148, 71);
            this.btnInforme.TabIndex = 8;
            this.btnInforme.Text = "Obtener informe mensual";
            this.btnInforme.UseVisualStyleBackColor = true;
            this.btnInforme.Click += new System.EventHandler(this.btnInforme_Click);
            // 
            // btnglobal
            // 
            this.btnglobal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnglobal.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnglobal.Location = new System.Drawing.Point(797, 403);
            this.btnglobal.Name = "btnglobal";
            this.btnglobal.Size = new System.Drawing.Size(148, 71);
            this.btnglobal.TabIndex = 9;
            this.btnglobal.Text = "Obtener informe global";
            this.btnglobal.UseVisualStyleBackColor = true;
            this.btnglobal.Click += new System.EventHandler(this.btnglobal_Click);
            // 
            // MostrarFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(981, 572);
            this.ControlBox = false;
            this.Controls.Add(this.btnglobal);
            this.Controls.Add(this.btnInforme);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.datePick);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.dgvFacturas);
            this.Controls.Add(this.btnEliminarFactura);
            this.Controls.Add(this.btnVerfactura);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1003, 594);
            this.Name = "MostrarFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerfactura;
        private System.Windows.Forms.Button btnEliminarFactura;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.DateTimePicker datePick;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnInforme;
        private System.Windows.Forms.Button btnglobal;
    }
}