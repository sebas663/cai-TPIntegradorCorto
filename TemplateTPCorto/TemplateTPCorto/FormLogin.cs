using Datos;
using Negocio.interfaces;
using System;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    /// <summary>
    /// Representa la pantalla de inicio de sesión para la aplicación.
    /// Permite validar credenciales y redirigir al menú principal en caso de éxito.
    /// </summary>
    public partial class FormLogin : Form
    {
        private readonly ILoginNegocio loginNegocio;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="FormLogin"/>.
        /// </summary>
        /// <param name="loginNegocio">Interfaz de negocio de autenticación.</param>
        /// <exception cref="ArgumentNullException">Si la dependencia es nula.</exception>
        public FormLogin(ILoginNegocio loginNegocio)
        {
            InitializeComponent();
            this.loginNegocio = loginNegocio ?? throw new ArgumentNullException(nameof(loginNegocio));
        }

        /// <summary>
        /// Evento que se ejecuta cuando el usuario presiona el botón de ingreso.
        /// Realiza validaciones y gestiona el acceso a la aplicación.
        /// </summary>
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (!ValidarCampos(usuario, password))
                return;

            if (loginNegocio.EstaBloqueado(usuario))
            {
                FormUtils.MostrarMensajeAdvertencia($"El usuario {usuario} está bloqueado.");
                return;
            }

            try
            {
                Credencial credencial = loginNegocio.Login(usuario, password);

                if (credencial == null)
                {
                    FormUtils.MostrarMensajeAdvertencia("Alguno de los datos ingresados no es correcto.");
                    return;
                }

                if (loginNegocio.EstaBloqueado(usuario))
                {
                    FormUtils.MostrarMensajeAdvertencia($"El usuario {usuario} ha sido bloqueado tras intentos fallidos.");
                    return;
                }

                AbrirMenu(credencial);
            }
            catch (Exception ex)
            {
                FormUtils.MostrarMensajeAdvertencia($"Error al procesar el login: {ex.Message}");
            }
        }

        /// <summary>
        /// Valida que los campos de usuario y contraseña no estén vacíos antes de procesar el inicio de sesión.
        /// </summary>
        /// <param name="usuario">Nombre de usuario ingresado.</param>
        /// <param name="password">Contraseña ingresada.</param>
        /// <returns><c>true</c> si ambos campos son válidos, <c>false</c> de lo contrario.</returns>
        private bool ValidarCampos(string usuario, string password)
        {
            if (string.IsNullOrWhiteSpace(usuario))
            {
                FormUtils.MostrarMensajeAdvertencia("El nombre de usuario no puede estar vacío.");
                txtUsuario.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                FormUtils.MostrarMensajeAdvertencia("La contraseña no puede estar vacía.");
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Oculta el formulario actual y muestra el menú principal tras una autenticación exitosa.
        /// </summary>
        /// <param name="credencial">Credencial del usuario autenticado.</param>
        private void AbrirMenu(Credencial credencial)
        {
            FormMenu menu = FabricaFormularios.Instancia.CrearFormMenu(credencial);
            menu.Show();
            this.Hide();
        }
    }
}