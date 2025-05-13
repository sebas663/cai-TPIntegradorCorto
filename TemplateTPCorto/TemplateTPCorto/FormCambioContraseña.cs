using Datos;
using Persistencia;
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
    public partial class FormCambioContraseña : Form
    {
        // Propiedad para almacenar la credencial
        private Credencial _credencial;

        // Constructor que recibe el objeto
        public FormCambioContraseña(Credencial credencial)
        {
            InitializeComponent();
            _credencial = credencial; // Guardamos la credencial
        }
        // Evento del Botón "Guardar"
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nuevaContrasena = txtNuevaContrasena.Text;
            string confirmarContrasena = txtConfirmarContrasena.Text;

            if (nuevaContrasena.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres.");
                return;
            }

            if (nuevaContrasena != confirmarContrasena)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            // Actualizamos la contraseña en el objeto Credencial
            _credencial.Contrasena = nuevaContrasena;
            _credencial.FechaUltimoLogin = DateTime.Now;
            
            // Guardamos en el CSV
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            usuarioPersistencia.ActualizarUsuario(_credencial);

            // Acá tenemos que actualizar el CSV para que persista
            MessageBox.Show("Contraseña actualizada correctamente.");
            this.Close();
            Application.OpenForms["FormLogin"].Show();
        }

        private void txtNuevaContrasena_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
