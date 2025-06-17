using Datos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProductoNegocio:IProductoNegocio
    {
        private readonly IProductoPersistencia productoPersistencia;
        public ProductoNegocio(IProductoPersistencia productoPersistencia)
        {
            this.productoPersistencia = productoPersistencia;
        }
        public List<Producto> ObtenerProductosPorCategoria(string categoria)
        {
            // Obtengo todos los productos de la categoría
            List<Producto> productos = productoPersistencia.ObtenerProductosPorCategoria(categoria);

            // Creo una lista para almacenar productos con stock positivo
            List<Producto> productosConStock = new List<Producto>();

            // Recorro cada producto y filtro los que tienen stock > 0
            foreach (Producto producto in productos)
            {
                if (producto.Stock > 0)
                {
                    productosConStock.Add(producto);
                }
            }

            // Retorno la lista filtrada
            return productosConStock;
        }

    }
}
