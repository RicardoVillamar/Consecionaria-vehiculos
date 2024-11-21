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
    public partial class FrmClienteRegistrar : Form
    {
        public FrmClienteRegistrar()
        {
            InitializeComponent();
        }

        // Evento para validar la entrada de texto en el campo Nombre
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;
            if (!char.IsLetter(letra) && letra != ' ' && letra != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        // Evento para validar la entrada de texto en el campo Cedula
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            char Num = e.KeyChar;
            if (!char.IsDigit(Num) && Num != ' ' && Num != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        // Evento para validar la entrada de texto en el campo Apellido
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;
            if (!char.IsLetter(letra) && letra != ' ' && letra != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        // Evento para validar la entrada de texto en el campo Telefono
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            char Num = e.KeyChar;
            if (!char.IsDigit(Num) && Num != ' ' && Num != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        // Evento para registrar un nuevo cliente
        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            ControlCliente client = new ControlCliente();
            string Nombrecliente = txtNombre.Text;
            string Apellidocliente = txtApellido.Text;
            string Cedulacliente = txtCedula.Text;
            string Telefonocliente = txtTelefono.Text;
            string Correocliente = txtCorreo.Text;
            string idCliente = client.generarId();
            if (Cedulacliente != null)
            {
                client.RegistrarCliente(idCliente, Nombrecliente, Apellidocliente, Cedulacliente, Telefonocliente, Correocliente);
                MessageBox.Show("Se ha registrado correctamente");
                this.Close();

            }
        }

        // Evento para limitar la longitud del texto en el campo Cedula
        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            if (txtCedula.Text.Length > 10)
            {
                txtCedula.Text = txtCedula.Text.Substring(0, 10);
                txtCedula.SelectionStart = txtCedula.Text.Length;
            }
        }

        // Evento para limitar la longitud del texto en el campo Telefono
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (txtTelefono.Text.Length > 10)
            {
                txtTelefono.Text = txtTelefono.Text.Substring(0, 10);
                txtTelefono.SelectionStart = txtTelefono.Text.Length;
            }
        }

        // Evento que se ejecuta al cargar el formulario
        private void FrmClienteRegistrar_Load(object sender, EventArgs e)
        {

        }
    }
}
