using Datos;
using System;
using System.Collections.Generic;

namespace Persistencia
{
    /// <summary>
    /// Define las operaciones de acceso a datos relacionadas con los clientes.
    /// </summary>
    public interface IClientePersistencia
    {
        /// <summary>
        /// Obtiene la lista completa de clientes.
        /// </summary>
        /// <returns>Una lista de todos los clientes disponibles.</returns>
        List<Cliente> ObtenerClientes();
    }
}
