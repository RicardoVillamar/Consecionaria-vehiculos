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

    public partial class FrmVehiculoReporteMarca : Form
    {
        ControlVehiculo Ctrlvh = new ControlVehiculo();
        string marcaBuscada;

        // Constructor del formulario
        public FrmVehiculoReporteMarca()
        {
            InitializeComponent();
            dgvReporteVehiculo.Columns["colIdVehiculo"].Visible = false;
            Ctrlvh.LlenarReporte(dgvReporteVehiculo);
        }

        // Evento KeyDown para el TextBox de marca
        private void txtMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                marcaBuscada = txtMarca.Text.Trim().ToUpper();
                Ctrlvh.LlenarPorMarca(dgvReporteVehiculo, marcaBuscada);
                txtMarca.Clear();
            }
        }

        // Evento Click para el botón de generar PDF
        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            Ctrlvh.GenerarPDFMarca(marcaBuscada);
            Ctrlvh.AbrirPDFMarca();
        }
    }
}
