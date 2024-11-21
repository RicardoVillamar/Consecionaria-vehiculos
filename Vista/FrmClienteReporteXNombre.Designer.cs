namespace Vista
{
    partial class FrmClienteReporteXNombre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClienteReporteXNombre));
            this.label6 = new System.Windows.Forms.Label();
            this.lbNomCliente = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dgvClienteReporte = new System.Windows.Forms.DataGridView();
            this.colIdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClienteReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(228, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 29);
            this.label6.TabIndex = 13;
            this.label6.Text = "Filtro por Nombre";
            // 
            // lbNomCliente
            // 
            this.lbNomCliente.AutoSize = true;
            this.lbNomCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNomCliente.Location = new System.Drawing.Point(183, 84);
            this.lbNomCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNomCliente.Name = "lbNomCliente";
            this.lbNomCliente.Size = new System.Drawing.Size(65, 17);
            this.lbNomCliente.TabIndex = 15;
            this.lbNomCliente.Text = "Nombres";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(253, 82);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(229, 23);
            this.txtNombre.TabIndex = 16;
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            // 
            // dgvClienteReporte
            // 
            this.dgvClienteReporte.AllowUserToAddRows = false;
            this.dgvClienteReporte.AllowUserToDeleteRows = false;
            this.dgvClienteReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClienteReporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCliente,
            this.colNombre,
            this.colApellido,
            this.colCedula,
            this.colCorreo,
            this.colTelefono});
            this.dgvClienteReporte.Location = new System.Drawing.Point(29, 132);
            this.dgvClienteReporte.Name = "dgvClienteReporte";
            this.dgvClienteReporte.ReadOnly = true;
            this.dgvClienteReporte.RowHeadersWidth = 51;
            this.dgvClienteReporte.Size = new System.Drawing.Size(602, 310);
            this.dgvClienteReporte.TabIndex = 17;
            // 
            // colIdCliente
            // 
            this.colIdCliente.HeaderText = "IdCliente";
            this.colIdCliente.MinimumWidth = 6;
            this.colIdCliente.Name = "colIdCliente";
            this.colIdCliente.ReadOnly = true;
            this.colIdCliente.Width = 125;
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.MinimumWidth = 6;
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 125;
            // 
            // colApellido
            // 
            this.colApellido.HeaderText = "Apellidos";
            this.colApellido.MinimumWidth = 6;
            this.colApellido.Name = "colApellido";
            this.colApellido.ReadOnly = true;
            this.colApellido.Width = 125;
            // 
            // colCedula
            // 
            this.colCedula.HeaderText = "Cedula";
            this.colCedula.MinimumWidth = 6;
            this.colCedula.Name = "colCedula";
            this.colCedula.ReadOnly = true;
            this.colCedula.Width = 125;
            // 
            // colCorreo
            // 
            this.colCorreo.HeaderText = "Correo Electronico";
            this.colCorreo.MinimumWidth = 6;
            this.colCorreo.Name = "colCorreo";
            this.colCorreo.ReadOnly = true;
            this.colCorreo.Width = 125;
            // 
            // colTelefono
            // 
            this.colTelefono.HeaderText = "Telefono";
            this.colTelefono.MinimumWidth = 6;
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.ReadOnly = true;
            this.colTelefono.Width = 125;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(102, 474);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(146, 39);
            this.btnRefrescar.TabIndex = 20;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(352, 474);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(146, 39);
            this.btnGenerar.TabIndex = 21;
            this.btnGenerar.Text = "GenerarPdf";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // FrmCliReporteXNombre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 598);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.dgvClienteReporte);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lbNomCliente);
            this.Controls.Add(this.label6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCliReporteXNombre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmClienteNombre";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClienteReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbNomCliente;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridView dgvClienteReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnGenerar;
    }
}