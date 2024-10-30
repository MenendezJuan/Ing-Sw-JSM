using BEs.Clases.Negocio.Compras.Enums;
using System;
using System.Collections.Generic;

namespace BEs.Clases.Negocio.Compras
{
    public class Compra
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime Fecha { get; set; }
        public TipoPago TipoPagoEnum { get; set; }
        public EstadoCompra EstadoCompraEnum { get; set; }
        public int ProveedorId { get; set; }
        public Proveedor oProveedor { get; set; }
        public List<DetalleCompra> oDetalleCompra { get; set; }
    }
}
