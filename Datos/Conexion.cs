using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        private SqlConnection cn = null;

        public SqlConnection Cn { get => cn; set => cn = value; }

        // Método para establecer la conexión a la base de datos
        public string Conectar()
        {
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = cadena;
                cn.Open();
                return "1";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return "0" + ex.Message;
            }
        }

        // Método para cerrar la conexión a la base de datos
        public string Cerrar()
        {
            try
            {
                cn.Close();
                return "1";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return "0" + ex.Message;
            }
        }
    }
}
