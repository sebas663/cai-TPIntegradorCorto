using Datos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    /// <summary>
    /// Clase encargada de configurar la visibilidad de los botones del menú según el perfil y los roles del usuario.
    /// </summary>
    public class MenuConfigurador
    {
        private readonly Perfil perfil;
        private readonly List<Rol> rolesUsuario;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="MenuConfigurador"/> con el perfil del usuario.
        /// </summary>
        /// <param name="perfil">Perfil del usuario autenticado.</param>
        public MenuConfigurador(Perfil perfil)
        {
            this.perfil = perfil ?? throw new ArgumentNullException(nameof(perfil));
            this.rolesUsuario = perfil.Roles ?? new List<Rol>();
        }

        /// <summary>
        /// Configura la visibilidad de los botones del menú según el perfil y los roles del usuario.
        /// </summary>
        /// <param name="botones">Diccionario de botones donde la clave es el nombre lógico del botón.</param>
        public void ConfigurarBotones(Dictionary<string, Button> botones)
        {
            if (!botones.ContainsKey("btnCambioContrasenia") || !botones.ContainsKey("btnVentas") ||
                !botones.ContainsKey("btnModificarPersona") || !botones.ContainsKey("btnDesbloquearCredencial") ||
                !botones.ContainsKey("btnAutorizaciones"))
            {
                throw new ArgumentException("El diccionario de botones no contiene las claves necesarias.");
            }

            // Configuración de botones según perfil y roles
            botones["btnCambioContrasenia"].Visible = true;

            if (perfil.Id == ((int)EnumPerfilId.Operador).ToString() &&
                FormUtils.TieneRol(rolesUsuario, (int)EnumRolId.Operador))
            {
                botones["btnVentas"].Visible = true;
            }

            if (perfil.Id == ((int)EnumPerfilId.Supervisor).ToString())
            {
                if (FormUtils.TieneRol(rolesUsuario, (int)EnumRolId.ModificarPersona))
                    botones["btnModificarPersona"].Visible = true;

                if (FormUtils.TieneRol(rolesUsuario, (int)EnumRolId.DesbloquearCredencial))
                    botones["btnDesbloquearCredencial"].Visible = true;
            }

            if (perfil.Id == ((int)EnumPerfilId.Administrador).ToString())
            {
                if (FormUtils.TieneRol(rolesUsuario, (int)EnumRolId.AutorizarModificarPersona) ||
                    FormUtils.TieneRol(rolesUsuario, (int)EnumRolId.AutorizarDesbloquearCredencial))
                {
                    botones["btnAutorizaciones"].Visible = true;
                }
            }
        }
    }
}