using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Motocicleta : Vehiculo
    {
        private string idMotocicleta;
        private string tipoMoto;
        private int numRuedas;
        private string tipoFreno;

        public string IdMotocicleta { get => idMotocicleta; set => idMotocicleta = value; }
        public string TipoMoto { get => tipoMoto; set => tipoMoto = value; }
        public int NumRuedas { get => numRuedas; set => numRuedas = value; }
        public string TipoFreno { get => tipoFreno; set => tipoFreno = value; }

        // Constructor de la clase Motocicleta
        public Motocicleta(string idVehiculo, string marca, string tipoVehiculo, string tipoCombustible, string color, string estado, float kilometraje, float precio,
            string idMotocicleta, string tipoMoto, int numRuedas, string tipoFreno) : base(idVehiculo, marca, tipoVehiculo, tipoCombustible, color, estado, kilometraje, precio)
        {
            IdMotocicleta = idMotocicleta;
            TipoMoto = tipoMoto;
            NumRuedas = numRuedas;
            TipoFreno = tipoFreno;
        }

        // Método ToString para obtener la representación en cadena del objeto
        public override string ToString()
        {
            return base.ToString() + "\nTipo de Moto: " + TipoMoto + "\nNumero de Ruedas: " + NumRuedas + "\nTipo de Freno: " + TipoFreno;
        }
    }
}
