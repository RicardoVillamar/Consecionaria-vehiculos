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

    public partial class FrmVehiculoReporteEstado : Form
    {
        ControlVehiculo Ctrlvh = new ControlVehiculo();
        string estadoSeleccionado;

        // Constructor del formulario
        public FrmVehiculoReporteEstado()
        {
            InitializeComponent();
            dgvReporteVehiculo.Columns["colIdVehiculo"].Visible = false;
            Ctrlvh.LlenarReporte(dgvReporteVehiculo);
        }

        // Evento que se ejecuta al cambiar la selección del combo box
        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            estadoSeleccionado = cmbFiltro.SelectedItem.ToString();
            Ctrlvh.LlenarPorEstado(dgvReporteVehiculo, estadoSeleccionado);
        }

        // Evento que se ejecuta al hacer clic en el botón para generar PDF
        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            Ctrlvh.GenerarPDFEstado(estadoSeleccionado);
            Ctrlvh.AbrirPDFEstado();
        }
    }
}
