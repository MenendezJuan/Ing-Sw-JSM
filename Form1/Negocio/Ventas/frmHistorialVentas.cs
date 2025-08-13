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
			CargarVentas();
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
			// Ocultar columnas poco útiles y renombrar encabezados básicos
			if (gridVentas.Columns.Contains("Id")) gridVentas.Columns["Id"].HeaderText = "Id";
			if (gridVentas.Columns.Contains("MontoTotal")) gridVentas.Columns["MontoTotal"].HeaderText = "Monto";
			if (gridVentas.Columns.Contains("Fecha")) gridVentas.Columns["Fecha"].HeaderText = "Fecha";
			if (gridVentas.Columns.Contains("TipoPagoEnum")) gridVentas.Columns["TipoPagoEnum"].HeaderText = "Pago";
			if (gridVentas.Columns.Contains("Comentario")) gridVentas.Columns["Comentario"].Visible = false;
			if (gridVentas.Columns.Contains("oDetalleVenta")) gridVentas.Columns["oDetalleVenta"].Visible = false;
			if (gridVentas.Columns.Contains("oCliente")) gridVentas.Columns["oCliente"].Visible = false;
		}

		private void FormatearGrillaDetalles()
		{
			if (gridDetalles.Columns.Count == 0) return;
			if (gridDetalles.Columns.Contains("Id")) gridDetalles.Columns["Id"].Visible = false;
			if (gridDetalles.Columns.Contains("VentaId")) gridDetalles.Columns["VentaId"].Visible = false;
			if (gridDetalles.Columns.Contains("ProductoId")) gridDetalles.Columns["ProductoId"].HeaderText = "ProductoId";
			if (gridDetalles.Columns.Contains("Precio")) gridDetalles.Columns["Precio"].HeaderText = "Precio";
			if (gridDetalles.Columns.Contains("Cantidad")) gridDetalles.Columns["Cantidad"].HeaderText = "Cantidad";
			if (gridDetalles.Columns.Contains("SubTotal")) gridDetalles.Columns["SubTotal"].HeaderText = "Subtotal";
			if (gridDetalles.Columns.Contains("oProducto")) gridDetalles.Columns["oProducto"].Visible = false;
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

			var frm = new frmRegistrarDevolucion(_ventaSeleccionada.Id, detalle.oProducto.Id);
			var dialogResult = frm.ShowDialog(this);
			CargarDetalles(_ventaSeleccionada.Id);
			CargarVentas();
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

