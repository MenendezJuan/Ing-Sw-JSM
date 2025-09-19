using BEs.Clases;
using BEs.Clases.Negocio.Enums;
using BEs.Interfaces;
using System;
using System.Collections.Generic;

namespace BEs.Clases.Negocio.Ventas
{
    public class Venta : Entidad, IVerificableEntity
    {
        [PropiedadVerificable(1, false)] // No crítica, puede ser opcional
        public string Comentario { get; set; }
        
        [PropiedadVerificable(2)]
        public decimal MontoTotal { get; set; }
        
        [PropiedadVerificable(3)]
        public DateTime Fecha { get; set; }
        
        [PropiedadVerificable(4)]
        public TipoPago TipoPagoEnum { get; set; }
        
        [PropiedadVerificable(5)]
        public EstadoVenta EstadoVentaEnum { get; set; }
        
        [PropiedadVerificable(6)]
        public int? ClienteId { get; set; }
        
        [PropiedadVerificable(7)]
        public int? UsuarioVendedorId { get; set; }
        public Cliente oCliente { get; set; }
        public Usuario oVendedor { get; set; }
        public List<DetalleVenta> oDetalleVenta { get; set; }

        // Propiedades calculadas para la UI
        public string NombreCliente => oCliente?.NombreCompleto ?? "Cliente no disponible";
        
        public string NombreVendedor 
        { 
            get 
            {
                if (oVendedor?.Email != null)
                {
                    // Extraer el nombre antes del @ del email
                    var partes = oVendedor.Email.Split('@');
                    return partes.Length > 0 ? partes[0] : "No disponible";
                }
                return "No disponible";
            } 
        }
        
        // Propiedad para dígito verificador
        public string DV { get; set; }
    }
}