-- ==========================================
-- EXTENSIÓN: StockMinimo por Producto
-- Seguro para múltiples ejecuciones
-- ==========================================

-- 1) Columna y constraints
IF NOT EXISTS (
    SELECT 1 FROM sys.columns 
    WHERE object_id = OBJECT_ID(N'[dbo].[Producto]') AND name = 'StockMinimo'
)
BEGIN
    ALTER TABLE [dbo].[Producto]
      ADD [StockMinimo] decimal(18,2) NOT NULL CONSTRAINT [DF_Producto_StockMinimo] DEFAULT(0);
END
GO

IF NOT EXISTS (
    SELECT 1 FROM sys.check_constraints 
    WHERE name = 'CK_Producto_StockMinimo_NoNegativo'
)
BEGIN
    ALTER TABLE [dbo].[Producto]
      ADD CONSTRAINT [CK_Producto_StockMinimo_NoNegativo] CHECK ([StockMinimo] >= 0);
END
GO

-- 2) Actualizar SP: InsertarProducto (agregar parámetro opcional y escritura de StockMinimo)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertarProducto')
BEGIN
    DROP PROCEDURE [dbo].[InsertarProducto];
END
GO

CREATE PROCEDURE [dbo].[InsertarProducto]
    @Codigo NVARCHAR(50),
    @CategoriaEnum INT,
    @Stock DECIMAL(18, 2) = NULL,
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(255),
    @PrecioCompra DECIMAL(18, 2),
    @PrecioVenta DECIMAL(18, 2) = NULL,
    @Estado BIT,
    @Fecha DATETIME = NULL,
    @StockMinimo DECIMAL(18,2) = 0
AS
BEGIN
    IF @Fecha IS NULL SET @Fecha = GETDATE();

    INSERT INTO Producto (Codigo, CategoriaEnum, Stock, Nombre, Descripcion, PrecioCompra, PrecioVenta, Estado, Fecha, StockMinimo)
    OUTPUT INSERTED.Id
    VALUES (@Codigo, @CategoriaEnum, @Stock, @Nombre, @Descripcion, @PrecioCompra, @PrecioVenta, @Estado, @Fecha, @StockMinimo);
END
GO

-- 3) Actualizar SP: ActualizarProducto (agregar parámetro StockMinimo y actualizar campo)
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ActualizarProducto')
BEGIN
    DROP PROCEDURE [dbo].[ActualizarProducto];
END
GO

CREATE PROCEDURE [dbo].[ActualizarProducto]
    @Id INT,
    @Codigo VARCHAR(50),
    @CategoriaEnum INT,
    @Stock DECIMAL(18, 2),
    @Nombre NVARCHAR(255),
    @Descripcion NVARCHAR(255),
    @PrecioCompra DECIMAL(18, 2),
    @PrecioVenta DECIMAL(18, 2),
    @Estado BIT,
    @Fecha DATETIME = NULL,
    @StockMinimo DECIMAL(18,2)
AS
BEGIN
    IF @Fecha IS NULL SET @Fecha = GETDATE();

    UPDATE Producto
    SET Codigo = @Codigo,
        CategoriaEnum = @CategoriaEnum,
        Stock = @Stock,
        Nombre = @Nombre,
        Descripcion = @Descripcion,
        PrecioCompra = @PrecioCompra,
        PrecioVenta = @PrecioVenta,
        Estado = @Estado,
        Fecha = @Fecha,
        StockMinimo = @StockMinimo
    WHERE Id = @Id;
END
GO

-- 4) Compatibilidad: SPs que leen stock no requieren cambios.
--    Vistas/consultas que usan Producto.* obtendrán StockMinimo automáticamente.


