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
        Guid _idUsuario;
        Guid _idProducto;
        int _cantidad;

        public Guid IdCliente { get => _idCliente; set => _idCliente = value; }
        public Guid IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public Guid IdProducto { get => _idProducto; set => _idProducto = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
    public Ventas()
        {
            _idUsuario = new Guid("784c07f2-2b26-4973-9235-4064e94832b5");
        }
    }
}

