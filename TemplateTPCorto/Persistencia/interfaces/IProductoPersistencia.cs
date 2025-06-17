using Datos;
using System;
using System.Collections.Generic;

namespace Persistencia
{
    /// <summary>
    /// Define las operaciones de acceso a datos relacionadas con productos.
    /// </summary>
    public interface IProductoPersistencia
    {
        /// <summary>
        /// Obtiene una lista de productos pertenecientes a una categoría específica.
        /// </summary>
        /// <param name="categoria">El nombre de la categoría para filtrar los productos.</param>
        /// <returns>Una lista de productos que pertenecen a la categoría especificada.</returns>
        List<Producto> ObtenerProductosPorCategoria(string categoria);
    }
}
