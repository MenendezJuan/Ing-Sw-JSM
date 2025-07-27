using BEs;
using BEs.Clases;
using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Enums;
using BEs.Clases.Negocio.Ventas;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix.Negocio.Ventas
{
    public partial class frmTramitarOrdenCarrito : Form, IObservador
    {
        #region Propiedades y Variables

        private BLL_PRODUCTO _bllProducto;
        private BLL_VENTA _bllVenta;
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        
        // Cliente actual
        private Cliente _clienteActual;
        
        // Carrito de compras en memoria
        private List<ItemCarrito> _carrito;
        
        // Productos originales (antes de filtros)
        private List<Producto> _productosOriginales;
        
        // Producto seleccionado actualmente
        private Producto _productoSeleccionado;

        #endregion

        #region Constructor y Inicialización

        public frmTramitarOrdenCarrito()
        {
            InitializeComponent();
            InicializarComponentes();
        }

        /// <summary>
        /// Constructor que recibe el cliente desde frmInicioOrden
        /// </summary>
        /// <param name="cliente">Cliente para el cual se creará la venta</param>
        public frmTramitarOrdenCarrito(Cliente cliente) : this()
        {
            _clienteActual = cliente;
            EstablecerCliente(cliente);
        }

        private void InicializarComponentes()
        {
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            _bllProducto = new BLL_PRODUCTO();
            _bllVenta = new BLL_VENTA();
            
            // Inicializar carrito
            _carrito = new List<ItemCarrito>();
            
            // Configurar fecha actual
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
            // Configurar total inicial
            ActualizarTotal();
            
            // Cargar datos iniciales
            CargarCategorias();
            CargarProductos();
            ConfigurarDataGrids();
            
            // Configurar idiomas y permisos
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

        private void EstablecerCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                _clienteActual = cliente;
                lblCliente.Text = cliente.NombreCompleto;
            }
            else
            {
                lblCliente.Text = "Cliente no disponible";
            }
        }

        #endregion

        #region Configuración de DataGridViews

        private void ConfigurarDataGrids()
        {
            ConfigurarDataGridProductos();
            ConfigurarDataGridCarrito();
        }

        private void ConfigurarDataGridProductos()
        {
            // Configurar DataGridView de Productos (usando dataGridViewProductos)
            dataGridViewProductos.SelectionChanged += DataGridViewProductos_SelectionChanged;
            dataGridViewProductos.AutoGenerateColumns = false;
            dataGridViewProductos.Columns.Clear();

            dataGridViewProductos.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "Id", 
                HeaderText = "ID", 
                Name = "Id", 
                Width = 50,
                ReadOnly = true 
            });
            
            dataGridViewProductos.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "Codigo", 
                HeaderText = "Código", 
                Name = "Codigo", 
                Width = 80,
                ReadOnly = true 
            });
            
            dataGridViewProductos.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "Nombre", 
                HeaderText = "Producto", 
                Name = "Nombre", 
                Width = 200,
                ReadOnly = true 
            });
            
            dataGridViewProductos.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "CategoriaEnum", 
                HeaderText = "Categoría", 
                Name = "Categoria", 
                Width = 100,
                ReadOnly = true 
            });
            
            dataGridViewProductos.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "Stock", 
                HeaderText = "Stock Total", 
                Name = "StockTotal", 
                Width = 80,
                ReadOnly = true 
            });
            
            dataGridViewProductos.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "StockDisponible", 
                HeaderText = "Disponible", 
                Name = "StockDisponible", 
                Width = 80,
                ReadOnly = true 
            });
            
            dataGridViewProductos.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "PrecioVenta", 
                HeaderText = "Precio", 
                Name = "PrecioVenta", 
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
        }

        private void ConfigurarDataGridCarrito()
        {
            // Configurar DataGridView del Carrito
            dataGridViewCarrito.SelectionChanged += DataGridViewCarrito_SelectionChanged;
            dataGridViewCarrito.AutoGenerateColumns = false;
            dataGridViewCarrito.Columns.Clear();

            dataGridViewCarrito.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "NombreProducto", 
                HeaderText = "Producto", 
                Name = "Producto", 
                Width = 200,
                ReadOnly = true 
            });
            
            dataGridViewCarrito.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "Cantidad", 
                HeaderText = "Cantidad", 
                Name = "Cantidad", 
                Width = 80,
                ReadOnly = true 
            });
            
            dataGridViewCarrito.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "PrecioUnitario", 
                HeaderText = "Precio Unit.", 
                Name = "PrecioUnitario", 
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
            
            dataGridViewCarrito.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "Subtotal", 
                HeaderText = "Subtotal", 
                Name = "Subtotal", 
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
        }

        #endregion

        #region Carga de Datos

        private void CargarCategorias()
        {
            try
            {
                // Cargar todas las categorías del enum
                var categorias = Enum.GetValues(typeof(Categoria)).Cast<Categoria>().ToList();
                
                // Crear lista con opción "Todas"
                var categoriasCombo = new List<object>();
                categoriasCombo.Add(new { Value = -1, Text = "Todas las categorías" });
                
                foreach (var categoria in categorias)
                {
                    categoriasCombo.Add(new { Value = (int)categoria, Text = categoria.ToString() });
                }
                
                cmbCategoriaProducto.DataSource = categoriasCombo;
                cmbCategoriaProducto.DisplayMember = "Text";
                cmbCategoriaProducto.ValueMember = "Value";
                cmbCategoriaProducto.SelectedIndex = 0; // Seleccionar "Todas"
                
                cmbCategoriaProducto.SelectedIndexChanged += CmbCategoriaProducto_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductos()
        {
            try
            {
                _productosOriginales = _bllProducto.ObtenerTodos()
                    .Where(p => p.Estado && p.Stock > 0) // Solo productos activos con stock
                    .ToList();
                
                // Obtener información de stock para cada producto
                foreach (var producto in _productosOriginales)
                {
                    var stockInfo = _bllProducto.ObtenerInfoStock(producto.Id);
                    if (stockInfo != null)
                    {
                        producto.StockDisponible = stockInfo.StockDisponible;
                    }
                    else
                    {
                        producto.StockDisponible = producto.Stock; // Fallback
                    }
                }
                
                AplicarFiltroCategoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltroCategoria()
        {
            if (_productosOriginales == null) return;

            try
            {
                var categoriaSeleccionada = Convert.ToInt32(cmbCategoriaProducto.SelectedValue);
                
                List<Producto> productosFiltrados;
                
                if (categoriaSeleccionada == -1) // Todas las categorías
                {
                    productosFiltrados = _productosOriginales.ToList();
                }
                else
                {
                    productosFiltrados = _productosOriginales
                        .Where(p => (int)p.CategoriaEnum == categoriaSeleccionada)
                        .ToList();
                }
                
                dataGridViewProductos.DataSource = productosFiltrados;
                LimpiarSeleccionProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar productos: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos de Selección

        private void DataGridViewProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProductos.CurrentRow?.DataBoundItem is Producto productoSeleccionado)
            {
                _productoSeleccionado = productoSeleccionado;
                
                // Configurar cantidad máxima según stock disponible
                numericCantidadProducto.Maximum = Math.Max(1, (decimal)productoSeleccionado.StockDisponible);
                numericCantidadProducto.Value = 1;
                numericCantidadProducto.Enabled = productoSeleccionado.StockDisponible > 0;
                
                // Habilitar/deshabilitar botón de agregar
                btnAgregarACarrito_frmTramitarOrden.Enabled = productoSeleccionado.StockDisponible > 0;
                
                if (productoSeleccionado.StockDisponible <= 0)
                {
                    MessageBox.Show($"El producto '{productoSeleccionado.Nombre}' no tiene stock disponible.", 
                        "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                LimpiarSeleccionProducto();
            }
        }

        private void DataGridViewCarrito_SelectionChanged(object sender, EventArgs e)
        {
            // Habilitar botón eliminar si hay algo seleccionado
            btnEliminarProducto.Enabled = dataGridViewCarrito.CurrentRow != null;
        }

        private void CmbCategoriaProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltroCategoria();
        }

        private void LimpiarSeleccionProducto()
        {
            _productoSeleccionado = null;
            numericCantidadProducto.Value = 1;
            numericCantidadProducto.Enabled = false;
            btnAgregarACarrito_frmTramitarOrden.Enabled = false;
        }

        #endregion

        #region Gestión del Carrito

        private void btnAgregarACarrito_Click(object sender, EventArgs e)
        {
            try
            {
                if (_productoSeleccionado == null)
                {
                    MessageBox.Show("Por favor, seleccione un producto.", "Producto requerido", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal cantidadSolicitada = numericCantidadProducto.Value;
                
                // Verificar stock disponible
                if (cantidadSolicitada > _productoSeleccionado.StockDisponible)
                {
                    MessageBox.Show($"No hay suficiente stock disponible. Stock disponible: {_productoSeleccionado.StockDisponible}", 
                        "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar si el producto ya está en el carrito
                var itemExistente = _carrito.FirstOrDefault(i => i.ProductoId == _productoSeleccionado.Id);
                
                if (itemExistente != null)
                {
                    // Verificar que la cantidad total no exceda el stock
                    decimal cantidadTotal = itemExistente.Cantidad + cantidadSolicitada;
                    if (cantidadTotal > _productoSeleccionado.StockDisponible)
                    {
                        MessageBox.Show($"La cantidad total ({cantidadTotal}) excedería el stock disponible ({_productoSeleccionado.StockDisponible}).", 
                            "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    // Actualizar cantidad existente
                    itemExistente.Cantidad = cantidadTotal;
                    itemExistente.Subtotal = itemExistente.Cantidad * itemExistente.PrecioUnitario;
                }
                else
                {
                    // Agregar nuevo item al carrito
                    var nuevoItem = new ItemCarrito
                    {
                        ProductoId = _productoSeleccionado.Id,
                        NombreProducto = _productoSeleccionado.Nombre,
                        Cantidad = cantidadSolicitada,
                        PrecioUnitario = _productoSeleccionado.PrecioVenta,
                        Subtotal = cantidadSolicitada * _productoSeleccionado.PrecioVenta
                    };
                    
                    _carrito.Add(nuevoItem);
                }

                // Actualizar vista del carrito
                ActualizarVistaCarrito();
                ActualizarTotal();
                
                // Limpiar selección
                LimpiarSeleccionProducto();
                
                MessageBox.Show($"Producto agregado al carrito: {_productoSeleccionado.Nombre} x{cantidadSolicitada}", 
                    "Producto agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar producto al carrito: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewCarrito.CurrentRow?.DataBoundItem is ItemCarrito itemSeleccionado)
                {
                    var resultado = MessageBox.Show(
                        $"¿Está seguro de que desea eliminar '{itemSeleccionado.NombreProducto}' del carrito?", 
                        "Confirmar eliminación", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question);
                    
                    if (resultado == DialogResult.Yes)
                    {
                        _carrito.Remove(itemSeleccionado);
                        ActualizarVistaCarrito();
                        ActualizarTotal();
                        
                        MessageBox.Show("Producto eliminado del carrito.", "Producto eliminado", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un producto del carrito para eliminar.", 
                        "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar producto del carrito: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVaciarCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                if (_carrito.Count == 0)
                {
                    MessageBox.Show("El carrito ya está vacío.", "Carrito vacío", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var resultado = MessageBox.Show(
                    "¿Está seguro de que desea vaciar todo el carrito?", 
                    "Confirmar vaciado", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);
                
                if (resultado == DialogResult.Yes)
                {
                    _carrito.Clear();
                    ActualizarVistaCarrito();
                    ActualizarTotal();
                    
                    MessageBox.Show("Carrito vaciado exitosamente.", "Carrito vaciado", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al vaciar carrito: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarVistaCarrito()
        {
            dataGridViewCarrito.DataSource = null;
            dataGridViewCarrito.DataSource = _carrito.ToList(); // Nueva lista para forzar actualización
            
            // Habilitar/deshabilitar botones según el estado del carrito
            btnEliminarProducto.Enabled = false; // Se habilitará en SelectionChanged
            btnVaciarCarrito.Enabled = _carrito.Count > 0;
            btnConfirmarCarrito.Enabled = _carrito.Count > 0;
        }

        private void ActualizarTotal()
        {
            decimal total = _carrito.Sum(item => item.Subtotal);
            lblTotal.Text = total.ToString("C2");
        }

        #endregion

        #region Confirmación de Compra

        private void btnConfirmarCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones previas
                if (_clienteActual == null)
                {
                    MessageBox.Show("No hay un cliente seleccionado para esta venta.", "Cliente requerido", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_carrito.Count == 0)
                {
                    MessageBox.Show("No se pueden confirmar compras vacías. Agregue al menos un producto al carrito.", 
                        "Carrito vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmar con el usuario
                decimal total = _carrito.Sum(item => item.Subtotal);
                var resultado = MessageBox.Show(
                    $"¿Confirmar la venta?\n\nCliente: {_clienteActual.NombreCompleto}\nTotal: {total:C2}\nProductos: {_carrito.Count}", 
                    "Confirmar venta", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);
                
                if (resultado == DialogResult.Yes)
                {
                    CrearVenta();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al confirmar la compra: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearVenta()
        {
            try
            {
                // Crear la venta
                var nuevaVenta = new Venta
                {
                    ClienteId = _clienteActual.Id,
                    UsuarioVendedorId = sesion.oUsuario.Id,
                    Fecha = DateTime.Now,
                    MontoTotal = _carrito.Sum(item => item.Subtotal),
                    TipoPagoEnum = TipoPago.Efectivo, // Por defecto, se puede cambiar después
                    EstadoVentaEnum = EstadoVenta.EnProceso,
                    Comentario = $"Venta creada desde carrito - {_carrito.Count} productos",
                    oCliente = _clienteActual,
                    oDetalleVenta = new List<DetalleVenta>()
                };

                // Crear detalles de venta
                foreach (var item in _carrito)
                {
                    var detalle = new DetalleVenta
                    {
                        ProductoId = item.ProductoId,
                        Cantidad = item.Cantidad,
                        Precio = item.PrecioUnitario,
                        SubTotal = item.Subtotal,
                        Fecha = DateTime.Now,
                        oProducto = _productosOriginales.FirstOrDefault(p => p.Id == item.ProductoId)
                    };
                    
                    nuevaVenta.oDetalleVenta.Add(detalle);
                }

                // Guardar la venta (esto reservará automáticamente el stock)
                int ventaId = _bllVenta.Insertar(nuevaVenta);
                
                MessageBox.Show($"Venta creada exitosamente con ID: {ventaId}\n\nEl stock ha sido reservado automáticamente.", 
                    "Venta creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Limpiar carrito y cerrar formulario
                _carrito.Clear();
                ActualizarVistaCarrito();
                ActualizarTotal();
                
                // Cerrar formulario y volver al anterior
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la venta: {ex.Message}", "Error al crear venta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos de Botones

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Verificar si hay productos en el carrito
            if (_carrito.Count > 0)
            {
                var resultado = MessageBox.Show(
                    "Hay productos en el carrito. ¿Está seguro de que desea salir sin confirmar la venta?", 
                    "Confirmar salida", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);
                
                if (resultado == DialogResult.No)
                {
                    return; // No cerrar
                }
            }
            
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region Gestión de Idiomas y Permisos

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
        #endregion

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar idiomas: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cboxIdiomas_SelectedIndexChanged_1(object sender, EventArgs e)
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

        #endregion
    }

    #region Clase auxiliar para el carrito

    /// <summary>
    /// Representa un item en el carrito de compras
    /// </summary>
    public class ItemCarrito
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }

    #endregion
}
