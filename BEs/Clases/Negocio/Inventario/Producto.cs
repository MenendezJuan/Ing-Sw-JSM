using System;

namespace BEs.Clases.Negocio
{
    public class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public Categoria CategoriaEnum { get; set; }
        public decimal Stock { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}