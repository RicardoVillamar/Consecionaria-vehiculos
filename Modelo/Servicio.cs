using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Servicio
    {
        private string idServicio;
        private string tipoVehiculo;
        private string cedula;
        private string servicios;
        private DateTime fecha;
        private string descripServicio;
        private float costo;

        public string IdServicio { get => idServicio; set => idServicio = value; }
        public string TipoVehiculo { get => tipoVehiculo; set => tipoVehiculo = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Servicios { get => servicios; set => servicios = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string DescripServicio { get => descripServicio; set => descripServicio = value; }
        public float Costo { get => costo; set => costo = value; }

        public Servicio(string idServicio, string tipoVehiculo, string cedula, string servicios, DateTime fecha,  float costo)
        {
            IdServicio = idServicio;
            TipoVehiculo = tipoVehiculo;
            Cedula = cedula;
            Servicios = servicios;
            Fecha = fecha;
            Costo = costo;
        }

        public void RegistrarServicio()
        {

        }
        public void ModificarServicio()
        {

        }
        public void EliminarServicio()
        {

        }

        public void GenerarReporte()
        {

        }

        public override string ToString()
        {
            return "ID:" + idServicio + "\nTipo de Vehiculo: " + tipoVehiculo + "\nCedula: " + cedula + "\nServicios: " + servicios
                + "\nFecha: " + fecha + "\nDescripcion de Servicio: " + descripServicio + "\nCosto: " + costo;
        }
    }
}
