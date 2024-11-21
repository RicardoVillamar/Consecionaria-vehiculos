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
    public partial class FrmServicioReporte : Form
    {
        ControlServicios ctrlser = new ControlServicios();
        public FrmServicioReporte()
        {
            InitializeComponent();
            ctrlser.LlenarGrid(dgvServicios);
        }

        // Método para actualizar el DataGridView
        public void ActualizarDataGridView()
        {
            ctrlser.LlenarGrid(dgvServicios);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvServicios.SelectedRows[0];
                string idserv = filaSeleccionada.Cells["colidServicio"].Value.ToString();
                string tipodeVehiculo = filaSeleccionada.Cells["colTipodeVehiculo"].Value.ToString();
                string servicio = filaSeleccionada.Cells["colServicio"].Value.ToString();
                DateTime fecha = Convert.ToDateTime(filaSeleccionada.Cells["colFecha"].Value);
                float costo = float.Parse(filaSeleccionada.Cells["colCosto"].Value.ToString());

                FrmServicioActualizar formActualizar = new FrmServicioActualizar();
                formActualizar.SetDatos(idserv, tipodeVehiculo, servicio, fecha, costo);

                if (formActualizar.ShowDialog() == DialogResult.OK)
                {
                    ActualizarFila(idserv);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para modificar");
            }
        }

        // Método para actualizar una fila específica en el DataGridView
        private void ActualizarFila(string idserv)
        {
            foreach (DataGridViewRow fila in dgvServicios.Rows)
            {
                if (fila.Cells["colidServicio"].Value.ToString() == idserv)
                {
                    ctrlser.ActualizarFilaEnGrid(fila, idserv);
                    break;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count > 0)
            {
                int rowIndex = dgvServicios.SelectedRows[0].Index;
                string idServ = dgvServicios.Rows[rowIndex].Cells["colidServicio"].Value.ToString();
                string msj = ctrlser.EliminarServicio(idServ);

                if (msj.Contains("correctamente"))
                {
                    dgvServicios.Rows.RemoveAt(rowIndex);
                    MessageBox.Show(msj);
                }
                else
                {
                    MessageBox.Show(msj);
                }

            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
            ctrlser.LlenarGrid(dgvServicios);
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            ctrlser.GenerarPDF();
            ctrlser.AbrirPDF();
        }
    }

}
