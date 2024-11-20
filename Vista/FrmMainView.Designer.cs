namespace Vista
{
    partial class FrmMainView
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainView));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteClientesPorCedulaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteClientesPorNombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehiculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteVehiculoPorEstadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteVehiculoPorMarcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarServicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteServicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteServicioPorCedulaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporeteServiciosPorServiciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compraVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarCompraVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteCompraVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.vehiculosToolStripMenuItem,
            this.serviciosToolStripMenuItem,
            this.compraVentaToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(993, 31);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarClienteToolStripMenuItem,
            this.reporteClientesToolStripMenuItem,
            this.reporteClientesPorCedulaToolStripMenuItem,
            this.reporteClientesPorNombreToolStripMenuItem});
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(93, 29);
            this.clienteToolStripMenuItem.Text = "Clientes";
            // 
            // registrarClienteToolStripMenuItem
            // 
            this.registrarClienteToolStripMenuItem.Name = "registrarClienteToolStripMenuItem";
            this.registrarClienteToolStripMenuItem.Size = new System.Drawing.Size(343, 30);
            this.registrarClienteToolStripMenuItem.Text = "Registrar Cliente";
            this.registrarClienteToolStripMenuItem.Click += new System.EventHandler(this.registrarClienteToolStripMenuItem_Click);
            // 
            // reporteClientesToolStripMenuItem
            // 
            this.reporteClientesToolStripMenuItem.Name = "reporteClientesToolStripMenuItem";
            this.reporteClientesToolStripMenuItem.Size = new System.Drawing.Size(343, 30);
            this.reporteClientesToolStripMenuItem.Text = "Reporte Clientes";
            this.reporteClientesToolStripMenuItem.Click += new System.EventHandler(this.reporteClientesToolStripMenuItem_Click);
            // 
            // reporteClientesPorCedulaToolStripMenuItem
            // 
            this.reporteClientesPorCedulaToolStripMenuItem.Name = "reporteClientesPorCedulaToolStripMenuItem";
            this.reporteClientesPorCedulaToolStripMenuItem.Size = new System.Drawing.Size(343, 30);
            this.reporteClientesPorCedulaToolStripMenuItem.Text = "Reporte Clientes por Cedula";
            this.reporteClientesPorCedulaToolStripMenuItem.Click += new System.EventHandler(this.reporteClientesPorCedulaToolStripMenuItem_Click);
            // 
            // reporteClientesPorNombreToolStripMenuItem
            // 
            this.reporteClientesPorNombreToolStripMenuItem.Name = "reporteClientesPorNombreToolStripMenuItem";
            this.reporteClientesPorNombreToolStripMenuItem.Size = new System.Drawing.Size(343, 30);
            this.reporteClientesPorNombreToolStripMenuItem.Text = "Reporte Clientes por Nombre";
            this.reporteClientesPorNombreToolStripMenuItem.Click += new System.EventHandler(this.reporteClientesPorNombreToolStripMenuItem_Click);
            // 
            // vehiculosToolStripMenuItem
            // 
            this.vehiculosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroVehiculoToolStripMenuItem,
            this.reporteVehiculoToolStripMenuItem,
            this.reporteVehiculoPorEstadoToolStripMenuItem,
            this.reporteVehiculoPorMarcaToolStripMenuItem});
            this.vehiculosToolStripMenuItem.Name = "vehiculosToolStripMenuItem";
            this.vehiculosToolStripMenuItem.Size = new System.Drawing.Size(107, 29);
            this.vehiculosToolStripMenuItem.Text = "Vehiculos";
            // 
            // registroVehiculoToolStripMenuItem
            // 
            this.registroVehiculoToolStripMenuItem.Name = "registroVehiculoToolStripMenuItem";
            this.registroVehiculoToolStripMenuItem.Size = new System.Drawing.Size(336, 30);
            this.registroVehiculoToolStripMenuItem.Text = "Registro Vehiculo";
            this.registroVehiculoToolStripMenuItem.Click += new System.EventHandler(this.registroVehiculoToolStripMenuItem_Click);
            // 
            // reporteVehiculoToolStripMenuItem
            // 
            this.reporteVehiculoToolStripMenuItem.Name = "reporteVehiculoToolStripMenuItem";
            this.reporteVehiculoToolStripMenuItem.Size = new System.Drawing.Size(336, 30);
            this.reporteVehiculoToolStripMenuItem.Text = "Reporte Vehiculo";
            this.reporteVehiculoToolStripMenuItem.Click += new System.EventHandler(this.reporteVehiculoToolStripMenuItem_Click);
            // 
            // reporteVehiculoPorEstadoToolStripMenuItem
            // 
            this.reporteVehiculoPorEstadoToolStripMenuItem.Name = "reporteVehiculoPorEstadoToolStripMenuItem";
            this.reporteVehiculoPorEstadoToolStripMenuItem.Size = new System.Drawing.Size(336, 30);
            this.reporteVehiculoPorEstadoToolStripMenuItem.Text = "Reporte Vehiculo por Estado";
            this.reporteVehiculoPorEstadoToolStripMenuItem.Click += new System.EventHandler(this.reporteVehiculoPorEstadoToolStripMenuItem_Click);
            // 
            // reporteVehiculoPorMarcaToolStripMenuItem
            // 
            this.reporteVehiculoPorMarcaToolStripMenuItem.Name = "reporteVehiculoPorMarcaToolStripMenuItem";
            this.reporteVehiculoPorMarcaToolStripMenuItem.Size = new System.Drawing.Size(336, 30);
            this.reporteVehiculoPorMarcaToolStripMenuItem.Text = "Reporte Vehiculo por Marca";
            this.reporteVehiculoPorMarcaToolStripMenuItem.Click += new System.EventHandler(this.reporteVehiculoPorMarcaToolStripMenuItem_Click);
            // 
            // serviciosToolStripMenuItem
            // 
            this.serviciosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarServicioToolStripMenuItem,
            this.reporteServicioToolStripMenuItem,
            this.reporteServicioPorCedulaToolStripMenuItem,
            this.reporeteServiciosPorServiciosToolStripMenuItem});
            this.serviciosToolStripMenuItem.Name = "serviciosToolStripMenuItem";
            this.serviciosToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.serviciosToolStripMenuItem.Text = "Servicios";
            // 
            // registrarServicioToolStripMenuItem
            // 
            this.registrarServicioToolStripMenuItem.Name = "registrarServicioToolStripMenuItem";
            this.registrarServicioToolStripMenuItem.Size = new System.Drawing.Size(365, 30);
            this.registrarServicioToolStripMenuItem.Text = "Registrar Servicio";
            this.registrarServicioToolStripMenuItem.Click += new System.EventHandler(this.registrarServicioToolStripMenuItem_Click);
            // 
            // reporteServicioToolStripMenuItem
            // 
            this.reporteServicioToolStripMenuItem.Name = "reporteServicioToolStripMenuItem";
            this.reporteServicioToolStripMenuItem.Size = new System.Drawing.Size(365, 30);
            this.reporteServicioToolStripMenuItem.Text = "Reporte Servicio";
            this.reporteServicioToolStripMenuItem.Click += new System.EventHandler(this.reporteServicioToolStripMenuItem_Click);
            // 
            // reporteServicioPorCedulaToolStripMenuItem
            // 
            this.reporteServicioPorCedulaToolStripMenuItem.Name = "reporteServicioPorCedulaToolStripMenuItem";
            this.reporteServicioPorCedulaToolStripMenuItem.Size = new System.Drawing.Size(365, 30);
            this.reporteServicioPorCedulaToolStripMenuItem.Text = "Reporte Servicio por Cedula";
            this.reporteServicioPorCedulaToolStripMenuItem.Click += new System.EventHandler(this.reporteServicioPorCedulaToolStripMenuItem_Click);
            // 
            // reporeteServiciosPorServiciosToolStripMenuItem
            // 
            this.reporeteServiciosPorServiciosToolStripMenuItem.Name = "reporeteServiciosPorServiciosToolStripMenuItem";
            this.reporeteServiciosPorServiciosToolStripMenuItem.Size = new System.Drawing.Size(365, 30);
            this.reporeteServiciosPorServiciosToolStripMenuItem.Text = "Reporete Servicios por Servicios";
            this.reporeteServiciosPorServiciosToolStripMenuItem.Click += new System.EventHandler(this.reporeteServiciosPorServiciosToolStripMenuItem_Click);
            // 
            // compraVentaToolStripMenuItem
            // 
            this.compraVentaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarCompraVentaToolStripMenuItem,
            this.reporteCompraVentaToolStripMenuItem});
            this.compraVentaToolStripMenuItem.Name = "compraVentaToolStripMenuItem";
            this.compraVentaToolStripMenuItem.Size = new System.Drawing.Size(148, 29);
            this.compraVentaToolStripMenuItem.Text = "Compra/Venta";
            // 
            // registrarCompraVentaToolStripMenuItem
            // 
            this.registrarCompraVentaToolStripMenuItem.Name = "registrarCompraVentaToolStripMenuItem";
            this.registrarCompraVentaToolStripMenuItem.Size = new System.Drawing.Size(297, 30);
            this.registrarCompraVentaToolStripMenuItem.Text = "Registrar Compra Venta";
            this.registrarCompraVentaToolStripMenuItem.Click += new System.EventHandler(this.registrarCompraVentaToolStripMenuItem_Click);
            // 
            // reporteCompraVentaToolStripMenuItem
            // 
            this.reporteCompraVentaToolStripMenuItem.Name = "reporteCompraVentaToolStripMenuItem";
            this.reporteCompraVentaToolStripMenuItem.Size = new System.Drawing.Size(297, 30);
            this.reporteCompraVentaToolStripMenuItem.Text = "Reporte Compra Venta";
            this.reporteCompraVentaToolStripMenuItem.Click += new System.EventHandler(this.reporteCompraVentaToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(63, 29);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(272, 116);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 380);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 599);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FrmMainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Consecionaria Vehiculos";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehiculosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroVehiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteVehiculoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem serviciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarServicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteServicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compraVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarCompraVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteCompraVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteVehiculoPorEstadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteVehiculoPorMarcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteServicioPorCedulaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporeteServiciosPorServiciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteClientesPorCedulaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteClientesPorNombreToolStripMenuItem;
    }
}

