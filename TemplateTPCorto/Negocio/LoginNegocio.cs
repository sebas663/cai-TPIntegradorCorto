using Datos;
using Persistencia;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LoginNegocio
    {
        private readonly UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
        private const int MAX_INTENTOS = 3;

        public LoginNegocio(UsuarioPersistencia usuarioPersistencia)
        {
            this.usuarioPersistencia = usuarioPersistencia;
        }

        public Credencial Login(String usuario, String password)
        {
            Credencial credencial = usuarioPersistencia.Login(usuario);

            if (credencial != null && credencial.Contrasena.Equals(password))
            {
                usuarioPersistencia.ReiniciarIntentos(credencial.Legajo);
                return credencial;
            }
            if (credencial != null)
            {
                RegistrarIntento(credencial);
            }
            return null;
        }
        public Perfil ObtenerPerfil(string legajo)
        {
            return usuarioPersistencia.ObtenerPerfil(legajo);
        }
        public bool EstaBloqueado(string usuario)
        {
            Credencial credencial = usuarioPersistencia.Login(usuario);
            if (credencial != null)
            {
                return usuarioPersistencia.EstaBloqueado(credencial.Legajo);

            }
            return false;
        }

        private void RegistrarIntento(Credencial credencial)
        {
            int intentos = usuarioPersistencia.ObtenerNumeroIntentosPorLegajo(credencial.Legajo);
            if (intentos < MAX_INTENTOS)
            {
                DateTime now = DateTime.Now;
                usuarioPersistencia.RegistrarIntento(credencial.Legajo, now.ToString("d/M/yyyy", CultureInfo.InvariantCulture));
            }
            if ((intentos + 1) == MAX_INTENTOS)
            {
                usuarioPersistencia.BloquearUsuario(credencial.Legajo);
            }
        }

        public bool EsContraseniaExpirada(Credencial credencial)
        {
            return credencial.FechaUltimoLogin.HasValue &&
                 credencial.FechaUltimoLogin.Value.AddDays(30) <= DateTime.Today;
        }

        public bool EsPrimerLogin(Credencial credencial)
        {
            return credencial.FechaUltimoLogin == default(DateTime);
        }
        
        public void ActualizarContrasenia(Credencial credencial)
        {
            usuarioPersistencia.ActualizarContrasenia(credencial);
        }

        public Credencial BuscarCredencialPorNumeroLegajo(String legajo)
        {
            return usuarioPersistencia.BuscarCredencialPorNumeroLegajo(legajo);
        }

        public Persona BuscarPersonaPorNumeroLegajo(string legajo)
        {
            return usuarioPersistencia.BuscarPersonaPorNumeroLegajo(legajo);
        }

        public void RegistrarOperacionCambioCredencial(Autorizacion autorizacion, OperacionCambioCredencial operacion)
        {
            string idOperacion = usuarioPersistencia.CrearAutorizacion(autorizacion);
            operacion.IdOperacion = idOperacion;
            usuarioPersistencia.RegistrarOperacionCambioCredencial(operacion);
        }
        public void RegistrarOperacionCambioPersona(Autorizacion autorizacion, OperacionCambioPersona operacion)
        {
            string idOperacion = usuarioPersistencia.CrearAutorizacion(autorizacion);
            operacion.IdOperacion = idOperacion;
            usuarioPersistencia.RegistrarOperacionCambioPersona(operacion);
        }

        public List<OperacionCambioCredencial> ObtenerOperacionesCambioCredencialPendientesAutorizar()
        {
            List<Autorizacion> autorizaciones = ObtenerAutorizacionesPorTipoOperacionEstado(
                EnumTipoOperacion.CambioCredencial.ToString(),
                EnumEstadoAutorizacion.Pendiente.ToString()
            );
            List<String> idsOperacion = ObtenerIdsOperacion(autorizaciones);
            return usuarioPersistencia.ObtenerOperacionesCambioCredencialPorIdsOperacion(idsOperacion);
        }

        public List<OperacionCambioPersona> ObtenerOperacionesCambioPersonaPendientesAutorizar()
        {
            List<Autorizacion> autorizaciones = ObtenerAutorizacionesPorTipoOperacionEstado(
                EnumTipoOperacion.CambioPersona.ToString(),
                EnumEstadoAutorizacion.Pendiente.ToString()
            );
            List<String> idsOperacion = ObtenerIdsOperacion(autorizaciones);
            return usuarioPersistencia.ObtenerOperacionesCambioPersonaPorIdsOperacion(idsOperacion);
        }
        
        public void AutorizarOperacionesCambioCredencial(List<OperacionCambioCredencial> operaciones, string legajoAutorizador)
        {
            foreach (OperacionCambioCredencial row in operaciones)
            {
                Credencial credencial = usuarioPersistencia.ObtenerCredencialPorLegajo(row.Legajo);
                credencial.Contrasena = row.Contrasena;
                credencial.FechaUltimoLogin = null;
                ActualizarContrasenia(credencial);
                usuarioPersistencia.ReiniciarIntentos(row.Legajo);
                usuarioPersistencia.EliminarUsuarioBloqueadoPorLegajo(row.Legajo);
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
                usuarioPersistencia.ModificarPersonaPorLegajo(modificada);
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
            return usuarioPersistencia.ObtenerAutorizacionesPorTipoOperacionEstado(tipoOperacion, estado);
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
            Autorizacion autorizacion = usuarioPersistencia.ObtenerAutorizacionPorIdOperacion(idOperacion);
            autorizacion.Estado = estado;
            autorizacion.LegajoAutorizador = legajoAutorizador;
            autorizacion.FechaAutorizacion = DateTime.Now;
            usuarioPersistencia.ActualizarEstadoAutorizacion(autorizacion);
        }

    }
}