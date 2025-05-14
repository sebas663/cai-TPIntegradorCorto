using Datos;
using Datos.Login;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        public List<String> Obtenerdatos(string archivo)
        {
            DataBaseUtils database = new DataBaseUtils();
            return database.BuscarRegistro(archivo);
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
        private List<String> ObtenerRolperfil(string legajo)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> listado = dataBaseUtils.BuscarRegistro("perfil_rol.csv");
            string perfil = ObtenerPerfilId(legajo);
            List<String> listadoRol = new List<String>();
            int contador = 0;
            foreach (String registro in listado)
            {
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                string[] campos = registro.Split(';');
                if (campos[0] == perfil)
                {
                    listadoRol.Add(campos[1]);
                }
            }
            return listadoRol;
        }
        public List<String> ObtenerRol(string legajo)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> listado = dataBaseUtils.BuscarRegistro("rol.csv");
            List<String> listadoRol = ObtenerRolperfil(legajo);
            List<String> listadoRolNombre = new List<String>();
            int contador = 0;
            foreach (String registro in listado)
            {
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                string[] campos = registro.Split(';');
                if (listadoRol.Contains(campos[0]))
                {
                    listadoRolNombre.Add(campos[1]);
                }
            }
            return listadoRolNombre;
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

        public void ContraseñaSupervisor(string legajo, string nombreUsuario, string contrasena, string idperfil , string fechaAlta, string fechaUltimoLogin)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> listado = dataBaseUtils.BuscarRegistro("operacion_cambio_credencial.csv");
            int contador = 0;
            int contador1 = 0;
            foreach (String registro in listado)
            {
                String[] datos = registro.Split(';');
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                if (int.Parse(datos[0]) <= contador1)
                {
                    contador1 = int.Parse(datos[0]);
                }
            }
            contador1++;
            string[] nuevoRegistro = { Convert.ToString(contador1), legajo, nombreUsuario, contrasena, idperfil, fechaAlta, fechaUltimoLogin };
            string lineaCSV = string.Join(";", nuevoRegistro);
            dataBaseUtils.AgregarRegistro("operacion_cambio_credencial.csv", lineaCSV);
        }
        public Datousuario ObtenerPersona(string legajo)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> listado = dataBaseUtils.BuscarRegistro("persona.csv");
            Datousuario datousuario = null;
            int contador = 0;
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
                    datousuario.Legajo = datos[0];
                    datousuario.Nombre = datos[1];
                    datousuario.Apellido = datos[2];
                    datousuario.DNI = int.Parse(datos[3]);
                    datousuario.FechaIngreso = DateTime.ParseExact(datos[4], "d/M/yyyy", CultureInfo.InvariantCulture);
                    break;
                }
            }
            return datousuario;
        }
        public void ModificarPersona (string legajo, string nombre, string apellido, string DNI, string fechaingreso)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> listado = dataBaseUtils.BuscarRegistro("operacion_cambio_persona.csv");
            int contador = 0;
            int contador1 = 0;
            foreach (String registro in listado)
            {
                String[] datos = registro.Split(';');
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                if (int.Parse(datos[0]) <= contador1)
                {
                    contador1 = int.Parse(datos[0]);
                }
            }
            contador1++;
            string[] nuevoRegistro = { Convert.ToString(contador1), legajo, nombre, apellido, DNI, fechaingreso };
            string lineaCSV = string.Join(";", nuevoRegistro);
            dataBaseUtils.AgregarRegistro("operacion_cambio_persona", lineaCSV);
        }
    }
}
