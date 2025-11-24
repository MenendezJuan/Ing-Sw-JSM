using BEs;
using BEs.Clases;
using BEs.Clases.Negocio.Enums;
using BEs.Clases.Negocio.Ventas;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix
{
    public enum ModoDevolucion
    {
        Iniciar,
        Evaluar,
        Procesar,
        Ver
    }

    public partial class frmDevolucionDetalle : Form, IObservador
    {
        private class LineaDevolucionView
        {
            public int ProductoId { get; set; }
            public string NombreProducto { get; set; }
            public decimal CantidadVendida { get; set; }
            public decimal CantidadYaDevuelta { get; set; }
            public decimal Cantidad { get; set; }
        }

        private ModoDevolucion _modo;
        public ModoDevolucion Modo
        {
            get => _modo;
            set
            {
                _modo = value;
                ConfigurarModo();
            }
        }
        public int DevolucionId { get; set; }

        private readonly BLL_DEVOLUCION _bllDevolucion;
        private readonly BLL_VENTA _bllVenta;
        private readonly BLL_PRODUCTO _bllProducto;
        private readonly BLL_CLIENTE _bllCliente;
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;

        private Devolucion _devolucionActual;
        private List<DevolucionDetalle> _detallesActuales;

        public frmDevolucionDetalle()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            _bllDevolucion = new BLL_DEVOLUCION();
            _bllVenta = new BLL_VENTA();
            _bllProducto = new BLL_PRODUCTO();
            _bllCliente = new BLL_CLIENTE();

            CargarIdiomas();
            sesion.RegistrarObservador(this); // Registrarse como observador para multiidioma
            Actualizar(sesion.Idioma);
            ConfigurarControles();

            // Eventos
            comboVenta.SelectedIndexChanged += comboVenta_SelectedIndexChanged;
            dataGridViewDetalles.CellValidating += dataGridViewDetalles_CellValidating;
            dataGridViewDetalles.DataError += dataGridViewDetalles_DataError;

            if (sesion.Permisos != null && sesion.Permisos.Count > 0)
            {
                BuscarControles(this.Controls);
                Buscar(sesion.Permisos[0]);
            }
        }

        private void dataGridViewDetalles_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("Valor inválido. Ingrese un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dataGridViewDetalles_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (Modo != ModoDevolucion.Iniciar) return;
            var grid = (DataGridView)sender;
            var columnName = grid.Columns[e.ColumnIndex].Name;
            if (columnName != "ADevolver_Column") return;

            var row = grid.Rows[e.RowIndex];
            if (row?.DataBoundItem is LineaDevolucionView linea)
            {
                // Parsear nuevo valor
                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), out var nuevaCantidad))
                {
                    e.Cancel = true;
                    MessageBox.Show("Ingrese un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nuevaCantidad < 0m)
                {
                    e.Cancel = true;
                    MessageBox.Show("La cantidad no puede ser negativa.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var maxPermitido = Math.Max(0m, linea.CantidadVendida - linea.CantidadYaDevuelta);
                if (nuevaCantidad > maxPermitido)
                {
                    e.Cancel = true;
                    MessageBox.Show($"La cantidad a devolver ({nuevaCantidad:N2}) no puede superar lo disponible ({maxPermitido:N2}).",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void ConfigurarControles()
        {
            // Configurar DataGrid de líneas
            dataGridViewDetalles.AutoGenerateColumns = false;
            dataGridViewDetalles.Columns.Clear();

            // Columna Producto (solo lectura)
            dataGridViewDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreProducto",
                HeaderText = "Producto",
                Name = "Producto_Column",
                Tag = "grid_Producto_Column",
                Width = 200,
                ReadOnly = true
            });

            // Columna Vendida (solo lectura)
            dataGridViewDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CantidadVendida",
                HeaderText = "Vendida",
                Name = "Vendida_Column",
                Tag = "grid_Vendida_Column",
                Width = 80,
                ReadOnly = true
            });

            // Columna Ya Devuelta (solo lectura)
            dataGridViewDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CantidadYaDevuelta",
                HeaderText = "Ya Devuelta",
                Name = "YaDevuelta_Column",
                Tag = "grid_YaDevuelta_Column",
                Width = 100,
                ReadOnly = true
            });

            // Columna A Devolver (editable solo en modo Iniciar)
            dataGridViewDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cantidad",
                HeaderText = "A Devolver",
                Name = "ADevolver_Column",
                Tag = "grid_ADevolver_Column",
                Width = 100,
                ReadOnly = false
            });

            // Configurar estilos del DataGrid
            dataGridViewDetalles.BackgroundColor = System.Drawing.Color.White;
            dataGridViewDetalles.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dataGridViewDetalles.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridViewDetalles.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(32, 30, 45);
            dataGridViewDetalles.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewDetalles.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(32, 30, 45);
            dataGridViewDetalles.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridViewDetalles.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            dataGridViewDetalles.EnableHeadersVisualStyles = false;

            // Configurar combos
            comboEstado.DataSource = Enum.GetValues(typeof(EstadoDevolucion));
            comboEstado.DisplayMember = "EstadoDevolucion";
        }

        private void ConfigurarModo()
        {
            switch (Modo)
            {
                case ModoDevolucion.Iniciar:
                    this.Text = "Nueva Devolución";
                    lblTitulo.Text = "Nueva Devolución";
                    btnGuardar.Text = "Crear Devolución";
                    btnGuardar.Tag = "btnGuardarDevolucion";
                    btnGuardar.Visible = true;

                    comboVenta.Enabled = true;
                    comboVenta.Visible = true;
                    txtVenta.Visible = false;
                    txtMotivo.Enabled = true;
                    dataGridViewDetalles.ReadOnly = false;

                    lblObservacionesGerente.Visible = false;
                    txtObservacionesGerente.Visible = false;
                    lblObservacionesDeposito.Visible = false;
                    txtObservacionesDeposito.Visible = false;

                    btnAprobar.Visible = false;
                    btnRechazar.Visible = false;
                    btnFirmarConforme.Visible = false;

                    // Mostrar estado inicial por claridad
                    if (comboEstado.Items.Count > 0) comboEstado.SelectedItem = EstadoDevolucion.Iniciada;

                    CargarVentasDisponibles();
                    break;

                case ModoDevolucion.Evaluar:
                    this.Text = "Evaluar Devolución";
                    lblTitulo.Text = "Evaluar Devolución";
                    btnGuardar.Text = "Guardar Evaluación";
                    btnGuardar.Tag = "btnGuardarEvaluacion";
                    btnGuardar.Visible = false;

                    comboVenta.Enabled = false;
                    comboVenta.Visible = false;
                    txtVenta.Visible = true;
                    txtMotivo.Enabled = false;
                    dataGridViewDetalles.ReadOnly = true;
                    lblObservacionesGerente.Visible = true;
                    txtObservacionesGerente.Visible = true;
                    txtObservacionesGerente.Enabled = true;
                    lblObservacionesDeposito.Visible = false;
                    txtObservacionesDeposito.Visible = false;
                    btnAprobar.Visible = true;
                    btnRechazar.Visible = true;
                    btnFirmarConforme.Visible = false;

                    CargarDevolucionExistente();
                    break;

                case ModoDevolucion.Procesar:
                    this.Text = "Procesar Devolución";
                    lblTitulo.Text = "Procesar Devolución";
                    btnGuardar.Text = "Procesar Devolución";
                    btnGuardar.Tag = "btnProcesarDevolucion";
                    // Se procesa con el botón específico (Firmar/Procesar)
                    btnGuardar.Visible = false;

                    // Solo lectura
                    comboVenta.Enabled = false;
                    comboVenta.Visible = false;
                    txtVenta.Visible = true;
                    txtMotivo.Enabled = false;
                    dataGridViewDetalles.ReadOnly = true;

                    // Habilitar campos de procesamiento
                    lblObservacionesDeposito.Visible = true;
                    txtObservacionesDeposito.Visible = true;
                    txtObservacionesDeposito.Enabled = true;

                    // Botones específicos
                    btnAprobar.Visible = false;
                    btnRechazar.Visible = false;
                    btnFirmarConforme.Visible = true;

                    CargarDevolucionExistente();
                    break;

                case ModoDevolucion.Ver:
                    this.Text = "Ver Devolución";
                    lblTitulo.Text = "Ver Devolución";
                    btnGuardar.Visible = false;

                    // Todo solo lectura
                    comboVenta.Enabled = false;
                    comboVenta.Visible = false;
                    txtVenta.Visible = true;
                    txtMotivo.Enabled = false;
                    dataGridViewDetalles.ReadOnly = true;

                    // Mostrar todas las observaciones
                    lblObservacionesGerente.Visible = true;
                    txtObservacionesGerente.Visible = true;
                    txtObservacionesGerente.Enabled = false;
                    lblObservacionesDeposito.Visible = true;
                    txtObservacionesDeposito.Visible = true;
                    txtObservacionesDeposito.Enabled = false;

                    // Ocultar botones específicos
                    btnAprobar.Visible = false;
                    btnRechazar.Visible = false;
                    btnFirmarConforme.Visible = false;

                    CargarDevolucionExistente();
                    break;
            }
        }

        private void CargarVentasDisponibles()
        {
            try
            {
                var ventas = _bllVenta.ObtenerTodos()
                    .Where(v => v.EstadoVentaEnum == EstadoVenta.Entregada)
                    .OrderByDescending(v => v.Fecha)
                    .ToList();

                var ventasConDevolucion = _bllDevolucion.ObtenerVentasConDevoluciones();
                if (ventasConDevolucion != null && ventasConDevolucion.Count > 0)
                {
                    ventas = ventas.Where(v => !ventasConDevolucion.Contains(v.Id)).ToList();
                }

                var ventasDisplay = ventas.Select(v => new
                {
                    Id = v.Id,
                    Descripcion = $"Venta #{v.Id} - {v.Fecha:dd/MM/yyyy} - {v.NombreCliente}"
                }).ToList();

                comboVenta.DataSource = ventasDisplay;
                comboVenta.DisplayMember = "Descripcion";
                comboVenta.ValueMember = "Id";

                if (ventasDisplay.Any())
                {
                    comboVenta.SelectedIndex = 0;
                    CargarProductosDeVenta();
                }
                else
                {
                    dataGridViewDetalles.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDevolucionExistente()
        {
            try
            {
                _devolucionActual = _bllDevolucion.ObtenerPorId(DevolucionId);
                if (_devolucionActual == null)
                {
                    MessageBox.Show("Devolución no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Cargar datos en controles
                txtVenta.Text = $"{_devolucionActual.NumeroVenta} - {_devolucionActual.NombreCliente}";
                comboEstado.SelectedItem = _devolucionActual.Estado;
                txtMotivo.Text = _devolucionActual.Motivo;
                txtObservacionesGerente.Text = _devolucionActual.ObservacionesGerente;
                txtObservacionesDeposito.Text = _devolucionActual.ObservacionesDeposito;

                // Cargar detalles con información adicional
                CargarDetallesConInformacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar devolución: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void CargarDetallesConInformacion()
        {
            try
            {
                var detallesConInfo = new List<dynamic>();

                foreach (var detalle in _devolucionActual.oDetalles)
                {
                    // Obtener información de la venta original
                    var detalleVenta = _bllVenta.ObtenerDetallesPorVentaId(_devolucionActual.VentaId)
                        .FirstOrDefault(d => d.ProductoId == detalle.ProductoId);

                    decimal cantidadVendida = detalleVenta?.Cantidad ?? 0;
                    decimal cantidadYaDevuelta = _bllDevolucion.ObtenerCantidadDevueltaAcumulada(_devolucionActual.VentaId, detalle.ProductoId);

                    detallesConInfo.Add(new
                    {
                        NombreProducto = detalle.NombreProducto,
                        CantidadVendida = cantidadVendida,
                        CantidadYaDevuelta = cantidadYaDevuelta,
                        Cantidad = detalle.Cantidad
                    });
                }

                dataGridViewDetalles.DataSource = detallesConInfo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Modo == ModoDevolucion.Iniciar && comboVenta.SelectedValue != null)
            {
                CargarProductosDeVenta();
            }
        }

        private void CargarProductosDeVenta()
        {
            try
            {
                if (comboVenta.SelectedValue == null) return;

                int ventaId;
                try
                {
                    ventaId = Convert.ToInt32(comboVenta.SelectedValue);
                }
                catch
                {
                    var val = comboVenta.SelectedValue;
                    var prop = val?.GetType().GetProperty("Id");
                    if (prop == null) throw;
                    ventaId = Convert.ToInt32(prop.GetValue(val));
                }
                var detallesVenta = _bllVenta.ObtenerDetallesPorVentaId(ventaId);

                var productosParaDevolucion = detallesVenta.Select(d => new LineaDevolucionView
                {
                    ProductoId = d.ProductoId,
                    NombreProducto = d.NombreProducto,
                    CantidadVendida = Convert.ToDecimal(d.Cantidad),
                    CantidadYaDevuelta = _bllDevolucion.ObtenerCantidadDevueltaAcumulada(ventaId, d.ProductoId),
                    Cantidad = 0m // Por defecto 0, editable
                }).ToList();

                // Usamos BindingList para que el grid sea editable
                dataGridViewDetalles.DataSource = new System.ComponentModel.BindingList<LineaDevolucionView>(productosParaDevolucion);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Modo)
                {
                    case ModoDevolucion.Iniciar:
                        GuardarNuevaDevolucion();
                        break;
                    case ModoDevolucion.Evaluar:
                        // Usar botones específicos
                        MessageBox.Show("Use los botones Aprobar o Rechazar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case ModoDevolucion.Procesar:
                        ProcesarDevolucion();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarNuevaDevolucion()
        {
            if (comboVenta.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una venta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Ingrese el motivo de la devolución.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener detalles con cantidades > 0
            var detalles = new List<DevolucionDetalle>();
            if (dataGridViewDetalles.DataSource is System.ComponentModel.BindingList<LineaDevolucionView> lineas)
            {
                foreach (var item in lineas.Where(l => l.Cantidad > 0m))
                {
                    var maxPermitido = Math.Max(0m, item.CantidadVendida - item.CantidadYaDevuelta);
                    if (item.Cantidad > maxPermitido)
                    {
                        MessageBox.Show(
                            $"La cantidad a devolver de '{item.NombreProducto}' ({item.Cantidad:N2}) supera lo disponible ({maxPermitido:N2}).",
                            "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    detalles.Add(new DevolucionDetalle
                    {
                        ProductoId = item.ProductoId,
                        Cantidad = item.Cantidad
                    });
                }
            }

            if (!detalles.Any())
            {
                MessageBox.Show("Debe seleccionar al menos un producto para devolver.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear devolución
            var devolucion = new Devolucion
            {
                VentaId = (int)comboVenta.SelectedValue,
                FechaSolicitud = DateTime.Now,
                Estado = EstadoDevolucion.Iniciada,
                Motivo = txtMotivo.Text.Trim()
            };

            int devolucionId = _bllDevolucion.Iniciar(devolucion, detalles);

            MessageBox.Show("Devolución creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            try
            {
                _bllDevolucion.Evaluar(DevolucionId, EstadoDevolucion.Autorizada, txtObservacionesGerente.Text.Trim(), sesion.oUsuario.Id);
                MessageBox.Show("Devolución autorizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al aprobar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            try
            {
                _bllDevolucion.Evaluar(DevolucionId, EstadoDevolucion.Rechazada, txtObservacionesGerente.Text.Trim(), sesion.oUsuario.Id);
                MessageBox.Show("Devolución rechazada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al rechazar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcesarDevolucion()
        {
            try
            {
                // Validar observaciones de depósito
                if (string.IsNullOrWhiteSpace(txtObservacionesDeposito.Text))
                {
                    MessageBox.Show("Debe ingresar observaciones del depósito antes de firmar la conformidad.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtObservacionesDeposito.Focus();
                    return;
                }

                _bllDevolucion.Procesar(DevolucionId, txtObservacionesDeposito.Text.Trim(), SessionManager.GetInstance().oUsuario.Id);
                string rutaArchivo = _bllDevolucion.ObtenerUltimoArchivoConforme(DevolucionId);

                MessageBox.Show($"Devolución procesada correctamente.\n\nArchivo de conformidad generado en:\n{rutaArchivo}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFirmarConforme_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtObservacionesDeposito.Text))
            {
                MessageBox.Show("Debe ingresar observaciones del depósito antes de firmar la conformidad.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtObservacionesDeposito.Focus();
                return;
            }

            var result = MessageBox.Show("¿Confirma que los productos de reemplazo están en buenas condiciones y han sido entregados al cliente?",
                "Confirmar Conformidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ProcesarDevolucion();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CargarIdiomas()
        {
            try
            {
                var idiomas = Bll_Idioma.ListarTodos();
                cboxIdiomas.DataSource = idiomas;
                cboxIdiomas.DisplayMember = "Nombre";
                cboxIdiomas.ValueMember = "Id";

                if (sesion.Idioma != null)
                {
                    cboxIdiomas.SelectedValue = sesion.Idioma.Id;
                }
                else
                {
                    var idiomaPredeterminado = idiomas.FirstOrDefault(i => i.Nombre == "Español");
                    if (idiomaPredeterminado != null)
                    {
                        cboxIdiomas.SelectedValue = idiomaPredeterminado.Id;
                    }
                }

                // Agregar evento para cambio de idioma
                cboxIdiomas.SelectedIndexChanged += CboxIdiomas_SelectedIndexChanged;
            }
            catch { }
        }

        private void CboxIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxIdiomas.SelectedItem is IIdioma idiomaSeleccionado)
            {
                sesion.CambiarIdioma(idiomaSeleccionado);
            }
        }

        public void Actualizar(IIdioma idioma)
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
                            if (!string.IsNullOrEmpty(traduccion)) column.HeaderText = traduccion;
                        }
                    }
                }
            }
        }

        private List<Control> ListaControles = new List<Control>();

        public void BuscarControles(System.Collections.ICollection controles)
        {
            foreach (Control control in controles)
            {
                ListaControles.Add(control);
                if (control.Controls.Count > 0) BuscarControles(control.Controls);
            }
        }

        public void Buscar(BEs.Clases.Componente c)
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

        public void Comprobar(BEs.Clases.Componente p)
        {
            foreach (Control control in ListaControles)
            {
                if (control.Tag != null && control.Tag.ToString() == p.Nombre)
                {
                    control.Visible = true;
                    control.Enabled = true;
                }
            }
        }
    }
}
