using BEs.Clases.Negocio.Compras;
using BEs.Clases.Negocio.Compras.Enums;
using BLLs.Negocio;
using System;
using System.Windows.Forms;

namespace Form1.Negocio
{
    public partial class frmVerificacionProductos : Form
    {
        private frmGenerarOrdenCompra _formularioGenerarOrdenCompra;
        private BLL_COMPRA _bllCompra;
        private BLL_COTIZACION _bllCotizacion;
        private Compra _ordenCompraSeleccionada;
        private Cotizacion _cotizacionSeleccionada;
        public frmVerificacionProductos()
        {
            InitializeComponent();
            _bllCompra = new BLL_COMPRA();
            _bllCotizacion = new BLL_COTIZACION();
        }

        private void btnAprobarRecepcion_Click(object sender, EventArgs e)
        {
            if (CamposValidosParaAprobacion())
            {
                // Si todo está correcto, aprobar la recepción y habilitar el botón de pago
                MessageBox.Show("Recepción aprobada. El botón de pago será habilitado.", "Recepción Aprobada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _formularioGenerarOrdenCompra?.HabilitarBotonPago(true);

                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos antes de aprobar la recepción.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRechazarRecepcion_Click(object sender, EventArgs e)
        {
            try
            {
                _bllCompra.CambiarEstadoCompra(_ordenCompraSeleccionada.Id, EstadoCompra.Rechazada);
                MessageBox.Show($"Se ha notificado al proveedor {_cotizacionSeleccionada.DescripcionProveedor} que los productos serán devueltos.", "Recepción Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar el estado de la orden de compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void frmVerificacionProductos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        #region metodosPrivados
        private void CargarDatos()
        {
            dataGridViewDetalleCompra.DataSource = _bllCompra.ObtenerDetallesPorCompraId(_ordenCompraSeleccionada.Id);
            dataGridViewDetalleCotizacion.DataSource = _bllCotizacion.ObtenerDetallesPorCotizacionId(_cotizacionSeleccionada.Id);
        }

        public void CargarOrdenCompraYCotizacion(Compra ordenCompra, Cotizacion cotizacion)
        {
            _ordenCompraSeleccionada = ordenCompra;
            _cotizacionSeleccionada = cotizacion;

            // Cargar los datos en los DataGridView
            CargarDatos();
        }

        private bool CamposValidosParaAprobacion()
        {
            return checkBoxLlegaronProductos.Checked &&
                   checkBoxCondicionesProductos.Checked &&
                   checkBoxCantidadProductos.Checked &&
                   checkBoxPrecioProductos.Checked &&
                   !string.IsNullOrEmpty(textBoxObservaciones.Text);
        }

        #endregion
    }
}
