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
        public FormAdministrador()
        {
            InitializeComponent();
            btnCerrarSession.Click += btnCerrarSession_Click;
        }

        private void btnCambioContrasenia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cambio de contraseña.");
        }
        private void btnAutorizaciones_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Autorizaciones.");
        }

    }
}
