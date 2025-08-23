using System;
using System.Collections.Generic;

namespace BEs.Clases.Negocio.Ventas
{
    public class Cliente
    {
        public int Id { get; set; }
        [PropiedadVerificable]
        public string CUIT { get; set; }
        [PropiedadVerificable]
        public string Nombre { get; set; }
        [PropiedadVerificable]
        public string Apellido { get; set; }
        [PropiedadVerificable]
        public string Direccion { get; set; }
        [PropiedadVerificable]
        public string Mail { get; set; }
        [PropiedadVerificable]
        public string Telefono { get; set; }
        [PropiedadVerificable]
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public string NombreCompleto => $"{Nombre} {Apellido}";

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
} 