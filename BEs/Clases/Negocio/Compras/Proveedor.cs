using System;

namespace BEs.Clases.Negocio
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string CUIT { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}