-- =============================================
-- SCRIPT COMPLETO: SISTEMA DE VENTAS CHEESELOGIX
-- Incluye: Tablas, Enums, Stored Procedures, Vistas
-- =============================================

USE [CheeseLogix]
GO

-- ============================================= 
-- 1. TABLA CLIENTE (si no existe)
-- =============================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Cliente' AND xtype='U')
BEGIN
    CREATE TABLE [dbo].[Cliente](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [CUIT] [nvarchar](20) NOT NULL,
        [Nombre] [nvarchar](100) NOT NULL,
        [Apellido] [nvarchar](100) NOT NULL,
        [Direccion] [nvarchar](255) NULL,
        [Mail] [nvarchar](100) NULL,
        [Telefono] [nvarchar](20) NULL,
        [Estado] [bit] NOT NULL DEFAULT(1),
        [FechaRegistro] [datetime] NOT NULL DEFAULT(getdate()),
        CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([Id] ASC),
        CONSTRAINT [UK_Cliente_CUIT] UNIQUE NONCLUSTERED ([CUIT] ASC)
    )
    PRINT 'Tabla Cliente creada exitosamente.'
END
ELSE
    PRINT 'Tabla Cliente ya existe.'
GO

-- =============================================
-- 2. ENUM ESTADO VENTA (Check Constraint)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE name = 'CK_Venta_EstadoVentaEnum')
BEGIN
    -- Se agregará después de crear la tabla Venta
    PRINT 'Check constraint para EstadoVentaEnum se agregará con la tabla Venta.'
END
GO

-- =============================================
-- 3. TABLA VENTA
-- =============================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Venta' AND xtype='U')
BEGIN
    CREATE TABLE [dbo].[Venta](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [Comentario] [nvarchar](500) NULL,
        [MontoTotal] [decimal](18, 2) NOT NULL,
        [Fecha] [datetime] NOT NULL DEFAULT(getdate()),
        [TipoPagoEnum] [int] NOT NULL DEFAULT(0),
        [EstadoVentaEnum] [int] NOT NULL DEFAULT(0),
        [ClienteId] [int] NULL,
        [UsuarioVendedorId] [int] NULL,
        CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED ([Id] ASC),
        CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY([ClienteId]) 
            REFERENCES [dbo].[Cliente] ([Id]),
        CONSTRAINT [FK_Venta_Usuario] FOREIGN KEY([UsuarioVendedorId]) 
            REFERENCES [dbo].[Usuario] ([Id]),
        CONSTRAINT [CK_Venta_TipoPagoEnum] CHECK ([TipoPagoEnum] IN (0,1,2)),
        CONSTRAINT [CK_Venta_EstadoVentaEnum] CHECK ([EstadoVentaEnum] IN (0,1,2,3)),
        CONSTRAINT [CK_Venta_MontoTotal] CHECK ([MontoTotal] >= 0)
    )
    PRINT 'Tabla Venta creada exitosamente.'
END
ELSE
    PRINT 'Tabla Venta ya existe.'
GO

-- =============================================
-- 4. TABLA DETALLE VENTA
-- =============================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='DetalleVenta' AND xtype='U')
BEGIN
    CREATE TABLE [dbo].[DetalleVenta](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [VentaId] [int] NOT NULL,
        [ProductoId] [int] NOT NULL,
        [Precio] [decimal](18, 2) NOT NULL,
        [Cantidad] [decimal](18, 2) NOT NULL,
        [SubTotal] [decimal](18, 2) NOT NULL,
        [Fecha] [datetime] NOT NULL DEFAULT(getdate()),
        CONSTRAINT [PK_DetalleVenta] PRIMARY KEY CLUSTERED ([Id] ASC),
        CONSTRAINT [FK_DetalleVenta_Venta] FOREIGN KEY([VentaId]) 
            REFERENCES [dbo].[Venta] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_DetalleVenta_Producto] FOREIGN KEY([ProductoId]) 
            REFERENCES [dbo].[Producto] ([Id]),
        CONSTRAINT [CK_DetalleVenta_Precio] CHECK ([Precio] >= 0),
        CONSTRAINT [CK_DetalleVenta_Cantidad] CHECK ([Cantidad] > 0),
        CONSTRAINT [CK_DetalleVenta_SubTotal] CHECK ([SubTotal] >= 0)
    )
    PRINT 'Tabla DetalleVenta creada exitosamente.'
END
ELSE
    PRINT 'Tabla DetalleVenta ya existe.'
GO

-- =============================================
-- 5. AGREGAR COLUMNA STOCKRESERVADO SI NO EXISTE
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Producto') AND name = 'StockReservado')
BEGIN
    ALTER TABLE [dbo].[Producto] 
    ADD [StockReservado] [decimal](18, 2) NOT NULL DEFAULT(0)
    
    -- Agregar constraints para StockReservado
    ALTER TABLE [dbo].[Producto] 
    ADD CONSTRAINT [CK_Producto_StockReservado_NonNegative] CHECK ([StockReservado] >= 0)
    
    ALTER TABLE [dbo].[Producto] 
    ADD CONSTRAINT [CK_Producto_StockReservado_LessOrEqualStock] CHECK ([StockReservado] <= [Stock])
    
    PRINT 'Columna StockReservado agregada a tabla Producto.'
END
ELSE
    PRINT 'Columna StockReservado ya existe en tabla Producto.'
GO

-- =============================================
-- 6. STORED PROCEDURE: ObtenerClientePorCUIT
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ObtenerClientePorCUIT]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[ObtenerClientePorCUIT]
GO

CREATE PROCEDURE [dbo].[ObtenerClientePorCUIT]
    @CUIT NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Buscar cliente por CUIT (limpiando espacios y guiones)
    SELECT 
        Id,
        CUIT,
        Nombre,
        Apellido,
        Direccion,
        Mail,
        Telefono,
        Estado,
        FechaRegistro
    FROM [dbo].[Cliente]
    WHERE REPLACE(REPLACE(CUIT, '-', ''), ' ', '') = REPLACE(REPLACE(@CUIT, '-', ''), ' ', '')
      AND Estado = 1 -- Solo clientes activos
END
GO

-- =============================================
-- 7. STORED PROCEDURES DE STOCK (si no existen)
-- =============================================

-- Reservar Stock
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReservarStock]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[ReservarStock]
GO

CREATE PROCEDURE [dbo].[ReservarStock]
    @ProductoId INT,
    @Cantidad DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @StockDisponible DECIMAL(18,2)
    
    -- Verificar stock disponible
    SELECT @StockDisponible = (Stock - StockReservado) 
    FROM Producto 
    WHERE Id = @ProductoId
    
    IF @StockDisponible >= @Cantidad
    BEGIN
        UPDATE Producto 
        SET StockReservado = StockReservado + @Cantidad
        WHERE Id = @ProductoId
        
        SELECT 1 as Success, 'Stock reservado exitosamente' as Message
    END
    ELSE
    BEGIN
        SELECT 0 as Success, 'Stock insuficiente' as Message
    END
END
GO

-- Liberar Stock
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LiberarStock]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[LiberarStock]
GO

CREATE PROCEDURE [dbo].[LiberarStock]
    @ProductoId INT,
    @Cantidad DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Producto 
    SET StockReservado = CASE 
        WHEN (StockReservado - @Cantidad) < 0 THEN 0 
        ELSE (StockReservado - @Cantidad) 
    END
    WHERE Id = @ProductoId
END
GO

-- Confirmar Venta Stock
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConfirmarVentaStock]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[ConfirmarVentaStock]
GO

CREATE PROCEDURE [dbo].[ConfirmarVentaStock]
    @ProductoId INT,
    @Cantidad DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Producto 
    SET Stock = Stock - @Cantidad,
        StockReservado = CASE 
            WHEN (StockReservado - @Cantidad) < 0 THEN 0 
            ELSE (StockReservado - @Cantidad) 
        END
    WHERE Id = @ProductoId
    AND Stock >= @Cantidad
END
GO

-- Obtener Stock Disponible
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ObtenerStockDisponible]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[ObtenerStockDisponible]
GO

CREATE PROCEDURE [dbo].[ObtenerStockDisponible]
    @ProductoId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    IF @ProductoId IS NULL
    BEGIN
        -- Obtener todos los productos
        SELECT 
            Id,
            Stock,
            StockReservado,
            (Stock - StockReservado) as StockDisponible
        FROM Producto
        WHERE Estado = 1
    END
    ELSE
    BEGIN
        -- Obtener producto específico
        SELECT 
            Id,
            Stock,
            StockReservado,
            (Stock - StockReservado) as StockDisponible
        FROM Producto
        WHERE Id = @ProductoId AND Estado = 1
    END
END
GO

-- =============================================
-- 8. VISTA: ProductoConStock
-- =============================================
IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_ProductoConStock]'))
    DROP VIEW [dbo].[V_ProductoConStock]
GO

CREATE VIEW [dbo].[V_ProductoConStock]
AS
SELECT 
    p.Id,
    p.Codigo,
    p.Nombre,
    p.CategoriaEnum,
    p.Stock,
    p.StockReservado,
    (p.Stock - p.StockReservado) as StockDisponible,
    p.PrecioVenta,
    p.Estado,
    CASE 
        WHEN (p.Stock - p.StockReservado) <= 0 THEN 'Sin Stock'
        WHEN (p.Stock - p.StockReservado) <= 10 THEN 'Stock Bajo'
        ELSE 'Stock Normal'
    END as EstadoStock
FROM [dbo].[Producto] p
WHERE p.Estado = 1
GO

-- =============================================
-- 9. DATOS DE PRUEBA (OPCIONAL)
-- =============================================

-- Insertar cliente de prueba si no existe
IF NOT EXISTS (SELECT 1 FROM Cliente WHERE CUIT = '20123456789')
BEGIN
    INSERT INTO Cliente (CUIT, Nombre, Apellido, Direccion, Mail, Telefono, Estado)
    VALUES ('20-12345678-9', 'Juan', 'Pérez', 'Av. Corrientes 1234', 'juan.perez@email.com', '1123456789', 1)
    PRINT 'Cliente de prueba insertado.'
END
GO

-- =============================================
-- RESUMEN FINAL
-- =============================================
PRINT '============================================='
PRINT 'SCRIPT COMPLETADO EXITOSAMENTE'
PRINT '============================================='
PRINT 'Tablas creadas:'
PRINT '- Cliente'
PRINT '- Venta' 
PRINT '- DetalleVenta'
PRINT 'Columna agregada:'
PRINT '- Producto.StockReservado'
PRINT 'Stored Procedures creados:'
PRINT '- ObtenerClientePorCUIT'
PRINT '- ReservarStock, LiberarStock, ConfirmarVentaStock'
PRINT '- ObtenerStockDisponible'
PRINT 'Vistas creadas:'
PRINT '- V_ProductoConStock'
PRINT '=============================================' 