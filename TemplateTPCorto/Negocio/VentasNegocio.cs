using Datos;
using Datos.Ventas;
using Persistencia;
using Persistencia.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentasNegocio:IVentasNegocio
    {
        private readonly IClientePersistencia clientePersistencia;
        private readonly IVentaPersistencia ventaPersistencia;
        public VentasNegocio(IClientePersistencia clientePersistencia, IVentaPersistencia ventaPersistencia)
        {
            this.clientePersistencia = clientePersistencia;
            this.ventaPersistencia = ventaPersistencia;
        }
        public List<Cliente> ObtenerClientes()
        {
            return clientePersistencia.ObtenerClientes();
        }

        public List<CategoriaProductos> ObtenerCategoriaProductos()
        {
            List<CategoriaProductos> categoriaProductos = new List<CategoriaProductos>();

            CategoriaProductos p1 = new CategoriaProductos("1", "Audio");
            categoriaProductos.Add(p1);

            CategoriaProductos p2 = new CategoriaProductos("2", "Celulares");
            categoriaProductos.Add(p2);

            CategoriaProductos p3 = new CategoriaProductos("3", "Electro Hogar");
            categoriaProductos.Add(p3);

            CategoriaProductos p4 = new CategoriaProductos("4", "Informática");
            categoriaProductos.Add(p4);

            CategoriaProductos p5 = new CategoriaProductos("5", "Smart TV");
            categoriaProductos.Add(p5);

            return categoriaProductos;
        }
        public bool RegistrarVenta(Venta venta)
        {
            return ventaPersistencia.GuardarVenta(venta);
        }
    }
}
