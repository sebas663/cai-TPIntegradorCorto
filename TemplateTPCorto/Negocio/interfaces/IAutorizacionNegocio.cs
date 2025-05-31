using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.interfaces
{
    /// <summary>
    /// Interfaz para la gestión de autorizaciones en la capa de negocio.
    /// Define operaciones para registrar, aprobar y rechazar cambios en credenciales y datos de usuario.
    /// </summary>
    public interface IAutorizacionNegocio
    {
        /// <summary>
        /// Registra una operación de cambio de credencial para su posterior autorización.
        /// </summary>
        /// <param name="autorizacion">El objeto <see cref="Autorizacion"/> asociado a la solicitud.</param>
        /// <param name="operacion">El objeto <see cref="OperacionCambioCredencial"/> con los datos modificados.</param>
        void RegistrarOperacionCambioCredencial(Autorizacion autorizacion, OperacionCambioCredencial operacion);

        /// <summary>
        /// Registra una operación de cambio de datos personales para su posterior autorización.
        /// </summary>
        /// <param name="autorizacion">El objeto <see cref="Autorizacion"/> asociado a la solicitud.</param>
        /// <param name="operacion">El objeto <see cref="OperacionCambioPersona"/> con los datos modificados.</param>
        void RegistrarOperacionCambioPersona(Autorizacion autorizacion, OperacionCambioPersona operacion);

        /// <summary>
        /// Obtiene la lista de operaciones de cambio de credencial que están pendientes de autorización.
        /// </summary>
        /// <returns>
        /// Una lista de <see cref="OperacionCambioCredencial"/> con las solicitudes pendientes.
        /// </returns>
        List<OperacionCambioCredencial> ObtenerOperacionesCambioCredencialPendientesAutorizar();

        /// <summary>
        /// Obtiene la lista de operaciones de cambio de datos personales que están pendientes de autorización.
        /// </summary>
        /// <returns>
        /// Una lista de <see cref="OperacionCambioPersona"/> con las solicitudes pendientes.
        /// </returns>
        List<OperacionCambioPersona> ObtenerOperacionesCambioPersonaPendientesAutorizar();

        /// <summary>
        /// Autoriza un conjunto de operaciones de cambio de credencial.
        /// </summary>
        /// <param name="operaciones">Lista de <see cref="OperacionCambioCredencial"/> a autorizar.</param>
        /// <param name="legajoAutorizador">El número de legajo del usuario que autoriza los cambios.</param>
        void AutorizarOperacionesCambioCredencial(List<OperacionCambioCredencial> operaciones, string legajoAutorizador);

        /// <summary>
        /// Autoriza un conjunto de operaciones de cambio de datos personales.
        /// </summary>
        /// <param name="operaciones">Lista de <see cref="OperacionCambioPersona"/> a autorizar.</param>
        /// <param name="legajoAutorizador">El número de legajo del usuario que autoriza los cambios.</param>
        void AutorizarOperacionesCambioPersona(List<OperacionCambioPersona> operaciones, string legajoAutorizador);

        /// <summary>
        /// Rechaza un conjunto de operaciones de cambio de credencial.
        /// </summary>
        /// <param name="operaciones">Lista de <see cref="OperacionCambioCredencial"/> a rechazar.</param>
        /// <param name="legajoAutorizador">El número de legajo del usuario que rechaza los cambios.</param>
        void RechazarOperacionesCambioCredencial(List<OperacionCambioCredencial> operaciones, string legajoAutorizador);

        /// <summary>
        /// Rechaza un conjunto de operaciones de cambio de datos personales.
        /// </summary>
        /// <param name="operaciones">Lista de <see cref="OperacionCambioPersona"/> a rechazar.</param>
        /// <param name="legajoAutorizador">El número de legajo del usuario que rechaza los cambios.</param>
        void RechazarOperacionesCambioPersona(List<OperacionCambioPersona> operaciones, string legajoAutorizador);
    }
}