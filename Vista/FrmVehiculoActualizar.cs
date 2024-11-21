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

    public partial class FrmVehiculoActualizar : Form
    {
        ControlVehiculo ctVh = new ControlVehiculo();
        private string idInicial;

        public FrmVehiculoActualizar()
        {
            InitializeComponent();
        }

        // Establece los datos iniciales del vehículo
        public void SetDatos(string idc, string color, string tipo)
        {
            idInicial = idc;
            txtColor.Text = color.ToString();
            txtTipoC.Text = tipo.ToString();
        }

        // Obtiene los datos actualizados del vehículo
        public (string, string, string) GetDatosActualizados()
        {
            return (
                idInicial,
                txtColor.Text,
                txtTipoC.Text
            );
        }

        // Maneja el evento de clic del botón Aceptar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string color = txtColor.Text;
            string tipo = txtTipoC.Text;

            ctVh.ActualizarVehiculo(idInicial, color, tipo);
            this.DialogResult = DialogResult.OK;
            this.Close(); ;
        }
    }
}
