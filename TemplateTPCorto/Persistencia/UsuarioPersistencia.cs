using Datos;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public List<String> Obtenerdatos(string archivo)
        {
            DataBaseUtils database = new DataBaseUtils();
            return database.BuscarRegistro(archivo);
        }
        public Perfil ObtenerPerfil(string legajo)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            string perfilId = ObtenerPerfilId(legajo);
            List<String> listado = dataBaseUtils.BuscarRegistro("perfil.csv");
            string perfilRegistro = "";
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
                    perfilRegistro = registro;
                    break;
                }
            }
            List<Rol> roles = ObtenerRolesPorPerfilId(perfilId);
            return new Perfil(perfilRegistro, roles);
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

        public List<Rol> ObtenerRolesPorPerfilId(string perfilId)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> rolIDs = ObtenerRolIdsPorPerfilId(perfilId);
            List<String> listado = dataBaseUtils.BuscarRegistro("rol.csv");
            List<Rol> roles = new List<Rol>();
            int contador = 0;
            foreach (String registro in listado)
            {
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                string[] campos = registro.Split(';');
                if (rolIDs.Contains(campos[0]))
                {
                    roles.Add(new Rol(registro));
                }
            }
            return roles;
        }
        private List<String> ObtenerRolIdsPorPerfilId(string perfilId)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> listado = dataBaseUtils.BuscarRegistro("perfil_rol.csv");
            List<String> listadoRolIds = new List<String>();
            int contador = 0;
            foreach (String registro in listado)
            {
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                string[] campos = registro.Split(';');
                if (campos[0] == perfilId)
                {
                    listadoRolIds.Add(campos[1]);
                }
            }
            return listadoRolIds;
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

        public void RegistrarOperacionCambioCredencial(string legajo, string nombreUsuario, string contrasena, string idperfil , string fechaAlta, string fechaUltimoLogin)
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
        public void RegistrarOperacionCambioPersona (string legajo, string nombre, string apellido, string DNI, string fechaingreso)
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
        public Persona BuscarPersonaPorNumeroLegajo(string legajo)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> listado = dataBaseUtils.BuscarRegistro("persona.csv");
            Persona datousuario = null;
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
                    datousuario = new Persona(registro);
                    break;
                }
            }
            return datousuario;
        }
        public void AutorizarRegistroCredencial(Credencial credencial)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            if(credencial != null)
            {
                dataBaseUtils.BorrarRegistro(credencial.Legajo, "Credencial.csv");
                string[] nuevoRegistro = { credencial.Legajo, credencial.NombreUsuario, credencial.Contrasena, credencial.FechaAlta.ToString("d/M/yyyy"), credencial.FechaUltimoLogin?.ToString("d/M/yyyy") };
                string lineaCSV = string.Join(";", nuevoRegistro);
                dataBaseUtils.AgregarRegistro("credenciales.csv", lineaCSV);
            }
            else
            {
                throw new Exception("No se puede agregar un registro nulo");
            }

        }

        public Credencial BuscarCredencialPorNumeroLegajo(string legajo)
        {
            Credencial credencialLogin = null;

            foreach (Credencial credencial in ObtenerCredenciales())
            {
                if (credencial.Legajo.Equals(legajo))
                {
                    credencialLogin = credencial;
                }
            }

            return credencialLogin;
        }

        public Persona AutorizarUsuario(string idoperacion)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> listado = Obtenerdatos("operacion_cambio_persona.csv");
            Persona usuario = null;
            int contador = 0;
            foreach (String registro in listado)
            {
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                String[] datos = registro.Split(';');
                if (datos[0] == idoperacion)
                {
                    string registrocredencial = string.Join(";", datos[1], datos[2], datos[3], datos[4], datos[5]);
                    usuario = new Persona(registrocredencial);
                    dataBaseUtils.BorrarRegistro(idoperacion, "operacion_cambio_persona.csv");
                    break;
                }
            }
            return usuario;
        }
        public Credencial AutorizarCredencial(string idoperacion)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> listado = Obtenerdatos("operacion_cambio_credencial.csv");
            Credencial credencial = null;
            int contador = 0;
            foreach (String registro in listado)
            {
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                String[] datos = registro.Split(';');
                if (datos[0] == idoperacion)
                {
                    string registrocredencial = string.Join(";", datos[1], datos[2], datos[3], datos[5], datos[6]);
                    credencial = new Credencial(registrocredencial);
                    dataBaseUtils.BorrarRegistro(idoperacion, "operacion_cambio_credencial.csv");
                    break;
                }
            }
            return credencial;
        }
        public void AutorizarRegistroUsuario(Credencial usuario)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            if (usuario != null)
            {
                dataBaseUtils.BorrarRegistro(usuario.Legajo, "persona.csv");
                string[] nuevoRegistro = { usuario.Legajo };
                string lineaCSV = string.Join(";", nuevoRegistro);
                dataBaseUtils.AgregarRegistro("persona.csv", lineaCSV);
            }
            else
            {
                throw new Exception("No se puede agregar un registro nulo");
            }

        }
    }

}
