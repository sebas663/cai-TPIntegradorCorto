using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public static class FormUtils
    {
        public static void MostrarMensajeAdvertencia(string mensaje)
        {
            string tituloDefault = "Error de validación";
            MostrarMensajeAdvertencia(mensaje, tituloDefault);
        }
        public static void MostrarMensajeAdvertencia(string mensaje, string titulo)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void MostrarMensajeInformacion(string mensaje)
        {
            string tituloDefault = "Información";
            MostrarMensajeInformacion(mensaje, tituloDefault);
        }
        public static void MostrarMensajeInformacion(string mensaje, string titulo)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static bool TieneRol(List<Rol> roles, int rolId)
        {
            bool tieneRol = false;
            foreach (Rol rol in roles)
            {
                if (rol.Id == rolId.ToString())
                {
                    tieneRol = true;
                    break;
                }
            }
            return tieneRol;
        }

        public static bool EsIngresoSoloTextoEspaciosValido(string texto)
        {
            bool esValido = true;
            foreach (char c in texto)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    esValido = false;
                }
            }
            return esValido;
        }
        public static bool EsIngresoSoloNumerosValido(string texto)
        {
            return texto.All(char.IsDigit);
        }
        public static bool EsFechaValida(DateTime fechaSeleccionada, DateTime fechaControl)
        {
            return fechaSeleccionada >= fechaControl && fechaSeleccionada <= DateTime.Today;
        }
    }
}
