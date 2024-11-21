using BEs;
using BEs.Clases;
using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Compras;
using BEs.Clases.Negocio.Compras.Enums;
using BEs.Clases.Negocio.Enums;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using Form1.Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Form1
{
    public partial class frmGenerarOrdenCompra : Form, IObservador
    {
        private BLL_COTIZACION _bllCotizacion;
        private BLL_COMPRA _bllCompra;
        private BLL_PROVEEDOR _bllProveedor;
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        public frmGenerarOrdenCompra()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            _bllCotizacion = new BLL_COTIZACION();
            _bllCompra = new BLL_COMPRA();
            _bllProveedor = new BLL_PROVEEDOR();
            ActualizarDataGrids();
            CargarComboBoxTipoPago();
            sesion.RegistrarObservador(this);
            IIdioma oIdioma = sesion.Idioma;
            CargarIdiomas();
            Actualizar(oIdioma);
            if (sesion.Permisos != null)
            {
                BuscarControles(this.Controls);
                Buscar(sesion.Permisos[0]);
            }
        }

        private void frmGenerarOrdenCompra_Load(object sender, EventArgs e)
        {

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
            if (cotizacionSeleccionada.EstadoCotizacionEnum != EstadoCotizacion.Aprobada)
            {
                MessageBox.Show("La cotización seleccionada no está aprobada. No se puede generar la orden de compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CompraExistente(cotizacionSeleccionada.Id))
            {
                MessageBox.Show("Ya existe una orden de compra generada para esta cotización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                CotizacionId = cotizacionSeleccionada.Id,
                oDetalleCompra = new List<DetalleCompra>()
            };

            decimal montoTotal = 0;

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

                nuevaCompra.oDetalleCompra.Add(detalleCompra);

                montoTotal += subtotal;
            }

            nuevaCompra.MontoTotal = montoTotal;

            int compraId = _bllCompra.Insertar(nuevaCompra);

            nuevaCompra.Id = compraId;

            MessageBox.Show("La orden de compra ha sido generada exitosamente y está en estado Pendiente.", "Orden de Compra Generada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormulario();
            CargarOrdenesCompra();
            CargarCotizacionesAprobadas();
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            if (dataGridViewCompra.CurrentRow?.DataBoundItem is Compra compra)
            {
                if (compra.EstadoCompraEnum == EstadoCompra.Verificada)
                {
                    try
                    {
                        _bllCompra.CambiarEstadoCompraYActualizarStock(compra.Id, EstadoCompra.Pagada);

                        var cotizacionId = compra.CotizacionId;
                        if (compra != null && compra.CotizacionId.HasValue)
                        {
                            _bllCompra.EliminarReferenciaCotizacion(compra.Id);

                            _bllCotizacion.Eliminar(compra.CotizacionId.Value);
                        }

                        MessageBox.Show("La compra ha sido marcada como pagada y la cotización asociada ha sido eliminada.");

                        CargarOrdenesCompra();
                        CargarCotizacionesAprobadas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al procesar la compra: {ex.Message}");
                    }
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
        public void HabilitarBotonPago(bool habilitar)
        {
            btnPago.Enabled = habilitar;
        }

        private Compra ObtenerCompraSeleccionada()
        {
            if (dataGridViewCompra.CurrentRow?.DataBoundItem is Compra compraSeleccionada)
            {
                return compraSeleccionada;
            }
            return null;
        }

        private void ActualizarDataGridViewDetalle(List<DetalleCompra> detalles)
        {
            dataGridViewDetalles.DataSource = null;
            dataGridViewDetalles.DataSource = detalles;
            ConfigurarDataGridDetalle();
            Actualizar(sesion.Idioma);


        }

        private void ConfigurarDataGridDetalle()
        {
            if (dataGridViewDetalles.Columns["CompraId"] != null)
                dataGridViewDetalles.Columns["CompraId"].Visible = false;

            if (dataGridViewDetalles.Columns["ProductoId"] != null)
                dataGridViewDetalles.Columns["ProductoId"].Visible = false;

            if (dataGridViewDetalles.Columns["oProducto"] != null)
                dataGridViewDetalles.Columns["oProducto"].Visible = false;

            if (dataGridViewDetalles.Columns["oCompra"] != null)
                dataGridViewDetalles.Columns["oCompra"].Visible = false;

            if (dataGridViewDetalles.Columns["NombreProducto"] != null)
            {
                dataGridViewDetalles.Columns["NombreProducto"].HeaderText = "Producto";
                dataGridViewDetalles.Columns["NombreProducto"].Tag = "NombreProducto_column";
            }

            dataGridViewDetalles.Columns["Precio"].HeaderText = "Precio";
            dataGridViewDetalles.Columns["Precio"].Tag = "Precio_column";

            dataGridViewDetalles.Columns["SubTotal"].HeaderText = "Sub-Total";
            dataGridViewDetalles.Columns["SubTotal"].Tag = "SubTotal_column";

            if (dataGridViewDetalles.Columns["Cantidad"] != null)
            {
                dataGridViewDetalles.Columns["Cantidad"].HeaderText = "Cantidad";
                dataGridViewDetalles.Columns["Cantidad"].Tag = "Cantidad_column";
            }

            if (dataGridViewDetalles.Columns["Fecha"] != null)
            {
                dataGridViewDetalles.Columns["Fecha"].HeaderText = "Fecha de Compra";
                dataGridViewDetalles.Columns["Fecha"].Tag = "FechaCompra_column";
            }
        }

        private void ActualizarDataGridViewCotizacionRecibiendoLista(List<Cotizacion> cotizaciones)
        {
            dataGridViewCotizaciones.DataSource = null;

            // Asignar la lista de cotizaciones al DataGridView
            dataGridViewCotizaciones.DataSource = cotizaciones;

            // Ocultar columnas que no deseas mostrar
            dataGridViewCotizaciones.Columns["ProveedorId"].Visible = false;
            dataGridViewCotizaciones.Columns["Proveedor"].Visible = false;

            // Ajustar el encabezado y la ubicación de la columna `DescripcionProveedor`
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].HeaderText = "Proveedor";
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].Tag = "Proveedor_Column";
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].DisplayIndex = 2;

            // Configurar encabezados de otras columnas
            dataGridViewCotizaciones.Columns["FechaCotizacion"].HeaderText = "Fecha de Cotización";
            dataGridViewCotizaciones.Columns["FechaCotizacion"].Tag = "FechaCotizacion_Column";
            dataGridViewCotizaciones.Columns["EstadoCotizacionEnum"].HeaderText = "Estado";
            dataGridViewCotizaciones.Columns["EstadoCotizacionEnum"].Tag = "Estado_Column";
        }


        private void CargarOrdenesCompra()
        {
            dataGridViewCompra.DataSource = null;
            var ordenesCompra = _bllCompra.ObtenerTodos();
            dataGridViewCompra.DataSource = ordenesCompra;

            // Ocultar columnas de objetos complejos
            if (dataGridViewCompra.Columns["ProveedorId"] != null)
                dataGridViewCompra.Columns["ProveedorId"].Visible = false;

            if (dataGridViewCompra.Columns["oProveedor"] != null)
                dataGridViewCompra.Columns["oProveedor"].Visible = false;

            if (dataGridViewCompra.Columns["CotizacionId"] != null)
                dataGridViewCompra.Columns["CotizacionId"].Visible = false;

            if (dataGridViewCompra.Columns["NombreProveedor"] != null)
                dataGridViewCompra.Columns["NombreProveedor"].HeaderText = "Proveedor";
            dataGridViewCompra.Columns["NombreProveedor"].Tag = "Proveedor_Column";

            if (dataGridViewCompra.Columns["Id"] != null)
                dataGridViewCompra.Columns["Id"].HeaderText = "Nro. Orden";
            dataGridViewCompra.Columns["Id"].Tag = "Orden_Column";

            if (dataGridViewCompra.Columns["Fecha"] != null)
                dataGridViewCompra.Columns["Fecha"].HeaderText = "Fecha";
            dataGridViewCompra.Columns["Fecha"].Tag = "FechaC_Column";

            if (dataGridViewCompra.Columns["MontoTotal"] != null)
                dataGridViewCompra.Columns["MontoTotal"].HeaderText = "Monto Total";
            dataGridViewCompra.Columns["MontoTotal"].Tag = "MontoTotal_Column";


            if (dataGridViewCompra.Columns["Comentario"] != null)
                dataGridViewCompra.Columns["Comentario"].HeaderText = "Comentario";
            dataGridViewCompra.Columns["Comentario"].Tag = "Comentario_Column";

            if (dataGridViewCompra.Columns["EstadoCompraEnum"] != null)
                dataGridViewCompra.Columns["EstadoCompraEnum"].HeaderText = "Estado";
            dataGridViewCompra.Columns["EstadoCompraEnum"].Tag = "Estado_Column";

            if (dataGridViewCompra.Columns["TipoPagoEnum"] != null)
                dataGridViewCompra.Columns["TipoPagoEnum"].HeaderText = "Tipo de Pago";
            dataGridViewCompra.Columns["TipoPagoEnum"].Tag = "TipoPago_Column";
        }

        private void LimpiarFormulario()
        {
            textBoxComentario.Clear();
            cbPago.SelectedIndex = -1;
            dataGridViewDetalles.DataSource = null;
            labelProv.Text = string.Empty;
            labelFecha.Text = string.Empty;
        }

        private void AbrirFormularioVerificacionProductos(Compra compra, Cotizacion cotizacion)
        {
            frmVerificacionProductos formVerificacion = new frmVerificacionProductos();
            formVerificacion.Owner = this;

            formVerificacion.OnRecepcionRechazada += ActualizarDataGrids;
            formVerificacion.OnRecepcionAprobada += ActualizarDataGrids;

            formVerificacion.CargarOrdenCompraYCotizacion(compra, cotizacion);
            formVerificacion.Show();
        }

        private void ActualizarDataGrids()
        {
            CargarCotizacionesAprobadas();
            CargarOrdenesCompra();
        }
        private bool CompraExistente(int cotizacionId)
        {
            var compras = _bllCompra.ObtenerTodos();

            return compras.Any(compra => compra.CotizacionId == cotizacionId);
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
            var compraSeleccionada = ObtenerCompraSeleccionada();

            if (compraSeleccionada != null)
            {
                // Obtener y mostrar los detalles de la orden de compra seleccionada
                if (compraSeleccionada.oProveedor != null)
                {
                    var proveedorSeleccionado = _bllProveedor.ObtenerPorId(compraSeleccionada.oProveedor.Id);
                    lblProveedor.Text = proveedorSeleccionado.Descripcion;
                }
                else
                {
                    lblProveedor.Text = "Proveedor no disponible";
                }

                lblFecha.Text = compraSeleccionada.Fecha.ToShortDateString();
                lblTotal.Text = compraSeleccionada.MontoTotal.ToString("C");

                ActualizarDataGridViewDetalle(compraSeleccionada.oDetalleCompra);

                buttonVerificacionProductos.Enabled = compraSeleccionada.EstadoCompraEnum == EstadoCompra.Pendiente;

                btnPago.Enabled = compraSeleccionada.EstadoCompraEnum == EstadoCompra.Verificada;
            }
            else
            {
                buttonVerificacionProductos.Enabled = false;
                btnPago.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cerrar();
        }

        private void dataGridViewCompra_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Error en la columna {e.ColumnIndex}: {e.Exception.Message}", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.ThrowException = false;
        }

        private void dataGridViewDetalles_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Error en la columna {e.ColumnIndex}: {e.Exception.Message}", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.ThrowException = false;
        }

        private void buttonVerificacionProductos_Click(object sender, EventArgs e)
        {
            var compraSeleccionada = ObtenerCompraSeleccionada();

            if (compraSeleccionada != null && compraSeleccionada.EstadoCompraEnum == EstadoCompra.Pendiente)
            {
                var cotizacionSeleccionada = _bllCotizacion.ObtenerPorId(compraSeleccionada.CotizacionId ?? 0);

                if (cotizacionSeleccionada != null)
                {
                    AbrirFormularioVerificacionProductos(compraSeleccionada, cotizacionSeleccionada);
                }
                else
                {
                    MessageBox.Show("No se encontró la cotización relacionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una compra válida antes de proceder.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        #region Idiomas
        private void CargarIdiomas()
        {
            try
            {
                var idiomas = Bll_Idioma.ListarTodos();
                cboxIdiomas.DataSource = idiomas;
                cboxIdiomas.DisplayMember = "Nombre";
                cboxIdiomas.ValueMember = "Id";

                var idiomaPredeterminado = idiomas.FirstOrDefault(i => i.Nombre == "Español");
                if (idiomaPredeterminado != null)
                {
                    cboxIdiomas.SelectedValue = idiomaPredeterminado.Id;
                    sesion.CambiarIdioma(idiomaPredeterminado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los idiomas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarTextosControles(Idioma idioma)
        {
            try
            {
                var traducciones = Bll_Traduccion.ListarPorIdioma(idioma.Id);

                foreach (Control control in ListaControles)
                {
                    var traduccion = traducciones.FirstOrDefault(t => t.Palabra == control.Text);
                    if (traduccion != null)
                    {
                        control.Text = traduccion.TraduccionTexto;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar los textos de los controles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Actualizar(IIdioma idioma)
        {
            foreach (Control control in ListaControles)
            {
                if (control.Tag != null)
                {
                    string traduccion = Bll_Traduccion.BuscarTraduccion(control.Tag.ToString(), idioma.Id);
                    if (!string.IsNullOrEmpty(traduccion))
                    {
                        control.Text = traduccion;
                    }
                }
            }

            RecorrerDataGridTraduccion(idioma);

            if (cboxIdiomas.DataSource != null && cboxIdiomas.Items.Count > 0 && cboxIdiomas.ValueMember != string.Empty)
            {
                cboxIdiomas.SelectedValue = idioma.Id;
            }
        }

        public void RecorrerDataGridTraduccion(IIdioma idioma)
        {
            foreach (Control control in ListaControles)
            {
                if (control is DataGridView dataGridView)
                {
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Tag != null)
                        {
                            string traduccion = Bll_Traduccion.BuscarTraduccion(column.Tag.ToString(), idioma.Id);
                            if (!string.IsNullOrEmpty(traduccion))
                            {
                                column.HeaderText = traduccion;
                            }
                        }
                    }
                }
            }
        }
        #endregion Idiomas

        List<Control> ListaControles = new List<Control>();
        public void BuscarControles(ICollection controles)
        {
            foreach (Control c in controles)
            {
                ListaControles.Add(c);
                if (c.HasChildren)
                {
                    BuscarControles(c.Controls);
                }
            }
        }

        #region Permisos
        public void Buscar(Componente c)
        {
            GrupoPermisos grupo = (GrupoPermisos)c;
            foreach (Componente p in grupo.Permisos)
            {
                if (p is GrupoPermisos)
                {
                    Buscar(p);
                    Comprobar(p);
                }
                else
                {
                    Comprobar(p);
                }
            }
        }

        public void Comprobar(Componente p)
        {
            foreach (Control c in ListaControles)
            {
                if (c.Tag != null && c.Tag.ToString() == p.Nombre)
                {
                    c.Visible = true;
                }
            }
        }
        #endregion Permisos


        #region Extras
        public void Cerrar()
        {
            Form frmMenu = Application.OpenForms.OfType<frmMenuPrincipal>().FirstOrDefault();

            if (frmMenu == null)
            {
                // Si no existe una instancia de frmMenuPrincipal, crea una nueva
                frmMenuPrincipal FormPrincipal = new frmMenuPrincipal();
                FormPrincipal.Show();
            }
            else
            {
                // Si ya existe, simplemente enfócalo
                frmMenu.BringToFront();
            }

            // Cierra el formulario actual
            this.Close();
        }
        #endregion Extras

        private void cboxIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxIdiomas.SelectedItem != null)
            {
                Idioma idiomaSeleccionado = (Idioma)cboxIdiomas.SelectedItem;
                ListaControles.Clear();
                BuscarControles(this.Controls);
                ActualizarTextosControles(idiomaSeleccionado);
                sesion.CambiarIdioma(idiomaSeleccionado);
            }
        }
    }
}
