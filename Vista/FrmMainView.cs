using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmMainView : Form
    {
        public FrmMainView()
        {
            InitializeComponent();
        }

        // Abre el formulario para registrar un cliente
        private void registrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClienteRegistrar rgtCliente = new FrmClienteRegistrar();
            rgtCliente.ShowDialog();
        }

        // Abre el formulario para registrar un vehículo
        private void registroVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVehiculoRegistrar rgtVehiculo = new FrmVehiculoRegistrar();
            rgtVehiculo.ShowDialog();
        }

        // Abre el formulario para registrar un servicio
        private void registrarServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmServicioRegistrar rgtServicio = new FrmServicioRegistrar();
            rgtServicio.ShowDialog();
        }

        // Cierra la aplicación
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Abre el formulario para registrar una compra/venta
        private void registrarCompraVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompraVentaRegistrar rgtCompraVenta = new FrmCompraVentaRegistrar();
            rgtCompraVenta.ShowDialog();
        }

        // Abre el formulario para generar un reporte de clientes
        private void reporteClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClienteReporte frmClienteReporte = new FrmClienteReporte();
            frmClienteReporte.ShowDialog();
        }

        // Abre el formulario para generar un reporte de vehículos
        private void reporteVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVehiculoReporte frmVehiculoReporte = new FrmVehiculoReporte();
            frmVehiculoReporte.ShowDialog();
        }

        // Abre el formulario para generar un reporte de servicios
        private void reporteServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmServicioReporte frmServicioReporte = new FrmServicioReporte();
            frmServicioReporte.ShowDialog();
        }

        // Abre el formulario para generar un reporte de compra/venta
        private void reporteCompraVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompraVentaReporte frmCompraVentaReporte = new FrmCompraVentaReporte();
            frmCompraVentaReporte.ShowDialog();
        }

        // Abre el formulario para generar un reporte de vehículos por estado
        private void reporteVehiculoPorEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVehiculoReporteEstado frmVehiculoEstado = new FrmVehiculoReporteEstado();
            frmVehiculoEstado.ShowDialog();
        }

        // Abre el formulario para generar un reporte de vehículos por marca
        private void reporteVehiculoPorMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVehiculoReporteMarca frmVehiculoMarca = new FrmVehiculoReporteMarca();
            frmVehiculoMarca.ShowDialog();
        }

        // Abre el formulario para generar un reporte de servicios por cédula
        private void reporteServicioPorCedulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmServicioReporteCedula rgtCedBus = new FrmServicioReporteCedula();
            rgtCedBus.ShowDialog();
        }

        // Abre el formulario para generar un reporte de servicios por tipo de servicio
        private void reporeteServiciosPorServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmServicioReporteServicio rgtServBus = new FrmServicioReporteServicio();
            rgtServBus.ShowDialog();
        }

        // Abre el formulario para generar un reporte de clientes por cédula
        private void reporteClientesPorCedulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FrmClienteReporteXCedula frmCedula = new FrmClienteReporteXCedula();
            frmCedula.ShowDialog();
        }

        // Abre el formulario para generar un reporte de clientes por nombre
        private void reporteClientesPorNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClienteReporteXNombre frmNombre = new FrmClienteReporteXNombre();
            frmNombre.ShowDialog();
        }
    }
}
