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
                Perfil perfil = loginNegocio.ObtenerPerfil(usuario.Legajo);
                // operador
                if (perfil.Id == "1" && loginNegocio.TieneRol(perfil.Roles, "5"))
                {
                    btnCambioContrasenia.Visible = true;
                }
                // supervisor
                if (perfil.Id == "2")
                {
                    btnCambioContrasenia.Visible = true;
                    if (loginNegocio.TieneRol(perfil.Roles, "1")) {
                        btnModificarPersona.Visible = true;
                    }
                    if (loginNegocio.TieneRol(perfil.Roles, "3"))
                    {
                        btnDesbloquearCredencial.Visible = true;
                    }
                }
                // administrador
                if (perfil.Id == "3")
                {
                    btnCambioContrasenia.Visible = true;
                    if (loginNegocio.TieneRol(perfil.Roles, "2") || loginNegocio.TieneRol(perfil.Roles, "4"))
                    {
                        btnAutorizaciones.Visible = true;
                    }
                    
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
           CargarUserControl(new FormModificacionPersona());
        }

        private void btnAutorizaciones_Click(object sender, EventArgs e)
        {
           CargarUserControl(new FormAutorizaciones());
        }

        private void btnDesbloquearCredencial_Click(object sender, EventArgs e)
        {
           CargarUserControl(new FormDesbloquearCredencial());
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
