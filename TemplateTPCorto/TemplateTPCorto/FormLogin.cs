using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private GestorLogin gestor = new GestorLogin();
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            String usuario = txtUsuario.Text;
            String password = txtPassword.Text;

            LoginNegocio loginNegocio = new LoginNegocio();
            Credencial credencial = loginNegocio.login(usuario, password);

            if (gestor.EstaBloqueado(usuario))
            {
                MessageBox.Show("Este usuario está bloqueado.");
                return;
            }

            if (gestor.ValidarCredenciales(usuario, password))
            {
                MessageBox.Show("Login exitoso.");
                gestor.LimpiarIntentos(usuario);
                // Lógica de redirección o acceso
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
                gestor.RegistrarIntentoFallido(usuario);
            }


        }

        

    }
}
