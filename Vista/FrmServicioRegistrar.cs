﻿using Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vista
{
    public partial class FrmServicioRegistrar : Form
    {
        public FrmServicioRegistrar()
        {
            InitializeComponent();
            txtDescripcion.ReadOnly = true;
            txtCosto.ReadOnly = true;
            txtDescripcion.Enabled = false;
            txtCosto.Enabled = false;
        }

        private void cmbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServicio.SelectedIndex != -1)
            {
                switch (cmbServicio.SelectedIndex)
                {
                    case 0:
                        txtDescripcion.Text = "Se trabajara en la corrección de cualquier daño mecánico o electrónico en el vehículo, " +
                            "incluyendo reparaciones de motor, transmisión, sistema eléctrico, frenos, suspensión, entre otros. " +
                            "La reparación puede ser tanto de daños menores como de problemas más complejos que requieren un diagnóstico detallado y la intervención de técnicos especializados.";
                        txtCosto.Text = "150,00";
                        break;
                    case 1:
                        txtDescripcion.Text = "Se realizara una la limpieza profunda y detallada tanto del interior como del exterior del vehículo. " +
                            "Incluye la eliminación de suciedad, polvo, manchas, y olores desagradables, así como el pulido y encerado de la carrocería para devolverle su brillo original.";
                        txtCosto.Text = "75,00";
                        break;
                    default:
                        txtDescripcion.Clear();
                        txtCosto.Clear();
                        break;
                }
            }
            else
            {
                txtDescripcion.Clear();
                txtCosto.Clear();
            }

        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ced = e.KeyChar;
            if (!char.IsDigit(ced) && ced != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            if (txtCedula.Text.Length > 10)
            {
                txtCedula.Text = txtCedula.Text.Substring(0, 10);
                txtCedula.SelectionStart = txtCedula.Text.Length;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CtrlServicios ser = new CtrlServicios();
            string servicios = cmbServicio.SelectedItem.ToString();
            string tipoVehiculo = cmbTipoVehiculo.SelectedItem.ToString();
            string cedula = txtCedula.Text;
            DateTime fecha = dtpFecha.Value;
            string descripServicio = txtDescripcion.Text;
            float costo = float.Parse(txtCosto.Text);
            string id = ser.generarId();

            if (string.IsNullOrWhiteSpace(cedula))
            {
                MessageBox.Show("Por favor, ingrese la cédula del cliente.");
                return;
            }
            if (cedula != null)
            {
                ser.RegistrarServicio(id, tipoVehiculo, cedula, servicios, fecha, descripServicio, costo);
                MessageBox.Show("Se ha registrado exitosamente");
                this.Close();

            }

        }

    }
}
