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
    public partial class FrmSReporteXServicio : Form
    {
        // Modulo de Servicio elaborado por: Quiñonez Castrellon Anthony Joel

        ControlServicios ctrlser = new ControlServicios();
        string servicios;
        public FrmSReporteXServicio()
        {
            InitializeComponent();
            ctrlser.LlenarGrid(dgvServicios);
        }
        private void cmbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            servicios = cmbServicio.SelectedItem.ToString();
            ctrlser.LlenarFilServ(dgvServicios, servicios);
        }
        private void btnPdf_Click(object sender, EventArgs e)
        {
            ctrlser.GenerarPDFServ(servicios);
            ctrlser.AbrirPDFServ();
        }
    }
}
