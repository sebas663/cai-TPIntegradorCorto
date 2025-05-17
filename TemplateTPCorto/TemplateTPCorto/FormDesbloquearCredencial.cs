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
    public partial class FormDesbloquearCredencial : UserControl
    {
        private readonly LoginNegocio loginNegocio;
        private readonly Credencial usuarioLogueado;
        private const int MIN_CARACTERES_CONTRASENIA = 8;
        public FormDesbloquearCredencial(LoginNegocio negocio, Credencial logueado)
        {
            InitializeComponent();
            this.loginNegocio = negocio;
            this.usuarioLogueado = logueado;
        }

        private void BtnDesbloqueoCredencial_Click(object sender, EventArgs e)
        {
            String legajo = txtLegajo.Text;
            String password = txtContraseniaNueva.Text;

            if (string.IsNullOrEmpty(legajo))
            {
                MessageBox.Show("El legajo no puede estar vacio");
                txtLegajo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("La contraseña nueva no puede estar vacia.");
                txtContraseniaNueva.Focus();
                return;
            }
            if (password.Length < MIN_CARACTERES_CONTRASENIA)
            {
                MessageBox.Show("La contraseña nueve debe tener al menos 8 caracteres.");
                txtContraseniaNueva.Focus();
                return;
            }
            Credencial credencial = loginNegocio.BuscarCredencialPorNumeroLegajo(legajo);
            if (credencial != null)
            {
                string mensaje = "¿Cambiar contraseña de legajo: " + legajo + ", usuario: " + credencial.NombreUsuario + "?";
                DialogResult result = MessageBox.Show(
                    mensaje,
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
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
                    Perfil perfil = loginNegocio.ObtenerPerfil(legajo);
                    OperacionCambioCredencial operacion = new OperacionCambioCredencial
                    {
                        Legajo = credencial.Legajo,
                        NombreUsuario = credencial.NombreUsuario,
                        Contrasena = password,
                        IdPerfil = perfil.Id,
                        FechaAlta = credencial.FechaAlta,
                        FechaUltimoLogin = credencial.FechaUltimoLogin.Value
                    };

                    loginNegocio.RegistrarOperacionCambioCredencial(autorizacion, operacion);
                    MessageBox.Show("La operación quedo pendiente de aprobación por parte del administrador.");
                    txtLegajo.Text = string.Empty;
                    txtContraseniaNueva.Text = string.Empty;
                    txtLegajo.Focus();
                }
            }
            else
            {
                MessageBox.Show("No existe usuario para el nùmero de legajo ingresado.");
                txtLegajo.Focus();
            }
        }
    }
}
