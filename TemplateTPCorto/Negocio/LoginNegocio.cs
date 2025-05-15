using Datos;
using Datos.Login;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        public Credencial obtenerusuariosupervisor(String usuario)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            Credencial credencial = usuarioPersistencia.login(usuario);
            return credencial;
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
        public List<String> Obtenerdatos(string archivo)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            return usuarioPersistencia.Obtenerdatos(archivo);
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

        public void ActualizarContrasenia(Credencial usuario)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            string legajo = usuario.Legajo;
            string nombreUsuario = usuario.NombreUsuario;
            string contrasena = usuario.Contrasena;
            string fechaAlta = usuario.FechaAlta.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            string fechaUltimoLogin = usuario.FechaUltimoLogin.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            usuarioPersistencia.ActualizarContrasenia(legajo, nombreUsuario, contrasena, fechaAlta, fechaUltimoLogin);
        }
        public void Supervisorcredenciales(Credencial usuario)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            string legajo = usuario.Legajo;
            string nombreUsuario = usuario.NombreUsuario;
            string contrasena = usuario.Contrasena;
            string fechaAlta = usuario.FechaAlta.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            string fechaUltimoLogin = "";
            //string idperfil = ObtenerPerfil(legajo);
            string idperfil = "";
            usuarioPersistencia.ContraseñaSupervisor(legajo, nombreUsuario, contrasena, idperfil, fechaAlta, fechaUltimoLogin);
        }
        public Datousuario ObtenerPersona(string legajo)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            Datousuario datousuario = usuarioPersistencia.ObtenerPersona(legajo);
            return datousuario;
        }
        public void ModificarPersona(string legajo, string nombreUsuario, string Apellido, string DNI, string fechaIngreso)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            usuarioPersistencia.ModificarPersona(legajo, nombreUsuario, Apellido, DNI, fechaIngreso);
        }
        public bool AutorizarPersona(string idperfil)
        {
            bool flag = false;
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            Datousuario datosusuario = usuarioPersistencia.AutorizarUsuario(idperfil);
            if (datosusuario != null)
            {
                usuarioPersistencia.AutorizarRegistroUsuario(datosusuario);
                flag = true;
            }
            else
            {
                throw new Exception("No se encontró el usuario con el legajo proporcionado.");
            }
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
    }
}