using Control;
using iTextSharp.text.pdf;
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
    public partial class FrmClienteReporte : Form
    {
        CtrlCliente client = new CtrlCliente();
        public FrmClienteReporte()
        {
            InitializeComponent();
            client.LlenarGrid(dgvClienteReporte);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvClienteReporte.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvClienteReporte.SelectedRows[0];
                string id = filaSeleccionada.Cells["colIdCliente"].Value.ToString();
                string telefono = filaSeleccionada.Cells["colTelefono"].Value.ToString();
                string correo = filaSeleccionada.Cells["colCorreo"].Value.ToString();

                FrmClienteActualizar frmClienteAct = new FrmClienteActualizar();
                frmClienteAct.SetDatos(id, telefono, correo);

                if (frmClienteAct.ShowDialog() == DialogResult.OK)
                {
                    // Datos actualizados pero no actualizar el DataGridView aquí
                    // Se actualizará cuando se presione el botón de Refrescar
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para modificar");
            }
        }

        private void ActualizarFila(string nombre)
        {
            foreach (DataGridViewRow fila in dgvClienteReporte.Rows)
            {
                if (fila.Cells["colNombre"].Value.ToString() == nombre)
                {
                    client.ActualizarFilaEnGrid(fila, nombre);
                    break;
                }
            }
        }


        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            if (dgvClienteReporte.SelectedRows.Count > 0)
            {
                
                int dex  = dgvClienteReporte.SelectedRows[0].Index;
                string ID = dgvClienteReporte.Rows[dex].Cells["colIdCliente"].Value.ToString();
                string mensaje = client.BajarCliente(ID);

                if (mensaje.Contains("correctamente"))
                {
                    dgvClienteReporte.Rows.RemoveAt(dex);
                    MessageBox.Show(mensaje);
                }
                else
                {
                    MessageBox.Show("Error al dar de baja a cliente");
                }
            }
            else
            {
                MessageBox.Show("seleccione fila a dar de baja");
            }
            
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            client.LlenarGrid(dgvClienteReporte);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            client.GenerarPDF();
            client.AbrirPDF();
        }
    }
}
