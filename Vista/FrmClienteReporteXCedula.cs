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
    public partial class FrmClienteReporteXCedula : Form
    {
        ControlCliente client = new ControlCliente();
        string Cedula;

        // Constructor del formulario
        public FrmClienteReporteXCedula()
        {
            InitializeComponent();
            client.LlenarGrid(dgvClienteReporte);
        }

        // Evento KeyDown para el campo de texto de cédula
        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cedula = txtCedula.Text.Trim().ToUpper();
                client.LlenarReportePorCedula(dgvClienteReporte, Cedula);
            }
        }

        // Evento Click para el botón de refrescar
        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            client.LlenarGrid(dgvClienteReporte);
        }

        // Evento Click para el botón de generar PDF
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            client.GenerarPDFCedula(Cedula);
            client.AbrirPDFCedula();
        }
    }
}
