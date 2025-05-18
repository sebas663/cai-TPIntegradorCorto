using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public partial class FormModificacionPersona : UserControl
    {
        private readonly LoginNegocio loginNegocio;
        private Persona persona;
        private readonly Credencial usuarioLogueado;
        private readonly DateTime fechaIngresoMinima;
        public FormModificacionPersona(LoginNegocio loginNegocio, Credencial logueado)
        {
            InitializeComponent();
            this.loginNegocio = loginNegocio;
            this.usuarioLogueado = logueado;
            fechaIngresoMinima = DateTime.ParseExact("01/01/2010", "d/M/yyyy", CultureInfo.InvariantCulture);
            btnModificar.Visible = false;
            labelNombre.Visible = false;
            txtNombre.Visible = false;
            labelApellido.Visible = false;
            txtApellido.Visible = false;
            labelFechaIngreso.Visible = false;
            dateFechaIngreso.Visible = false;
            labelDni.Visible = false;
            txtDni.Visible = false;
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            String legajo = txtLegajo.Text;

            if (string.IsNullOrEmpty(legajo))
            {
                FormUtils.MostrarMensajeAdvertencia("El Legajo no puede estar vacio.");
                txtLegajo.Focus();
                return;
            }
            persona = loginNegocio.BuscarPersonaPorNumeroLegajo(legajo);
            if (persona != null)
            {
                btnModificar.Visible = true;
                labelNombre.Visible = true;
                txtNombre.Visible = true;
                labelApellido.Visible = true;
                txtApellido.Visible = true;
                labelFechaIngreso.Visible = true;
                dateFechaIngreso.Visible = true;
                labelDni.Visible = true;
                txtDni.Visible = true;
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                txtDni.Text = persona.Dni;
                dateFechaIngreso.Value = persona.FechaIngreso;
            }
            else
            {
                FormUtils.MostrarMensajeAdvertencia("No existe usuario para el nùmero de legajo ingresado.");
                txtLegajo.Focus();
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string dni = txtDni.Text;
            DateTime fechaIngreso = dateFechaIngreso.Value;
            if (string.IsNullOrEmpty(nombre))
            {
                FormUtils.MostrarMensajeAdvertencia("El Nombre no puede estar vacio.");
                txtNombre.Focus();
                return;
            }
            if (!FormUtils.EsIngresoSoloTextoEspaciosValido(nombre))
            {
                FormUtils.MostrarMensajeAdvertencia("El Nombre solo debe contener letras y espacios.");
                return;
            }
            if (string.IsNullOrEmpty(apellido))
            {
                FormUtils.MostrarMensajeAdvertencia("El Apellido no puede estar vacio.");
                txtApellido.Focus();
                return;
            }
            if (!FormUtils.EsIngresoSoloTextoEspaciosValido(apellido))
            {
                FormUtils.MostrarMensajeAdvertencia("El Apellido solo debe contener letras y espacios.");
                return;
            }
            if (string.IsNullOrEmpty(dni))
            {
                FormUtils.MostrarMensajeAdvertencia("El DNI no puede estar vacio.");
                txtDni.Focus();
                return;
            }
            if (!FormUtils.EsIngresoSoloNumerosValido(dni))
            {
                FormUtils.MostrarMensajeAdvertencia("El DNI solo debe contener nùmeros.");
                return;
            }
            if (!FormUtils.EsFechaValida(fechaIngreso, fechaIngresoMinima))
            {
                FormUtils.MostrarMensajeAdvertencia("La Fecha de ingreso es invàlida.");
                dateFechaIngreso.Focus();
                return;
            }
            String legajo = txtLegajo.Text;
            OperacionCambioPersona operacion = new OperacionCambioPersona
            {
                Legajo = legajo,
                Nombre = nombre,
                Apellido = apellido,
                Dni = dni,
                FechaIngreso = fechaIngreso
            };
            string mensaje = "¿Modificar datos de " + persona.ToString() + "? \n ¿Por los nuevos " + operacion.ToString();
            DialogResult result = MessageBox.Show(
                mensaje,
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                txtDni.Text = persona.Dni;
                dateFechaIngreso.Value = persona.FechaIngreso;
                txtNombre.Focus();
            }
            else
            {
                Autorizacion autorizacion = new Autorizacion
                {
                    TipoOperacion = EnumTipoOperacion.CambioPersona.ToString(),
                    Estado = EnumEstadoAutorizacion.Pendiente.ToString(),
                    LegajoSolicitante = usuarioLogueado.Legajo,
                    FechaSolicitud = DateTime.Now
                };

                loginNegocio.RegistrarOperacionCambioPersona(autorizacion, operacion);
                FormUtils.MostrarMensajeInformacion("La operación quedo pendiente de aprobación por parte del administrador.");
                btnModificar.Visible = false;
                labelNombre.Visible = false;
                txtNombre.Visible = false;
                labelApellido.Visible = false;
                txtApellido.Visible = false;
                labelFechaIngreso.Visible = false;
                dateFechaIngreso.Visible = false;
                labelDni.Visible = false;
                txtDni.Visible = false;
                txtLegajo.Text = string.Empty;
                txtLegajo.Focus();
            }
        }
    }
}
