using BEs;
using BEs.Clases;
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
    public partial class frmHistorialDevoluciones : Form, IObservador
    {
        private readonly BLL_DEVOLUCION _bllDevolucion;
        private readonly BLL_CLIENTE _bllCliente;
        private readonly BLL_VENTA _bllVenta;
        private readonly BLL_EXPORTACION _bllExportacion;
        private readonly SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        private List<Control> ListaControles = new List<Control>();

        public frmHistorialDevoluciones()
        {
            InitializeComponent();
            _bllDevolucion = new BLL_DEVOLUCION();
            _bllCliente = new BLL_CLIENTE();
            _bllVenta = new BLL_VENTA();
            _bllExportacion = new BLL_EXPORTACION();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            sesion.RegistrarObservador(this);
        }

        private void frmHistorialDevoluciones_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarGrilla();
                CargarClientes();
                CargarVentas();
                CargarEstados();
                Actualizar(sesion.Idioma);
                if (sesion.Permisos != null && sesion.Permisos.Count > 0)
                {
                    BuscarControles(this.Controls);
                    Buscar(sesion.Permisos[0]);
                }
                AplicarPermisos();
                CargarHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar historial: {ex.Message}", 
                    ConstantesUI.Titulos.Error, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrilla()
        {
            dataGridViewHistorial.AutoGenerateColumns = false;
            dataGridViewHistorial.AllowUserToAddRows = false;
            dataGridViewHistorial.AllowUserToDeleteRows = false;
            dataGridViewHistorial.ReadOnly = true;
            dataGridViewHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewHistorial.MultiSelect = false;
            dataGridViewHistorial.RowHeadersVisible = false;
            dataGridViewHistorial.BackgroundColor = Color.White;
            dataGridViewHistorial.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configurar columnas
            dataGridViewHistorial.Columns.Clear();

            dataGridViewHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "Nro Devolución",
                DataPropertyName = "Id",
                Width = 100,
                Tag = "grid_NroDevolucion_Column"
            });

            dataGridViewHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFechaSolicitud",
                HeaderText = "Fecha Solicitud",
                DataPropertyName = "FechaSolicitud",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" },
                Width = 150,
                Tag = "grid_FechaSolicitud_Column"
            });

            dataGridViewHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNumeroVenta",
                HeaderText = "Nro Venta",
                DataPropertyName = "NumeroVenta",
                Width = 100,
                Tag = "grid_NroVenta_Column"
            });

            dataGridViewHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCliente",
                HeaderText = "Cliente",
                DataPropertyName = "NombreCliente",
                Width = 200,
                Tag = "grid_Cliente_Column"
            });

            dataGridViewHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Estado",
                DataPropertyName = "EstadoTexto",
                Width = 120,
                Tag = "grid_Estado_Column"
            });

            dataGridViewHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMotivo",
                HeaderText = "Motivo",
                DataPropertyName = "Motivo",
                Width = 250,
                Tag = "grid_Motivo_Column"
            });

            dataGridViewHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFechaDecision",
                HeaderText = "Fecha Decisión",
                DataPropertyName = "FechaDecision",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" },
                Width = 150,
                Tag = "grid_FechaDecision_Column"
            });

            dataGridViewHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEmailGerente",
                HeaderText = "Gerente",
                DataPropertyName = "EmailGerente",
                Width = 150,
                Tag = "grid_Gerente_Column"
            });

            dataGridViewHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFechaProcesamiento",
                HeaderText = "Fecha Procesamiento",
                DataPropertyName = "FechaProcesamiento",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" },
                Width = 150,
                Tag = "grid_FechaProcesamiento_Column"
            });

            dataGridViewHistorial.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEmailDeposito",
                HeaderText = "Depósito",
                DataPropertyName = "EmailDeposito",
                Width = 150,
                Tag = "grid_Deposito_Column"
            });

            // Aplicar estilos del sistema
            dataGridViewHistorial.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(32, 30, 45);
            dataGridViewHistorial.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewHistorial.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewHistorial.EnableHeadersVisualStyles = false;

            dataGridViewHistorial.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
            dataGridViewHistorial.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180);
            dataGridViewHistorial.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void CargarClientes()
        {
            try
            {
                var clientes = _bllCliente.ObtenerTodos();
                cmbCliente.DataSource = null;
                cmbCliente.Items.Clear();
                cmbCliente.Items.Add(new ComboBoxItem { Text = "-- Todos --", Value = null });
                
                foreach (var cliente in clientes)
                {
                    cmbCliente.Items.Add(new ComboBoxItem 
                    { 
                        Text = $"{cliente.Nombre} {cliente.Apellido}", 
                        Value = cliente.Id 
                    });
                }
                
                cmbCliente.DisplayMember = "Text";
                cmbCliente.ValueMember = "Value";
                cmbCliente.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", 
                    ConstantesUI.Titulos.Error, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void CargarVentas()
        {
            try
            {
                var ventas = _bllVenta.ObtenerTodos();
                cmbVenta.DataSource = null;
                cmbVenta.Items.Clear();
                cmbVenta.Items.Add(new ComboBoxItem { Text = "-- Todas --", Value = null });
                
                foreach (var venta in ventas)
                {
                    cmbVenta.Items.Add(new ComboBoxItem 
                    { 
                        Text = $"Venta #{venta.Id}", 
                        Value = venta.Id 
                    });
                }
                
                cmbVenta.DisplayMember = "Text";
                cmbVenta.ValueMember = "Value";
                cmbVenta.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ventas: {ex.Message}", 
                    ConstantesUI.Titulos.Error, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void CargarEstados()
        {
            cmbEstado.DataSource = null;
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add(new ComboBoxItem { Text = "-- Todos --", Value = null });
            cmbEstado.Items.Add(new ComboBoxItem { Text = "Iniciada", Value = EstadoDevolucion.Iniciada });
            cmbEstado.Items.Add(new ComboBoxItem { Text = "En Evaluación", Value = EstadoDevolucion.EnEvaluacion });
            cmbEstado.Items.Add(new ComboBoxItem { Text = "Autorizada", Value = EstadoDevolucion.Autorizada });
            cmbEstado.Items.Add(new ComboBoxItem { Text = "Rechazada", Value = EstadoDevolucion.Rechazada });
            cmbEstado.Items.Add(new ComboBoxItem { Text = "Procesada", Value = EstadoDevolucion.Procesada });
            
            cmbEstado.DisplayMember = "Text";
            cmbEstado.ValueMember = "Value";
            cmbEstado.SelectedIndex = 0;
        }

        private void CargarHistorial()
        {
            try
            {
                int? clienteId = (cmbCliente.SelectedItem as ComboBoxItem)?.Value as int?;
                int? ventaId = (cmbVenta.SelectedItem as ComboBoxItem)?.Value as int?;
                EstadoDevolucion? estado = (cmbEstado.SelectedItem as ComboBoxItem)?.Value as EstadoDevolucion?;

                var devoluciones = _bllDevolucion.Listar(clienteId, ventaId, estado);

                // Filtrar por rango de fechas si está definido
                if (dtpFechaDesde.Checked || dtpFechaHasta.Checked)
                {
                    devoluciones = devoluciones.Where(d =>
                    {
                        if (dtpFechaDesde.Checked && d.FechaSolicitud < dtpFechaDesde.Value.Date)
                            return false;
                        if (dtpFechaHasta.Checked && d.FechaSolicitud > dtpFechaHasta.Value.Date.AddDays(1).AddSeconds(-1))
                            return false;
                        return true;
                    }).ToList();
                }

                // Preparar datos para la grilla
                var viewData = devoluciones.Select(d => new
                {
                    d.Id,
                    d.FechaSolicitud,
                    NumeroVenta = d.oVenta != null ? $"Venta #{d.oVenta.Id}" : $"Venta #{d.VentaId}",
                    NombreCliente = d.oVenta?.oCliente != null 
                        ? $"{d.oVenta.oCliente.Nombre} {d.oVenta.oCliente.Apellido}" 
                        : "N/A",
                    EstadoTexto = TraducirEstado(d.Estado),
                    d.Motivo,
                    d.FechaDecision,
                    EmailGerente = d.oUsuarioGerente?.Email ?? "N/A",
                    d.FechaProcesamiento,
                    EmailDeposito = d.oUsuarioDeposito?.Email ?? "N/A",
                    DevolucionObj = d // Mantener referencia para acciones
                }).ToList();

                dataGridViewHistorial.DataSource = viewData;
                lblTotalRegistros.Text = $"Total: {viewData.Count} registro(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar historial: {ex.Message}", 
                    ConstantesUI.Titulos.Error, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private string TraducirEstado(EstadoDevolucion estado)
        {
            switch (estado)
            {
                case EstadoDevolucion.Iniciada:
                    return "Iniciada";
                case EstadoDevolucion.EnEvaluacion:
                    return "En Evaluación";
                case EstadoDevolucion.Autorizada:
                    return "Autorizada";
                case EstadoDevolucion.Rechazada:
                    return "Rechazada";
                case EstadoDevolucion.Procesada:
                    return "Procesada";
                default:
                    return estado.ToString();
            }
        }

        private void AplicarPermisos()
        {
            try
            {
                var permisos = sesion.Permisos;
                if (permisos == null || permisos.Count == 0) return;

                // Buscar permiso de consulta de historial
                bool puedeConsultar = BuscarPermiso(permisos[0], "FormHistorialDevoluciones");
                bool puedeExportar = BuscarPermiso(permisos[0], "Button_ExportarHistorialDev_GesDev");

                btnExportarPDF.Visible = puedeExportar;
                btnExportarExcel.Visible = puedeExportar;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al aplicar permisos: {ex.Message}", 
                    ConstantesUI.Titulos.Error, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private bool BuscarPermiso(Componente componente, string nombre)
        {
            if (componente.Nombre == nombre)
                return true;

            GrupoPermisos grupo = componente as GrupoPermisos;
            if (grupo != null)
            {
                foreach (var permiso in grupo.Permisos)
                {
                    if (BuscarPermiso(permiso, nombre))
                        return true;
                }
            }

            return false;
        }

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

        public void BuscarControles(System.Collections.ICollection controles)
        {
            foreach (Control control in controles)
            {
                ListaControles.Add(control);
                if (control.Controls.Count > 0) BuscarControles(control.Controls);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbCliente.SelectedIndex = 0;
            cmbVenta.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            dtpFechaDesde.Checked = false;
            dtpFechaHasta.Checked = false;
            CargarHistorial();
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewHistorial.DataSource == null || dataGridViewHistorial.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", 
                        ConstantesUI.Titulos.Informacion, 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    return;
                }

                // Por ahora exportamos a Excel (la implementación completa de PDF con RDLC está fuera de alcance)
                MessageBox.Show("La exportación a PDF completo requiere configuración RDLC.\n\n" +
                              "Se exportará a Excel como alternativa.",
                              ConstantesUI.Titulos.Informacion,
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);

                btnExportarExcel_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", 
                    ConstantesUI.Titulos.Error, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewHistorial.DataSource == null || dataGridViewHistorial.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", 
                        ConstantesUI.Titulos.Informacion, 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    return;
                }

                DataTable dt = ConvertirDataGridViewADataTable(dataGridViewHistorial);
                string nombreArchivo = _bllExportacion.GenerarNombreArchivoUnico("HistorialDevoluciones");

                bool exportado = _bllExportacion.ExportarDataTableAExcel(dt, nombreArchivo, "Historial de Devoluciones");

                if (exportado)
                {
                    string rutaCompleta = System.IO.Path.Combine(BLL_CONFIGURACION.ObtenerDirectorioReporteria(), nombreArchivo + ".xlsx");
                    MessageBox.Show($"Historial exportado correctamente a:\n{rutaCompleta}",
                        ConstantesUI.Titulos.Exito, 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);

                    DialogResult result = MessageBox.Show("¿Desea abrir el archivo Excel?",
                        "Abrir archivo", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        _bllExportacion.AbrirArchivo(rutaCompleta);
                    }
                }
                else
                {
                    MessageBox.Show("Error al exportar a Excel.", 
                        ConstantesUI.Titulos.Error, 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}", 
                    ConstantesUI.Titulos.Error, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private DataTable ConvertirDataGridViewADataTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // Agregar columnas (excepto columnas ocultas y DevolucionObj)
            foreach (DataGridViewColumn columna in dgv.Columns)
            {
                if (columna.Visible && columna.Name != "DevolucionObj")
                {
                    dt.Columns.Add(columna.HeaderText);
                }
            }

            // Agregar filas
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (!fila.IsNewRow)
                {
                    DataRow dr = dt.NewRow();
                    int colIndex = 0;
                    foreach (DataGridViewColumn columna in dgv.Columns)
                    {
                        if (columna.Visible && columna.Name != "DevolucionObj")
                        {
                            dr[colIndex] = fila.Cells[columna.Name].Value ?? DBNull.Value;
                            colIndex++;
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        private void dataGridViewHistorial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var devolucionId = Convert.ToInt32(dataGridViewHistorial.Rows[e.RowIndex].Cells["colId"].Value);
                
                // Abrir formulario de detalle (ajustar según tu implementación real)
                // Si frmDevolucionDetalle existe y tiene propiedades DevolucionId y Modo
                // frmDevolucionDetalle frmDetalle = new frmDevolucionDetalle();
                // frmDetalle.DevolucionId = devolucionId;
                // frmDetalle.ShowDialog();
                
                MessageBox.Show($"Ver detalle de devolución #{devolucionId}\n\nImplementar navegación al formulario de detalle.", 
                    ConstantesUI.Titulos.Informacion, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                // Refrescar si se hicieron cambios
                CargarHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir devolución: {ex.Message}", 
                    ConstantesUI.Titulos.Error, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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

            // Traducir columnas del grid
            foreach (DataGridViewColumn col in dataGridViewHistorial.Columns)
            {
                if (col.Tag != null)
                {
                    string traduccion = Bll_Traduccion.BuscarTraduccion(col.Tag.ToString(), idioma.Id);
                    if (!string.IsNullOrEmpty(traduccion))
                    {
                        col.HeaderText = traduccion;
                    }
                }
            }
        }

        // Clase helper para ComboBox
        private class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
        }
    }
}


