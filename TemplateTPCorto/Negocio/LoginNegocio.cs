using Datos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

            if (credencial == null)
            {
                return null;
            }
            if (!credencial.Contrasena.Equals(password))
            {
                credencial.EsContrasenaIncorrecta = true;
                RegistrarIntento(credencial);
                return credencial;
            }
            ReiniciarIntentos(credencial.Legajo);
            return credencial;
        }

        public string ObtenerPerfil(string legajo)
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
                credencial.EstaBloqueado = true;
                usuarioPersistencia.BloquearUsuario(credencial.Legajo);
            }

        }

        private void ReiniciarIntentos(string usuario)
        {

        }
    }
}