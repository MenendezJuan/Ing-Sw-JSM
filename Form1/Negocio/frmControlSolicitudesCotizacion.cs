using BEs.Clases.Negocio.Compras;
using BEs.Clases.Negocio.Enums;
using BLLs.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Form1
{
    public partial class frmControlSolicitudesCotizacion : Form
    {
        private BLL_COTIZACION _bllCotizacion;
        public frmControlSolicitudesCotizacion()
        {
            InitializeComponent();
            _bllCotizacion = new BLL_COTIZACION();
        }

        private void frmControlSolicitudesCotizacion_Load(object sender, EventArgs e)
        {
            CargarCotizacionesPorEstado();
        }

        private void btnAprobSolicitud_Click(object sender, EventArgs e)
        {
            CambiarEstadoCotizacionSeleccionada(EstadoCotizacion.Aprobada);
        }

        private void btnRechSolicitud_Click(object sender, EventArgs e)
        {
            CambiarEstadoCotizacionSeleccionada(EstadoCotizacion.Rechazada);
        }

        #region MetodosPrivados

        private void CargarCotizacionesPorEstado()
        {
            List<Cotizacion> cotizaciones;

            if (rbPendiente.Checked)
            {
                cotizaciones = _bllCotizacion.ObtenerPorEstado(EstadoCotizacion.Pendiente);

                int solicitudesPendientes = cotizaciones.Count;

                // Actualizar el labelNotificacion con el número de solicitudes pendientes
                labelNotificacion.Text = $"Atención: {solicitudesPendientes} Ordenes pendientes de aprobación.";
            }
            else if (rbFinalizado.Checked)
            {
                // Cargar cotizaciones en estados aprobada o rechazada
                cotizaciones = _bllCotizacion.ObtenerPorEstados(new List<EstadoCotizacion>
                {
                    EstadoCotizacion.Aprobada,
                    EstadoCotizacion.Rechazada
                });
            }
            else
            {
                cotizaciones = new List<Cotizacion>();
            }

            dataGridViewCotizaciones.DataSource = cotizaciones;
            dataGridViewCotizaciones.ClearSelection();
            ActualizarDataGridViewCotizacionRecibiendoLista(cotizaciones);
        }

        private void ActualizarDataGridViewCotizacionRecibiendoLista(List<Cotizacion> cotizaciones)
        {
            dataGridViewCotizaciones.DataSource = null;
            dataGridViewDetalleCotizacion.DataSource = null;

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

        private void CargarDetallesCotizacion(int cotizacionId)
        {
            Cotizacion cotizacion = _bllCotizacion.ObtenerPorId(cotizacionId);
            if (cotizacion != null)
            {
                ActualizarDataGridViewDetalle(cotizacion.DetallesCotizacion);
            }
        }

        private void CambiarEstadoCotizacionSeleccionada(EstadoCotizacion nuevoEstado)
        {
            if (dataGridViewCotizaciones.SelectedRows.Count > 0)
            {
                int cotizacionId = (int)dataGridViewCotizaciones.SelectedRows[0].Cells["Id"].Value;
                try
                {
                    bool exito = _bllCotizacion.EvaluarYActualizarEstadoCotizacion(cotizacionId, nuevoEstado);

                    if (exito)
                    {
                        MessageBox.Show($"Cotización {nuevoEstado} exitosamente.", "Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCotizacionesPorEstado();
                    }
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo cambiar el estado de la cotización. Error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una cotización primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarCotizaciones()
        {
            List<Cotizacion> cotizaciones = _bllCotizacion.ObtenerTodos();
            dataGridViewCotizaciones.DataSource = cotizaciones;
            dataGridViewCotizaciones.ClearSelection();
        }

        private void ActualizarDataGridViewCotizacion()
        {
            dataGridViewCotizaciones.DataSource = null;
            List<Cotizacion> cotizaciones = _bllCotizacion.ObtenerTodos();
            dataGridViewCotizaciones.DataSource = cotizaciones;
            ConfigurarColumnasCotizacion();
        }

        private void ConfigurarColumnasCotizacion()
        {
            // Ocultar columnas no deseadas
            dataGridViewCotizaciones.Columns["ProveedorId"].Visible = false;
            dataGridViewCotizaciones.Columns["Proveedor"].Visible = false;

            // Configurar encabezados y ubicaciones
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].HeaderText = "Proveedor";
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].DisplayIndex = 2;
            dataGridViewCotizaciones.Columns["FechaCotizacion"].HeaderText = "Fecha de Cotización";
            dataGridViewCotizaciones.Columns["EstadoCotizacionEnum"].HeaderText = "Estado";
        }

        private void ActualizarDataGridViewDetalle(List<DetalleCotizacion> detalles)
        {
            dataGridViewDetalleCotizacion.DataSource = null;
            dataGridViewDetalleCotizacion.DataSource = detalles;

            // Configurar columnas visibles y sus encabezados
            dataGridViewDetalleCotizacion.Columns["CotizacionId"].Visible = false;
            dataGridViewDetalleCotizacion.Columns["ProductoId"].Visible = false;
            dataGridViewDetalleCotizacion.Columns["oProducto"].Visible = false;

            dataGridViewDetalleCotizacion.Columns["NombreProducto"].HeaderText = "Producto";
            dataGridViewDetalleCotizacion.Columns["Cantidad"].HeaderText = "Cantidad";
            dataGridViewDetalleCotizacion.Columns["Fecha"].HeaderText = "Fecha de Solicitud";
        }

        #endregion

        private void dataGridViewCotizaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCotizaciones.SelectedRows.Count > 0)
            {
                int cotizacionId = (int)dataGridViewCotizaciones.SelectedRows[0].Cells["Id"].Value;
                CargarDetallesCotizacion(cotizacionId);
            }
        }

        private void rbPendiente_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPendiente.Checked)
            {
                CargarCotizacionesPorEstado();
            }
        }

        private void rbFinalizado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFinalizado.Checked)
            {
                CargarCotizacionesPorEstado();
            }
        }

        private void buttonfrmOrdenCompra_Click(object sender, EventArgs e)
        {

        }

        private void btnRegProv_Click(object sender, EventArgs e)
        {

        }

        private void btnRegProd_Click(object sender, EventArgs e)
        {

        }
    }
}
