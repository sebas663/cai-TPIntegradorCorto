using Negocio;
using Negocio.interfaces;
using Persistencia;
using Persistencia.DataBase;
using Persistencia.interfaces;
using System;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    /// <summary>
    /// Clase principal que sirve como punto de entrada a la aplicación.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada de la aplicación Windows Forms.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Configurar dependencias antes de ejecutar la aplicación
            ConfigurarDependencias();

            // Ejecutar la aplicación con el formulario de inicio de sesión
            Application.Run(FabricaFormularios.Instancia.CrearFormLogin());
        }

        /// <summary>
        /// Configura e inicializa las dependencias de persistencia y negocio,
        /// luego inicializa la fábrica de formularios, que es un Singleton.
        /// </summary>
        private static void ConfigurarDependencias()
        {
            // Inicializar utilidad de persistencia
            DataBaseUtils dataBaseUtils = new DataBaseUtils();

            // Instanciar persistencias
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia(dataBaseUtils);
            IAutorizacionPersistencia autorizacionPersistencia = new AutorizacionPersistencia(dataBaseUtils);
            IGestionUsuarioPersistencia gestionUsuarioPersistencia = new GestionUsuarioPersistencia(dataBaseUtils);

            // Instanciar capas de negocio
            ILoginNegocio loginNegocio = new LoginNegocio(usuarioPersistencia);
            IGestionUsuarioNegocio gestionUsuarioNegocio = new GestionUsuarioNegocio(gestionUsuarioPersistencia);
            IAutorizacionNegocio autorizacionNegocio = new AutorizacionNegocio(autorizacionPersistencia, gestionUsuarioNegocio, loginNegocio);

            // Inicializar la fábrica de formularios (Singleton)
            FabricaFormularios.Inicializar(loginNegocio, gestionUsuarioNegocio, autorizacionNegocio);
        }
    }
}