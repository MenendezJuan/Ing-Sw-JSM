using BEs;
using BEs.Clases;
using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Enums;
using BEs.Clases.Negocio.Ventas;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using BLLs.Tecnica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheeseLogix.Negocio.Ventas
{
    public partial class frmDespachoProducto : Form, IObservador
    {
        #region Propiedades y Variables

        private BLL_VENTA _bllVenta;
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        
        // Venta seleccionada actualmente
        private Venta _ventaSeleccionada;
        
        // Lista de ventas cobradas
        private List<Venta> _ventasCobradas;
        
        // Control de firma
        private bool _ventaFirmada = false;
        private string _archivoFirmaActual = string.Empty;

        #endregion

        #region Constructor y Inicialización

        public frmDespachoProducto()
        {
            InitializeComponent();
            InicializarComponentes();
        }

        /// <summary>
        /// Constructor que recibe la venta para el despacho (desde frmCobroVenta)
        /// </summary>
        /// <param name="venta">Venta a despachar</param>
        public frmDespachoProducto(Venta venta) : this()
        {
            // Si viene de frmCobroVenta, cargar todas las ventas y seleccionar la específica
            CargarVentasCobradas();
            if (venta != null)
            {
                SeleccionarVentaEspecifica(venta.Id);
            }
        }

        private void InicializarComponentes()
        {
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            _bllVenta = new BLL_VENTA();

            // Configurar DataGridViews
            ConfigurarDataGrids();
            
            // Cargar ventas cobradas
            CargarVentasCobradas();
            
            // Estado inicial de botones
            ActualizarEstadoBotones();

            // Configurar idiomas y permisos
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

        private void frmCobroVenta_Load(object sender, EventArgs e)
        {
            // El formulario ya está configurado en InicializarComponentes
        }

        #endregion

        #region Configuración de DataGridViews

        private void ConfigurarDataGrids()
        {
            ConfigurarDataGridVentas();
            ConfigurarDataGridDetalles();
        }

        private void ConfigurarDataGridVentas()
        {
            dataGridViewOrdenVenta.SelectionChanged += DataGridViewOrdenVenta_SelectionChanged;
            dataGridViewOrdenVenta.AutoGenerateColumns = false;
            dataGridViewOrdenVenta.Columns.Clear();

            dataGridViewOrdenVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID Venta",
                Name = "Id",
                Width = 80,
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
                Name = "MontoTotal",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dataGridViewOrdenVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EstadoVentaEnum",
                HeaderText = "Estado",
                Name = "Estado",
                Width = 100,
                ReadOnly = true
            });
        }

        private void ConfigurarDataGridDetalles()
        {
            dataGridViewDetOrdenVenta.AutoGenerateColumns = false;
            dataGridViewDetOrdenVenta.Columns.Clear();

            dataGridViewDetOrdenVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreProducto",
                HeaderText = "Producto",
                Name = "Producto",
                Width = 200,
                ReadOnly = true
            });

            dataGridViewDetOrdenVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad",
                Name = "Cantidad",
                Width = 80,
                ReadOnly = true
            });

            dataGridViewDetOrdenVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Precio",
                HeaderText = "Precio Unit.",
                Name = "Precio",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dataGridViewDetOrdenVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SubTotal",
                HeaderText = "Subtotal",
                Name = "SubTotal",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
        }

        #endregion

        #region Carga de Datos

        private void CargarVentasCobradas()
        {
            try
            {
                // Obtener todas las ventas en estado "Cobrada"
                _ventasCobradas = _bllVenta.ObtenerTodos()
                    .Where(v => v.EstadoVentaEnum == EstadoVenta.Cobrada)
                    .OrderByDescending(v => v.Fecha)
                    .ToList();

                dataGridViewOrdenVenta.DataSource = _ventasCobradas;
                
                // Limpiar selección
                LimpiarSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las ventas cobradas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarVentaEspecifica(int ventaId)
        {
            try
            {
                var venta = _ventasCobradas?.FirstOrDefault(v => v.Id == ventaId);
                if (venta != null)
                {
                    // Buscar el índice en el DataGridView
                    for (int i = 0; i < dataGridViewOrdenVenta.Rows.Count; i++)
                    {
                        if (dataGridViewOrdenVenta.Rows[i].DataBoundItem is Venta ventaRow && ventaRow.Id == ventaId)
                        {
                            dataGridViewOrdenVenta.ClearSelection();
                            dataGridViewOrdenVenta.Rows[i].Selected = true;
                            dataGridViewOrdenVenta.CurrentCell = dataGridViewOrdenVenta.Rows[i].Cells[0];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar la venta específica: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDetalleVenta(int ventaId)
        {
            try
            {
                var detalles = _bllVenta.ObtenerDetallesPorVentaId(ventaId);
                dataGridViewDetOrdenVenta.DataSource = detalles;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el detalle de la venta: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos de Selección

        private void DataGridViewOrdenVenta_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewOrdenVenta.CurrentRow?.DataBoundItem is Venta ventaSeleccionada)
            {
                _ventaSeleccionada = ventaSeleccionada;
                
                // Cargar detalles de la venta
                CargarDetalleVenta(ventaSeleccionada.Id);
                
                // Verificar si ya tiene firma
                VerificarFirmaExistente(ventaSeleccionada.Id);
                
                // Actualizar estado de botones
                ActualizarEstadoBotones();
            }
            else
            {
                LimpiarSeleccion();
            }
        }

        private void LimpiarSeleccion()
        {
            _ventaSeleccionada = null;
            _ventaFirmada = false;
            _archivoFirmaActual = string.Empty;
            
            dataGridViewDetOrdenVenta.DataSource = null;
            ActualizarEstadoBotones();
        }

        #endregion

        #region Firma de Conforme

        private void VerificarFirmaExistente(int ventaId)
        {
            try
            {
                string directorioFirmas = BLL_CONFIGURACION.ObtenerDirectorioFirmas();
                string nombreArchivo = $"Conforme_Venta_{ventaId:D6}_{DateTime.Now:yyyyMMdd}.txt";
                string rutaCompleta = Path.Combine(directorioFirmas, nombreArchivo);

                // Buscar archivo de firma para hoy
                if (File.Exists(rutaCompleta))
                {
                    _ventaFirmada = true;
                    _archivoFirmaActual = rutaCompleta;
                }
                else
                {
                    // Buscar archivo de firma en cualquier fecha
                    string patron = $"Conforme_Venta_{ventaId:D6}_*.txt";
                    if (Directory.Exists(directorioFirmas))
                    {
                        var archivos = Directory.GetFiles(directorioFirmas, patron);
                        if (archivos.Length > 0)
                        {
                            _ventaFirmada = true;
                            _archivoFirmaActual = archivos[0]; // Tomar el primero encontrado
                        }
                        else
                        {
                            _ventaFirmada = false;
                            _archivoFirmaActual = string.Empty;
                        }
                    }
                    else
                    {
                        _ventaFirmada = false;
                        _archivoFirmaActual = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                _ventaFirmada = false;
                _archivoFirmaActual = string.Empty;
                MessageBox.Show($"Error al verificar firma existente: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GenerarFirmaConforme()
        {
            try
            {
                if (_ventaSeleccionada == null)
                {
                    MessageBox.Show("No hay una venta seleccionada.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener directorio de firmas desde configuración (se crea automáticamente)
                string directorioFirmas = BLL_CONFIGURACION.ObtenerDirectorioFirmas();

                // Nombre del archivo
                string nombreArchivo = $"Conforme_Venta_{_ventaSeleccionada.Id:D6}_{DateTime.Now:yyyyMMdd}.txt";
                string rutaCompleta = Path.Combine(directorioFirmas, nombreArchivo);

                // Verificar si ya existe
                if (File.Exists(rutaCompleta))
                {
                    MessageBox.Show("Esta venta ya tiene un conforme firmado para el día de hoy.", "Conforme existente",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Crear archivo de conforme
                using (var writer = new StreamWriter(rutaCompleta, false, System.Text.Encoding.UTF8))
                {
                    writer.WriteLine("===============================================");
                    writer.WriteLine("           CONFORME DE ENTREGA               ");
                    writer.WriteLine("           CHEESE LOGIX S.A.                 ");
                    writer.WriteLine("===============================================");
                    writer.WriteLine();
                    writer.WriteLine($"Venta ID: {_ventaSeleccionada.Id:D6}");
                    writer.WriteLine($"Cliente: {_ventaSeleccionada.oCliente?.NombreCompleto ?? "N/A"}");
                    writer.WriteLine($"CUIT Cliente: {_ventaSeleccionada.oCliente?.CUIT ?? "N/A"}");
                    writer.WriteLine($"Fecha de Venta: {_ventaSeleccionada.Fecha:dd/MM/yyyy HH:mm}");
                    writer.WriteLine($"Total: {_ventaSeleccionada.MontoTotal:C2}");
                    writer.WriteLine();
                    writer.WriteLine("-----------------------------------------------");
                    writer.WriteLine("            PRODUCTOS ENTREGADOS:            ");
                    writer.WriteLine("-----------------------------------------------");

                    var detalles = _bllVenta.ObtenerDetallesPorVentaId(_ventaSeleccionada.Id);
                    foreach (var detalle in detalles)
                    {
                        writer.WriteLine($"• {detalle.NombreProducto} - Cantidad: {detalle.Cantidad:N2}");
                    }

                    writer.WriteLine();
                    writer.WriteLine("-----------------------------------------------");
                    writer.WriteLine($"Firmado el: {DateTime.Now:dd/MM/yyyy HH:mm}");
                    writer.WriteLine($"Usuario: {sesion.oUsuario?.Email ?? "N/A"}");
                    writer.WriteLine();
                    writer.WriteLine("Firma del Cliente: _________________");
                    writer.WriteLine();
                    writer.WriteLine("Firma del Responsable: _____________");
                    writer.WriteLine();
                    writer.WriteLine("===============================================");
                }

                _ventaFirmada = true;
                _archivoFirmaActual = rutaCompleta;
                ActualizarEstadoBotones();

                MessageBox.Show($"Conforme generado exitosamente:\n{rutaCompleta}", "Conforme generado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el conforme: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Control de Estados

        private void ActualizarEstadoBotones()
        {
            // btnFirmarConforme: Habilitado si hay venta seleccionada y no está firmada
            btnFirmarConforme.Enabled = _ventaSeleccionada != null && !_ventaFirmada;

            // btnConfirmarEntrega: Habilitado si hay venta seleccionada y está firmada
            btnConfirmarEntrega.Enabled = _ventaSeleccionada != null && _ventaFirmada;

            // Actualizar texto del botón de firma
            if (_ventaFirmada)
            {
                btnFirmarConforme.Text = "✓ Conforme Firmado";
                btnFirmarConforme.BackColor = Color.LightGreen;
            }
            else
            {
                btnFirmarConforme.Text = "Firmar Conforme";
                btnFirmarConforme.BackColor = SystemColors.Control;
            }
        }

        #endregion

        #region Eventos de Botones

        private void btnFirmarConforme_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ventaSeleccionada == null)
                {
                    MessageBox.Show("Por favor, seleccione una venta para firmar el conforme.", "Selección requerida",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_ventaFirmada)
                {
                    MessageBox.Show("Esta venta ya tiene un conforme firmado.", "Conforme existente",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Confirmar acción
                var resultado = MessageBox.Show(
                    $"¿Confirmar la firma del conforme para la venta #{_ventaSeleccionada.Id}?\n\nCliente: {_ventaSeleccionada.oCliente?.NombreCompleto}",
                    "Confirmar firma de conforme",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    GenerarFirmaConforme();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al firmar conforme: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmarEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ventaSeleccionada == null)
                {
                    MessageBox.Show("No hay una venta seleccionada.", "Selección requerida",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!_ventaFirmada)
                {
                    MessageBox.Show("Debe firmar el conforme antes de confirmar la entrega.", "Conforme requerido",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmar acción
                var resultado = MessageBox.Show(
                    $"¿Confirmar la entrega de la venta #{_ventaSeleccionada.Id}?\n\nEsta acción cambiará el estado a 'Entregada' y confirmará definitivamente la venta del stock.",
                    "Confirmar entrega",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    ConfirmarEntrega();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al confirmar entrega: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfirmarEntrega()
        {
            try
            {
                // Cambiar estado a Entregada
                _bllVenta.CambiarEstadoVenta(_ventaSeleccionada.Id, EstadoVenta.Entregada);

                MessageBox.Show($"Entrega confirmada exitosamente.\n\nVenta #{_ventaSeleccionada.Id} marcada como 'Entregada'.",
                    "Entrega confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar ventas cobradas (la entregada ya no aparecerá)
                CargarVentasCobradas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al confirmar la entrega: {ex.Message}", "Error al confirmar entrega",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
        #endregion

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

        #endregion
    }
}

