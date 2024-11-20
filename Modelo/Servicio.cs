using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Servicio
    {
        public string IdServicio { get; set; }
        public string TipoVehiculo { get; set; }
        public string Cedula { get; set; }
        public string Servicios { get; set; }
        public DateTime Fecha { get; set; }
        public string DescripServicio { get; set; }
        public float Costo { get; set; }

        // Constructor de la clase Servicio
        public Servicio(string idServicio, string tipoVehiculo, string cedula, string servicios, DateTime fecha, float costo)
        {
            IdServicio = idServicio;
            TipoVehiculo = tipoVehiculo;
            Cedula = cedula;
            Servicios = servicios;
            Fecha = fecha;
            Costo = costo;
        }

        // Método ToString para representar el objeto como una cadena
        public override string ToString()
        {
            return $"ID: {IdServicio}\nTipo de Vehiculo: {TipoVehiculo}\nCedula: {Cedula}\nServicios: {Servicios}\nFecha: {Fecha}\nDescripcion de Servicio: {DescripServicio}\nCosto: {Costo}";
        }
    }
}
