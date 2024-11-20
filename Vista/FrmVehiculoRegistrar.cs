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
    //Elaborado por el estudiante: Villamar Minuche Ricardo Daniel
    public partial class FrmVehiculoRegistrar : Form
    {
        CtrlVehiculo ctrlVehiculo = new CtrlVehiculo();
        ValidarVehiculo valH = new ValidarVehiculo();
        public FrmVehiculoRegistrar()
        {
            InitializeComponent();
            gbAutomovil.Enabled = false;
            gbCamion.Enabled = false;
            gbMotocicleta.Enabled = false;
        }

        //Tipo de Vehiculo
        private void cmbTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoVehiculo =(string) cmbTipoVehiculo.Text;

            if (tipoVehiculo.Equals("Automovil"))
            {
                gbAutomovil.Enabled = true;
                gbCamion.Enabled = false;
                gbMotocicleta.Enabled = false;

            }else if (tipoVehiculo.Equals("Camion"))
            {
                gbCamion.Enabled = true;
                gbAutomovil.Enabled = false;
                gbMotocicleta.Enabled = false;   
            }
            else if (tipoVehiculo.Equals("Motocicleta"))
            {
                gbMotocicleta.Enabled = true;
                gbAutomovil.Enabled = false;
                gbCamion.Enabled = false;
            }
       
        }

        //Registrar Vehiculo
        private void btnRegistrarVehiculo_Click(object sender, EventArgs e)
        {
            //Datos Vehiculo
            string marca = txtMarca.Text;
            string color = txtColor.Text;
            string tipoVehiculo = (string)cmbTipoVehiculo.Text;
            string estado = (string)cmbEstado.Text;
            string tipoCombustible = txtCombustible.Text;
            string kilometraje = txtKilometraje.Text;
            string precio = txtPrecio.Text;
 
            string msj;

            if (tipoVehiculo.Equals("Automovil"))
            {
                //Datos Automovil
                string nPuertas = txtNPuertas.Text;
                string tipoTransmision = (string)cmbTipoTransmision.Text;
                string tipoAuto = (string)cmbTipoAuto.Text;

                string id = valH.GenerarId();
                string ida = valH.GenerarId();
                msj = ctrlVehiculo.IngresarAuto(id, marca, tipoVehiculo, tipoCombustible, color, estado, kilometraje, precio, ida, nPuertas, tipoTransmision, tipoAuto);
                MessageBox.Show("Registro Automovil Exitoso");
                ctrlVehiculo.LimpiarAuto(txtMarca, txtColor, cmbTipoVehiculo, cmbEstado, txtCombustible, txtKilometraje, txtPrecio, txtNPuertas, cmbTipoTransmision, cmbTipoAuto);
            }
            else if (tipoVehiculo.Equals("Camion"))
            {
                //Datos Camion
                string capacidadCarga = txtCapacidadCarga.Text;
                string tipoCarga = (string)cmbTipoCarga.Text;

                string id = valH.GenerarId();
                string idc = valH.GenerarId();
                msj = ctrlVehiculo.IngresarCamion(id, marca, tipoVehiculo, tipoCombustible, color, estado, kilometraje, precio, idc, capacidadCarga, tipoCarga);
                MessageBox.Show("Registro Camion Exitoso");
                ctrlVehiculo.LimpiarCamion(txtMarca, txtColor, cmbTipoVehiculo, cmbEstado, txtCombustible, txtKilometraje, txtPrecio, txtCapacidadCarga, cmbTipoCarga);

            }
            else if (tipoVehiculo.Equals("Motocicleta"))
            {
                //Datos Motocicleta
                string tipoMoto = (string)cmbTipoMoto.Text;
                string ruedas = txtNRuedas.Text;
                string tipoFreno = (string)cmbTipoFreno.Text;


                string id = valH.GenerarId();
                string idm = valH.GenerarId();
                msj = ctrlVehiculo.IngresarMoto(id, marca, tipoVehiculo, tipoCombustible, color, estado, kilometraje, precio, idm, tipoMoto, ruedas, tipoFreno);
                MessageBox.Show("Registro Motocicleta Exitoso");
                ctrlVehiculo.LimpiarMoto(txtMarca, txtColor, cmbTipoVehiculo, cmbEstado, txtCombustible, txtKilometraje, txtPrecio, cmbTipoMoto, txtNRuedas, cmbTipoFreno);
            }
            else
            {
                msj = "Complete todos los campos";
                MessageBox.Show(msj, "Error");
            }
        }

        //Vehiculo
        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;
            if (!char.IsLetter(letra) && letra != ' ' && letra != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }

            if (char.IsLetter(letra))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void txtColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            char color = e.KeyChar;
            if (!char.IsLetter(color) && color != ' ' && color != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        private void txtCombustible_KeyPress(object sender, KeyPressEventArgs e)
        {
            char comustible = e.KeyChar;
            if (!char.IsLetter(comustible) && comustible != ' ' && comustible != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        private void txtKilometraje_KeyPress(object sender, KeyPressEventArgs e)
        {
            char km = e.KeyChar;
            if (!char.IsDigit(km) && km != ' ' && km != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            char precio = e.KeyChar;
            if (!char.IsDigit(precio) && precio != ' ' && precio != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        //Automovil
        private void txtNPuertas_KeyPress(object sender, KeyPressEventArgs e)
        {
            char puertas = e.KeyChar;
            if (!char.IsDigit(puertas) && puertas != ' ' && puertas != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        //Camion
        private void txtCapacidadCarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            char capacidad = e.KeyChar;
            if (!char.IsDigit(capacidad) && capacidad != ' ' && capacidad != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }

        }

        //Motocicleta
        private void txtNRuedas_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ruedas = e.KeyChar;
            if (!char.IsDigit(ruedas) && ruedas != ' ' && ruedas != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
           CtrlConn ctrlc = new CtrlConn();
            ctrlc.conectar();
        }
    }
}
