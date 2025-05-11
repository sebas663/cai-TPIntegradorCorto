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

            if (txtUsuario.Text == "")
            {
                permiteAvanzar = false;
                MessageBox.Show("El nombre de usuario no puede estar vacio");
            }

            if (txtPassword.Text == "")
            {
                permiteAvanzar = false;
                MessageBox.Show("La contraseña no puede estar vacia.");
            }
 
            if (permiteAvanzar)
            {
                LoginNegocio loginNegocio = new LoginNegocio();
                bool establoqueado = loginNegocio.EstaBloqueado(usuario);
                if (!establoqueado)
                {
                    Credencial credencial = loginNegocio.login(usuario, password);
                    if (credencial == null || (credencial.EsContrasenaIncorrecta && !credencial.EstaBloqueado))
                    {
                        MessageBox.Show("Alguno de los datos ingresados no es correcto.");
                        permiteAvanzar = false;

                    }
                    if (credencial.EstaBloqueado)
                    {
                        MessageBox.Show("El usuario esta bloqueado.");
                        permiteAvanzar = false;

                    }
                    if (permiteAvanzar)
                    {
                        AbrirMenu(credencial);
                    }
                }
                else
                {
                    MessageBox.Show("El usuario esta bloqueado.");
                }
                
            }
        }

        private void AbrirMenu(Credencial credencial)
        {
            this.Hide();
            LoginNegocio loginNegocio = new LoginNegocio();
            string perfil = loginNegocio.ObtenerPerfil(credencial.Legajo);
            Form formMenu = null;
            if (perfil == "Operador")
            {
                formMenu = new FormOperador();
            }
            if (perfil == "Supervisor")
            {
                formMenu = new FormSupervisor();
            }
            if (perfil == "Administrador")
            {
                formMenu = new FormAdministrador();
            }
            if (formMenu != null) {
                formMenu.FormClosed += FormMenu_FormClosed;
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
        private void LimpiarCamposLogin()
        {
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsuario.Focus();
        }

    }
}
