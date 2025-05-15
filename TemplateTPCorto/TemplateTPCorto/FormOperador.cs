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
    public partial class FormOperador : Form
    {
        private Form formularioAnterior;
        private Credencial usuario;
        public FormOperador(Form anterior, Credencial logueado)
        {
            InitializeComponent();
            btnCerrarSession.Click += btnCerrarSession_Click;
            formularioAnterior = anterior;
            usuario = logueado;
        }

        private void btnCambioContrasenia_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormContraseniaCambio(usuario).Show();
        }

        private void btnCerrarSession_Click(object sender, EventArgs e)
        {
            this.Close();
            formularioAnterior.Show();
        }

    }
}
