﻿using BEs;
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

namespace Form1
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
            ActualizarDataGridViewCotizacion();
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
            dataGridViewCotizaciones.Columns["DescripcionProveedor"].DisplayIndex = 2;

            // Configurar encabezados de otras columnas
            dataGridViewCotizaciones.Columns["FechaCotizacion"].HeaderText = "Fecha de Cotización";
            dataGridViewCotizaciones.Columns["EstadoCotizacionEnum"].HeaderText = "Estado";
        }

        private void dataGridViewCotizaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCotizaciones.SelectedRows.Count > 0)
            {
                // Obtener la cotización seleccionada
                var cotizacionSeleccionada = (Cotizacion)dataGridViewCotizaciones.SelectedRows[0].DataBoundItem;

                // Mostrar los detalles en dataGridViewDetalle
                ActualizarDataGridViewDetalle(cotizacionSeleccionada.DetallesCotizacion);

                // Mostrar el estado en el labelEstado
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
            dataGridViewDetalle.Columns["Cantidad"].HeaderText = "Cantidad";
            dataGridViewDetalle.Columns["Fecha"].HeaderText = "Fecha de Solicitud";
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
