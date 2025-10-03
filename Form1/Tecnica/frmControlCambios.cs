using BEs;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using BLLs.Tecnica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix.Tecnica
{
    public partial class frmControlCambios : Form, IObservador
    {
        private BLL_USUARIO _bllUsuario;
        private BLL_PRODUCTO _bllProducto;
        private BLL_VENTA _bllVenta;
        private BLL_CONTROLCAMBIOS _bllControlCambios;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        private SessionManager sesion;

        private string _tipoEntidadActual = "Usuario";
        private object _entidadSeleccionada;
        private object _historialSeleccionado;

        public frmControlCambios()
        {
            InitializeComponent();
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            try
            {
                _bllUsuario = new BLL_USUARIO();
                _bllProducto = new BLL_PRODUCTO();
                _bllVenta = new BLL_VENTA();
                _bllControlCambios = new BLL_CONTROLCAMBIOS();

                sesion = SessionManager.GetInstance();
                Bll_Idioma = new BLL_IDIOMA();
                Bll_Traduccion = new BLL_TRADUCCION();

                // NO conectar CellFormatting - causa problemas con valores incompatibles
                // dataGridHistorial.CellFormatting += dataGridHistorial_CellFormatting;

                // Configurar idiomas y permisos primero
                sesion.RegistrarObservador(this);
                IIdioma oIdioma = sesion.Idioma;
                CargarIdiomas();
                BuscarControles(this.Controls);
                Actualizar(oIdioma);

                // Luego cargar datos
                CargarTiposEntidad();
                // ActualizarEntidades se llama automáticamente desde CargarTiposEntidad
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar el formulario: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Configuración de Entidades

        private void CargarTiposEntidad()
        {
            try
            {
                var tiposEntidad = new List<object>
                {
                    new { Valor = "Usuario", Texto = "Usuarios" },
                    new { Valor = "Producto", Texto = "Productos" },
                    new { Valor = "Venta", Texto = "Ventas" }
                };

                comboTipoEntidad.DataSource = tiposEntidad;
                comboTipoEntidad.DisplayMember = "Texto";
                comboTipoEntidad.ValueMember = "Valor";

                // PRESELECIÓN AUTOMÁTICA Y CARGA INMEDIATA
                comboTipoEntidad.SelectedIndex = 0;

                // Forzar actualización inmediata después de configurar el combo
                if (comboTipoEntidad.SelectedValue != null)
                {
                    _tipoEntidadActual = comboTipoEntidad.SelectedValue.ToString();
                    ActualizarEntidades();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de entidad: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboTipoEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboTipoEntidad.SelectedValue != null)
                {
                    // Obtener el valor correctamente
                    string tipoEntidad = comboTipoEntidad.SelectedValue.ToString();

                    // Validar que sea un tipo conocido
                    if (tipoEntidad == "Usuario" || tipoEntidad == "Producto" || tipoEntidad == "Venta")
                    {
                        _tipoEntidadActual = tipoEntidad;
                        ActualizarEntidades();
                        LimpiarHistorial();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar tipo de entidad: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarEntidades()
        {
            try
            {
                dataGridEntidades.DataSource = null;
                _entidadSeleccionada = null;

                switch (_tipoEntidadActual)
                {
                    case "Usuario":
                        try
                        {
                            var usuarios = _bllUsuario.ListarParaGestion(); // Usar método sin verificación DV
                            dataGridEntidades.DataSource = usuarios;
                            ConfigurarColumnas_Usuario();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al cargar usuarios: {ex.Message}", ConstantesUI.Titulos.Error);
                            dataGridEntidades.DataSource = null;
                        }
                        break;

                    case "Producto":
                        try
                        {
                            var productos = _bllProducto.ObtenerTodos();
                            dataGridEntidades.DataSource = productos;
                            ConfigurarColumnas_Producto();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al cargar productos: {ex.Message}", ConstantesUI.Titulos.Error);
                            dataGridEntidades.DataSource = null;
                        }
                        break;

                    case "Venta":
                        try
                        {
                            var ventas = _bllVenta.ObtenerTodos();
                            dataGridEntidades.DataSource = ventas;
                            ConfigurarColumnas_Venta();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al cargar ventas: {ex.Message}", ConstantesUI.Titulos.Error);
                            dataGridEntidades.DataSource = null;
                        }
                        break;

                    default:
                        MessageBox.Show($"Tipo de entidad no reconocido: {_tipoEntidadActual}", ConstantesUI.Titulos.Error);
                        dataGridEntidades.DataSource = null;
                        break;
                }

                // Aplicar estilo a los DataGrids
                AplicarEstiloDataGrid(dataGridEntidades);
                AplicarEstiloDataGrid(dataGridHistorial);

                lblEntidadSeleccionada.Text = $"Entidades: {_tipoEntidadActual}";

                // Seleccionar automáticamente el primer registro
                if (dataGridEntidades.Rows.Count > 0)
                {
                    dataGridEntidades.CurrentCell = dataGridEntidades.Rows[0].Cells[0];
                    dataGridEntidades.Rows[0].Selected = true;
                    dataGridEntidades_SelectionChanged(null, null); // Trigger manual
                }
                else
                {
                    LimpiarHistorial();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar entidades: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarHistorial();
            }
        }

        #endregion Configuración de Entidades

        #region Estilos DataGrid

        private void AplicarEstiloDataGrid(DataGridView dataGrid)
        {
            // Estilo principal
            dataGrid.BackgroundColor = System.Drawing.Color.FromArgb(32, 30, 45);
            dataGrid.ForeColor = System.Drawing.Color.White;
            dataGrid.GridColor = System.Drawing.Color.FromArgb(50, 50, 50);
            dataGrid.BorderStyle = BorderStyle.None;

            // Cabeceras
            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(11, 7, 17);
            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGrid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGrid.ColumnHeadersHeight = 35;

            // Filas
            dataGrid.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(32, 30, 45);
            dataGrid.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGrid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(70, 70, 70);
            dataGrid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGrid.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);

            // Filas alternadas
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(28, 26, 40);
            dataGrid.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.White;

            // Configuración general
            dataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGrid.RowHeadersVisible = false;
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.MultiSelect = false;
            dataGrid.ReadOnly = true;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.RowTemplate.Height = 25;
        }

        #endregion Estilos DataGrid

        #region Configuración de Columnas

        private void ConfigurarColumnas_Usuario()
        {
            if (dataGridEntidades.Columns.Count > 0)
            {
                dataGridEntidades.Columns["Email"].HeaderText = "Email";

                // OCULTAR INFORMACIÓN SENSIBLE Y TÉCNICA
                dataGridEntidades.Columns["Contraseña"].Visible = false;
                dataGridEntidades.Columns["DV"].Visible = false;
                if (dataGridEntidades.Columns.Contains("DigitoVerificador"))
                    dataGridEntidades.Columns["DigitoVerificador"].Visible = false;
            }
        }

        private void ConfigurarColumnas_Producto()
        {
            if (dataGridEntidades.Columns.Count > 0)
            {
                dataGridEntidades.Columns["Id"].HeaderText = "ID";
                dataGridEntidades.Columns["Codigo"].HeaderText = "Código";
                dataGridEntidades.Columns["Nombre"].HeaderText = "Nombre";
                dataGridEntidades.Columns["PrecioCompra"].HeaderText = "Precio Compra";
                if (dataGridEntidades.Columns.Contains("PrecioVenta"))
                    dataGridEntidades.Columns["PrecioVenta"].HeaderText = "Precio Venta";
                if (dataGridEntidades.Columns.Contains("Estado"))
                    dataGridEntidades.Columns["Estado"].HeaderText = "Activo";

                // OCULTAR DÍGITOS VERIFICADORES - NUNCA VISIBLES
                if (dataGridEntidades.Columns.Contains("DigitoVerificador"))
                    dataGridEntidades.Columns["DigitoVerificador"].Visible = false;
                if (dataGridEntidades.Columns.Contains("DV"))
                    dataGridEntidades.Columns["DV"].Visible = false;

                // Ocultar propiedades complejas
                if (dataGridEntidades.Columns.Contains("Proveedores"))
                    dataGridEntidades.Columns["Proveedores"].Visible = false;
                if (dataGridEntidades.Columns.Contains("StockDisponible"))
                    dataGridEntidades.Columns["StockDisponible"].Visible = false;
            }
        }

        private void ConfigurarColumnas_Venta()
        {
            if (dataGridEntidades.Columns.Count > 0)
            {
                dataGridEntidades.Columns["Id"].HeaderText = "ID Venta";
                dataGridEntidades.Columns["MontoTotal"].HeaderText = "Monto Total";
                dataGridEntidades.Columns["Fecha"].HeaderText = "Fecha";
                if (dataGridEntidades.Columns.Contains("TipoPagoEnum"))
                    dataGridEntidades.Columns["TipoPagoEnum"].HeaderText = "Tipo Pago";
                if (dataGridEntidades.Columns.Contains("EstadoVentaEnum"))
                    dataGridEntidades.Columns["EstadoVentaEnum"].HeaderText = "Estado";
                if (dataGridEntidades.Columns.Contains("ClienteId"))
                    dataGridEntidades.Columns["ClienteId"].HeaderText = "Cliente ID";

                // OCULTAR DÍGITOS VERIFICADORES - NUNCA VISIBLES
                if (dataGridEntidades.Columns.Contains("DigitoVerificador"))
                    dataGridEntidades.Columns["DigitoVerificador"].Visible = false;
                if (dataGridEntidades.Columns.Contains("DV"))
                    dataGridEntidades.Columns["DV"].Visible = false;

                // Ocultar propiedades complejas
                if (dataGridEntidades.Columns.Contains("oCliente"))
                    dataGridEntidades.Columns["oCliente"].Visible = false;
                if (dataGridEntidades.Columns.Contains("oVendedor"))
                    dataGridEntidades.Columns["oVendedor"].Visible = false;
                if (dataGridEntidades.Columns.Contains("oDetalleVenta"))
                    dataGridEntidades.Columns["oDetalleVenta"].Visible = false;
                if (dataGridEntidades.Columns.Contains("NombreCliente"))
                    dataGridEntidades.Columns["NombreCliente"].Visible = false;
                if (dataGridEntidades.Columns.Contains("NombreVendedor"))
                    dataGridEntidades.Columns["NombreVendedor"].Visible = false;
            }
        }

        #endregion Configuración de Columnas

        #region Eventos de Selección

        private void dataGridEntidades_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridEntidades.CurrentRow?.DataBoundItem != null)
            {
                _entidadSeleccionada = dataGridEntidades.CurrentRow.DataBoundItem;
                CargarHistorialEntidad();
            }
            else
            {
                LimpiarHistorial();
            }
        }

        private void CargarHistorialEntidad()
        {
            try
            {
                if (_entidadSeleccionada == null) return;

                int entidadId = 0;
                string tipoEntidad = _tipoEntidadActual;

                // Obtener ID usando reflexión para evitar problemas de cast
                var idProperty = _entidadSeleccionada.GetType().GetProperty("Id");
                if (idProperty != null)
                {
                    entidadId = (int)idProperty.GetValue(_entidadSeleccionada);
                }
                else
                {
                    throw new InvalidOperationException($"No se pudo obtener el ID de la entidad {_tipoEntidadActual}");
                }

                // Cargar historial específico
                var historial = _bllControlCambios.ObtenerHistorialEntidad(tipoEntidad, entidadId);

                // Formatear datos ANTES de asignar al DataGridView
                FormatearDatosHistorial(historial, tipoEntidad);

                dataGridHistorial.DataSource = historial;

                ConfigurarColumnasHistorial();
                AplicarEstiloDataGrid(dataGridHistorial);
                lblHistorialInfo.Text = $"Historial de {tipoEntidad} ID: {entidadId} ({historial.Rows.Count} registros)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar historial: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarHistorial();
            }
        }

        /// <summary>
        /// Formatea los datos del historial ANTES de mostrarlos en el DataGridView
        /// Esto evita problemas con el evento CellFormatting
        /// </summary>
        private void FormatearDatosHistorial(System.Data.DataTable historial, string tipoEntidad)
        {
            try
            {
                if (historial == null || historial.Rows.Count == 0)
                    return;

                // Agregar columna de texto formateado si no existe
                if (tipoEntidad == "Venta" && historial.Columns.Contains("EstadoVenta"))
                {
                    // Agregar columna de estado formateado si no existe
                    if (!historial.Columns.Contains("EstadoTexto"))
                    {
                        historial.Columns.Add("EstadoTexto", typeof(string));
                    }

                    foreach (System.Data.DataRow row in historial.Rows)
                    {
                        if (row["EstadoVenta"] != DBNull.Value)
                        {
                            int estado = Convert.ToInt32(row["EstadoVenta"]);
                            string estadoTexto;

                            switch (estado)
                            {
                                case 0:
                                    estadoTexto = "En Proceso";
                                    break;
                                case 1:
                                    estadoTexto = "Cobrada";
                                    break;
                                case 2:
                                    estadoTexto = "Entregada";
                                    break;
                                case 3:
                                    estadoTexto = "Cancelada";
                                    break;
                                default:
                                    estadoTexto = $"Desconocido ({estado})";
                                    break;
                            }

                            row["EstadoTexto"] = estadoTexto;
                        }
                        else
                        {
                            row["EstadoTexto"] = "-";
                        }
                    }


                    // Ocultar la columna numérica y mostrar la de texto
                    historial.Columns["EstadoVenta"].ColumnMapping = System.Data.MappingType.Hidden;
                }
                else if (tipoEntidad == "Producto" && historial.Columns.Contains("Estado"))
                {
                    if (!historial.Columns.Contains("EstadoTexto"))
                    {
                        historial.Columns.Add("EstadoTexto", typeof(string));
                    }

                    foreach (System.Data.DataRow row in historial.Rows)
                    {
                        if (row["Estado"] != DBNull.Value)
                        {
                            bool estado = Convert.ToBoolean(row["Estado"]);
                            row["EstadoTexto"] = estado ? "Activo" : "Inactivo";
                        }
                        else
                        {
                            row["EstadoTexto"] = "-";
                        }
                    }

                    historial.Columns["Estado"].ColumnMapping = System.Data.MappingType.Hidden;
                }
                else if (tipoEntidad == "Usuario" && historial.Columns.Contains("Activo"))
                {
                    if (!historial.Columns.Contains("ActivoTexto"))
                    {
                        historial.Columns.Add("ActivoTexto", typeof(string));
                    }

                    foreach (System.Data.DataRow row in historial.Rows)
                    {
                        if (row["Activo"] != DBNull.Value)
                        {
                            bool activo = Convert.ToBoolean(row["Activo"]);
                            row["ActivoTexto"] = activo ? "Activo" : "Inactivo";
                        }
                        else
                        {
                            row["ActivoTexto"] = "-";
                        }
                    }

                    historial.Columns["Activo"].ColumnMapping = System.Data.MappingType.Hidden;
                }
            }
            catch (Exception ex)
            {
                // Si falla el formateo, no es crítico - los datos originales se mostrarán
                System.Diagnostics.Debug.WriteLine($"Error al formatear datos del historial: {ex.Message}");
            }
        }

        private void ConfigurarColumnasHistorial()
        {
            if (dataGridHistorial.Columns.Count > 0)
            {
                // Columnas comunes de historial
                if (dataGridHistorial.Columns.Contains("Id"))
                    dataGridHistorial.Columns["Id"].HeaderText = "Historial ID";
                if (dataGridHistorial.Columns.Contains("FechaModificacion"))
                    dataGridHistorial.Columns["FechaModificacion"].HeaderText = "Fecha Modificación";
                if (dataGridHistorial.Columns.Contains("TipoOperacion"))
                    dataGridHistorial.Columns["TipoOperacion"].HeaderText = "Operación";
                if (dataGridHistorial.Columns.Contains("UsuarioModificacion"))
                    dataGridHistorial.Columns["UsuarioModificacion"].HeaderText = "Usuario";

                // OCULTAR DÍGITOS VERIFICADORES EN HISTORIAL - NUNCA VISIBLES
                if (dataGridHistorial.Columns.Contains("DigitoVerificador"))
                    dataGridHistorial.Columns["DigitoVerificador"].Visible = false;
                if (dataGridHistorial.Columns.Contains("DV"))
                    dataGridHistorial.Columns["DV"].Visible = false;

                // Específicos por entidad
                switch (_tipoEntidadActual)
                {
                    case "Usuario":
                        if (dataGridHistorial.Columns.Contains("Email"))
                            dataGridHistorial.Columns["Email"].HeaderText = "Email";
                        if (dataGridHistorial.Columns.Contains("Fecha"))
                            dataGridHistorial.Columns["Fecha"].HeaderText = "Fecha Registro";
                        if (dataGridHistorial.Columns.Contains("Activo"))
                            dataGridHistorial.Columns["Activo"].HeaderText = "Activo";
                        // DV ya oculto arriba - no duplicar
                        break;

                    case "Producto":
                        if (dataGridHistorial.Columns.Contains("ProductoId"))
                            dataGridHistorial.Columns["ProductoId"].HeaderText = "Producto ID";
                        if (dataGridHistorial.Columns.Contains("Codigo"))
                            dataGridHistorial.Columns["Codigo"].HeaderText = "Código";
                        if (dataGridHistorial.Columns.Contains("Nombre"))
                            dataGridHistorial.Columns["Nombre"].HeaderText = "Nombre";
                        if (dataGridHistorial.Columns.Contains("Estado"))
                            dataGridHistorial.Columns["Estado"].HeaderText = "Estado";
                        break;

                    case "Venta":
                        if (dataGridHistorial.Columns.Contains("VentaId"))
                            dataGridHistorial.Columns["VentaId"].HeaderText = "Venta ID";
                        if (dataGridHistorial.Columns.Contains("MontoTotal"))
                            dataGridHistorial.Columns["MontoTotal"].HeaderText = "Monto";

                        // Ocultar columna numérica y mostrar la de texto
                        if (dataGridHistorial.Columns.Contains("EstadoVenta"))
                            dataGridHistorial.Columns["EstadoVenta"].Visible = false;

                        if (dataGridHistorial.Columns.Contains("EstadoTexto"))
                        {
                            dataGridHistorial.Columns["EstadoTexto"].HeaderText = "Estado";
                            dataGridHistorial.Columns["EstadoTexto"].DisplayIndex = 3; // Posición después de Monto
                        }
                        break;
                }

                // Aplicar formato de fecha a la columna FechaModificacion si existe
                if (dataGridHistorial.Columns.Contains("FechaModificacion") &&
                    dataGridHistorial.Columns["FechaModificacion"] is DataGridViewTextBoxColumn)
                {
                    dataGridHistorial.Columns["FechaModificacion"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                }
            }
        }

        private void dataGridHistorial_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridHistorial.CurrentRow?.DataBoundItem != null)
            {
                _historialSeleccionado = dataGridHistorial.CurrentRow.DataBoundItem;
                btnRestaurar.Enabled = true;
            }
            else
            {
                _historialSeleccionado = null;
                btnRestaurar.Enabled = false;
            }
        }

        // MÉTODO ELIMINADO: CellFormatting causaba FormatException
        // Ahora usamos FormatearDatosHistorial() que formatea los datos ANTES de mostrarlos

        private void LimpiarHistorial()
        {
            dataGridHistorial.DataSource = null;
            _historialSeleccionado = null;
            btnRestaurar.Enabled = false;
            lblHistorialInfo.Text = "Seleccione una entidad para ver su historial";
        }

        #endregion Eventos de Selección

        #region Acciones

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarEntidades();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_historialSeleccionado == null)
                {
                    MessageBox.Show(ConstantesUI.Plantillas.Seleccione("un registro del historial para restaurar"));
                    return;
                }

                // Confirmar restauración
                var resultado = MessageBox.Show(
                    $"¿Está seguro de que desea restaurar esta versión de {_tipoEntidadActual}?\n\nEsta acción sobrescribirá los datos actuales.",
                    ConstantesUI.Titulos.Confirmacion,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    int historialId = ObtenerIdHistorial(_historialSeleccionado);
                    bool exito = _bllControlCambios.RestaurarDesdeHistorial(_tipoEntidadActual, historialId);

                    if (exito)
                    {
                        MessageBox.Show($"Se restauró el {_tipoEntidadActual} exitosamente", ConstantesUI.Titulos.Informacion);
                        ActualizarEntidades();
                        CargarHistorialEntidad(); // Recargar historial
                    }
                    else
                    {
                        MessageBox.Show("Error al restaurar el registro", ConstantesUI.Titulos.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al restaurar: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ObtenerIdHistorial(object historialItem)
        {
            try
            {
                // El historialItem es un DataRowView cuando viene de un DataTable
                if (historialItem is System.Data.DataRowView rowView)
                {
                    if (rowView.Row.Table.Columns.Contains("Id"))
                    {
                        return Convert.ToInt32(rowView["Id"]);
                    }
                }
                // Si es un objeto directo, usar reflexión
                else
                {
                    var idProperty = historialItem.GetType().GetProperty("Id");
                    if (idProperty != null)
                    {
                        return (int)idProperty.GetValue(historialItem);
                    }
                }

                throw new InvalidOperationException("No se pudo obtener el ID del historial. El objeto no contiene la propiedad 'Id'.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al obtener ID del historial: {ex.Message}", ex);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            sesion.DesregistrarObservador(this);
            this.Close();
        }

        #endregion Acciones



        #region Idiomas y Permisos

        private List<Control> ListaControles = new List<Control>();

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
                MessageBox.Show($"Error al cargar los idiomas: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error al actualizar los textos de los controles: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Idiomas y Permisos
    }
}