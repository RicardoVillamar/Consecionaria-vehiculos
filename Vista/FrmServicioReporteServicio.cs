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
    public partial class FrmServicioReporteServicio : Form
    {
        ControlServicios ctrlser = new ControlServicios();
        string servicios;

        // Constructor del formulario
        public FrmServicioReporteServicio()
        {
            InitializeComponent();
            ctrlser.LlenarGrid(dgvServicios);
        }

        // Evento al cambiar la selección del combo box
        private void cmbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            servicios = cmbServicio.SelectedItem.ToString();
            ctrlser.LlenarFilServ(dgvServicios, servicios);
        }

        // Evento al hacer clic en el botón para generar PDF
        private void btnPdf_Click(object sender, EventArgs e)
        {
            ctrlser.GenerarPDFServ(servicios);
            ctrlser.AbrirPDFServ();
        }
    }
}
