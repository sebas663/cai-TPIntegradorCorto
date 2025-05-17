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

        public Credencial ObtenerCredencialPorLegajo(String legajo)
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
                string[] campos = registro.Split(';');
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
                if (datos[0] == legajo)
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
                    existe = true;
                    break;
                }
            }

            return existe;
        }

        public void ActualizarContrasenia(Credencial credencial)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            string legajo = credencial.Legajo;
            string nombreUsuario = credencial.NombreUsuario;
            string contrasena = credencial.Contrasena;
            string fechaAlta = credencial.FechaAlta.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            string fechaUltimoLogin = credencial.FechaUltimoLogin?.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            string[] nuevoRegistro = { legajo, nombreUsuario, contrasena, fechaAlta, fechaUltimoLogin };
            string lineaCSV = string.Join(";", nuevoRegistro);
            dataBaseUtils.BorrarRegistro(legajo, "credenciales.csv");
            dataBaseUtils.AgregarRegistro("credenciales.csv", lineaCSV);
        }

        public void RegistrarOperacionCambioCredencial(OperacionCambioCredencial operacion)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            string idOperacion = operacion.IdOperacion;
            string legajo = operacion.Legajo;
            string nombreUsuario = operacion.NombreUsuario;
            string contrasena = operacion.Contrasena;
            string fechaAlta = operacion.FechaAlta.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            string fechaUltimoLogin = operacion.FechaUltimoLogin.ToString("d/M/yyyy", CultureInfo.InvariantCulture); ;
            string idperfil = operacion.IdPerfil;
            string[] nuevoRegistro = { idOperacion, legajo, nombreUsuario, contrasena, idperfil, fechaAlta, fechaUltimoLogin };
            string lineaCSV = string.Join(";", nuevoRegistro);
            dataBaseUtils.AgregarRegistro("operacion_cambio_credencial.csv", lineaCSV);
        }
        public void RegistrarOperacionCambioPersona(OperacionCambioPersona operacion)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            string idOperacion = operacion.IdOperacion;
            string legajo = operacion.Legajo;
            string nombre = operacion.Nombre;
            string apellido = operacion.Apellido;
            string dni = operacion.Dni;
            string fechaingreso = operacion.FechaIngreso.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            string[] nuevoRegistro = { idOperacion, legajo, nombre, apellido, dni, fechaingreso };
            string lineaCSV = string.Join(";", nuevoRegistro);
            dataBaseUtils.AgregarRegistro("operacion_cambio_persona.csv", lineaCSV);
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

        public void EliminarOperacionCambioPersonaPorIdOperacion(string idOperacion)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> listado = dataBaseUtils.BuscarRegistro("operacion_cambio_persona.csv");
            int contador = 0;
            foreach (String registro in listado)
            {
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                String[] datos = registro.Split(';');
                if (datos[0] == idOperacion)
                {
                    dataBaseUtils.BorrarRegistro(idOperacion, "operacion_cambio_persona.csv");
                    break;
                }
            }
        }
        public void EliminarOperacionCambioCredencialPorIdOperacion(string idOperacion)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> listado = dataBaseUtils.BuscarRegistro("operacion_cambio_credencial.csv");
            int contador = 0;
            foreach (String registro in listado)
            {
                if (contador == 0)
                {
                    contador++;
                    continue;
                }
                String[] datos = registro.Split(';');
                if (datos[0] == idOperacion)
                {
                    dataBaseUtils.BorrarRegistro(idOperacion, "operacion_cambio_credencial.csv");
                    break;
                }
            }
        }

        public void EliminarUsuarioBloqueadoPorLegajo(string legajo)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> listado = dataBaseUtils.BuscarRegistro("usuario_bloqueado.csv");
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
                    dataBaseUtils.BorrarRegistro(legajo, "usuario_bloqueado.csv");
                    break;
                }
            }
        }

        public List<OperacionCambioCredencial> ObtenerOperacionesCambioCredencial()
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> listado = dataBaseUtils.BuscarRegistro("operacion_cambio_credencial.csv");
            List<OperacionCambioCredencial> listadoCredenciales = new List<OperacionCambioCredencial>();

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

                listadoCredenciales.Add(new OperacionCambioCredencial(registro));
            }

            return listadoCredenciales;
        }

        public List<OperacionCambioPersona> ObtenerOperacionesCambioPersona()
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> listado = dataBaseUtils.BuscarRegistro("operacion_cambio_persona.csv");
            List<OperacionCambioPersona> listadoCredenciales = new List<OperacionCambioPersona>();

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

                listadoCredenciales.Add(new OperacionCambioPersona(registro));
            }

            return listadoCredenciales;
        }

        public void ModificarPersonaPorLegajo(Persona modificada)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            dataBaseUtils.BorrarRegistro(modificada.Legajo, "persona.csv");
            string fechaIngreso = modificada.FechaIngreso.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            string[] nuevoRegistro = {
                modificada.Legajo,
                modificada.Nombre,
                modificada.Apellido,
                modificada.Dni,
                fechaIngreso,
            };
            string lineaCSV = string.Join(";", nuevoRegistro);
            dataBaseUtils.AgregarRegistro("persona.csv", lineaCSV);
        }

        public void ReiniciarIntentos(string legajo)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            dataBaseUtils.BorrarRegistro(legajo, "login_intentos.csv");
        }
        

        public List<Autorizacion> ObtenerAutorizacionesPorTipoOperacion(string tipoOperacion)
        {
            List<Autorizacion> lista = new List<Autorizacion>();

            foreach (Autorizacion item in ObtenerAutorizaciones())
            {
                if (item.TipoOperacion == tipoOperacion)
                {
                    lista.Add(item);
                }
            }

            return lista;
        }
        public List<Autorizacion> ObtenerAutorizaciones()
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> listado = dataBaseUtils.BuscarRegistro("autorizacion.csv");
            List<Autorizacion> listadoCredenciales = new List<Autorizacion>();

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

                listadoCredenciales.Add(new Autorizacion(registro));
            }

            return listadoCredenciales;
        }

        public string CrearAutorizacion(Autorizacion autorizacion)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> listado = dataBaseUtils.BuscarRegistro("autorizacion.csv");
            string tipoOperacion = autorizacion.TipoOperacion;
            string estado = autorizacion.Estado;
            string legajoSolicitante = autorizacion.LegajoSolicitante;
            string fechaSolicitud = autorizacion.FechaSolicitud.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            string legajoAutorizador = autorizacion.LegajoAutorizador;
            string fechaAutorizacion = autorizacion.FechaAutorizacion?.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            // El archivo siempre tiene 1 registro demas, es el de los nombres de las columnas.
            // entonces el primer id es 1 
            string idOperacion = listado.Count.ToString();
            string[] nuevoRegistro = {
                idOperacion,
                tipoOperacion,
                estado,
                legajoSolicitante,
                fechaSolicitud,
                legajoAutorizador,
                fechaAutorizacion
            };
            string lineaCSV = string.Join(";", nuevoRegistro);
            dataBaseUtils.AgregarRegistro("autorizacion.csv", lineaCSV);
            return idOperacion;
        }
    }

}