using Datos;
using Negocio.interfaces;
using Persistencia;
using Persistencia.DataBase;
using Persistencia.interfaces;
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
    public class LoginNegocio:ILoginNegocio
    {
        private readonly IUsuarioPersistencia usuarioPersistencia;
        private const int MAX_INTENTOS = 3;

        public LoginNegocio(IUsuarioPersistencia usuarioPersistencia)
        {
            this.usuarioPersistencia = usuarioPersistencia;
        }
        public Credencial Login(String usuario, String password)
        {
            Credencial credencial = usuarioPersistencia.Login(usuario);

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
        public bool EstaBloqueado(string usuario)
        {
            Credencial credencial = usuarioPersistencia.Login(usuario);
            if (credencial != null)
            {
                return usuarioPersistencia.EstaBloqueado(credencial.Legajo);

            }
            return false;
        }
        public bool EsContraseniaExpirada(Credencial credencial)
        {
            return credencial.FechaUltimoLogin.HasValue &&
                 credencial.FechaUltimoLogin.Value.AddDays(30) <= DateTime.Today;
        }
        public bool EsPrimerLogin(Credencial credencial)
        {
            return credencial.FechaUltimoLogin == null;
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

        public void ReiniciarIntentos(string legajo)
        {
            usuarioPersistencia.ReiniciarIntentos(legajo);
        }
    }
}