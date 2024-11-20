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
    public partial class FrmCliReporteXCedula : Form
    {
        CtrlCliente client = new CtrlCliente();
        string Cedula;
        public FrmCliReporteXCedula()
        {
            InitializeComponent();
            client.LlenarGrid(dgvClienteReporte);
        }

        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cedula = txtCedula.Text.Trim().ToUpper();
                client.LlenarReportePorCedula(dgvClienteReporte, Cedula);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            client.LlenarGrid(dgvClienteReporte);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            client.GenerarPDFCedula(Cedula);
            client.AbrirPDFCedula();
        }
    }
}
