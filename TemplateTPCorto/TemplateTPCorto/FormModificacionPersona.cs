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
        public FormModificacionPersona(LoginNegocio negocio, Credencial logueado)
        {
            InitializeComponent();
            this.loginNegocio = negocio;
            this.usuarioLogueado = logueado;
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
                MessageBox.Show("El legajo no puede estar vacio.");
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
                MessageBox.Show("No existe usuario para el nùmero de legajo ingresado.");
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
                MessageBox.Show("El Nombre no puede estar vacio.");
                txtNombre.Focus();
                return;
            }
            if (string.IsNullOrEmpty(apellido))
            {
                MessageBox.Show("El apellido no puede estar vacio.");
                txtApellido.Focus();
                return;
            }
            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("El dni no puede estar vacio.");
                txtDni.Focus();
                return;
            }
            if (!FechaIngresoValida(fechaIngreso))
            {
                MessageBox.Show("La fecha de ingreso es invàlida.");
                dateFechaIngreso.Focus();
                return;
            }
            String legajo = txtLegajo.Text;
            if (persona != null)
            {
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
                    MessageBox.Show("La operación quedo pendiente de aprobación por parte del administrador.");
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
            else
            {
                MessageBox.Show("Primero debe ingresar un legajo y apretar el botòn buscar.");
                txtLegajo.Focus();
            }

        }

        bool FechaIngresoValida(DateTime fechaIngreso)
        {
            DateTime hoy = DateTime.Today;

            // Regla 1: No puede ser en el futuro
            if (fechaIngreso > hoy)
                return false;

            // Regla 2: Fecha ingreso no mayor a 20 años inicio actividades de la empresa.
            int edad = hoy.Year - fechaIngreso.Year;
            if (fechaIngreso > hoy.AddYears(-edad)) edad--; 

            if (edad < 0 || edad > 20)
                return false;

            return true;
        }

    }
}
