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
    public partial class FormContraseniaCambio : FormMenuBase
    {
        private Form formularioAnterior;
        private Credencial usuario;
        private const int MIN_CARACTERES_CONTRASENIA = 8;
        private bool essupervisor;
        public FormContraseniaCambio(Form anterior, Credencial logueado, bool essupervisor=false)
        {
            InitializeComponent();
            btnCerrarSession.Click += btnCerrarSession_Click;
            formularioAnterior = anterior;
            usuario = logueado;
            this.essupervisor = essupervisor;
            if (essupervisor==true)
            {
                txtContraseniaActual.ReadOnly = true;
            }
        }

        public void btnCambioContrasenia_Click(object sender, EventArgs e)
        {
            String contraseniaActual = txtContraseniaActual.Text;
            String contraseniaNueva = txtContraseniaNueva.Text;
            String confirmarContraseniaNueva = txtConfirmarContraseniaNueva.Text;

            Boolean permiteAvanzar = true;

            if (contraseniaActual == "" && this.essupervisor==false)
            {
                permiteAvanzar = false;
                MessageBox.Show("La contraseña actual no puede estar vacia.");
                txtContraseniaActual.Focus();
                return;
            }

            if (contraseniaNueva == "" )
            {
                permiteAvanzar = false;
                MessageBox.Show("La contraseña nueva no puede estar vacia.");
                txtContraseniaNueva.Focus();
                return;
            }

            if (confirmarContraseniaNueva == "")
            {
                permiteAvanzar = false;
                MessageBox.Show("El confirmar contraseña nueva no puede estar vacio.");
                txtContraseniaActual.Focus();
                return;
            }
            if (usuario.Contrasena != contraseniaActual && this.essupervisor == false)
            {
                permiteAvanzar = false;
                MessageBox.Show("La contraseña actual es erronea.");
                txtContraseniaActual.Focus();
                return;
            }
            if (contraseniaNueva == contraseniaActual && this.essupervisor == false)
            {
                permiteAvanzar = false;
                MessageBox.Show("La contraseña nueva debe ser distinta a la contraseña actual.");
                txtContraseniaNueva.Focus();
                return;
            }
            if (contraseniaNueva.Length < MIN_CARACTERES_CONTRASENIA)
            {
                permiteAvanzar = false;
                MessageBox.Show("La contraseña nueve debe tener al menos 8 caracteres.");
                txtContraseniaNueva.Focus();
                return;
            }
            if (confirmarContraseniaNueva != contraseniaNueva)
            {
                permiteAvanzar = false;
                MessageBox.Show("No coincide la contraseña nueva con el confirmar contraseña nueva.");
                txtConfirmarContraseniaNueva.Focus();
                return;
            }

            if (permiteAvanzar && this.essupervisor == false) {
                LoginNegocio loginNegocio = new LoginNegocio();
                usuario.Contrasena = contraseniaNueva;
                usuario.FechaUltimoLogin = DateTime.Now;
                loginNegocio.ActualizarContrasenia(usuario);
                MessageBox.Show("La contraseña se cambio con èxito.");
                Volver();
            }
            if (permiteAvanzar && this.essupervisor == true)
            {
                LoginNegocio loginNegocio = new LoginNegocio();
                usuario.Contrasena = contraseniaNueva;
                loginNegocio.Supervisorcredenciales(usuario);
                MessageBox.Show("La contraseña se cambio con èxito.");
                Volver();
            }
        }

        
        public void btnVolver_Click(object sender, EventArgs e)
        {
            Volver();
        }

        private void Volver()
        {
            if (formularioAnterior != null && !formularioAnterior.IsDisposed)
            {
                formularioAnterior.Show();
            }
            this.Hide();
        }

    }
}
