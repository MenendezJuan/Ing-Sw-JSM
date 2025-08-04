-- =============================================
-- STORED PROCEDURES PARA MÓDULO DE REPORTES
-- Sistema CheeseLogix
-- =============================================

USE [IngenieriaSoftware]
GO

-- =============================================
-- 1. PRODUCTOS MÁS VENDIDOS
-- Obtiene los productos más vendidos en un período
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ObtenerProductosMasVendidos]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[SP_ObtenerProductosMasVendidos]
GO

CREATE PROCEDURE [dbo].[SP_ObtenerProductosMasVendidos]
    @FechaInicio DATETIME = NULL,
    @FechaFin DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Si no se proporcionan fechas, usar los últimos 6 meses
    IF @FechaInicio IS NULL
        SET @FechaInicio = DATEADD(MONTH, -6, GETDATE())
    
    IF @FechaFin IS NULL
        SET @FechaFin = GETDATE()
    
    SELECT TOP 10
        p.Id as ProductoId,
        p.Codigo as CodigoProducto,
        p.Nombre as NombreProducto,
        p.Descripcion,
        SUM(dv.Cantidad) as TotalVendido,
        SUM(dv.SubTotal) as TotalFacturado,
        COUNT(DISTINCT v.Id) as NumeroVentas,
        AVG(dv.Precio) as PrecioPromedio
    FROM Producto p
    INNER JOIN DetalleVenta dv ON p.Id = dv.ProductoId
    INNER JOIN Venta v ON dv.VentaId = v.Id
    WHERE v.Fecha BETWEEN @FechaInicio AND @FechaFin
        AND v.EstadoVentaEnum IN (2, 3) -- Solo ventas Completadas o Entregadas
        AND p.Estado = 1
    GROUP BY p.Id, p.Codigo, p.Nombre, p.Descripcion
    ORDER BY TotalVendido DESC, TotalFacturado DESC
END
GO

-- =============================================
-- 2. CLIENTES QUE MÁS COMPRAN
-- Obtiene los mejores clientes por monto y frecuencia
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ObtenerClientesMejores]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[SP_ObtenerClientesMejores]
GO

CREATE PROCEDURE [dbo].[SP_ObtenerClientesMejores]
    @FechaInicio DATETIME = NULL,
    @FechaFin DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Si no se proporcionan fechas, usar los últimos 6 meses
    IF @FechaInicio IS NULL
        SET @FechaInicio = DATEADD(MONTH, -6, GETDATE())
    
    IF @FechaFin IS NULL
        SET @FechaFin = GETDATE()
    
    SELECT TOP 10
        c.Id as ClienteId,
        c.CUIT,
        c.Nombre + ' ' + c.Apellido as NombreCompleto,
        c.Mail,
        c.Telefono,
        COUNT(v.Id) as NumeroCompras,
        SUM(v.MontoTotal) as TotalComprado,
        AVG(v.MontoTotal) as PromedioCompra,
        MAX(v.Fecha) as UltimaCompra,
        SUM(CASE WHEN v.Fecha >= DATEADD(MONTH, -1, GETDATE()) THEN 1 ELSE 0 END) as ComprasUltimoMes
    FROM Cliente c
    INNER JOIN Venta v ON c.Id = v.ClienteId
    WHERE v.Fecha BETWEEN @FechaInicio AND @FechaFin
        AND v.EstadoVentaEnum IN (2, 3) -- Solo ventas Completadas o Entregadas
        AND c.Estado = 1
    GROUP BY c.Id, c.CUIT, c.Nombre, c.Apellido, c.Mail, c.Telefono
    ORDER BY TotalComprado DESC, NumeroCompras DESC
END
GO

-- =============================================
-- 3. VENTAS POR MES
-- Obtiene resumen de ventas agrupadas por mes para un año
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ObtenerVentasPorMes]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[SP_ObtenerVentasPorMes]
GO

CREATE PROCEDURE [dbo].[SP_ObtenerVentasPorMes]
    @Año INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Si no se proporciona año, usar el año actual
    IF @Año IS NULL
        SET @Año = YEAR(GETDATE())
    
    SELECT 
        MONTH(v.Fecha) as Mes,
        DATENAME(MONTH, v.Fecha) as NombreMes,
        COUNT(v.Id) as NumeroVentas,
        SUM(v.MontoTotal) as TotalVentas,
        AVG(v.MontoTotal) as PromedioVenta,
        SUM(CASE WHEN v.TipoPagoEnum = 1 THEN v.MontoTotal ELSE 0 END) as VentasEfectivo,
        SUM(CASE WHEN v.TipoPagoEnum = 2 THEN v.MontoTotal ELSE 0 END) as VentasTarjeta,
        SUM(CASE WHEN v.TipoPagoEnum = 3 THEN v.MontoTotal ELSE 0 END) as VentasTransferencia,
        COUNT(DISTINCT v.ClienteId) as ClientesDistintos
    FROM Venta v
    WHERE YEAR(v.Fecha) = @Año
        AND v.EstadoVentaEnum IN (2, 3) -- Solo ventas Completadas o Entregadas
    GROUP BY MONTH(v.Fecha), DATENAME(MONTH, v.Fecha)
    ORDER BY Mes
END
GO

-- =============================================
-- 4. PROVEEDORES MÁS ACTIVOS
-- Obtiene proveedores con más órdenes de compra
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ObtenerProveedoresMasActivos]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[SP_ObtenerProveedoresMasActivos]
GO

CREATE PROCEDURE [dbo].[SP_ObtenerProveedoresMasActivos]
    @FechaInicio DATETIME = NULL,
    @FechaFin DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Si no se proporcionan fechas, usar los últimos 6 meses
    IF @FechaInicio IS NULL
        SET @FechaInicio = DATEADD(MONTH, -6, GETDATE())
    
    IF @FechaFin IS NULL
        SET @FechaFin = GETDATE()
    
    SELECT TOP 10
        p.Id as ProveedorId,
        p.CUIT,
        p.Descripcion as NombreProveedor,
        p.Mail,
        p.Telefono,
        COUNT(c.Id) as NumeroCompras,
        SUM(c.MontoTotal) as TotalComprado,
        AVG(c.MontoTotal) as PromedioCompra,
        MAX(c.Fecha) as UltimaCompra,
        SUM(CASE WHEN c.Fecha >= DATEADD(MONTH, -1, GETDATE()) THEN 1 ELSE 0 END) as ComprasUltimoMes,
        COUNT(DISTINCT cot.Id) as NumeroCotizaciones
    FROM Proveedor p
    INNER JOIN Compra c ON p.Id = c.ProveedorId
    LEFT JOIN Cotizacion cot ON p.Id = cot.ProveedorId 
        AND cot.FechaCotizacion BETWEEN @FechaInicio AND @FechaFin
    WHERE c.Fecha BETWEEN @FechaInicio AND @FechaFin
        AND c.EstadoCompra IN (2, 3) -- Solo compras Completadas o Recibidas
        AND p.Estado = 1
    GROUP BY p.Id, p.CUIT, p.Descripcion, p.Mail, p.Telefono
    ORDER BY TotalComprado DESC, NumeroCompras DESC
END
GO

-- =============================================
-- 5. RESUMEN EJECUTIVO
-- Obtiene métricas generales del negocio en un período
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ObtenerResumenEjecutivo]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[SP_ObtenerResumenEjecutivo]
GO

CREATE PROCEDURE [dbo].[SP_ObtenerResumenEjecutivo]
    @FechaInicio DATETIME,
    @FechaFin DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        -- Métricas de Ventas
        COUNT(DISTINCT v.Id) as TotalVentas,
        SUM(v.MontoTotal) as TotalFacturado,
        AVG(v.MontoTotal) as PromedioVenta,
        COUNT(DISTINCT v.ClienteId) as ClientesActivos,
        
        -- Métricas de Productos
        COUNT(DISTINCT dv.ProductoId) as ProductosVendidos,
        SUM(dv.Cantidad) as UnidadesVendidas,
        
        -- Métricas de Compras
        COUNT(DISTINCT c.Id) as TotalCompras,
        SUM(c.MontoTotal) as TotalComprado,
        COUNT(DISTINCT c.ProveedorId) as ProveedoresActivos,
        
        -- Métricas de Rentabilidad (estimada)
        SUM(v.MontoTotal) - SUM(c.MontoTotal) as GananciaEstimada,
        
        -- Crecimiento vs período anterior
        (SELECT COUNT(*) FROM Venta WHERE Fecha BETWEEN DATEADD(DAY, -DATEDIFF(DAY, @FechaInicio, @FechaFin), @FechaInicio) AND @FechaInicio) as VentasPeriodoAnterior,
        
        -- Stock bajo (productos con stock <= 10)
        (SELECT COUNT(*) FROM Producto WHERE Stock <= 10 AND Estado = 1) as ProductosStockBajo
        
    FROM Venta v
    LEFT JOIN DetalleVenta dv ON v.Id = dv.VentaId
    LEFT JOIN Compra c ON c.Fecha BETWEEN @FechaInicio AND @FechaFin
    WHERE v.Fecha BETWEEN @FechaInicio AND @FechaFin
        AND v.EstadoVentaEnum IN (2, 3) -- Solo ventas Completadas o Entregadas
END
GO

-- =============================================
-- PERMISOS Y FINALIZACIÓN
-- =============================================
PRINT '============================================='
PRINT 'STORED PROCEDURES DE REPORTES CREADOS:'
PRINT '- SP_ObtenerProductosMasVendidos'
PRINT '- SP_ObtenerClientesMejores'
PRINT '- SP_ObtenerVentasPorMes'
PRINT '- SP_ObtenerProveedoresMasActivos'
PRINT '- SP_ObtenerResumenEjecutivo'
PRINT '============================================='
PRINT 'Nota: Asegúrate de que las tablas Cliente, Venta,'
PRINT 'DetalleVenta, Producto, Proveedor y Compra existan'
PRINT 'con la estructura esperada.'
PRINT '============================================='