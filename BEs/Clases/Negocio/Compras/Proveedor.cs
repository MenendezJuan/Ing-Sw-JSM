using BEs.Clases.Negocio.Inventario;
using System;
using System.Collections.Generic;

namespace BEs.Clases.Negocio
{
    public class Proveedor
    {
        public int Id { get; set; }
        [PropiedadVerificable]
        public string CUIT { get; set; }
        [PropiedadVerificable]
        public string Descripcion { get; set; }
        [PropiedadVerificable]
        public string Direccion { get; set; }
        [PropiedadVerificable]
        public string Mail { get; set; }
        [PropiedadVerificable]
        public string Telefono { get; set; }
        [PropiedadVerificable]
        public bool Estado { get; set; }
        [PropiedadVerificable]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public List<ProductoProveedor> Productos { get; set; } = new List<ProductoProveedor>();
        public override string ToString()
        {
            return Descripcion;
        }
    }
}