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

namespace CheeseLogix
{
	public partial class frmAjustesStock : Form, IObservador
	{
		private readonly BLL_AJUSTESTOCK _bllAjuste;
		private readonly BLL_PRODUCTO _bllProducto;
		private SessionManager sesion;
		private BLL_IDIOMA Bll_Idioma;
		private BLL_TRADUCCION Bll_Traduccion;

		public frmAjustesStock()
		{
			InitializeComponent();
			sesion = SessionManager.GetInstance();
			Bll_Idioma = new BLL_IDIOMA();
			Bll_Traduccion = new BLL_TRADUCCION();
			_bllAjuste = new BLL_AJUSTESTOCK();
			_bllProducto = new BLL_PRODUCTO();
			CargarIdiomas();
			Actualizar(sesion.Idioma);
			CargarCombos();
			CargarPendientes();
		}

		private void CargarCombos()
		{
			var productos = _bllProducto.ObtenerTodos().Where(p => p.Estado).ToList();
			comboProductos.DataSource = productos;
			comboProductos.DisplayMember = "Nombre";
			comboProductos.ValueMember = "Id";

			comboTipo.DataSource = Enum.GetValues(typeof(TipoAjuste));
		}

		private void btnRegistrar_Click(object sender, EventArgs e)
		{
			if (comboProductos.SelectedValue == null || comboTipo.SelectedItem == null)
			{
				MessageBox.Show("Seleccione producto y tipo.");
				return;
			}
			if (numericCantidad.Value <= 0)
			{
				MessageBox.Show("La cantidad debe ser mayor a cero.");
				return;
			}

			int productoId = (int)comboProductos.SelectedValue;
			decimal cantidad = numericCantidad.Value;
			TipoAjuste tipo = (TipoAjuste)comboTipo.SelectedItem;
			string motivo = txtMotivo.Text?.Trim();
			int? usuarioId = sesion.oUsuario != null ? (int?)sesion.oUsuario.Id : null;

			try
			{
				_bllAjuste.RegistrarSolicitud(productoId, cantidad, tipo, motivo, usuarioId);
				MessageBox.Show("Solicitud registrada.");
				Limpiar();
				CargarPendientes();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
			}
		}

		private void CargarPendientes()
		{
			var ajustes = _bllAjuste.ListarPendientes();
			gridPendientes.DataSource = ajustes;
		}

		private void btnAprobar_Click(object sender, EventArgs e)
		{
			if (gridPendientes.CurrentRow == null) return;
			var ajuste = gridPendientes.CurrentRow.DataBoundItem as BEs.Clases.Negocio.Inventario.AjusteStock;
			if (ajuste == null) return;
			int aprobadorId = sesion.oUsuario != null ? sesion.oUsuario.Id : 0;
			_bllAjuste.Aprobar(ajuste.Id, aprobadorId);
			CargarPendientes();
		}

		private void btnRechazar_Click(object sender, EventArgs e)
		{
			if (gridPendientes.CurrentRow == null) return;
			var ajuste = gridPendientes.CurrentRow.DataBoundItem as BEs.Clases.Negocio.Inventario.AjusteStock;
			if (ajuste == null) return;
			int aprobadorId = sesion.oUsuario != null ? sesion.oUsuario.Id : 0;
			_bllAjuste.Rechazar(ajuste.Id, aprobadorId, "Rechazado");
			CargarPendientes();
		}

		private void Limpiar()
		{
			numericCantidad.Value = 0;
			txtMotivo.Text = string.Empty;
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

