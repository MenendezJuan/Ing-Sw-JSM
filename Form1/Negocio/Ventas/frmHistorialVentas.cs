using BEs;
using BEs.Clases.Negocio.Enums;
using BEs.Clases.Negocio.Ventas;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using BLLs.Tecnica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix.Negocio.Ventas
{
    public partial class frmHistorialVentas : Form, IObservador
    {
        private readonly BLL_VENTA _bllVenta;
        private readonly BLL_IDIOMA Bll_Idioma;
        private readonly BLL_TRADUCCION Bll_Traduccion;
        private readonly BLL_EXPORTACION _bllExportacion;
        private readonly SessionManager sesion;

        private Venta _ventaSeleccionada;

        public frmHistorialVentas()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            _bllVenta = new BLL_VENTA();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            _bllExportacion = new BLL_EXPORTACION();
            CargarIdiomas();
            Actualizar(sesion.Idioma);
            ConfigurarEstilosDataGrids();
            CargarVentas();
        }

        private void ConfigurarEstilosDataGrids()
        {
            // Configurar estilos para gridVentas
            gridVentas.BackgroundColor = Color.FromArgb(45, 45, 45);
            gridVentas.DefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);
            gridVentas.DefaultCellStyle.ForeColor = Color.White;
            gridVentas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180);
            gridVentas.DefaultCellStyle.SelectionForeColor = Color.White;
            gridVentas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            gridVentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridVentas.EnableHeadersVisualStyles = false;
            gridVentas.BorderStyle = BorderStyle.None;
            gridVentas.GridColor = Color.FromArgb(80, 80, 80);

            // Configurar estilos para gridDetalles
            gridDetalles.BackgroundColor = Color.FromArgb(45, 45, 45);
            gridDetalles.DefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);
            gridDetalles.DefaultCellStyle.ForeColor = Color.White;
            gridDetalles.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180);
            gridDetalles.DefaultCellStyle.SelectionForeColor = Color.White;
            gridDetalles.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            gridDetalles.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridDetalles.EnableHeadersVisualStyles = false;
            gridDetalles.BorderStyle = BorderStyle.None;
            gridDetalles.GridColor = Color.FromArgb(80, 80, 80);
        }

        private void CargarVentas()
        {
            try
            {
                var ventas = _bllVenta.ObtenerTodos()
                    .Where(v => v.EstadoVentaEnum == EstadoVenta.Cobrada || v.EstadoVentaEnum == EstadoVenta.Entregada)
                    .OrderByDescending(v => v.Fecha)
                    .ToList();
                gridVentas.DataSource = ventas;
                FormatearGrillaVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ventas: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDetalles(int ventaId)
        {
            try
            {
                var detalles = _bllVenta.ObtenerDetallesPorVentaId(ventaId);
                gridDetalles.DataSource = detalles;
                FormatearGrillaDetalles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalles: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGrillaVentas()
        {
            if (gridVentas.Columns.Count == 0) return;

            // Configurar columnas visibles con nombres correctos
            if (gridVentas.Columns.Contains("Id"))
            {
                gridVentas.Columns["Id"].HeaderText = "Nro. Venta";
                gridVentas.Columns["Id"].Tag = "NroVenta_Column";
            }
            if (gridVentas.Columns.Contains("MontoTotal")) gridVentas.Columns["MontoTotal"].HeaderText = "Monto";
            if (gridVentas.Columns.Contains("TipoPagoEnum")) gridVentas.Columns["TipoPagoEnum"].HeaderText = "Pago";
            if (gridVentas.Columns.Contains("Fecha")) gridVentas.Columns["Fecha"].HeaderText = "Fecha";

            // Corregir nombre de estado
            if (gridVentas.Columns.Contains("EstadoVentaEnum")) gridVentas.Columns["EstadoVentaEnum"].HeaderText = "Estado";

            // Renombrar columnas existentes para cliente y vendedor
            if (gridVentas.Columns.Contains("ClienteId"))
                gridVentas.Columns["ClienteId"].HeaderText = "Nro. Cliente";

            if (gridVentas.Columns.Contains("UsuarioVendedorId"))
                gridVentas.Columns["UsuarioVendedorId"].HeaderText = "Cód. Vendedor";

            // Agregar columnas calculadas para nombres
            if (!gridVentas.Columns.Contains("Cliente"))
            {
                DataGridViewTextBoxColumn clienteCol = new DataGridViewTextBoxColumn
                {
                    Name = "Cliente",
                    HeaderText = "Cliente",
                    DataPropertyName = "NombreCliente",
                    ReadOnly = true
                };
                gridVentas.Columns.Add(clienteCol);
            }

            if (!gridVentas.Columns.Contains("Vendedor"))
            {
                DataGridViewTextBoxColumn vendedorCol = new DataGridViewTextBoxColumn
                {
                    Name = "Vendedor",
                    HeaderText = "Vendedor",
                    DataPropertyName = "NombreVendedor",
                    ReadOnly = true
                };
                gridVentas.Columns.Add(vendedorCol);
            }

            // Ocultar columnas no deseadas
            if (gridVentas.Columns.Contains("Comentario")) gridVentas.Columns["Comentario"].Visible = false;
            if (gridVentas.Columns.Contains("oDetalleVenta")) gridVentas.Columns["oDetalleVenta"].Visible = false;
            if (gridVentas.Columns.Contains("oCliente")) gridVentas.Columns["oCliente"].Visible = false;
            if (gridVentas.Columns.Contains("oVendedor")) gridVentas.Columns["oVendedor"].Visible = false;
            if (gridVentas.Columns.Contains("NombreCliente")) gridVentas.Columns["NombreCliente"].Visible = false;
            if (gridVentas.Columns.Contains("NombreVendedor")) gridVentas.Columns["NombreVendedor"].Visible = false;
            
            // OCULTAR DÍGITOS VERIFICADORES - NUNCA VISIBLES
            if (gridVentas.Columns.Contains("DigitoVerificador")) gridVentas.Columns["DigitoVerificador"].Visible = false;
            if (gridVentas.Columns.Contains("DV")) gridVentas.Columns["DV"].Visible = false;
        }

        private void FormatearGrillaDetalles()
        {
            if (gridDetalles.Columns.Count == 0) return;

            // Ocultar columnas no deseadas
            if (gridDetalles.Columns.Contains("Id")) gridDetalles.Columns["Id"].Visible = false;
            if (gridDetalles.Columns.Contains("VentaId")) gridDetalles.Columns["VentaId"].Visible = false;
            if (gridDetalles.Columns.Contains("oProducto")) gridDetalles.Columns["oProducto"].Visible = false;
            if (gridDetalles.Columns.Contains("oVenta")) gridDetalles.Columns["oVenta"].Visible = false;

            // Renombrar columnas correctamente
            if (gridDetalles.Columns.Contains("ProductoId")) gridDetalles.Columns["ProductoId"].HeaderText = "Cód. Producto";
            if (gridDetalles.Columns.Contains("Precio")) gridDetalles.Columns["Precio"].HeaderText = "Precio";
            if (gridDetalles.Columns.Contains("Cantidad")) gridDetalles.Columns["Cantidad"].HeaderText = "Cantidad";
            if (gridDetalles.Columns.Contains("SubTotal")) gridDetalles.Columns["SubTotal"].HeaderText = "Subtotal";
        }

        private void gridVentas_SelectionChanged(object sender, EventArgs e)
        {
            if (gridVentas.CurrentRow == null) return;
            _ventaSeleccionada = gridVentas.CurrentRow.DataBoundItem as Venta;
            if (_ventaSeleccionada != null)
            {
                CargarDetalles(_ventaSeleccionada.Id);
            }
        }

        private void gridDetalles_SelectionChanged(object sender, EventArgs e)
        {
            // Evento mantenido para compatibilidad, sin funcionalidad específica
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridVentas.DataSource == null || gridVentas.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Por ahora, la exportación a PDF usa Excel como formato intermedio
                // TODO: Implementar exportación directa a PDF con reporte RDLC
                MessageBox.Show("La exportación a PDF está en desarrollo. Por favor, use la opción 'Exportar a Excel' y convierta el archivo a PDF desde Excel si lo necesita.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Alternativamente, exportar a Excel con nombre PDF para referencia
                // Convertir DataGridViews a DataTables
                DataTable dtVentas = ConvertirDataGridViewADataTable(gridVentas);
                DataTable dtDetalles = ConvertirDataGridViewADataTable(gridDetalles);

                // Generar nombre de archivo
                string nombreArchivo = _bllExportacion.GenerarNombreArchivoUnico("HistorialVentas");

                // Exportar múltiples hojas a Excel (temporalmente como PDF)
                bool exportado = _bllExportacion.ExportarMultiplesDataTablesAExcel(nombreArchivo + "_ParaPDF",
                    (dtVentas, "Ventas", "Historial de Ventas"),
                    (dtDetalles, "Detalles", "Detalles de Ventas"));

                if (exportado)
                {
                    string rutaCompleta = System.IO.Path.Combine(BLL_CONFIGURACION.ObtenerDirectorioReporteria(), nombreArchivo + "_ParaPDF.xlsx");
                    MessageBox.Show($"Datos exportados a Excel (puede convertir a PDF desde Excel):\n{rutaCompleta}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult result = MessageBox.Show("¿Desea abrir el archivo Excel?",
                        "Abrir archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        _bllExportacion.AbrirArchivo(rutaCompleta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridVentas.DataSource == null || gridVentas.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Convertir DataGridViews a DataTables
                DataTable dtVentas = ConvertirDataGridViewADataTable(gridVentas);
                DataTable dtDetalles = ConvertirDataGridViewADataTable(gridDetalles);

                // Generar nombre de archivo
                string nombreArchivo = _bllExportacion.GenerarNombreArchivoUnico("HistorialVentas");

                // Exportar múltiples hojas a Excel
                bool exportado = _bllExportacion.ExportarMultiplesDataTablesAExcel(nombreArchivo,
                    (dtVentas, "Ventas", "Historial de Ventas"),
                    (dtDetalles, "Detalles", "Detalles de Ventas"));

                if (exportado)
                {
                    string rutaCompleta = System.IO.Path.Combine(BLL_CONFIGURACION.ObtenerDirectorioReporteria(), nombreArchivo + ".xlsx");
                    MessageBox.Show($"Historial exportado correctamente a:\n{rutaCompleta}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult result = MessageBox.Show("¿Desea abrir el archivo Excel?",
                        "Abrir archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        _bllExportacion.AbrirArchivo(rutaCompleta);
                    }
                }
                else
                {
                    MessageBox.Show("Error al exportar el historial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Convierte un DataGridView a DataTable para exportación
        /// </summary>
        private DataTable ConvertirDataGridViewADataTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // Agregar columnas visibles
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    dt.Columns.Add(column.HeaderText, typeof(string));
                }
            }

            // Agregar filas
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dataRow = dt.NewRow();
                    int columnIndex = 0;

                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        if (column.Visible)
                        {
                            dataRow[columnIndex] = row.Cells[column.Index].Value?.ToString() ?? "";
                            columnIndex++;
                        }
                    }

                    dt.Rows.Add(dataRow);
                }
            }

            return dt;
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
            catch { }
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
            if (cboxIdiomas.DataSource != null && cboxIdiomas.Items.Count > 0 && cboxIdiomas.ValueMember != string.Empty)
            {
                cboxIdiomas.SelectedValue = idioma.Id;
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

        #endregion Idiomas
    }
}