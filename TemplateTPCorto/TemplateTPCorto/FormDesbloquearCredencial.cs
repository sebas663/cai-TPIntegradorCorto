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
    public partial class FormDesbloquearCredencial : UserControl
    {
        private readonly IGestionUsuarioNegocio gestionUsuarioNegocio;
        private readonly IAutorizacionNegocio autorizacionNegocio;
        private readonly Credencial usuarioLogueado;
        private const int MIN_CARACTERES_CONTRASENIA = 8;
        private Credencial usuarioCambioCredencial;
        public FormDesbloquearCredencial(IGestionUsuarioNegocio gestionUsuarioNegocio, IAutorizacionNegocio autorizacionNegocio, Credencial logueado)
        {
            InitializeComponent();
            this.gestionUsuarioNegocio = gestionUsuarioNegocio;
            this.autorizacionNegocio = autorizacionNegocio;
            this.usuarioLogueado = logueado;
            labelUsuario.Visible = false;
            labelContraseniaNueva.Visible = false;
            txtContraseniaNueva.Visible = false;
            btnDesbloquearCredencial.Visible = false;
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            String legajo = txtLegajo.Text;

            if (string.IsNullOrEmpty(legajo))
            {
                FormUtils.MostrarMensajeAdvertencia("El Legajo no puede estar vacio");
                txtLegajo.Focus();
                return;
            }
            usuarioCambioCredencial = gestionUsuarioNegocio.BuscarCredencialPorNumeroLegajo(legajo);
            if (usuarioCambioCredencial != null)
            {
                labelUsuario.Text = "Usuario: " + usuarioCambioCredencial.NombreUsuario;
                labelUsuario.Visible = true;
                labelContraseniaNueva.Visible = true;
                txtContraseniaNueva.Visible = true;
                btnDesbloquearCredencial.Visible = true;
            }
            else
            {
                FormUtils.MostrarMensajeInformacion("No existe usuario para el nùmero de legajo ingresado.");
                txtLegajo.Focus();
            }
        }
        private void BtnDesbloqueoCredencial_Click(object sender, EventArgs e)
        {
            String legajo = txtLegajo.Text;
            String password = txtContraseniaNueva.Text;
            if (string.IsNullOrEmpty(password))
            {
                FormUtils.MostrarMensajeAdvertencia("La Contraseña nueva no puede estar vacia.");
                txtContraseniaNueva.Focus();
                return;
            }
            if (password.Length < MIN_CARACTERES_CONTRASENIA)
            {
                FormUtils.MostrarMensajeAdvertencia("La Contraseña nueve debe tener al menos 8 caracteres.");
                txtContraseniaNueva.Focus();
                return;
            }
  
            string mensaje = "¿Cambiar contraseña de legajo: " + legajo + ", usuario: " + usuarioCambioCredencial.NombreUsuario + "?";
            DialogResult result = MessageBox.Show(
                mensaje,
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                txtLegajo.Text = string.Empty;
                txtContraseniaNueva.Text = string.Empty;
                labelUsuario.Text = string.Empty;
                labelUsuario.Visible = false;
                labelContraseniaNueva.Visible = false;
                txtContraseniaNueva.Visible = false;
                btnDesbloquearCredencial.Visible = false;
                txtLegajo.Focus();
            }
            else
            {
                Autorizacion autorizacion = new Autorizacion
                {
                    TipoOperacion = EnumTipoOperacion.CambioCredencial.ToString(),
                    Estado = EnumEstadoAutorizacion.Pendiente.ToString(),
                    LegajoSolicitante = usuarioLogueado.Legajo,
                    FechaSolicitud = DateTime.Now
                };
                Perfil perfil = gestionUsuarioNegocio.ObtenerPerfil(legajo);
                OperacionCambioCredencial operacion = new OperacionCambioCredencial
                {
                    Legajo = usuarioCambioCredencial.Legajo,
                    NombreUsuario = usuarioCambioCredencial.NombreUsuario,
                    Contrasena = password,
                    IdPerfil = perfil.Id,
                    FechaAlta = usuarioCambioCredencial.FechaAlta,
                    FechaUltimoLogin = usuarioCambioCredencial.FechaUltimoLogin.Value
                };

                autorizacionNegocio.RegistrarOperacionCambioCredencial(autorizacion, operacion);
                FormUtils.MostrarMensajeInformacion("La operación quedo pendiente de aprobación por parte del administrador.");
                txtLegajo.Text = string.Empty;
                txtContraseniaNueva.Text = string.Empty;
                labelUsuario.Text = string.Empty;
                labelUsuario.Visible = false;
                labelContraseniaNueva.Visible = false;
                txtContraseniaNueva.Visible = false;
                btnDesbloquearCredencial.Visible = false;
                txtLegajo.Focus();
            }
        }
    }
}
