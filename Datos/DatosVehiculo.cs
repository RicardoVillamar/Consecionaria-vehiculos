using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Datos
{
    //Elaborado por el estudiante: Villamar Minuche Ricardo Daniel
    public class DatosVehiculo
    {
        SqlCommand cmd = null;


        public string IngresarVehiculo(Vehiculo vh, SqlConnection cn)
        {
            string x;

            string scriptVehiculo = "INSERT INTO Vehiculo (Marca, TipoVehiculo, TipoCombustible, Color, Estado, Kilometraje, Precio, Retirado) " +
                "VALUES (@Marca, @TipoVehiculo, @TipoCombustible, @Color, @Estado, @Kilometraje, @Precio, @Retirado); SELECT SCOPE_IDENTITY()";

            cmd = new SqlCommand();
            try
            {
                cmd.Connection = cn;
                cmd.CommandText = scriptVehiculo;
                cmd.Parameters.AddWithValue("@Marca", vh.Marca);
                cmd.Parameters.AddWithValue("@TipoVehiculo", vh.TipoVehiculo);
                cmd.Parameters.AddWithValue("@TipoCombustible", vh.TipoCombustible);
                cmd.Parameters.AddWithValue("@Color", vh.Color);
                cmd.Parameters.AddWithValue("@Estado", vh.Estado);
                cmd.Parameters.AddWithValue("@Kilometraje", vh.Kilometraje);
                cmd.Parameters.AddWithValue("@Precio", vh.Precio);
                cmd.Parameters.AddWithValue("@Retirado", "NO");

                int idVehiculo = Convert.ToInt32(cmd.ExecuteScalar());
                
                if (vh is Automovil)
                {
                    Automovil auto = (Automovil)vh;
                    string scriptAutomovil = "INSERT INTO Automovil (idAutomovil, numeroPuertas, tipoTransmision, tipoAutomovil) " +
                                             "VALUES (@IdVehiculo, @NumeroPuertas, @TipoTransmision, @TipoAuto)";

                    cmd.CommandText = scriptAutomovil;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IdVehiculo", idVehiculo);
                    cmd.Parameters.AddWithValue("@NumeroPuertas", auto.NumeroPuertas);
                    cmd.Parameters.AddWithValue("@TipoTransmision", auto.TipoTransmision);
                    cmd.Parameters.AddWithValue("@TipoAuto", auto.TipoAuto);

                    cmd.ExecuteNonQuery();
                }
                else if (vh is Camion)
                {
                    Camion camion = (Camion)vh;
                    string scriptCamion = "INSERT INTO Camion (idCamion, capacidadCarga, tipoCarga) " +
                                          "VALUES (@IdVehiculo, @CapacidadCarga, @TipoCarga)";

                    cmd.CommandText = scriptCamion;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IdVehiculo", idVehiculo);
                    cmd.Parameters.AddWithValue("@CapacidadCarga", camion.CapacidadCarga);
                    cmd.Parameters.AddWithValue("@TipoCarga", camion.TipoCarga);

                    cmd.ExecuteNonQuery();
                }
                else if (vh is Motocicleta)
                {
                    Motocicleta moto = (Motocicleta)vh;
                    string scriptMotocicleta = "INSERT INTO Motocicleta (idMotocicleta, tipoMoto, numeroRuedas, tipoFrenos) " +
                                               "VALUES (@IdVehiculo, @TipoMoto, @NumeroRuedas, @TipoFrenos)";

                    cmd.CommandText = scriptMotocicleta;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IdVehiculo", idVehiculo);
                    cmd.Parameters.AddWithValue("@TipoMoto", moto.TipoMoto);
                    cmd.Parameters.AddWithValue("@NumeroRuedas", moto.NumRuedas);
                    cmd.Parameters.AddWithValue("@TipoFrenos", moto.TipoFreno);

                    cmd.ExecuteNonQuery();
                }

                x = "1";
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al insertar Vehiculo: " + ex.Message);
                x = "0" + ex.Message;
            }

            return x;
        }
    
        public List<Vehiculo> ConsultarVh(SqlConnection cn)
        {
            List<Vehiculo> listvh = new List<Vehiculo>();
            SqlDataReader dr = null;
            Vehiculo vh = null;
            string scriptVehiculo = "SELECT * FROM Vehiculo WHERE Retirado != 'SI'";
            cmd = new SqlCommand();

            try
            {
                cmd.Connection = cn;
                cmd.CommandText = scriptVehiculo;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    vh = new Vehiculo("", "", "", "", "", "",0,0) ;
                    vh.IdVehiculo = dr["IdVehiculo"].ToString();
                    vh.Marca = dr["Marca"].ToString();
                    vh.TipoVehiculo = dr["TipoVehiculo"].ToString();
                    vh.TipoCombustible = dr["TipoCombustible"].ToString();
                    vh.Color = dr["Color"].ToString();
                    vh.Estado = dr["Estado"].ToString();
                    vh.Kilometraje = float.Parse(dr["Kilometraje"].ToString());
                    vh.Precio = float.Parse(dr["Precio"].ToString());
                    listvh.Add(vh);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return listvh;
        }
        public string EliminarVehiculo(string id, SqlConnection cn)
        {
            string x;
            string scriptVehiculo = "DELETE FROM Vehiculo WHERE IdVehiculo = '" + id + "'";
            cmd = new SqlCommand();

            try
            {
                cmd.Connection = cn;
                cmd.CommandText = scriptVehiculo;
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

        public string RetirarVehiculo(string id, SqlConnection cn)
        {
            string x;
            string scriptVehiculo = "UPDATE Vehiculo SET Retirado = 'SI' WHERE IdVehiculo = @IdVehiculo";
            cmd = new SqlCommand(scriptVehiculo, cn);

            cmd.Parameters.AddWithValue("@IdVehiculo", id);

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

        public string ActualizarVehiculo(string id, string color, string tipoCombustible, SqlConnection cn)
        {
            string x;
            string scriptVehiculo = "UPDATE Vehiculo SET Color = @Color, TipoCombustible = @TipoCombustible WHERE IdVehiculo = @IdVehiculo";
            cmd = new SqlCommand(scriptVehiculo, cn);

            cmd.Parameters.AddWithValue("@IdVehiculo", id);
            cmd.Parameters.AddWithValue("@Color", color);
            cmd.Parameters.AddWithValue("@TipoCombustible", tipoCombustible);

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

        public List<Vehiculo> FiltarVhMarca(SqlConnection cn, string marca)
        {
            List<Vehiculo> listvh = new List<Vehiculo>();
            SqlDataReader dr = null;
            Vehiculo vh = null;
            string scriptVehiculo = "SELECT * FROM Vehiculo WHERE Retirado != 'SI' AND Marca = @Marca";
            cmd = new SqlCommand(scriptVehiculo, cn);
            cmd.Parameters.AddWithValue("@Marca", marca);

            try
            {
                cmd.Connection = cn;
                cmd.CommandText = scriptVehiculo;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    vh = new Vehiculo("", "", "", "", "", "", 0, 0);
                    vh.IdVehiculo = dr["IdVehiculo"].ToString();
                    vh.Marca = dr["Marca"].ToString();
                    vh.TipoVehiculo = dr["TipoVehiculo"].ToString();
                    vh.TipoCombustible = dr["TipoCombustible"].ToString();
                    vh.Color = dr["Color"].ToString();
                    vh.Estado = dr["Estado"].ToString();
                    vh.Kilometraje = float.Parse(dr["Kilometraje"].ToString());
                    vh.Precio = float.Parse(dr["Precio"].ToString());
                    listvh.Add(vh);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return listvh;
        }

        public List<Vehiculo> FiltrarVhEstado(SqlConnection cn, string estado)
        {
            List<Vehiculo> listvh = new List<Vehiculo>();
            SqlDataReader dr = null;
            Vehiculo vh = null;
            string scriptVehiculo = "SELECT * FROM Vehiculo WHERE Retirado != 'SI' AND Estado = @Estado";

            SqlCommand cmd = new SqlCommand(scriptVehiculo, cn);
            cmd.Parameters.AddWithValue("@Estado", estado);

            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    vh = new Vehiculo("", "", "", "", "", "", 0, 0);
                    vh.IdVehiculo = dr["IdVehiculo"].ToString();
                    vh.Marca = dr["Marca"].ToString();
                    vh.TipoVehiculo = dr["TipoVehiculo"].ToString();
                    vh.TipoCombustible = dr["TipoCombustible"].ToString();
                    vh.Color = dr["Color"].ToString();
                    vh.Estado = dr["Estado"].ToString();
                    vh.Kilometraje = float.Parse(dr["Kilometraje"].ToString());
                    vh.Precio = float.Parse(dr["Precio"].ToString());
                    listvh.Add(vh);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (dr != null && !dr.IsClosed)
                {
                    dr.Close();
                }
            }
            return listvh;
        }

    }
}
