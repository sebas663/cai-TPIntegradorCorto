using Datos;
using Datos.Ventas;
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
    public partial class FormVentas : UserControl
    {
        public FormVentas()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {

            CargarClientes();
            CargarCategoriasProductos();
            IniciarTotales();
        }

        private void IniciarTotales()
        {
            lablSubTotal.Text = "0.00";
            lblTotal.Text = "0.00";
        }

        private void CargarCategoriasProductos()
        {
            
            VentasNegocio ventasNegocio = new VentasNegocio();

            List<CategoriaProductos> categoriaProductos = ventasNegocio.ObtenerCategoriaProductos();

            foreach (CategoriaProductos categoriaProducto in categoriaProductos)
            {
                cboCategoriaProductos.Items.Add(categoriaProducto);
            }
        }

        private void CargarClientes()
        {
            VentasNegocio ventasNegocio = new VentasNegocio();

            List<Cliente> listadoClientes = ventasNegocio.ObtenerClientes();

            foreach (Cliente cliente in listadoClientes)
            {
                cmbClientes.Items.Add(cliente);
            }
        }

        private void btnListarProductos_Click(object sender, EventArgs e)
        {
            VentasNegocio ventasNegocio = new VentasNegocio();


        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            {
                Cliente cliente = (Cliente)cmbClientes.SelectedItem;
                List <ProductoCarrito> ProductosNoAgregados = new List<ProductoCarrito>();
                VentasNegocio negocio = new VentasNegocio();
                if (cliente == null)
                {
                    MessageBox.Show("Seleccioná un cliente.");
                    return;
                }
                else if (listBox1.Items.Count == 0)
                {
                    MessageBox.Show("No hay productos en el carrito.");
                    return;
                }
                foreach (ProductoCarrito producto in listBox1.Items)
                {
                    Ventas item = new Ventas
                    {
                        IdCliente = cliente.Id,
                        IdUsuario = "UsuarioActual", // Reemplazar con el usuario actual
                        IdProducto = producto.IdProducto,
                        Cantidad = producto.Cantidad,
                    };
                    bool resultado = negocio.RegistrarVenta(item);
                    if (!resultado)
                    {
                        ProductosNoAgregados.Add(producto);
                    }
                }
                if (ProductosNoAgregados.Count == 0)
                {
                    MessageBox.Show("Ventas registradas correctamente.");
                    listBox1.Items.Clear();
                    carrito.Clear();
                    IniciarTotales();
                }
                else
                {
                    string productoInfo = "No se pudieron registrar las siguientes ventas: ";

                    foreach (ProductoCarrito producto in ProductosNoAgregados)
                    {
                        productoInfo += $"{producto.NombreProducto}" + "\n";
                    }
                    MessageBox.Show($"{productoInfo}");
                }
            }
        }
    }
}
