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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Rectangle = iTextSharp.text.Rectangle;

namespace CheeseLogix.Negocio.Ventas
{
    public partial class frmCobroVenta : Form, IObservador
    {
        #region Propiedades y Variables

        private BLL_VENTA _bllVenta;
        private BLL_FACTURACION _bllFacturacion;
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        
        // Venta actual
        private Venta _ventaActual;

        #endregion

        #region Constructor y Inicialización

        public frmCobroVenta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor que recibe la venta a cobrar
        /// </summary>
        /// <param name="venta">Venta a procesar</param>
        public frmCobroVenta(Venta venta) : this()
        {
            _ventaActual = venta;
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            _bllVenta = new BLL_VENTA();
            _bllFacturacion = new BLL_FACTURACION();

            // Configurar datos de la venta
            ConfigurarDataGridDetalle();
            CargarDatosVenta();
            CargarMetodosPago();

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
            // Configuración adicional al cargar el formulario
            if (_ventaActual == null)
            {
                MessageBox.Show("Error: No se proporcionó una venta válida.", ConstantesUI.Titulos.Error, 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        #endregion

        #region Configuración de Datos

        private void ConfigurarDataGridDetalle()
        {
            dataGridViewDetalleVenta.AutoGenerateColumns = false;
            dataGridViewDetalleVenta.Columns.Clear();

            dataGridViewDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreProducto",
                HeaderText = "Producto",
                Name = "Producto",
                Width = 200,
                ReadOnly = true
            });

            dataGridViewDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad",
                Name = "Cantidad",
                Width = 80,
                ReadOnly = true
            });

            dataGridViewDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Precio",
                HeaderText = "Precio Unit.",
                Name = "Precio",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dataGridViewDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SubTotal",
                HeaderText = "Subtotal",
                Name = "SubTotal",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
        }

        private void CargarDatosVenta()
        {
            if (_ventaActual == null) return;

            try
            {
                // Cargar detalles de la venta
                var detalles = _bllVenta.ObtenerDetallesPorVentaId(_ventaActual.Id);
                dataGridViewDetalleVenta.DataSource = detalles;

                // Cargar información en los labels
                lblTotal.Text = _ventaActual.MontoTotal.ToString("C2");
                labelEstado.Text = ObtenerDescripcionEstado(_ventaActual.EstadoVentaEnum);
                labelCliente.Text = _ventaActual.oCliente?.NombreCompleto ?? "Cliente no disponible";
                labelFecha.Text = _ventaActual.Fecha.ToString("dd/MM/yyyy HH:mm");

                // Establecer color del estado
                ActualizarColorEstado(_ventaActual.EstadoVentaEnum);

                // Establecer método de pago actual
                if (comboBoxMetodoPago.Items.Count > 0)
                {
                    comboBoxMetodoPago.SelectedValue = (int)_ventaActual.TipoPagoEnum;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de la venta: {ex.Message}", ConstantesUI.Titulos.Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMetodosPago()
        {
            try
            {
                var metodosPago = new List<object>
                {
                    new { Value = (int)TipoPago.Efectivo, Text = "Efectivo" },
                    new { Value = (int)TipoPago.Credito, Text = "Tarjeta" },
                    new { Value = (int)TipoPago.Debito, Text = "Debito" }
                };

                comboBoxMetodoPago.DataSource = metodosPago;
                comboBoxMetodoPago.DisplayMember = "Text";
                comboBoxMetodoPago.ValueMember = "Value";
                comboBoxMetodoPago.SelectedIndex = 0; // Efectivo por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar métodos de pago: {ex.Message}", ConstantesUI.Titulos.Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ActualizarColorEstado(EstadoVenta estado)
        {
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

        #endregion

        #region Eventos de Botones

        private void btnConfirmarPago_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (_ventaActual == null)
                {
                    MessageBox.Show("Error: No hay una venta válida.", ConstantesUI.Titulos.Error,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_ventaActual.EstadoVentaEnum != EstadoVenta.EnProceso)
                {
                    MessageBox.Show("Solo se pueden cobrar ventas en estado 'En Proceso'.", ConstantesUI.Titulos.Validacion,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmar con el usuario
                var metodoPago = comboBoxMetodoPago.Text;
                var resultado = MessageBox.Show(
                    $"¿Confirmar el pago de la venta?\n\nCliente: {_ventaActual.oCliente?.NombreCompleto}\nTotal: {_ventaActual.MontoTotal:C2}\nMétodo: {metodoPago}",
                    ConstantesUI.Titulos.Confirmacion,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    ProcesarPago();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al confirmar el pago: {ex.Message}", ConstantesUI.Titulos.Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (_ventaActual == null)
                {
                    MessageBox.Show("Error: No hay una venta válida.", ConstantesUI.Titulos.Error,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_ventaActual.EstadoVentaEnum == EstadoVenta.Cancelada)
                {
                    MessageBox.Show("La venta ya está cancelada.", ConstantesUI.Titulos.Informacion,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Confirmar cancelación
                var resultado = MessageBox.Show(
                    $"¿Está seguro de que desea cancelar la venta?\n\nEsta acción liberará el stock reservado y no se podrá deshacer.",
                    ConstantesUI.Titulos.Confirmacion,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    CancelarVenta();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cancelar la venta: {ex.Message}", ConstantesUI.Titulos.Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region Procesamiento de Pago

        private void ProcesarPago()
        {
            try
            {
                // Actualizar método de pago
                var metodoPagoSeleccionado = (TipoPago)Convert.ToInt32(comboBoxMetodoPago.SelectedValue);
                _ventaActual.TipoPagoEnum = metodoPagoSeleccionado;

                // Cambiar estado a Cobrada
                _bllVenta.CambiarEstadoVenta(_ventaActual.Id, EstadoVenta.Cobrada);
                _ventaActual.EstadoVentaEnum = EstadoVenta.Cobrada;

                // Generar factura en PDF con el estado ya actualizado
                // Actualizar vista
                labelEstado.Text = ObtenerDescripcionEstado(EstadoVenta.Cobrada);
                ActualizarColorEstado(EstadoVenta.Cobrada);

                // Generar factura con el estado correcto
                string rutaFactura = GenerarFactura();

                MessageBox.Show($"Pago confirmado exitosamente.\n\nLa venta ha sido marcada como 'Cobrada'.\n\nFactura generada en: {rutaFactura}",
                    ConstantesUI.Titulos.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirigir al formulario de despacho
                var frmDespacho = new frmDespachoProducto(_ventaActual);
                this.Hide();
                var resultadoDespacho = frmDespacho.ShowDialog();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el pago: {ex.Message}", ConstantesUI.Titulos.Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelarVenta()
        {
            try
            {
                // Cambiar estado a Cancelada (esto liberará automáticamente el stock)
                _bllVenta.CambiarEstadoVenta(_ventaActual.Id, EstadoVenta.Cancelada);
                _ventaActual.EstadoVentaEnum = EstadoVenta.Cancelada;

                // Actualizar vista
                labelEstado.Text = ObtenerDescripcionEstado(EstadoVenta.Cancelada);
                ActualizarColorEstado(EstadoVenta.Cancelada);

                MessageBox.Show("Venta cancelada exitosamente.\n\nEl stock reservado ha sido liberado automáticamente.",
                    ConstantesUI.Titulos.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirigir al formulario de inicio de órdenes
                this.DialogResult = DialogResult.Cancel;
                this.Close();

                // Mostrar frmInicioOrden
                var frmInicio = new frmInicioOrden();
                frmInicio.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cancelar la venta: {ex.Message}", ConstantesUI.Titulos.Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Generación de Factura

        /// <summary>
        /// Genera una factura PDF usando la BLL de facturación
        /// </summary>
        /// <returns>Ruta del archivo PDF generado</returns>
        private string GenerarFactura()
        {
            try
            {
                return _bllFacturacion.GenerarFacturaPDF(_ventaActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar la factura: {ex.Message}", ConstantesUI.Titulos.Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
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
                MessageBox.Show($"Error al cargar idiomas: {ex.Message}", ConstantesUI.Titulos.Error,
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
                MessageBox.Show($"Error al actualizar los textos de los controles: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
