using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Compras;
using BEs.Clases.Negocio.Enums;
using BLLs.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Form1
{
    public partial class frmGestionarEnvioCotizacion : Form
    {
        private List<DetalleCotizacion> _detallesCotizacion;
        private Cotizacion _cotizacion;
        private BLL_PRODUCTO _bllProducto;
        private BLL_PROVEEDOR _bllProveedor;
        private BLL_COTIZACION _bllCotizacion;

        public frmGestionarEnvioCotizacion()
        {
            InitializeComponent();
            _detallesCotizacion = new List<DetalleCotizacion>();
            _cotizacion = new Cotizacion();
            _bllProducto = new BLL_PRODUCTO();
            _bllProveedor = new BLL_PROVEEDOR();
            _bllCotizacion = new BLL_COTIZACION();
        }

        private void buttonEnviarSolicitudCotizacion_Click(object sender, EventArgs e)
        {
            // Verifica que haya un proveedor seleccionado
            if (comboBoxProv.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona un proveedor.");
                return;
            }

            // Verifica que haya detalles en el DataGridView
            if (dataGridViewLista.Rows.Count == 0)
            {
                MessageBox.Show("No hay detalles para enviar en la cotización.");
                return;
            }

            // Crea los detalles de la cotización a partir del DataGridView
            List<DetalleCotizacion> detalles = new List<DetalleCotizacion>();
            foreach (DataGridViewRow row in dataGridViewLista.Rows)
            {
                if (row.Cells["ProductoId"].Value != null && row.Cells["Cantidad"].Value != null)
                {
                    int productoId = (int)row.Cells["ProductoId"].Value;
                    Producto producto = _bllProducto.ObtenerPorId(productoId);

                    detalles.Add(new DetalleCotizacion
                    {
                        ProductoId = productoId,
                        oProducto = producto,
                        Cantidad = (decimal)row.Cells["Cantidad"].Value,
                        Fecha = DateTime.Now
                    });
                }
            }

            // Configura la cotización
            var cotizacion = new Cotizacion
            {
                ProveedorId = (int)comboBoxProv.SelectedValue,
                DetallesCotizacion = detalles,
                EstadoCotizacionEnum = EstadoCotizacion.Pendiente,
                FechaCotizacion = DateTime.Now
            };

            // Envía la cotización
            _bllCotizacion.Insertar(cotizacion);
            MessageBox.Show($"Cotización enviada al proveedor {comboBoxProv.Text}, exitosamente.");
            LimpiarFormulario();
        }

        private void btnAgregarALista_Click(object sender, EventArgs e)
        {
            // Verifica si hay un producto seleccionado
            if (comboBoxProducto.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un producto.");
                return;
            }

            // Verifica si la cantidad es válida
            if (!decimal.TryParse(textBoxCantidad.Text, out decimal cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Por favor, ingresa una cantidad válida.");
                return;
            }

            // Conversión de gramos a kilos si btnG está seleccionado
            if (btnG.Checked)
            {
                cantidad /= 1000; // Convierte gramos a kilos (1 kilo = 1000 gramos)
            }

            Producto producto = (Producto)comboBoxProducto.SelectedItem;

            DetalleCotizacion detalle = new DetalleCotizacion
            {
                ProductoId = producto.Id,
                Cantidad = cantidad, // Aquí ya está en kilos si btnG está seleccionado
                Fecha = DateTime.Now
            };

            dataGridViewLista.Rows.Add(detalle.ProductoId, producto.Nombre, detalle.Cantidad);

            // Actualiza el proveedor y la fecha en los labels
            lblProveedor.Text = $"{comboBoxProv.Text}"; // Muestra el nombre del proveedor seleccionado
            lblFecha.Text = $"{DateTime.Now:dd-MM-yyyy}"; // Muestra la fecha actual con formato

            // Habilita los botones de enviar y cancelar
            buttonEnviarSolicitudCotizacion.Enabled = true;
            buttonCancelarSolicitudCotizacion.Enabled = true;

            // Deshabilita el comboBox de proveedor
            comboBoxProv.Enabled = false;
        }

        private void btnEliminarDeLista_Click(object sender, EventArgs e)
        {
            if (dataGridViewLista.Rows.Count <= 1)
            {
                MessageBox.Show("Debes cargar items primero.");
                return;
            }

            if (dataGridViewLista.SelectedRows.Count > 0)
            {
                dataGridViewLista.Rows.RemoveAt(dataGridViewLista.SelectedRows[0].Index);
            }


            if (dataGridViewLista.Rows.Count <= 1)
            {
                buttonEnviarSolicitudCotizacion.Enabled = false;
                buttonCancelarSolicitudCotizacion.Enabled = false;
                LimpiarFormulario();
            }
        }

        private void buttonCancelarSolicitudCotizacion_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }


        #region MetodosPrivados
        private void LimpiarFormulario()
        {
            comboBoxCategoria.SelectedIndex = -1;
            comboBoxProv.SelectedIndex = -1;
            comboBoxProv.Enabled = true;
            comboBoxProducto.SelectedIndex = -1;
            lblProveedor.Text = "-";
            lblFecha.Text = "-";
            textBoxCantidad.Clear();
            dataGridViewLista.Rows.Clear();

            buttonEnviarSolicitudCotizacion.Enabled = false;
            buttonCancelarSolicitudCotizacion.Enabled = false;
        }

        private void CargarProveedores()
        {
            comboBoxProv.DataSource = null; // Limpia el DataSource anterior
            var proveedores = _bllProveedor.ObtenerTodos(); // Obtiene la lista de proveedores
            if (proveedores.Any())
            {
                comboBoxProv.DataSource = proveedores;
                comboBoxProv.DisplayMember = "Descripcion"; // Cambia "Descripcion" por la propiedad que deseas mostrar
                comboBoxProv.ValueMember = "Id"; // Asegúrate de que "Id" es un int
            }
            else
            {
                comboBoxProv.DataSource = null; // Limpia el DataSource si no hay proveedores
            }
        }

        private void ActualizarDataGridViewDetalles()
        {
            dataGridViewLista.Rows.Clear();
            dataGridViewLista.Columns.Clear();

            // Agrega las columnas al DataGridView
            dataGridViewLista.Columns.Add("ProductoId", "ID Producto");
            dataGridViewLista.Columns.Add("Nombre", "Nombre");
            dataGridViewLista.Columns.Add("Cantidad", "Cantidad");

            foreach (DetalleCotizacion detalle in _detallesCotizacion)
            {
                dataGridViewLista.Rows.Add(detalle.ProductoId, detalle.oProducto.Nombre, detalle.Cantidad);
            }
        }

        #endregion

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCategoria.SelectedItem is Categoria categoria) // Verifica si el tipo es Categoria
            {
                comboBoxProducto.Enabled = true; // Habilita el ComboBox de productos
                comboBoxProducto.DataSource = null; // Limpia el DataSource anterior

                // Obtiene el proveedor seleccionado
                if (comboBoxProv.SelectedItem is Proveedor proveedor)
                {
                    int proveedorId = proveedor.Id;

                    // Obtiene los productos para el proveedor y la categoría seleccionados
                    var productos = _bllProducto.ObtenerProductosProveedorPorCategoria(proveedorId, categoria);
                    comboBoxProducto.DataSource = productos;
                    comboBoxProducto.DisplayMember = "Nombre"; // Cambia esto si "Nombre" no es la propiedad adecuada
                    comboBoxProducto.ValueMember = "Id"; // Asegúrate de que "Id" es un int
                }
            }
            else
            {
                comboBoxProducto.DataSource = null; // Limpia el DataSource si no hay categoría seleccionada
                comboBoxProducto.Enabled = false; // Deshabilita el ComboBox de productos si no hay categoría seleccionada
            }
        }



        private void frmGestionarEnvioCotizacion_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            comboBoxCategoria.SelectedIndex = -1;
            comboBoxCategoria.Enabled = false;
            comboBoxProducto.Enabled = false;
            ActualizarDataGridViewDetalles();
        }

        private void comboBoxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProducto.SelectedValue != null)
            {
                // Aquí puedes manejar la lógica de habilitar el TextBox y los RadioButtons
                textBoxCantidad.Enabled = true; // Habilita el TextBox de cantidad

                // Habilita los RadioButtons
                btnG.Enabled = true; // Habilita el RadioButton btnG
                btnK.Enabled = true; // Habilita el RadioButton btnK

                // Si deseas seleccionar un RadioButton por defecto, puedes hacerlo aquí
                // Por ejemplo, seleccionamos btnG por defecto
                btnG.Checked = true; // Cambia a checked el btnG (o btnK según tu lógica)
            }
            else
            {
                // Si no hay un producto seleccionado, deshabilita el TextBox y los RadioButtons
                textBoxCantidad.Enabled = false; // Deshabilita el TextBox de cantidad
                btnG.Enabled = false; // Deshabilita el RadioButton btnG
                btnK.Enabled = false; // Deshabilita el RadioButton btnK
            }
        }

        private void comboBoxProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProv.SelectedItem is Proveedor proveedor)
            {
                comboBoxCategoria.Enabled = true;
                comboBoxCategoria.DataSource = null;

                int proveedorId = proveedor.Id; // Accede a la propiedad Id del objeto Proveedor

                // Obtén las categorías disponibles para el proveedor seleccionado
                var categorias = _bllProducto.ObtenerCategoriasPorProveedor(proveedorId);

                if (categorias.Any())
                {
                    comboBoxCategoria.DataSource = categorias;
                    comboBoxCategoria.DisplayMember = "Nombre"; // Asegúrate de tener un método ToString adecuado en tu enum
                    comboBoxCategoria.ValueMember = ""; // No necesitas ValueMember aquí ya que es un enum
                }
                else
                {
                    comboBoxCategoria.DataSource = null;
                    comboBoxCategoria.Enabled = false;
                }
            }
            else
            {
                comboBoxCategoria.DataSource = null; // Limpia el DataSource si no hay proveedor
                comboBoxCategoria.Enabled = false; // Deshabilita el ComboBox de categorías si no hay proveedor seleccionado
            }
        }
    }
}
