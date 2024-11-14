using BEs;
using BEs.Clases;
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

namespace Form1
{
    public partial class frmControlSolicitudesCotizacion : Form, IObservador
    {
        private BLL_COTIZACION _bllCotizacion;
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        public frmControlSolicitudesCotizacion()
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
            _bllCotizacion = new BLL_COTIZACION();
        }

        private void frmControlSolicitudesCotizacion_Load(object sender, EventArgs e)
        {
            CargarCotizacionesPorEstado();
        }

        private void btnAprobSolicitud_Click(object sender, EventArgs e)
        {
            CambiarEstadoCotizacionSeleccionada(EstadoCotizacion.Aprobada);
        }

        private void btnRechSolicitud_Click(object sender, EventArgs e)
        {
            CambiarEstadoCotizacionSeleccionada(EstadoCotizacion.Rechazada);
        }

        #region MetodosPrivados

        private void CargarCotizacionesPorEstado()
        {
            List<Cotizacion> cotizaciones;

            if (rbPendiente.Checked)
            {
                cotizaciones = _bllCotizacion.ObtenerPorEstado(EstadoCotizacion.Pendiente);

                int solicitudesPendientes = cotizaciones.Count;

                labelNotificacion.Text = $"Atención: {solicitudesPendientes} Ordenes pendientes de aprobación.";
            }
            else if (rbFinalizado.Checked)
            {
                cotizaciones = _bllCotizacion.ObtenerPorEstados(new List<EstadoCotizacion>
                {
                    EstadoCotizacion.Aprobada,
                    EstadoCotizacion.Rechazada
                });
            }
            else
            {
                cotizaciones = new List<Cotizacion>();
            }

            dataGridViewCotizaciones.DataSource = cotizaciones;
            dataGridViewCotizaciones.ClearSelection();
            ActualizarDataGridViewCotizacionRecibiendoLista(cotizaciones);
        }

        private void ActualizarDataGridViewCotizacionRecibiendoLista(List<Cotizacion> cotizaciones)
        {
            dataGridViewCotizaciones.DataSource = null;
            dataGridViewDetalleCotizacion.DataSource = null;

            dataGridViewCotizaciones.DataSource = cotizaciones;

            dataGridViewCotizaciones.Columns["ProveedorId"].Visible = false;
            dataGridViewCotizaciones.Columns["Proveedor"].Visible = false;

            dataGridViewCotizaciones.Columns["DescripcionProveedor"].HeaderText = "Proveedor";
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].DisplayIndex = 2;

            dataGridViewCotizaciones.Columns["FechaCotizacion"].HeaderText = "Fecha de Cotización";
            dataGridViewCotizaciones.Columns["EstadoCotizacionEnum"].HeaderText = "Estado";
        }

        private void CargarDetallesCotizacion(int cotizacionId)
        {
            Cotizacion cotizacion = _bllCotizacion.ObtenerPorId(cotizacionId);
            if (cotizacion != null)
            {
                ActualizarDataGridViewDetalle(cotizacion.DetallesCotizacion);
            }
        }

        private void CambiarEstadoCotizacionSeleccionada(EstadoCotizacion nuevoEstado)
        {
            if (dataGridViewCotizaciones.SelectedRows.Count > 0)
            {
                int cotizacionId = (int)dataGridViewCotizaciones.SelectedRows[0].Cells["Id"].Value;
                try
                {
                    bool exito = _bllCotizacion.EvaluarYActualizarEstadoCotizacion(cotizacionId, nuevoEstado);

                    if (exito)
                    {
                        MessageBox.Show($"Cotización {nuevoEstado} exitosamente.", "Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCotizacionesPorEstado();
                    }
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo cambiar el estado de la cotización. Error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una cotización primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarCotizaciones()
        {
            List<Cotizacion> cotizaciones = _bllCotizacion.ObtenerTodos();
            dataGridViewCotizaciones.DataSource = cotizaciones;
            dataGridViewCotizaciones.ClearSelection();
        }

        private void ActualizarDataGridViewCotizacion()
        {
            dataGridViewCotizaciones.DataSource = null;
            List<Cotizacion> cotizaciones = _bllCotizacion.ObtenerTodos();
            dataGridViewCotizaciones.DataSource = cotizaciones;
            ConfigurarColumnasCotizacion();
        }

        private void ConfigurarColumnasCotizacion()
        {
            dataGridViewCotizaciones.Columns["ProveedorId"].Visible = false;
            dataGridViewCotizaciones.Columns["Proveedor"].Visible = false;

            dataGridViewCotizaciones.Columns["DescripcionProveedor"].HeaderText = "Proveedor";
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].DisplayIndex = 2;
            dataGridViewCotizaciones.Columns["FechaCotizacion"].HeaderText = "Fecha de Cotización";
            dataGridViewCotizaciones.Columns["EstadoCotizacionEnum"].HeaderText = "Estado";
        }

        private void ActualizarDataGridViewDetalle(List<DetalleCotizacion> detalles)
        {
            dataGridViewDetalleCotizacion.DataSource = null;
            dataGridViewDetalleCotizacion.DataSource = detalles;

            dataGridViewDetalleCotizacion.Columns["CotizacionId"].Visible = false;
            dataGridViewDetalleCotizacion.Columns["ProductoId"].Visible = false;
            dataGridViewDetalleCotizacion.Columns["oProducto"].Visible = false;

            dataGridViewDetalleCotizacion.Columns["NombreProducto"].HeaderText = "Producto";
            dataGridViewDetalleCotizacion.Columns["Cantidad"].HeaderText = "Cantidad";
            dataGridViewDetalleCotizacion.Columns["Fecha"].HeaderText = "Fecha de Solicitud";
        }

        #endregion

        private void dataGridViewCotizaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCotizaciones.SelectedRows.Count > 0)
            {
                int cotizacionId = (int)dataGridViewCotizaciones.SelectedRows[0].Cells["Id"].Value;
                CargarDetallesCotizacion(cotizacionId);
            }
        }

        private void rbPendiente_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPendiente.Checked)
            {
                CargarCotizacionesPorEstado();
            }
        }

        private void rbFinalizado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFinalizado.Checked)
            {
                CargarCotizacionesPorEstado();
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Cerrar();
        }
    }
}

