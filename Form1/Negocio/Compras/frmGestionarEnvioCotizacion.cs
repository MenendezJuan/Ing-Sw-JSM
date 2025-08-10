using BEs;
using BEs.Clases;
using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Compras;
using BEs.Clases.Negocio.Enums;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix
{
    public partial class frmGestionarEnvioCotizacion : Form, IObservador
    {
        private List<DetalleCotizacion> _detallesCotizacion;
        private Cotizacion _cotizacion;
        private BLL_PRODUCTO _bllProducto;
        private BLL_PROVEEDOR _bllProveedor;
        private BLL_COTIZACION _bllCotizacion;
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;

        public frmGestionarEnvioCotizacion()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            _detallesCotizacion = new List<DetalleCotizacion>();
            _cotizacion = new Cotizacion();
            _bllProducto = new BLL_PRODUCTO();
            _bllProveedor = new BLL_PROVEEDOR();
            _bllCotizacion = new BLL_COTIZACION();
            CargarProveedores();

            if (comboBoxProv.SelectedItem is Proveedor proveedor)
            {
                CargarCategoriasProveedor(proveedor.Id);
            }

            llenarDataGridCotizaciones();
            ActualizarDataGridViewDetalles();
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

        private void buttonEnviarSolicitudCotizacion_Click(object sender, EventArgs e)
        {
            if (comboBoxProv.SelectedValue == null)
            {
                MessageBox.Show(BLLs.Tecnica.ConstantesUI.Plantillas.Seleccione("un proveedor"));
                return;
            }

            if (dataGridViewLista.Rows.Count == 0)
            {
                MessageBox.Show(BLLs.Tecnica.ConstantesUI.Plantillas.NoHayInactivosParaMostrar("detalles para enviar"), BLLs.Tecnica.ConstantesUI.Titulos.Informacion);
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
            MessageBox.Show($"Cotización enviada al proveedor {comboBoxProv.Text}, exitosamente.", BLLs.Tecnica.ConstantesUI.Titulos.Informacion);
            llenarDataGridCotizaciones();
            LimpiarFormulario();
        }

        private void btnAgregarALista_Click(object sender, EventArgs e)
        {
            if (comboBoxProducto.SelectedItem == null)
            {
                MessageBox.Show(BLLs.Tecnica.ConstantesUI.Plantillas.Seleccione("un producto"));
                return;
            }

            if (!decimal.TryParse(textBoxCantidad.Text, out decimal cantidad) || cantidad <= 0)
            {
                MessageBox.Show(BLLs.Tecnica.ConstantesUI.Plantillas.Ingrese("una cantidad válida"));
                return;
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
            if (dataGridViewLista.Rows.Count <= 0)
            {
                MessageBox.Show("Debes cargar items primero.", BLLs.Tecnica.ConstantesUI.Titulos.Informacion);
                return;
            }

            if (dataGridViewLista.SelectedRows.Count > 0)
            {
                dataGridViewLista.Rows.RemoveAt(dataGridViewLista.SelectedRows[0].Index);

                if (dataGridViewLista.Rows.Count <= 0)
                {
                    buttonEnviarSolicitudCotizacion.Enabled = false;
                    buttonCancelarSolicitudCotizacion.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show(BLLs.Tecnica.ConstantesUI.Plantillas.Seleccione("un elemento para eliminar"));
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
            dataGridViewLista.Columns["ProductoId"].Tag = "ProductoId_Column";
            dataGridViewLista.Columns.Add("Nombre", "Nombre del Producto");
            dataGridViewLista.Columns["Nombre"].Tag = "Producto_Column";
            dataGridViewLista.Columns.Add("Cantidad", "Cantidad");
            dataGridViewLista.Columns["Cantidad"].Tag = "Cantidad_Column";


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

        private void llenarDataGridCotizaciones()
        {
            dataGridViewCotizaciones.DataSource = null;
            var cotizaciones = _bllCotizacion.ObtenerPorEstado(EstadoCotizacion.Pendiente);
            dataGridViewCotizaciones.DataSource = cotizaciones;

            // Ocultar columnas que no deseas mostrar
            dataGridViewCotizaciones.Columns["ProveedorId"].Visible = false;
            dataGridViewCotizaciones.Columns["Proveedor"].Visible = false;

            // Ajustar el encabezado y la ubicación de la columna `DescripcionProveedor`
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].HeaderText = "Proveedor";
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].Tag = "Proveedor_Column";
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].DisplayIndex = 2;

            dataGridViewCotizaciones.Columns["Id"].HeaderText = "Nro. Cotizacion";
            dataGridViewCotizaciones.Columns["Id"].Tag = "Nro.Cotizacion_Column";


            // Configurar encabezados de otras columnas
            dataGridViewCotizaciones.Columns["FechaCotizacion"].HeaderText = "Fecha de Cotización";
            dataGridViewCotizaciones.Columns["FechaCotizacion"].Tag = "FechaCotizacion_Column";
            dataGridViewCotizaciones.Columns["EstadoCotizacionEnum"].HeaderText = "Estado";
            dataGridViewCotizaciones.Columns["EstadoCotizacionEnum"].Tag = "Estado_Column";
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

        }

        private void comboBoxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProducto.SelectedValue != null)
            {
                textBoxCantidad.Enabled = true;
            }
            else
            {
                textBoxCantidad.Enabled = false;
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
                MessageBox.Show($"Error al cargar los idiomas: {ex.Message}", BLLs.Tecnica.ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error al actualizar los textos de los controles: {ex.Message}", BLLs.Tecnica.ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
