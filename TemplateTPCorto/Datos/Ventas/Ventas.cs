using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Ventas
{
    public class Ventas
    {
        Guid _idCliente;
        String _idUsuario;
        Guid _idProducto;
        int _cantidad;

        public Guid IdCliente { get => _idCliente; set => _idCliente = value; }
        public String IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public Guid IdProducto { get => _idProducto; set => _idProducto = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
    }
}
