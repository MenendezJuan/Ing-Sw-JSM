using BEs;
using BEs.Clases;
using BEs.Clases.Negocio.Compras;
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
    public partial class frmGestionCotizacionProductos : Form, IObservador
    {
        private BLL_COTIZACION _bllCotizacion;
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        public frmGestionCotizacionProductos()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            _bllCotizacion = new BLL_COTIZACION();
            ActualizarDataGridViewCotizacion();
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

        private void btnSolicitarCotizacion_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal pform = Owner as frmMenuPrincipal;
            frmGestionarEnvioCotizacion compraInsumo = new frmGestionarEnvioCotizacion();
            pform.AddOwnedForm(compraInsumo);
            pform.FormHijo(compraInsumo);
            this.Close();
        }

        private void frmGestionCompraProductos_Load(object sender, EventArgs e)
        {

        }

        private void ActualizarDataGridViewCotizacionRecibiendoLista(List<Cotizacion> cotizaciones)
        {
            dataGridViewCotizaciones.DataSource = null;
            dataGridViewDetalle.DataSource = null;

            // Asignar la lista de cotizaciones al DataGridView
            dataGridViewCotizaciones.DataSource = cotizaciones;

            // Ocultar columnas que no deseas mostrar
            dataGridViewCotizaciones.Columns["ProveedorId"].Visible = false;
            dataGridViewCotizaciones.Columns["Proveedor"].Visible = false; // Oculta la columna de objeto `Proveedor`

            // Ajustar el encabezado y la ubicación de la columna `DescripcionProveedor`
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].HeaderText = "Proveedor";
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].DisplayIndex = 2;

            // Configurar encabezados de otras columnas
            dataGridViewCotizaciones.Columns["FechaCotizacion"].HeaderText = "Fecha de Cotización";
            dataGridViewCotizaciones.Columns["EstadoCotizacionEnum"].HeaderText = "Estado";
        }


        private void ActualizarDataGridViewCotizacion()
        {
            dataGridViewCotizaciones.DataSource = null;
            List<Cotizacion> cotizaciones = _bllCotizacion.ObtenerTodos();

            // Asignar la lista de cotizaciones al DataGridView
            dataGridViewCotizaciones.DataSource = cotizaciones;

            // Ocultar columnas que no deseas mostrar
            dataGridViewCotizaciones.Columns["ProveedorId"].Visible = false;
            dataGridViewCotizaciones.Columns["Proveedor"].Visible = false; // Oculta la columna de objeto `Proveedor`

            // Ajustar el encabezado y la ubicación de la columna `DescripcionProveedor`
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].HeaderText = "Proveedor";
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].Tag = "Proveedor_Column";
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].DisplayIndex = 2;

            // Configurar encabezados de otras columnas
            dataGridViewCotizaciones.Columns["FechaCotizacion"].HeaderText = "Fecha de Cotización";
            dataGridViewCotizaciones.Columns["FechaCotizacion"].Tag = "FechaCotizacion_Column";
            dataGridViewCotizaciones.Columns["EstadoCotizacionEnum"].HeaderText = "Estado";
            dataGridViewCotizaciones.Columns["EstadoCotizacionEnum"].Tag = "Estado_Column";
        }

        private void dataGridViewCotizaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCotizaciones.SelectedRows.Count > 0)
            {
                var cotizacionSeleccionada = (Cotizacion)dataGridViewCotizaciones.SelectedRows[0].DataBoundItem;

                ActualizarDataGridViewDetalle(cotizacionSeleccionada.DetallesCotizacion);

                Actualizar(sesion.Idioma);

                labelEstado.Text = cotizacionSeleccionada.EstadoCotizacionEnum.ToString();
            }
        }

        private void ActualizarDataGridViewDetalle(List<DetalleCotizacion> detalles)
        {
            dataGridViewDetalle.DataSource = null;
            dataGridViewDetalle.DataSource = detalles;

            // Configurar las columnas visibles y sus encabezados
            dataGridViewDetalle.Columns["CotizacionId"].Visible = false;
            dataGridViewDetalle.Columns["ProductoId"].Visible = false;
            dataGridViewDetalle.Columns["oProducto"].Visible = false;

            dataGridViewDetalle.Columns["NombreProducto"].HeaderText = "Producto";
            dataGridViewDetalle.Columns["NombreProducto"].Tag = "Producto_Column";
            dataGridViewDetalle.Columns["Cantidad"].HeaderText = "Cantidad";
            dataGridViewDetalle.Columns["Cantidad"].Tag = "Cantidad_Column";
            dataGridViewDetalle.Columns["Fecha"].HeaderText = "Fecha de Solicitud";
            dataGridViewDetalle.Columns["Fecha"].Tag = "FechaSolicitud_Column";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime desde = dateTimePickerDesde.Value;
            DateTime hasta = dateTimePickerHasta.Value;

            // Obtener cotizaciones en el rango de fechas
            List<Cotizacion> cotizaciones = _bllCotizacion.ObtenerCotizacionesPorFecha(desde, hasta);
            ActualizarDataGridViewCotizacionRecibiendoLista(cotizaciones);
        }

        private void btnReestablecer_Click(object sender, EventArgs e)
        {
            // Limpiar los DateTimePicker
            dateTimePickerDesde.Value = DateTime.Now;
            dateTimePickerHasta.Value = DateTime.Now;

            // Volver a cargar todas las cotizaciones
            ActualizarDataGridViewCotizacion();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Cerrar();
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
    }
}
