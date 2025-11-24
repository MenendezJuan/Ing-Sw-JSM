using BEs.Clases;
using BEs.Clases.Negocio.Enums;
using BEs.Interfaces;
using System;
using System.Collections.Generic;

namespace BEs.Clases.Negocio.Ventas
{
    public class Devolucion : Entidad, IVerificableEntity
    {
        [PropiedadVerificable(1)]
        public int VentaId { get; set; }

        [PropiedadVerificable(2)]
        public DateTime FechaSolicitud { get; set; }

        [PropiedadVerificable(3)]
        public EstadoDevolucion Estado { get; set; }

        [PropiedadVerificable(4, false)]
        public string Motivo { get; set; }

        [PropiedadVerificable(5, false)]
        public string ObservacionesGerente { get; set; }

        [PropiedadVerificable(6, false)]
        public DateTime? FechaDecision { get; set; }

        [PropiedadVerificable(7, false)]
        public int? UsuarioGerenteId { get; set; }

        [PropiedadVerificable(8, false)]
        public string ObservacionesDeposito { get; set; }

        [PropiedadVerificable(9, false)]
        public DateTime? FechaProcesamiento { get; set; }

        [PropiedadVerificable(10, false)]
        public int? UsuarioDepositoId { get; set; }

        public Venta oVenta { get; set; }
        public Usuario oUsuarioGerente { get; set; }
        public Usuario oUsuarioDeposito { get; set; }
        public List<DevolucionDetalle> oDetalles { get; set; }

        public string DV { get; set; }

        public string NumeroDevolucion => $"DEV-{Id:00000}";
        public string EstadoTexto => Estado.ToString();
        public string NombreCliente => oVenta?.oCliente?.NombreCompleto ?? "Cliente no disponible";
        public string NumeroVenta => oVenta != null ? $"VTA-{oVenta.Id:00000}" : "Venta no disponible";
        public string NombreUsuarioGerente => oUsuarioGerente != null ? oUsuarioGerente.Email.Split('@')[0] : "No asignado";
        public string NombreUsuarioDeposito => oUsuarioDeposito != null ? oUsuarioDeposito.Email.Split('@')[0] : "No asignado";
    }
}
