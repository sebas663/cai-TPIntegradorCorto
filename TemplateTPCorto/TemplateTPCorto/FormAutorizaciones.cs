using Datos;
using Negocio;
using Negocio.interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public partial class FormAutorizaciones : UserControl
    {
        private readonly IGestionUsuarioNegocio gestionUsuarioNegocio;
        private readonly IAutorizacionNegocio autorizacionNegocio;
        private readonly Credencial usuarioLogueado;
        private bool esCambioCredencial = false;
        public FormAutorizaciones(IGestionUsuarioNegocio gestionUsuarioNegocio, IAutorizacionNegocio autorizacionNegocio, Credencial logueado)
        {
            InitializeComponent();
            this.gestionUsuarioNegocio = gestionUsuarioNegocio;
            this.autorizacionNegocio = autorizacionNegocio;
            this.usuarioLogueado = logueado;
            BtnOperacionesCambioCredencial.Visible = false;
            BtnOperacionesCambioPersona.Visible = false;
            labelTipoOperacion.Visible = false;
            dgwAutorizarOperaciones.AllowUserToAddRows = false;
            dgwAutorizarOperaciones.AllowUserToDeleteRows = false;
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

        private void BtnOperacionesCambioCredencial_Click(object sender, EventArgs e)
        {
            esCambioCredencial = true;
            dgwAutorizarOperaciones.Columns.Clear();
            labelTipoOperacion.Text = BtnOperacionesCambioCredencial.Text;
            labelTipoOperacion.Visible = true;
            List<OperacionCambioCredencial>  lista = autorizacionNegocio.ObtenerOperacionesCambioCredencialPendientesAutorizar();
            if (lista.Count > 0)
            {
                dgwAutorizarOperaciones.DataSource = lista;
                AgregarColumnaSeleccion(dgwAutorizarOperaciones);
            }
            else
            {
                FormUtils.MostrarMensajeInformacion("No hay operaciones cambio credencial con estado Pendiente.");
            }
        }
        private void BtnOperacionesCambioPersona_Click(object sender, EventArgs e)
        {
            esCambioCredencial = false;
            dgwAutorizarOperaciones.Columns.Clear();
            labelTipoOperacion.Text = BtnOperacionesCambioPersona.Text;
            labelTipoOperacion.Visible = true;
            List<OperacionCambioPersona> lista = autorizacionNegocio.ObtenerOperacionesCambioPersonaPendientesAutorizar();
            if (lista.Count > 0)
            {
                dgwAutorizarOperaciones.DataSource = lista;
                AgregarColumnaSeleccion(dgwAutorizarOperaciones);
            }
            else
            {
                FormUtils.MostrarMensajeInformacion("No hay operaciones cambio persona con estado Pendiente.");
            }
        }
        private void BtnAutorizarSeleccionados_Click(object sender, EventArgs e)
        {
            if (HayAlMenosUnoSeleccionado())
            {
                string mensaje = GenerarMensajeSeleccionados();
                DialogResult result = MessageBox.Show(
                        mensaje,
                        "Confirmar autorizaciones",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                if (result == DialogResult.Yes)
                {
                    if (esCambioCredencial)
                    {
                        List<OperacionCambioCredencial> operaciones = ObtenerOperacionesCambioCredencialesSeleccionadas();
                        autorizacionNegocio.AutorizarOperacionesCambioCredencial(operaciones, usuarioLogueado.Legajo);
                    }
                    else
                    {
                        List<OperacionCambioPersona> operaciones = ObtenerOperacionesCambioDatosPersonasSeleccionadas();
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
        private void BtnRechazarSeleccionados_Click(object sender, EventArgs e)
        {
            if (HayAlMenosUnoSeleccionado())
            {
                string mensaje = GenerarMensajeSeleccionados();
                DialogResult result = MessageBox.Show(
                        mensaje,
                        "Confirmar rechazos",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                if (result == DialogResult.Yes)
                {
                    if (esCambioCredencial)
                    {
                        List<OperacionCambioCredencial> operaciones = ObtenerOperacionesCambioCredencialesSeleccionadas();
                        autorizacionNegocio.RechazarOperacionesCambioCredencial(operaciones, usuarioLogueado.Legajo);
                    }
                    else
                    {
                        List<OperacionCambioPersona> operaciones = ObtenerOperacionesCambioDatosPersonasSeleccionadas();
                        autorizacionNegocio.RechazarOperacionesCambioPersona(operaciones, usuarioLogueado.Legajo);
                    }
                    FormUtils.MostrarMensajeInformacion("Los rechazos se ejecutaron con éxito.");
                    dgwAutorizarOperaciones.Columns.Clear();
                }
            }
            else {
                FormUtils.MostrarMensajeAdvertencia("Debe seleccionar al menos un registro.");
            }
            
        }
        private List<OperacionCambioCredencial> ObtenerOperacionesCambioCredencialesSeleccionadas()
        {
            List<OperacionCambioCredencial> seleccionados = new List<OperacionCambioCredencial>();

            foreach (DataGridViewRow row in dgwAutorizarOperaciones.Rows)
            {
                bool seleccionado = Convert.ToBoolean(row.Cells["Seleccionar"].Value ?? false);
                if (seleccionado)
                {
                    string lineaCsv = GenerarLineaCSVDesdeFila(row);
                    seleccionados.Add(new OperacionCambioCredencial(lineaCsv));
                }
            }

            return seleccionados;
        }
        private List<OperacionCambioPersona> ObtenerOperacionesCambioDatosPersonasSeleccionadas()
        {
            List<OperacionCambioPersona> seleccionados = new List<OperacionCambioPersona>();

            foreach (DataGridViewRow row in dgwAutorizarOperaciones.Rows)
            {
                bool seleccionado = Convert.ToBoolean(row.Cells["Seleccionar"].Value ?? false);
                if (seleccionado)
                {
                    string lineaCsv = GenerarLineaCSVDesdeFila(row);
                    seleccionados.Add(new OperacionCambioPersona(lineaCsv));
                }
            }

            return seleccionados;
        }
        private bool HayAlMenosUnoSeleccionado()
        {
            bool alMenosUnoChequeado = false;
            foreach (DataGridViewRow fila in dgwAutorizarOperaciones.Rows)
            {
                if (fila.Cells["Seleccionar"].Value != null &&
                    Convert.ToBoolean(fila.Cells["Seleccionar"].Value))
                {
                    alMenosUnoChequeado = true;
                    break;
                }
            }

            return alMenosUnoChequeado;
        }
        private string GenerarMensajeSeleccionados()
        {
            string resultado = "Registros seleccionados:\n";
            foreach (DataGridViewRow row in dgwAutorizarOperaciones.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Seleccionar"].Value) == true)
                {
                    List<string> campos = new List<string>();

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.OwningColumn.Name == "Seleccionar")
                            continue;

                        string label = cell.OwningColumn.HeaderText;
                        string valor;

                        if (cell.Value is DateTime fecha)
                        {
                            valor = fecha.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
                        }
                        else if (DateTime.TryParse(Convert.ToString(cell.Value), out fecha))
                        {
                            valor = fecha.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            valor = Convert.ToString(cell.Value);
                        }
                        campos.Add($"{label}: {valor}");
                    }
                    resultado += string.Join(" - ", campos) + "\n";
                }
            }
            return resultado;
        }
        private string GenerarLineaCSVDesdeFila(DataGridViewRow row)
        {
            List<string> valores = new List<string>();

            for (int i = 1; i < row.Cells.Count; i++) // Salta la columna de selección
            {
                var header = row.DataGridView.Columns[i].Name;
                var valor = row.Cells[i].Value;

                if (valor is DateTime fecha)
                {
                    valores.Add(fecha.ToString("d/M/yyyy", CultureInfo.InvariantCulture));
                }
                else if (!string.IsNullOrEmpty(header) &&
                         header.ToLower().Contains("fecha") &&
                         DateTime.TryParse(valor?.ToString(), out var fechaParsed))
                {
                    valores.Add(fechaParsed.ToString("d/M/yyyy", CultureInfo.InvariantCulture));
                }
                else
                {
                    valores.Add(valor?.ToString()?.Trim() ?? "");
                }
            }

            return string.Join(";", valores);
        }
        private void AgregarColumnaSeleccion(DataGridView dgv)
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Seleccionar",
                Name = "Seleccionar",
                FalseValue = false,
                TrueValue = true,
                ReadOnly = false
            };
            dgv.Columns.Insert(0, chk);
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Name != "Seleccionar")
                    col.ReadOnly = true;
            }
            // Inicializar todas las celdas con false
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                fila.Cells["Seleccionar"].Value = false;
            }
        }

    }

}
