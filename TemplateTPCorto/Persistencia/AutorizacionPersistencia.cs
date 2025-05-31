using Datos;
using Persistencia.DataBase;
using Persistencia.interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class AutorizacionPersistencia:IAutorizacionPersistencia
    {
        private readonly DataBaseUtils dataBaseUtils;
        public AutorizacionPersistencia(DataBaseUtils dataBaseUtils)
        {
            this.dataBaseUtils = dataBaseUtils;
        }
        public void RegistrarOperacionCambioCredencial(OperacionCambioCredencial operacion)
        {
            string idOperacion = operacion.IdOperacion;
            string legajo = operacion.Legajo;
            string nombreUsuario = operacion.NombreUsuario;
            string contrasena = operacion.Contrasena;
            string fechaAlta = operacion.FechaAlta.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            string fechaUltimoLogin = operacion.FechaUltimoLogin.ToString("d/M/yyyy", CultureInfo.InvariantCulture); ;
            string idperfil = operacion.IdPerfil;
            string[] nuevoRegistro = { idOperacion, legajo, nombreUsuario, contrasena, idperfil, fechaAlta, fechaUltimoLogin };
            string lineaCSV = string.Join(";", nuevoRegistro);
            dataBaseUtils.AgregarRegistro("operacion_cambio_credencial.csv", lineaCSV);
        }
        public void RegistrarOperacionCambioPersona(OperacionCambioPersona operacion)
        {
            string idOperacion = operacion.IdOperacion;
            string legajo = operacion.Legajo;
            string nombre = operacion.Nombre;
            string apellido = operacion.Apellido;
            string dni = operacion.Dni;
            string fechaingreso = operacion.FechaIngreso.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            string[] nuevoRegistro = { idOperacion, legajo, nombre, apellido, dni, fechaingreso };
            string lineaCSV = string.Join(";", nuevoRegistro);
            dataBaseUtils.AgregarRegistro("operacion_cambio_persona.csv", lineaCSV);
        }
        public List<OperacionCambioCredencial> ObtenerOperacionesCambioCredencialPorIdsOperacion(List<string> idsOperacion)
        {
            List<OperacionCambioCredencial> listado = new List<OperacionCambioCredencial>();
            foreach (OperacionCambioCredencial registro in ObtenerOperacionesCambioCredencial())
            {
                if (idsOperacion.Contains(registro.IdOperacion))
                {
                    listado.Add(registro);
                }
            }
            return listado;
        }
        public List<OperacionCambioPersona> ObtenerOperacionesCambioPersonaPorIdsOperacion(List<string> idsOperacion)
        {
            List<OperacionCambioPersona> listado = new List<OperacionCambioPersona>();
            foreach (OperacionCambioPersona registro in ObtenerOperacionesCambioPersona())
            {
                if (idsOperacion.Contains(registro.IdOperacion))
                {
                    listado.Add(registro);
                }
            }
            return listado;
        }
        public Autorizacion ObtenerAutorizacionPorIdOperacion(string idOperacion)
        {
            Autorizacion autorizacion = null;
            foreach (Autorizacion item in ObtenerAutorizaciones())
            {
                if (item.IdOperacion == idOperacion)
                {
                    autorizacion = item;
                }
            }
            return autorizacion;
        }
        public List<Autorizacion> ObtenerAutorizacionesPorTipoOperacionEstado(string tipoOperacion, string estado)
        {
            List<Autorizacion> lista = new List<Autorizacion>();
            foreach (Autorizacion item in ObtenerAutorizaciones())
            {
                if (item.TipoOperacion == tipoOperacion && item.Estado == estado)
                {
                    lista.Add(item);
                }
            }
            return lista;
        }
        public string CrearAutorizacion(Autorizacion autorizacion)
        {
            List<String> listado = dataBaseUtils.BuscarRegistro("autorizacion.csv");
            string tipoOperacion = autorizacion.TipoOperacion;
            string estado = autorizacion.Estado;
            string legajoSolicitante = autorizacion.LegajoSolicitante;
            string fechaSolicitud = autorizacion.FechaSolicitud.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            string legajoAutorizador = autorizacion.LegajoAutorizador;
            string fechaAutorizacion = autorizacion.FechaAutorizacion?.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            // El archivo siempre tiene 1 registro demas, es el de los nombres de las columnas.
            // entonces el primer id es 1 
            string idOperacion = listado.Count.ToString();
            string[] nuevoRegistro = {
                idOperacion,
                tipoOperacion,
                estado,
                legajoSolicitante,
                fechaSolicitud,
                legajoAutorizador,
                fechaAutorizacion
            };
            string lineaCSV = string.Join(";", nuevoRegistro);
            dataBaseUtils.AgregarRegistro("autorizacion.csv", lineaCSV);
            return idOperacion;
        }
        public void ActualizarEstadoAutorizacion(Autorizacion autorizacion)
        {
            string idOperacion = autorizacion.IdOperacion;
            string tipoOperacion = autorizacion.TipoOperacion;
            string estado = autorizacion.Estado;
            string legajoSolicitante = autorizacion.LegajoSolicitante;
            string fechaSolicitud = autorizacion.FechaSolicitud.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            string legajoAutorizador = autorizacion.LegajoAutorizador;
            string fechaAutorizacion = autorizacion.FechaAutorizacion?.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            string[] nuevoRegistro = {
                idOperacion,
                tipoOperacion,
                estado,
                legajoSolicitante,
                fechaSolicitud,
                legajoAutorizador,
                fechaAutorizacion
            };
            string lineaCSV = string.Join(";", nuevoRegistro);
            dataBaseUtils.BorrarRegistro(idOperacion, "autorizacion.csv");
            dataBaseUtils.AgregarRegistro("autorizacion.csv", lineaCSV);
        }
        private List<OperacionCambioCredencial> ObtenerOperacionesCambioCredencial()
        {
            List<String> listado = dataBaseUtils.BuscarRegistro("operacion_cambio_credencial.csv");
            List<OperacionCambioCredencial> listadoCredenciales = new List<OperacionCambioCredencial>();
            int contador = 0;
            foreach (String registro in listado)
            {
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                listadoCredenciales.Add(new OperacionCambioCredencial(registro));
            }

            return listadoCredenciales;
        }
        private List<OperacionCambioPersona> ObtenerOperacionesCambioPersona()
        {
            List<String> listado = dataBaseUtils.BuscarRegistro("operacion_cambio_persona.csv");
            List<OperacionCambioPersona> listadoCredenciales = new List<OperacionCambioPersona>();
            int contador = 0;
            foreach (String registro in listado)
            {
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                listadoCredenciales.Add(new OperacionCambioPersona(registro));
            }

            return listadoCredenciales;
        }
        private List<Autorizacion> ObtenerAutorizaciones()
        {
            List<String> listado = dataBaseUtils.BuscarRegistro("autorizacion.csv");
            List<Autorizacion> listadoCredenciales = new List<Autorizacion>();
            int contador = 0;
            foreach (String registro in listado)
            {
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                listadoCredenciales.Add(new Autorizacion(registro));
            }

            return listadoCredenciales;
        }
    }
}
