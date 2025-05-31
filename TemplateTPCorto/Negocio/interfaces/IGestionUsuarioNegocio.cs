using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de gestión de usuario en la capa de negocio.
    /// Proporciona métodos para recuperar información de usuarios y administrar credenciales.
    /// </summary>
    public interface IGestionUsuarioNegocio
    {
        /// <summary>
        /// Obtiene el perfil asociado a un usuario identificado por su número de legajo.
        /// </summary>
        /// <param name="legajo">Número único de legajo del usuario.</param>
        /// <returns>
        /// Un objeto <see cref="Perfil"/> que contiene la información del perfil del usuario.
        /// Si el usuario no existe, retorna <c>null</c>.
        /// </returns>
        Perfil ObtenerPerfil(string legajo);

        /// <summary>
        /// Actualiza la contraseña de un usuario, reemplazándola con una nueva.
        /// </summary>
        /// <param name="credencial">Un objeto <see cref="Credencial"/> que contiene la nueva contraseña.</param>
        /// <remarks>
        /// Se recomienda validar la seguridad de la contraseña antes de actualizarla.
        /// </remarks>
        void ActualizarContrasenia(Credencial credencial);

        /// <summary>
        /// Busca la credencial asociada a un número de legajo en la base de datos.
        /// </summary>
        /// <param name="legajo">Número único de legajo del usuario.</param>
        /// <returns>
        /// Un objeto <see cref="Credencial"/> si la credencial existe; de lo contrario, <c>null</c>.
        /// </returns>
        Credencial BuscarCredencialPorNumeroLegajo(string legajo);

        /// <summary>
        /// Busca la información personal de un usuario identificándolo por su número de legajo.
        /// </summary>
        /// <param name="legajo">Número único de legajo del usuario.</param>
        /// <returns>
        /// Un objeto <see cref="Persona"/> que contiene los datos personales del usuario.
        /// Si el usuario no existe, retorna <c>null</c>.
        /// </returns>
        Persona BuscarPersonaPorNumeroLegajo(string legajo);
    }
}