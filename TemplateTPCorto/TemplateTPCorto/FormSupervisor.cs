using Datos;
using System;
using Negocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.Login;
using System.Globalization;

namespace TemplateTPCorto
{
    public partial class FormSupervisor : FormMenuBase
    {
        private Credencial usuario;
        private Datousuario usuaurioamodificar;
        public FormSupervisor(Credencial logueado)
        {
            InitializeComponent();
            btnCerrarSession.Click += btnCerrarSession_Click;
            usuario = logueado;
            txtsupervisorusuario.Visible = false;
            btnsupervisorusuario.Visible = false;
            btnmodifipersona.Visible = false;
            txtnombre.Enabled = false;
            txtapellido.Enabled = false;
            txtdni.Enabled = false;
            usuaurioamodificar = null;
        }
        private void btnCambioContrasenia_Click(object sender, EventArgs e)
        {
            txtsupervisorusuario.Visible = true;
            btnsupervisorusuario.Visible = true;
        }

        private void btnModificarPersona_Click(object sender, EventArgs e)
        {
            btnmodifipersona.Visible = true;
            txtsupervisorusuario.Visible = true;
        }


        private void btnsupervisorusuario_Click(object sender, EventArgs e)
        {
            LoginNegocio loginNegocio = new LoginNegocio();
            string legajoingresado = txtsupervisorusuario.Text;
            Credencial credencial = loginNegocio.obtenerusuariosupervisor(legajoingresado);
            if (credencial == null)
            {
                MessageBox.Show("El usuario ingresado no existe.");
                txtsupervisorusuario.Focus();
            }
            else
            {
                this.Hide();
                FormContraseniaCambio form = new FormContraseniaCambio(credencial);
                form.Show();
            }
        }

        private void btnmodifipersona_Click(object sender, EventArgs e)
        {
            string legajoingresado = txtsupervisorusuario.Text;
            LoginNegocio loginNegocio = new LoginNegocio();
            Datousuario datousuario = loginNegocio.ObtenerPersona(legajoingresado);
            this.usuaurioamodificar = datousuario;
            if (datousuario == null)
            {
                MessageBox.Show("El usuario ingresado no existe.");
                txtsupervisorusuario.Focus();
            }
            else
            {
                txtnombre.Text = datousuario.Nombre;
                txtapellido.Text = datousuario.Apellido;
                txtdni.Text = Convert.ToString(datousuario.DNI);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreingresado = txtnombre.Text;
            string apellidoingresado = txtapellido.Text;
            string dniingresado = txtdni.Text;
            LoginNegocio loginNegocio = new LoginNegocio();
            string fechaIngreso = this.usuaurioamodificar.FechaIngreso.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
            loginNegocio.ModificarPersona(this.usuaurioamodificar.Legajo, nombreingresado, apellidoingresado, dniingresado, fechaIngreso);
        }

        private void check1_CheckedChanged(object sender, EventArgs e)
        {
            txtnombre.Enabled = check1.Checked;
        }

        private void check2_CheckedChanged(object sender, EventArgs e)
        {
            txtapellido.Enabled = check2.Checked;
        }

        private void check3_CheckedChanged(object sender, EventArgs e)
        {
            txtdni.Enabled = check3.Checked;

        }
    }
}