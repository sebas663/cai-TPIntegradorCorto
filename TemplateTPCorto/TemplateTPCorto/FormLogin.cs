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
        private readonly LoginNegocio loginNegocio;
        public FormLogin(LoginNegocio negocio)
        {
            InitializeComponent();
            this.loginNegocio = negocio;
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            String usuario = txtUsuario.Text;
            String password = txtPassword.Text;
            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("El nombre de usuario no puede estar vacio");
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("La contraseña no puede estar vacia.");
                txtPassword.Focus();
                return;
            }
            bool establoqueado = loginNegocio.EstaBloqueado(usuario);
            if (!establoqueado)
            {
                Credencial credencial = loginNegocio.Login(usuario, password);
                establoqueado = loginNegocio.EstaBloqueado(usuario);
                if (credencial == null && !establoqueado)
                {
                    MessageBox.Show("Alguno de los datos ingresados no es correcto.");

                }
                if (establoqueado)
                {
                    MessageBox.Show("El usuario esta bloqueado.");
                    return;

                }
                FormMenu menu = new FormMenu(loginNegocio, credencial);
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("El usuario esta bloqueado.");
            }
        }
    }
}