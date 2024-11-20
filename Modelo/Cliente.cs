using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente
    {

        //Se está tomando el valor de identificación del cliente que se proporciona al crear un nuevo cliente.

        private string _idCliente;
        public string IdCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        //Se está tomando el nombre del cliente que se proporcionó al crear un nuevo cliente

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        //Esta línea se encarga de asignar el valor del apellido que se proporcionó al crear un nuevo cliente

        private string _Apellido;
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }

            //Esta línea se encarga de asignar el valor del cedula que se proporcionó al crear un nuevo cliente

        }
        private string _Cedula;
        public string Cedula
        {
            get { return _Cedula; }
            set { _Cedula = value; }
        }

        //Esta línea se encarga de asignar el valor del telefono que se proporcionó al crear un nuevo cliente

        private int _Telefono;
        public int Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        //Esta línea se encarga de asignar el valor del Email que se proporcionó al crear un nuevo cliente

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
    }
}