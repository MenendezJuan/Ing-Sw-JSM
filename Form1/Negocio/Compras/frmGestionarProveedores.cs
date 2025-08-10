using BEs;
using BEs.Clases;
using BEs.Clases.Negocio;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using BLLs.Tecnica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix.Negocio
{
    public partial class frmGestionarProveedores : Form, IObservador
    {
        private BLL_PROVEEDOR _bllProveedor;
        private BLL_EXPORTACION _bllExportacion;
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        private Proveedor _proveedorSeleccionado;
        public frmGestionarProveedores()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            _bllProveedor = new BLL_PROVEEDOR();
            _bllExportacion = new BLL_EXPORTACION();
            CargarProveedores();
            CargarComboBuscar();
            panelDatosProv.Visible = false;
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            Proveedor proveedor = (btnAceptar.Tag.ToString() == "Actualizar") ? _proveedorSeleccionado : new Proveedor();
            MapearControlesAProveedor(proveedor);

            if (btnAceptar.Tag.ToString() == "Agregar")
            {
                proveedor.Estado = true;
                _bllProveedor.Insertar(proveedor);
                MessageBox.Show("Proveedor agregado correctamente.");
            }
            else if (btnAceptar.Tag.ToString() == "Actualizar")
            {
                proveedor.Estado = true;
                _bllProveedor.Actualizar(proveedor);
                MessageBox.Show("Proveedor actualizado correctamente.");
            }

            CargarProveedores();
            panelDatosProv.Visible = false;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewProveedor.DataSource == null)
                {
                    MessageBox.Show(ConstantesUI.Mensajes.NoHayDatosParaExportar, ConstantesUI.Titulos.Informacion, 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Convertir DataGridView a DataTable
                DataTable dtProveedores = ConvertirDataGridViewADataTable(dataGridViewProveedor);
                
                // Usar BLL_EXPORTACION para exportar
                string fileName = _bllExportacion.GenerarNombreArchivoUnico("InformacionProveedores");
                bool exportado = _bllExportacion.ExportarMultiplesDataTablesAExcel(fileName, 
                    (dtProveedores, ConstantesUI.Exportacion.HojaProveedores, ConstantesUI.Exportacion.TituloProveedores));

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void btnBorrarBusqueda_Click(object sender, EventArgs e)
        {
            try
            {
                txtBuscar.Clear();
                if (comboBuscar.Items.Count > 0) comboBuscar.SelectedIndex = -1;
                CargarProveedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al limpiar búsqueda: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string criterio = comboBuscar?.SelectedItem?.ToString() ?? string.Empty;
                string textoBusqueda = txtBuscar?.Text?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(criterio) || string.IsNullOrWhiteSpace(textoBusqueda))
                {
                    CargarProveedores();
                    return;
                }

                string mensajeError;
                if (!ValidarEntradaBusquedaProveedores(criterio, textoBusqueda, out mensajeError))
                {
                    MessageBox.Show(mensajeError, ConstantesUI.Titulos.Validacion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var proveedores = _bllProveedor.BuscarProveedores(criterio, textoBusqueda, incluirInactivos: true);
                dataGridViewProveedor.DataSource = proveedores;
                Actualizar(sesion.Idioma);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar proveedores: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrarIngresoDatos_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        #region MetodosPrivados
        private void LimpiarControles()
        {
            txtCuit.Clear();
            txtDireccion.Clear();
            txtDescripcion.Clear();
            txtTelefono.Clear();
            textBoxEmail.Clear();
            lblSeleccionadoEspecifico.Text = string.Empty;
        }

        private void CargarComboBuscar()
        {
            comboBuscar.Items.Clear();
            comboBuscar.Items.Add("CUIT");
            comboBuscar.Items.Add("Descripcion");
            comboBuscar.Items.Add("Direccion");
            comboBuscar.Items.Add("Email");
            comboBuscar.Items.Add("Telefono");
            comboBuscar.Items.Add("Estado");

            if (comboBuscar.Items.Count > 0)
                comboBuscar.SelectedIndex = 0;
        }

        private bool ValidarEntradaBusquedaProveedores(string criterio, string texto, out string mensajeError)
        {
            mensajeError = string.Empty;
            if (string.IsNullOrWhiteSpace(criterio)) { mensajeError = ConstantesUI.Validaciones.SeleccioneCriterioBusqueda; return false; }
            if (string.IsNullOrWhiteSpace(texto)) { mensajeError = ConstantesUI.Validaciones.IngreseTextoBusqueda; return false; }

            string crit = criterio.Trim().ToLowerInvariant();
            string val = texto.Trim();
            string valNorm = val.ToLowerInvariant();

            switch (crit)
            {
                case "cuit":
                    string limpio = val.Replace("-", string.Empty).Replace(" ", string.Empty);
                    if (!limpio.All(char.IsDigit)) { mensajeError = ConstantesUI.Validaciones.CUITSoloNumeros; return false; }
                    if (limpio.Length < 4) { mensajeError = ConstantesUI.Validaciones.IngreseAlMenos4Cuit; return false; }
                    return true;
                case "email":
                    if (val.Length < 3) { mensajeError = ConstantesUI.Validaciones.IngreseAlMenos3Email; return false; }
                    if (val.Contains("@") && !BLL_VALIDACION.ValidarEmail(val)) { mensajeError = ConstantesUI.Validaciones.EmailNoValido; return false; }
                    return true;
                case "telefono":
                case "teléfono":
                    if (val.Length < 4) { mensajeError = ConstantesUI.Validaciones.IngreseAlMenos4Telefono; return false; }
                    return true;
                case "estado":
                    var aceptados = new[] { "activo", "inactivo", "true", "false", "1", "0" };
                    if (!aceptados.Contains(valNorm)) { mensajeError = ConstantesUI.Validaciones.EstadoInvalido; return false; }
                    return true;
                case "descripcion":
                case "direccion":
                    if (val.Length < 2) { mensajeError = ConstantesUI.Validaciones.IngreseAlMenos2; return false; }
                    return true;
                default:
                    return true;
            }
        }

        private void MapearProveedorAControles(Proveedor proveedor)
        {
            txtCuit.Text = proveedor.CUIT;
            txtDescripcion.Text = proveedor.Descripcion;
            txtDireccion.Text = proveedor.Direccion;
            txtTelefono.Text = proveedor.Telefono;
            textBoxEmail.Text = proveedor.Mail;
            lblSeleccionadoEspecifico.Text = proveedor.Descripcion;
        }

        private void MapearControlesAProveedor(Proveedor proveedor)
        {
            proveedor.CUIT = txtCuit.Text;
            proveedor.Descripcion = txtDescripcion.Text;
            proveedor.Direccion = txtDireccion.Text;
            proveedor.Telefono = txtTelefono.Text;
            proveedor.Mail = textBoxEmail.Text;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCuit.Text))
            {
                MessageBox.Show(ConstantesUI.Plantillas.Ingrese("un CUIT para el proveedor"));
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show(ConstantesUI.Plantillas.Ingrese("una descripcion para el proveedor"));
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show(ConstantesUI.Plantillas.Ingrese("una direccion para el proveedor"));
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show(ConstantesUI.Plantillas.Ingrese("un telefono para el proveedor"));
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show(ConstantesUI.Plantillas.Ingrese("un mail para el proveedor"));
                return false;
            }

            return true;
        }

        private void CargarProveedores()
        {
            var proveedores = _bllProveedor.ObtenerTodos();
            dataGridViewProveedor.DataSource = proveedores;
            if (dataGridViewProveedor.Columns["Estado"] != null)
                dataGridViewProveedor.Columns["Estado"].Visible = false;

            dataGridViewProveedor.Columns["CUIT"].HeaderText = "C.U.I.T";
            dataGridViewProveedor.Columns["CUIT"].Tag = "CUIT_column";

            dataGridViewProveedor.Columns["Descripcion"].HeaderText = "Descripcion";
            dataGridViewProveedor.Columns["Descripcion"].Tag = "Descripcion_Column";

            dataGridViewProveedor.Columns["Direccion"].HeaderText = "Direccion";
            dataGridViewProveedor.Columns["Direccion"].Tag = "Direccion_column";

            dataGridViewProveedor.Columns["Mail"].HeaderText = "Email";
            dataGridViewProveedor.Columns["Mail"].Tag = "Mail_column";

            dataGridViewProveedor.Columns["Telefono"].HeaderText = "Telefono";
            dataGridViewProveedor.Columns["Telefono"].Tag = "Telefono_column";

            dataGridViewProveedor.Columns["FechaRegistro"].HeaderText = "Fecha de Registro";
            dataGridViewProveedor.Columns["FechaRegistro"].Tag = "FechaRegistro_Column";

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
        #endregion

        private void buttonAgregarProveedor_Click(object sender, EventArgs e)
        {
            panelDatosProv.Visible = true;
            txtCuit.ReadOnly = false;
            lblSeleccionado.Visible = false;
            lblSeleccionadoEspecifico.Visible = false;
            LimpiarControles();
            _proveedorSeleccionado = null;
            btnAceptar.Tag = "Agregar";
        }

        private void buttonActualizarProveedor_Click(object sender, EventArgs e)
        {
            if (_proveedorSeleccionado == null)
            {
                MessageBox.Show(ConstantesUI.Plantillas.Seleccione("un proveedor para actualizar"));
                return;
            }

            if (!_proveedorSeleccionado.Estado)
            {
                MessageBox.Show(ConstantesUI.Plantillas.NoPuedeActualizarInactivo("proveedor"));
                return;
            }

            panelDatosProv.Visible = true;
            txtCuit.ReadOnly = true;
            lblSeleccionado.Visible = true;
            lblSeleccionadoEspecifico.Visible = true;
            lblSeleccionadoEspecifico.Text = _proveedorSeleccionado.Descripcion;


            MapearProveedorAControles(_proveedorSeleccionado);
            btnAceptar.Tag = "Actualizar";
        }

        private void buttonEliminarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (_proveedorSeleccionado != null)
                {
                    if (!_proveedorSeleccionado.Estado)
                    {
                        MessageBox.Show(ConstantesUI.Plantillas.NoPuedeActualizarInactivo("proveedor"));
                        return;
                    }
                    DialogResult resultado = MessageBox.Show(
                        ConstantesUI.Plantillas.ConfirmarEliminacion("proveedor"),
                        ConstantesUI.Titulos.Confirmacion,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (resultado == DialogResult.Yes)
                    {
                        _bllProveedor.Eliminar(_proveedorSeleccionado.Id);
                        CargarProveedores();
                        MessageBox.Show(ConstantesUI.Plantillas.EliminadoCorrectamente("Proveedor"));
                        _proveedorSeleccionado = null;
                    }
                }
                else
                {
                    MessageBox.Show(ConstantesUI.Plantillas.Seleccione("un proveedor para eliminar"));
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmGestionarProveedores_Load(object sender, EventArgs e)
        {

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

        private void buttonReactivacionProv_Click(object sender, EventArgs e)
        {
            CargarProveedoresInactivosEnGrid();
        }

        #region

        private void CargarProveedoresInactivosEnGrid()
        {
            var proveedoresInactivos = _bllProveedor.ObtenerProveedoresInactivos();
            if (proveedoresInactivos != null && proveedoresInactivos.Count > 0)
            {
                dataGridViewProveedor.DataSource = proveedoresInactivos;
                OcultarControlesNormalesSinMover();
            }
            else
            {
                MessageBox.Show("No hay productos inactivos para mostrar.");
                MostrarControlesNormales();
            }
        }

        private void ReactivarProveedorSeleccionado()
        {
            if (dataGridViewProveedor.SelectedRows.Count > 0)
            {
                var proveedorSeleccionado = (Proveedor)dataGridViewProveedor.SelectedRows[0].DataBoundItem;

                try
                {
                    proveedorSeleccionado.Estado = true;
                    _bllProveedor.Reactivar(proveedorSeleccionado.Id);

                    MessageBox.Show($"El proveedor '{proveedorSeleccionado.Descripcion}' ha sido reactivado.");

                    // Volver a cargar la vista normal
                    CargarProveedores();
                    MostrarControlesNormales();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al reactivar el proveedor: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proveedor inactivo para reactivar.");
            }
        }
        private void OcultarControlesNormalesSinMover()
        {
            buttonAgregarProveedor.Enabled = false;
            buttonActualizarProveedor.Enabled = false;
            buttonEliminarProveedor.Enabled = false;
            btnExportar.Enabled = false;
            btnRefresh.Enabled = false;
            panelDatosProv.Enabled = false;
            panelDatosFiltrar.Enabled = false;
            btnReactivarProveedor.Enabled = true;
        }

        private void MostrarControlesNormales()
        {
            buttonAgregarProveedor.Enabled = true;
            buttonActualizarProveedor.Enabled = true;
            buttonEliminarProveedor.Enabled = true;
            btnExportar.Enabled = true;
            btnRefresh.Enabled = true;
            panelDatosProv.Enabled = true;
            panelDatosFiltrar.Enabled = true;
            btnReactivarProveedor.Enabled = false;
        }
        #endregion

        private void btnReactivarProveedor_Click(object sender, EventArgs e)
        {
            ReactivarProveedorSeleccionado();
        }

        private void dataGridViewProveedor_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProveedor.SelectedRows.Count > 0)
            {
                var item = dataGridViewProveedor.SelectedRows[0].DataBoundItem as Proveedor;

                if (item != null)
                {
                    _proveedorSeleccionado = item;
                    lblSeleccionado.Visible = true;
                    lblSeleccionadoEspecifico.Visible = true;
                    lblSeleccionadoEspecifico.Text = item.Descripcion;

                    MapearProveedorAControles(_proveedorSeleccionado);
                }
            }
            else
            {
                _proveedorSeleccionado = null;
                lblSeleccionado.Visible = false;
                lblSeleccionadoEspecifico.Visible = false;
                LimpiarControles();
            }
        }

        private void dataGridViewProveedor_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dataGridViewProveedor.Rows[e.RowIndex];
            bool estado = Convert.ToBoolean(row.Cells["Estado"].Value);

            if (!estado)
            {
                row.DefaultCellStyle.BackColor = Color.Gray;
                row.DefaultCellStyle.ForeColor = Color.White;
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

        private void dataGridViewProveedor_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RecorrerDataGridTraduccion(sesion.Idioma);
        }
    }
}

