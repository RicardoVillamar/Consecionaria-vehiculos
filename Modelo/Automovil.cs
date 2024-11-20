using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Automovil : Vehiculo
    {
        private string idAutomovil;
        private string numeroPuertas;
        private string tipoTransmision;
        private string tipoAuto;

        public string IdAutomovil { get => idAutomovil; set => idAutomovil = value; }
        public string NumeroPuertas { get => numeroPuertas; set => numeroPuertas = value; }
        public string TipoTransmision { get => tipoTransmision; set => tipoTransmision = value; }
        public string TipoAuto { get => tipoAuto; set => tipoAuto = value; }

        // Constructor de la clase Automovil
        public Automovil(string idVehiculo, string marca, string tipoVehiculo, string tipoCombustible, string color, string estado, float kilometraje, float precio,
            string idAutomovil, string numeroPuertas, string tipoTransmision, string tipoAuto) : base(idVehiculo, marca, tipoVehiculo, tipoCombustible, color, estado, kilometraje, precio)
        {
            IdAutomovil = idAutomovil;
            NumeroPuertas = numeroPuertas;
            TipoTransmision = tipoTransmision;
            TipoAuto = tipoAuto;
        }

        // Método ToString para representar el objeto como una cadena
        public override string ToString()
        {
            return base.ToString() + "\nNumero de Puertas: " + NumeroPuertas + "\nTipo de Transmision: " + TipoTransmision + "\nTipo de Auto: " + tipoAuto;
        }

    }
}
