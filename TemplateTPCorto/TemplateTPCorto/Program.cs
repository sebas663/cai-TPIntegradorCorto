using Negocio;
using Negocio.interfaces;
using Persistencia;
using Persistencia.DataBase;
using Persistencia.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Utilitario para persistencia
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            // Implementaciones de las interfaces persistencia
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia(dataBaseUtils);
            IAutorizacionPersistencia autorizacionPersistencia = new AutorizacionPersistencia(dataBaseUtils);
            IGestionUsuarioPersistencia gestionUsuarioPersistencia = new GestionUsuarioPersistencia(dataBaseUtils);
            // Implementaciones de las interfaces negocio
            ILoginNegocio loginNegocio = new LoginNegocio(usuarioPersistencia);
            IGestionUsuarioNegocio gestionUsuarioNegocio = new GestionUsuarioNegocio(gestionUsuarioPersistencia);
            IAutorizacionNegocio autorizacionNegocio = new AutorizacionNegocio(autorizacionPersistencia);
            //Inicializaciòn de la fabrica de formularios
            FabricaFormularios.Inicializar(loginNegocio, gestionUsuarioNegocio, autorizacionNegocio);
            Application.Run(FabricaFormularios.Instancia.CrearFormLogin());
        }
    }
}
