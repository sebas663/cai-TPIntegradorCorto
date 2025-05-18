using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public partial class FormContraseniaCambio : UserControl
    {
        private readonly LoginNegocio loginNegocio;
        private readonly Credencial usuarioLogueado;
        private const int MIN_CARACTERES_CONTRASENIA = 8;
        public FormContraseniaCambio(LoginNegocio loginNegocio, Credencial logueado)
        {
            InitializeComponent();
            this.loginNegocio = loginNegocio;
            this.usuarioLogueado = logueado;
        }

        public void BtnCambioContrasenia_Click(object sender, EventArgs e)
        {
            String contraseniaActual = txtContraseniaActual.Text;
            String contraseniaNueva = txtContraseniaNueva.Text;
            String confirmarContraseniaNueva = txtConfirmarContraseniaNueva.Text;

            if (string.IsNullOrEmpty(contraseniaActual))
            {
                MessageBox.Show("La contraseña actual no puede estar vacia.");
                txtContraseniaActual.Focus();
                return;
            }

            if (string.IsNullOrEmpty(contraseniaNueva))
            {
                MessageBox.Show("La contraseña nueva no puede estar vacia.");
                txtContraseniaNueva.Focus();
                return;
            }

            if (string.IsNullOrEmpty(confirmarContraseniaNueva))
            {
                MessageBox.Show("El confirmar contraseña nueva no puede estar vacio.");
                txtContraseniaActual.Focus();
                return;
            }
            if (usuarioLogueado.Contrasena != contraseniaActual)
            {
                MessageBox.Show("La contraseña actual es erronea.");
                txtContraseniaActual.Focus();
                return;
            }
            if (contraseniaNueva == contraseniaActual)
            {
                MessageBox.Show("La contraseña nueva debe ser distinta a la contraseña actual.");
                txtContraseniaNueva.Focus();
                return;
            }
            if (contraseniaNueva.Length < MIN_CARACTERES_CONTRASENIA)
            {
                MessageBox.Show("La contraseña nueve debe tener al menos 8 caracteres.");
                txtContraseniaNueva.Focus();
                return;
            }
            if (confirmarContraseniaNueva != contraseniaNueva)
            {
                MessageBox.Show("No coincide la contraseña nueva con el confirmar contraseña nueva.");
                txtConfirmarContraseniaNueva.Focus();
                return;
            }
            Credencial usuarioModificado = new Credencial
            {
                Legajo = usuarioLogueado.Legajo,
                NombreUsuario = usuarioLogueado.NombreUsuario,
                Contrasena = contraseniaNueva,
                FechaAlta = usuarioLogueado.FechaAlta,
                FechaUltimoLogin = DateTime.Now
            };

            loginNegocio.ActualizarContrasenia(usuarioModificado);
            MessageBox.Show("La contraseña se cambio con èxito.");
            new FormLogin(loginNegocio).Show();
            this.ParentForm.Hide();
        }

    }
}