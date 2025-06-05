using Datos;
using Negocio.interfaces;
using Persistencia;
using Persistencia.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AutorizacionNegocio:IAutorizacionNegocio
    {
        private readonly IAutorizacionPersistencia autorizacionPersistencia;
        private readonly IGestionUsuarioNegocio gestionUsuarioNegocio;
        private readonly ILoginNegocio loginNegocio;
        
        public AutorizacionNegocio(IAutorizacionPersistencia autorizacionPersistencia, IGestionUsuarioNegocio gestionUsuarioNegocio,
            ILoginNegocio loginNegocio)
        {
            this.autorizacionPersistencia = autorizacionPersistencia;
            this.gestionUsuarioNegocio = gestionUsuarioNegocio;
            this.loginNegocio = loginNegocio;
        }
        public void RegistrarOperacionCambioCredencial(Autorizacion autorizacion, OperacionCambioCredencial operacion)
        {
            string idOperacion = autorizacionPersistencia.CrearAutorizacion(autorizacion);
            operacion.IdOperacion = idOperacion;
            autorizacionPersistencia.RegistrarOperacionCambioCredencial(operacion);
        }
        public void RegistrarOperacionCambioPersona(Autorizacion autorizacion, OperacionCambioPersona operacion)
        {
            string idOperacion = autorizacionPersistencia.CrearAutorizacion(autorizacion);
            operacion.IdOperacion = idOperacion;
            autorizacionPersistencia.RegistrarOperacionCambioPersona(operacion);
        }

        public List<OperacionCambioCredencial> ObtenerOperacionesCambioCredencialPendientesAutorizar()
        {
            List<Autorizacion> autorizaciones = ObtenerAutorizacionesPorTipoOperacionEstado(
                EnumTipoOperacion.CambioCredencial.ToString(),
                EnumEstadoAutorizacion.Pendiente.ToString()
            );
            List<String> idsOperacion = ObtenerIdsOperacion(autorizaciones);
            return autorizacionPersistencia.ObtenerOperacionesCambioCredencialPorIdsOperacion(idsOperacion);
        }

        public List<OperacionCambioPersona> ObtenerOperacionesCambioPersonaPendientesAutorizar()
        {
            List<Autorizacion> autorizaciones = ObtenerAutorizacionesPorTipoOperacionEstado(
                EnumTipoOperacion.CambioPersona.ToString(),
                EnumEstadoAutorizacion.Pendiente.ToString()
            );
            List<String> idsOperacion = ObtenerIdsOperacion(autorizaciones);
            return autorizacionPersistencia.ObtenerOperacionesCambioPersonaPorIdsOperacion(idsOperacion);
        }

        public void AutorizarOperacionesCambioCredencial(List<OperacionCambioCredencial> operaciones, string legajoAutorizador)
        {
            foreach (OperacionCambioCredencial row in operaciones)
            {
                Credencial credencial = gestionUsuarioNegocio.BuscarCredencialPorNumeroLegajo(row.Legajo);
                credencial.Contrasena = row.Contrasena;
                credencial.FechaUltimoLogin = null;
                loginNegocio.ReiniciarIntentos(row.Legajo);
                gestionUsuarioNegocio.ActualizarContrasenia(credencial);
                gestionUsuarioNegocio.DesbloquearUsuarioBloqueadoPorLegajo(row.Legajo);
                ActualizarEstadoAutorizacion(
                    row.IdOperacion,
                    EnumEstadoAutorizacion.Autorizado.ToString(),
                    legajoAutorizador
                );
            }
        }

        public void AutorizarOperacionesCambioPersona(List<OperacionCambioPersona> operaciones, string legajoAutorizador)
        {
            foreach (OperacionCambioPersona row in operaciones)
            {
                Persona modificada = new Persona
                {
                    Legajo = row.Legajo,
                    Nombre = row.Nombre,
                    Apellido = row.Apellido,
                    Dni = row.Dni,
                    FechaIngreso = row.FechaIngreso
                };
                gestionUsuarioNegocio.ActualizarDatosPersonaPorLegajo(modificada);
                ActualizarEstadoAutorizacion(
                    row.IdOperacion,
                    EnumEstadoAutorizacion.Autorizado.ToString(),
                    legajoAutorizador
                );
            }
        }

        public void RechazarOperacionesCambioCredencial(List<OperacionCambioCredencial> operaciones, string legajoAutorizador)
        {
            foreach (OperacionCambioCredencial row in operaciones)
            {
                ActualizarEstadoAutorizacion(
                    row.IdOperacion,
                    EnumEstadoAutorizacion.Rechazado.ToString(),
                    legajoAutorizador
                );
            }
        }

        public void RechazarOperacionesCambioPersona(List<OperacionCambioPersona> operaciones, string legajoAutorizador)
        {
            foreach (OperacionCambioPersona row in operaciones)
            {
                ActualizarEstadoAutorizacion(
                    row.IdOperacion,
                    EnumEstadoAutorizacion.Rechazado.ToString(),
                    legajoAutorizador
                );
            }
        }
        private List<Autorizacion> ObtenerAutorizacionesPorTipoOperacionEstado(string tipoOperacion, string estado)
        {
            return autorizacionPersistencia.ObtenerAutorizacionesPorTipoOperacionEstado(tipoOperacion, estado);
        }

        private List<String> ObtenerIdsOperacion(List<Autorizacion> autorizaciones)
        {
            List<String> idsOperacion = new List<String>();
            foreach (Autorizacion registro in autorizaciones)
            {
                idsOperacion.Add(registro.IdOperacion);
            }
            return idsOperacion;
        }
        private void ActualizarEstadoAutorizacion(string idOperacion, string estado, string legajoAutorizador)
        {
            Autorizacion autorizacion = autorizacionPersistencia.ObtenerAutorizacionPorIdOperacion(idOperacion);
            autorizacion.Estado = estado;
            autorizacion.LegajoAutorizador = legajoAutorizador;
            autorizacion.FechaAutorizacion = DateTime.Now;
            autorizacionPersistencia.ActualizarEstadoAutorizacion(autorizacion);
        }

    }
}
