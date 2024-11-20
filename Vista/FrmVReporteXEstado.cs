using Control;
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
    //Elaborado por el estudiante: Villamar Minuche Ricardo Daniel
    public partial class FrmVReporteXEstado : Form
    {
        ControlVehiculo Ctrlvh = new ControlVehiculo();
        string estadoSeleccionado;
        public FrmVReporteXEstado()
        {
            InitializeComponent();
            dgvReporteVehiculo.Columns["colIdVehiculo"].Visible = false;
            Ctrlvh.LlenarReporte(dgvReporteVehiculo);
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            estadoSeleccionado = cmbFiltro.SelectedItem.ToString();
            Ctrlvh.LlenarPorEstado(dgvReporteVehiculo, estadoSeleccionado);
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            Ctrlvh.GenerarPDFEstado(estadoSeleccionado);
            Ctrlvh.AbrirPDFEstado();
        }
    }
}
