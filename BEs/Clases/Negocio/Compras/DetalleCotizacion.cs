using System;

namespace BEs.Clases.Negocio.Compras
{
    public class DetalleCotizacion
    {
        public int Id { get; set; }
        public int CotizacionId { get; set; }
        public int ProductoId { get; set; }
        public Producto oProducto { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        public string NombreProducto => oProducto?.Nombre ?? "Sin Proveedor";
    }
}
