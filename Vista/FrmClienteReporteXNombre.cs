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
    public partial class FrmClienteReporteXNombre : Form
    {
        ControlCliente client = new ControlCliente();
        string Nombre;

        public FrmClienteReporteXNombre()
        {
            InitializeComponent();
            client.LlenarGrid(dgvClienteReporte);
        }

        // Maneja el evento KeyDown del TextBox para buscar por nombre
        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Nombre = txtNombre.Text.Trim().ToUpper();
                client.LlenarReportePorNombre(dgvClienteReporte, Nombre);
            }
        }

        // Maneja el evento Click del botón Refrescar
        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            client.LlenarGrid(dgvClienteReporte);
        }

        // Maneja el evento Click del botón Generar
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            client.GenerarPDFNombre(Nombre);
            client.AbrirPDFNombre();
        }
    }
}
