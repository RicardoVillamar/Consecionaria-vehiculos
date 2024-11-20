using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Detalle
    {
        private int cantidad;
        private string descripcion;
        private decimal precioUnitario;

        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }

        // Constructor que inicializa todos los campos
        public Detalle(int cantidad, string descripcion, decimal precioUnitario)
        {
            Cantidad = cantidad;
            Descripcion = descripcion;
            PrecioUnitario = precioUnitario;
        }

        // Constructor que inicializa cantidad y precioUnitario
        public Detalle(int cantidad, decimal precioUnitario)
        {
            this.cantidad = cantidad;
            this.precioUnitario = precioUnitario;
        }
    }
}

