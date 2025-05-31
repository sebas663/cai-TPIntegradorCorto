using Datos;
using Negocio.interfaces;
using System;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    /// <summary>
    /// Control de usuario que permite al usuario cambiar su contraseña.
    /// Realiza validaciones antes de actualizar la credencial en el sistema.
    /// </summary>
    public partial class FormContraseniaCambio : UserControl
    {
        private readonly IGestionUsuarioNegocio gestionUsuarioNegocio;
        private readonly Credencial usuarioLogueado;
        private const int MIN_CARACTERES_CONTRASENIA = 8;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="FormContraseniaCambio"/>.
        /// </summary>
        /// <param name="gestionUsuarioNegocio">Interfaz de negocio para gestión de usuarios.</param>
        /// <param name="logueado">Credencial del usuario autenticado.</param>
        /// <exception cref="ArgumentNullException">Si alguna dependencia es nula.</exception>
        public FormContraseniaCambio(IGestionUsuarioNegocio gestionUsuarioNegocio, Credencial logueado)
        {
            InitializeComponent();
            this.gestionUsuarioNegocio = gestionUsuarioNegocio ?? throw new ArgumentNullException(nameof(gestionUsuarioNegocio));
            this.usuarioLogueado = logueado ?? throw new ArgumentNullException(nameof(logueado));
        }

        /// <summary>
        /// Evento que se ejecuta al presionar el botón de cambio de contraseña.
        /// Realiza validaciones y actualiza la credencial si las validaciones son correctas.
        /// </summary>
        public void BtnCambioContrasenia_Click(object sender, EventArgs e)
        {
            string contraseniaActual = txtContraseniaActual.Text.Trim();
            string contraseniaNueva = txtContraseniaNueva.Text.Trim();
            string confirmarContraseniaNueva = txtConfirmarContraseniaNueva.Text.Trim();

            if (!ValidarCambioContrasenia(contraseniaActual, contraseniaNueva, confirmarContraseniaNueva))
                return;

            try
            {
                Credencial usuarioModificado = new Credencial
                {
                    Legajo = usuarioLogueado.Legajo,
                    NombreUsuario = usuarioLogueado.NombreUsuario,
                    Contrasena = contraseniaNueva,
                    FechaAlta = usuarioLogueado.FechaAlta,
                    FechaUltimoLogin = DateTime.Now
                };

                gestionUsuarioNegocio.ActualizarContrasenia(usuarioModificado);
                FormUtils.MostrarMensajeInformacion("La contraseña se cambió con éxito.");

                FabricaFormularios.Instancia.CrearFormLogin().Show();
                this.ParentForm?.Hide();
            }
            catch (Exception ex)
            {
                FormUtils.MostrarMensajeAdvertencia($"Error al cambiar la contraseña: {ex.Message}");
            }
        }

        /// <summary>
        /// Valida los datos ingresados por el usuario antes de proceder con el cambio de contraseña.
        /// </summary>
        /// <param name="contraseniaActual">Contraseña actual ingresada por el usuario.</param>
        /// <param name="contraseniaNueva">Nueva contraseña propuesta por el usuario.</param>
        /// <param name="confirmarContraseniaNueva">Confirmación de la nueva contraseña.</param>
        /// <returns><c>true</c> si todas las validaciones son correctas, <c>false</c> en caso contrario.</returns>
        private bool ValidarCambioContrasenia(string contraseniaActual, string contraseniaNueva, string confirmarContraseniaNueva)
        {
            if (string.IsNullOrWhiteSpace(contraseniaActual))
            {
                FormUtils.MostrarMensajeAdvertencia("La contraseña actual no puede estar vacía.");
                txtContraseniaActual.Focus();
                return false;
            }

            if (usuarioLogueado.Contrasena != contraseniaActual)
            {
                FormUtils.MostrarMensajeAdvertencia("La contraseña actual es incorrecta.");
                txtContraseniaActual.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(contraseniaNueva))
            {
                FormUtils.MostrarMensajeAdvertencia("La contraseña nueva no puede estar vacía.");
                txtContraseniaNueva.Focus();
                return false;
            }

            if (contraseniaNueva.Length < MIN_CARACTERES_CONTRASENIA)
            {
                FormUtils.MostrarMensajeAdvertencia($"La contraseña nueva debe tener al menos {MIN_CARACTERES_CONTRASENIA} caracteres.");
                txtContraseniaNueva.Focus();
                return false;
            }

            if (contraseniaNueva == contraseniaActual)
            {
                FormUtils.MostrarMensajeAdvertencia("La contraseña nueva debe ser distinta a la actual.");
                txtContraseniaNueva.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(confirmarContraseniaNueva))
            {
                FormUtils.MostrarMensajeAdvertencia("Debes confirmar la nueva contraseña.");
                txtConfirmarContraseniaNueva.Focus();
                return false;
            }

            if (confirmarContraseniaNueva != contraseniaNueva)
            {
                FormUtils.MostrarMensajeAdvertencia("No coincide la nueva contraseña con la confirmación.");
                txtConfirmarContraseniaNueva.Focus();
                return false;
            }

            return true;
        }
    }
}