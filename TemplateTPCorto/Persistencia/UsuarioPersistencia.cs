using Datos;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Persistencia.interfaces;


namespace Persistencia
{
    public class UsuarioPersistencia: IUsuarioPersistencia
    {
        private readonly DataBaseUtils dataBaseUtils;
        public UsuarioPersistencia(DataBaseUtils dataBaseUtils)
        {
            this.dataBaseUtils = dataBaseUtils;
        }
        public Credencial Login(String username)
        {
            Credencial credencialLogin = null;
            foreach (Credencial credencial in ObtenerCredenciales())
            {
                if (credencial.NombreUsuario.Equals(username))
                {
                    credencialLogin = credencial;
                }
            }
            return credencialLogin;
        }
        public int ObtenerNumeroIntentosPorLegajo(string legajo)
        {
            List<String> listado = dataBaseUtils.BuscarRegistro("login_intentos.csv");
            int contador = 0;
            int intentos = 0;
            foreach (String registro in listado)
            {
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                String[] datos = registro.Split(';');
                if (datos[0] == legajo)
                {
                    intentos++;
                }
            }
            return intentos;
        }
        public void RegistrarIntento(string legajo, string fecha)
        {
            string[] nuevoRegistro = { legajo, fecha };
            string lineaCSV = string.Join(";", nuevoRegistro);
            dataBaseUtils.AgregarRegistro("login_intentos.csv", lineaCSV);
        }
        public void BloquearUsuario(string legajo)
        {
            dataBaseUtils.AgregarRegistro("usuario_bloqueado.csv", legajo);
        }
        public bool EstaBloqueado(string legajo)
        {
            List<String> listado = dataBaseUtils.BuscarRegistro("usuario_bloqueado.csv");
            int contador = 0;
            bool existe = false;
            foreach (String registro in listado)
            {
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                if (registro == legajo)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }
        public void ReiniciarIntentos(string legajo)
        {
            dataBaseUtils.BorrarRegistro(legajo, "login_intentos.csv");
        }
        private List<Credencial> ObtenerCredenciales()
        {
            List<String> listado = dataBaseUtils.BuscarRegistro("credenciales.csv");
            List<Credencial> listadoCredenciales = new List<Credencial>();
            int contador = 0;
            foreach (String registro in listado)
            {
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                Credencial credencial = new Credencial(registro);
                listadoCredenciales.Add(credencial);
            }
            return listadoCredenciales;
        }
    }
}