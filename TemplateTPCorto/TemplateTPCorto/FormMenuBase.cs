using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public class FormMenuBase : Form
    {
        private bool cerrarSesion = false;

        public FormMenuBase()
        {
            this.FormClosing += Form_FormClosing;
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cerrarSesion && e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "¿Estás seguro de que deseas salir?",
                    "Confirmar salida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancela el cierre
                }
                else
                {
                    Application.Exit(); // Finaliza toda la aplicación
                }
            }
        }
        public void btnCerrarSession_Click(object sender, EventArgs e)
        {
            cerrarSesion = true;
            this.Close();
        }
    }

}
