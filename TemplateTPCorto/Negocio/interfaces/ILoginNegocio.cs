using Datos;
using Persistencia;
using System;
using System.Collections.Generic;

namespace Negocio.interfaces
{
    /// <summary>
    /// Interfaz para la gestión de autenticación y manejo de credenciales de usuario en la capa de negocio.
    /// Permite validar usuarios, gestionar bloqueos y verificar el estado de las credenciales.
    /// </summary>
    public interface ILoginNegocio
    {
        /// <summary>
        /// Autentica a un usuario validando su nombre de usuario y contraseña.
        /// </summary>
        /// <param name="usuario">El nombre de usuario.</param>
        /// <param name="password">La contraseña en texto plano ingresada por el usuario.</param>
        /// <returns>
        /// Un objeto <see cref="Credencial"/> si la autenticación es exitosa; de lo contrario, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// Se recomienda encriptar la contraseña antes de enviarla para mayor seguridad.
        /// </remarks>
        Credencial Login(string usuario, string password);

        /// <summary>
        /// Determina si un usuario está bloqueado debido a múltiples intentos fallidos de inicio de sesión.
        /// </summary>
        /// <param name="usuario">El nombre de usuario.</param>
        /// <returns>
        /// <c>true</c> si el usuario está bloqueado; <c>false</c> en caso contrario.
        /// </returns>
        bool EstaBloqueado(string usuario);

        /// <summary>
        /// Verifica si la contraseña de un usuario ha expirado y requiere ser cambiada.
        /// </summary>
        /// <param name="credencial">La credencial asociada al usuario.</param>
        /// <returns>
        /// <c>true</c> si la contraseña está expirada; <c>false</c> si aún es válida.
        /// </returns>
        /// <remarks>
        /// Se recomienda obligar al usuario a cambiar su contraseña si está expirada.
        /// </remarks>
        bool EsContraseniaExpirada(Credencial credencial);

        /// <summary>
        /// Verifica si un usuario está iniciando sesión por primera vez en el sistema.
        /// </summary>
        /// <param name="credencial">La credencial asociada al usuario.</param>
        /// <returns>
        /// <c>true</c> si es el primer inicio de sesión del usuario; <c>false</c> si ya ha iniciado sesión anteriormente.
        /// </returns>
        /// <remarks>
        /// Si es el primer inicio de sesión, se puede solicitar un cambio de contraseña por seguridad.
        /// </remarks>
        bool EsPrimerLogin(Credencial credencial);

        /// <summary>
        /// Reinicia el contador de intentos fallidos de inicio de sesión para un usuario,
        /// permitiéndole intentar autenticarse nuevamente sin restricciones previas.
        /// </summary>
        /// <param name="legajo">El número de legajo del usuario.</param>
        void ReiniciarIntentos(string legajo);
    }
}