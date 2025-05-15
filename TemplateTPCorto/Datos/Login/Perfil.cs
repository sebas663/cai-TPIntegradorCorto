using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Perfil
    {
        private String _id;
        private String _descripcion;
        private List<Rol> _roles;

        public string Id { get => _id; set => _id = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }

        public List<Rol> Roles { get => _roles; set => _roles = value; }

        public Perfil(String registro, List<Rol> roles)
        {
            String[] datos = registro.Split(';');
            this._id = datos[0];
            this._descripcion = datos[1];
            this._roles = roles;
        }

    }
}
