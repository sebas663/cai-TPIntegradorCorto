using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateTPCorto
{
    public class FormUtils
    {
        public bool TieneRol(List<Rol> roles, int rolId)
        {
            bool tieneRol = false;
            foreach (Rol rol in roles)
            {
                if (rol.Id == rolId.ToString())
                {
                    tieneRol = true;
                    break;
                }
            }
            return tieneRol;
        }
    }
}
