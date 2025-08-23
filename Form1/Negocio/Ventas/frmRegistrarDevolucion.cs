using BEs;
using BEs.Clases;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using BLLs.Tecnica;
using BEs.Clases.Negocio.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix.Negocio.Ventas
{
	public partial class frmRegistrarDevolucion : Form, IObservador
	{
		private readonly BLL_DEVOLUCION _bllDevolucion;
		private readonly BLL_VENTA _bllVenta;
		private readonly BLL_PRODUCTO _bllProducto;
		private readonly BLL_FACTURACION _bllFacturacion;
		private readonly BLL_EXPORTACION _bllExportacion;
		private string _ultimaNotaCreditoRuta;
		private SessionManager sesion;
		private BLL_IDIOMA Bll_Idioma;
		private BLL_TRADUCCION Bll_Traduccion;

		public frmRegistrarDevolucion()
		{
			InitializeComponent();
			sesion = SessionManager.GetInstance();
			Bll_Idioma = new BLL_IDIOMA();
			Bll_Traduccion = new BLL_TRADUCCION();
			_bllDevolucion = new BLL_DEVOLUCION();
			_bllVenta = new BLL_VENTA();
			_bllProducto = new BLL_PRODUCTO();
			_bllFacturacion = new BLL_FACTURACION();
			_bllExportacion = new BLL_EXPORTACION();
			CargarIdiomas();
			Actualizar(sesion.Idioma);
			CargarCombos();
		}

		public frmRegistrarDevolucion(int ventaId, int productoId) : this()
		{
			try
			{
				if (comboVentas.Items.Count > 0)
					comboVentas.SelectedValue = ventaId;
				if (comboProductos.Items.Count > 0)
					comboProductos.SelectedValue = productoId;
			}
			catch { }
		}

		private void CargarCombos()
		{
			var ventas = _bllVenta.ObtenerVentasPorEstado(EstadoVenta.Cobrada);
			comboVentas.DataSource = ventas;
			comboVentas.DisplayMember = "Id";
			comboVentas.ValueMember = "Id";

			var productos = _bllProducto.ObtenerTodos().Where(p => p.Estado).ToList();
			comboProductos.DataSource = productos;
			comboProductos.DisplayMember = "Nombre";
			comboProductos.ValueMember = "Id";
		}

		private void btnRegistrar_Click(object sender, EventArgs e)
		{
			if (comboVentas.SelectedValue == null || comboProductos.SelectedValue == null) { MessageBox.Show("Seleccione venta y producto."); return; }
			if (numericCantidad.Value <= 0) { MessageBox.Show("Cantidad inválida."); return; }
			int ventaId = (int)comboVentas.SelectedValue;
			int productoId = (int)comboProductos.SelectedValue;
			decimal cantidad = numericCantidad.Value;
			string motivo = txtMotivo.Text?.Trim();
			bool apto = chkApto.Checked;
			int? usuarioId = sesion.Usuario != null ? (int?)sesion.Usuario.Id : null;
			try
			{
				_bllDevolucion.RegistrarCliente(ventaId, productoId, cantidad, motivo, apto, usuarioId);

				// Generar Nota de Crédito (parcial, solo por lo devuelto)
				var venta = _bllVenta.ObtenerPorId(ventaId);
				var producto = _bllProducto.ObtenerPorId(productoId);
				var items = new System.Collections.Generic.List<(string Producto, decimal Cantidad, decimal PrecioUnit)>
				{
					(producto?.Nombre ?? $"Prod {productoId}", cantidad, ObtenerPrecioUnitarioDeVenta(ventaId, productoId))
				};
				string ruta = _bllFacturacion.GenerarNotaCreditoPDF(venta, items, motivo);
				_ultimaNotaCreditoRuta = ruta;
				if (btnAbrirNotaCredito != null) btnAbrirNotaCredito.Enabled = true;
				MessageBox.Show($"Devolución registrada.\nNota de Crédito generada en:\n{ruta}", ConstantesUI.Titulos.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
				MessageBox.Show("Devolución registrada.");
				Limpiar();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
			}
		}

		private decimal ObtenerPrecioUnitarioDeVenta(int ventaId, int productoId)
		{
			var detalles = _bllVenta.ObtenerDetallesPorVentaId(ventaId);
			var detalle = detalles?.FirstOrDefault(d => d.oProducto?.Id == productoId);
			return detalle?.Precio ?? 0m;
		}

		private void btnAbrirNotaCredito_Click(object sender, EventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(_ultimaNotaCreditoRuta))
				{
					_bllExportacion.AbrirArchivo(_ultimaNotaCreditoRuta);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"No se pudo abrir la Nota de Crédito: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Limpiar()
		{
			numericCantidad.Value = 0;
			txtMotivo.Text = string.Empty;
			chkApto.Checked = false;
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
			catch { }
		}

		public void Actualizar(BEs.Interfaces.IIdioma idioma)
		{
			foreach (Control control in ListaControles)
			{
				if (control.Tag != null)
				{
					string traduccion = Bll_Traduccion.BuscarTraduccion(control.Tag.ToString(), idioma.Id);
					if (!string.IsNullOrEmpty(traduccion)) control.Text = traduccion;
				}
			}
			RecorrerDataGridTraduccion(idioma);
			if (cboxIdiomas.DataSource != null && cboxIdiomas.Items.Count > 0 && cboxIdiomas.ValueMember != string.Empty)
			{
				cboxIdiomas.SelectedValue = idioma.Id;
			}
		}

		public void RecorrerDataGridTraduccion(BEs.Interfaces.IIdioma idioma)
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
							if (!string.IsNullOrEmpty(traduccion)) column.HeaderText = traduccion;
						}
					}
				}
			}
		}

		List<Control> ListaControles = new List<Control>();
		public void BuscarControles(ICollection controles)
		{
			foreach (Control control in controles)
			{
				ListaControles.Add(control);
				if (control.Controls.Count > 0) BuscarControles(control.Controls);
			}
		}
	}
}

