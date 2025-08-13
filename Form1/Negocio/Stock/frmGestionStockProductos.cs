using BEs;
using BEs.Clases;
using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Inventario;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using BLLs.Tecnica;
using BLLs.Tecnica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix
{
    public partial class frmGestionStockProductos : Form, IObservador
    {
        private BLL_PRODUCTO _bllProducto;
        private BLL_PROVEEDOR _bllProveedor;
        private BLL_EXPORTACION _bllExportacion;
        private Producto _productoSeleccionado;
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        public frmGestionStockProductos()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            _bllProducto = new BLL_PRODUCTO();
            _bllProveedor = new BLL_PROVEEDOR();
            _bllExportacion = new BLL_EXPORTACION();
            CargarDatos();
            CargarComboBuscar();
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

        private void buttonAgregarProductoProveedorSelec_Click(object sender, System.EventArgs e)
        {
            panelDatosProducto.Visible = true;
            txtCodigo.ReadOnly = false;
            lblSeleccionado.Visible = false;
            lblSeleccionadoEspecifico.Visible = false;
            LimpiarControles();
            _productoSeleccionado = null;
            btnAceptar.Tag = "Agregar";
        }

        private void buttonActualizarProducto_Click(object sender, System.EventArgs e)
        {
            if (_productoSeleccionado == null)
            {
                MessageBox.Show(ConstantesUI.Plantillas.Seleccione("un producto para actualizar"));
                return;
            }

            if (!_productoSeleccionado.Estado)
            {
                MessageBox.Show(ConstantesUI.Plantillas.NoPuedeActualizarInactivo("producto"));
                return;
            }

            panelDatosProducto.Visible = true;
            txtCodigo.ReadOnly = true;
            lblSeleccionado.Visible = true;
            lblSeleccionadoEspecifico.Visible = true;
            lblSeleccionadoEspecifico.Text = _productoSeleccionado.Nombre;

            MapearProductoAControles(_productoSeleccionado);
            btnAceptar.Tag = "Actualizar";
        }

        private void buttonEliminarProducto_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (_productoSeleccionado != null)
                {
                    if (!_productoSeleccionado.Estado)
                    {
                        MessageBox.Show("No se puede actualizar un producto inactivo.");
                        return;
                    }

                    DialogResult resultado = MessageBox.Show(
                        ConstantesUI.Plantillas.ConfirmarEliminacion("producto"),
                        ConstantesUI.Titulos.Confirmacion,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (resultado == DialogResult.Yes)
                    {
                        _bllProducto.Eliminar(_productoSeleccionado.Id);
                        CargarProductos();
                        MessageBox.Show(ConstantesUI.Plantillas.EliminadoCorrectamente("Producto"));
                        _productoSeleccionado = null;
                    }
                }
                else
                {
                    MessageBox.Show(ConstantesUI.Plantillas.Seleccione("un producto para eliminar"));
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            Producto producto = (btnAceptar.Tag.ToString() == "Actualizar") ? _productoSeleccionado : new Producto();
            MapearControlesAProducto(producto);

            int proveedorId = (int)comboProveedor.SelectedValue;

            if (btnAceptar.Tag.ToString() == "Agregar")
            {
                producto.Estado = true;
                _bllProducto.Insertar(producto, proveedorId);
                MessageBox.Show("Producto agregado correctamente.");
            }
            else if (btnAceptar.Tag.ToString() == "Actualizar")
            {
                producto.Estado = true;
                _bllProducto.Actualizar(producto, proveedorId);
                MessageBox.Show("Producto actualizado correctamente.");
            }

            CargarProductos();
            panelDatosProducto.Visible = false;
        }

        private void btnBorrarIngresoDatos_Click(object sender, System.EventArgs e)
        {
            LimpiarControles();
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (comboBuscar.SelectedItem == null || string.IsNullOrWhiteSpace(txtBuscar.Text.Trim()))
                {
                    MessageBox.Show(ConstantesUI.Validaciones.SeleccioneCriterioBusqueda + " " + ConstantesUI.Validaciones.IngreseTextoBusqueda, ConstantesUI.Titulos.Validacion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string criterioBusqueda = comboBuscar.SelectedItem.ToString();
                string textoBusqueda = txtBuscar.Text.Trim();
                int? categoria = null;
                bool? estado = null;
                string nombre = null;

                if (!string.IsNullOrEmpty(textoBusqueda))
                {
                    switch (criterioBusqueda)
                    {
                        case "Categoría":
                            if (Enum.TryParse<Categoria>(textoBusqueda, true, out var categoriaEnum))
                            {
                                categoria = (int)categoriaEnum;
                            }
                            else
                            {
                                MessageBox.Show(ConstantesUI.Validaciones.CategoriaNoValida, ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            break;

                        case "Estado":
                            if (textoBusqueda.Equals(ConstantesUI.Estados.Activo, StringComparison.OrdinalIgnoreCase))
                            {
                                estado = true;
                            }
                            else if (textoBusqueda.Equals(ConstantesUI.Estados.Inactivo, StringComparison.OrdinalIgnoreCase))
                            {
                                estado = false;
                            }
                            else
                            {
                                MessageBox.Show(ConstantesUI.Validaciones.EstadoInvalido, ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            break;

                        case "Nombre del producto":
                            nombre = textoBusqueda;
                            break;

                        default:
                            MessageBox.Show(ConstantesUI.Validaciones.CriterioBusquedaNoValido, ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }
                }

                var productos = _bllProducto.BuscarProductos(categoria, nombre, estado);

                dataGridViewProductos.DataSource = productos;
                Actualizar(sesion.Idioma);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar productos: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrarBusqueda_Click(object sender, System.EventArgs e)
        {
            LimpiarControlesBusqueda();
        }

        private void btnExportar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (dataGridViewProductos.DataSource == null)
                {
                    MessageBox.Show(ConstantesUI.Mensajes.NoHayDatosParaExportar, ConstantesUI.Titulos.Informacion, 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Convertir DataGridView a DataTable
                DataTable dtProductos = ConvertirDataGridViewADataTable(dataGridViewProductos);
                
                // Usar BLL_EXPORTACION para exportar
                string fileName = _bllExportacion.GenerarNombreArchivoUnico("InformacionProductos");
                bool exportado = _bllExportacion.ExportarMultiplesDataTablesAExcel(fileName, 
                    (dtProductos, ConstantesUI.Exportacion.HojaProductos, ConstantesUI.Exportacion.TituloProductos));

                if (exportado)
                {
                    string rutaCompleta = System.IO.Path.Combine(BLL_CONFIGURACION.ObtenerDirectorioReporteria(), fileName + ".xlsx");
                    MessageBox.Show($"Archivo exportado correctamente a: {rutaCompleta}", 
                        ConstantesUI.Titulos.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Preguntar si quiere abrir el archivo
                    DialogResult result = MessageBox.Show(ConstantesUI.Mensajes.DeseaAbrirArchivoExportado, 
                        ConstantesUI.Titulos.AbrirArchivo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                    if (result == DialogResult.Yes)
                    {
                        _bllExportacion.AbrirArchivo(rutaCompleta);
                    }
                }
                else
                {
                    MessageBox.Show(ConstantesUI.Mensajes.ErrorExportacion, ConstantesUI.Titulos.Error, 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la exportación: {ex.Message}", ConstantesUI.Titulos.Error, 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            CargarProductos();
        }

        private void dataGridViewProductos_SelectionChanged(object sender, System.EventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                // Obtener el producto de la fila seleccionada
                var item = dataGridViewProductos.SelectedRows[0].DataBoundItem as Producto;

                if (item != null)
                {
                    _productoSeleccionado = item;
                    lblSeleccionado.Visible = true;
                    lblSeleccionadoEspecifico.Visible = true;
                    lblSeleccionadoEspecifico.Text = item.Nombre;

                    // Mapear los datos del producto seleccionado a los controles de edición
                    MapearProductoAControles(_productoSeleccionado);
                }
            }
            else
            {
                // Si no hay ninguna fila seleccionada, limpiar la variable y la interfaz
                _productoSeleccionado = null;
                lblSeleccionado.Visible = false;
                lblSeleccionadoEspecifico.Visible = false;
                LimpiarControles();
            }
        }

        private void frmGestionStockProductos_Load(object sender, System.EventArgs e)
        {

        }

        #region MetodosPrivados

        private void CargarDatos()
        {
            CargarProveedores();
            CargarCategorias();
            ConfigurarEncabezadosColumnas();
        }
        private void LimpiarControlesBusqueda()
        {
            comboBuscar.SelectedIndex = -1;
            txtBuscar.Clear();
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

        private void CargarCategorias()
        {
            comboCategoria.DataSource = Enum.GetValues(typeof(Categoria));
        }
        private void MapearProductoAControles(Producto producto)
        {
            txtCodigo.Text = producto.Codigo;
            txtNombre.Text = producto.Nombre;
            comboCategoria.SelectedItem = producto.CategoriaEnum;
            txtDescripcion.Text = producto.Descripcion;
            numericUpDownPrecioCompra.Value = producto.PrecioCompra;
            numericUpDownStockMinimo.Value = producto.StockMinimo >= 0 ? producto.StockMinimo : 0;
            lblSeleccionadoEspecifico.Text = producto.Nombre;
        }

        private void MapearControlesAProducto(Producto producto)
        {
            producto.Codigo = txtCodigo.Text;
            producto.Nombre = txtNombre.Text;
            producto.CategoriaEnum = (Categoria)comboCategoria.SelectedItem;
            producto.Descripcion = txtDescripcion.Text;
            producto.PrecioCompra = numericUpDownPrecioCompra.Value;
            producto.StockMinimo = numericUpDownStockMinimo.Value;

            int proveedorId = (int)comboProveedor.SelectedValue;
            if (!producto.Proveedores.Any(pp => pp.ProveedorId == proveedorId))
            {
                producto.Proveedores.Clear();
                producto.Proveedores.Add(new ProductoProveedor { ProductoId = producto.Id, ProveedorId = proveedorId });
            }
        }

        private void LimpiarControles()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            comboCategoria.SelectedIndex = -1;
            txtDescripcion.Clear();
            numericUpDownPrecioCompra.Value = 0;
            lblSeleccionadoEspecifico.Text = string.Empty;
        }

        private void CargarProductos()
        {
            var productos = _bllProducto.ObtenerTodos();
            dataGridViewProductos.DataSource = productos;
            ConfigurarEncabezadosColumnas();

            try
            {
                var bajos = _bllProducto.ObtenerProductosBajoStock();
                if (bajos != null && bajos.Count > 0)
                {
                    // Resaltar filas con bajo stock
                    foreach (DataGridViewRow row in dataGridViewProductos.Rows)
                    {
                        var p = row.DataBoundItem as Producto;
                        if (p != null && bajos.Any(b => b.Id == p.Id))
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
                        }
                    }
                }
            }
            catch { }
        }

        private void chkSoloBajoStock_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSoloBajoStock.Checked)
                {
                    var bajos = _bllProducto.ObtenerProductosBajoStock();
                    dataGridViewProductos.DataSource = bajos;
                }
                else
                {
                    CargarProductos();
                }
            }
            catch { }
        }

        private void ConfigurarEncabezadosColumnas()
        {
            dataGridViewProductos.Columns["Codigo"].HeaderText = "Código";
            dataGridViewProductos.Columns["Codigo"].Tag = "Codigo_Column";

            dataGridViewProductos.Columns["CategoriaEnum"].HeaderText = "Categoría";
            dataGridViewProductos.Columns["CategoriaEnum"].Tag = "Categoria_Column";

            dataGridViewProductos.Columns["Stock"].HeaderText = "Stock";
            dataGridViewProductos.Columns["Stock"].Tag = "Stock_Column";

            dataGridViewProductos.Columns["Descripcion"].HeaderText = "Descripcion";
            dataGridViewProductos.Columns["Descripcion"].Tag = "Descripcion_Column";

            dataGridViewProductos.Columns["Nombre"].HeaderText = "Nombre del Producto";
            dataGridViewProductos.Columns["Nombre"].Tag = "Producto_Column";

            dataGridViewProductos.Columns["PrecioCompra"].HeaderText = "Precio de Compra";
            dataGridViewProductos.Columns["PrecioCompra"].Tag = "PrecioCompra_Column";

            dataGridViewProductos.Columns["PrecioVenta"].HeaderText = "Precio de Venta";
            dataGridViewProductos.Columns["PrecioVenta"].Tag = "PrecioVenta_Column";

            dataGridViewProductos.Columns["Fecha"].HeaderText = "Fecha de Registro";
            dataGridViewProductos.Columns["Fecha"].Tag = "FechaRegistro_Column";

            if (dataGridViewProductos.Columns.Contains("StockMinimo"))
            {
                dataGridViewProductos.Columns["StockMinimo"].HeaderText = "Stock Mínimo";
                dataGridViewProductos.Columns["StockMinimo"].Tag = "StockMinimo_Column";
            }

            dataGridViewProductos.Columns["Estado"].Visible = false;
        }
        private void CargarProveedores()
        {
            var proveedores = _bllProveedor.ObtenerTodos();
            comboProveedor.DisplayMember = "Descripcion";
            comboProveedor.ValueMember = "Id";
            comboProveedor.DataSource = proveedores;
            if (comboProveedor.Items.Count > 0)
            {
                comboProveedor.SelectedIndex = 0;
            }
        }

        private void CargarComboBuscar()
        {
            comboBuscar.Items.Clear();
            comboBuscar.Items.Add("Categoría");
            comboBuscar.Items.Add("Estado");
            comboBuscar.Items.Add("Nombre del producto");

            comboBuscar.SelectedIndex = 0;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show(ConstantesUI.Plantillas.Ingrese("un código para el producto"));
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(ConstantesUI.Plantillas.Ingrese("un nombre para el producto"));
                return false;
            }

            if (comboCategoria.SelectedIndex == -1)
            {
                MessageBox.Show(ConstantesUI.Plantillas.Seleccione("una categoría para el producto"));
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show(ConstantesUI.Plantillas.Ingrese("una descripción para el producto"));
                return false;
            }

            if (comboProveedor.SelectedIndex == -1)
            {
                MessageBox.Show(ConstantesUI.Plantillas.Seleccione("un proveedor para el producto"));
                return false;
            }

            if (numericUpDownPrecioCompra.Value <= 0)
            {
                MessageBox.Show(ConstantesUI.Plantillas.Ingrese("un precio de compra válido"));
                return false;
            }

            return true;
        }

        private void MostrarControlesNormales()
        {
            buttonAgregarProductoProveedorSelec.Enabled = true;
            buttonActualizarProducto.Enabled = true;
            buttonEliminarProducto.Enabled = true;
            btnExportar.Enabled = true;
            btnRefresh.Enabled = true;
            panelDatosProducto.Enabled = true;
            panelFiltrar.Enabled = true;
            btnReactivarProductos.Enabled = false;
        }

        private void OcultarControlesNormalesSinMover()
        {
            buttonAgregarProductoProveedorSelec.Enabled = false;
            buttonActualizarProducto.Enabled = false;
            buttonEliminarProducto.Enabled = false;
            btnExportar.Enabled = false;
            btnRefresh.Enabled = false;
            panelDatosProducto.Enabled = false;
            panelFiltrar.Enabled = false;
            btnReactivarProductos.Enabled = true;
        }

        private void CargarProductosInactivosEnGrid()
        {
            var productosInactivos = _bllProducto.ObtenerProductosInactivos();
            if (productosInactivos != null && productosInactivos.Count > 0)
            {
                dataGridViewProductos.DataSource = productosInactivos;
                OcultarControlesNormalesSinMover();
            }
            else
            {
                MessageBox.Show(ConstantesUI.Plantillas.NoHayInactivosParaMostrar("productos"));
                MostrarControlesNormales();
            }
        }

        private void ReactivarProductoSeleccionado()
        {
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                var productoSeleccionado = (Producto)dataGridViewProductos.SelectedRows[0].DataBoundItem;

                if (comboProveedor.SelectedIndex == -1)
                {
                    MessageBox.Show(ConstantesUI.Plantillas.Seleccione("un proveedor para reactivar el producto"));
                    return;
                }

                int proveedorId = (int)comboProveedor.SelectedValue;

                try
                {
                    productoSeleccionado.Estado = true;
                    _bllProducto.Actualizar(productoSeleccionado, proveedorId);

                    MessageBox.Show($"El producto '{productoSeleccionado.Nombre}' ha sido reactivado y asociado al proveedor seleccionado.", ConstantesUI.Titulos.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Volver a cargar la vista normal
                    CargarProductos();
                    ConfigurarEncabezadosColumnas();
                    MostrarControlesNormales();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al reactivar el producto: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show(ConstantesUI.Plantillas.Seleccione("un producto inactivo para reactivar"));
            }
        }

        #endregion

        #region PropiedadesAux

        #endregion

        private void dataGridViewProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewProductos.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                bool estado = (bool)e.Value;
                e.Value = estado ? ConstantesUI.Estados.Activo : ConstantesUI.Estados.Inactivo;
                e.FormattingApplied = true;
            }
        }

        private void comboProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProveedor.SelectedValue != null)
            {
                int proveedorId = (int)comboProveedor.SelectedValue;
                var productos = _bllProducto.ObtenerProductosPorProveedor(proveedorId);

                if (productos != null)
                {
                    dataGridViewProductos.DataSource = productos;
                }
                else
                {
                    dataGridViewProductos.DataSource = null;
                }
            }
        }

        private void dataGridViewProductos_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dataGridViewProductos.Rows[e.RowIndex];
            bool estado = Convert.ToBoolean(row.Cells["Estado"].Value);

            if (!estado)
            {
                row.DefaultCellStyle.BackColor = Color.Gray;
                row.DefaultCellStyle.ForeColor = Color.White;
            }
        }

        private void buttonReactivarProductos_Click(object sender, EventArgs e)
        {
            CargarProductosInactivosEnGrid();
        }

        private void btnReactivarProductos_Click(object sender, EventArgs e)
        {
            ReactivarProductoSeleccionado();
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Cerrar();
        }
    }
}
