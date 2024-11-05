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
            if (comboBoxProv.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona un proveedor.");
                return;
            }

            if (dataGridViewLista.Rows.Count == 0)
            {
                MessageBox.Show("No hay detalles para enviar en la cotización.");
                return;
            }

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

            var cotizacion = new Cotizacion
            {
                ProveedorId = (int)comboBoxProv.SelectedValue,
                DetallesCotizacion = detalles,
                EstadoCotizacionEnum = EstadoCotizacion.Pendiente,
                FechaCotizacion = DateTime.Now
            };

            _bllCotizacion.Insertar(cotizacion);
            MessageBox.Show($"Cotización enviada al proveedor {comboBoxProv.Text}, exitosamente.");
            LimpiarFormulario();
        }

        private void btnAgregarALista_Click(object sender, EventArgs e)
        {
            if (comboBoxProducto.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un producto.");
                return;
            }

            if (!decimal.TryParse(textBoxCantidad.Text, out decimal cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Por favor, ingresa una cantidad válida.");
                return;
            }

            if (btnG.Checked)
            {
                cantidad /= 1000;
            }

            Producto producto = (Producto)comboBoxProducto.SelectedItem;

            DetalleCotizacion detalle = new DetalleCotizacion
            {
                ProductoId = producto.Id,
                Cantidad = cantidad,
                Fecha = DateTime.Now
            };

            dataGridViewLista.Rows.Add(detalle.ProductoId, producto.Nombre, detalle.Cantidad);

            lblProveedor.Text = $"{comboBoxProv.Text}";
            lblFecha.Text = $"{DateTime.Now:dd-MM-yyyy}";

            buttonEnviarSolicitudCotizacion.Enabled = true;
            buttonCancelarSolicitudCotizacion.Enabled = true;

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
            comboBoxProv.DataSource = null;
            var proveedores = _bllProveedor.ObtenerTodos();
            if (proveedores.Any())
            {
                comboBoxProv.DataSource = proveedores;
                comboBoxProv.DisplayMember = "Descripcion";
                comboBoxProv.ValueMember = "Id";
                comboBoxProv.SelectedIndex = 0;
            }
            else
            {
                comboBoxProv.DataSource = null;
            }
        }

        private void ActualizarDataGridViewDetalles()
        {
            dataGridViewLista.Rows.Clear();
            dataGridViewLista.Columns.Clear();

            dataGridViewLista.Columns.Add("ProductoId", "ID Producto");
            dataGridViewLista.Columns.Add("Nombre", "Nombre");
            dataGridViewLista.Columns.Add("Cantidad", "Cantidad");

            foreach (DetalleCotizacion detalle in _detallesCotizacion)
            {
                dataGridViewLista.Rows.Add(detalle.ProductoId, detalle.oProducto.Nombre, detalle.Cantidad);
            }
        }

        private void CargarCategoriasProveedor(int proveedorId)
        {
            comboBoxCategoria.DataSource = null;
            comboBoxCategoria.Enabled = true;

            // Obtiene las categorías disponibles para el proveedor
            var categorias = _bllProducto.ObtenerCategoriasPorProveedor(proveedorId);

            if (categorias.Any())
            {
                comboBoxCategoria.DataSource = categorias;
                comboBoxCategoria.SelectedIndex = 0;
                comboBoxCategoria.Refresh();
            }
            else
            {
                comboBoxCategoria.DataSource = null;
                comboBoxCategoria.Enabled = false;
            }
        }

        #endregion

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCategoria.SelectedItem is Categoria categoria)
            {
                comboBoxProducto.Enabled = true;
                comboBoxProducto.DataSource = null;

                // Obtiene el proveedor seleccionado
                if (comboBoxProv.SelectedItem is Proveedor proveedor)
                {
                    int proveedorId = proveedor.Id;

                    // Obtiene los productos para el proveedor y la categoría seleccionados
                    var productos = _bllProducto.ObtenerProductosProveedorPorCategoria(proveedorId, categoria);
                    comboBoxProducto.DataSource = productos;
                    comboBoxProducto.DisplayMember = "Nombre";
                    comboBoxProducto.ValueMember = "Id";
                }
            }
            else
            {
                comboBoxProducto.DataSource = null;
                comboBoxProducto.Enabled = false;
            }
        }



        private void frmGestionarEnvioCotizacion_Load(object sender, EventArgs e)
        {
            CargarProveedores();

            if (comboBoxProv.SelectedItem is Proveedor proveedor)
            {
                CargarCategoriasProveedor(proveedor.Id);
            }

            ActualizarDataGridViewDetalles();
        }

        private void comboBoxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProducto.SelectedValue != null)
            {
                textBoxCantidad.Enabled = true;

                // Habilita los RadioButtons
                btnG.Enabled = true;
                btnK.Enabled = true;

                btnG.Checked = true;
            }
            else
            {
                textBoxCantidad.Enabled = false;
                btnG.Enabled = false;
                btnK.Enabled = false;
            }
        }

        private void comboBoxProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProv.SelectedItem is Proveedor proveedor)
            {
                CargarCategoriasProveedor(proveedor.Id);
            }
            else
            {
                comboBoxCategoria.DataSource = null;
                comboBoxCategoria.Enabled = false;
            }
        }
    }
}
