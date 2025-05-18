using Negocio;
using Persistencia;
using Persistencia.DataBase;
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
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia(dataBaseUtils);
            LoginNegocio loginNegocio = new LoginNegocio(usuarioPersistencia);
            Application.Run(new FormLogin(loginNegocio));
        }
    }
}
