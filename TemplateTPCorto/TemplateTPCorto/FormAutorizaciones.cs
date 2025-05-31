using Datos;
using Negocio;
using Negocio.interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    /// <summary>
    /// Control de usuario encargado de gestionar las autorizaciones o rechazos para operaciones
    /// de cambio de credencial y cambio de datos de persona.
    /// </summary>
    public partial class FormAutorizaciones : UserControl
    {
        private readonly IGestionUsuarioNegocio gestionUsuarioNegocio;
        private readonly IAutorizacionNegocio autorizacionNegocio;
        private readonly Credencial usuarioLogueado;
        private bool esCambioCredencial = false;

        /// <summary>
        /// Inicializa una nueva instancia de la clase FormAutorizaciones.
        /// </summary>
        /// <param name="gestionUsuarioNegocio">Interfaz para la gestión de usuarios.</param>
        /// <param name="autorizacionNegocio">Interfaz para la autorización de cambios.</param>
        /// <param name="logueado">Credencial del usuario autenticado.</param>
        public FormAutorizaciones(IGestionUsuarioNegocio gestionUsuarioNegocio, IAutorizacionNegocio autorizacionNegocio, Credencial logueado)
        {
            InitializeComponent();
            this.gestionUsuarioNegocio = gestionUsuarioNegocio;
            this.autorizacionNegocio = autorizacionNegocio;
            this.usuarioLogueado = logueado;
            ConfigurarInterfaz();
        }

        /// <summary>
        /// Configura la interfaz del formulario, estableciendo la visibilidad de botones y propiedades del DataGridView.
        /// </summary>
        private void ConfigurarInterfaz()
        {
            // Inicialmente ocultar botones y etiquetas para evitar confusiones.
            BtnOperacionesCambioCredencial.Visible = false;
            BtnOperacionesCambioPersona.Visible = false;
            labelTipoOperacion.Visible = false;

            // Configura el DataGridView para no permitir agregar o eliminar filas.
            dgwAutorizarOperaciones.AllowUserToAddRows = false;
            dgwAutorizarOperaciones.AllowUserToDeleteRows = false;

            // Obtiene el perfil del usuario autenticado y asigna la visibilidad de botones según roles.
            Perfil perfil = gestionUsuarioNegocio.ObtenerPerfil(usuarioLogueado.Legajo);

            if (FormUtils.TieneRol(perfil.Roles, (int)EnumRolId.AutorizarModificarPersona))
            {
                BtnOperacionesCambioPersona.Visible = true;
            }
            if (FormUtils.TieneRol(perfil.Roles, (int)EnumRolId.AutorizarDesbloquearCredencial))
            {
                BtnOperacionesCambioCredencial.Visible = true;
            }
        }

        /// <summary>
        /// Evento que se produce al hacer clic en el botón para operaciones de cambio de credencial.
        /// Carga las operaciones pendientes y agrega la columna de selección.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void BtnOperacionesCambioCredencial_Click(object sender, EventArgs e)
        {
            esCambioCredencial = true;
            dgwAutorizarOperaciones.Columns.Clear();
            labelTipoOperacion.Text = BtnOperacionesCambioCredencial.Text;
            labelTipoOperacion.Visible = true;

            List<OperacionCambioCredencial> lista = autorizacionNegocio.ObtenerOperacionesCambioCredencialPendientesAutorizar();
            if (lista != null && lista.Count > 0)
            {
                dgwAutorizarOperaciones.DataSource = lista;
                AutorizacionesUtils.AgregarColumnaSeleccion(dgwAutorizarOperaciones);
            }
            else
            {
                FormUtils.MostrarMensajeInformacion("No hay operaciones cambio credencial con estado Pendiente.");
            }
        }

        /// <summary>
        /// Evento que se produce al hacer clic en el botón para operaciones de cambio de persona.
        /// Carga las operaciones pendientes y agrega la columna de selección.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void BtnOperacionesCambioPersona_Click(object sender, EventArgs e)
        {
            esCambioCredencial = false;
            dgwAutorizarOperaciones.Columns.Clear();
            labelTipoOperacion.Text = BtnOperacionesCambioPersona.Text;
            labelTipoOperacion.Visible = true;

            List<OperacionCambioPersona> lista = autorizacionNegocio.ObtenerOperacionesCambioPersonaPendientesAutorizar();
            if (lista != null && lista.Count > 0)
            {
                dgwAutorizarOperaciones.DataSource = lista;
                AutorizacionesUtils.AgregarColumnaSeleccion(dgwAutorizarOperaciones);
            }
            else
            {
                FormUtils.MostrarMensajeInformacion("No hay operaciones cambio persona con estado Pendiente.");
            }
        }

        /// <summary>
        /// Evento que se produce al hacer clic en el botón para autorizar operaciones seleccionadas.
        /// Verifica selección, muestra un mensaje de confirmación y ejecuta la autorización según tipo.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void BtnAutorizarSeleccionados_Click(object sender, EventArgs e)
        {
            if (AutorizacionesUtils.HayAlMenosUnoSeleccionado(dgwAutorizarOperaciones))
            {
                string mensaje = AutorizacionesUtils.GenerarMensajeSeleccionados(dgwAutorizarOperaciones);
                DialogResult result = MessageBox.Show(mensaje, "Confirmar autorizaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (esCambioCredencial)
                    {
                        List<OperacionCambioCredencial> operaciones = AutorizacionesUtils.ObtenerOperacionesCambioCredencialesSeleccionadas(dgwAutorizarOperaciones);
                        autorizacionNegocio.AutorizarOperacionesCambioCredencial(operaciones, usuarioLogueado.Legajo);
                    }
                    else
                    {
                        List<OperacionCambioPersona> operaciones = AutorizacionesUtils.ObtenerOperacionesCambioDatosPersonasSeleccionadas(dgwAutorizarOperaciones);
                        autorizacionNegocio.AutorizarOperacionesCambioPersona(operaciones, usuarioLogueado.Legajo);
                    }
                    FormUtils.MostrarMensajeInformacion("Las autorizaciones se ejecutaron con éxito.");
                    dgwAutorizarOperaciones.Columns.Clear();
                }
            }
            else
            {
                FormUtils.MostrarMensajeAdvertencia("Debe seleccionar al menos un registro.");
            }
        }

        /// <summary>
        /// Evento que se produce al hacer clic en el botón para rechazar operaciones seleccionadas.
        /// Verifica selección, muestra un mensaje de confirmación y ejecuta el rechazo según tipo.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void BtnRechazarSeleccionados_Click(object sender, EventArgs e)
        {
            if (AutorizacionesUtils.HayAlMenosUnoSeleccionado(dgwAutorizarOperaciones))
            {
                string mensaje = AutorizacionesUtils.GenerarMensajeSeleccionados(dgwAutorizarOperaciones);
                DialogResult result = MessageBox.Show(mensaje, "Confirmar rechazos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (esCambioCredencial)
                    {
                        List<OperacionCambioCredencial> operaciones = AutorizacionesUtils.ObtenerOperacionesCambioCredencialesSeleccionadas(dgwAutorizarOperaciones);
                        autorizacionNegocio.RechazarOperacionesCambioCredencial(operaciones, usuarioLogueado.Legajo);
                    }
                    else
                    {
                        List<OperacionCambioPersona> operaciones = AutorizacionesUtils.ObtenerOperacionesCambioDatosPersonasSeleccionadas(dgwAutorizarOperaciones);
                        autorizacionNegocio.RechazarOperacionesCambioPersona(operaciones, usuarioLogueado.Legajo);
                    }
                    FormUtils.MostrarMensajeInformacion("Los rechazos se ejecutaron con éxito.");
                    dgwAutorizarOperaciones.Columns.Clear();
                }
            }
            else
            {
                FormUtils.MostrarMensajeAdvertencia("Debe seleccionar al menos un registro.");
            }
        }
    }
}