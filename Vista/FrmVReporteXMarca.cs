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
    public partial class FrmVReporteXMarca : Form
    {
        ControlVehiculo Ctrlvh = new ControlVehiculo();
        string marcaBuscada;
        public FrmVReporteXMarca()
        {
            InitializeComponent();
            dgvReporteVehiculo.Columns["colIdVehiculo"].Visible = false;
            Ctrlvh.LlenarReporte(dgvReporteVehiculo);
        }

        private void txtMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                marcaBuscada = txtMarca.Text.Trim().ToUpper();
                Ctrlvh.LlenarPorMarca(dgvReporteVehiculo, marcaBuscada);
                txtMarca.Clear();
            }
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            Ctrlvh.GenerarPDFMarca(marcaBuscada);
            Ctrlvh.AbrirPDFMarca();
        }
    }
}
