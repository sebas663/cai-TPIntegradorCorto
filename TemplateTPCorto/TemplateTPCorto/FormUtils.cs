using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    /// <summary>
    /// Clase utilitaria para operaciones comunes en la interfaz de usuario y validaciones.
    /// </summary>
    public static class FormUtils
    {
        /// <summary>
        /// Muestra un mensaje de advertencia con un título por defecto.
        /// </summary>
        /// <param name="mensaje">El mensaje a mostrar.</param>
        public static void MostrarMensajeAdvertencia(string mensaje) =>
            MessageBox.Show(mensaje, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        /// <summary>
        /// Muestra un mensaje de advertencia con un título personalizado.
        /// </summary>
        /// <param name="mensaje">El mensaje a mostrar.</param>
        /// <param name="titulo">El título de la ventana emergente.</param>
        public static void MostrarMensajeAdvertencia(string mensaje, string titulo) =>
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        /// <summary>
        /// Muestra un mensaje informativo con un título por defecto.
        /// </summary>
        /// <param name="mensaje">El mensaje a mostrar.</param>
        public static void MostrarMensajeInformacion(string mensaje) =>
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        /// <summary>
        /// Muestra un mensaje informativo con un título personalizado.
        /// </summary>
        /// <param name="mensaje">El mensaje a mostrar.</param>
        /// <param name="titulo">El título de la ventana emergente.</param>
        public static void MostrarMensajeInformacion(string mensaje, string titulo) =>
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

        /// <summary>
        /// Determina si la lista de roles contiene un rol específico por ID.
        /// </summary>
        /// <param name="roles">Lista de roles del usuario.</param>
        /// <param name="rolId">Identificador del rol buscado.</param>
        /// <returns><c>true</c> si el usuario tiene el rol, de lo contrario <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Si la lista de roles es nula.</exception>
        public static bool TieneRol(List<Rol> roles, int rolId)
        {
            if (roles == null)
                throw new ArgumentNullException(nameof(roles), "La lista de roles no puede ser nula.");

            return roles.Any(rol => rol.Id == rolId.ToString());
        }

        /// <summary>
        /// Determina si un texto contiene solo letras y espacios en blanco.
        /// </summary>
        /// <param name="texto">El texto a validar.</param>
        /// <returns><c>true</c> si el texto solo contiene letras y espacios, de lo contrario <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Si el texto es nulo.</exception>
        public static bool EsIngresoSoloTextoEspaciosValido(string texto)
        {
            if (texto == null)
                throw new ArgumentNullException(nameof(texto), "El texto no puede ser nulo.");

            return texto.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        /// <summary>
        /// Determina si un texto contiene solo números.
        /// </summary>
        /// <param name="texto">El texto a validar.</param>
        /// <returns><c>true</c> si el texto solo contiene números, de lo contrario <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Si el texto es nulo.</exception>
        public static bool EsIngresoSoloNumerosValido(string texto)
        {
            if (texto == null)
                throw new ArgumentNullException(nameof(texto), "El texto no puede ser nulo.");

            return texto.All(char.IsDigit);
        }

        /// <summary>
        /// Verifica si una fecha es válida dentro del rango permitido.
        /// </summary>
        /// <param name="fechaSeleccionada">La fecha seleccionada.</param>
        /// <param name="fechaControl">La fecha mínima permitida.</param>
        /// <returns><c>true</c> si la fecha está dentro del rango, <c>false</c> si es inválida.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Si <paramref name="fechaControl"/> es mayor que <see cref="DateTime.Today"/>.</exception>
        public static bool EsFechaValida(DateTime fechaSeleccionada, DateTime fechaControl)
        {
            if (fechaControl > DateTime.Today)
                throw new ArgumentOutOfRangeException(nameof(fechaControl), "La fecha de control no puede ser futura.");

            return fechaSeleccionada >= fechaControl && fechaSeleccionada <= DateTime.Today;
        }
    }
}