using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public partial class FormAdministrador : FormMenuBase
    {
        private Credencial usuario;
        public FormAdministrador(Credencial logueado)
        {
            InitializeComponent();
            btnCerrarSession.Click += btnCerrarSession_Click;
            usuario = logueado;
            tablacontraseñas.Rows.Clear();
            tablausuarios.Rows.Clear();
            tablacontraseñas.ColumnCount = 7;
            tablacontraseñas.Columns[0].Name = "ID";
            tablacontraseñas.Columns[1].Name = "Legajo";
            tablacontraseñas.Columns[2].Name = "Usuario";
            tablacontraseñas.Columns[3].Name = "Contraseña";
            tablacontraseñas.Columns[4].Name = "Perfil";
            tablacontraseñas.Columns[5].Name = "Fecha de Alta";
            tablacontraseñas.Columns[6].Name = "Último Login";

            tablausuarios.ColumnCount = 6;
            tablausuarios.Columns[0].Name = "ID";
            tablausuarios.Columns[1].Name = "Legajo";
            tablausuarios.Columns[2].Name = "Nombre";
            tablausuarios.Columns[3].Name = "Apellido";
            tablausuarios.Columns[4].Name = "DNI";
            tablausuarios.Columns[5].Name = "Fecha de Ingreso";
            CargarRegistros("operacion_cambio_credencial.csv", tablacontraseñas);
            CargarRegistros("operacion_cambio_persona.csv", tablausuarios);
            tablausuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tablausuarios.MultiSelect = true;
            tablacontraseñas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tablacontraseñas.MultiSelect = true;
        }
        private void CargarRegistros(string archivo, DataGridView dgv)
        {
            try
            {
                LoginNegocio loginNegocio = new LoginNegocio();
                List<String> lista = loginNegocio.Obtenerdatos(archivo);
                int contador = 0;
                foreach (string linea in lista)
                {
                    if (string.IsNullOrWhiteSpace(linea))
                        continue;

                    string[] campos = linea.Split(';');
                    if (contador!=0)
                    {
                        dgv.Rows.Add(campos);
                    }
                    contador++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar registros: " + ex.Message);
            }
        }


        private void btnCambioContrasenia_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormContraseniaCambio form = new FormContraseniaCambio(usuario);
            form.Show();
        }
        private void btnAutorizaciones_Click(object sender, EventArgs e)
        {
            if (tablacontraseñas.SelectedRows.Count == 0 && tablausuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay filas seleccionadas.");
            }
            else
            {
                LoginNegocio loginNegocio = new LoginNegocio();
                List<DataGridViewRow> filasParaEliminarusuarios = new List<DataGridViewRow>();
                List<DataGridViewRow> filasParaEliminarContraseñas = new List<DataGridViewRow>();
                foreach (DataGridViewRow fila in tablausuarios.SelectedRows)
                {
                    string id = fila.Cells[0].Value.ToString();
                    bool flag = loginNegocio.AutorizarPersona(id);
                    if(flag)
                    {
                        filasParaEliminarusuarios.Add(fila);
                    }
                }
                foreach (DataGridViewRow fila in filasParaEliminarusuarios)
                {
                    tablausuarios.Rows.Remove(fila);
                }
                foreach (DataGridViewRow fila in tablacontraseñas.SelectedRows)
                {
                    string id = fila.Cells[0].Value.ToString();
                    bool flag = loginNegocio.AutorizarContraseña(id);
                    if (flag)
                    {
                        filasParaEliminarContraseñas.Add(fila);
                    }
                }
                foreach (DataGridViewRow fila in filasParaEliminarContraseñas)
                {
                    tablacontraseñas.Rows.Remove(fila);
                }
                MessageBox.Show("Autorizaciónes realizadas correctamente.");
            }
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listacontraseñas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
