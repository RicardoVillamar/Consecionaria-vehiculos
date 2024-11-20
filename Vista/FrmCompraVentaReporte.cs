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
    public partial class FrmCompraVentaReporte : Form
    {
        CtrlCompraVenta controlador = new CtrlCompraVenta();
        public FrmCompraVentaReporte()
        {
            InitializeComponent();
        }

        private void Reporte_Click(object sender, EventArgs e)
        {
            if (TablaReporteCompraVenta.Rows.Count == 0)
            {
                MessageBox.Show("Se debe filtrar los registros.");
                return;
            }

            controlador.GenerarPDF(TablaReporteCompraVenta);
            controlador.AbrirPDF();
        }

        private void btnFiltrarReporte_Click(object sender, EventArgs e)
        {
            string mensaje = controlador.Reporte(
                TablaReporteCompraVenta,
                cmbTipo.Text,
                campoCedula.Text
            );

            if (mensaje[0] == '0')
                this.LimpiarCampos();

            MessageBox.Show(mensaje);
        }

        private void TablaReporte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 5 && e.RowIndex != -1)
            {
                string cedula = TablaReporteCompraVenta.Rows[e.RowIndex].Cells["Cedula"].Value.ToString();
                DialogResult msj = MessageBox.Show("¿Deseas eliminar las ventas del cliente?", "Confirmación", MessageBoxButtons.OKCancel);

                if (msj == DialogResult.OK)
                {
                    controlador.Eliminar(cedula);
                    TablaReporteCompraVenta.Rows.Clear();    
                }
            }

        }

        private void LimpiarCampos()
        {
            cmbTipo.ResetText();
            campoCedula.Text = "";
            TablaReporteCompraVenta.Rows.Clear();
        }
        private void campoCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (!char.IsDigit(c) && c != ' ' && c != (char)Keys.Back)
                e.Handled = true;
        }
    }
}
