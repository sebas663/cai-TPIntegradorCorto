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
                    Credencial credencial = loginNegocio.Login(usuario, password);
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
                        //this.Hide();
                        //FormMenu formMenu = new FormMenu();
                        //formMenu.ShowDialog();
                        MessageBox.Show("Se logueo");
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
