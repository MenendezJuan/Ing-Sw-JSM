using BEs.Clases.Negocio.Compras;
using BLLs.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Form1
{
    public partial class frmGestionCompraProductos : Form
    {
        private BLL_COTIZACION _bllCotizacion;
        public frmGestionCompraProductos()
        {
            InitializeComponent();
            _bllCotizacion = new BLL_COTIZACION();
        }

        private void btnSolicitarCotizacion_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal pform = Owner as frmMenuPrincipal;
            frmGestionarEnvioCotizacion compraInsumo = new frmGestionarEnvioCotizacion();
            pform.AddOwnedForm(compraInsumo);
            pform.FormHijo(compraInsumo);
            this.Close();
        }

        private void frmGestionCompraProductos_Load(object sender, EventArgs e)
        {
            ActualizarDataGridViewCotizacion();
        }

        private void ActualizarDataGridViewCotizacionRecibiendoLista(List<Cotizacion> cotizaciones)
        {
            dataGridViewCotizaciones.DataSource = null;
            dataGridViewDetalle.DataSource = null;

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


        private void ActualizarDataGridViewCotizacion()
        {
            dataGridViewCotizaciones.DataSource = null;
            List<Cotizacion> cotizaciones = _bllCotizacion.ObtenerTodos();

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

        private void dataGridViewCotizaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCotizaciones.SelectedRows.Count > 0)
            {
                // Obtener la cotización seleccionada
                var cotizacionSeleccionada = (Cotizacion)dataGridViewCotizaciones.SelectedRows[0].DataBoundItem;

                // Mostrar los detalles en dataGridViewDetalle
                ActualizarDataGridViewDetalle(cotizacionSeleccionada.DetallesCotizacion);

                // Mostrar el estado en el labelEstado
                labelEstado.Text = cotizacionSeleccionada.EstadoCotizacionEnum.ToString();
            }
        }

        private void ActualizarDataGridViewDetalle(List<DetalleCotizacion> detalles)
        {
            dataGridViewDetalle.DataSource = null;
            dataGridViewDetalle.DataSource = detalles;

            // Configurar las columnas visibles y sus encabezados
            dataGridViewDetalle.Columns["CotizacionId"].Visible = false;
            dataGridViewDetalle.Columns["ProductoId"].Visible = false;
            dataGridViewDetalle.Columns["oProducto"].Visible = false;

            dataGridViewDetalle.Columns["NombreProducto"].HeaderText = "Producto";
            dataGridViewDetalle.Columns["Cantidad"].HeaderText = "Cantidad";
            dataGridViewDetalle.Columns["Fecha"].HeaderText = "Fecha de Solicitud";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime desde = dateTimePickerDesde.Value;
            DateTime hasta = dateTimePickerHasta.Value;

            // Obtener cotizaciones en el rango de fechas
            List<Cotizacion> cotizaciones = _bllCotizacion.ObtenerCotizacionesPorFecha(desde, hasta);
            ActualizarDataGridViewCotizacionRecibiendoLista(cotizaciones);
        }

        private void btnReestablecer_Click(object sender, EventArgs e)
        {
            // Limpiar los DateTimePicker
            dateTimePickerDesde.Value = DateTime.Now;
            dateTimePickerHasta.Value = DateTime.Now;

            // Volver a cargar todas las cotizaciones
            ActualizarDataGridViewCotizacion();
        }

        private void buttonEvaluarOrdenesExistentes_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal pform = Owner as frmMenuPrincipal;
            frmControl controlSolicitudes = new frmControl();
            pform.AddOwnedForm(controlSolicitudes);
            pform.FormHijo(controlSolicitudes);
            this.Close();
        }
    }
}
