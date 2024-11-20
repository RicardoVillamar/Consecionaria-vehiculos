namespace Vista
{
    partial class FrmVReporteXEstado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVReporteXEstado));
            this.btnGenerarPDF = new System.Windows.Forms.Button();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvReporteVehiculo = new System.Windows.Forms.DataGridView();
            this.colIdVehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoVehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoCombustible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteVehiculo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerarPDF
            // 
            this.btnGenerarPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarPDF.Location = new System.Drawing.Point(258, 500);
            this.btnGenerarPDF.Name = "btnGenerarPDF";
            this.btnGenerarPDF.Size = new System.Drawing.Size(153, 33);
            this.btnGenerarPDF.TabIndex = 52;
            this.btnGenerarPDF.Text = "Generar PDF";
            this.btnGenerarPDF.UseVisualStyleBackColor = true;
            this.btnGenerarPDF.Click += new System.EventHandler(this.btnGenerarPDF_Click);
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Items.AddRange(new object[] {
            "Usado",
            "NoUsado"});
            this.cmbFiltro.Location = new System.Drawing.Point(258, 92);
            this.cmbFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(179, 24);
            this.cmbFiltro.TabIndex = 48;
            this.cmbFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(209, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 47;
            this.label2.Text = "Filtro";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(231, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(208, 29);
            this.label6.TabIndex = 45;
            this.label6.Text = "Filtro por Estado";
            // 
            // dgvReporteVehiculo
            // 
            this.dgvReporteVehiculo.AllowUserToAddRows = false;
            this.dgvReporteVehiculo.AllowUserToDeleteRows = false;
            this.dgvReporteVehiculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporteVehiculo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdVehiculo,
            this.colMarca,
            this.colTipoVehiculo,
            this.colTipoCombustible,
            this.colColor,
            this.colEstado,
            this.colPrecio});
            this.dgvReporteVehiculo.Location = new System.Drawing.Point(12, 145);
            this.dgvReporteVehiculo.Name = "dgvReporteVehiculo";
            this.dgvReporteVehiculo.ReadOnly = true;
            this.dgvReporteVehiculo.RowHeadersWidth = 62;
            this.dgvReporteVehiculo.Size = new System.Drawing.Size(641, 331);
            this.dgvReporteVehiculo.TabIndex = 44;
            // 
            // colIdVehiculo
            // 
            this.colIdVehiculo.HeaderText = "Id";
            this.colIdVehiculo.MinimumWidth = 8;
            this.colIdVehiculo.Name = "colIdVehiculo";
            this.colIdVehiculo.ReadOnly = true;
            this.colIdVehiculo.Width = 150;
            // 
            // colMarca
            // 
            this.colMarca.HeaderText = "Marca";
            this.colMarca.MinimumWidth = 8;
            this.colMarca.Name = "colMarca";
            this.colMarca.ReadOnly = true;
            this.colMarca.Width = 150;
            // 
            // colTipoVehiculo
            // 
            this.colTipoVehiculo.HeaderText = "Tipo de Vehiculo";
            this.colTipoVehiculo.MinimumWidth = 8;
            this.colTipoVehiculo.Name = "colTipoVehiculo";
            this.colTipoVehiculo.ReadOnly = true;
            this.colTipoVehiculo.Width = 150;
            // 
            // colTipoCombustible
            // 
            this.colTipoCombustible.HeaderText = "Tipo de Combustible";
            this.colTipoCombustible.MinimumWidth = 8;
            this.colTipoCombustible.Name = "colTipoCombustible";
            this.colTipoCombustible.ReadOnly = true;
            this.colTipoCombustible.Width = 150;
            // 
            // colColor
            // 
            this.colColor.HeaderText = "Color";
            this.colColor.MinimumWidth = 8;
            this.colColor.Name = "colColor";
            this.colColor.ReadOnly = true;
            this.colColor.Width = 150;
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.MinimumWidth = 8;
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 150;
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.MinimumWidth = 8;
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            this.colPrecio.Width = 150;
            // 
            // FrmVReporteXEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 598);
            this.Controls.Add(this.btnGenerarPDF);
            this.Controls.Add(this.cmbFiltro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvReporteVehiculo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmVReporteXEstado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVehiculoEstado";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteVehiculo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGenerarPDF;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvReporteVehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdVehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoVehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoCombustible;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
    }
}