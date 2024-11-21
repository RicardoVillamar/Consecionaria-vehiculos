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
    public partial class FrmServicioReporteCedula : Form
    {
        ControlServicios ctrlser = new ControlServicios();
        string cedula;

        // Constructor del formulario
        public FrmServicioReporteCedula()
        {
            InitializeComponent();
            ctrlser.LlenarGrid(dgvServicios);
        }

        // Evento para manejar la entrada de teclas en el campo de texto de cédula
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

        // Evento para manejar la acción al presionar una tecla en el campo de texto de cédula
        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cedula = txtCedula.Text.Trim();
                ctrlser.LlenarCedula(dgvServicios, cedula);
                txtCedula.Clear();
            }
        }

        // Evento para manejar la acción al hacer clic en el botón de generar PDF
        private void btnPdf_Click(object sender, EventArgs e)
        {
            ctrlser.GenerarPDFCed(cedula);
            ctrlser.AbrirPDFCed();
        }
    }
}
