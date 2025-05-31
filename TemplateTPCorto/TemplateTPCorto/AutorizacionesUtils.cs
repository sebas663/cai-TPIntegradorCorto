using Datos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    /// <summary>
    /// Clase utilitaria para el manejo de operaciones de autorizaciones en formularios.
    /// Provee métodos para obtener operaciones seleccionadas, generar mensajes descriptivos
    /// de las filas seleccionadas, generar líneas CSV y la creación de una columna de selección.
    /// </summary>
    public static class AutorizacionesUtils
    {
        /// <summary>
        /// Obtiene la lista de operaciones de cambio de credencial seleccionadas presentes en el DataGridView.
        /// </summary>
        /// <param name="dataGridView">Instancia de DataGridView que contiene las operaciones.</param>
        /// <returns>Lista de operaciones de cambio de credencial seleccionadas.</returns>
        public static List<OperacionCambioCredencial> ObtenerOperacionesCambioCredencialesSeleccionadas(DataGridView dataGridView)
        {
            List<OperacionCambioCredencial> seleccionados = new List<OperacionCambioCredencial>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                bool seleccionado = false;
                if (row.Cells["Seleccionar"].Value != null)
                {
                    seleccionado = Convert.ToBoolean(row.Cells["Seleccionar"].Value);
                }
                if (seleccionado)
                {
                    string lineaCsv = GenerarLineaCSVDesdeFila(row);
                    seleccionados.Add(new OperacionCambioCredencial(lineaCsv));
                }
            }
            return seleccionados;
        }

        /// <summary>
        /// Obtiene la lista de operaciones de cambio de datos de persona seleccionadas presentes en el DataGridView.
        /// </summary>
        /// <param name="dataGridView">Instancia de DataGridView que contiene las operaciones.</param>
        /// <returns>Lista de operaciones de cambio de datos de persona seleccionadas.</returns>
        public static List<OperacionCambioPersona> ObtenerOperacionesCambioDatosPersonasSeleccionadas(DataGridView dataGridView)
        {
            List<OperacionCambioPersona> seleccionados = new List<OperacionCambioPersona>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                bool seleccionado = false;
                if (row.Cells["Seleccionar"].Value != null)
                {
                    seleccionado = Convert.ToBoolean(row.Cells["Seleccionar"].Value);
                }
                if (seleccionado)
                {
                    string lineaCsv = GenerarLineaCSVDesdeFila(row);
                    seleccionados.Add(new OperacionCambioPersona(lineaCsv));
                }
            }
            return seleccionados;
        }

        /// <summary>
        /// Determina si al menos una fila del DataGridView está marcada (seleccionada).
        /// </summary>
        /// <param name="dataGridView">Instancia de DataGridView a evaluar.</param>
        /// <returns>
        /// Verdadero si existe al menos un elemento seleccionado; de lo contrario, falso.
        /// </returns>
        public static bool HayAlMenosUnoSeleccionado(DataGridView dataGridView)
        {
            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                if (fila.Cells["Seleccionar"].Value != null && Convert.ToBoolean(fila.Cells["Seleccionar"].Value))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Genera un mensaje descriptivo que detalla los registros seleccionados en el DataGridView.
        /// </summary>
        /// <param name="dataGridView">Instancia de DataGridView que contiene los registros.</param>
        /// <returns>Cadena con la información de cada registro seleccionado.</returns>
        public static string GenerarMensajeSeleccionados(DataGridView dataGridView)
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine("Registros seleccionados:");

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                bool seleccionado = false;
                if (row.Cells["Seleccionar"].Value != null)
                {
                    seleccionado = Convert.ToBoolean(row.Cells["Seleccionar"].Value);
                }
                if (seleccionado)
                {
                    StringBuilder registro = new StringBuilder();
                    // Recorre todas las celdas excepto la de selección.
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.DataGridView.Columns[i].Name.Equals("Seleccionar", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }
                        string header = row.DataGridView.Columns[i].HeaderText;
                        string valor = "";
                        if (row.Cells[i].Value != null)
                        {
                            DateTime fecha;
                            if (row.Cells[i].Value is DateTime)
                            {
                                fecha = (DateTime)row.Cells[i].Value;
                                valor = fecha.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
                            }
                            else if (DateTime.TryParse(row.Cells[i].Value.ToString(), out fecha))
                            {
                                valor = fecha.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                valor = row.Cells[i].Value.ToString().Trim();
                            }
                        }
                        registro.Append(header + ": " + valor + " - ");
                    }
                    // Eliminar el último separador " - " si existe.
                    if (registro.Length >= 3)
                    {
                        registro.Remove(registro.Length - 3, 3);
                    }
                    mensaje.AppendLine(registro.ToString());
                }
            }
            return mensaje.ToString();
        }

        /// <summary>
        /// Genera una línea de texto en formato CSV a partir de una fila del DataGridView.
        /// Se omite la primera columna (la de selección).
        /// </summary>
        /// <param name="row">Fila del DataGridView.</param>
        /// <returns>Cadena en formato CSV con los datos de la fila.</returns>
        public static string GenerarLineaCSVDesdeFila(DataGridViewRow row)
        {
            List<string> valores = new List<string>();

            // Comienza desde el índice 1 para omitir la columna "Seleccionar".
            for (int i = 1; i < row.Cells.Count; i++)
            {
                string header = row.DataGridView.Columns[i].Name;
                object valorObj = row.Cells[i].Value;
                string valor = "";
                if (valorObj != null)
                {
                    DateTime fecha;
                    if (valorObj is DateTime)
                    {
                        fecha = (DateTime)valorObj;
                        valor = fecha.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
                    }
                    else if (!string.IsNullOrEmpty(header) && header.ToLower().Contains("fecha") &&
                             DateTime.TryParse(valorObj.ToString(), out fecha))
                    {
                        valor = fecha.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        valor = valorObj.ToString().Trim();
                    }
                }
                valores.Add(valor);
            }
            return string.Join(";", valores);
        }

        /// <summary>
        /// Agrega una columna de selección de tipo CheckBox al DataGridView.
        /// Configura dicha columna como editable y establece las demás columnas como solo lectura.
        /// </summary>
        /// <param name="dataGridView">Instancia de DataGridView a la que se le agregará la columna.</param>
        public static void AgregarColumnaSeleccion(DataGridView dataGridView)
        {
            if (dataGridView == null)
            {
                throw new ArgumentNullException("dataGridView");
            }

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "Seleccionar";
            chk.Name = "Seleccionar";
            chk.FalseValue = false;
            chk.TrueValue = true;
            chk.ReadOnly = false;

            // Inserta la columna al inicio.
            dataGridView.Columns.Insert(0, chk);

            // Establece todas las demás columnas como de solo lectura.
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                if (!col.Name.Equals("Seleccionar", StringComparison.OrdinalIgnoreCase))
                {
                    col.ReadOnly = true;
                }
            }

            // Inicializa la columna de selección en falso para todas las filas.
            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                fila.Cells["Seleccionar"].Value = false;
            }
        }
    }
}