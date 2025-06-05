using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.interfaces
{
    /// <summary>
    /// Interfaz para la gestión de usuarios en la capa de persistencia.
    /// Define métodos para manipular credenciales, personas y perfiles en la base de datos.
    /// </summary>
    public interface IGestionUsuarioPersistencia
    {
        /// <summary>
        /// Actualiza la contraseña de una credencial específica.
        /// </summary>
        /// <param name="credencial">La credencial que contiene la nueva contraseña.</param>
        void ActualizarContrasenia(Credencial credencial);

        /// <summary>
        /// Actualiza los datos de persona especifica.
        /// </summary>
        /// <param name="modificada">La persona que contiene los datos modificados.</param>
        void ActualizarDatosPersonaPorLegajo(Persona modificada);

        /// <summary>
        /// Busca una credencial asociada a un número de legajo.
        /// </summary>
        /// <param name="legajo">El número de legajo del usuario.</param>
        /// <returns>La credencial del usuario si se encuentra, de lo contrario, null.</returns>
        Credencial BuscarCredencialPorNumeroLegajo(string legajo);

        /// <summary>
        /// Busca una persona en la base de datos según su número de legajo.
        /// </summary>
        /// <param name="legajo">El número de legajo de la persona.</param>
        /// <returns>La persona encontrada o null si no existe.</returns>
        Persona BuscarPersonaPorNumeroLegajo(string legajo);

        /// <summary>
        /// Desbloquea un usuario bloqueado.
        /// </summary>
        /// <param name="legajo">El número de legajo del usuario bloqueado.</param>
        void DesbloquearUsuarioBloqueadoPorLegajo(string legajo);

        /// <summary>
        /// Obtiene el perfil de un usuario según su número de legajo.
        /// </summary>
        /// <param name="legajo">El número de legajo del usuario.</param>
        /// <returns>El perfil del usuario si existe, de lo contrario, null.</returns>
        Perfil ObtenerPerfil(string legajo);
    }
}