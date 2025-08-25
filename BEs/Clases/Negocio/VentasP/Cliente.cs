using System;

namespace BEs.Clases.Negocio.Ventas
{
    public class Cliente
    {
        public int Id { get; set; }
        public string CUIT { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public string NombreCompleto => $"{Nombre} {Apellido}";

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}