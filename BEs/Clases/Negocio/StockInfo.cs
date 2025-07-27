namespace BEs.Clases.Negocio
{
    /// <summary>
    /// Información completa del stock de un producto
    /// </summary>
    public class StockInfo
    {
        public int ProductoId { get; set; }
        public decimal StockTotal { get; set; }
        public decimal StockReservado { get; set; }
        public decimal StockDisponible { get; set; }

        public bool TieneStockDisponible => StockDisponible > 0;
        public bool TieneStockBajo => StockDisponible <= 10 && StockDisponible > 0;
        public bool SinStock => StockDisponible <= 0;

        public string EstadoStock
        {
            get
            {
                if (SinStock) return "Sin Stock";
                if (TieneStockBajo) return "Stock Bajo";
                return "Stock OK";
            }
        }
    }

    /// <summary>
    /// Información sobre reservas liberadas automáticamente
    /// </summary>
    public class ReservasLiberadas
    {
        public int VentasCanceladas { get; set; }
        public int ProductosLiberados { get; set; }
        public decimal CantidadTotalLiberada { get; set; }

        public bool HuboLiberaciones => VentasCanceladas > 0;

        public override string ToString()
        {
            if (!HuboLiberaciones)
                return "No se encontraron reservas vencidas.";

            return $"Se cancelaron {VentasCanceladas} ventas, liberando {CantidadTotalLiberada} unidades de {ProductosLiberados} productos.";
        }
    }
}