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
    public partial class FormMenu : Form
    {
        private Credencial usuario;
        public FormMenu(Credencial usuarioLogueado)
        {
            InitializeComponent();
            usuario = usuarioLogueado;
            ConfigurarMenuPorPerfilRol();
        }

        private void ConfigurarMenuPorPerfilRol()
        {
            btnCerrarSession.Visible = true;
            btnCambioContrasenia.Visible = false;
            btnModificarPersona.Visible = false;
            btnDesbloquearCredencial.Visible = false;
            btnAutorizaciones.Visible = false;

            LoginNegocio loginNegocio = new LoginNegocio();
            bool esPrimerLogin = loginNegocio.EsPrimerLogin(usuario);
            bool esContraseniaExpirada = loginNegocio.EsContraseniaExpirada(usuario);
            if (esPrimerLogin || esContraseniaExpirada)
            {
                CargarUserControl(new FormContraseniaCambio(usuario));
            }
            else 
            {
                string perfil = loginNegocio.ObtenerPerfil(usuario.Legajo);
                if (perfil == "Operador")
                {
                    btnCambioContrasenia.Visible = true;
                }
                if (perfil == "Supervisor")
                {
                    btnCambioContrasenia.Visible = true;
                    btnModificarPersona.Visible = true;
                    btnDesbloquearCredencial.Visible = true;
                }
                if (perfil == "Administrador")
                {
                    btnCambioContrasenia.Visible = true;
                    btnAutorizaciones.Visible = true;
                }
            }
        }

        private void CargarUserControl(UserControl userControl)
        {
            panelMain.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(userControl);
        }

        private void btnModificarPersona_Click(object sender, EventArgs e)
        {

        }

        private void btnAutorizaciones_Click(object sender, EventArgs e)
        {

        }

        private void btnDesbloquearCredencial_Click(object sender, EventArgs e)
        {

        }

        private void btnCambioContrasenia_Click(object sender, EventArgs e)
        {
            CargarUserControl(new FormContraseniaCambio(usuario));
        }

        private void btnCerrarSession_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormLogin().Show();
        }

    }
}
