using Datos;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Persistencia
{
    public class UsuarioPersistencia
    {
        public Credencial login(String username)
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

        public string ObtenerPerfil(string legajo)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            string perfilId = ObtenerPerfilId(legajo);
            List<String> listado = dataBaseUtils.BuscarRegistro("perfil.csv");
            string perfil = "";
            int contador = 0;
            foreach (String registro in listado)
            {
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                string [] campos = registro.Split(';');
                if (campos[0] == perfilId)
                {
                    perfil = campos[1];
                    break;
                }
            }

            return perfil;
        }

        private string ObtenerPerfilId(string legajo)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> listado = dataBaseUtils.BuscarRegistro("usuario_perfil.csv");
            string perfilId = "";
            int contador = 0;
            foreach (String registro in listado)
            {
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                string[] campos = registro.Split(';');
                if (campos[0] == legajo)
                {
                    perfilId = campos[1];
                    break;
                }
            }

            return perfilId;
        }

        private List<Credencial> ObtenerCredenciales()
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
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
                // Mostrar en consola lo que se está leyendo
                Console.WriteLine("Registro leído: " + registro);

                Credencial credencial = new Credencial(registro);
                listadoCredenciales.Add(credencial);
            }

            return listadoCredenciales;
        }

        public int ObtenerNumeroIntentosPorLegajo(string legajo)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();

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
                if (datos[0]==legajo)
                {
                    intentos++;
                }
            }

            return intentos;
        }
        public void RegistrarIntento(string legajo, string fecha)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            // Datos a agregar
            string[] nuevoRegistro = { legajo, fecha };
            string lineaCSV = string.Join(";", nuevoRegistro);
            dataBaseUtils.AgregarRegistro("login_intentos.csv", lineaCSV);
        }
        public void BloquearUsuario(string legajo)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            dataBaseUtils.AgregarRegistro("usuario_bloqueado.csv", legajo);
        }

        public bool EstaBloqueado(string legajo)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();

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
                    existe=true;
                    break;
                }
            }

            return existe;
        }
    
        public void ActualizarContrasenia(string legajo, string nombreUsuario, string contrasena, string fechaAlta, string fechaUltimoLogin)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            dataBaseUtils.BorrarRegistro(legajo, "credenciales.csv");
            string[] nuevoRegistro = { legajo, nombreUsuario, contrasena, fechaAlta, fechaUltimoLogin };
            string lineaCSV = string.Join(";", nuevoRegistro);
            dataBaseUtils.AgregarRegistro("credenciales.csv", lineaCSV);
        }
    }

}
