using BEs;
using BEs.Clases;
using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Inventario;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Form1
{
    public partial class frmGestionStockProductos : Form, IObservador
    {
        private BLL_PRODUCTO _bllProducto;
        private BLL_PROVEEDOR _bllProveedor;
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
            sesion.RegistrarObservador(this);
            IIdioma oIdioma = sesion.Idioma;
            CargarIdiomas();
            Actualizar(oIdioma);
            if (sesion.Permisos != null)
            {
                BuscarControles(this.Controls);
                Buscar(sesion.Permisos[0]);
            }
            _bllProducto = new BLL_PRODUCTO();
            _bllProveedor = new BLL_PROVEEDOR();
        }

        private void buttonAgregarProductoProveedorSelec_Click(object sender, System.EventArgs e)
        {
            panelDatosProducto.Visible = true;
            txtCodigo.ReadOnly = false;  // Código editable en agregar
            lblSeleccionado.Visible = false;  // Ocultar etiquetas de selección
            lblSeleccionadoEspecifico.Visible = false;
            LimpiarControles();  // Limpiar los controles para ingresar nuevos datos
            _productoSeleccionado = null;  // Resetear el producto seleccionado
            btnAceptar.Tag = "Agregar";  // Usar la etiqueta del botón para distinguir si es agregar o actualizar
        }

        private void buttonActualizarProducto_Click(object sender, System.EventArgs e)
        {
            if (_productoSeleccionado == null)
            {
                MessageBox.Show("Por favor, seleccione un producto para actualizar.");
                return;
            }

            // Mostrar el panel para actualizar y rellenar los controles con los datos del producto
            panelDatosProducto.Visible = true;
            txtCodigo.ReadOnly = true;  // Código no editable al actualizar
            lblSeleccionado.Visible = true;
            lblSeleccionadoEspecifico.Visible = true;
            lblSeleccionadoEspecifico.Text = _productoSeleccionado.Nombre;

            // Mapear los datos del producto seleccionado a los controles
            MapearProductoAControles(_productoSeleccionado);
            btnAceptar.Tag = "Actualizar";  // Distinguir si es agregar o actualizar
        }

        private void buttonEliminarProducto_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (_productoSeleccionado != null)
                {
                    DialogResult resultado = MessageBox.Show(
                        "¿Estás seguro de que deseas eliminar este producto?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (resultado == DialogResult.Yes)
                    {
                        _bllProducto.Eliminar(_productoSeleccionado.Id);
                        CargarProductos();
                        MessageBox.Show("Producto eliminado correctamente.");
                        _productoSeleccionado = null;
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona un producto para eliminar.");
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

        }

        private void btnBorrarBusqueda_Click(object sender, System.EventArgs e)
        {
            LimpiarControlesBusqueda();
        }

        private void btnExportar_Click(object sender, System.EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            app.Visible = true;
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Exportado desde DataGridView";

            for (int i = 1; i <= dataGridViewProductos.Columns.Count; i++)
            {
                worksheet.Cells[1, i] = dataGridViewProductos.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridViewProductos.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewProductos.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridViewProductos.Rows[i].Cells[j].Value?.ToString();
                }
            }

            string filePath = "C:\\InformacionProducto" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".xlsx";
            workbook.SaveAs(filePath);
            workbook.Close();
            app.Quit();

            ReleaseObject(worksheet);
            ReleaseObject(workbook);
            ReleaseObject(app);

            MessageBox.Show("Archivo exportado correctamente a: " + filePath);
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
            CargarProveedores();
            CargarCategorias();
            ConfigurarEncabezadosColumnas();
        }

        #region MetodosPrivados
        private void LimpiarControlesBusqueda()
        {
            comboBuscar.SelectedIndex = -1;
            txtBuscar.Clear();
        }
        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Excepción al liberar objeto " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
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
            lblSeleccionadoEspecifico.Text = producto.Nombre;
        }

        private void MapearControlesAProducto(Producto producto)
        {
            producto.Codigo = txtCodigo.Text;
            producto.Nombre = txtNombre.Text;
            producto.CategoriaEnum = (Categoria)comboCategoria.SelectedItem;
            producto.Descripcion = txtDescripcion.Text;
            producto.PrecioCompra = numericUpDownPrecioCompra.Value;

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
        }

        private void ConfigurarEncabezadosColumnas()
        {
            dataGridViewProductos.Columns["Codigo"].HeaderText = "Código";
            dataGridViewProductos.Columns["CategoriaEnum"].HeaderText = "Categoría";
            dataGridViewProductos.Columns["Stock"].HeaderText = "Stock";
            dataGridViewProductos.Columns["Nombre"].HeaderText = "Nombre del Producto";
            dataGridViewProductos.Columns["PrecioCompra"].HeaderText = "Precio de Compra";
            dataGridViewProductos.Columns["PrecioVenta"].HeaderText = "Precio de Venta";
            dataGridViewProductos.Columns["Fecha"].HeaderText = "Fecha de Registro";
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

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Por favor, ingrese un código para el producto.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre para el producto.");
                return false;
            }

            if (comboCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una categoría para el producto.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, ingrese una descripción para el producto.");
                return false;
            }

            if (comboProveedor.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un proveedor para el producto.");
                return false;
            }

            if (numericUpDownPrecioCompra.Value <= 0)
            {
                MessageBox.Show("Por favor, ingrese un precio de compra válido.");
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
                MessageBox.Show("No hay productos inactivos para mostrar.");
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
                    MessageBox.Show("Por favor, seleccione un proveedor para reactivar el producto.");
                    return;
                }

                int proveedorId = (int)comboProveedor.SelectedValue;

                try
                {
                    productoSeleccionado.Estado = true;
                    _bllProducto.Actualizar(productoSeleccionado, proveedorId);

                    MessageBox.Show($"El producto '{productoSeleccionado.Nombre}' ha sido reactivado y asociado al proveedor seleccionado.");

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
                MessageBox.Show("Por favor, seleccione un producto inactivo para reactivar.");
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
                e.Value = estado ? "Activo" : "Inactivo";
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
