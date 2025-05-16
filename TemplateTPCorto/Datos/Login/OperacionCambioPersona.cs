using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class OperacionCambioPersona
    {
        private String _idOperacion;
        private String _legajo;
        private String _nombre;
        private String _apellido;
        private String _dni;
        private DateTime _fechaIngreso;

        public string IdOperacion { get => _idOperacion; set => _idOperacion = value; }
        public string Legajo { get => _legajo; set => _legajo = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Dni { get => _dni; set => _dni = value; }
        public DateTime FechaIngreso { get => _fechaIngreso; set => _fechaIngreso = value; }

        public OperacionCambioPersona(String registro)
        {
            String[] datos = registro.Split(';');
            this._idOperacion = datos[0];
            this._legajo = datos[1];
            this._nombre = datos[2];
            this._apellido = datos[3];
            this._dni = datos[4];
            this._fechaIngreso = DateTime.ParseExact(datos[5], "d/M/yyyy", CultureInfo.InvariantCulture);
        }

        public OperacionCambioPersona()
        {
        }
        public override string ToString()
        {
            string fechaIngreso = FechaIngreso.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            return $"Legajo: {Legajo}, Nombre: {Nombre}, Apellido: {Apellido}, DNI: {Dni}, Fecha de ingreso: {fechaIngreso}";
        }
    }
}
