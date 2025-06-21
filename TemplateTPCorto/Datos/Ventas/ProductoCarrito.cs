using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Ventas
{
    public class ProductoCarrito
    {
        public Guid IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int IdCategoria { get; set; }

        public int Subtotal
        {
            get { return PrecioUnitario * Cantidad; }
        }

        public override string ToString()
        {
            return $"{NombreProducto} - ${PrecioUnitario} x {Cantidad} = ${Subtotal}";
        }
    }
}
