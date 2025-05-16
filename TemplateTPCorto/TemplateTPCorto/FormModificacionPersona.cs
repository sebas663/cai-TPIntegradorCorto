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
        private Persona persona;
        public FormModificacionPersona()
        {
            InitializeComponent();
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
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String legajo = txtLegajo.Text;

            if (string.IsNullOrEmpty(legajo))
            {
                MessageBox.Show("El legajo no puede estar vacio.");
                txtLegajo.Focus();
                return;
            }
            LoginNegocio loginNegocio = new LoginNegocio();
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String legajo = txtLegajo.Text;
            LoginNegocio loginNegocio = new LoginNegocio();
            if (persona != null)
            {
                string mensaje = "¿Modificar datos legajo: " + legajo + ", usuario: " + persona.Nombre + "?";
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
                    loginNegocio.RegistrarOperacionCambioPersona(persona);
                    MessageBox.Show("La operación quedo pendiente de aprobación por parte del administrador.");
                }
            }
            else
            {
                MessageBox.Show("Primero debe ingresar un legajo y apretar el botòn buscar.");
                txtLegajo.Focus();
            }

        }
    }
}
