using Datos;
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
    public partial class FormAdministrador : FormMenuBase
    {
        private Credencial usuario;
        public FormAdministrador(Credencial logueado)
        {
            InitializeComponent();
            btnCerrarSession.Click += btnCerrarSession_Click;
            usuario = logueado;
        }

        private void btnCambioContrasenia_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormContraseniaCambio form = new FormContraseniaCambio(this, usuario, false);
            form.Show();
        }
        private void btnAutorizaciones_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Autorizaciones.");
        }

    }
}
