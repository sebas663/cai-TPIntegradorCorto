using System;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public static class LoadingHelper
    {
        private static FormLoading _form;

        /// <summary>
        /// Muestra el formulario de carga y procesa eventos de UI.
        /// </summary>
        public static void Mostrar()
        {
            if (_form == null)
            {
                _form = new FormLoading();
                _form.StartPosition = FormStartPosition.CenterScreen;
                _form.Show();
                Application.DoEvents(); // Asegura que se muestre inmediatamente
            }
        }

        /// <summary>
        /// Cierra el formulario de carga si está visible.
        /// </summary>
        public static void Ocultar()
        {
            if (_form != null)
            {
                _form.Close();
                _form.Dispose();
                _form = null;
            }
        }
    }
}