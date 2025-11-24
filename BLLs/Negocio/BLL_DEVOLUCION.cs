using BEs;
using BEs.Clases.Negocio.Enums;
using BEs.Clases.Negocio.Ventas;
using BLLs.Tecnica;
using MPPs;
using MPPs.Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BLLs.Negocio
{
    public class BLL_DEVOLUCION
    {
        private readonly MPP_DEVOLUCION devolucionRepository;
        private readonly MPP_VENTA ventaRepository;
        private readonly MPP_PRODUCTO productoRepository;
        private readonly MPP_USUARIO usuarioRepository;
        private readonly BLL_CONTROLCAMBIOS _bllControlCambios;
        private readonly BLL_VENTA _bllVenta;

        public BLL_DEVOLUCION()
        {
            devolucionRepository = new MPP_DEVOLUCION();
            ventaRepository = new MPP_VENTA();
            productoRepository = new MPP_PRODUCTO();
            usuarioRepository = new MPP_USUARIO();
            _bllControlCambios = new BLL_CONTROLCAMBIOS();
            _bllVenta = new BLL_VENTA();
        }

        /// <summary>
        /// Inicia una nueva devolución con validaciones de negocio
        /// </summary>
        public int Iniciar(BEs.Clases.Negocio.Ventas.Devolucion devolucion, List<BEs.Clases.Negocio.Ventas.DevolucionDetalle> detalles)
        {
            ValidarDevolucionParaInicio(devolucion, detalles);

            devolucion.DV = Seguridad.Seguridad.CalcularDigitoVerificadorHorizontal(devolucion);

            foreach (var detalle in detalles)
            {
                detalle.DV = Seguridad.Seguridad.CalcularDigitoVerificadorHorizontal(detalle);
            }

            int devolucionId = devolucionRepository.Crear(devolucion, detalles);

            _bllControlCambios.ActualizarDigitoVerificador("DEVOLUCION", devolucionId);
            _bllControlCambios.ActualizarDVVTabla("DEVOLUCION_DETALLE");

            var bllBitacora = new BLL_BITACORA();
            var mppBitacora = new MPPs.MPP_BITACORA();
            mppBitacora.Agregar(SessionManager.GetInstance().oUsuario,
                BEs.Enum_TiposBitacora.INFO,
                $"Devolución iniciada: {devolucion.NumeroDevolucion} para venta {devolucion.NumeroVenta}");

            return devolucionId;
        }

        /// <summary>
        /// Evalúa una devolución (Gerente aprueba o rechaza)
        /// </summary>
        public void Evaluar(int devolucionId, EstadoDevolucion decision, string observacionesGerente, int usuarioGerenteId)
        {
            var devolucion = devolucionRepository.ObtenerPorId(devolucionId);
            if (devolucion == null)
                throw new ArgumentException($"La devolución con ID {devolucionId} no existe.");

            if (devolucion.Estado != EstadoDevolucion.EnEvaluacion)
                throw new InvalidOperationException("La devolución debe estar en estado 'En Evaluación' para poder evaluarse.");

            // Actualizar evaluación
            devolucionRepository.ActualizarEstadoEvaluacion(devolucionId, decision, observacionesGerente, usuarioGerenteId, DateTime.Now);

            // Actualizar DVH en BD
            try
            {
                _bllControlCambios.ActualizarDigitoVerificador("DEVOLUCION", devolucionId);
                _bllControlCambios.ActualizarDVVTabla("DEVOLUCION");
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("DV para DEVOLUCION no soportado por ControlCambios aún. Continuando.");
            }

            // Registrar en bitácora
            string mensajeBitacora = decision == EstadoDevolucion.Autorizada
                ? $"Devolución autorizada: {devolucion.NumeroDevolucion}"
                : $"Devolución rechazada: {devolucion.NumeroDevolucion}";
            RegistrarBitacora(mensajeBitacora);
        }

        /// <summary>
        /// Pone una devolución en estado 'En Evaluación' (transición desde 'Iniciada').
        /// </summary>
        public void EnviarAEvaluacion(int devolucionId, int usuarioGerenteId)
        {
            var devolucion = devolucionRepository.ObtenerPorId(devolucionId);
            if (devolucion == null)
                throw new ArgumentException($"La devolución con ID {devolucionId} no existe.");

            if (devolucion.Estado == EstadoDevolucion.EnEvaluacion)
                return; 
            if (devolucion.Estado != EstadoDevolucion.Iniciada)
                throw new InvalidOperationException("Solo se pueden enviar a evaluación devoluciones 'Iniciadas'.");

            devolucionRepository.ActualizarEstadoEvaluacion(devolucionId, EstadoDevolucion.EnEvaluacion, string.Empty, usuarioGerenteId, DateTime.Now);

            try
            {
                _bllControlCambios.ActualizarDigitoVerificador("DEVOLUCION", devolucionId);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("DV para DEVOLUCION no soportado por ControlCambios aún. Continuando.");
            }
            RegistrarBitacora($"Devolución enviada a evaluación: {devolucion.NumeroDevolucion}");
        }

        /// <summary>
        /// Procesa una devolución autorizada (Encargado de Depósito)
        /// </summary>
        public void Procesar(int devolucionId, string observacionesDeposito, int usuarioDepositoId)
        {
            var devolucion = devolucionRepository.ObtenerPorId(devolucionId);
            if (devolucion == null)
                throw new ArgumentException($"La devolución con ID {devolucionId} no existe.");

            if (devolucion.Estado != EstadoDevolucion.Autorizada)
                throw new InvalidOperationException("La devolución debe estar autorizada para poder procesarse.");

            // Validar stock disponible para los productos de reemplazo
            if (!ValidarStockParaReemplazo(devolucion.oDetalles))
                throw new InvalidOperationException("No hay suficiente stock disponible para los productos de reemplazo.");

            // Procesar la devolución
            devolucionRepository.Procesar(devolucionId, observacionesDeposito, usuarioDepositoId, DateTime.Now);

            // Generar archivo TXT de conformidad
            GenerarConformeDevolucion(devolucion, usuarioDepositoId);

            try
            {
                _bllControlCambios.ActualizarDigitoVerificador("DEVOLUCION", devolucionId);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("DV para DEVOLUCION no soportado por ControlCambios aún. Continuando.");
            }

            // Registrar en bitácora
            RegistrarBitacora($"Devolución procesada: {devolucion.NumeroDevolucion}");
        }

        /// <summary>
        /// Devuelve el path del último archivo TXT de conformidad generado para una devolución
        /// </summary>
        public string ObtenerUltimoArchivoConforme(int devolucionId)
        {
            try
            {
                string directorio = @"C:\CheeseLogix\FirmadoConforme";
                if (!Directory.Exists(directorio))
                    return string.Empty;

                string prefix = $"Conforme_Devolucion_{devolucionId}_";
                var archivos = Directory.EnumerateFiles(directorio, "Conforme_Devolucion_*.txt")
                    .Where(p => Path.GetFileName(p).StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    .Select(p => new FileInfo(p))
                    .OrderByDescending(fi => fi.CreationTimeUtc)
                    .ToList();

                return archivos.FirstOrDefault()?.FullName ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Lista devoluciones con filtros opcionales
        /// </summary>
        public List<BEs.Clases.Negocio.Ventas.Devolucion> Listar(int? clienteId = null, int? ventaId = null, EstadoDevolucion? estado = null)
        {
            return devolucionRepository.Listar(clienteId, ventaId, estado);
        }

        /// <summary>
        /// Obtiene una devolución completa por ID
        /// </summary>
        public BEs.Clases.Negocio.Ventas.Devolucion ObtenerPorId(int id)
        {
            return devolucionRepository.ObtenerPorId(id);
        }

        /// <summary>
        /// Obtiene la cantidad total devuelta acumulada para un producto en una venta específica
        /// </summary>
        public decimal ObtenerCantidadDevueltaAcumulada(int ventaId, int productoId)
        {
            return devolucionRepository.ObtenerCantidadDevueltaAcumulada(ventaId, productoId);
        }

        /// <summary>
        /// Obtiene la cantidad devuelta de un producto específico en una venta
        /// </summary>
        public decimal ObtenerCantidadDevueltaProductoVenta(int ventaId, int productoId)
        {
            return ObtenerCantidadDevueltaAcumulada(ventaId, productoId);
        }

        /// <summary>
        /// Obtiene IDs de ventas que ya tienen devoluciones
        /// </summary>
        public List<int> ObtenerVentasConDevoluciones()
        {
            var devoluciones = devolucionRepository.Listar();
            return devoluciones.Select(d => d.VentaId).Distinct().ToList();
        }

        /// <summary>
        /// Registra una devolución de cliente (alias de Iniciar)
        /// </summary>
        public int RegistrarCliente(int ventaId, int productoId, decimal cantidad, string motivo, bool apto)
        {
            var venta = ventaRepository.ObtenerPorId(ventaId);
            if (venta == null)
                throw new Exception("Venta no encontrada");

            var producto = productoRepository.ObtenerPorId(productoId);
            if (producto == null)
                throw new Exception("Producto no encontrado");

            var detalle = new BEs.Clases.Negocio.Ventas.DevolucionDetalle
            {
                ProductoId = productoId,
                Cantidad = cantidad
            };

            var devolucion = new BEs.Clases.Negocio.Ventas.Devolucion
            {
                VentaId = ventaId,
                Motivo = motivo,
                Estado = EstadoDevolucion.Iniciada
            };

            return Iniciar(devolucion, new List<BEs.Clases.Negocio.Ventas.DevolucionDetalle> { detalle });
        }

        #region VALIDACIONES

        /// <summary>
        /// Valida una devolución antes de iniciarla
        /// </summary>
        private void ValidarDevolucionParaInicio(Devolucion devolucion, List<DevolucionDetalle> detalles)
        {
            if (devolucion == null)
                throw new ArgumentNullException("La devolución no puede ser nula.");

            if (detalles == null || !detalles.Any())
                throw new ArgumentException("La devolución debe tener al menos un producto.");

            if (string.IsNullOrWhiteSpace(devolucion.Motivo))
                throw new ArgumentException("El motivo de la devolución es obligatorio.");

            // Validar venta
            var venta = ventaRepository.ObtenerPorId(devolucion.VentaId);
            if (venta == null)
                throw new ArgumentException("La venta especificada no existe.");

            if (venta.EstadoVentaEnum != BEs.Clases.Negocio.Enums.EstadoVenta.Entregada)
                throw new ArgumentException("Solo se pueden devolver productos de ventas entregadas.");

            // Validar plazo de 15 días
            var diasDesdeVenta = (DateTime.Now - venta.Fecha).TotalDays;
            if (diasDesdeVenta > 15)
                throw new ArgumentException("Han transcurrido más de 15 días desde la venta. No se permite devolución.");

            // Validar cada detalle
            foreach (var detalle in detalles)
            {
                ValidarDetalleDevolucion(detalle, venta);
            }
        }

        /// <summary>
        /// Valida un detalle de devolución
        /// </summary>
        private void ValidarDetalleDevolucion(DevolucionDetalle detalle, Venta venta)
        {
            if (detalle.Cantidad <= 0)
                throw new ArgumentException("La cantidad a devolver debe ser mayor a cero.");

            // Verificar que el producto pertenece a la venta
            var detalleVenta = venta.oDetalleVenta?.FirstOrDefault(dv => dv.ProductoId == detalle.ProductoId);
            if (detalleVenta == null)
                throw new ArgumentException($"El producto {detalle.ProductoId} no pertenece a la venta especificada.");

            // Verificar que no se exceda la cantidad vendida menos ya devuelta
            var cantidadYaDevuelta = devolucionRepository.ObtenerCantidadDevueltaAcumulada(venta.Id, detalle.ProductoId);
            var cantidadDisponible = detalleVenta.Cantidad - cantidadYaDevuelta;

            if (detalle.Cantidad > cantidadDisponible)
                throw new ArgumentException($"La cantidad a devolver ({detalle.Cantidad}) excede la cantidad disponible ({cantidadDisponible}) para este producto.");
        }

        /// <summary>
        /// Valida que hay stock suficiente para los productos de reemplazo
        /// </summary>
        private bool ValidarStockParaReemplazo(List<DevolucionDetalle> detalles)
        {
            foreach (var detalle in detalles)
            {
                var producto = productoRepository.ObtenerPorId(detalle.ProductoId);
                if (producto == null)
                    return false;

                var stockDisponible = producto.Stock - producto.StockReservado;
                if (detalle.Cantidad > stockDisponible)
                    return false;
            }
            return true;
        }

        #endregion

        #region UTILIDADES

        /// <summary>
        /// Genera el archivo TXT de conformidad de devolución
        /// </summary>
        /// <returns>Path completo del archivo generado</returns>
        private string GenerarConformeDevolucion(Devolucion devolucion, int usuarioDepositoId)
        {
            try
            {
                string directorio = @"C:\CheeseLogix\FirmadoConforme";
                Directory.CreateDirectory(directorio);

                string nombreArchivo = $"Conforme_Devolucion_{devolucion.Id}_{DateTime.Now:yyyyMMddHHmm}.txt";
                string rutaCompleta = Path.Combine(directorio, nombreArchivo);

                var usuarioDeposito = usuarioRepository.ObtenerPorId(usuarioDepositoId);

                using (StreamWriter writer = new StreamWriter(rutaCompleta))
                {
                    writer.WriteLine("=========================================");
                    writer.WriteLine("   CONFORME DE DEVOLUCIÓN - CHEESE LOGIX");
                    writer.WriteLine("=========================================");
                    writer.WriteLine();
                    writer.WriteLine($"Número de Devolución: {devolucion.NumeroDevolucion}");
                    writer.WriteLine($"Fecha de Devolución: {DateTime.Now:dd/MM/yyyy HH:mm}");
                    writer.WriteLine($"Número de Venta: {devolucion.NumeroVenta}");
                    writer.WriteLine($"Cliente: {devolucion.NombreCliente}");
                    writer.WriteLine($"Motivo: {devolucion.Motivo}");
                    writer.WriteLine();
                    writer.WriteLine("PRODUCTOS DEVUELTOS Y REEMPLAZADOS:");
                    writer.WriteLine("------------------------------------");

                    foreach (var detalle in devolucion.oDetalles)
                    {
                        writer.WriteLine($"- {detalle.NombreProducto}: {detalle.Cantidad} unidades");
                    }

                    writer.WriteLine();
                    writer.WriteLine("FIRMA DEL CLIENTE: ___________________________");
                    writer.WriteLine();
                    writer.WriteLine($"FIRMA DEL ENCARGADO DE DEPÓSITO: {usuarioDeposito?.Email?.Split('@')[0] ?? "Usuario"}");
                    writer.WriteLine($"Fecha de procesamiento: {DateTime.Now:dd/MM/yyyy HH:mm}");
                    writer.WriteLine();
                    writer.WriteLine("=========================================");
                    writer.WriteLine("   PRODUCTOS EN BUENAS CONDICIONES");
                    writer.WriteLine("=========================================");
                }

                return rutaCompleta;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error generando archivo conforme: {ex.Message}");
                throw new Exception("Error al generar el archivo de conformidad.");
            }
        }

        /// <summary>
        /// Registra evento en bitácora
        /// </summary>
        private void RegistrarBitacora(string mensaje)
        {
            try
            {
                var mppBitacora = new MPPs.MPP_BITACORA();
                mppBitacora.Agregar(SessionManager.GetInstance().oUsuario,
                    BEs.Enum_TiposBitacora.INFO,
                    mensaje);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error registrando bitácora: {ex.Message}");
            }
        }

        #endregion
    }
}