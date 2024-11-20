using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Datos
{
    public class DatosCompraVenta
    {
        private SqlCommand cmd = null;

        public void AgregarDetalles(List<Detalle> detalles, int IdCompraVenta, SqlConnection cn)
        {
            string script = "INSERT INTO [detalle] (cantidad, precio_unitario, compra_venta_id) VALUES (@cantidad, @precio_unitario, @compra_venta_id); SELECT CAST(scope_identity() AS int);";

            try
            {
                cmd = new SqlCommand(script, cn);
                
                foreach (Detalle detalle in detalles)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                    cmd.Parameters.AddWithValue("@precio_unitario", detalle.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@compra_venta_id", IdCompraVenta);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al insertar un detalle: {ex.Message}");
            }

        }


        public int AgregarCompraVenta(CompraVenta entity, int clienteId, SqlConnection cn)
        {
            string fields = "(tipo, id_cliente, total, fecha)";
            string script = $"INSERT INTO compra_ventas {fields} VALUES (@tipo, @idCliente, @total, @fecha) SELECT SCOPE_IDENTITY()";
            try
            {
                cmd = new SqlCommand(script, cn);

                // asociar el cliente con la compraventa con sus detalles
                cmd.Parameters.AddWithValue("@tipo", entity.TipoCV);
                cmd.Parameters.AddWithValue("@idCliente", clienteId);
                cmd.Parameters.AddWithValue("@total", entity.Total);
                cmd.Parameters.AddWithValue("@fecha", entity.Fecha);
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (SqlException ex)
            {
                return 0;
            }
        }

        /* Obtiene las compras o ventas realizadas por un cliente */
        public List<CompraVenta> ConsultarCompraVenta(string tipo, string cedula, SqlConnection cn)
        {
            string script = $@"
                    SELECT Apellidocliente, Cedulacliente, tipo, fecha, total FROM detalle
                    INNER JOIN compra_ventas ON (detalle.compra_venta_id) = (compra_ventas.id_compra_ventas) 
                    INNER JOIN Clientes ON (compra_ventas.id_cliente) = (Clientes.id_cliente) WHERE Cedulacliente = '{cedula}' AND tipo = '{tipo}'
                    GROUP BY Apellidocliente, Cedulacliente, tipo, fecha, total;
                    ";
                
            List<CompraVenta> lista = new List<CompraVenta>();
            Cliente cliente = new Cliente();
            try
            {
                cmd = new SqlCommand(script, cn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cliente.Apellido = dr["Apellidocliente"].ToString();
                    cliente.Cedula = dr["Cedulacliente"].ToString();

                    lista.Add(
                        new CompraVenta()
                        {
                            Cliente = cliente,
                            TipoCV = dr["tipo"].ToString(),
                            Fecha = DateTime.Parse(dr["fecha"].ToString().Substring(0, 10)),
                            Total = Decimal.Parse(dr["total"].ToString())
                        }
                    );
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al consultar compras o ventas: " + ex.Message);
            }

            return lista;
        }
    
        /* Elimina las compras o ventas con sus detalles de un cliente */
        public int Eliminar(string cedula, SqlConnection cn)
        {
            string script = $@"
                        DELETE c
                        FROM compra_ventas c
                        INNER JOIN clientes cl ON c.id_cliente = cl.id_cliente
                        WHERE cl.Cedulacliente = '{cedula}';
                        ";

            try
            {
                cmd = new SqlCommand(script, cn);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al eliminar compras o ventas de clientes: " + ex.Message);
                return 0;
            }

        }

    }

}
