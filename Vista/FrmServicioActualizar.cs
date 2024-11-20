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
    public partial class FrmServicioActualizar : Form
    {
        CtrlServicios ctrlser = new CtrlServicios();
        private string idServi;
        public FrmServicioActualizar()
        {
            InitializeComponent();

        }

        private void cmbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServicio.SelectedIndex != -1)
            {
                switch (cmbServicio.SelectedIndex)
                {
                    case 0:
                        txtCosto.Text = "150,00";
                        break;
                    case 1:
                        txtCosto.Text = "75,00";
                        break;
                    default:
                        txtCosto.Clear();
                        break;
                }
            }
            else
            {
                txtCosto.Clear();
            }
        }

        public void SetDatos(string idServ, string tipodeVehiculo, string servicio, DateTime fecha, float costo)
        {
            idServi = idServ;
            cmbServicio.SelectedItem = servicio;
            cmbTipodeVehiculo.SelectedItem = tipodeVehiculo;
            dtpFecha.Value = fecha;
            txtCosto.Text = costo.ToString();
        }

        public (string, string, string, DateTime, float) GetDatosActualizados()
        {
            return (
                idServi,
                cmbTipodeVehiculo.SelectedItem.ToString(),
                cmbServicio.SelectedItem.ToString(),
                dtpFecha.Value,
                float.Parse(txtCosto.Text)
            );
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string servicios = cmbServicio.SelectedItem.ToString();
            string tipoVehiculo = cmbTipodeVehiculo.SelectedItem.ToString();
            DateTime fecha = dtpFecha.Value;
            float costo = float.Parse(txtCosto.Text);

            ctrlser.ModificarServicio(idServi, tipoVehiculo, servicios, fecha, costo);

            MessageBox.Show("Se ha modificado exitosamente");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}


