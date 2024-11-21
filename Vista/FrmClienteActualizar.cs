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
    public partial class FrmClienteActualizar : Form
    {
        ControlCliente ctrlcliente = new ControlCliente();
        private string id;

        public FrmClienteActualizar()
        {
            InitializeComponent();
        }

        // Establece los datos del cliente en los campos de texto
        public void SetDatos(string idn, string telefono, string correo)
        {
            id = idn;
            txtTelefono.Text = telefono.ToString();
            txtCorreo.Text = correo.ToString();
        }

        // Obtiene los datos actualizados del cliente
        public (string, string, string) GetDatosActualizados()
        {
            return (
                id,
                txtTelefono.Text,
                txtCorreo.Text
            );
        }

        // Maneja el evento de clic del botón Aceptar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string telefono = txtTelefono.Text;
            string correo = txtCorreo.Text;

            ctrlcliente.ActulizarCliente(id, telefono, correo);
            MessageBox.Show("Se ha actualizado correctamente");
            this.DialogResult = DialogResult.OK;
            this.Close(); ;
        }

        // Limita la longitud del texto en el campo de teléfono
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (txtTelefono.Text.Length > 10)
            {
                txtTelefono.Text = txtTelefono.Text.Substring(0, 10);
                txtTelefono.SelectionStart = txtTelefono.Text.Length;
            }
        }
    }
}
