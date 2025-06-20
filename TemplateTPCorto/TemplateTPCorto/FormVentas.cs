using Datos;
using Datos.Ventas;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    /// <summary>
    /// Control de usuario para la gestión de ventas en la aplicación.
    /// </summary>
    public partial class FormVentas : UserControl
    {
        private readonly IVentasNegocio ventasNegocio;
        private readonly IProductoNegocio productoNegocio;
        private List<ProductoCarrito> carrito = new List<ProductoCarrito>();
        private const int MONTO_MINIMO_PARA_APLICAR_DESCUENTO = 1000000;
        /// <summary>
        /// Constructor que inicializa las dependencias de negocio y los componentes gráficos.
        /// </summary>
        /// <param name="ventasNegocio">Instancia de IVentasNegocio.</param>
        /// <param name="productoNegocio">Instancia de IProductoNegocio.</param>
        public FormVentas(IVentasNegocio ventasNegocio, IProductoNegocio productoNegocio)
        {
            this.ventasNegocio = ventasNegocio ?? throw new ArgumentNullException(nameof(ventasNegocio));
            this.productoNegocio = productoNegocio ?? throw new ArgumentNullException(nameof(productoNegocio));
            InitializeComponent();
        }
        /// <summary>
        /// Inicializa los valores necesarios al cargar el formulario.
        /// </summary>
        private void FormVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarCategoriasProductos();
            IniciarTotales();
        }
        /// <summary>
        /// Inicializa los valores de los totales en la interfaz.
        /// </summary>
        private void IniciarTotales()
        {
            lablSubTotal.Text = "0.00";
            lblTotal.Text = "0.00";
            lblDescuento.Text = "0.00";
        }
        /// <summary>
        /// Carga la lista de categorías de productos en el combo box.
        /// </summary>
        private void CargarCategoriasProductos()
        {
            List<CategoriaProductos> categoriaProductos = ventasNegocio.ObtenerCategoriaProductos();
            cboCategoriaProductos.Items.Clear();
            foreach (CategoriaProductos categoriaProducto in categoriaProductos)
            {
                cboCategoriaProductos.Items.Add(categoriaProducto);
            }
        }
        /// <summary>
        /// Carga la lista de clientes en el combo box.
        /// </summary>
        private void CargarClientes()
        {
            List<Cliente> listadoClientes = ventasNegocio.ObtenerClientes();
            cmbClientes.Items.Clear();
            foreach (Cliente cliente in listadoClientes)
            {
                cmbClientes.Items.Add(cliente);
            }
        }
        /// <summary>
        /// Lista los productos según la categoría seleccionada.
        /// </summary>
        private void btnListarProductos_Click(object sender, EventArgs e)
        {
            var categoriaSeleccionada = ObtenerCategoriaProductosSeleccionado();
            if (categoriaSeleccionada == null)
            {
                FormUtils.MostrarMensajeAdvertencia("Seleccioná una categoría de producto.");
                return;
            }
            string idCategoria = categoriaSeleccionada.Id;
            List<Producto> productos = productoNegocio.ObtenerProductosPorCategoria(idCategoria);
            lstProducto.Items.Clear();
            foreach (Producto producto in productos)
            {
                lstProducto.Items.Add(producto);
            }
        }
        /// <summary>
        /// Agrega un producto seleccionado al carrito con la cantidad ingresada.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto producto = ObtenerProductoSeleccionado();
            if (producto == null)
            {
                FormUtils.MostrarMensajeAdvertencia("Seleccioná un producto.");
                return;
            }

            int cantidad = ObtenerCantidadIngresada();
            if (cantidad <= 0)
            {
                FormUtils.MostrarMensajeAdvertencia("Ingresá una cantidad válida.");
                return;
            }

            if (cantidad > producto.Stock)
            {
                FormUtils.MostrarMensajeAdvertencia("No hay suficiente stock disponible.");
                return;
            }
            AgregarProductoAlCarrito(producto, cantidad);
            ActualizarTotales();
            txtCantidad.Clear();
        }
        /// <summary>
        /// Agrega el producto al carrito, asegurando que no supere el stock.
        /// </summary>
        /// <param name="producto">El producto seleccionado.</param>
        /// <param name="cantidad">Cantidad solicitada.</param>
        private void AgregarProductoAlCarrito(Producto producto, int cantidad)
        {
            ProductoCarrito productoEnCarrito = carrito.Find(p => p.IdProducto == producto.Id);

            if (productoEnCarrito != null)
            {
                listBox1.Items.Remove(productoEnCarrito);

                int cantidadDisponible = producto.Stock - productoEnCarrito.Cantidad;
                if (cantidadDisponible==0)
                {
                    FormUtils.MostrarMensajeAdvertencia("Ya cargo el total de stock disponible del producto en la venta.");
                    return;
                }
                bool superaCantidadDisponible = cantidad > cantidadDisponible;
                int cantidadAgregar = superaCantidadDisponible ? cantidadDisponible : cantidad;
                productoEnCarrito.Cantidad += cantidadAgregar;
                listBox1.Items.Add(productoEnCarrito);
                if (superaCantidadDisponible)
                {
                    FormUtils.MostrarMensajeInformacion($"La cantidad ingresada superó el stock disponible, se agregó la cantidad de {cantidadAgregar} disponibles en stock.");
                }
            }
            else
            {
                ProductoCarrito nuevoProducto = new ProductoCarrito
                {
                    IdProducto = producto.Id,
                    NombreProducto = producto.Nombre,
                    PrecioUnitario = producto.Precio,
                    Cantidad = cantidad,
                    Categoria = producto.IdCategoria == 3 ? "Electro Hogar" : "Otra"
                };

                carrito.Add(nuevoProducto);
                listBox1.Items.Add(nuevoProducto);
            }
        }
        /// <summary>
        /// Actualiza los totales de la venta, incluyendo descuentos aplicables.
        /// </summary>
        private void ActualizarTotales()
        {
            int subtotal = carrito.Sum(p => p.Subtotal);
            lablSubTotal.Text = $"${subtotal:N0}";

            // Sumar solo productos de categoría "Electro Hogar"
            var productosElectro = carrito.Where(p => p.Categoria == "Electro Hogar").ToList();
            int totalElectro = productosElectro.Sum(p => p.Subtotal);
            decimal descuento = 0;
            if (totalElectro > MONTO_MINIMO_PARA_APLICAR_DESCUENTO)
            {
                descuento = totalElectro * 0.15m;
            }

            lblDescuento.Text = descuento > 0 ? $"-${descuento:N0}" : "$0.00";
            decimal total = subtotal - descuento;
            lblTotal.Text = $"${total:N0}";
        }
        /// <summary>
        /// Quita el producto seleccionado del carrito.
        /// </summary>
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                FormUtils.MostrarMensajeAdvertencia("Seleccioná un producto del carrito para quitar.");
                return;
            }
            var itemSeleccionado = ObtenerProductoCarritoSeleccionado();
            listBox1.Items.Remove(itemSeleccionado);
            carrito.Remove(itemSeleccionado);
            ActualizarTotales();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un producto del carrito.");
                return;
            }

            ProductoCarrito seleccionadoProductoCarrito = (ProductoCarrito)listBox1.SelectedItem;
            Producto seleccionadoProducto = (Producto)listBox1.SelectedItem;
            int nuevaCantidad = (int)nudNuevaCantidad.Value;

            if (nuevaCantidad > seleccionadoProducto.Stock)
            {
                MessageBox.Show($"La cantidad ingresada ({nuevaCantidad}) supera el stock disponible ({seleccionadoProducto.Stock}).");
                return;
            }

            seleccionadoProductoCarrito.Cantidad = nuevaCantidad;
            
            RefrescarListaCarrito();
            ActualizarTotales();
        }

        private void RefrescarListaCarrito()
        {
            listBox1.Items.Clear();
            foreach (var producto in carrito)
            {
                listBox1.Items.Add(producto);
            }
        }

        /// <summary>
        /// Maneja el evento de carga de ventas y registra los productos en el sistema.
        /// </summary>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            Cliente cliente = ObtenerClienteSeleccionado();
            if (cliente == null)
            {
                FormUtils.MostrarMensajeAdvertencia("Seleccioná un cliente.");
                return;
            }

            if (listBox1.Items.Count <= 0)
            {
                FormUtils.MostrarMensajeAdvertencia("No hay productos en el carrito.");
                return;
            }

            List<ProductoCarrito> productosNoAgregados = RegistrarVentas(cliente);

            ManejarResultadoRegistro(productosNoAgregados);
        }
        /// <summary>
        /// Registra las ventas de los productos del carrito.
        /// </summary>
        /// <param name="cliente">Cliente que realizará la compra.</param>
        /// <returns>Lista de productos que no pudieron ser registrados.</returns>
        private List<ProductoCarrito> RegistrarVentas(Cliente cliente)
        {
            List<ProductoCarrito> productosNoAgregados = new List<ProductoCarrito>();

            foreach (ProductoCarrito producto in listBox1.Items)
            {
                Venta venta = new Venta
                {
                    IdCliente = cliente.Id,
                    IdProducto = producto.IdProducto,
                    Cantidad = producto.Cantidad
                };

                if (!ventasNegocio.RegistrarVenta(venta))
                {
                    productosNoAgregados.Add(producto);
                }
            }

            return productosNoAgregados;
        }
        /// <summary>
        /// Maneja el resultado del registro de ventas, mostrando mensajes según el caso.
        /// </summary>
        /// <param name="productosNoAgregados">Lista de productos que no se pudieron registrar.</param>
        private void ManejarResultadoRegistro(List<ProductoCarrito> productosNoAgregados)
        {
            if (productosNoAgregados.Count == 0)
            {
                FormUtils.MostrarMensajeInformacion("Ventas registradas correctamente.");
                carrito.Clear();
                listBox1.Items.Clear();
                IniciarTotales();
            }
            else
            {
                MostrarErroresRegistro(productosNoAgregados);
            }
        }
        /// <summary>
        /// Muestra los productos que no pudieron ser registrados.
        /// </summary>
        /// <param name="productosNoAgregados">Lista de productos no registrados.</param>
        private void MostrarErroresRegistro(List<ProductoCarrito> productosNoAgregados)
        {
            string productoInfo = "No se pudieron registrar las siguientes ventas:\n";

            foreach (ProductoCarrito producto in productosNoAgregados)
            {
                productoInfo += $"{producto.NombreProducto}\n";
            }

            FormUtils.MostrarMensajeAdvertencia(productoInfo);
        }
        /// <summary>
        /// Obtiene la cantidad ingresada en el campo de texto.
        /// </summary>
        /// <returns>La cantidad ingresada o 0 si no es válida.</returns>
        private int ObtenerCantidadIngresada()
        {
            return int.TryParse(txtCantidad.Text, out int cantidad) ? cantidad : 0;
        }
        /// <summary>
        /// Obtiene el CategoriaProductos seleccionado en la lista.
        /// </summary>
        /// <returns>El CategoriaProductos seleccionado o null si no hay selección.</returns>
        private CategoriaProductos ObtenerCategoriaProductosSeleccionado()
        {
            return cboCategoriaProductos.SelectedItem as CategoriaProductos;
        }
        /// <summary>
        /// Obtiene el producto seleccionado en la lista.
        /// </summary>
        /// <returns>El producto seleccionado o null si no hay selección.</returns>
        private Producto ObtenerProductoSeleccionado()
        {
            return lstProducto.SelectedItem as Producto;
        }
        /// <summary>
        /// Obtiene el ProductoCarrito seleccionado.
        /// </summary>
        /// <returns>El ProductoCarrito seleccionado o null si no hay selección.</returns>
        private ProductoCarrito ObtenerProductoCarritoSeleccionado()
        {
            return listBox1.SelectedItem as ProductoCarrito;
        }
        /// <summary>
        /// Obtiene el cliente seleccionado.
        /// </summary>
        /// <returns>El cliente seleccionado o null si no hay selección.</returns>
        private Cliente ObtenerClienteSeleccionado()
        {
            return cmbClientes.SelectedItem as Cliente;
        }

       
    }
}
