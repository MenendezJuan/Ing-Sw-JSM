using BEs.Clases.Negocio.Inventario;
using BEs.Interfaces;
using System;
using System.Collections.Generic;

namespace BEs.Clases.Negocio
{
    public class Producto : Entidad, IVerificableEntity
    {
        [PropiedadVerificable(1)]
        public string Codigo { get; set; }

        [PropiedadVerificable(2)]
        public Categoria CategoriaEnum { get; set; }

        [PropiedadVerificable(3, false)] // No crítica, puede cambiar frecuentemente
        public decimal? Stock { get; set; }

        [PropiedadVerificable(4)]
        public string Nombre { get; set; }

        [PropiedadVerificable(5)]
        public string Descripcion { get; set; }

        [PropiedadVerificable(6)]
        public decimal PrecioCompra { get; set; }

        [PropiedadVerificable(7, false)] // No crítica, puede cambiar frecuentemente
        public decimal? PrecioVenta { get; set; }

        [PropiedadVerificable(8)]
        public bool Estado { get; set; }

        [PropiedadVerificable(9)]
        public DateTime Fecha { get; set; }

        // Propiedades para sistema de reservas
        public decimal StockReservado { get; set; } = 0;

        // Propiedad calculada: Stock disponible = Stock - StockReservado
        public decimal StockDisponible
        {
            get
            {
                return (Stock ?? 0) - StockReservado;
            }
        }

        [PropiedadVerificable(10, false)] // No crítica, configuración administrativa
        public decimal StockMinimo { get; set; } = 0;

        public List<ProductoProveedor> Proveedores { get; set; } = new List<ProductoProveedor>();

        // Propiedad para dígito verificador
        public string DV { get; set; }
    }
}