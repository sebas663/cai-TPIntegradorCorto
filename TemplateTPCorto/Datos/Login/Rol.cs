using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Rol
    {
        private String _id;
        private String _descripcion;

        public string Id { get => _id; set => _id = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }

        public Rol(String registro)
        {
            String[] datos = registro.Split(';');
            this._id = datos[0];
            this._descripcion = datos[1];
        }
    }
}
