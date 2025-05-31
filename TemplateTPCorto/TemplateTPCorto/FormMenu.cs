using Datos;
using Negocio;
using Negocio.interfaces;
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
        private readonly ILoginNegocio loginNegocio;
        private readonly IGestionUsuarioNegocio gestionUsuarioNegocio;
        private readonly Credencial usuario;
        public FormMenu(ILoginNegocio loginNegocio, IGestionUsuarioNegocio gestionUsuarioNegocio, Credencial usuarioLogueado)
        {
            InitializeComponent();
            this.loginNegocio = loginNegocio;
            this.gestionUsuarioNegocio = gestionUsuarioNegocio;
            this.usuario = usuarioLogueado;
            ConfigurarMenuPorPerfilRol();
        }
        private void ConfigurarMenuPorPerfilRol()
        {
            btnCerrarSession.Visible = true;
            btnCambioContrasenia.Visible = false;
            btnModificarPersona.Visible = false;
            btnDesbloquearCredencial.Visible = false;
            btnAutorizaciones.Visible = false;
            btnVentas.Visible = false;
            bool esPrimerLogin = loginNegocio.EsPrimerLogin(usuario);
            bool esContraseniaExpirada = loginNegocio.EsContraseniaExpirada(usuario);
            if (esPrimerLogin || esContraseniaExpirada)
            {
                CargarUserControl(FabricaFormularios.Instancia.CrearFormContraseniaCambio(usuario));
            }
            else 
            {
                Perfil perfil = gestionUsuarioNegocio.ObtenerPerfil(usuario.Legajo);
                // operador
                if (int.Parse(perfil.Id) == (int)EnumPerfilId.Operador
                        && FormUtils.TieneRol(perfil.Roles, (int)EnumRolId.Operador))
                {
                    btnCambioContrasenia.Visible = true;
                    btnVentas.Visible = true;
                }
                // supervisor
                if (int.Parse(perfil.Id) == (int)EnumPerfilId.Supervisor)
                {
                    btnCambioContrasenia.Visible = true;
                    if (FormUtils.TieneRol(perfil.Roles, (int)EnumRolId.ModificarPersona)) {
                        btnModificarPersona.Visible = true;
                    }
                    if (FormUtils.TieneRol(perfil.Roles, (int)EnumRolId.DesbloquearCredencial))
                    {
                        btnDesbloquearCredencial.Visible = true;
                    }
                }
                // administrador
                if (int.Parse(perfil.Id) == (int)EnumPerfilId.Administrador)
                {
                    btnCambioContrasenia.Visible = true;
                    if (FormUtils.TieneRol(perfil.Roles, (int)EnumRolId.AutorizarModificarPersona)
                            || FormUtils.TieneRol(perfil.Roles, (int)EnumRolId.AutorizarDesbloquearCredencial))
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
        private void BtnModificarPersona_Click(object sender, EventArgs e)
        {
            CargarUserControl(FabricaFormularios.Instancia.CrearFormModificacionPersona(usuario));
        }
        private void BtnAutorizaciones_Click(object sender, EventArgs e)
        {
            CargarUserControl(FabricaFormularios.Instancia.CrearFormAutorizaciones(usuario));
        }
        private void BtnDesbloquearCredencial_Click(object sender, EventArgs e)
        {
            CargarUserControl(FabricaFormularios.Instancia.CrearFormDesbloquearCredencial(usuario));
        }
        private void BtnCambioContrasenia_Click(object sender, EventArgs e)
        {
            CargarUserControl(FabricaFormularios.Instancia.CrearFormContraseniaCambio(usuario));
        }
        private void BtnVentas_Click(object sender, EventArgs e)
        {
            CargarUserControl(FabricaFormularios.Instancia.CrearFormFormVentas(usuario));
        }
        private void BtnCerrarSession_Click(object sender, EventArgs e)
        {
            this.Hide();
            FabricaFormularios.Instancia.CrearFormLogin().Show();
        }
    }
}
