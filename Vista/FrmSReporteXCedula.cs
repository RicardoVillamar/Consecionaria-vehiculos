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
    public partial class FrmSReporteXCedula : Form
    {
        ControlServicios ctrlser = new ControlServicios();
        string cedula;
        public FrmSReporteXCedula()
        {
            InitializeComponent();
            ctrlser.LlenarGrid(dgvServicios);
        }
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (char.IsDigit(e.KeyChar) && txtCedula.Text.Length >= 10)
            {
                e.Handled = true;
            }
        }
        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cedula = txtCedula.Text.Trim();
                ctrlser.LlenarCedula(dgvServicios, cedula);
                txtCedula.Clear();
            }
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            ctrlser.GenerarPDFCed(cedula);
            ctrlser.AbrirPDFCed();
        }
    }
}
