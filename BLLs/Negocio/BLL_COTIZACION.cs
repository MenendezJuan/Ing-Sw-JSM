using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Compras;
using BEs.Clases.Negocio.Enums;
using MPPs.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLLs.Negocio
{
    public class BLL_COTIZACION
    {
        private readonly MPP_COTIZACION cotizacionRepository;
        private readonly MPP_DETALLECOMPRA detalleCompraRepository;

        public BLL_COTIZACION()
        {
            cotizacionRepository = new MPP_COTIZACION();
            detalleCompraRepository = new MPP_DETALLECOMPRA();
        }

        // Método para insertar una nueva cotización
        public void Insertar(Cotizacion cotizacion)
        {
            ValidarCotizacion(cotizacion);
            cotizacion.EstadoCotizacionEnum = EstadoCotizacion.Pendiente;
            cotizacionRepository.Insertar(cotizacion);
        }

        public void EvaluarYActualizarEstadoCotizacion(int cotizacionId, EstadoCotizacion nuevoEstado)
        {
            var cotizacion = cotizacionRepository.ObtenerPorId(cotizacionId);
            if (cotizacion == null)
                throw new ArgumentException($"La cotización con Id {cotizacionId} no existe.");

            if (cotizacion.EstadoCotizacionEnum == EstadoCotizacion.Aprobada || cotizacion.EstadoCotizacionEnum == EstadoCotizacion.Rechazada)
                throw new InvalidOperationException("No se puede cambiar el estado de una cotización que ya fue aprobada o rechazada.");

            cotizacionRepository.CambiarEstadoCotizacion(cotizacionId, nuevoEstado);
        }

        // Método para actualizar una cotización existente
        public void Actualizar(Cotizacion cotizacion)
        {
            ValidarExistenciaCotizacion(cotizacion.Id);
            ValidarCotizacion(cotizacion);
            cotizacionRepository.Actualizar(cotizacion);

            // Actualización de los detalles de la cotización
            var detallesActuales = detalleCompraRepository.ObtenerPorCotizacionId(cotizacion.Id);
            var detallesAActualizar = cotizacion.DetallesCompra.Where(d => detallesActuales.Any(da => da.Id == d.Id)).ToList();
            var detallesAEliminar = detallesActuales.Where(da => !cotizacion.DetallesCompra.Any(d => d.Id == da.Id)).ToList();
            var detallesAAgregar = cotizacion.DetallesCompra.Where(d => d.Id == 0).ToList();

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
                detalle.CotizacionId = cotizacion.Id;
                detalleCompraRepository.Insertar(detalle);
            }
        }



        // Método para eliminar una cotización y sus detalles
        public void Eliminar(int id)
        {
            ValidarExistenciaCotizacion(id);
            var cotizacion = cotizacionRepository.ObtenerPorId(id);
            if (cotizacion != null)
            {
                foreach (var detalle in cotizacion.DetallesCompra)
                {
                    detalleCompraRepository.Eliminar(detalle.Id);
                }
                cotizacionRepository.Eliminar(id);
            }
        }

        // Método para obtener una cotización por su Id
        public Cotizacion ObtenerPorId(int id)
        {
            return cotizacionRepository.ObtenerPorId(id);
        }

        // Método para obtener todas las cotizaciones
        public List<Cotizacion> ObtenerTodos()
        {
            return cotizacionRepository.ObtenerTodos();
        }

        // Método para obtener los detalles de una cotización específica por CotizacionId
        public List<DetalleCompra> ObtenerDetallesPorCotizacionId(int cotizacionId)
        {
            return detalleCompraRepository.ObtenerPorCotizacionId(cotizacionId);
        }

        // Método de validación para verificar la integridad de la cotización antes de insertar o actualizar
        private void ValidarCotizacion(Cotizacion cotizacion)
        {
            if (cotizacion == null)
                throw new ArgumentNullException("La cotización no puede ser nula.");

            if (cotizacion.ProveedorId <= 0)
                throw new ArgumentException("Proveedor inválido.");

            if (cotizacion.DetallesCompra == null || !cotizacion.DetallesCompra.Any())
                throw new ArgumentException("La cotización debe tener al menos un detalle.");

            foreach (var detalle in cotizacion.DetallesCompra)
            {
                if (detalle.Cantidad <= 0)
                    throw new ArgumentException("La cantidad en el detalle debe ser mayor a cero.");
                if (detalle.oProducto == null || detalle.oProducto.Id <= 0)
                    throw new ArgumentException("Producto inválido en el detalle.");
            }
        }

        // Método de validación para verificar la existencia de una cotización antes de actualizar o eliminar
        private void ValidarExistenciaCotizacion(int cotizacionId)
        {
            var cotizacion = cotizacionRepository.ObtenerPorId(cotizacionId);
            if (cotizacion == null)
                throw new ArgumentException($"La cotización con Id {cotizacionId} no existe.");
        }
    }
}
