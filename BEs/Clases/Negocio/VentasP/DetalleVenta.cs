using BEs.Clases.Negocio.Ventas;
using System;

namespace BEs.Clases.Negocio.Ventas
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public Venta oVenta { get; set; }
        public int ProductoId { get; set; }
        public Producto oProducto { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime Fecha { get; set; }

        public string NombreProducto => oProducto?.Nombre ?? "Producto no disponible";
    }
} 