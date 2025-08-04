-- =============================================
-- STORED PROCEDURES ADICIONALES PARA CLIENTES
-- Sistema CheeseLogix - Extensión de Reportes
-- =============================================

USE [IngenieriaSoftware]
GO

-- =============================================
-- 1. CLIENTES TOP PARA GRÁFICO
-- Obtiene los mejores clientes simplificado para gráfico
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ObtenerClientesTopGrafico]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[SP_ObtenerClientesTopGrafico]
GO

CREATE PROCEDURE [dbo].[SP_ObtenerClientesTopGrafico]
    @FechaInicio DATETIME = NULL,
    @FechaFin DATETIME = NULL,
    @TopClientes INT = 5
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Si no se proporcionan fechas, usar los últimos 6 meses
    IF @FechaInicio IS NULL
        SET @FechaInicio = DATEADD(MONTH, -6, GETDATE())
    
    IF @FechaFin IS NULL
        SET @FechaFin = GETDATE()
    
    SELECT TOP (@TopClientes)
        c.Id as ClienteId,
        CASE 
            WHEN LEN(c.Nombre + ' ' + c.Apellido) > 20 
            THEN LEFT(c.Nombre + ' ' + c.Apellido, 17) + '...'
            ELSE c.Nombre + ' ' + c.Apellido
        END as NombreCliente,
        SUM(v.MontoTotal) as TotalCompras,
        COUNT(v.Id) as CantidadOrdenes
    FROM Cliente c
    INNER JOIN Venta v ON c.Id = v.ClienteId
    WHERE v.Fecha BETWEEN @FechaInicio AND @FechaFin
        AND v.EstadoVentaEnum IN (2, 3) -- Solo ventas Completadas o Entregadas
        AND c.Estado = 1
    GROUP BY c.Id, c.Nombre, c.Apellido
    ORDER BY TotalCompras DESC
END
GO

-- =============================================
-- 2. PRODUCTOS MÁS VENDIDOS SIMPLIFICADO
-- Versión optimizada para el reporte
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ObtenerProductosTopReporte]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[SP_ObtenerProductosTopReporte]
GO

CREATE PROCEDURE [dbo].[SP_ObtenerProductosTopReporte]
    @FechaInicio DATETIME = NULL,
    @FechaFin DATETIME = NULL,
    @TopProductos INT = 10
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Si no se proporcionan fechas, usar los últimos 6 meses
    IF @FechaInicio IS NULL
        SET @FechaInicio = DATEADD(MONTH, -6, GETDATE())
    
    IF @FechaFin IS NULL
        SET @FechaFin = GETDATE()
    
    SELECT TOP (@TopProductos)
        p.Id as ProductoId,
        CASE 
            WHEN LEN(p.Nombre) > 25 
            THEN LEFT(p.Nombre, 22) + '...'
            ELSE p.Nombre
        END as NombreProducto,
        SUM(dv.Cantidad) as CantidadVendida,
        SUM(dv.SubTotal) as TotalVentas
    FROM Producto p
    INNER JOIN DetalleVenta dv ON p.Id = dv.ProductoId
    INNER JOIN Venta v ON dv.VentaId = v.Id
    WHERE v.Fecha BETWEEN @FechaInicio AND @FechaFin
        AND v.EstadoVentaEnum IN (2, 3) -- Solo ventas Completadas o Entregadas
        AND p.Estado = 1
    GROUP BY p.Id, p.Nombre
    ORDER BY CantidadVendida DESC, TotalVentas DESC
END
GO

-- =============================================
-- 3. RESUMEN EJECUTIVO MEJORADO
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ObtenerResumenEjecutivoMejorado]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[SP_ObtenerResumenEjecutivoMejorado]
GO

CREATE PROCEDURE [dbo].[SP_ObtenerResumenEjecutivoMejorado]
    @FechaInicio DATETIME,
    @FechaFin DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        -- Período de análisis
        @FechaInicio as FechaInicio,
        @FechaFin as FechaFin,
        DATEDIFF(DAY, @FechaInicio, @FechaFin) as DiasAnalisis,
        
        -- Métricas de Ventas
        COUNT(DISTINCT v.Id) as TotalVentas,
        ISNULL(SUM(v.MontoTotal), 0) as TotalFacturado,
        ISNULL(AVG(v.MontoTotal), 0) as PromedioVenta,
        COUNT(DISTINCT v.ClienteId) as ClientesActivos,
        
        -- Métricas de Productos
        COUNT(DISTINCT dv.ProductoId) as ProductosVendidos,
        ISNULL(SUM(dv.Cantidad), 0) as UnidadesVendidas,
        
        -- Top performers
        (SELECT TOP 1 p.Nombre FROM Producto p 
         INNER JOIN DetalleVenta dv2 ON p.Id = dv2.ProductoId 
         INNER JOIN Venta v2 ON dv2.VentaId = v2.Id 
         WHERE v2.Fecha BETWEEN @FechaInicio AND @FechaFin 
         GROUP BY p.Id, p.Nombre 
         ORDER BY SUM(dv2.Cantidad) DESC) as ProductoMasVendido,
         
        (SELECT TOP 1 c.Nombre + ' ' + c.Apellido FROM Cliente c 
         INNER JOIN Venta v3 ON c.Id = v3.ClienteId 
         WHERE v3.Fecha BETWEEN @FechaInicio AND @FechaFin 
         GROUP BY c.Id, c.Nombre, c.Apellido 
         ORDER BY SUM(v3.MontoTotal) DESC) as MejorCliente,
         
        -- Stock crítico
        (SELECT COUNT(*) FROM Producto WHERE Stock <= 10 AND Estado = 1) as ProductosStockBajo
        
    FROM Venta v
    LEFT JOIN DetalleVenta dv ON v.Id = dv.VentaId
    WHERE v.Fecha BETWEEN @FechaInicio AND @FechaFin
        AND v.EstadoVentaEnum IN (2, 3) -- Solo ventas Completadas o Entregadas
END
GO

-- =============================================
-- PERMISOS Y FINALIZACIÓN
-- =============================================
PRINT '============================================='
PRINT 'STORED PROCEDURES ADICIONALES CREADOS:'
PRINT '- SP_ObtenerClientesTopGrafico'
PRINT '- SP_ObtenerProductosTopReporte'
PRINT '- SP_ObtenerResumenEjecutivoMejorado'
PRINT '============================================='
PRINT 'Estos SP están optimizados para el reporte'
PRINT 'y incluyen manejo de texto truncado para UI'
PRINT '============================================='