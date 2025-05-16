using Datos;
using Persistencia;
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
        private const int MAX_INTENTOS = 3;
        public Credencial login(String usuario, String password)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();

            Credencial credencial = usuarioPersistencia.login(usuario);

            if (credencial != null && credencial.Contrasena.Equals(password))
            {
                ReiniciarIntentos(credencial.Legajo);
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
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            return usuarioPersistencia.ObtenerPerfil(legajo);
        }
        public bool EstaBloqueado(string usuario)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            Credencial credencial = usuarioPersistencia.login(usuario);
            if (credencial != null)
            {
                return usuarioPersistencia.EstaBloqueado(credencial.Legajo);

            }
            return false;
        }

        private void RegistrarIntento(Credencial credencial)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
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

        private void ReiniciarIntentos(string legajo)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            usuarioPersistencia.ReiniciarIntentos(legajo);
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

        public bool TieneRol(List<Rol> roles, string rolId)
        {
            bool tieneRol = false;
            foreach (Rol rol in roles)
            {
                if (rol.Id == rolId)
                {
                    tieneRol = true;
                    break;
                }
            }
            return tieneRol;
        }
        public void ActualizarContrasenia(Credencial credencial)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            usuarioPersistencia.ActualizarContrasenia(credencial);
        }
        public void RegistrarOperacionCambioCredencial(OperacionCambioCredencial operacion)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            usuarioPersistencia.RegistrarOperacionCambioCredencial(operacion);
        }

        public Credencial BuscarCredencialPorNumeroLegajo(String legajo)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            return usuarioPersistencia.BuscarCredencialPorNumeroLegajo(legajo);
        }

        public Persona BuscarPersonaPorNumeroLegajo(string legajo)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            return usuarioPersistencia.BuscarPersonaPorNumeroLegajo(legajo);
        }

        public void RegistrarOperacionCambioPersona(OperacionCambioPersona operacion)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            usuarioPersistencia.RegistrarOperacionCambioPersona(operacion);
        }

        public List<OperacionCambioCredencial> ObtenerOperacionesCambioCredencial()
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            return usuarioPersistencia.ObtenerOperacionesCambioCredencial();
        }

        public List<OperacionCambioPersona> ObtenerOperacionesCambioPersona()
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            return usuarioPersistencia.ObtenerOperacionesCambioPersona();
        }

        public void AutorizarOperacionesCambioCredencial(List<OperacionCambioCredencial> operaciones)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            foreach (OperacionCambioCredencial row in operaciones)
            {
                Credencial credencial = usuarioPersistencia.ObtenerCredencialPorLegajo(row.Legajo);
                credencial.Contrasena = row.Contrasena;
                credencial.FechaUltimoLogin = null;
                ActualizarContrasenia(credencial);
                ReiniciarIntentos(row.Legajo);
                usuarioPersistencia.EliminarUsuarioBloqueadoPorLegajo(row.Legajo);
                usuarioPersistencia.EliminarOperacionCambioCredencialPorIdOperacion(row.IdOperacion);
            }
        }

        public void AutorizarOperacionesCambioPersona(List<OperacionCambioPersona> operaciones)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            foreach (OperacionCambioPersona row in operaciones)
            {
                Persona modificada = new Persona();
                modificada.Legajo = row.Legajo;
                modificada.Nombre = row.Nombre;
                modificada.Apellido = row.Apellido;
                modificada.Dni = row.Dni;
                modificada.FechaIngreso = row.FechaIngreso;
                usuarioPersistencia.ModificarPersonaPorLegajo(modificada);
                usuarioPersistencia.EliminarOperacionCambioPersonaPorIdOperacion(row.IdOperacion);
            }
        }
    }
}