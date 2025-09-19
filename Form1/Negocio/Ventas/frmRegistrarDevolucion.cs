using BEs;
using BEs.Clases.Negocio.Enums;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using BLLs.Tecnica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix.Negocio.Ventas
{
    public partial class frmRegistrarDevolucion : Form, IObservador
    {
        private readonly BLL_DEVOLUCION _bllDevolucion;
        private readonly BLL_VENTA _bllVenta;
        private readonly BLL_PRODUCTO _bllProducto;
        private readonly BLL_FACTURACION _bllFacturacion;
        private readonly BLL_EXPORTACION _bllExportacion;
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;

        public frmRegistrarDevolucion()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            _bllDevolucion = new BLL_DEVOLUCION();
            _bllVenta = new BLL_VENTA();
            _bllProducto = new BLL_PRODUCTO();
            _bllFacturacion = new BLL_FACTURACION();
            _bllExportacion = new BLL_EXPORTACION();
            CargarIdiomas();
            Actualizar(sesion.Idioma);
            CargarCombos();

            comboVentas.SelectedIndexChanged += ComboVentas_SelectedIndexChanged;
            comboProductos.SelectedIndexChanged += ComboProductos_SelectedIndexChanged;
        }

        public frmRegistrarDevolucion(int ventaId, int productoId) : this()
        {
            try
            {
                if (comboVentas.Items.Count > 0)
                    comboVentas.SelectedValue = ventaId;
                if (comboProductos.Items.Count > 0)
                    comboProductos.SelectedValue = productoId;
            }
            catch { }
        }

        private void CargarCombos()
        {
            try
            {
                var todasLasVentas = _bllVenta.ObtenerTodos()
                    .Where(v => v.EstadoVentaEnum == EstadoVenta.Cobrada || v.EstadoVentaEnum == EstadoVenta.Entregada)
                    .ToList();

                var ventasConDevoluciones = _bllDevolucion.ObtenerVentasConDevoluciones();

                var ventasDisponibles = todasLasVentas
                    .Where(v => !ventasConDevoluciones.Contains(v.Id))
                    .OrderByDescending(v => v.Fecha)
                    .ToList();

                var ventasDisplay = ventasDisponibles.Select(v => new
                {
                    Id = v.Id,
                    Descripcion = $"Venta #{v.Id} - {v.Fecha:dd/MM/yyyy} - ${v.MontoTotal:F2} - {v.NombreCliente}"
                }).ToList();

                comboVentas.DataSource = ventasDisplay;
                comboVentas.DisplayMember = "Descripcion";
                comboVentas.ValueMember = "Id";

                // Solo mostrar productos que están activos
                // Los productos específicos de cada venta se filtrarán dinámicamente
                var productos = _bllProducto.ObtenerTodos().Where(p => p.Estado).ToList();
                comboProductos.DataSource = productos;
                comboProductos.DisplayMember = "Nombre";
                comboProductos.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (comboVentas.SelectedValue == null || comboProductos.SelectedValue == null) { MessageBox.Show("Seleccione venta y producto."); return; }
            if (numericCantidad.Value <= 0) { MessageBox.Show("Cantidad inválida."); return; }

            int ventaId = (int)comboVentas.SelectedValue;
            int productoId = (int)comboProductos.SelectedValue;
            decimal cantidad = numericCantidad.Value;
            string motivo = txtMotivo.Text?.Trim();
            bool apto = chkApto.Checked;
            int? usuarioId = sesion.oUsuario != null ? (int?)sesion.oUsuario.Id : null;

            // Validar que no se pueda devolver más de lo que se compró
            if (!ValidarCantidadDevolucion(ventaId, productoId, cantidad))
            {
                return; // La validación ya muestra el mensaje de error
            }

            try
            {
                _bllDevolucion.RegistrarCliente(ventaId, productoId, cantidad, motivo, apto, usuarioId);

                // Generar Nota de Crédito (parcial, solo por lo devuelto)
                var venta = _bllVenta.ObtenerPorId(ventaId);
                var producto = _bllProducto.ObtenerPorId(productoId);
                var items = new System.Collections.Generic.List<(string Producto, decimal Cantidad, decimal PrecioUnit)>
                {
                    (producto?.Nombre ?? $"Prod {productoId}", cantidad, ObtenerPrecioUnitarioDeVenta(ventaId, productoId))
                };
                string ruta = _bllFacturacion.GenerarNotaCreditoPDF(venta, items, motivo);
                MessageBox.Show($"Devolución registrada correctamente.\nNota de Crédito generada en:\n{ruta}", ConstantesUI.Titulos.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Preguntar si desea abrir la nota de crédito
                var abrirNota = MessageBox.Show("¿Desea abrir la Nota de Crédito generada?",
                    ConstantesUI.Titulos.Confirmacion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (abrirNota == DialogResult.Yes)
                {
                    try
                    {
                        _bllExportacion.AbrirArchivo(ruta);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"No se pudo abrir la Nota de Crédito: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                Limpiar();
                CargarCombos();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private decimal ObtenerPrecioUnitarioDeVenta(int ventaId, int productoId)
        {
            var detalles = _bllVenta.ObtenerDetallesPorVentaId(ventaId);
            var detalle = detalles?.FirstOrDefault(d => d.oProducto?.Id == productoId);
            return detalle?.Precio ?? 0m;
        }

        private bool ValidarCantidadDevolucion(int ventaId, int productoId, decimal cantidadADevolver)
        {
            try
            {
                // Obtener la cantidad original comprada de este producto en esta venta
                var detalles = _bllVenta.ObtenerDetallesPorVentaId(ventaId);
                var detalleProducto = detalles?.FirstOrDefault(d => d.oProducto?.Id == productoId);

                if (detalleProducto == null)
                {
                    MessageBox.Show(
                        "El producto seleccionado no se encuentra en esta venta.",
                        ConstantesUI.Titulos.Validacion,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }

                decimal cantidadOriginal = detalleProducto.Cantidad;

                // Obtener la cantidad ya devuelta de este producto en esta venta
                decimal cantidadYaDevuelta = _bllDevolucion.ObtenerCantidadDevueltaProductoVenta(ventaId, productoId);

                // Cantidad disponible para devolver
                decimal cantidadDisponibleParaDevolver = cantidadOriginal - cantidadYaDevuelta;

                if (cantidadADevolver > cantidadDisponibleParaDevolver)
                {
                    MessageBox.Show(
                        $"No se puede devolver esa cantidad.\n\n" +
                        $"Cantidad original comprada: {cantidadOriginal:N2}\n" +
                        $"Cantidad ya devuelta: {cantidadYaDevuelta:N2}\n" +
                        $"Cantidad disponible para devolver: {cantidadDisponibleParaDevolver:N2}\n" +
                        $"Cantidad que intenta devolver: {cantidadADevolver:N2}",
                        ConstantesUI.Titulos.Validacion,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    // Ajustar el control numeric a la cantidad máxima permitida
                    numericCantidad.Value = cantidadDisponibleParaDevolver;
                    return false;
                }

                if (cantidadDisponibleParaDevolver <= 0)
                {
                    MessageBox.Show(
                        "No hay cantidad disponible para devolver de este producto en esta venta.\n" +
                        "Ya se ha devuelto la totalidad del producto comprado.",
                        ConstantesUI.Titulos.Validacion,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al validar la cantidad de devolución: {ex.Message}",
                    ConstantesUI.Titulos.Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        private void Limpiar()
        {
            numericCantidad.Value = 0;
            txtMotivo.Text = string.Empty;
            chkApto.Checked = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ComboVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarInformacionCantidades();
        }

        private void ComboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarInformacionCantidades();
        }

        private void ActualizarInformacionCantidades()
        {
            try
            {
                if (comboVentas.SelectedValue == null || comboProductos.SelectedValue == null)
                {
                    // Resetear información si no hay selección completa
                    numericCantidad.Maximum = 999;
                    numericCantidad.Minimum = 0;
                    return;
                }

                int ventaId = (int)comboVentas.SelectedValue;
                int productoId = (int)comboProductos.SelectedValue;

                // Obtener información de cantidad
                var detalles = _bllVenta.ObtenerDetallesPorVentaId(ventaId);
                var detalleProducto = detalles?.FirstOrDefault(d => d.oProducto?.Id == productoId);

                if (detalleProducto != null)
                {
                    decimal cantidadOriginal = detalleProducto.Cantidad;
                    decimal cantidadYaDevuelta = _bllDevolucion.ObtenerCantidadDevueltaProductoVenta(ventaId, productoId);
                    decimal cantidadDisponible = cantidadOriginal - cantidadYaDevuelta;

                    // Configurar el rango del NumericUpDown
                    numericCantidad.Minimum = 0;
                    numericCantidad.Maximum = cantidadDisponible > 0 ? cantidadDisponible : 0;

                    // Si ya no hay cantidad disponible, mostrar 0 y deshabilitar
                    if (cantidadDisponible <= 0)
                    {
                        numericCantidad.Value = 0;
                        numericCantidad.Enabled = false;
                    }
                    else
                    {
                        numericCantidad.Enabled = true;
                        // Solo ajustar si el valor actual es mayor al disponible
                        if (numericCantidad.Value > cantidadDisponible)
                        {
                            numericCantidad.Value = cantidadDisponible;
                        }
                        // Si está en 0, sugerir cantidad 1 (si es posible)
                        else if (numericCantidad.Value == 0 && cantidadDisponible >= 1)
                        {
                            numericCantidad.Value = 1;
                        }
                    }
                }
                else
                {
                    // El producto no está en esta venta
                    numericCantidad.Maximum = 0;
                    numericCantidad.Value = 0;
                    numericCantidad.Enabled = false;
                }
            }
            catch (Exception)
            {
                // En caso de error, mantener configuración segura
                numericCantidad.Maximum = 999;
                numericCantidad.Minimum = 0;
                numericCantidad.Enabled = true;
            }
        }

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
            catch { }
        }

        public void Actualizar(BEs.Interfaces.IIdioma idioma)
        {
            foreach (Control control in ListaControles)
            {
                if (control.Tag != null)
                {
                    string traduccion = Bll_Traduccion.BuscarTraduccion(control.Tag.ToString(), idioma.Id);
                    if (!string.IsNullOrEmpty(traduccion)) control.Text = traduccion;
                }
            }
            RecorrerDataGridTraduccion(idioma);
            if (cboxIdiomas.DataSource != null && cboxIdiomas.Items.Count > 0 && cboxIdiomas.ValueMember != string.Empty)
            {
                cboxIdiomas.SelectedValue = idioma.Id;
            }
        }

        public void RecorrerDataGridTraduccion(BEs.Interfaces.IIdioma idioma)
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
                            if (!string.IsNullOrEmpty(traduccion)) column.HeaderText = traduccion;
                        }
                    }
                }
            }
        }

        private List<Control> ListaControles = new List<Control>();

        public void BuscarControles(ICollection controles)
        {
            foreach (Control control in controles)
            {
                ListaControles.Add(control);
                if (control.Controls.Count > 0) BuscarControles(control.Controls);
            }
        }
    }
}