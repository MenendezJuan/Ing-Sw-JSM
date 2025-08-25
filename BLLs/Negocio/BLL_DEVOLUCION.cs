using BEs.Clases.Negocio.Enums;
using BEs.Clases.Negocio.Inventario;
using MPPs.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLLs.Negocio
{
    public class BLL_DEVOLUCION
    {
        private readonly MPP_DEVOLUCION _repo;
        private readonly MPP_PRODUCTO _productoRepo;

        public BLL_DEVOLUCION()
        {
            _repo = new MPP_DEVOLUCION();
            _productoRepo = new MPP_PRODUCTO();
        }

        public int RegistrarCliente(int ventaId, int productoId, decimal cantidad, string motivo, bool aptoParaVenta, int? usuarioId)
        {
            ValidarComun(productoId, cantidad, motivo);
            var dev = new Devolucion
            {
                Origen = OrigenDevolucion.Cliente,
                VentaId = ventaId,
                ProductoId = productoId,
                Cantidad = cantidad,
                Motivo = motivo,
                AptoParaVenta = aptoParaVenta,
                Fecha = DateTime.Now,
                UsuarioId = usuarioId
            };
            int id = _repo.Insertar(dev);

            if (aptoParaVenta)
            {
                _productoRepo.ActualizarStock(productoId, cantidad);
            }
            return id;
        }

        public int RegistrarProveedor(int compraId, int productoId, decimal cantidad, string motivo, bool yaIngresadoAStock, int? usuarioId)
        {
            ValidarComun(productoId, cantidad, motivo);
            var dev = new Devolucion
            {
                Origen = OrigenDevolucion.Proveedor,
                CompraId = compraId,
                ProductoId = productoId,
                Cantidad = cantidad,
                Motivo = motivo,
                AptoParaVenta = false,
                Fecha = DateTime.Now,
                UsuarioId = usuarioId
            };
            int id = _repo.Insertar(dev);

            if (yaIngresadoAStock)
            {
                _productoRepo.ActualizarStock(productoId, -cantidad);
            }
            return id;
        }

        public List<Devolucion> Listar()
        {
            return _repo.Listar();
        }

        /// <summary>
        /// Obtiene las IDs de ventas que ya tienen devoluciones registradas
        /// </summary>
        public List<int> ObtenerVentasConDevoluciones()
        {
            var devoluciones = _repo.Listar();
            return devoluciones.Where(d => d.VentaId.HasValue)
                .Select(d => d.VentaId.Value)
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Obtiene la cantidad total ya devuelta de un producto específico en una venta específica
        /// </summary>
        /// <param name="ventaId">ID de la venta</param>
        /// <param name="productoId">ID del producto</param>
        /// <returns>Cantidad total devuelta</returns>
        public decimal ObtenerCantidadDevueltaProductoVenta(int ventaId, int productoId)
        {
            try
            {
                var devoluciones = _repo.Listar();
                return devoluciones
                    .Where(d => d.VentaId == ventaId && d.ProductoId == productoId)
                    .Sum(d => d.Cantidad);
            }
            catch (Exception)
            {
                // En caso de error, retornar 0 para no bloquear la operación
                return 0;
            }
        }

        private static void ValidarComun(int productoId, decimal cantidad, string motivo)
        {
            if (productoId <= 0) throw new ArgumentException("Producto inválido", nameof(productoId));
            if (cantidad <= 0) throw new ArgumentException("Cantidad debe ser mayor a cero", nameof(cantidad));
            if (string.IsNullOrWhiteSpace(motivo)) throw new ArgumentException("Motivo es obligatorio", nameof(motivo));
        }
    }
}