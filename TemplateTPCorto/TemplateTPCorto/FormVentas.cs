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
using Datos.Ventas;


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
            if (cboCategoriaProductos.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná una categoría de producto.");
                return;
            }

            CategoriaProductos categoriaSeleccionada = (CategoriaProductos)cboCategoriaProductos.SelectedItem;
            int idCategoria = int.Parse(categoriaSeleccionada.Id);

            VentasNegocio ventasNegocio = new VentasNegocio();
            List<Producto> productos = ventasNegocio.ObtenerProductosPorCategoria(idCategoria);

            lstProducto.Items.Clear();

            foreach (Producto producto in productos)
            {
                lstProducto.Items.Add(producto);
            }
        }
        private List<ProductoCarrito> carrito = new List<ProductoCarrito>();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (lstProducto.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un producto.");
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingresá una cantidad válida.");
                return;
            }

            var producto = (Producto)lstProducto.SelectedItem;

            if (cantidad > producto.Stock)
            {
                MessageBox.Show("No hay suficiente stock disponible.");
                return;
            }

            // Creamos el ítem y lo agregamos al carrito
            ProductoCarrito item = new ProductoCarrito
            {
                IdProducto = producto.Id,
                NombreProducto = producto.Nombre,
                PrecioUnitario = producto.Precio,
                Cantidad = cantidad,
                Categoria = producto.IdCategoria == 3 ? "Electro Hogar" : "Otra"
            };

            carrito.Add(item);
            listBox1.Items.Add(item); // Mostrar en el ListBox

            ActualizarTotales();
            txtCantidad.Clear();
        }
        private void ActualizarTotales()
        {
            int subtotal = carrito.Sum(p => p.Subtotal);
            lablSubTotal.Text = $"${subtotal:N0}";

            // Sumar solo productos de categoría "Electro Hogar"
            var productosElectro = carrito.Where(p => p.Categoria == "Electro Hogar").ToList();
            int totalElectro = productosElectro.Sum(p => p.Subtotal);

            decimal descuento = 0;
            if (totalElectro > 1000000)
            {
                descuento = totalElectro * 0.15m;
            }

            lblDescuento.Text = descuento > 0 ? $"-${descuento:N0}" : "$0";

            decimal total = subtotal - descuento;
            lblTotal.Text = $"${total:N0}";
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un producto del carrito para quitar.");
                return;
            }

            var itemSeleccionado = (ProductoCarrito)listBox1.SelectedItem;

            // Quitamos del listado visual
            listBox1.Items.Remove(itemSeleccionado);

            // Quitamos del carrito real
            carrito.Remove(itemSeleccionado);

            // Recalculamos los totales
            ActualizarTotales();
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
