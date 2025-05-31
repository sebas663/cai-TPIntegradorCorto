using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.interfaces
{
    /// <summary>
    /// Interfaz para la gestión de autenticación y credenciales de usuario en la capa de persistencia.
    /// Permite el manejo de inicio de sesión, bloqueo de usuarios e intentos fallidos.
    /// </summary>
    public interface IUsuarioPersistencia
    {
        /// <summary>
        /// Autentica a un usuario con su nombre de usuario y devuelve su credencial si es válida.
        /// </summary>
        /// <param name="usuario">El nombre de usuario.</param>
        /// <returns>
        /// Un objeto <see cref="Credencial"/> si el usuario existe y está autorizado; 
        /// de lo contrario, devuelve <c>null</c>.
        /// </returns>
        Credencial Login(string usuario);

        /// <summary>
        /// Determina si un usuario está bloqueado debido a múltiples intentos fallidos de inicio de sesión.
        /// </summary>
        /// <param name="legajo">El número de legajo del usuario.</param>
        /// <returns>
        /// <c>true</c> si el usuario está bloqueado; <c>false</c> en caso contrario.
        /// </returns>
        bool EstaBloqueado(string legajo);

        /// <summary>
        /// Bloquea el acceso de un usuario al sistema debido a múltiples intentos fallidos de autenticación.
        /// </summary>
        /// <param name="legajo">El número de legajo del usuario.</param>
        void BloquearUsuario(string legajo);

        /// <summary>
        /// Obtiene el número de intentos fallidos de inicio de sesión realizados por un usuario.
        /// </summary>
        /// <param name="legajo">El número de legajo del usuario.</param>
        /// <returns>La cantidad de intentos fallidos registrados.</returns>
        int ObtenerNumeroIntentosPorLegajo(string legajo);

        /// <summary>
        /// Registra un intento fallido de inicio de sesión para un usuario, incluyendo la fecha del intento.
        /// </summary>
        /// <param name="legajo">El número de legajo del usuario.</param>
        /// <param name="fecha">La fecha y hora del intento de inicio de sesión fallido.</param>
        void RegistrarIntento(string legajo, string fecha);

        /// <summary>
        /// Reinicia el contador de intentos fallidos de inicio de sesión para un usuario,
        /// permitiéndole intentar autenticarse nuevamente sin restricciones previas.
        /// </summary>
        /// <param name="legajo">El número de legajo del usuario.</param>
        void ReiniciarIntentos(string legajo);
    }
}