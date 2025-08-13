using BEs.Clases.Negocio.Enums;
using System;

namespace BEs.Clases.Negocio.Inventario
{
	public class AjusteStock
	{
		public int Id { get; set; }
		public int ProductoId { get; set; }
		public decimal Cantidad { get; set; }
		public TipoAjuste Tipo { get; set; }
		public string Motivo { get; set; }
		public DateTime Fecha { get; set; }
		public int? UsuarioSolicitanteId { get; set; }
		public int? UsuarioAprobadorId { get; set; }
		public EstadoAjuste Estado { get; set; }
	}
}

