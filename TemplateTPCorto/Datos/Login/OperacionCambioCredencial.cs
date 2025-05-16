using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class OperacionCambioCredencial
    {
        private String _idOperacion;
        private String _legajo;
        private String _nombreUsuario;
        private String _contrasena;
        private String _idPerfil;
        private DateTime _fechaAlta;
        private DateTime _fechaUltimoLogin;

        public string IdOperacion { get => _idOperacion; set => _idOperacion = value; }
        public string Legajo { get => _legajo; set => _legajo = value; }
        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Contrasena { get => _contrasena; set => _contrasena = value; }
        public string IdPerfil { get => _idPerfil; set => _idPerfil = value; }
        public DateTime FechaAlta { get => _fechaAlta; set => _fechaAlta = value; }
        public DateTime FechaUltimoLogin { get => _fechaUltimoLogin; set => _fechaUltimoLogin = value; }

        public OperacionCambioCredencial(String registro)
        {
            String[] datos = registro.Split(';');
            this._idOperacion = datos[0];
            this._legajo = datos[1];
            this._nombreUsuario = datos[2];
            this._contrasena = datos[3];
            this._idPerfil = datos[4];
            this._fechaAlta = DateTime.ParseExact(datos[5], "d/M/yyyy", CultureInfo.InvariantCulture);
            this._fechaUltimoLogin = DateTime.ParseExact(datos[6], "d/M/yyyy", CultureInfo.InvariantCulture);
        }

        public OperacionCambioCredencial()
        {
        }
    }
}
