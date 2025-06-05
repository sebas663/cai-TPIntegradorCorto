using Datos;
using Persistencia.DataBase;
using Persistencia.interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class GestionUsuarioPersistencia:IGestionUsuarioPersistencia
    {
        private readonly DataBaseUtils dataBaseUtils;
        public GestionUsuarioPersistencia(DataBaseUtils dataBaseUtils)
        {
            this.dataBaseUtils = dataBaseUtils;
        }
        public void ActualizarContrasenia(Credencial credencial)
        {
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
        public Persona BuscarPersonaPorNumeroLegajo(string legajo)
        {
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
        public Perfil ObtenerPerfil(string legajo)
        {
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
        public void DesbloquearUsuarioBloqueadoPorLegajo(string legajo)
        {
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
        public void ActualizarDatosPersonaPorLegajo(Persona modificada)
        {
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
        private string ObtenerPerfilId(string legajo)
        {
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
        private List<Rol> ObtenerRolesPorPerfilId(string perfilId)
        {
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
