using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Autorizacion
    {
        private String _idOperacion;
        private String _tipoOperacion;
        private String _estado;
        private String _legajoSolicitante;
        private DateTime _fechaSolicitud;
        private String _legajoAutorizador;
        private DateTime? _fechaAutorizacion;

        public string IdOperacion { get => _idOperacion; set => _idOperacion = value; }
        public string TipoOperacion { get => _tipoOperacion; set => _tipoOperacion = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string LegajoSolicitante { get => _legajoSolicitante; set => _legajoSolicitante = value; }
        public DateTime FechaSolicitud { get => _fechaSolicitud; set => _fechaSolicitud = value; }
        public string LegajoAutorizador { get => _legajoAutorizador; set => _legajoAutorizador = value; }
        public DateTime? FechaAutorizacion { get => _fechaAutorizacion; set => _fechaAutorizacion = value; }

        public Autorizacion(String registro)
        {
            String[] datos = registro.Split(';');
            this._idOperacion = datos[0];
            this._tipoOperacion = datos[1];
            this._estado = datos[2];
            this._legajoSolicitante = datos[3];
            this._fechaSolicitud = DateTime.ParseExact(datos[4], "d/M/yyyy", CultureInfo.InvariantCulture);
            this._legajoAutorizador = datos[5];
            if (!string.IsNullOrEmpty(datos[6]))
            {
                this._fechaAutorizacion = DateTime.ParseExact(datos[6], "d/M/yyyy", CultureInfo.InvariantCulture);
            }
            
        }

        public Autorizacion()
        {
        }
    }
}
