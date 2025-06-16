using Datos.Ventas;
using Datos;
using System;
using System.Collections.Generic;

namespace Negocio
{
    /// <summary>
    /// Define las operaciones de negocio relacionadas con ventas, clientes y categorías de productos.
    /// </summary>
    public interface IVentasNegocio
    {
        /// <summary>
        /// Obtiene la lista de todos los clientes disponibles.
        /// </summary>
        /// <returns>Lista de clientes.</returns>
        List<Cliente> ObtenerClientes();

        /// <summary>
        /// Obtiene la lista de todas las categorías de productos disponibles.
        /// </summary>
        /// <returns>Lista de categorías de productos.</returns>
        List<CategoriaProductos> ObtenerCategoriaProductos();

        /// <summary>
        /// Registra una venta en el sistema.
        /// </summary>
        /// <param name="venta">La venta que se desea registrar.</param>
        /// <returns>Verdadero si la venta fue registrada correctamente; de lo contrario, falso.</returns>
        bool RegistrarVenta(Venta venta);
    }
}
