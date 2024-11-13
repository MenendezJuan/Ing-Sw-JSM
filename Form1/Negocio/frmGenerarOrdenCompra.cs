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
            sesion.RegistrarObservador(this);
            IIdioma oIdioma = sesion.Idioma;
            CargarIdiomas();
            Actualizar(oIdioma);
            if (sesion.Permisos != null)
            {
                BuscarControles(this.Controls);
                Buscar(sesion.Permisos[0]);
            }
            _bllCotizacion = new BLL_COTIZACION();
            _bllCompra = new BLL_COMPRA();
            _bllProveedor = new BLL_PROVEEDOR();
        }

        private void frmGenerarOrdenCompra_Load(object sender, EventArgs e)
        {
            ActualizarDataGrids();
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
            int compraId = _bllCompra.Insertar(nuevaCompra);

            nuevaCompra.Id = compraId;

            // Notificar al usuario
            MessageBox.Show("La orden de compra ha sido generada exitosamente y está en estado Pendiente.", "Orden de Compra Generada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormulario();
            CargarOrdenesCompra();
            CargarCotizacionesAprobadas();
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            // Obtener el elemento seleccionado en el DataGridView
            if (dataGridViewCompra.CurrentRow?.DataBoundItem is Compra compra)
            {
                // Verificar si el estado de la compra es Pendiente
                if (compra.EstadoCompraEnum == EstadoCompra.Pendiente)
                {
                    try
                    {
                        // Cambiar el estado a Pagada y actualizar el stock
                        _bllCompra.CambiarEstadoCompraYActualizarStock(compra.Id, EstadoCompra.Pagada);

                        // Eliminar la cotización asociada y sus detalles
                        var cotizacionId = compra.CotizacionId; // Asegúrate de que el modelo de Compra tenga esta referencia
                        if (compra != null && compra.CotizacionId.HasValue)
                        {
                            // Eliminar la referencia a CotizacionId en la base de datos
                            _bllCompra.EliminarReferenciaCotizacion(compra.Id);

                            // Eliminar la cotización y sus detalles
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

            // Ocultar columnas de objetos complejos
            if (dataGridViewCompra.Columns["ProveedorId"] != null)
                dataGridViewCompra.Columns["ProveedorId"].Visible = false;

            if (dataGridViewCompra.Columns["oProveedor"] != null)
                dataGridViewCompra.Columns["oProveedor"].Visible = false;

            if (dataGridViewCompra.Columns["CotizacionId"] != null)
                dataGridViewCompra.Columns["CotizacionId"].Visible = false;

            if (dataGridViewCompra.Columns["NombreProveedor"] != null)
                dataGridViewCompra.Columns["NombreProveedor"].HeaderText = "Proveedor";

            // Configurar encabezados de columnas y orden
            if (dataGridViewCompra.Columns["Id"] != null)
                dataGridViewCompra.Columns["Id"].HeaderText = "Nro. Orden";

            if (dataGridViewCompra.Columns["Fecha"] != null)
                dataGridViewCompra.Columns["Fecha"].HeaderText = "Fecha";

            if (dataGridViewCompra.Columns["MontoTotal"] != null)
                dataGridViewCompra.Columns["MontoTotal"].HeaderText = "Monto Total";

            if (dataGridViewCompra.Columns["Comentario"] != null)
                dataGridViewCompra.Columns["Comentario"].HeaderText = "Comentario";

            if (dataGridViewCompra.Columns["EstadoCompraEnum"] != null)
                dataGridViewCompra.Columns["EstadoCompraEnum"].HeaderText = "Estado";

            if (dataGridViewCompra.Columns["TipoPagoEnum"] != null)
                dataGridViewCompra.Columns["TipoPagoEnum"].HeaderText = "Tipo de Pago";
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

            // Suscribirse al evento OnRecepcionRechazada para actualizar los DataGridViews
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

                // Actualizar el DataGridView de detalles de compra
                ActualizarDataGridViewDetalle(compraSeleccionada.oDetalleCompra);

                // Habilitar el botón de verificación de productos si el estado es "Pendiente"
                buttonVerificacionProductos.Enabled = compraSeleccionada.EstadoCompraEnum == EstadoCompra.Pendiente;
            }
            else
            {
                // Deshabilitar el botón si no hay una compra seleccionada o no es válida
                buttonVerificacionProductos.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewCompra_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Error en la columna {e.ColumnIndex}: {e.Exception.Message}", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.ThrowException = false; // Evita que el programa se bloquee
        }

        private void dataGridViewDetalles_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Error en la columna {e.ColumnIndex}: {e.Exception.Message}", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.ThrowException = false; // Evita que el programa se bloquee
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

            if (cboxIdiomas.DataSource != null && cboxIdiomas.Items.Count > 0 && cboxIdiomas.ValueMember != string.Empty)
            {
                cboxIdiomas.SelectedValue = idioma.Id;
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

        //Ajustar esta logica
        #region Extras
        int i = 0;
        public void Cerrar()
        {
            if (i == 0)
            {
                frmMenuPrincipal FormPrincipal = new frmMenuPrincipal();
                FormPrincipal.Show();
                i++;
                this.Close();
            }
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
