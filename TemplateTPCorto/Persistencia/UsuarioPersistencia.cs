using Datos;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class UsuarioPersistencia
    {
        private DataBaseUtils dataBaseUtils = new DataBaseUtils();

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
