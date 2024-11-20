using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control
{
    public class ValidarCompraVenta
    {
        public static bool ValidarDatosDetalle(DataGridView grid)
        {
            bool valido = true;
            int i = 0;

            if (grid.RowCount == 1) return !valido;

            foreach (DataGridViewRow row in grid.Rows)
            {
                try
                {
                    int Cantidad = ValidarCompraVenta.aEnteroPositivo(row.Cells["Cantidad"].Value.ToString());
                    decimal PrecioUnitario = ValidarCompraVenta.aDecimal(row.Cells["PrecioUnitario"].Value.ToString());

                    if(Cantidad == -1)
                        valido = false;

                    if (PrecioUnitario < 500)
                        valido = false;
 
                }
                catch (Exception ex)
                {
                    valido = false;
                }

                if(!valido) break;
                
                if (++i == grid.RowCount - 1) break;
            }

            return valido;
        }

        public static bool ValidarCedula(string cedula)
        {
            bool esValido = true;

            if (cedula.Length != 10 || String.IsNullOrEmpty(cedula))
                return !esValido;

            foreach (char letra in cedula)
            {
                if (Char.IsLetter(letra))
                {
                    esValido = false;
                    break;
                }
            }

            return esValido;
        }

        public static decimal aDecimal(string valor)
        {
            decimal number;
            try
            {
                Decimal.TryParse(valor, out number);
                return number;
            }
            catch
            {
                return 0;
            }
        }

        public static int aEnteroPositivo(string valor)
        {
            try
            {
                return Convert.ToInt32(valor.Trim());
            }
            catch
            {
                return -1;
            }
        }
    }
}
