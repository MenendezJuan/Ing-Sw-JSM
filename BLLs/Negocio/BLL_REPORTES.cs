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

        #region Reportes Optimizados

        /// <summary>
        /// Obtiene los productos más vendidos optimizado para reporte
        /// </summary>
        public DataTable ObtenerProductosTopReporte(DateTime? fechaInicio = null, DateTime? fechaFin = null, int top = 10)
        {
            try
            {
                return _mppVenta.ObtenerProductosTopReporte(fechaInicio, fechaFin, top);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener productos top para reporte: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene los clientes top para gráfico
        /// </summary>
        public DataTable ObtenerClientesTopGrafico(DateTime? fechaInicio = null, DateTime? fechaFin = null, int top = 5)
        {
            try
            {
                return _mppVenta.ObtenerClientesTopGrafico(fechaInicio, fechaFin, top);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener clientes top para gráfico: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene resumen ejecutivo mejorado
        /// </summary>
        public DataTable ObtenerResumenEjecutivoMejorado(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return _mppVenta.ObtenerResumenEjecutivoMejorado(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener resumen ejecutivo mejorado: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene las ventas por mes del año actual - Método mantenido para compatibilidad
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
                // Obtener productos más vendidos del último mes usando método optimizado
                var fechaInicio = DateTime.Now.AddMonths(-1);
                var productosMasVendidos = ObtenerProductosTopReporte(fechaInicio, DateTime.Now, 5);

                if (productosMasVendidos.Rows.Count > 0)
                {
                    var productoTop = productosMasVendidos.Rows[0]["NombreProducto"].ToString();
                    recomendaciones.Add($"Aumentar stock de {productoTop} - es el producto más vendido");
                }

                // Obtener clientes mejores usando método optimizado
                var mejoresClientes = ObtenerClientesTopGrafico(fechaInicio, DateTime.Now, 5);
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