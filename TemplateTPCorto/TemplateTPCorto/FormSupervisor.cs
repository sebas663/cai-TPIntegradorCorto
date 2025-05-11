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
    public partial class FormSupervisor : FormMenuBase
    {
        public FormSupervisor()
        {
            InitializeComponent();
        }
        private void btnCambioContrasenia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cambio de contraseña.");
        }

        private void btnModificarPersona_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Modificar persona.");
        }

        private void btnDesbloquearCredencial_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desbloqueo credencial.");
        }

    }
}
