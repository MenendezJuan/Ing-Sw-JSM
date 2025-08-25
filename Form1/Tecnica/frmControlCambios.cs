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
            _bllUsuario = new BLL_USUARIO();
            _bllProducto = new BLL_PRODUCTO();
            _bllVenta = new BLL_VENTA();
            _bllControlCambios = new BLL_CONTROLCAMBIOS();

            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();

            CargarTiposEntidad();
            ActualizarEntidades();

            // Configurar idiomas y permisos
            sesion.RegistrarObservador(this);
            IIdioma oIdioma = sesion.Idioma;
            CargarIdiomas();
            BuscarControles(this.Controls);
            Actualizar(oIdioma);
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
                comboTipoEntidad.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de entidad: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboTipoEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTipoEntidad.SelectedValue != null)
            {
                _tipoEntidadActual = comboTipoEntidad.SelectedValue.ToString();
                ActualizarEntidades();
                LimpiarHistorial();
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
                        var usuarios = _bllUsuario.Listar();
                        dataGridEntidades.DataSource = usuarios;
                        ConfigurarColumnas_Usuario();
                        break;

                    case "Producto":
                        var productos = _bllProducto.ObtenerTodos();
                        dataGridEntidades.DataSource = productos;
                        ConfigurarColumnas_Producto();
                        break;

                    case "Venta":
                        var ventas = _bllVenta.ObtenerTodos();
                        dataGridEntidades.DataSource = ventas;
                        ConfigurarColumnas_Venta();
                        break;
                }

                lblEntidadSeleccionada.Text = $"Entidades: {_tipoEntidadActual}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar entidades: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Configuración de Columnas

        private void ConfigurarColumnas_Usuario()
        {
            if (dataGridEntidades.Columns.Count > 0)
            {
                dataGridEntidades.Columns["Email"].HeaderText = "Email";
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

        #endregion

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

                // Obtener ID según el tipo
                switch (_tipoEntidadActual)
                {
                    case "Usuario":
                        entidadId = ((Usuario)_entidadSeleccionada).Id;
                        break;
                    case "Producto":
                        entidadId = ((BEs.Clases.Negocio.Producto)_entidadSeleccionada).Id;
                        break;
                    case "Venta":
                        entidadId = ((BEs.Clases.Negocio.Ventas.Venta)_entidadSeleccionada).Id;
                        break;
                }

                // Cargar historial específico
                var historial = _bllControlCambios.ObtenerHistorialEntidad(tipoEntidad, entidadId);
                dataGridHistorial.DataSource = historial;

                ConfigurarColumnasHistorial();
                lblHistorialInfo.Text = $"Historial de {tipoEntidad} ID: {entidadId} ({historial.Rows.Count} registros)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar historial: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarHistorial();
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
                if (dataGridHistorial.Columns.Contains("DigitoVerificador"))
                    dataGridHistorial.Columns["DigitoVerificador"].Visible = false;

                // Específicos por entidad
                switch (_tipoEntidadActual)
                {
                    case "Usuario":
                        if (dataGridHistorial.Columns.Contains("Email"))
                            dataGridHistorial.Columns["Email"].HeaderText = "Email";
                        if (dataGridHistorial.Columns.Contains("Fecha"))
                            dataGridHistorial.Columns["Fecha"].HeaderText = "Fecha Registro";
                        if (dataGridHistorial.Columns.Contains("DV"))
                            dataGridHistorial.Columns["DV"].Visible = false;
                        break;

                    case "Producto":
                        if (dataGridHistorial.Columns.Contains("ProductoId"))
                            dataGridHistorial.Columns["ProductoId"].HeaderText = "Producto ID";
                        if (dataGridHistorial.Columns.Contains("Codigo"))
                            dataGridHistorial.Columns["Codigo"].HeaderText = "Código";
                        if (dataGridHistorial.Columns.Contains("Nombre"))
                            dataGridHistorial.Columns["Nombre"].HeaderText = "Nombre";
                        break;

                    case "Venta":
                        if (dataGridHistorial.Columns.Contains("VentaId"))
                            dataGridHistorial.Columns["VentaId"].HeaderText = "Venta ID";
                        if (dataGridHistorial.Columns.Contains("MontoTotal"))
                            dataGridHistorial.Columns["MontoTotal"].HeaderText = "Monto";
                        if (dataGridHistorial.Columns.Contains("EstadoVenta"))
                            dataGridHistorial.Columns["EstadoVenta"].HeaderText = "Estado";
                        break;
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

        private void LimpiarHistorial()
        {
            dataGridHistorial.DataSource = null;
            _historialSeleccionado = null;
            btnRestaurar.Enabled = false;
            lblHistorialInfo.Text = "Seleccione una entidad para ver su historial";
        }

        #endregion

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
            // Obtener ID del historial usando reflexión
            var idProperty = historialItem.GetType().GetProperty("Id");
            if (idProperty != null)
            {
                return (int)idProperty.GetValue(historialItem);
            }
            throw new InvalidOperationException("No se pudo obtener el ID del historial");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            sesion.DesregistrarObservador(this);
            this.Close();
        }

        #endregion

        #region Idiomas y Permisos

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

        #endregion
    }
}
