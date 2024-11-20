using Control;
using iTextSharp.text.pdf.security;
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
    public partial class FrmCliReporteXNombre : Form
    {
        CtrlCliente client = new CtrlCliente();
        string Nombre;

        public FrmCliReporteXNombre()
        {
            InitializeComponent();
            client.LlenarGrid(dgvClienteReporte);
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Nombre = txtNombre.Text.Trim().ToUpper();
                client.LlenarReportePorNombre(dgvClienteReporte, Nombre);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            client.LlenarGrid(dgvClienteReporte);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            client.GenerarPDFNombre(Nombre);
            client.AbrirPDFNombre();
        }
    }
}
