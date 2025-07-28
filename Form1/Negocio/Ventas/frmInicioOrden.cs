using BEs;
using BEs.Clases;
using BEs.Clases.Negocio.Enums;
using BEs.Clases.Negocio.Ventas;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using CheeseLogix.Negocio.Ventas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix.Negocio.Ventas
{
    public partial class frmInicioOrden : Form, IObservador
    {
        private BLL_VENTA _bllVenta;
        private BLL_CLIENTE _bllCliente;
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        private List<Venta> _ventasOriginales;
        private Venta _ventaSeleccionada;

        public frmInicioOrden()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            _bllVenta = new BLL_VENTA();
            _bllCliente = new BLL_CLIENTE();
            
            dateTimePickerDesde.Value = DateTime.Now.AddDays(-30);
            dateTimePickerHasta.Value = DateTime.Now;
            
            // Configurar validación de CUIT
            ConfigurarValidacionCUIT();
            
            CargarVentas();
            ConfigurarDataGrids();
            
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

        private void frmInicioOrden_Load(object sender, EventArgs e)
        {
            // Configuración adicional al cargar el formulario
            labelEstado.Text = "Estado: -";
            SeleccionarPrimeraFila();
        }

        #region Configuración de Validaciones

        private void ConfigurarValidacionCUIT()
        {
            // Configurar eventos para validación de CUIT
            txtCuitCliente.KeyPress += TxtCuitCliente_KeyPress;
            txtCuitCliente.TextChanged += TxtCuitCliente_TextChanged;
            txtCuitCliente.Leave += TxtCuitCliente_Leave;
            
            // Configurar tooltip de ayuda (más compatible que PlaceholderText)
            ToolTip tooltipCuit = new ToolTip();
            tooltipCuit.SetToolTip(txtCuitCliente, "Ingrese el CUIT del cliente (11 dígitos)\nEjemplo: 20123456789 o 20-12345678-9");
        }

        private void TxtCuitCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, backspace, delete y guión
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '-')
            {
                e.Handled = true;
                return;
            }

            // Limitar longitud máxima (13 caracteres con guiones: XX-XXXXXXXX-X)
            if (txtCuitCliente.Text.Length >= 13 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void TxtCuitCliente_TextChanged(object sender, EventArgs e)
        {
            // Limpiar colores de error mientras escribe
            txtCuitCliente.BackColor = SystemColors.Window;
        }

        private void TxtCuitCliente_Leave(object sender, EventArgs e)
        {
            ValidarFormatoCUIT();
        }

        private bool ValidarFormatoCUIT()
        {
            string cuit = txtCuitCliente.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(cuit))
            {
                return true; // Válido si está vacío (no es obligatorio hasta que presione el botón)
            }

            // Limpiar guiones para validación
            string cuitLimpio = cuit.Replace("-", "").Replace(" ", "");

            // Validar longitud (debe ser 11 dígitos)
            if (cuitLimpio.Length != 11)
            {
                MostrarErrorCUIT("El CUIT debe tener 11 dígitos.");
                return false;
            }

            // Validar que sean solo números
            if (!cuitLimpio.All(char.IsDigit))
            {
                MostrarErrorCUIT("El CUIT debe contener solo números.");
                return false;
            }

            // Validación básica de dígito verificador de CUIT argentino
            if (!ValidarDigitoVerificadorCUIT(cuitLimpio))
            {
                MostrarErrorCUIT("El CUIT ingresado no es válido.");
                return false;
            }

            // Si llegamos aquí, el CUIT es válido
            txtCuitCliente.BackColor = SystemColors.Window;
            return true;
        }

        private bool ValidarDigitoVerificadorCUIT(string cuit)
        {
            try
            {
                // Algoritmo de validación de CUIT argentino
                int[] secuencia = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                int suma = 0;

                for (int i = 0; i < 10; i++)
                {
                    suma += int.Parse(cuit[i].ToString()) * secuencia[i];
                }

                int resto = suma % 11;
                int digitoVerificador = resto < 2 ? resto : 11 - resto;

                return digitoVerificador == int.Parse(cuit[10].ToString());
            }
            catch
            {
                return false;
            }
        }

        private void MostrarErrorCUIT(string mensaje)
        {
            txtCuitCliente.BackColor = Color.LightPink;
            // Opcional: mostrar tooltip con el error
            ToolTip toolTip = new ToolTip();
            toolTip.Show(mensaje, txtCuitCliente, 0, txtCuitCliente.Height, 3000);
        }

        #endregion

        #region Gestión de DataGridViews

        private void ConfigurarDataGrids()
        {
            // Configurar DataGridView de Ventas
            dataGridViewOrdenVenta.SelectionChanged += DataGridViewOrdenVenta_SelectionChanged;
            dataGridViewOrdenVenta.AutoGenerateColumns = false;
            dataGridViewOrdenVenta.Columns.Clear();
            
            // Configurar selección
            dataGridViewOrdenVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOrdenVenta.MultiSelect = false;
            dataGridViewOrdenVenta.ReadOnly = true;

            // Configurar columnas para ventas
            dataGridViewOrdenVenta.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "Id", 
                HeaderText = "ID", 
                Name = "Id", 
                Width = 60,
                ReadOnly = true 
            });
            
            dataGridViewOrdenVenta.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "NombreCliente", 
                HeaderText = "Cliente", 
                Name = "Cliente", 
                Width = 200,
                ReadOnly = true 
            });
            
            dataGridViewOrdenVenta.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "Fecha", 
                HeaderText = "Fecha", 
                Name = "Fecha", 
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });
            
            dataGridViewOrdenVenta.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "MontoTotal", 
                HeaderText = "Total", 
                Name = "Total", 
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
            
            dataGridViewOrdenVenta.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "EstadoVentaEnum", 
                HeaderText = "Estado", 
                Name = "Estado", 
                Width = 120,
                ReadOnly = true 
            });

            // Configurar DataGridView de Detalles
            dataGridViewDetalle.AutoGenerateColumns = false;
            dataGridViewDetalle.Columns.Clear();
            
            dataGridViewDetalle.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "NombreProducto", 
                HeaderText = "Producto", 
                Name = "Producto", 
                Width = 200,
                ReadOnly = true 
            });
            
            dataGridViewDetalle.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "Cantidad", 
                HeaderText = "Cantidad", 
                Name = "Cantidad", 
                Width = 80,
                ReadOnly = true 
            });
            
            dataGridViewDetalle.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "Precio", 
                HeaderText = "Precio Unit.", 
                Name = "Precio", 
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
            
            dataGridViewDetalle.Columns.Add(new DataGridViewTextBoxColumn 
            { 
                DataPropertyName = "SubTotal", 
                HeaderText = "Subtotal", 
                Name = "SubTotal", 
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
        }

        private void CargarVentas()
        {
            try
            {
                _ventasOriginales = _bllVenta.ObtenerTodos();
                AplicarFiltroFechas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las ventas: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltroFechas()
        {
            if (_ventasOriginales == null) return;

            DateTime fechaDesde = dateTimePickerDesde.Value.Date;
            DateTime fechaHasta = dateTimePickerHasta.Value.Date.AddDays(1).AddSeconds(-1);

            var ventasFiltradas = _ventasOriginales
                .Where(v => v.Fecha >= fechaDesde && v.Fecha <= fechaHasta)
                .OrderByDescending(v => v.Fecha)
                .ToList();

            dataGridViewOrdenVenta.DataSource = ventasFiltradas;
            
            // Auto-seleccionar la primera fila si hay datos
            SeleccionarPrimeraFila();
        }

        private void SeleccionarPrimeraFila()
        {
            if (dataGridViewOrdenVenta.Rows.Count > 0)
            {
                dataGridViewOrdenVenta.Rows[0].Selected = true;
                dataGridViewOrdenVenta.CurrentCell = dataGridViewOrdenVenta.Rows[0].Cells[0];
                
                // Llamar manualmente al evento para asegurar que se actualice el estado
                DataGridViewOrdenVenta_SelectionChanged(dataGridViewOrdenVenta, EventArgs.Empty);
            }
        }

        private void DataGridViewOrdenVenta_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewOrdenVenta.SelectedRows.Count > 0)
            {
                var ventaSeleccionada = (Venta)dataGridViewOrdenVenta.SelectedRows[0].DataBoundItem;
                _ventaSeleccionada = ventaSeleccionada;
                MostrarDetalleVenta(ventaSeleccionada);
                ActualizarEstadoLabel(ventaSeleccionada.EstadoVentaEnum);
            }
            else
            {
                LimpiarSeleccion();
            }
        }

        private void MostrarDetalleVenta(Venta venta)
        {
            if (venta == null)
            {
                dataGridViewDetalle.DataSource = null;
                return;
            }

            var detalles = _bllVenta.ObtenerDetallesPorVentaId(venta.Id);
            dataGridViewDetalle.DataSource = detalles;
        }

        private void ActualizarEstadoLabel(EstadoVenta estado)
        {
            labelEstado.Text = $"Estado: {ObtenerDescripcionEstado(estado)}";
            
            // Cambiar color según el estado
            switch (estado)
            {
                case EstadoVenta.EnProceso:
                    labelEstado.ForeColor = Color.Orange;
                    break;
                case EstadoVenta.Cobrada:
                    labelEstado.ForeColor = Color.Yellow;
                    break;
                case EstadoVenta.Entregada:
                    labelEstado.ForeColor = Color.LightGreen;
                    break;
                case EstadoVenta.Cancelada:
                    labelEstado.ForeColor = Color.Red;
                    break;
                default:
                    labelEstado.ForeColor = Color.Gainsboro;
                    break;
            }
        }

        private string ObtenerDescripcionEstado(EstadoVenta estado)
        {
            switch (estado)
            {
                case EstadoVenta.EnProceso: return "En Proceso";
                case EstadoVenta.Cobrada: return "Cobrada";
                case EstadoVenta.Entregada: return "Entregada";
                case EstadoVenta.Cancelada: return "Cancelada";
                default: return "Desconocido";
            }
        }

        private void LimpiarSeleccion()
        {
            _ventaSeleccionada = null;
            dataGridViewDetalle.DataSource = null;
            labelEstado.Text = "Estado: -";
            labelEstado.ForeColor = Color.Gainsboro;
        }

        #endregion

        #region Eventos de Botones

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePickerDesde.Value > dateTimePickerHasta.Value)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", 
                        "Error en fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AplicarFiltroFechas();
                
                var cantidadResultados = dataGridViewOrdenVenta.Rows.Count;
                MessageBox.Show($"Se encontraron {cantidadResultados} ventas en el rango de fechas seleccionado.", 
                    "Búsqueda completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la búsqueda: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReestablecer_Click(object sender, EventArgs e)
        {
            try
            {
                // Restablecer fechas al último mes
                dateTimePickerDesde.Value = DateTime.Now.AddDays(-30);
                dateTimePickerHasta.Value = DateTime.Now;
                
                // Recargar todas las ventas
                CargarVentas();
                
                MessageBox.Show("Los filtros han sido restablecidos.", "Filtros restablecidos", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al restablecer filtros: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIniciarOrden_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener CUIT del textbox
                string cuit = txtCuitCliente.Text.Trim();
                
                if (string.IsNullOrWhiteSpace(cuit))
                {
                    MessageBox.Show("Por favor, ingrese el CUIT del cliente.", "CUIT requerido", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCuitCliente.Focus();
                    return;
                }

                // Validar formato de CUIT antes de continuar
                if (!ValidarFormatoCUIT())
                {
                    MessageBox.Show("Por favor, ingrese un CUIT válido antes de continuar.", "CUIT inválido", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCuitCliente.Focus();
                    return;
                }

                // Limpiar formato del CUIT para la búsqueda
                string cuitLimpio = cuit.Replace("-", "").Replace(" ", "");

                // Buscar cliente por CUIT (usar CUIT limpio)
                var cliente = _bllCliente.BuscarPorCUIT(cuitLimpio);
                
                if (cliente != null)
                {
                    // Cliente encontrado - Mostrar mensaje y redirigir
                    var resultado = MessageBox.Show(
                        $"Cliente encontrado: {cliente.NombreCompleto}\n\n¿Desea iniciar una nueva orden de venta para este cliente?", 
                        "Cliente encontrado", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Information);
                    
                    if (resultado == DialogResult.Yes)
                    {
                        // Redirigir a frmTramitarOrdenCarrito pasando el CUIT limpio para que busque automáticamente
                        var frmTramitar = new frmTramitarOrdenCarrito(cuitLimpio);
                        
                        this.Hide();
                        frmTramitar.ShowDialog();
                        this.Show();
                        
                        // Limpiar textbox y recargar ventas por si se creó una nueva
                        txtCuitCliente.Clear();
                        CargarVentas();
                    }
                }
                else
                {
                    // Cliente no encontrado - Preguntar si quiere agregarlo
                    var resultado = MessageBox.Show(
                        $"No se encontró un cliente con CUIT '{cuitLimpio}' en nuestro sistema.\n\n¿Desea agregar este cliente?", 
                        "Cliente no encontrado", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question);
                    
                    if (resultado == DialogResult.Yes)
                    {
                        // Redirigir a frmGestionarClientes
                        var frmGestionClientes = new frmGestionarClientes();
                        // TODO: Si es posible, pre-llenar el CUIT en el formulario de gestión
                        
                        this.Hide();
                        frmGestionClientes.ShowDialog();
                        this.Show();
                        
                                                 // Limpiar textbox
                         txtCuitCliente.Clear();
                    }
                    else
                    {
                        // Usuario eligió no agregar cliente
                        MessageBox.Show("Por favor, elija un cliente válido o agregue el cliente al sistema.", 
                            "Cliente requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Limpiar textbox y mantener foco
                        txtCuitCliente.Clear();
                        txtCuitCliente.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el cliente: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // En caso de error, limpiar y mantener foco
                txtCuitCliente.Clear();
                txtCuitCliente.Focus();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
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
        #endregion Permisos
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
}
