using BEs;
using BEs.Clases;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using BLLs.Tecnica;
using BEs.Clases.Negocio.Enums;
using BEs.Clases.Negocio.Ventas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix.Negocio.Ventas
{
	public partial class frmHistorialVentas : Form, IObservador
	{
		private readonly BLL_VENTA _bllVenta;
		private readonly BLL_IDIOMA Bll_Idioma;
		private readonly BLL_TRADUCCION Bll_Traduccion;
		private readonly SessionManager sesion;

		private Venta _ventaSeleccionada;
		public frmHistorialVentas()
		{
			InitializeComponent();
			sesion = SessionManager.GetInstance();
			_bllVenta = new BLL_VENTA();
			Bll_Idioma = new BLL_IDIOMA();
			Bll_Traduccion = new BLL_TRADUCCION();
			CargarIdiomas();
			Actualizar(sesion.Idioma);
			ConfigurarEstilosDataGrids();
			CargarVentas();
		}
		
		private void ConfigurarEstilosDataGrids()
		{
			// Configurar estilos para gridVentas
			gridVentas.BackgroundColor = Color.FromArgb(45, 45, 45);
			gridVentas.DefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);
			gridVentas.DefaultCellStyle.ForeColor = Color.White;
			gridVentas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180);
			gridVentas.DefaultCellStyle.SelectionForeColor = Color.White;
			gridVentas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
			gridVentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			gridVentas.EnableHeadersVisualStyles = false;
			gridVentas.BorderStyle = BorderStyle.None;
			gridVentas.GridColor = Color.FromArgb(80, 80, 80);
			
			// Configurar estilos para gridDetalles
			gridDetalles.BackgroundColor = Color.FromArgb(45, 45, 45);
			gridDetalles.DefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);
			gridDetalles.DefaultCellStyle.ForeColor = Color.White;
			gridDetalles.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180);
			gridDetalles.DefaultCellStyle.SelectionForeColor = Color.White;
			gridDetalles.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
			gridDetalles.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			gridDetalles.EnableHeadersVisualStyles = false;
			gridDetalles.BorderStyle = BorderStyle.None;
			gridDetalles.GridColor = Color.FromArgb(80, 80, 80);
		}

		private void CargarVentas()
		{
			try
			{
				var ventas = _bllVenta.ObtenerTodos()
					.Where(v => v.EstadoVentaEnum == EstadoVenta.Cobrada || v.EstadoVentaEnum == EstadoVenta.Entregada)
					.OrderByDescending(v => v.Fecha)
					.ToList();
				gridVentas.DataSource = ventas;
				FormatearGrillaVentas();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error al cargar ventas: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CargarDetalles(int ventaId)
		{
			try
			{
				var detalles = _bllVenta.ObtenerDetallesPorVentaId(ventaId);
				gridDetalles.DataSource = detalles;
				FormatearGrillaDetalles();
				btnRegistrarDevolucion.Enabled = (detalles != null && detalles.Any());
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error al cargar detalles: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void FormatearGrillaVentas()
		{
			if (gridVentas.Columns.Count == 0) return;
			
			// Configurar columnas visibles con nombres correctos
			if (gridVentas.Columns.Contains("Id")) gridVentas.Columns["Id"].HeaderText = "Nro. Venta";
			if (gridVentas.Columns.Contains("MontoTotal")) gridVentas.Columns["MontoTotal"].HeaderText = "Monto";
			if (gridVentas.Columns.Contains("TipoPagoEnum")) gridVentas.Columns["TipoPagoEnum"].HeaderText = "Pago";
			if (gridVentas.Columns.Contains("Fecha")) gridVentas.Columns["Fecha"].HeaderText = "Fecha";
			
			// Corregir nombre de estado
			if (gridVentas.Columns.Contains("EstadoVentaEnum")) gridVentas.Columns["EstadoVentaEnum"].HeaderText = "Estado";
			
			// Renombrar columnas existentes para cliente y vendedor
			if (gridVentas.Columns.Contains("ClienteId")) 
				gridVentas.Columns["ClienteId"].HeaderText = "Nro. Cliente";
			
			if (gridVentas.Columns.Contains("UsuarioVendedorId")) 
				gridVentas.Columns["UsuarioVendedorId"].HeaderText = "Cód. Vendedor";
			
			// Agregar columnas calculadas para nombres
			if (!gridVentas.Columns.Contains("Cliente"))
			{
				DataGridViewTextBoxColumn clienteCol = new DataGridViewTextBoxColumn
				{
					Name = "Cliente",
					HeaderText = "Cliente",
					DataPropertyName = "NombreCliente",
					ReadOnly = true
				};
				gridVentas.Columns.Add(clienteCol);
			}
			
			if (!gridVentas.Columns.Contains("Vendedor"))
			{
				DataGridViewTextBoxColumn vendedorCol = new DataGridViewTextBoxColumn
				{
					Name = "Vendedor",
					HeaderText = "Vendedor",
					DataPropertyName = "NombreVendedor",
					ReadOnly = true
				};
				gridVentas.Columns.Add(vendedorCol);
			}
			
			// Ocultar columnas no deseadas
			if (gridVentas.Columns.Contains("Comentario")) gridVentas.Columns["Comentario"].Visible = false;
			if (gridVentas.Columns.Contains("oDetalleVenta")) gridVentas.Columns["oDetalleVenta"].Visible = false;
			if (gridVentas.Columns.Contains("oCliente")) gridVentas.Columns["oCliente"].Visible = false;
			if (gridVentas.Columns.Contains("oVendedor")) gridVentas.Columns["oVendedor"].Visible = false;
			if (gridVentas.Columns.Contains("NombreCliente")) gridVentas.Columns["NombreCliente"].Visible = false;
			if (gridVentas.Columns.Contains("NombreVendedor")) gridVentas.Columns["NombreVendedor"].Visible = false;
		}

		private void FormatearGrillaDetalles()
		{
			if (gridDetalles.Columns.Count == 0) return;
			
			// Ocultar columnas no deseadas
			if (gridDetalles.Columns.Contains("Id")) gridDetalles.Columns["Id"].Visible = false;
			if (gridDetalles.Columns.Contains("VentaId")) gridDetalles.Columns["VentaId"].Visible = false;
			if (gridDetalles.Columns.Contains("oProducto")) gridDetalles.Columns["oProducto"].Visible = false;
			if (gridDetalles.Columns.Contains("oVenta")) gridDetalles.Columns["oVenta"].Visible = false;
			
			// Renombrar columnas correctamente
			if (gridDetalles.Columns.Contains("ProductoId")) gridDetalles.Columns["ProductoId"].HeaderText = "Cód. Producto";
			if (gridDetalles.Columns.Contains("Precio")) gridDetalles.Columns["Precio"].HeaderText = "Precio";
			if (gridDetalles.Columns.Contains("Cantidad")) gridDetalles.Columns["Cantidad"].HeaderText = "Cantidad";
			if (gridDetalles.Columns.Contains("SubTotal")) gridDetalles.Columns["SubTotal"].HeaderText = "Subtotal";
		}

		private void gridVentas_SelectionChanged(object sender, EventArgs e)
		{
			if (gridVentas.CurrentRow == null) return;
			_ventaSeleccionada = gridVentas.CurrentRow.DataBoundItem as Venta;
			if (_ventaSeleccionada != null)
			{
				CargarDetalles(_ventaSeleccionada.Id);
			}
		}

		private void gridDetalles_SelectionChanged(object sender, EventArgs e)
		{
			btnRegistrarDevolucion.Enabled = gridDetalles.CurrentRow != null;
		}

		private void btnRegistrarDevolucion_Click(object sender, EventArgs e)
		{
			if (_ventaSeleccionada == null || gridDetalles.CurrentRow == null) return;
			var detalle = gridDetalles.CurrentRow.DataBoundItem as BEs.Clases.Negocio.Ventas.DetalleVenta;
			if (detalle == null) return;

			// Abrir como modal cuando se llama desde historial de ventas
			using (var frm = new frmRegistrarDevolucion(_ventaSeleccionada.Id, detalle.oProducto.Id))
			{
				frm.StartPosition = FormStartPosition.CenterParent;
				var dialogResult = frm.ShowDialog(this);
				
				// Refrescar datos después de cerrar el formulario
				if (dialogResult == DialogResult.OK || dialogResult == DialogResult.Cancel)
				{
					CargarDetalles(_ventaSeleccionada.Id);
					CargarVentas();
				}
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
			catch { }
		}

		public void Actualizar(IIdioma idioma)
		{
			foreach (Control control in ListaControles)
			{
				if (control.Tag != null)
				{
					string traduccion = Bll_Traduccion.BuscarTraduccion(control.Tag.ToString(), idioma.Id);
					if (!string.IsNullOrEmpty(traduccion)) control.Text = traduccion;
				}
			}
			if (cboxIdiomas.DataSource != null && cboxIdiomas.Items.Count > 0 && cboxIdiomas.ValueMember != string.Empty)
			{
				cboxIdiomas.SelectedValue = idioma.Id;
			}
		}

		List<Control> ListaControles = new List<Control>();
		public void BuscarControles(System.Collections.ICollection controles)
		{
			foreach (Control control in controles)
			{
				ListaControles.Add(control);
				if (control.Controls.Count > 0) BuscarControles(control.Controls);
			}
		}
		#endregion
	}
}

