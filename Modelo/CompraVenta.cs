using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CompraVenta
    {
        
// Estas propiedades parecen almacenar información relevante sobre una compra o venta, como el cliente involucrado, los detalles de los productos comprados, el tipo de operación, la fecha, el subtotal y el total.

        private Cliente _cliente;
        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        //Representan los productos o servicios que se están comprando o vendiendo.

        private List<Cliente> _clienteList;
        public List<Detalle> Detalles
        {
            get { return; _clienteList }
            set { _clienteList = value; }
        }

    //Indica el tipo de operación que se está realizando, es decir, si es una compra o una venta.

            private TipoCV;
            public string _TipoCV {

            get { return; _TipoCV }
            set {_TipoCV = value; }
    }
        
     //Es redundante y puede eliminarse.

        private _fecha;
            public DateTime _fecha
        {

            get { return; _fecha }
            set { _fecha = value; }
        }

      //Este método debería contener la lógica necesaria para realizar estos cálculos basados en los detalles de la compra.

        private _subtotal;
            public decimal _subtotal
        {

            get { return; _subtotal }
            set { _subtotal = value; }
        }
        private _total;
            public decimal _total
        {

            get { return; _total }
            set { _total = value; }
        }
    }

    }
