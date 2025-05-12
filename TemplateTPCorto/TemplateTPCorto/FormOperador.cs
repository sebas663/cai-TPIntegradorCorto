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
    public partial class FormOperador : FormMenuBase
    {
        private Credencial usuario;
        public FormOperador(Credencial logueado)
        {
            InitializeComponent();
            btnCerrarSession.Click += btnCerrarSession_Click;
            usuario = logueado;
        }

        private void btnCambioContrasenia_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormContraseniaCambio form = new FormContraseniaCambio(this, usuario);
            form.Show();
        }

    }
}
