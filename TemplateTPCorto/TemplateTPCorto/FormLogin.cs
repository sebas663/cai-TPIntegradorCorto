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
                       FormMenu menu = new FormMenu(credencial);
                       menu.Show();
                       this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("El usuario esta bloqueado.");
                }

            }
        }
    }
}