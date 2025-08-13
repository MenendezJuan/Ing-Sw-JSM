using BEs.Clases.Negocio.Enums;
using System;

namespace BEs.Clases.Negocio.Inventario
{
	public class Devolucion
	{
		public int Id { get; set; }
		public OrigenDevolucion Origen { get; set; }
		public int? VentaId { get; set; }
		public int? CompraId { get; set; }
		public int ProductoId { get; set; }
		public decimal Cantidad { get; set; }
		public string Motivo { get; set; }
		public bool AptoParaVenta { get; set; }
		public DateTime Fecha { get; set; }
		public int? UsuarioId { get; set; }
	}
}

