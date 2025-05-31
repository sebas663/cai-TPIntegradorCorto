using Datos;
using Negocio.interfaces;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    /// <summary>
    /// Control de usuario para la modificación de datos personales de un usuario en el sistema.
    /// </summary>
    public partial class FormModificacionPersona : UserControl
    {
        private readonly IGestionUsuarioNegocio gestionUsuarioNegocio;
        private readonly IAutorizacionNegocio autorizacionNegocio;
        private Persona persona;
        private readonly Credencial usuarioLogueado;
        private readonly DateTime fechaIngresoMinima;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="FormModificacionPersona"/>.
        /// </summary>
        /// <param name="gestionUsuarioNegocio">Interfaz de gestión de usuario.</param>
        /// <param name="autorizacionNegocio">Interfaz de autorización de modificaciones.</param>
        /// <param name="logueado">Usuario autenticado.</param>
        public FormModificacionPersona(IGestionUsuarioNegocio gestionUsuarioNegocio, IAutorizacionNegocio autorizacionNegocio, Credencial logueado)
        {
            InitializeComponent();
            this.gestionUsuarioNegocio = gestionUsuarioNegocio ?? throw new ArgumentNullException(nameof(gestionUsuarioNegocio));
            this.autorizacionNegocio = autorizacionNegocio ?? throw new ArgumentNullException(nameof(autorizacionNegocio));
            this.usuarioLogueado = logueado ?? throw new ArgumentNullException(nameof(logueado));

            fechaIngresoMinima = DateTime.ParseExact("01/01/2010", "d/M/yyyy", CultureInfo.InvariantCulture);
            OcultarCamposFormulario();
        }

        /// <summary>
        /// Evento que busca una persona por número de legajo.
        /// </summary>
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string legajo = txtLegajo.Text.Trim();

            if (string.IsNullOrWhiteSpace(legajo))
            {
                FormUtils.MostrarMensajeAdvertencia("El legajo no puede estar vacío.");
                txtLegajo.Focus();
                return;
            }

            persona = gestionUsuarioNegocio.BuscarPersonaPorNumeroLegajo(legajo);

            if (persona != null)
            {
                MostrarCamposFormulario();
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                txtDni.Text = persona.Dni;
                dateFechaIngreso.Value = persona.FechaIngreso;
            }
            else
            {
                FormUtils.MostrarMensajeAdvertencia("No existe usuario para el número de legajo ingresado.");
                txtLegajo.Focus();
            }
        }

        /// <summary>
        /// Evento que modifica los datos de una persona después de validaciones y confirmación.
        /// </summary>
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string dni = txtDni.Text.Trim();
            DateTime fechaIngreso = dateFechaIngreso.Value;

            if (!ValidarDatosPersona(nombre, apellido, dni, fechaIngreso))
                return;

            string mensaje = $"¿Modificar datos de {persona}? \n ¿Por los nuevos {nombre}, {apellido}, {dni}, {fechaIngreso:d/M/yyyy}?";
            DialogResult result = MessageBox.Show(mensaje, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                txtDni.Text = persona.Dni;
                dateFechaIngreso.Value = persona.FechaIngreso;
                txtNombre.Focus();
                return;
            }

            try
            {
                Autorizacion autorizacion = new Autorizacion
                {
                    TipoOperacion = EnumTipoOperacion.CambioPersona.ToString(),
                    Estado = EnumEstadoAutorizacion.Pendiente.ToString(),
                    LegajoSolicitante = usuarioLogueado.Legajo,
                    FechaSolicitud = DateTime.Now
                };

                OperacionCambioPersona operacion = new OperacionCambioPersona
                {
                    Legajo = txtLegajo.Text,
                    Nombre = nombre,
                    Apellido = apellido,
                    Dni = dni,
                    FechaIngreso = fechaIngreso
                };

                autorizacionNegocio.RegistrarOperacionCambioPersona(autorizacion, operacion);
                FormUtils.MostrarMensajeInformacion("La operación quedó pendiente de aprobación por parte del administrador.");
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                FormUtils.MostrarMensajeAdvertencia($"Error al registrar la operación: {ex.Message}");
            }
        }

        private bool ValidarDatosPersona(string nombre, string apellido, string dni, DateTime fechaIngreso)
        {
            if (string.IsNullOrWhiteSpace(nombre) || !FormUtils.EsIngresoSoloTextoEspaciosValido(nombre))
            {
                FormUtils.MostrarMensajeAdvertencia("El nombre solo debe contener letras y espacios.");
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(apellido) || !FormUtils.EsIngresoSoloTextoEspaciosValido(apellido))
            {
                FormUtils.MostrarMensajeAdvertencia("El apellido solo debe contener letras y espacios.");
                txtApellido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(dni) || !FormUtils.EsIngresoSoloNumerosValido(dni))
            {
                FormUtils.MostrarMensajeAdvertencia("El DNI solo debe contener números.");
                txtDni.Focus();
                return false;
            }

            if (!FormUtils.EsFechaValida(fechaIngreso, fechaIngresoMinima))
            {
                FormUtils.MostrarMensajeAdvertencia("La fecha de ingreso es inválida.");
                dateFechaIngreso.Focus();
                return false;
            }

            return true;
        }
        /// <summary>
        /// Restablece los campos del formulario y oculta los controles.
        /// </summary>
        private void LimpiarFormulario()
        {
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
        /// <summary>
        /// Oculta los controles de entrada hasta que se busque un usuario válido.
        /// </summary>
        private void OcultarCamposFormulario()
        {
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
        /// <summary>
        /// Muestra los controles de entrada cuando un usuario válido es encontrado.
        /// </summary>
        private void MostrarCamposFormulario()
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
        }
    }
}