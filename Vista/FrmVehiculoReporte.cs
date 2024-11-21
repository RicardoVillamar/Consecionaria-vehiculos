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

    public partial class FrmVehiculoReporte : Form
    {
        ControlVehiculo Ctrlvh = new ControlVehiculo();

        public FrmVehiculoReporte()
        {
            InitializeComponent();
            dgvReporteVehiculo.Columns["colIdVehiculo"].Visible = false;
            Ctrlvh.LlenarReporte(dgvReporteVehiculo);
        }

        // Método para retirar un vehículo
        private void btnRetirar_Click(object sender, EventArgs e)
        {
            if (dgvReporteVehiculo.SelectedRows.Count > 0)
            {
                int rowIndex = dgvReporteVehiculo.SelectedRows[0].Index;
                string id = dgvReporteVehiculo.Rows[rowIndex].Cells["colIdVehiculo"].Value.ToString();
                string msj = Ctrlvh.EliminarVh(id);

                if (msj.Contains("correctamente"))
                {
                    dgvReporteVehiculo.Rows.RemoveAt(rowIndex);
                    MessageBox.Show("Vehiculo Retirado Correctamente");
                }
                else
                {
                    MessageBox.Show("El Vehiculo No Se Retirado");
                }

            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
            Ctrlvh.LlenarReporte(dgvReporteVehiculo);

        }

        // Método para actualizar un vehículo
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvReporteVehiculo.SelectedRows.Count > 0)
            {
                DataGridViewRow rowS = dgvReporteVehiculo.SelectedRows[0];
                string id = rowS.Cells["colIdVehiculo"].Value.ToString();
                string color = rowS.Cells["colColor"].Value.ToString();
                string tipo = rowS.Cells["colTipoCombustible"].Value.ToString();
                FrmVehiculoActualizar frmAV = new FrmVehiculoActualizar();
                frmAV.SetDatos(id, color, tipo);
                if (frmAV.ShowDialog() == DialogResult.OK)
                {
                    ActualizarFila(id);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        // Método para actualizar una fila en el DataGridView
        private void ActualizarFila(string id)
        {
            foreach (DataGridViewRow fila in dgvReporteVehiculo.Rows)
            {
                if (fila.Cells[0].Value.ToString() == id)
                {
                    Ctrlvh.ActualizarFilaEnGrid(fila, id);
                    break;
                }
            }
        }

        // Método para generar y abrir un PDF
        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            Ctrlvh.GenerarPDF();
            Ctrlvh.AbrirPDF();
        }
    }
}
