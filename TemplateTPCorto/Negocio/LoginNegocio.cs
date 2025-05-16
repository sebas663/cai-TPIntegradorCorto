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

        private void ReiniciarIntentos(string usuario)
        {

        }

        public bool EsContraseniaExpirada(Credencial credencial)
        {
            return false;
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
        public void ActualizarContrasenia(Credencial usuario)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            string legajo = usuario.Legajo;
            string nombreUsuario = usuario.NombreUsuario;
            string contrasena = usuario.Contrasena;
            string fechaAlta = usuario.FechaAlta.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            string fechaUltimoLogin = usuario.FechaUltimoLogin?.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            usuarioPersistencia.ActualizarContrasenia(legajo, nombreUsuario, contrasena, fechaAlta, fechaUltimoLogin);
        }
        public void RegistrarOperacionCambioCredencial(Credencial usuario)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            string legajo = usuario.Legajo;
            string nombreUsuario = usuario.NombreUsuario;
            string contrasena = usuario.Contrasena;
            string fechaAlta = usuario.FechaAlta.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            string fechaUltimoLogin = usuario.FechaUltimoLogin?.ToString("d/M/yyyy", CultureInfo.InvariantCulture); ;
            Perfil perfil = usuarioPersistencia.ObtenerPerfil(legajo);
            string idperfil = perfil.Id;
            usuarioPersistencia.RegistrarOperacionCambioCredencial(legajo, nombreUsuario, contrasena, idperfil, fechaAlta, fechaUltimoLogin);
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

        public void RegistrarOperacionCambioPersona(Persona persona)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            string legajo = persona.Legajo;
            string nombre = persona.Nombre;
            string apellido = persona.Apellido;
            string dni = persona.Dni;
            string fechaingreso = persona.FechaIngreso.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            usuarioPersistencia.RegistrarOperacionCambioPersona(legajo, nombre, apellido, dni, fechaingreso);
        }

        public List<String> Obtenerdatos(string archivo)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            return usuarioPersistencia.Obtenerdatos(archivo);
        }
        public bool AutorizarPersona(string idperfil)
        {
            bool flag = false;
            //UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            //Persona datosusuario = usuarioPersistencia.AutorizarUsuario(idperfil);
            //if (datosusuario != null)
            //{
            //    usuarioPersistencia.AutorizarRegistroUsuario(datosusuario);
            //    flag = true;
            //}
            //else
            //{
            //    throw new Exception("No se encontró el usuario con el legajo proporcionado.");
            //}
            return flag;
        }
        public bool AutorizarContraseña(string idperfil)
        {
            bool flag = false;
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            Credencial credencial = usuarioPersistencia.AutorizarCredencial(idperfil);
            if (credencial != null)
            {
                usuarioPersistencia.AutorizarRegistroCredencial(credencial);
                flag = true;
            }
            else
            {
                throw new Exception("No se encontró el usuario con el legajo proporcionado.");
            }
            return flag;
        }
    }
}