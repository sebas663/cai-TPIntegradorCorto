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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TemplateTPCorto
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            String usuario = txtUsuario.Text;
            String password = txtPassword.Text;

            Boolean permiteAvanzar = true;

            if (usuario == "")
            {
                permiteAvanzar = false;
                MessageBox.Show("El nombre de usuario no puede estar vacio");
                txtUsuario.Focus();
                return;
            }

            if (password == "")
            {
                permiteAvanzar = false;
                MessageBox.Show("La contraseña no puede estar vacia.");
                txtPassword.Focus();
                return;
            }

            if (permiteAvanzar)
            {
                LoginNegocio loginNegocio = new LoginNegocio();
                bool establoqueado = loginNegocio.EstaBloqueado(usuario);
                if (!establoqueado)
                {
                    Credencial credencial = loginNegocio.login(usuario, password);
                    establoqueado = loginNegocio.EstaBloqueado(usuario);
                    if (credencial == null && !establoqueado)
                    {
                        MessageBox.Show("Alguno de los datos ingresados no es correcto.");
                        permiteAvanzar = false;

                    }
                    if (establoqueado)
                    {
                        MessageBox.Show("El usuario esta bloqueado.");
                        permiteAvanzar = false;

                    }
                    if (permiteAvanzar)
                    {
                        bool esPrimerLogin = loginNegocio.EsPrimerLogin(credencial);
                        bool esContraseniaExpirada = loginNegocio.EsContraseniaExpirada(credencial);
                        if (esPrimerLogin || esContraseniaExpirada)
                        {
                            this.Hide();
                            FormContraseniaCambio formContrasenia = new FormContraseniaCambio(this, credencial, true);
                            formContrasenia.FormClosed += FormContrasenia_FormClosed;
                            formContrasenia.Show();
                        }
                        else
                        {
                            AbrirMenu(credencial);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El usuario esta bloqueado.");
                }

            }
        }

        private void AbrirMenu(Credencial logueado)
        {
            LoginNegocio loginNegocio = new LoginNegocio();
            string perfil = loginNegocio.ObtenerPerfil(logueado.Legajo);
            Form formMenu = null;
            if (perfil == "Operador") formMenu = new FormOperador(this, logueado);
            if (perfil == "Supervisor") formMenu = new FormSupervisor(logueado);
            if (perfil == "Administrador") formMenu = new FormAdministrador(logueado);
            if (formMenu != null)
            {
                formMenu.FormClosed += FormMenu_FormClosed;
                this.Hide();
                formMenu.Show();
            }
            else
            {
                MessageBox.Show("Perfil no reconocido.");
            }
        }
        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            LimpiarCamposLogin();
        }

        private void FormContrasenia_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            LimpiarCamposLogin();
        }
        private void LimpiarCamposLogin()
        {
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsuario.Focus();
        }

    }
}