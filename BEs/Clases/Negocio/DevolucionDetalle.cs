using BEs.Clases;
using BEs.Interfaces;

namespace BEs.Clases.Negocio.Ventas
{
    public class DevolucionDetalle : Entidad, IVerificableEntity
    {
        [PropiedadVerificable(1)]
        public int DevolucionId { get; set; }

        [PropiedadVerificable(2)]
        public int ProductoId { get; set; }

        [PropiedadVerificable(3)]
        public decimal Cantidad { get; set; }

        public Devolucion oDevolucion { get; set; }
        public Producto oProducto { get; set; }

        public string DV { get; set; }

        public string NombreProducto => oProducto?.Nombre ?? "Producto no disponible";
        public decimal PrecioProducto => oProducto?.PrecioVenta ?? 0;
        public decimal Subtotal => Cantidad * PrecioProducto;
    }
}
