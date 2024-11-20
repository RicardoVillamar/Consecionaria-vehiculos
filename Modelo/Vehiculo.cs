using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Vehiculo
    {
        public string IdVehiculo { get; set; }
        public string Marca { get; set; }
        public string TipoVehiculo { get; set; }
        public string TipoCombustible { get; set; }
        public string Color { get; set; }
        public string Estado { get; set; }
        public float Kilometraje { get; set; }
        public float Precio { get; set; }

        public Vehiculo(string idVehiculo, string marca, string tipoVehiculo, string tipoCombustible, string color, string estado, float kilometraje, float precio)
        {
            IdVehiculo = idVehiculo;
            Marca = marca;
            TipoVehiculo = tipoVehiculo;
            TipoCombustible = tipoCombustible;
            Color = color;
            Estado = estado;
            Kilometraje = kilometraje;
            Precio = precio;
        }

        public void RegistrarVehiculo()
        {
            // Implementar lógica de registro de vehículo
        }

        public void ReporteVehiculo()
        {
            // Implementar lógica de reporte de vehículo
        }

        public bool RetirarVehiculo()
        {
            // Implementar lógica de retiro de vehículo
            return true;
        }

        // Método para obtener la representación en cadena del objeto Vehiculo
        public override string ToString()
        {
            return $"Id: {IdVehiculo}\nMarca: {Marca}\nTipo de Vehiculo: {TipoVehiculo}\nTipo de Combustible: {TipoCombustible}\nColor: {Color}\nEstado: {Estado}\nKilometraje: {Kilometraje}\nPrecio: {Precio}";
        }
    }
}
