-- ==========================================
-- ACTUALIZACIÓN PARA SISTEMA DE RESERVAS DE STOCK
-- ==========================================

-- 1. Agregar columna StockReservado a la tabla Producto
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Producto]') AND name = 'StockReservado')
BEGIN
    ALTER TABLE [dbo].[Producto] ADD [StockReservado] [decimal](18, 2) NOT NULL DEFAULT(0);
END
GO

-- 2. Constraints para asegurar coherencia de datos
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE name = 'CK_Producto_StockReservado_NoNegativo')
BEGIN
    ALTER TABLE [dbo].[Producto] 
    ADD CONSTRAINT [CK_Producto_StockReservado_NoNegativo] 
    CHECK ([StockReservado] >= 0);
END
GO

IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE name = 'CK_Producto_StockReservado_NoMayorQueStock')
BEGIN
    ALTER TABLE [dbo].[Producto] 
    ADD CONSTRAINT [CK_Producto_StockReservado_NoMayorQueStock] 
    CHECK ([StockReservado] <= [Stock]);
END
GO

-- ==========================================
-- STORED PROCEDURES PARA GESTIÓN DE RESERVAS
-- ==========================================

-- Procedure para reservar stock
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ReservarStock')
    DROP PROCEDURE [dbo].[ReservarStock]
GO

CREATE PROCEDURE [dbo].[ReservarStock]
    @ProductoId INT,
    @Cantidad DECIMAL(18, 2)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Variables para verificación
    DECLARE @StockDisponible DECIMAL(18, 2);
    DECLARE @StockActual DECIMAL(18, 2);
    DECLARE @StockReservadoActual DECIMAL(18, 2);
    
    -- Obtener stock actual del producto
    SELECT 
        @StockActual = Stock,
        @StockReservadoActual = StockReservado,
        @StockDisponible = (Stock - StockReservado)
    FROM Producto 
    WHERE Id = @ProductoId AND Estado = 1;
    
    -- Verificar que el producto existe y está activo
    IF @StockActual IS NULL
    BEGIN
        SELECT 0 AS Exito, 'Producto no encontrado o inactivo' AS Mensaje;
        RETURN;
    END
    
    -- Verificar que hay stock suficiente disponible
    IF @StockDisponible >= @Cantidad
    BEGIN
        -- Reservar stock
        UPDATE Producto 
        SET StockReservado = StockReservado + @Cantidad 
        WHERE Id = @ProductoId;
        
        SELECT 1 AS Exito, 'Stock reservado exitosamente' AS Mensaje;
    END
    ELSE
    BEGIN
        SELECT 0 AS Exito, 
               CONCAT('Stock insuficiente. Disponible: ', @StockDisponible, ', Solicitado: ', @Cantidad) AS Mensaje;
    END
END
GO

-- Procedure para liberar stock reservado
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'LiberarStock')
    DROP PROCEDURE [dbo].[LiberarStock]
GO

CREATE PROCEDURE [dbo].[LiberarStock]
    @ProductoId INT,
    @Cantidad DECIMAL(18, 2)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Verificar que no se libere más de lo reservado
    DECLARE @StockReservadoActual DECIMAL(18, 2);
    
    SELECT @StockReservadoActual = StockReservado 
    FROM Producto 
    WHERE Id = @ProductoId;
    
    IF @StockReservadoActual IS NULL
    BEGIN
        SELECT 0 AS Exito, 'Producto no encontrado' AS Mensaje;
        RETURN;
    END
    
    IF @StockReservadoActual >= @Cantidad
    BEGIN
        UPDATE Producto 
        SET StockReservado = StockReservado - @Cantidad 
        WHERE Id = @ProductoId;
        
        SELECT 1 AS Exito, 'Stock liberado exitosamente' AS Mensaje;
    END
    ELSE
    BEGIN
        SELECT 0 AS Exito, 
               CONCAT('No se puede liberar más stock del reservado. Reservado: ', @StockReservadoActual, ', Solicitado: ', @Cantidad) AS Mensaje;
    END
END
GO

-- Procedure para confirmar venta (restar stock definitivamente)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ConfirmarVentaStock')
    DROP PROCEDURE [dbo].[ConfirmarVentaStock]
GO

CREATE PROCEDURE [dbo].[ConfirmarVentaStock]
    @ProductoId INT,
    @Cantidad DECIMAL(18, 2)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Variables para verificación
    DECLARE @StockActual DECIMAL(18, 2);
    DECLARE @StockReservadoActual DECIMAL(18, 2);
    
    SELECT 
        @StockActual = Stock,
        @StockReservadoActual = StockReservado
    FROM Producto 
    WHERE Id = @ProductoId;
    
    IF @StockActual IS NULL
    BEGIN
        SELECT 0 AS Exito, 'Producto no encontrado' AS Mensaje;
        RETURN;
    END
    
    -- Verificar que hay stock y reserva suficiente
    IF @StockActual >= @Cantidad AND @StockReservadoActual >= @Cantidad
    BEGIN
        -- Restar del stock total y liberar de la reserva
        UPDATE Producto 
        SET Stock = Stock - @Cantidad,
            StockReservado = StockReservado - @Cantidad 
        WHERE Id = @ProductoId;
        
        SELECT 1 AS Exito, 'Venta confirmada, stock actualizado' AS Mensaje;
    END
    ELSE
    BEGIN
        SELECT 0 AS Exito, 
               CONCAT('Stock o reserva insuficiente. Stock: ', @StockActual, ', Reservado: ', @StockReservadoActual, ', Solicitado: ', @Cantidad) AS Mensaje;
    END
END
GO

-- Procedure para obtener stock disponible
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ObtenerStockDisponible')
    DROP PROCEDURE [dbo].[ObtenerStockDisponible]
GO

CREATE PROCEDURE [dbo].[ObtenerStockDisponible]
    @ProductoId INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        Id,
        Stock,
        StockReservado,
        (Stock - StockReservado) AS StockDisponible
    FROM Producto 
    WHERE Id = @ProductoId;
END
GO

-- ==========================================
-- VIEW PARA CONSULTAS DE STOCK
-- ==========================================

-- Vista para mostrar productos con información de stock completa
IF EXISTS (SELECT * FROM sys.views WHERE name = 'V_ProductoConStock')
    DROP VIEW [dbo].[V_ProductoConStock]
GO

CREATE VIEW [dbo].[V_ProductoConStock] AS
SELECT 
    p.Id,
    p.Codigo,
    p.Nombre,
    p.Descripcion,
    p.Stock,
    p.StockReservado,
    (p.Stock - p.StockReservado) AS StockDisponible,
    p.CategoriaEnum,
    p.PrecioCompra,
    p.PrecioVenta,
    p.Estado,
    p.Fecha,
    CASE 
        WHEN (p.Stock - p.StockReservado) <= 0 THEN 'Sin Stock'
        WHEN (p.Stock - p.StockReservado) <= 10 THEN 'Stock Bajo'
        ELSE 'Stock OK'
    END AS EstadoStock
FROM Producto p
WHERE p.Estado = 1;
GO

-- ==========================================
-- PROCEDURE PARA LIBERACIÓN AUTOMÁTICA DE RESERVAS VENCIDAS
-- ==========================================

-- Procedure para liberar reservas de ventas en proceso que tienen más de X minutos
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'LiberarReservasVencidas')
    DROP PROCEDURE [dbo].[LiberarReservasVencidas]
GO

CREATE PROCEDURE [dbo].[LiberarReservasVencidas]
    @MinutosVencimiento INT = 30
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Tabla temporal para almacenar ventas vencidas
    DECLARE @VentasVencidas TABLE (
        VentaId INT,
        ProductoId INT,
        Cantidad DECIMAL(18, 2)
    );
    
    -- Identificar ventas en proceso que han vencido
    INSERT INTO @VentasVencidas (VentaId, ProductoId, Cantidad)
    SELECT 
        v.Id,
        dv.ProductoId,
        dv.Cantidad
    FROM Venta v
    INNER JOIN DetalleVenta dv ON v.Id = dv.VentaId
    WHERE v.EstadoVenta = 0 -- EnProceso
    AND v.Fecha < DATEADD(MINUTE, -@MinutosVencimiento, GETDATE());
    
    -- Liberar stock reservado
    UPDATE p 
    SET StockReservado = StockReservado - tv.Cantidad
    FROM Producto p
    INNER JOIN @VentasVencidas tv ON p.Id = tv.ProductoId;
    
    -- Cancelar las ventas vencidas
    UPDATE Venta 
    SET EstadoVenta = 3 -- Cancelada
    WHERE Id IN (SELECT DISTINCT VentaId FROM @VentasVencidas);
    
    -- Retornar información de las ventas canceladas
    SELECT 
        COUNT(DISTINCT VentaId) AS VentasCanceladas,
        COUNT(*) AS ProductosLiberados,
        SUM(Cantidad) AS CantidadTotalLiberada
    FROM @VentasVencidas;
END
GO

PRINT 'Scripts de reserva de stock ejecutados exitosamente.'; 