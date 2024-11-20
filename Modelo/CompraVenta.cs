using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CompraVenta
    {
        /* Estas propiedades parecen almacenar información relevante sobre una compra o venta, 
        como el cliente involucrado, los detalles de los productos comprados, el tipo de operación,
        la fecha, el subtotal y el total.*/

        // Representa al cliente asociado con la compra o venta
        private Cliente _cliente;
        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        //Representan los productos o servicios que se están comprando o vendiendo.
        private List<Detalle> _detalles;
        public List<Detalle> Detalles
        {
            get { return _detalles; }
            set { _detalles = value; }
        }

        //Indica el tipo de operación que se está realizando, es decir, si es una compra o una venta.
        private string _tipoCV;
        public string TipoCV
        {
            get { return _tipoCV; }
            set { _tipoCV = value; }
        }

        //Es redundante y puede eliminarse.
        private DateTime _fecha;
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        //Este método debería contener la lógica necesaria para realizar estos cálculos basados en los detalles de la compra.
        private decimal _subtotal;
        public decimal Subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; }
        }

        // Total calculado
        private decimal _total;
        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }

    }


}
