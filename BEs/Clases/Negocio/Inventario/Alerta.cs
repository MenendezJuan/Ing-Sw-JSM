using BEs.Clases.Negocio.Enums;
using System;

namespace BEs.Clases.Negocio.Inventario
{
	public class Alerta
	{
		public int Id { get; set; }
		public TipoAlerta Tipo { get; set; }
		public int? ProductoId { get; set; }
		public string Mensaje { get; set; }
		public DateTime Fecha { get; set; }
		public bool Leida { get; set; }
	}
}


