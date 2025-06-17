using Datos.Ventas;
using System;

namespace Persistencia
{
    /// <summary>
    /// Define las operaciones de acceso a datos relacionadas con ventas.
    /// </summary>
    public interface IVentaPersistencia
    {
        /// <summary>
        /// Guarda una venta en el sistema de persistencia.
        /// </summary>
        /// <param name="venta">El objeto venta que se desea guardar.</param>
        /// <returns>
        /// Verdadero si la venta fue guardada correctamente; de lo contrario, falso.
        /// </returns>
        bool GuardarVenta(Venta venta);
    }
}
