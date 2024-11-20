using Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;

namespace Control
{
    public class DatosCliente
    {
        SqlCommand cmd = null;

        public List<Cliente> ConsultarCliente(SqlConnection cone)
        {
            List<Cliente> listaC = new List<Cliente>();
            SqlDataReader dr = null;
            Cliente c = null;
            string scriptCliente = "SELECT * FROM Clientes";
            cmd = new SqlCommand();
            try
            {
                cmd.Connection = cone;
                cmd.CommandText = scriptCliente;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c = new Cliente("", "", "", "", "", "");
                    c.IdCliente = dr["idCliente"].ToString();
                    c.Nombre = dr["Nombrecliente"].ToString();
                    c.Apellido = dr["Apellidocliente"].ToString();
                    c.Cedula = dr["Cedulacliente"].ToString();
                    c.Telefono = dr["Telefonocliente"].ToString();
                    c.Email = dr["Correocliente"].ToString();
                    listaC.Add(c);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listaC;
        }


        public string RegistrarCliente(Cliente c, SqlConnection sql)
        {
            string v = " ";
            string scriptCliente = "INSERT INTO Clientes ( Nombrecliente, Apellidocliente, Cedulacliente, Telefonocliente, Correocliente)" +
                "VALUES ('" + c.Nombre + "','" + c.Apellido + "','" + c.Cedula + "','" + c.Telefono + "','" + c.Email + "')";
            cmd = new SqlCommand();
            try
            {
                cmd.Connection = sql;
                cmd.CommandText = scriptCliente;
                cmd.ExecuteNonQuery();
                v = "1";
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                v = "0" + ex.Message;
            }
            return v;
        }
        public string ActualizarCliente(string id, string telf, string email, SqlConnection sql)
        {
            string c = " ";
            string comando = "UPDATE Clientes SET Telefonocliente= @Telefonocliente, Correocliente = @Correocliente WHERE idCliente= @idCliente";

            cmd = new SqlCommand(comando, sql);

            cmd.Parameters.AddWithValue("@idCliente", id);
            cmd.Parameters.AddWithValue("@Telefonocliente", telf);
            cmd.Parameters.AddWithValue("@Correocliente", email);
            try
            {
                cmd.ExecuteNonQuery();
                c = "1";
            }
            catch (SqlException e)
            {
                c = "0" + e.Message;
            }
            return c;
        }
        public string EliminarCliente(string id, SqlConnection sql)
        {
            string eli;
            string comando = "DELETE FROM Clientes WHERE idCliente='" + id + "'";
            cmd = new SqlCommand();
            try
            {
                cmd.Connection = sql;
                cmd.CommandText = comando;
                cmd.ExecuteNonQuery();
                eli = "1";
            }
            catch (SqlException e)
            {
                eli = "0" + e.Message;
            }
            return eli;

        }

        public List<Cliente> FiltarCliente(SqlConnection cn, string nombre)
        {
            List<Cliente> lstC = new List<Cliente>();
            SqlDataReader dr = null;
            Cliente c  = null;
            string scriptC = "SELECT * FROM Clientes WHERE  Nombrecliente = @Nombrecliente";
            cmd = new SqlCommand(scriptC, cn);
            cmd.Parameters.AddWithValue("@Nombrecliente", nombre);

            try
            {
                cmd.Connection = cn;
                cmd.CommandText = scriptC;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c = new Cliente("", "", "", "", "", "");
                    c.IdCliente = dr["idCliente"].ToString();
                    c.Nombre = dr["Nombrecliente"].ToString();
                    c.Apellido = dr["Apellidocliente"].ToString();
                    c.Cedula = dr["Cedulacliente"].ToString();
                    c.Telefono = dr["Telefonocliente"].ToString();
                    c.Email = dr["Correocliente"].ToString();
                    lstC.Add(c);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lstC;
        }

        public List<Cliente> FiltarClienteC(SqlConnection cn, string cedula)
        {
            List<Cliente> lstCd = new List<Cliente>();
            SqlDataReader dr = null;
            Cliente ce = null;
            string scriptC = "SELECT * FROM Clientes WHERE  Cedulacliente = @Cedulacliente";
            cmd = new SqlCommand(scriptC, cn);
            cmd.Parameters.AddWithValue("@Cedulacliente", cedula);

            try
            {
                cmd.Connection = cn;
                cmd.CommandText = scriptC;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ce = new Cliente("", "", "", "", "", "");
                    ce.IdCliente = dr["idCliente"].ToString();
                    ce.Nombre = dr["Nombrecliente"].ToString();
                    ce.Apellido = dr["Apellidocliente"].ToString();
                    ce.Cedula = dr["Cedulacliente"].ToString();
                    ce.Telefono = dr["Telefonocliente"].ToString();
                    ce.Email = dr["Correocliente"].ToString();
                    lstCd.Add(ce);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lstCd;
        }

        ////////////////////////
        public int verificar(string cedula, SqlConnection conexion)
        {
            string script = $"SELECT * FROM Clientes WHERE Cedulacliente = '{cedula}';";
            SqlDataReader dr;
            try
            {
                cmd = new SqlCommand(script, conexion);
                dr = cmd.ExecuteReader();
                return dr.HasRows ? 1 : 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine("0" + e.Message);
                return 0;
            }

        }

        public Cliente ObtenerClientePorCedula(string cedula, SqlConnection conexion)
        {
            string script = $"SELECT * FROM Clientes WHERE Cedulacliente = '{cedula}'";

            try
            {
                cmd = new SqlCommand(script, conexion);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    return new Cliente(
                        dr["id_cliente"].ToString(),
                        dr["Nombrecliente"].ToString(),
                        dr["Apellidocliente"].ToString(),
                        dr["Cedulacliente"].ToString(),
                        dr["Telefonocliente"].ToString(),
                        dr["Correocliente"].ToString()
                    );
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("0" + e.Message);
                return null;
            }

        }
    }


}
