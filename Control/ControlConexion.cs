using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control
{
    public class ControlConexion
    {
        Conexion conDBB = new Conexion();

        // Método para conectar a la base de datos
        public void conectar()
        {
            string msj = conDBB.Conectar();
            if (msj[0] == '1')
            {
                MessageBox.Show("Conexion Exitosa!");
            }
            else if (msj[0] == '0')
            {
                MessageBox.Show("Ocurrio un error: " + msj);
            }
            conDBB.Cerrar();
        }
    }
}
