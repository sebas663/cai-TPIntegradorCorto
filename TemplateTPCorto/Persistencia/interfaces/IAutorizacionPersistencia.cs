using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.interfaces
{
    /// <summary>
    /// Interfaz para la gestión de autorizaciones en la capa de persistencia.
    /// Define métodos para actualizar, registrar y obtener autorizaciones y operaciones relacionadas.
    /// </summary>
    public interface IAutorizacionPersistencia
    {
        /// <summary>
        /// Actualiza el estado de una autorización existente en la base de datos.
        /// </summary>
        /// <param name="autorizacion">La autorización con el nuevo estado.</param>
        void ActualizarEstadoAutorizacion(Autorizacion autorizacion);

        /// <summary>
        /// Crea una nueva autorización en la base de datos.
        /// </summary>
        /// <param name="autorizacion">Los datos de la autorización a crear.</param>
        /// <returns>El identificador único de la autorización creada.</returns>
        string CrearAutorizacion(Autorizacion autorizacion);

        /// <summary>
        /// Obtiene una lista de autorizaciones filtradas por tipo de operación y estado.
        /// </summary>
        /// <param name="tipoOperacion">El tipo de operación asociada a las autorizaciones.</param>
        /// <param name="estado">El estado actual de las autorizaciones.</param>
        /// <returns>Lista de autorizaciones que coinciden con los filtros.</returns>
        List<Autorizacion> ObtenerAutorizacionesPorTipoOperacionEstado(string tipoOperacion, string estado);

        /// <summary>
        /// Obtiene una autorización específica mediante su identificador de operación.
        /// </summary>
        /// <param name="idOperacion">El identificador único de la operación asociada a la autorización.</param>
        /// <returns>La autorización encontrada o null si no existe.</returns>
        Autorizacion ObtenerAutorizacionPorIdOperacion(string idOperacion);

        /// <summary>
        /// Obtiene una lista de operaciones de cambio de credencial basadas en múltiples identificadores de operación.
        /// </summary>
        /// <param name="idsOperacion">Lista de identificadores de operación.</param>
        /// <returns>Lista de operaciones de cambio de credencial asociadas.</returns>
        List<OperacionCambioCredencial> ObtenerOperacionesCambioCredencialPorIdsOperacion(List<string> idsOperacion);

        /// <summary>
        /// Obtiene una lista de operaciones de cambio de persona basadas en múltiples identificadores de operación.
        /// </summary>
        /// <param name="idsOperacion">Lista de identificadores de operación.</param>
        /// <returns>Lista de operaciones de cambio de persona asociadas.</returns>
        List<OperacionCambioPersona> ObtenerOperacionesCambioPersonaPorIdsOperacion(List<string> idsOperacion);

        /// <summary>
        /// Registra una operación de cambio de credencial en la base de datos.
        /// </summary>
        /// <param name="operacion">La operación de cambio de credencial a registrar.</param>
        void RegistrarOperacionCambioCredencial(OperacionCambioCredencial operacion);

        /// <summary>
        /// Registra una operación de cambio de persona en la base de datos.
        /// </summary>
        /// <param name="operacion">La operación de cambio de persona a registrar.</param>
        void RegistrarOperacionCambioPersona(OperacionCambioPersona operacion);
    }
}