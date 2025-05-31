using Datos;
using Negocio.interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    /// <summary>
    /// Representa el menú principal de la aplicación, configurando opciones de acuerdo al perfil del usuario autenticado.
    /// </summary>
    public partial class FormMenu : Form
    {
        private readonly ILoginNegocio loginNegocio;
        private readonly IGestionUsuarioNegocio gestionUsuarioNegocio;
        private readonly Credencial usuario;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="FormMenu"/>.
        /// </summary>
        /// <param name="loginNegocio">Interfaz de negocio de autenticación.</param>
        /// <param name="gestionUsuarioNegocio">Interfaz de negocio de gestión de usuarios.</param>
        /// <param name="usuarioLogueado">Usuario autenticado en el sistema.</param>
        /// <exception cref="ArgumentNullException">Si alguna dependencia es nula.</exception>
        public FormMenu(ILoginNegocio loginNegocio, IGestionUsuarioNegocio gestionUsuarioNegocio, Credencial usuarioLogueado)
        {
            InitializeComponent();
            this.loginNegocio = loginNegocio ?? throw new ArgumentNullException(nameof(loginNegocio));
            this.gestionUsuarioNegocio = gestionUsuarioNegocio ?? throw new ArgumentNullException(nameof(gestionUsuarioNegocio));
            this.usuario = usuarioLogueado ?? throw new ArgumentNullException(nameof(usuarioLogueado), "El usuario logueado no puede ser nulo.");

            ConfigurarMenuPorPerfilRol();
        }

        /// <summary>
        /// Configura la visibilidad de los botones del menú según el perfil y roles del usuario autenticado.
        /// </summary>
        private void ConfigurarMenuPorPerfilRol()
        {
            btnCerrarSession.Visible = true;
            
            OcultarBotonesMenu();

            bool esPrimerLogin = loginNegocio.EsPrimerLogin(usuario);
            bool esContraseniaExpirada = loginNegocio.EsContraseniaExpirada(usuario);

            if (esPrimerLogin || esContraseniaExpirada)
            {
                CargarUserControl(FabricaFormularios.Instancia.CrearFormContraseniaCambio(usuario));
                return;
            }

            Perfil perfil = gestionUsuarioNegocio.ObtenerPerfil(usuario.Legajo);

            if (perfil == null)
            {
                throw new InvalidOperationException("El perfil obtenido es inválido.");
            }

            MenuConfigurador configurador = new MenuConfigurador(perfil);
            Dictionary<string, Button> botones = new Dictionary<string, Button>
            {
                { "btnCambioContrasenia", btnCambioContrasenia },
                { "btnModificarPersona", btnModificarPersona },
                { "btnDesbloquearCredencial", btnDesbloquearCredencial },
                { "btnAutorizaciones", btnAutorizaciones },
                { "btnVentas", btnVentas }
            };

            configurador.ConfigurarBotones(botones);
        }

        /// <summary>
        /// Carga un control de usuario en el área principal de la ventana.
        /// </summary>
        /// <param name="userControl">Control de usuario a mostrar.</param>
        private void CargarUserControl(UserControl userControl)
        {
            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls.Clear();
            }

            userControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(userControl);
        }

        /// <summary>
        /// Abre el formulario de modificación de persona.
        /// </summary>
        private void BtnModificarPersona_Click(object sender, EventArgs e)
        {
            CargarUserControl(FabricaFormularios.Instancia.CrearFormModificacionPersona(usuario));
        }

        /// <summary>
        /// Abre el formulario de autorizaciones.
        /// </summary>
        private void BtnAutorizaciones_Click(object sender, EventArgs e)
        {
            CargarUserControl(FabricaFormularios.Instancia.CrearFormAutorizaciones(usuario));
        }

        /// <summary>
        /// Abre el formulario de desbloqueo de credencial.
        /// </summary>
        private void BtnDesbloquearCredencial_Click(object sender, EventArgs e)
        {
            CargarUserControl(FabricaFormularios.Instancia.CrearFormDesbloquearCredencial(usuario));
        }

        /// <summary>
        /// Abre el formulario de cambio de contraseña.
        /// </summary>
        private void BtnCambioContrasenia_Click(object sender, EventArgs e)
        {
            CargarUserControl(FabricaFormularios.Instancia.CrearFormContraseniaCambio(usuario));
        }

        /// <summary>
        /// Abre el formulario de ventas.
        /// </summary>
        private void BtnVentas_Click(object sender, EventArgs e)
        {
            CargarUserControl(FabricaFormularios.Instancia.CrearFormFormVentas(usuario));
        }

        /// <summary>
        /// Cierra la sesión actual y muestra el formulario de inicio de sesión.
        /// </summary>
        private void BtnCerrarSession_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                FabricaFormularios.Instancia.CrearFormLogin().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cerrar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Oculta los botones del menu.
        /// </summary>
        private void OcultarBotonesMenu()
        {
            btnCambioContrasenia.Visible = false;
            btnModificarPersona.Visible = false;
            btnDesbloquearCredencial.Visible = false;
            btnAutorizaciones.Visible = false;
            btnVentas.Visible = false;
        }
    }
}