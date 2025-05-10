using Datos;
using Persistencia;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Negocio
{
    public class LoginNegocio
    {
        private const int MAX_INTENTOS = 3;

        private UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();

        public Credencial Login(String usuario, String password)
        {
            Credencial credencial = usuarioPersistencia.Login(usuario);

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
            if ((intentos + 1)  == MAX_INTENTOS)
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

