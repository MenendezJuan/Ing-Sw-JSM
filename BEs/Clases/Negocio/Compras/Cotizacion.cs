using BEs.Clases.Negocio.Enums;
using System;
using System.Collections.Generic;

namespace BEs.Clases.Negocio.Compras
{
    public class Cotizacion
    {
        public int Id { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public int ProveedorId { get; set; }
        public EstadoCotizacion EstadoCotizacionEnum { get; set; }
        public Proveedor Proveedor { get; set; }
        public List<DetalleCotizacion> DetallesCotizacion { get; set; }

        public string DescripcionProveedor => Proveedor?.Descripcion ?? "Sin Proveedor";
    }
}
