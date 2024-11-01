using BEs.Clases.Negocio.Compras;
using System;

namespace BEs.Clases.Negocio
{
    public class DetalleCompra
    {
        public int Id { get; set; }
        public int CompraId { get; set; }
        public int? CotizacionId { get; set; }
        public Compra oCompra { get; set; }
        public int ProductoId { get; set; }
        public Producto oProducto { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime Fecha { get; set; }
    }

}