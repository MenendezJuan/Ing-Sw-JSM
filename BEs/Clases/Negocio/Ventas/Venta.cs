using BEs.Clases.Negocio.Enums;
using System;
using System.Collections.Generic;

namespace BEs.Clases.Negocio.Ventas
{
    public class Venta
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime Fecha { get; set; }
        public TipoPago TipoPagoEnum { get; set; }
        public EstadoVenta EstadoVentaEnum { get; set; }
        public int? ClienteId { get; set; }
        public int? UsuarioVendedorId { get; set; }
        public Cliente oCliente { get; set; }
        public Usuario oVendedor { get; set; }
        public List<DetalleVenta> oDetalleVenta { get; set; }

        public string NombreCliente => oCliente?.NombreCompleto ?? "Cliente no disponible";
    }
}