using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;

namespace Datos
{
    public class DatosServicios
    {

        SqlCommand cmd = null;
        //Registrar
        public string IngresarServ(Servicio servDat, SqlConnection conex)
        {
            string msj = "";
            string comando = "INSERT INTO SERVICIO (Cedula, TipodeVehiculo, Servicios, Fecha, Costo) " +
                             "VALUES (@Cedula, @TipodeVehiculo,@Servicios, @Fecha, @Costo)";
            
            cmd = new SqlCommand(comando, conex);
            cmd.Parameters.AddWithValue("@Cedula", servDat.Cedula);
            cmd.Parameters.AddWithValue("@TipodeVehiculo", servDat.TipoVehiculo);
            cmd.Parameters.AddWithValue("@Servicios", servDat.Servicios);
            cmd.Parameters.AddWithValue("@Fecha", servDat.Fecha.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Costo", servDat.Costo);

            try
            {
                cmd.ExecuteNonQuery();
                msj = "1";
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                msj = "0" + ex.Message;
            }

            return msj;
        }

        //Actualizar
        public string ActualizarServ(string idServ, string tipodeVehiculo, string servicios, DateTime fecha, float costo, SqlConnection conex)
        {
            string x = "";
            string comando = "UPDATE SERVICIO SET TipodeVehiculo= @TipodeVehiculo, Servicios= @Servicios, Fecha= @Fecha, Costo= @Costo " +
                "WHERE idServicio= @idServicio";

            cmd = new SqlCommand(comando, conex);

            cmd.Parameters.AddWithValue("@idServicio", idServ);
            cmd.Parameters.AddWithValue("@TipodeVehiculo", tipodeVehiculo);
            cmd.Parameters.AddWithValue("@Servicios", servicios);
            cmd.Parameters.AddWithValue("@Fecha", fecha);
            cmd.Parameters.AddWithValue("@Costo", costo);

            try
            {
                cmd.ExecuteNonQuery();
                x = "1";
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                x = "0" + ex.Message;
            }
            return x;
        }

        //Eliminar
        public string EliminarServ(string idServ, SqlConnection conex)
        {
            string res = "";
            string comando = "DELETE FROM SERVICIO WHERE idServicio= @idServicio";

            try
            {
                using (SqlCommand cmd = new SqlCommand(comando, conex))
                {
                    cmd.Parameters.AddWithValue("@idServicio", idServ);
                    cmd.CommandText = comando;
                    cmd.ExecuteNonQuery();
                    res = "1";
                }

            }
            catch (SqlException e)
            {
                res = "0" + e.Message;
            }
            return res;
        }

        //Consulta Servicio
        public List<Servicio> ConsultServicio(SqlConnection conex)
        {
            List<Servicio> lista = new List<Servicio>();
            SqlDataReader dr = null;
            Servicio serv = null;
            string comando = "SELECT * FROM SERVICIO";
            cmd = new SqlCommand();
            try
            {
                cmd.Connection = conex;
                cmd.CommandText=comando;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    serv = new Servicio("", "", "", "", DateTime.Now, 0);
                    serv.IdServicio = dr["idServicio"].ToString();
                    serv.Cedula = dr["Cedula"].ToString();
                    serv.TipoVehiculo = dr["TipodeVehiculo"].ToString();
                    serv.Servicios = dr["Servicios"].ToString();
                    serv.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                    serv.Costo = float.Parse(dr["Costo"].ToString());
                    lista.Add(serv);

                }
            }catch (SqlException e) 
            { 
                Console.WriteLine(e.Message);
            }
            return lista;
        }

        //Consultar Filtrado de Cedula 
        public List<Servicio> ConsultCedula(SqlConnection conex,string cedula)
        {
            List<Servicio> lista = new List<Servicio>();
            SqlDataReader dr = null;
            Servicio serv = null;
            string comando = "SELECT * FROM SERVICIO WHERE Cedula = @Cedula";
            cmd = new SqlCommand(comando, conex);
            cmd.Parameters.AddWithValue("@Cedula", cedula);
            try
            {
                cmd.Connection = conex;
                cmd.CommandText = comando;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    serv = new Servicio("", "", "", "", DateTime.Now, 0);
                    serv.IdServicio = dr["idServicio"].ToString();
                    serv.Cedula = dr["Cedula"].ToString();
                    serv.TipoVehiculo = dr["TipodeVehiculo"].ToString();
                    serv.Servicios = dr["Servicios"].ToString();
                    serv.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                    serv.Costo = float.Parse(dr["Costo"].ToString());
                    lista.Add(serv);

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return lista;
        }

        //Consultar Filtrado de Servicio
        public List<Servicio> ConsultFilServ(SqlConnection conex, string servicios)
        {
            List<Servicio> lista = new List<Servicio>();
            SqlDataReader dr = null;
            Servicio serv = null;
            string comando = "SELECT * FROM SERVICIO WHERE Servicios = @Servicios";
            cmd = new SqlCommand(comando, conex);
            cmd.Parameters.AddWithValue("@Servicios", servicios);
            try
            {
                cmd.Connection = conex;
                cmd.CommandText = comando;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    serv = new Servicio("", "", "", "", DateTime.Now, 0);
                    serv.IdServicio = dr["idServicio"].ToString();
                    serv.Cedula = dr["Cedula"].ToString();
                    serv.TipoVehiculo = dr["TipodeVehiculo"].ToString();
                    serv.Servicios = dr["Servicios"].ToString();
                    serv.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                    serv.Costo = float.Parse(dr["Costo"].ToString());
                    lista.Add(serv);

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return lista;
        }

    }
}

