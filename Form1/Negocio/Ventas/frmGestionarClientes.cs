using BEs;
using BEs.Clases;
using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Ventas;
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

namespace CheeseLogix.Negocio.Ventas
{
    public partial class frmGestionarClientes : Form, IObservador
    {
        private BLL_CLIENTE _bllCliente;
        private BLL_EXPORTACION _bllExportacion;
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        private Cliente _clienteSeleccionado;

        public frmGestionarClientes()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            _bllCliente = new BLL_CLIENTE();
            _bllExportacion = new BLL_EXPORTACION();
            CargarClientes();
            panelDatosCliente.Visible = false;
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

            Cliente cliente = (btnAceptar.Tag.ToString() == "Actualizar") ? _clienteSeleccionado : new Cliente();
            MapearControlesACliente(cliente);

            if (btnAceptar.Tag.ToString() == "Agregar")
            {
                cliente.Estado = true;
                _bllCliente.Insertar(cliente);
                MessageBox.Show("Cliente agregado correctamente.");
            }
            else if (btnAceptar.Tag.ToString() == "Actualizar")
            {
                cliente.Estado = true;
                _bllCliente.Actualizar(cliente);
                MessageBox.Show("Cliente actualizado correctamente.");
            }

            CargarClientes();
            panelDatosCliente.Visible = false;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewCliente.DataSource == null)
                {
                    MessageBox.Show("No hay datos para exportar.", "Información", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Convertir DataGridView a DataTable
                DataTable dtClientes = ConvertirDataGridViewADataTable(dataGridViewCliente);
                
                // Usar BLL_EXPORTACION para exportar
                string fileName = _bllExportacion.GenerarNombreArchivoUnico("InformacionClientes");
                bool exportado = _bllExportacion.ExportarMultiplesDataTablesAExcel(fileName, 
                    (dtClientes, "Clientes", "Información de Clientes - CheeseLogix"));

                if (exportado)
                {
                    string rutaCompleta = System.IO.Path.Combine(BLL_CONFIGURACION.ObtenerDirectorioReporteria(), fileName + ".xlsx");
                    MessageBox.Show($"Archivo exportado correctamente a: {rutaCompleta}", 
                        "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Preguntar si quiere abrir el archivo
                    DialogResult result = MessageBox.Show("¿Desea abrir el archivo exportado?", 
                        "Abrir Archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                    if (result == DialogResult.Yes)
                    {
                        _bllExportacion.AbrirArchivo(rutaCompleta);
                    }
                }
                else
                {
                    MessageBox.Show("Error al exportar el archivo.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la exportación: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btnBorrarBusqueda_Click(object sender, EventArgs e)
        {
            // Limpiar filtros de búsqueda y recargar todos los clientes
            CargarClientes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Implementar lógica de búsqueda si hay controles de filtro
            // Por ahora recarga todos los clientes
            CargarClientes();
        }

        private void btnBorrarIngresoDatos_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        #region MetodosPrivados
        private void LimpiarControles()
        {
            txtCuit.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            textBoxEmail.Clear();
            lblSeleccionadoEspecifico.Text = string.Empty;
        }

        private void MapearClienteAControles(Cliente cliente)
        {
            txtCuit.Text = cliente.CUIT;
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtDireccion.Text = cliente.Direccion;
            txtTelefono.Text = cliente.Telefono;
            textBoxEmail.Text = cliente.Mail;
            lblSeleccionadoEspecifico.Text = cliente.NombreCompleto;
        }

        private void MapearControlesACliente(Cliente cliente)
        {
            cliente.CUIT = txtCuit.Text;
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Mail = textBoxEmail.Text;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCuit.Text))
            {
                MessageBox.Show("Por favor, ingrese un CUIT para el cliente.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre para el cliente.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Por favor, ingrese un apellido para el cliente.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Por favor, ingrese una dirección para el cliente.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Por favor, ingrese un teléfono para el cliente.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Por favor, ingrese un email para el cliente.");
                return false;
            }

            return true;
        }

        private void CargarClientes()
        {
            var clientes = _bllCliente.ObtenerTodos();
            dataGridViewCliente.DataSource = clientes;
            
            if (dataGridViewCliente.Columns["Estado"] != null)
                dataGridViewCliente.Columns["Estado"].Visible = false;

            dataGridViewCliente.Columns["CUIT"].HeaderText = "C.U.I.T";
            dataGridViewCliente.Columns["CUIT"].Tag = "CUIT_column";

            dataGridViewCliente.Columns["Nombre"].HeaderText = "Nombre";
            dataGridViewCliente.Columns["Nombre"].Tag = "Nombre_Column";

            dataGridViewCliente.Columns["Apellido"].HeaderText = "Apellido";
            dataGridViewCliente.Columns["Apellido"].Tag = "Apellido_column";

            dataGridViewCliente.Columns["Direccion"].HeaderText = "Dirección";
            dataGridViewCliente.Columns["Direccion"].Tag = "Direccion_column";

            dataGridViewCliente.Columns["Mail"].HeaderText = "Email";
            dataGridViewCliente.Columns["Mail"].Tag = "Mail_column";

            dataGridViewCliente.Columns["Telefono"].HeaderText = "Teléfono";
            dataGridViewCliente.Columns["Telefono"].Tag = "Telefono_column";

            dataGridViewCliente.Columns["FechaRegistro"].HeaderText = "Fecha de Registro";
            dataGridViewCliente.Columns["FechaRegistro"].Tag = "FechaRegistro_Column";
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

        private void buttonAgregarCliente_Click(object sender, EventArgs e)
        {
            panelDatosCliente.Visible = true;
            txtCuit.ReadOnly = false;
            lblSeleccionado.Visible = false;
            lblSeleccionadoEspecifico.Visible = false;
            LimpiarControles();
            _clienteSeleccionado = null;
            btnAceptar.Tag = "Agregar";
        }

        private void buttonActualizarCliente_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente para actualizar.");
                return;
            }

            if (!_clienteSeleccionado.Estado)
            {
                MessageBox.Show("No se puede actualizar un cliente inactivo.");
                return;
            }

            panelDatosCliente.Visible = true;
            txtCuit.ReadOnly = true;
            lblSeleccionado.Visible = true;
            lblSeleccionadoEspecifico.Visible = true;
            lblSeleccionadoEspecifico.Text = _clienteSeleccionado.NombreCompleto;

            MapearClienteAControles(_clienteSeleccionado);
            btnAceptar.Tag = "Actualizar";
        }

        private void buttonEliminarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (_clienteSeleccionado != null)
                {
                    if (!_clienteSeleccionado.Estado)
                    {
                        MessageBox.Show("No se puede eliminar un cliente inactivo.");
                        return;
                    }
                    DialogResult resultado = MessageBox.Show(
                        "¿Estás seguro de que deseas eliminar este cliente?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (resultado == DialogResult.Yes)
                    {
                        _bllCliente.Eliminar(_clienteSeleccionado.Id);
                        CargarClientes();
                        MessageBox.Show("Cliente eliminado correctamente.");
                        _clienteSeleccionado = null;
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona un cliente para eliminar.");
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmGestionarClientes_Load(object sender, EventArgs e)
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

        private void buttonReactivacionCliente_Click(object sender, EventArgs e)
        {
            CargarClientesInactivosEnGrid();
        }

        #region Reactivacion
        private void CargarClientesInactivosEnGrid()
        {
            var clientesInactivos = _bllCliente.ObtenerClientesInactivos();
            if (clientesInactivos != null && clientesInactivos.Count > 0)
            {
                dataGridViewCliente.DataSource = clientesInactivos;
                OcultarControlesNormalesSinMover();
            }
            else
            {
                MessageBox.Show("No hay clientes inactivos para mostrar.");
                MostrarControlesNormales();
            }
        }

        private void ReactivarClienteSeleccionado()
        {
            if (dataGridViewCliente.SelectedRows.Count > 0)
            {
                var clienteSeleccionado = (Cliente)dataGridViewCliente.SelectedRows[0].DataBoundItem;

                try
                {
                    clienteSeleccionado.Estado = true;
                    _bllCliente.ReactivarCliente(clienteSeleccionado.Id);

                    MessageBox.Show($"El cliente '{clienteSeleccionado.NombreCompleto}' ha sido reactivado.");

                    // Volver a cargar la vista normal
                    CargarClientes();
                    MostrarControlesNormales();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al reactivar el cliente: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente inactivo para reactivar.");
            }
        }

        private void OcultarControlesNormalesSinMover()
        {
            buttonAgregarCliente.Enabled = false;
            buttonActualizarCliente.Enabled = false;
            buttonEliminarCliente.Enabled = false;
            btnExportar.Enabled = false;
            btnRefresh.Enabled = false;
            panelDatosCliente.Enabled = false;
            panelDatosFiltrar.Enabled = false;
            btnReactivarCliente.Enabled = true;
        }

        private void MostrarControlesNormales()
        {
            buttonAgregarCliente.Enabled = true;
            buttonActualizarCliente.Enabled = true;
            buttonEliminarCliente.Enabled = true;
            btnExportar.Enabled = true;
            btnRefresh.Enabled = true;
            panelDatosCliente.Enabled = true;
            panelDatosFiltrar.Enabled = true;
            btnReactivarCliente.Enabled = false;
        }
        #endregion

        private void btnReactivarCliente_Click(object sender, EventArgs e)
        {
            ReactivarClienteSeleccionado();
        }

        private void dataGridViewCliente_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCliente.SelectedRows.Count > 0)
            {
                var item = dataGridViewCliente.SelectedRows[0].DataBoundItem as Cliente;

                if (item != null)
                {
                    _clienteSeleccionado = item;
                    lblSeleccionado.Visible = true;
                    lblSeleccionadoEspecifico.Visible = true;
                    lblSeleccionadoEspecifico.Text = item.NombreCompleto;

                    MapearClienteAControles(_clienteSeleccionado);
                }
            }
            else
            {
                _clienteSeleccionado = null;
                lblSeleccionado.Visible = false;
                lblSeleccionadoEspecifico.Visible = false;
                LimpiarControles();
            }
        }

        private void dataGridViewCliente_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dataGridViewCliente.Rows[e.RowIndex];
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

        private void dataGridViewCliente_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RecorrerDataGridTraduccion(sesion.Idioma);
        }
    }
}

