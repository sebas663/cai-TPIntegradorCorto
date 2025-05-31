using Datos;
using Negocio.interfaces;
using System;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    /// <summary>
    /// Control de usuario para gestionar el desbloqueo de credenciales.
    /// Permite buscar usuarios por legajo y registrar la operación de desbloqueo de contraseña.
    /// </summary>
    public partial class FormDesbloquearCredencial : UserControl
    {
        private readonly IGestionUsuarioNegocio gestionUsuarioNegocio;
        private readonly IAutorizacionNegocio autorizacionNegocio;
        private readonly Credencial usuarioLogueado;
        private const int MIN_CARACTERES_CONTRASENIA = 8;
        private Credencial usuarioCambioCredencial;

        /// <summary>
        /// Constructor que inicializa la instancia de <see cref="FormDesbloquearCredencial"/>.
        /// </summary>
        /// <param name="gestionUsuarioNegocio">Interfaz de gestión de usuarios.</param>
        /// <param name="autorizacionNegocio">Interfaz de autorización.</param>
        /// <param name="logueado">Credencial del usuario autenticado.</param>
        public FormDesbloquearCredencial(IGestionUsuarioNegocio gestionUsuarioNegocio, IAutorizacionNegocio autorizacionNegocio, Credencial logueado)
        {
            InitializeComponent();
            this.gestionUsuarioNegocio = gestionUsuarioNegocio ?? throw new ArgumentNullException(nameof(gestionUsuarioNegocio));
            this.autorizacionNegocio = autorizacionNegocio ?? throw new ArgumentNullException(nameof(autorizacionNegocio));
            this.usuarioLogueado = logueado ?? throw new ArgumentNullException(nameof(logueado));

            OcultarCamposFormulario();
        }

        /// <summary>
        /// Evento que busca la credencial asociada al número de legajo ingresado.
        /// Si el usuario existe, se habilitan los controles para el desbloqueo.
        /// </summary>
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string legajo = txtLegajo.Text.Trim();

            if (string.IsNullOrWhiteSpace(legajo))
            {
                FormUtils.MostrarMensajeAdvertencia("El legajo no puede estar vacío.");
                txtLegajo.Focus();
                return;
            }

            usuarioCambioCredencial = gestionUsuarioNegocio.BuscarCredencialPorNumeroLegajo(legajo);
            if (usuarioCambioCredencial != null)
            {
                MostrarCamposFormulario();
                labelUsuario.Text = $"Usuario: {usuarioCambioCredencial.NombreUsuario}";
            }
            else
            {
                FormUtils.MostrarMensajeInformacion("No existe usuario para el número de legajo ingresado.");
                txtLegajo.Focus();
            }
        }

        /// <summary>
        /// Evento que realiza el desbloqueo de credencial, previa validación y confirmación del usuario.
        /// La operación queda pendiente de aprobación por el administrador.
        /// </summary>
        private void BtnDesbloqueoCredencial_Click(object sender, EventArgs e)
        {
            string legajo = txtLegajo.Text.Trim();
            string password = txtContraseniaNueva.Text.Trim();

            if (!ValidarDesbloqueoCredencial(password))
                return;

            DialogResult result = MessageBox.Show(
                $"¿Cambiar contraseña de legajo: {legajo}, usuario: {usuarioCambioCredencial.NombreUsuario}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                LimpiarFormulario();
                return;
            }

            try
            {
                Autorizacion autorizacion = new Autorizacion
                {
                    TipoOperacion = EnumTipoOperacion.CambioCredencial.ToString(),
                    Estado = EnumEstadoAutorizacion.Pendiente.ToString(),
                    LegajoSolicitante = usuarioLogueado.Legajo,
                    FechaSolicitud = DateTime.Now
                };

                Perfil perfil = gestionUsuarioNegocio.ObtenerPerfil(legajo);
                OperacionCambioCredencial operacion = new OperacionCambioCredencial
                {
                    Legajo = usuarioCambioCredencial.Legajo,
                    NombreUsuario = usuarioCambioCredencial.NombreUsuario,
                    Contrasena = password,
                    IdPerfil = perfil.Id,
                    FechaAlta = usuarioCambioCredencial.FechaAlta,
                    FechaUltimoLogin = usuarioCambioCredencial.FechaUltimoLogin.GetValueOrDefault()
                };

                autorizacionNegocio.RegistrarOperacionCambioCredencial(autorizacion, operacion);
                FormUtils.MostrarMensajeInformacion("La operación quedó pendiente de aprobación por parte del administrador.");
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                FormUtils.MostrarMensajeAdvertencia($"Error al registrar el desbloqueo de credencial: {ex.Message}");
            }
        }

        /// <summary>
        /// Valida que la nueva contraseña ingresada cumpla con los requisitos mínimos.
        /// </summary>
        /// <param name="password">Nueva contraseña ingresada.</param>
        /// <returns><c>true</c> si la contraseña es válida, <c>false</c> si no cumple los criterios.</returns>
        private bool ValidarDesbloqueoCredencial(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                FormUtils.MostrarMensajeAdvertencia("La contraseña nueva no puede estar vacía.");
                txtContraseniaNueva.Focus();
                return false;
            }

            if (password.Length < MIN_CARACTERES_CONTRASENIA)
            {
                FormUtils.MostrarMensajeAdvertencia($"La contraseña nueva debe tener al menos {MIN_CARACTERES_CONTRASENIA} caracteres.");
                txtContraseniaNueva.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Limpia los campos del formulario y oculta los controles de desbloqueo.
        /// </summary>
        private void LimpiarFormulario()
        {
            txtLegajo.Text = string.Empty;
            txtContraseniaNueva.Text = string.Empty;
            labelUsuario.Text = string.Empty;
            OcultarCamposFormulario();
            txtLegajo.Focus();
        }

        /// <summary>
        /// Oculta los controles de ingreso de credencial hasta que se busque un usuario válido.
        /// </summary>
        private void OcultarCamposFormulario()
        {
            labelUsuario.Visible = false;
            labelContraseniaNueva.Visible = false;
            txtContraseniaNueva.Visible = false;
            btnDesbloquearCredencial.Visible = false;
        }

        /// <summary>
        /// Muestra los controles de ingreso de credencial cuando un usuario válido es encontrado.
        /// </summary>
        private void MostrarCamposFormulario()
        {
            labelUsuario.Visible = true;
            labelContraseniaNueva.Visible = true;
            txtContraseniaNueva.Visible = true;
            btnDesbloquearCredencial.Visible = true;
        }
    }
}