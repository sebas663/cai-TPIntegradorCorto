using Datos;
using Negocio.interfaces;
using Persistencia;
using Persistencia.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestionUsuarioNegocio:IGestionUsuarioNegocio
    {
        private readonly IGestionUsuarioPersistencia gestionUsuarioPersistencia;

        public GestionUsuarioNegocio(IGestionUsuarioPersistencia gestionUsuarioPersistencia)
        {
            this.gestionUsuarioPersistencia = gestionUsuarioPersistencia;
        }
        public Perfil ObtenerPerfil(string legajo)
        {
            return gestionUsuarioPersistencia.ObtenerPerfil(legajo);
        }
        public void ActualizarContrasenia(Credencial credencial)
        {
            gestionUsuarioPersistencia.ActualizarContrasenia(credencial);
        }
        public Credencial BuscarCredencialPorNumeroLegajo(String legajo)
        {
            return gestionUsuarioPersistencia.BuscarCredencialPorNumeroLegajo(legajo);
        }
        public Persona BuscarPersonaPorNumeroLegajo(string legajo)
        {
            return gestionUsuarioPersistencia.BuscarPersonaPorNumeroLegajo(legajo);
        }
        public void DesbloquearUsuarioBloqueadoPorLegajo(string legajo)
        {
            gestionUsuarioPersistencia.DesbloquearUsuarioBloqueadoPorLegajo(legajo);
        }
        public void ActualizarDatosPersonaPorLegajo(Persona modificada)
        {
            gestionUsuarioPersistencia.ActualizarDatosPersonaPorLegajo(modificada);
        }
    }
}
