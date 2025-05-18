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
        public FormLogin(LoginNegocio loginNegocio)
        {
            InitializeComponent();
            this.loginNegocio = loginNegocio;
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            String usuario = txtUsuario.Text;
            String password = txtPassword.Text;
            if (string.IsNullOrEmpty(usuario))
            {
                FormUtils.MostrarMensajeAdvertencia("El Nombre de usuario no puede estar vacio.");
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                FormUtils.MostrarMensajeAdvertencia("La Contraseña no puede estar vacia.");
                txtPassword.Focus();
                return;
            }
            bool establoqueado = loginNegocio.EstaBloqueado(usuario);
            string usuarioBloqueadoMsg = "El usuario " + usuario + " esta bloqueado.";
            if (!establoqueado)
            {
                Credencial credencial = loginNegocio.Login(usuario, password);
                establoqueado = loginNegocio.EstaBloqueado(usuario);
                if (credencial == null && !establoqueado)
                {
                    FormUtils.MostrarMensajeAdvertencia("Alguno de los datos ingresados no es correcto.");
                    return;
                }
                if (establoqueado)
                {
                    FormUtils.MostrarMensajeAdvertencia(usuarioBloqueadoMsg);
                    return;
                }
                FormMenu menu = new FormMenu(loginNegocio, credencial);
                menu.Show();
                this.Hide();
            }
            else
            {
                FormUtils.MostrarMensajeAdvertencia(usuarioBloqueadoMsg);
            }
        }
    }
}