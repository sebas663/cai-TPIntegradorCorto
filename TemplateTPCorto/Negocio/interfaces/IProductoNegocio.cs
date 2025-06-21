using Datos;
using System;
using System.Collections.Generic;

namespace Negocio
{
    /// <summary>
    /// Define las operaciones de negocio relacionadas con los productos.
    /// </summary>
    public interface IProductoNegocio
    {
        /// <summary>
        /// Obtiene una lista de productos filtrados por categoría.
        /// </summary>
        /// <param name="categoria">Nombre de la categoría a filtrar.</param>
        /// <returns>Una lista de productos que pertenecen a la categoría especificada.</returns>
        List<Producto> ObtenerProductosPorCategoria(string categoria);
        /// <summary>
        /// Obtiene un producto por idProducto y categoría.
        /// </summary>
        /// <param name="idProducto">ID del producto a filtrar.</param>
        /// <param name="idCategoria">ID de la categoría a filtrar.</param>
        /// <returns>Un producto que perteneceneciente a los id ingresados.</returns>
        Producto ObtenerProductosPorIDProductoYCategoria(Guid idProducto, int idCategoria);
    }
}
