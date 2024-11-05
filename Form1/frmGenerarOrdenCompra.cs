using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Compras;
using BEs.Clases.Negocio.Compras.Enums;
using BEs.Clases.Negocio.Enums;
using BLLs.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Form1
{
    public partial class frmGenerarOrdenCompra : Form
    {
        private BLL_COTIZACION _bllCotizacion;
        private BLL_COMPRA _bllCompra;
        private BLL_PROVEEDOR _bllProveedor;
        public frmGenerarOrdenCompra()
        {
            InitializeComponent();
            _bllCotizacion = new BLL_COTIZACION();
            _bllCompra = new BLL_COMPRA();
            _bllProveedor = new BLL_PROVEEDOR();
        }

        private void frmGenerarOrdenCompra_Load(object sender, EventArgs e)
        {
            CargarCotizacionesAprobadas();
            CargarOrdenesCompra();
            CargarComboBoxTipoPago();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado una cotización
            var currentRowItem = dataGridViewCotizaciones.CurrentRow?.DataBoundItem;
            if (currentRowItem == null || !(currentRowItem is Cotizacion cotizacionSeleccionada))
            {
                MessageBox.Show("Por favor, seleccione una cotización aprobada antes de generar la orden de compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el campo de comentario no esté vacío
            if (string.IsNullOrWhiteSpace(textBoxComentario.Text))
            {
                MessageBox.Show("Por favor, ingrese un comentario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que se haya seleccionado un tipo de pago
            if (cbPago.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear la instancia de Compra y definir propiedades iniciales
            Compra nuevaCompra = new Compra
            {
                Fecha = DateTime.Now,
                Comentario = textBoxComentario.Text,
                ProveedorId = cotizacionSeleccionada.ProveedorId,
                oProveedor = cotizacionSeleccionada.Proveedor,
                TipoPagoEnum = (TipoPago)cbPago.SelectedItem,
                EstadoCompraEnum = EstadoCompra.Pendiente,
                oDetalleCompra = new List<DetalleCompra>()
            };

            decimal montoTotal = 0;

            // Generar cada DetalleCompra basado en DetalleCotizacion
            foreach (var detalleCotizacion in cotizacionSeleccionada.DetallesCotizacion)
            {
                var precioProducto = detalleCotizacion.oProducto?.PrecioCompra ?? 0;
                var subtotal = precioProducto * detalleCotizacion.Cantidad;

                DetalleCompra detalleCompra = new DetalleCompra
                {
                    ProductoId = detalleCotizacion.ProductoId,
                    oProducto = detalleCotizacion.oProducto,
                    Cantidad = detalleCotizacion.Cantidad,
                    Precio = precioProducto,
                    SubTotal = subtotal,
                    Fecha = DateTime.Now
                };

                // Agregar el detalle a la lista de detalles de la compra
                nuevaCompra.oDetalleCompra.Add(detalleCompra);

                // Sumar al total de la compra
                montoTotal += subtotal;
            }

            // Asignar el monto total a la compra
            nuevaCompra.MontoTotal = montoTotal;

            // Guardar la compra en la base de datos usando BLL_COMPRA
            _bllCompra.Insertar(nuevaCompra);

            // Eliminar la cotización seleccionada
            _bllCotizacion.Eliminar(cotizacionSeleccionada.Id);

            // Notificar al usuario
            MessageBox.Show("La orden de compra ha sido generada exitosamente y está en estado Pendiente.", "Orden de Compra Generada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormulario();

            // Actualizar las cotizaciones y las órdenes de compra en los DataGrids
            CargarCotizacionesAprobadas();
            CargarOrdenesCompra();
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            // Obtener el elemento seleccionado en el DataGridView
            if (dataGridViewCompra.CurrentRow?.DataBoundItem is Compra compra)
            {
                // Verificar si el estado de la compra es Pendiente
                if (compra.EstadoCompraEnum == EstadoCompra.Pendiente)
                {
                    // Cambiar el estado a Pagada
                    _bllCompra.CambiarEstadoCompra(compra.Id, EstadoCompra.Pagada);
                    MessageBox.Show("La compra ha sido marcada como pagada.");

                    CargarOrdenesCompra();
                }
                else
                {
                    MessageBox.Show("La compra ya está pagada.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una compra válida.");
            }
        }

        #region MetodosPrivados
        private void CargarCotizacionesAprobadas()
        {
            var cotizacionesAprobadas = _bllCotizacion.ObtenerPorEstado(EstadoCotizacion.Aprobada);
            ActualizarDataGridViewCotizacionRecibiendoLista(cotizacionesAprobadas);
        }
        private void CargarComboBoxTipoPago()
        {
            cbPago.DataSource = Enum.GetValues(typeof(TipoPago));
        }

        private void ActualizarDataGridViewDetalle(List<DetalleCompra> detalles)
        {
            dataGridViewDetalles.DataSource = null;
            dataGridViewDetalles.DataSource = detalles;

            // Verificar si las columnas existen antes de ocultarlas para evitar errores de referencia
            if (dataGridViewDetalles.Columns["CompraId"] != null)
                dataGridViewDetalles.Columns["CompraId"].Visible = false;

            if (dataGridViewDetalles.Columns["ProductoId"] != null)
                dataGridViewDetalles.Columns["ProductoId"].Visible = false;

            if (dataGridViewDetalles.Columns["oProducto"] != null)
                dataGridViewDetalles.Columns["oProducto"].Visible = false;

            if (dataGridViewDetalles.Columns["oCompra"] != null)
                dataGridViewDetalles.Columns["oCompra"].Visible = false;

            // Configurar los encabezados de las columnas visibles
            if (dataGridViewDetalles.Columns["NombreProducto"] != null)
                dataGridViewDetalles.Columns["NombreProducto"].HeaderText = "Producto";

            if (dataGridViewDetalles.Columns["Cantidad"] != null)
                dataGridViewDetalles.Columns["Cantidad"].HeaderText = "Cantidad";

            if (dataGridViewDetalles.Columns["Fecha"] != null)
                dataGridViewDetalles.Columns["Fecha"].HeaderText = "Fecha de Compra";
        }

        private void ActualizarDataGridViewCotizacionRecibiendoLista(List<Cotizacion> cotizaciones)
        {
            dataGridViewCotizaciones.DataSource = null;

            // Asignar la lista de cotizaciones al DataGridView
            dataGridViewCotizaciones.DataSource = cotizaciones;

            // Ocultar columnas que no deseas mostrar
            dataGridViewCotizaciones.Columns["ProveedorId"].Visible = false;
            dataGridViewCotizaciones.Columns["Proveedor"].Visible = false; // Oculta la columna de objeto `Proveedor`

            // Ajustar el encabezado y la ubicación de la columna `DescripcionProveedor`
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].HeaderText = "Proveedor";
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].DisplayIndex = 2;

            // Configurar encabezados de otras columnas
            dataGridViewCotizaciones.Columns["FechaCotizacion"].HeaderText = "Fecha de Cotización";
            dataGridViewCotizaciones.Columns["EstadoCotizacionEnum"].HeaderText = "Estado";
        }


        private void CargarOrdenesCompra()
        {
            dataGridViewCompra.DataSource = null;
            var ordenesCompra = _bllCompra.ObtenerTodos();
            dataGridViewCompra.DataSource = ordenesCompra;

            // Configurar las columnas visibles y sus encabezados
            dataGridViewCompra.Columns["ProveedorId"].Visible = false;
            dataGridViewCompra.Columns["oProveedor"].Visible = false;

            dataGridViewCompra.Columns["Id"].HeaderText = "Nro. Orden";
            dataGridViewCompra.Columns["Fecha"].HeaderText = "Fecha";
            dataGridViewCompra.Columns["MontoTotal"].HeaderText = "Monto Total";
            dataGridViewCompra.Columns["Comentario"].HeaderText = "Comentario";
            dataGridViewCompra.Columns["EstadoCompraEnum"].HeaderText = "Estado";
            dataGridViewCompra.Columns["TipoPagoEnum"].HeaderText = "TipoPago";
        }

        private void LimpiarFormulario()
        {
            textBoxComentario.Clear();
            cbPago.SelectedIndex = -1;
            dataGridViewDetalles.DataSource = null;
            labelProv.Text = string.Empty;
            labelFecha.Text = string.Empty;
        }

        #endregion

        private void dataGridViewCotizaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCotizaciones.CurrentRow?.DataBoundItem is Cotizacion cotizacionSeleccionada)
            {
                labelProv.Text = cotizacionSeleccionada.DescripcionProveedor;
                labelFecha.Text = cotizacionSeleccionada.FechaCotizacion.ToShortDateString();
            }
        }

        private void dataGridViewCompra_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCompra.CurrentRow?.DataBoundItem is Compra compraSeleccionada)
            {
                // Obtener y mostrar los detalles de la orden de compra seleccionada
                var proveedosSeleccionado = _bllProveedor.ObtenerPorId(compraSeleccionada.oProveedor.Id);
                lblProveedor.Text = proveedosSeleccionado.Descripcion;
                lblFecha.Text = compraSeleccionada.Fecha.ToShortDateString();
                lblTotal.Text = compraSeleccionada.MontoTotal.ToString("C");
                ActualizarDataGridViewDetalle(compraSeleccionada.oDetalleCompra);
            }
        }
    }
}
