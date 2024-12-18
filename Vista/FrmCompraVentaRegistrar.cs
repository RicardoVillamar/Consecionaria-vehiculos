﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control;

namespace Vista
{
    public partial class FrmCompraVentaRegistrar : Form
    {
        ControlCompraVenta ctrlCV = new ControlCompraVenta();
        public FrmCompraVentaRegistrar()
        {
            InitializeComponent();
        }

        // Método para registrar una compra o venta
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string msj = ctrlCV.Registrar(
                TablaDetalle,
                "1234567891",
                cmbTipo.Text,
                dtmFecha.Text
            );
            MessageBox.Show(msj);
            this.LimpiarFormulario();
        }

        // Método para limpiar el formulario
        private void LimpiarFormulario()
        {
            txtCedula.Text = "";
            cmbTipo.ResetText();
            TablaDetalle.Rows.Clear();
        }

        // Método para manejar el evento KeyPress del campo txtCedula
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            char n = e.KeyChar;

            if (!char.IsDigit(n) && n != ' ' && n != (char)Keys.Back)
                e.Handled = true;
        }
    }

}
