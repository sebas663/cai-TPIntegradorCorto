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

namespace TemplateTPCorto
{
    public partial class FormSupervisor : Form // se cambia para que funcione el designer.
    {
        private Credencial usuario;
        public FormSupervisor(Credencial logueado)
        {
            InitializeComponent();
            //btnCerrarSession.Click += btnCerrarSession_Click;
            usuario = logueado;
            txtsupervisorusuario.Visible = false;
            btnsupervisorusuario.Visible = false;
        }
        private void btnCambioContrasenia_Click(object sender, EventArgs e)
        {
            txtsupervisorusuario.Visible = true;
            btnsupervisorusuario.Visible = true;
        }

        private void btnModificarPersona_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Modificar persona.");
        }

        private void btnDesbloquearCredencial_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desbloqueo credencial.");
        }

        private void btnsupervisorusuario_Click(object sender, EventArgs e)
        {
            LoginNegocio loginNegocio = new LoginNegocio();
            string usuarioingresado = txtsupervisorusuario.Text;
            Credencial credencial = loginNegocio.obtenerusuariosupervisor(usuarioingresado);
            if(credencial == null)
            {
                MessageBox.Show("El usuario ingresado no existe.");
                txtsupervisorusuario.Focus();
            }
            else
            {
                this.Hide();
                FormContraseniaCambio form = new FormContraseniaCambio(this, credencial, true);
                form.Show();
            }
            
        }
    }
}
