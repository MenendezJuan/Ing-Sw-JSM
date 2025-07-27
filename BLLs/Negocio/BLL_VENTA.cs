using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Enums;
using BEs.Clases.Negocio.Ventas;
using MPPs;
using MPPs.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLLs.Negocio
{
    public class BLL_VENTA
    {
        private readonly MPP_VENTA ventaRepository;
        private readonly MPP_DETALLEVENTA detalleVentaRepository;
        private readonly MPP_PRODUCTO productoRepository;

        public BLL_VENTA()
        {
            ventaRepository = new MPP_VENTA();
            detalleVentaRepository = new MPP_DETALLEVENTA();
            productoRepository = new MPP_PRODUCTO();
        }

        // Método para insertar una nueva venta
        public int Insertar(Venta venta)
        {
            ValidarVenta(venta);
            
            // 1. RESERVAR STOCK para todos los productos
            if (!ReservarStockParaVenta(venta.oDetalleVenta))
            {
                throw new InvalidOperationException("No se pudo reservar el stock requerido para algunos productos.");
            }

            try
            {
                // 2. Crear la venta con stock reservado
                venta.EstadoVentaEnum = EstadoVenta.EnProceso;
                return ventaRepository.Insertar(venta);
            }
            catch
            {
                // Si falla la inserción, liberar el stock reservado
                LiberarStockParaVenta(venta.oDetalleVenta);
                throw;
            }
        }

        // Método para actualizar una venta existente
        public void Actualizar(Venta venta)
        {
            ValidarExistenciaVenta(venta.Id);
            ValidarVenta(venta);

            // Actualización de los detalles de la venta
            var detallesActuales = detalleVentaRepository.ObtenerPorVentaId(venta.Id);
            var detallesAActualizar = venta.oDetalleVenta.Where(d => detallesActuales.Any(da => da.Id == d.Id)).ToList();
            var detallesAEliminar = detallesActuales.Where(da => !venta.oDetalleVenta.Any(d => d.Id == da.Id)).ToList();
            var detallesAAgregar = venta.oDetalleVenta.Where(d => d.Id == 0).ToList();

            foreach (var detalle in detallesAEliminar)
            {
                detalleVentaRepository.Eliminar(detalle.Id);
            }

            foreach (var detalle in detallesAActualizar)
            {
                detalleVentaRepository.Actualizar(detalle);
            }

            foreach (var detalle in detallesAAgregar)
            {
                detalle.VentaId = venta.Id;
                detalleVentaRepository.Insertar(detalle);
            }

            ventaRepository.Actualizar(venta);
        }

        // Método para eliminar una venta y sus detalles
        public void Eliminar(int id)
        {
            ValidarExistenciaVenta(id);
            var venta = ventaRepository.ObtenerPorId(id);
            if (venta != null)
            {
                foreach (var detalle in venta.oDetalleVenta)
                {
                    detalleVentaRepository.Eliminar(detalle.Id);
                }
                ventaRepository.Eliminar(id);
            }
        }

        // Método para obtener una venta por su Id
        public Venta ObtenerPorId(int id)
        {
            return ventaRepository.ObtenerPorId(id);
        }

        // Método para obtener todas las ventas
        public List<Venta> ObtenerTodos()
        {
            return ventaRepository.ObtenerTodos();
        }

        // Método para obtener ventas por el Id del cliente
        public List<Venta> ObtenerVentasPorClienteId(int clienteId)
        {
            return ventaRepository.ObtenerVentasPorClienteId(clienteId);
        }

        // Método para obtener los detalles de una venta específica
        public List<DetalleVenta> ObtenerDetallesPorVentaId(int ventaId)
        {
            return detalleVentaRepository.ObtenerPorVentaId(ventaId);
        }

        public void CambiarEstadoVenta(int ventaId, EstadoVenta nuevoEstado)
        {
            ValidarExistenciaVenta(ventaId);
            var venta = ventaRepository.ObtenerPorId(ventaId);
            var estadoAnterior = venta.EstadoVentaEnum;

            // Cambiar estado en la base de datos
            ventaRepository.CambiarEstadoVenta(ventaId, nuevoEstado);

            // Manejar transiciones de stock según el nuevo estado
            switch (nuevoEstado)
            {
                case EstadoVenta.Entregada:
                    if (estadoAnterior == EstadoVenta.Cobrada)
                    {
                        // Confirmar venta: restar stock definitivamente y liberar reserva
                        foreach (var detalle in venta.oDetalleVenta)
                        {
                            if (!productoRepository.ConfirmarVentaStock(detalle.oProducto.Id, detalle.Cantidad))
                            {
                                throw new InvalidOperationException($"Error al confirmar stock para producto {detalle.oProducto.Nombre}");
                            }
                        }
                    }
                    break;

                case EstadoVenta.Cancelada:
                    if (estadoAnterior == EstadoVenta.EnProceso || estadoAnterior == EstadoVenta.Cobrada)
                    {
                        // Liberar stock reservado
                        foreach (var detalle in venta.oDetalleVenta)
                        {
                            if (!productoRepository.LiberarStock(detalle.oProducto.Id, detalle.Cantidad))
                            {
                                throw new InvalidOperationException($"Error al liberar stock para producto {detalle.oProducto.Nombre}");
                            }
                        }
                    }
                    break;
                    
                case EstadoVenta.Cobrada:
                    // En estado Cobrada, el stock sigue reservado hasta que se entregue
                    // No se hace nada con el stock aquí
                    break;
            }
        }

        // Este método ya no es necesario, la lógica se maneja en CambiarEstadoVenta
        [Obsolete("Use CambiarEstadoVenta instead. This method is deprecated.")]
        public void CambiarEstadoVentaYActualizarStock(int ventaId, EstadoVenta nuevoEstado)
        {
            CambiarEstadoVenta(ventaId, nuevoEstado);
        }

        // Método de validación para verificar la integridad de la venta antes de insertar o actualizar
        private void ValidarVenta(Venta venta)
        {
            if (venta == null)
                throw new ArgumentNullException("La venta no puede ser nula.");

            if (venta.oDetalleVenta == null || !venta.oDetalleVenta.Any())
                throw new ArgumentException("La venta debe tener al menos un detalle.");

            foreach (var detalle in venta.oDetalleVenta)
            {
                if (detalle.Cantidad <= 0)
                    throw new ArgumentException("La cantidad en el detalle debe ser mayor a cero.");
                if (detalle.oProducto == null || detalle.oProducto.Id <= 0)
                    throw new ArgumentException("Producto inválido en el detalle.");
                if (detalle.Precio <= 0)
                    throw new ArgumentException("El precio del producto debe ser mayor a cero.");
            }

            if (venta.MontoTotal <= 0)
                throw new ArgumentException("El monto total debe ser mayor a cero.");
        }

        // Método de validación para verificar la existencia de una venta antes de actualizar o eliminar
        private void ValidarExistenciaVenta(int ventaId)
        {
            var venta = ventaRepository.ObtenerPorId(ventaId);
            if (venta == null)
                throw new ArgumentException($"La venta con Id {ventaId} no existe.");
        }

        // ==========================================
        // MÉTODOS PARA GESTIÓN DE RESERVAS DE STOCK
        // ==========================================

        /// <summary>
        /// Reserva stock para todos los productos de una venta
        /// </summary>
        private bool ReservarStockParaVenta(List<DetalleVenta> detalles)
        {
            // Lista para hacer rollback en caso de error
            var reservasHechas = new List<(int ProductoId, decimal Cantidad)>();

            try
            {
                foreach (var detalle in detalles)
                {
                    if (!productoRepository.ReservarStock(detalle.oProducto.Id, detalle.Cantidad))
                    {
                        // Si no se puede reservar, revertir todas las reservas ya hechas
                        foreach (var reserva in reservasHechas)
                        {
                            productoRepository.LiberarStock(reserva.ProductoId, reserva.Cantidad);
                        }
                        return false;
                    }
                    
                    // Agregar a la lista de reservas exitosas
                    reservasHechas.Add((detalle.oProducto.Id, detalle.Cantidad));
                }
                return true;
            }
            catch
            {
                // En caso de excepción, revertir todas las reservas
                foreach (var reserva in reservasHechas)
                {
                    productoRepository.LiberarStock(reserva.ProductoId, reserva.Cantidad);
                }
                return false;
            }
        }

        /// <summary>
        /// Libera stock reservado para una venta (cuando se cancela)
        /// </summary>
        private void LiberarStockParaVenta(List<DetalleVenta> detalles)
        {
            foreach (var detalle in detalles)
            {
                productoRepository.LiberarStock(detalle.oProducto.Id, detalle.Cantidad);
            }
        }

        /// <summary>
        /// Valida que hay stock disponible para los productos (antes de intentar reservar)
        /// </summary>
        private void ValidarStockProductos(List<DetalleVenta> detalles)
        {
            foreach (var detalle in detalles)
            {
                var stockDisponible = productoRepository.ObtenerStockDisponible(detalle.oProducto.Id);
                if (stockDisponible < detalle.Cantidad)
                {
                    var producto = productoRepository.ObtenerPorId(detalle.oProducto.Id);
                    throw new InvalidOperationException(
                        $"Stock insuficiente para {producto?.Nombre ?? "producto"}. " +
                        $"Disponible: {stockDisponible}, Solicitado: {detalle.Cantidad}");
                }
            }
        }

        // Método para calcular el monto total de una venta
        public decimal CalcularMontoTotal(List<DetalleVenta> detalles)
        {
            if (detalles == null || !detalles.Any())
                return 0;

            return detalles.Sum(d => d.SubTotal);
        }

        // Método para procesar una venta completa (de EnProceso a Cobrada)
        public void ProcesarVenta(int ventaId)
        {
            var venta = ObtenerPorId(ventaId);
            if (venta == null)
                throw new ArgumentException($"La venta con Id {ventaId} no existe.");

            if (venta.EstadoVentaEnum != EstadoVenta.EnProceso)
                throw new InvalidOperationException("Solo se pueden procesar ventas en estado 'En Proceso'.");

            // El stock ya está reservado, solo cambiar estado a Cobrada
            CambiarEstadoVenta(ventaId, EstadoVenta.Cobrada);
        }

        // ==========================================
        // MÉTODOS ADICIONALES PARA GESTIÓN DE STOCK
        // ==========================================

        /// <summary>
        /// Obtiene información de stock disponible para un producto
        /// </summary>
        public StockInfo ObtenerInfoStock(int productoId)
        {
            return productoRepository.ObtenerInfoStock(productoId);
        }

        /// <summary>
        /// Libera automáticamente reservas de ventas vencidas
        /// </summary>
        /// <param name="minutosVencimiento">Minutos de vencimiento (default: 30)</param>
        /// <returns>Información sobre liberaciones realizadas</returns>
        public ReservasLiberadas LiberarReservasVencidas(int minutosVencimiento = 30)
        {
            return productoRepository.LiberarReservasVencidas(minutosVencimiento);
        }

        /// <summary>
        /// Cancela una venta y libera el stock reservado
        /// </summary>
        /// <param name="ventaId">ID de la venta a cancelar</param>
        /// <param name="motivo">Motivo de la cancelación</param>
        public void CancelarVenta(int ventaId, string motivo = null)
        {
            var venta = ObtenerPorId(ventaId);
            if (venta == null)
                throw new ArgumentException($"La venta con Id {ventaId} no existe.");

            if (venta.EstadoVentaEnum == EstadoVenta.Entregada)
                throw new InvalidOperationException("No se puede cancelar una venta ya entregada.");

            if (venta.EstadoVentaEnum == EstadoVenta.Cancelada)
                throw new InvalidOperationException("La venta ya está cancelada.");

            // Actualizar comentario con el motivo si se proporciona
            if (!string.IsNullOrWhiteSpace(motivo))
            {
                venta.Comentario = string.IsNullOrWhiteSpace(venta.Comentario) 
                    ? $"Cancelada: {motivo}" 
                    : $"{venta.Comentario} | Cancelada: {motivo}";
                
                Actualizar(venta);
            }

            // Cambiar estado (esto liberará automáticamente el stock)
            CambiarEstadoVenta(ventaId, EstadoVenta.Cancelada);
        }

        /// <summary>
        /// Verifica si se puede procesar una venta (tiene stock reservado suficiente)
        /// </summary>
        /// <param name="ventaId">ID de la venta</param>
        /// <returns>True si se puede procesar</returns>
        public bool PuedeProcesarVenta(int ventaId)
        {
            var venta = ObtenerPorId(ventaId);
            if (venta == null || venta.EstadoVentaEnum != EstadoVenta.EnProceso)
                return false;

            // Verificar que todos los productos tienen stock disponible/reservado
            foreach (var detalle in venta.oDetalleVenta)
            {
                var stockInfo = productoRepository.ObtenerInfoStock(detalle.oProducto.Id);
                if (stockInfo == null || stockInfo.StockReservado < detalle.Cantidad)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Obtiene un resumen de ventas por estado
        /// </summary>
        /// <returns>Diccionario con cantidad de ventas por estado</returns>
        public Dictionary<EstadoVenta, int> ObtenerResumenVentasPorEstado()
        {
            var todasLasVentas = ObtenerTodos();
            return todasLasVentas
                .GroupBy(v => v.EstadoVentaEnum)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        /// <summary>
        /// Obtiene ventas que están próximas a vencer (en proceso por más de X minutos)
        /// </summary>
        /// <param name="minutos">Minutos desde creación</param>
        /// <returns>Lista de ventas próximas a vencer</returns>
        public List<Venta> ObtenerVentasProximasAVencer(int minutos = 25)
        {
            var ventasEnProceso = ObtenerTodos()
                .Where(v => v.EstadoVentaEnum == EstadoVenta.EnProceso)
                .Where(v => v.Fecha.AddMinutes(minutos) <= DateTime.Now)
                .OrderBy(v => v.Fecha)
                .ToList();

            return ventasEnProceso;
        }
    }
} 