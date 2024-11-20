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

        private void registrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClienteRegistrar rgtCliente = new FrmClienteRegistrar();
            rgtCliente.ShowDialog();
        }

        private void registroVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVehiculoRegistrar rgtVehiculo = new FrmVehiculoRegistrar();
            rgtVehiculo.ShowDialog();
        }

        private void registrarServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmServicioRegistrar rgtServicio = new FrmServicioRegistrar();
            rgtServicio.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void registrarCompraVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompraVentaRegistrar rgtCompraVenta = new FrmCompraVentaRegistrar();
            rgtCompraVenta.ShowDialog();
        }

        private void reporteClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClienteReporte frmClienteReporte = new FrmClienteReporte();
            frmClienteReporte.ShowDialog();
        }

        private void reporteVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVehiculoReporte frmVehiculoReporte = new FrmVehiculoReporte();
            frmVehiculoReporte.ShowDialog();
        }

        private void reporteServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmServicioReporte frmServicioReporte = new FrmServicioReporte();  
            frmServicioReporte.ShowDialog();
        }

        private void reporteCompraVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompraVentaReporte frmCompraVentaReporte = new FrmCompraVentaReporte();
            frmCompraVentaReporte.ShowDialog();
        }

        private void reporteVehiculoPorEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVReporteXEstado frmVehiculoEstado = new FrmVReporteXEstado();
            frmVehiculoEstado.ShowDialog();
        }

        private void reporteVehiculoPorMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVReporteXMarca frmVehiculoMarca = new FrmVReporteXMarca();
            frmVehiculoMarca.ShowDialog();
        }

        private void reporteServicioPorCedulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSReporteXCedula rgtCedBus = new FrmSReporteXCedula();
            rgtCedBus.ShowDialog();
        }

        private void reporeteServiciosPorServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSReporteXServicio rgtServBus = new FrmSReporteXServicio();
            rgtServBus.ShowDialog();
        }

        private void reporteClientesPorCedulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliReporteXCedula frmCedula = new FrmCliReporteXCedula();
            frmCedula.ShowDialog();
        }

        private void reporteClientesPorNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliReporteXNombre frmNombre = new FrmCliReporteXNombre();
            frmNombre.ShowDialog();
        }
    }
}
