using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Compras;
using BEs.Clases.Negocio.Compras.Enums;
using MPPs;
using MPPs.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLLs.Negocio
{
    public class BLL_COMPRA
    {
        private readonly MPP_COMPRA compraRepository;
        private readonly MPP_DETALLECOMPRA detalleCompraRepository;
        private readonly MPP_PRODUCTO productoRepository;

        public BLL_COMPRA()
        {
            compraRepository = new MPP_COMPRA();
            detalleCompraRepository = new MPP_DETALLECOMPRA();
            productoRepository = new MPP_PRODUCTO();
        }

        // Método para insertar una nueva compra
        public int Insertar(Compra compra)
        {
            ValidarCompra(compra);
            return compraRepository.Insertar(compra);
        }

        // Método para actualizar una compra existente
        public void Actualizar(Compra compra)
        {
            ValidarExistenciaCompra(compra.Id);  // Nueva validación
            ValidarCompra(compra);
            compraRepository.Actualizar(compra);

            // Actualización de los detalles de la compra
            var detallesActuales = detalleCompraRepository.ObtenerPorCompraId(compra.Id);
            var detallesAActualizar = compra.oDetalleCompra.Where(d => detallesActuales.Any(da => da.Id == d.Id)).ToList();
            var detallesAEliminar = detallesActuales.Where(da => !compra.oDetalleCompra.Any(d => d.Id == da.Id)).ToList();
            var detallesAAgregar = compra.oDetalleCompra.Where(d => d.Id == 0).ToList();

            foreach (var detalle in detallesAEliminar)
            {
                detalleCompraRepository.Eliminar(detalle.Id);
            }

            foreach (var detalle in detallesAActualizar)
            {
                detalleCompraRepository.Actualizar(detalle);
            }

            foreach (var detalle in detallesAAgregar)
            {
                detalle.CompraId = compra.Id;
                detalleCompraRepository.Insertar(detalle);
            }
        }

        // Método para eliminar una compra y sus detalles
        public void Eliminar(int id)
        {
            ValidarExistenciaCompra(id);  // Nueva validación
            var compra = compraRepository.ObtenerPorId(id);
            if (compra != null)
            {
                foreach (var detalle in compra.oDetalleCompra)
                {
                    detalleCompraRepository.Eliminar(detalle.Id);
                }
                compraRepository.Eliminar(id);
            }
        }

        // Método para obtener una compra por su Id
        public Compra ObtenerPorId(int id)
        {
            return compraRepository.ObtenerPorId(id);
        }

        // Método para obtener todas las compras
        public List<Compra> ObtenerTodos()
        {
            return compraRepository.ObtenerTodos();
        }

        // Método para obtener compras por el Id del proveedor
        public List<Compra> ObtenerComprasPorProveedorId(int proveedorId)
        {
            return compraRepository.ObtenerComprasPorProveedorId(proveedorId);
        }

        // Método para obtener los detalles de una compra específica
        public List<DetalleCompra> ObtenerDetallesPorCompraId(int compraId)
        {
            return detalleCompraRepository.ObtenerPorCompraId(compraId);
        }

        public void CambiarEstadoCompra(int compraId, EstadoCompra nuevoEstado)
        {
            ValidarExistenciaCompra(compraId);
            compraRepository.CambiarEstadoCompra(compraId, nuevoEstado);
        }

        public void EliminarReferenciaCotizacion(int compraId)
        {
            compraRepository.EliminarReferenciaCotizacion(compraId);
        }

        public void CambiarEstadoCompraYActualizarStock(int compraId, EstadoCompra nuevoEstado)
        {
            ValidarExistenciaCompra(compraId);
            var compra = compraRepository.ObtenerPorId(compraId);

            if (compra != null && compra.EstadoCompraEnum == EstadoCompra.Pendiente)
            {
                compra.EstadoCompraEnum = nuevoEstado;
                compraRepository.CambiarEstadoCompra(compraId, nuevoEstado);

                if (nuevoEstado == EstadoCompra.Pagada)
                {
                    foreach (var detalle in compra.oDetalleCompra)
                    {
                        productoRepository.ActualizarStock(detalle.oProducto.Id, detalle.Cantidad);
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("La compra no es válida o ya está pagada.");
            }
        }

        // Método de validación para verificar la integridad de la compra antes de insertar o actualizar
        private void ValidarCompra(Compra compra)
        {
            if (compra == null)
                throw new ArgumentNullException("La compra no puede ser nula.");

            if (compra.oProveedor == null || compra.oProveedor.Id <= 0)
                throw new ArgumentException("Proveedor inválido.");

            if (compra.oDetalleCompra == null || !compra.oDetalleCompra.Any())
                throw new ArgumentException("La compra debe tener al menos un detalle.");

            foreach (var detalle in compra.oDetalleCompra)
            {
                if (detalle.Cantidad <= 0)
                    throw new ArgumentException("La cantidad en el detalle debe ser mayor a cero.");
                if (detalle.oProducto == null || detalle.oProducto.Id <= 0)
                    throw new ArgumentException("Producto inválido en el detalle.");
            }
        }

        // Método de validación para verificar la existencia de una compra antes de actualizar o eliminar
        private void ValidarExistenciaCompra(int compraId)
        {
            var compra = compraRepository.ObtenerPorId(compraId);
            if (compra == null)
                throw new ArgumentException($"La compra con Id {compraId} no existe.");
        }
    }
}