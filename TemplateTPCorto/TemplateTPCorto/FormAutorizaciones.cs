using Datos;
using Negocio;
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
        private readonly Credencial usuarioLogueado;
        private bool esCambioCredencial = false;
        public FormAutorizaciones(Credencial logueado)
        {
            InitializeComponent();
            usuarioLogueado = logueado;
        }

        private void BtnOperacionesCambioCredencial_Click(object sender, EventArgs e)
        {
            esCambioCredencial = true;
            LoginNegocio loginNegocio = new LoginNegocio();
            dgwAutorizarOperaciones.Columns.Clear();
            List<OperacionCambioCredencial>  lista = loginNegocio.ObtenerOperacionesCambioCredencialPendientesAutorizar();
            if (lista.Count > 0)
            {
                dgwAutorizarOperaciones.DataSource = lista;
                AgregarColumnaSeleccion(dgwAutorizarOperaciones);
            }
            else
            {
                MessageBox.Show("No hay operaciones cambio credencial con estado Pendiente.");
            }
        }

        private void BtnOperacionesCambioPersona_Click(object sender, EventArgs e)
        {
            esCambioCredencial = false;
            LoginNegocio loginNegocio = new LoginNegocio();
            dgwAutorizarOperaciones.Columns.Clear();
            List<OperacionCambioPersona> lista = loginNegocio.ObtenerOperacionesCambioPersonaPendientesAutorizar();
            if (lista.Count > 0)
            {
                dgwAutorizarOperaciones.DataSource = lista;
                AgregarColumnaSeleccion(dgwAutorizarOperaciones);
            }
            else
            {
                MessageBox.Show("No hay operaciones cambio persona con estado Pendiente.");
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
                    LoginNegocio loginNegocio = new LoginNegocio();
                    if (esCambioCredencial)
                    {
                        List<OperacionCambioCredencial> operaciones = ObtenerOperacionesCambioCredencialesSeleccionadas();
                        loginNegocio.AutorizarOperacionesCambioCredencial(operaciones, usuarioLogueado.Legajo);
                    }
                    else
                    {
                        List<OperacionCambioPersona> operaciones = ObtenerOperacionesCambioDatosPersonasSeleccionadas();
                        loginNegocio.AutorizarOperacionesCambioPersona(operaciones, usuarioLogueado.Legajo);
                    }
                    MessageBox.Show("Las autorizaciones se ejecutaron con éxito.");
                    dgwAutorizarOperaciones.Columns.Clear();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos un registro.");
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
                    LoginNegocio loginNegocio = new LoginNegocio();
                    if (esCambioCredencial)
                    {
                        List<OperacionCambioCredencial> operaciones = ObtenerOperacionesCambioCredencialesSeleccionadas();
                        loginNegocio.RechazarOperacionesCambioCredencial(operaciones, usuarioLogueado.Legajo);
                    }
                    else
                    {
                        List<OperacionCambioPersona> operaciones = ObtenerOperacionesCambioDatosPersonasSeleccionadas();
                        loginNegocio.RechazarOperacionesCambioPersona(operaciones, usuarioLogueado.Legajo);
                    }
                    MessageBox.Show("Los rechazos se ejecutaron con éxito.");
                    dgwAutorizarOperaciones.Columns.Clear();
                }
            }
            else {
                MessageBox.Show("Debe seleccionar al menos un registro.");
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
                    resultado += "- ";
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.OwningColumn.Name != "Seleccionar")
                            resultado += $"{cell.Value} ";
                    }
                    resultado += "\n";
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
                TrueValue = true
            };
            chk.HeaderText = "Seleccionar";
            chk.Name = "Seleccionar";
            dgv.Columns.Insert(0, chk);
            // Inicializar todas las celdas con false
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                fila.Cells["Seleccionar"].Value = false;
            }
        }
    }

}
