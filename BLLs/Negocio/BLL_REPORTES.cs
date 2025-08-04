using System;
using System.Collections.Generic;
using System.Data;
using MPPs;
using MPPs.Negocio;

namespace BLLs.Negocio
{
    public class BLL_REPORTES
    {
        private readonly MPP_VENTA _mppVenta;
        private readonly MPP_PRODUCTO _mppProducto;
        private readonly MPP_CLIENTE _mppCliente;
        private readonly MPP_PROVEEDOR _mppProveedor;

        public BLL_REPORTES()
        {
            _mppVenta = new MPP_VENTA();
            _mppProducto = new MPP_PRODUCTO();
            _mppCliente = new MPP_CLIENTE();
            _mppProveedor = new MPP_PROVEEDOR();
        }

        #region Reportes de Ventas

        /// <summary>
        /// Obtiene los productos más vendidos en un período
        /// </summary>
        public DataTable ObtenerProductosMasVendidos(DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            try
            {
                return _mppVenta.ObtenerProductosMasVendidos(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener productos más vendidos: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene las ventas por mes del año actual
        /// </summary>
        public DataTable ObtenerVentasPorMes(int? año = null)
        {
            try
            {
                int añoActual = año ?? DateTime.Now.Year;
                return _mppVenta.ObtenerVentasPorMes(añoActual);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener ventas por mes: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene los clientes que más compran
        /// </summary>
        public DataTable ObtenerClientesMejores(DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            try
            {
                return _mppVenta.ObtenerClientesMejores(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener mejores clientes: {ex.Message}", ex);
            }
        }

        #endregion

        #region Reportes de Compras

        /// <summary>
        /// Obtiene los proveedores con más órdenes
        /// </summary>
        public DataTable ObtenerProveedoresMasActivos(DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            try
            {
                return _mppProveedor.ObtenerProveedoresMasActivos(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener proveedores más activos: {ex.Message}", ex);
            }
        }

        #endregion

        #region Reportes Combinados

        /// <summary>
        /// Obtiene un resumen ejecutivo de ventas
        /// </summary>
        public DataTable ObtenerResumenEjecutivo(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return _mppVenta.ObtenerResumenEjecutivo(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener resumen ejecutivo: {ex.Message}", ex);
            }
        }

        #endregion

        #region Métodos de Análisis

        /// <summary>
        /// Genera recomendaciones basadas en los datos de ventas
        /// </summary>
        public List<string> GenerarRecomendaciones()
        {
            var recomendaciones = new List<string>();

            try
            {
                // Obtener productos más vendidos del último mes
                var fechaInicio = DateTime.Now.AddMonths(-1);
                var productosMasVendidos = ObtenerProductosMasVendidos(fechaInicio, DateTime.Now);

                if (productosMasVendidos.Rows.Count > 0)
                {
                    var productoTop = productosMasVendidos.Rows[0]["NombreProducto"].ToString();
                    recomendaciones.Add($"Aumentar stock de {productoTop} - es el producto más vendido");
                }

                // Obtener clientes mejores
                var mejoresClientes = ObtenerClientesMejores(fechaInicio, DateTime.Now);
                if (mejoresClientes.Rows.Count > 0)
                {
                    var clienteTop = mejoresClientes.Rows[0]["NombreCliente"].ToString();
                    recomendaciones.Add($"Crear promociones especiales para {clienteTop}");
                }

                // Análisis de tendencias mensuales
                var ventasMes = ObtenerVentasPorMes();
                if (ventasMes.Rows.Count >= 2)
                {
                    var ventasMesActual = Convert.ToDecimal(ventasMes.Rows[ventasMes.Rows.Count - 1]["TotalVentas"]);
                    var ventasMesAnterior = Convert.ToDecimal(ventasMes.Rows[ventasMes.Rows.Count - 2]["TotalVentas"]);

                    if (ventasMesActual > ventasMesAnterior)
                    {
                        recomendaciones.Add("Las ventas están en crecimiento - considerar expandir inventario");
                    }
                    else
                    {
                        recomendaciones.Add("Las ventas han disminuido - revisar estrategias de marketing");
                    }
                }

                if (recomendaciones.Count == 0)
                {
                    recomendaciones.Add("No hay suficientes datos para generar recomendaciones");
                }

                return recomendaciones;
            }
            catch (Exception ex)
            {
                recomendaciones.Add($"Error al generar recomendaciones: {ex.Message}");
                return recomendaciones;
            }
        }

        #endregion
    }
}