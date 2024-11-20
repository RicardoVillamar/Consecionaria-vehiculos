using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Modelo
{
    public class Camion : Vehiculo
    {
        private string idCamion;
        private float capacidadCarga;
        private string tipoCarga;

        public string IdCamion { get => idCamion; set => idCamion = value; }
        public float CapacidadCarga { get => capacidadCarga; set => capacidadCarga = value; }
        public string TipoCarga { get => tipoCarga; set => tipoCarga = value; }

        // Constructor de la clase Camion
        public Camion(string idVehiculo, string marca, string tipoVehiculo, string tipoCombustible, string color, string estado, float kilometraje, float precio,
            string idCamion, float capacidadCarga, string tipoCarga) : base(idVehiculo, marca, tipoVehiculo, tipoCombustible, color, estado, kilometraje, precio)
        {
            IdCamion = idCamion;
            CapacidadCarga = capacidadCarga;
            TipoCarga = tipoCarga;
        }

        // Método ToString para obtener la representación en cadena del objeto
        public override string ToString()
        {
            return base.ToString() + "\nCapacidad de Carga: " + CapacidadCarga + "\nTipo de Carga: " + TipoCarga;
        }
    }
}
