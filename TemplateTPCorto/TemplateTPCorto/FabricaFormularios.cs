using Datos;
using Negocio;
using Negocio.interfaces;
using System;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    /// <summary>
    /// Clase fábrica que crea instancias de los formularios de la aplicación.
    /// Implementa los patrones de diseño **Fábrica** y **Singleton** para gestionar la creación de formularios.
    /// </summary>
    public class FabricaFormularios
    {
        private static FabricaFormularios instancia;
        private readonly ILoginNegocio loginNegocio;
        private readonly IGestionUsuarioNegocio gestionUsuarioNegocio;
        private readonly IAutorizacionNegocio autorizacionNegocio;
        private readonly IVentasNegocio ventasNegocio;
        private readonly IProductoNegocio productoNegocio;

        /// <summary>
        /// Constructor privado para evitar instanciación directa y garantizar el Singleton.
        /// </summary>
        /// <param name="loginNegocio">Interfaz de negocio de autenticación.</param>
        /// <param name="gestionUsuarioNegocio">Interfaz de negocio de gestión de usuarios.</param>
        /// <param name="autorizacionNegocio">Interfaz de negocio para gestión de autorizaciones.</param>
        /// <param name="ventasNegocio">Interfaz de negocio para gestión de las ventas.</param>
        /// <param name="productoNegocio">Interfaz de negocio para gestión de los productos.</param>
        private FabricaFormularios(
            ILoginNegocio loginNegocio,
            IGestionUsuarioNegocio gestionUsuarioNegocio,
            IAutorizacionNegocio autorizacionNegocio,
            IVentasNegocio ventasNegocio,
            IProductoNegocio productoNegocio
        )
        {
            this.loginNegocio = loginNegocio;
            this.gestionUsuarioNegocio = gestionUsuarioNegocio;
            this.autorizacionNegocio = autorizacionNegocio;
            this.ventasNegocio = ventasNegocio;
            this.productoNegocio = productoNegocio;
        }

        /// <summary>
        /// Inicializa la instancia única de <see cref="FabricaFormularios"/>.
        /// </summary>
        /// <param name="loginNegocio">Interfaz de negocio de autenticación.</param>
        /// <param name="gestionUsuarioNegocio">Interfaz de negocio de gestión de usuarios.</param>
        /// <param name="autorizacionNegocio">Interfaz de negocio para gestión de autorizaciones.</param>
        /// <param name="ventasNegocio">Interfaz de negocio para gestión de las ventas.</param>
        /// <param name="productoNegocio">Interfaz de negocio para gestión de los productos.</param>
        public static void Inicializar(
            ILoginNegocio loginNegocio,
            IGestionUsuarioNegocio gestionUsuarioNegocio,
            IAutorizacionNegocio autorizacionNegocio,
            IVentasNegocio ventasNegocio,
            IProductoNegocio productoNegocio
        )
        {
            if (instancia == null)
            {
                instancia = new FabricaFormularios(loginNegocio, gestionUsuarioNegocio, autorizacionNegocio,
                   ventasNegocio, productoNegocio);
            }
        }

        /// <summary>
        /// Obtiene la instancia única de <see cref="FabricaFormularios"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">Si la fábrica no ha sido inicializada previamente.</exception>
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

        /// <summary>
        /// Crea una instancia de <see cref="FormLogin"/>.
        /// </summary>
        /// <returns>Instancia de <see cref="FormLogin"/>.</returns>
        public FormLogin CrearFormLogin()
        {
            return new FormLogin(loginNegocio);
        }

        /// <summary>
        /// Crea una instancia de <see cref="FormMenu"/>.
        /// </summary>
        /// <param name="usuarioLogueado">Credencial del usuario autenticado.</param>
        /// <returns>Instancia de <see cref="FormMenu"/>.</returns>
        public FormMenu CrearFormMenu(Credencial usuarioLogueado)
        {
            return new FormMenu(loginNegocio, gestionUsuarioNegocio, usuarioLogueado);
        }

        /// <summary>
        /// Crea una instancia de <see cref="FormModificacionPersona"/>.
        /// </summary>
        /// <param name="usuario">Credencial del usuario autenticado.</param>
        /// <returns>Instancia de <see cref="FormModificacionPersona"/>.</returns>
        public UserControl CrearFormModificacionPersona(Credencial usuario)
        {
            return new FormModificacionPersona(gestionUsuarioNegocio, autorizacionNegocio, usuario);
        }

        /// <summary>
        /// Crea una instancia de <see cref="FormAutorizaciones"/>.
        /// </summary>
        /// <param name="usuario">Credencial del usuario autenticado.</param>
        /// <returns>Instancia de <see cref="FormAutorizaciones"/>.</returns>
        public UserControl CrearFormAutorizaciones(Credencial usuario)
        {
            return new FormAutorizaciones(gestionUsuarioNegocio, autorizacionNegocio, usuario);
        }

        /// <summary>
        /// Crea una instancia de <see cref="FormDesbloquearCredencial"/>.
        /// </summary>
        /// <param name="usuario">Credencial del usuario autenticado.</param>
        /// <returns>Instancia de <see cref="FormDesbloquearCredencial"/>.</returns>
        public UserControl CrearFormDesbloquearCredencial(Credencial usuario)
        {
            return new FormDesbloquearCredencial(gestionUsuarioNegocio, autorizacionNegocio, usuario);
        }

        /// <summary>
        /// Crea una instancia de <see cref="FormContraseniaCambio"/>.
        /// </summary>
        /// <param name="usuario">Credencial del usuario autenticado.</param>
        /// <returns>Instancia de <see cref="FormContraseniaCambio"/>.</returns>
        public UserControl CrearFormContraseniaCambio(Credencial usuario)
        {
            return new FormContraseniaCambio(gestionUsuarioNegocio, usuario);
        }

        /// <summary>
        /// Crea una instancia de <see cref="FormVentas"/>.
        /// </summary>
        /// <returns>Instancia de <see cref="FormVentas"/>.</returns>
        public UserControl CrearFormFormVentas()
        {
            return new FormVentas(ventasNegocio, productoNegocio);
        }
    }
}