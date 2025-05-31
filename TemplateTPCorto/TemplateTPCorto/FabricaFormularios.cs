using Datos;
using Negocio;
using Negocio.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    /// <summary>
    /// Crea las instancias de las clases formulario utilizando patron de diseño fabrica y singleton.
    /// </summary>
    public class FabricaFormularios
    {
        private static FabricaFormularios instancia;
        private readonly ILoginNegocio loginNegocio;
        private readonly IGestionUsuarioNegocio gestionUsuarioNegocio;
        private readonly IAutorizacionNegocio autorizacionNegocio;

        private FabricaFormularios(
            ILoginNegocio loginNegocio,
            IGestionUsuarioNegocio gestionUsuarioNegocio,
            IAutorizacionNegocio autorizacionNegocio
        )
        {
            this.loginNegocio = loginNegocio;
            this.gestionUsuarioNegocio = gestionUsuarioNegocio;
            this.autorizacionNegocio = autorizacionNegocio;
        }

        public static void Inicializar(
            ILoginNegocio loginNegocio,
            IGestionUsuarioNegocio gestionUsuarioNegocio,
            IAutorizacionNegocio autorizacionNegocio
        )
        {
            if (instancia == null)
            {
                instancia = new FabricaFormularios(loginNegocio, gestionUsuarioNegocio, autorizacionNegocio);
            }
        }

        public static FabricaFormularios Instancia
        {
            get
            {
                if (instancia == null)
                {
                    throw new InvalidOperationException("La fábrica no ha sido inicializada.");
                }
                return instancia;
            }
        }

        public FormLogin CrearFormLogin()
        { 
            return new FormLogin(loginNegocio);
        }
        public FormMenu CrearFormMenu(Credencial usuarioLogueado)
        {
            return new FormMenu(loginNegocio, gestionUsuarioNegocio, usuarioLogueado);
        }
        public UserControl CrearFormModificacionPersona(Credencial usuario)
        {
            return new FormModificacionPersona(gestionUsuarioNegocio, autorizacionNegocio, usuario);
        }
        public UserControl CrearFormAutorizaciones(Credencial usuario)
        {
            return new FormAutorizaciones(gestionUsuarioNegocio, autorizacionNegocio, usuario);
        }
        public UserControl CrearFormDesbloquearCredencial(Credencial usuario)
        {
            return new FormDesbloquearCredencial(gestionUsuarioNegocio, autorizacionNegocio, usuario);
        }
        public UserControl CrearFormContraseniaCambio(Credencial usuario)
        {
            return new FormContraseniaCambio(gestionUsuarioNegocio, usuario);
        }
        public UserControl CrearFormFormVentas(Credencial usuario)
        {
            return new FormVentas();
        }
    }
}
