-- ==========================================
-- SISTEMA DE DÍGITO VERIFICADOR Y CONTROL DE CAMBIOS
-- CheeseLogix - Implementación Completa
-- ==========================================

-- ==========================================
-- 1. AGREGAR COLUMNAS DE DÍGITO VERIFICADOR
-- ==========================================

-- Agregar DV a tabla Producto
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Producto]') AND name = 'DigitoVerificador')
BEGIN
    ALTER TABLE [dbo].[Producto] ADD [DigitoVerificador] NVARCHAR(255) NULL;
    PRINT 'Columna DigitoVerificador agregada a tabla Producto';
END
GO

-- Agregar DV a tabla Venta
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Venta]') AND name = 'DigitoVerificador')
BEGIN
    ALTER TABLE [dbo].[Venta] ADD [DigitoVerificador] NVARCHAR(255) NULL;
    PRINT 'Columna DigitoVerificador agregada a tabla Venta';
END
GO

-- ==========================================
-- 2. CREAR TABLAS DE HISTORIAL
-- ==========================================

-- Tabla Historial_Productos
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Historial_Productos]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Historial_Productos](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [ProductoId] [int] NOT NULL,
        [Codigo] [varchar](50) NULL,
        [CategoriaEnum] [int] NULL,
        [Stock] [decimal](18, 2) NULL,
        [Nombre] [nvarchar](255) NOT NULL,
        [Descripcion] [nvarchar](255) NULL,
        [PrecioCompra] [decimal](18, 2) NOT NULL,
        [PrecioVenta] [decimal](18, 2) NULL,
        [Estado] [bit] NOT NULL,
        [Fecha] [datetime] NULL,
        [StockMinimo] [decimal](18, 2) NOT NULL DEFAULT(0),
        [DigitoVerificador] [nvarchar](255) NULL,
        [FechaModificacion] [datetime] NOT NULL DEFAULT(GETDATE()),
        [TipoOperacion] [nvarchar](10) NOT NULL, -- INSERT, UPDATE, DELETE
        [UsuarioModificacion] [int] NULL,
        CONSTRAINT [PK_Historial_Productos] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
    PRINT 'Tabla Historial_Productos creada';
END
GO

-- Tabla Historial_Ventas
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Historial_Ventas]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Historial_Ventas](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [VentaId] [int] NOT NULL,
        [Comentario] [nvarchar](255) NULL,
        [MontoTotal] [decimal](18, 2) NOT NULL,
        [Fecha] [datetime] NULL,
        [TipoPagoEnum] [int] NULL,
        [ClienteId] [int] NULL,
        [EstadoVenta] [int] NULL,
        [UsuarioVendedorId] [int] NULL,
        [DigitoVerificador] [nvarchar](255) NULL,
        [FechaModificacion] [datetime] NOT NULL DEFAULT(GETDATE()),
        [TipoOperacion] [nvarchar](10) NOT NULL, -- INSERT, UPDATE, DELETE
        [UsuarioModificacion] [int] NULL,
        CONSTRAINT [PK_Historial_Ventas] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
    PRINT 'Tabla Historial_Ventas creada';
END
GO

-- ==========================================
-- 3. STORED PROCEDURES GENÉRICOS
-- ==========================================

-- SP Genérico para calcular dígito verificador
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'CalcularDigitoVerificadorEntidad')
    DROP PROCEDURE [dbo].[CalcularDigitoVerificadorEntidad]
GO

CREATE PROCEDURE [dbo].[CalcularDigitoVerificadorEntidad]
    @TipoEntidad NVARCHAR(50),
    @EntidadId INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @CadenaVerificacion NVARCHAR(MAX) = '';
    DECLARE @DigitoVerificador NVARCHAR(255);
    
    -- Construir cadena según el tipo de entidad
    IF @TipoEntidad = 'Usuario'
    BEGIN
        SELECT @CadenaVerificacion = ISNULL(Email, '') + ISNULL(Contraseña, '')
        FROM Usuarios WHERE Id = @EntidadId;
    END
    ELSE IF @TipoEntidad = 'Producto' 
    BEGIN
        SELECT @CadenaVerificacion = 
            ISNULL(Codigo, '') + 
            CAST(ISNULL(CategoriaEnum, 0) AS NVARCHAR) +
            ISNULL(Nombre, '') + 
            ISNULL(Descripcion, '') +
            CAST(PrecioCompra AS NVARCHAR) +
            CAST(ISNULL(Estado, 0) AS NVARCHAR) +
            CONVERT(NVARCHAR, Fecha, 121)
        FROM Producto WHERE Id = @EntidadId;
    END
    ELSE IF @TipoEntidad = 'Venta'
    BEGIN
        SELECT @CadenaVerificacion = 
            CAST(MontoTotal AS NVARCHAR) +
            CONVERT(NVARCHAR, Fecha, 121) +
            CAST(ISNULL(TipoPagoEnum, 0) AS NVARCHAR) +
            CAST(ISNULL(ClienteId, 0) AS NVARCHAR) +
            CAST(ISNULL(EstadoVenta, 0) AS NVARCHAR) +
            CAST(ISNULL(UsuarioVendedorId, 0) AS NVARCHAR)
        FROM Venta WHERE Id = @EntidadId;
    END
    
    -- Calcular hash SHA256 (simulado con HASHBYTES)
    SET @DigitoVerificador = CONVERT(NVARCHAR(255), HASHBYTES('SHA2_256', @CadenaVerificacion), 2);
    
    SELECT @DigitoVerificador AS DigitoVerificador;
END
GO

-- SP para actualizar dígito verificador
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ActualizarDigitoVerificadorEntidad')
    DROP PROCEDURE [dbo].[ActualizarDigitoVerificadorEntidad]
GO

CREATE PROCEDURE [dbo].[ActualizarDigitoVerificadorEntidad]
    @TipoEntidad NVARCHAR(50),
    @EntidadId INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @DigitoVerificador NVARCHAR(255);
    
    -- Calcular nuevo dígito verificador
    EXEC CalcularDigitoVerificadorEntidad @TipoEntidad, @EntidadId;
    
    -- Obtener el resultado
    DECLARE @CadenaVerificacion NVARCHAR(MAX) = '';
    
    IF @TipoEntidad = 'Usuario'
    BEGIN
        SELECT @CadenaVerificacion = ISNULL(Email, '') + ISNULL(Contraseña, '')
        FROM Usuarios WHERE Id = @EntidadId;
        
        SET @DigitoVerificador = CONVERT(NVARCHAR(255), HASHBYTES('SHA2_256', @CadenaVerificacion), 2);
        
        UPDATE Usuarios 
        SET DigitoVerificador = @DigitoVerificador 
        WHERE Id = @EntidadId;
    END
    ELSE IF @TipoEntidad = 'Producto'
    BEGIN
        SELECT @CadenaVerificacion = 
            ISNULL(Codigo, '') + 
            CAST(ISNULL(CategoriaEnum, 0) AS NVARCHAR) +
            ISNULL(Nombre, '') + 
            ISNULL(Descripcion, '') +
            CAST(PrecioCompra AS NVARCHAR) +
            CAST(ISNULL(Estado, 0) AS NVARCHAR) +
            CONVERT(NVARCHAR, Fecha, 121)
        FROM Producto WHERE Id = @EntidadId;
        
        SET @DigitoVerificador = CONVERT(NVARCHAR(255), HASHBYTES('SHA2_256', @CadenaVerificacion), 2);
        
        UPDATE Producto 
        SET DigitoVerificador = @DigitoVerificador 
        WHERE Id = @EntidadId;
    END
    ELSE IF @TipoEntidad = 'Venta'
    BEGIN
        SELECT @CadenaVerificacion = 
            CAST(MontoTotal AS NVARCHAR) +
            CONVERT(NVARCHAR, Fecha, 121) +
            CAST(ISNULL(TipoPagoEnum, 0) AS NVARCHAR) +
            CAST(ISNULL(ClienteId, 0) AS NVARCHAR) +
            CAST(ISNULL(EstadoVenta, 0) AS NVARCHAR) +
            CAST(ISNULL(UsuarioVendedorId, 0) AS NVARCHAR)
        FROM Venta WHERE Id = @EntidadId;
        
        SET @DigitoVerificador = CONVERT(NVARCHAR(255), HASHBYTES('SHA2_256', @CadenaVerificacion), 2);
        
        UPDATE Venta 
        SET DigitoVerificador = @DigitoVerificador 
        WHERE Id = @EntidadId;
    END
    
    PRINT 'Dígito verificador actualizado para ' + @TipoEntidad + ' ID: ' + CAST(@EntidadId AS NVARCHAR);
END
GO

-- ==========================================
-- 4. TRIGGERS PARA HISTORIAL AUTOMÁTICO
-- ==========================================

-- Trigger para Producto
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_Producto_Historial')
    DROP TRIGGER TR_Producto_Historial
GO

CREATE TRIGGER TR_Producto_Historial
ON Producto
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @TipoOperacion NVARCHAR(10);
    DECLARE @UsuarioId INT = (SELECT TOP 1 Id FROM Usuarios WHERE Email = SUSER_NAME()); -- Aproximación
    
    -- Determinar tipo de operación
    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
        SET @TipoOperacion = 'UPDATE'
    ELSE IF EXISTS(SELECT * FROM inserted)
        SET @TipoOperacion = 'INSERT'
    ELSE
        SET @TipoOperacion = 'DELETE'
    
    -- Insertar en historial (INSERT y UPDATE)
    IF @TipoOperacion IN ('INSERT', 'UPDATE')
    BEGIN
        INSERT INTO Historial_Productos (
            ProductoId, Codigo, CategoriaEnum, Stock, Nombre, Descripcion, 
            PrecioCompra, PrecioVenta, Estado, Fecha, StockMinimo, DigitoVerificador,
            TipoOperacion, UsuarioModificacion
        )
        SELECT 
            Id, Codigo, CategoriaEnum, Stock, Nombre, Descripcion,
            PrecioCompra, PrecioVenta, Estado, Fecha, StockMinimo, DigitoVerificador,
            @TipoOperacion, @UsuarioId
        FROM inserted;
        
        -- Actualizar dígito verificador si es INSERT o UPDATE
        DECLARE @ProductoId INT;
        DECLARE cursor_productos CURSOR FOR SELECT Id FROM inserted;
        OPEN cursor_productos;
        FETCH NEXT FROM cursor_productos INTO @ProductoId;
        WHILE @@FETCH_STATUS = 0
        BEGIN
            EXEC ActualizarDigitoVerificadorEntidad 'Producto', @ProductoId;
            FETCH NEXT FROM cursor_productos INTO @ProductoId;
        END
        CLOSE cursor_productos;
        DEALLOCATE cursor_productos;
    END
    
    -- Insertar en historial (DELETE)
    IF @TipoOperacion = 'DELETE'
    BEGIN
        INSERT INTO Historial_Productos (
            ProductoId, Codigo, CategoriaEnum, Stock, Nombre, Descripcion, 
            PrecioCompra, PrecioVenta, Estado, Fecha, StockMinimo, DigitoVerificador,
            TipoOperacion, UsuarioModificacion
        )
        SELECT 
            Id, Codigo, CategoriaEnum, Stock, Nombre, Descripcion,
            PrecioCompra, PrecioVenta, Estado, Fecha, StockMinimo, DigitoVerificador,
            @TipoOperacion, @UsuarioId
        FROM deleted;
    END
END
GO

-- Trigger para Venta
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'TR_Venta_Historial')
    DROP TRIGGER TR_Venta_Historial
GO

CREATE TRIGGER TR_Venta_Historial
ON Venta
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @TipoOperacion NVARCHAR(10);
    DECLARE @UsuarioId INT = (SELECT TOP 1 Id FROM Usuarios WHERE Email = SUSER_NAME());
    
    -- Determinar tipo de operación
    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
        SET @TipoOperacion = 'UPDATE'
    ELSE IF EXISTS(SELECT * FROM inserted)
        SET @TipoOperacion = 'INSERT'
    ELSE
        SET @TipoOperacion = 'DELETE'
    
    -- Insertar en historial (INSERT y UPDATE)
    IF @TipoOperacion IN ('INSERT', 'UPDATE')
    BEGIN
        INSERT INTO Historial_Ventas (
            VentaId, Comentario, MontoTotal, Fecha, TipoPagoEnum, ClienteId, 
            EstadoVenta, UsuarioVendedorId, DigitoVerificador,
            TipoOperacion, UsuarioModificacion
        )
        SELECT 
            Id, Comentario, MontoTotal, Fecha, TipoPagoEnum, ClienteId,
            EstadoVenta, UsuarioVendedorId, DigitoVerificador,
            @TipoOperacion, @UsuarioId
        FROM inserted;
        
        -- Actualizar dígito verificador
        DECLARE @VentaId INT;
        DECLARE cursor_ventas CURSOR FOR SELECT Id FROM inserted;
        OPEN cursor_ventas;
        FETCH NEXT FROM cursor_ventas INTO @VentaId;
        WHILE @@FETCH_STATUS = 0
        BEGIN
            EXEC ActualizarDigitoVerificadorEntidad 'Venta', @VentaId;
            FETCH NEXT FROM cursor_ventas INTO @VentaId;
        END
        CLOSE cursor_ventas;
        DEALLOCATE cursor_ventas;
    END
    
    -- Insertar en historial (DELETE)
    IF @TipoOperacion = 'DELETE'
    BEGIN
        INSERT INTO Historial_Ventas (
            VentaId, Comentario, MontoTotal, Fecha, TipoPagoEnum, ClienteId, 
            EstadoVenta, UsuarioVendedorId, DigitoVerificador,
            TipoOperacion, UsuarioModificacion
        )
        SELECT 
            Id, Comentario, MontoTotal, Fecha, TipoPagoEnum, ClienteId,
            EstadoVenta, UsuarioVendedorId, DigitoVerificador,
            @TipoOperacion, @UsuarioId
        FROM deleted;
    END
END
GO

-- ==========================================
-- 5. STORED PROCEDURES PARA CONTROL DE CAMBIOS
-- ==========================================

-- SP para listar historial genérico
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ListarHistorialEntidad')
    DROP PROCEDURE [dbo].[ListarHistorialEntidad]
GO

CREATE PROCEDURE [dbo].[ListarHistorialEntidad]
    @TipoEntidad NVARCHAR(50),
    @EntidadId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    IF @TipoEntidad = 'Usuario'
    BEGIN
        SELECT * FROM Historial_Usuarios 
        WHERE (@EntidadId IS NULL OR Id = @EntidadId)
        ORDER BY Fecha DESC;
    END
    ELSE IF @TipoEntidad = 'Producto'
    BEGIN
        SELECT * FROM Historial_Productos 
        WHERE (@EntidadId IS NULL OR ProductoId = @EntidadId)
        ORDER BY FechaModificacion DESC;
    END
    ELSE IF @TipoEntidad = 'Venta'
    BEGIN
        SELECT * FROM Historial_Ventas 
        WHERE (@EntidadId IS NULL OR VentaId = @EntidadId)
        ORDER BY FechaModificacion DESC;
    END
END
GO

-- SP para restaurar desde historial
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'RestaurarDesdeHistorial')
    DROP PROCEDURE [dbo].[RestaurarDesdeHistorial]
GO

CREATE PROCEDURE [dbo].[RestaurarDesdeHistorial]
    @TipoEntidad NVARCHAR(50),
    @HistorialId INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    
    BEGIN TRY
        IF @TipoEntidad = 'Usuario'
        BEGIN
            -- Lógica existente para usuarios (ya implementada)
            PRINT 'Restauración de usuarios ya implementada';
        END
        ELSE IF @TipoEntidad = 'Producto'
        BEGIN
            DECLARE @ProductoId INT, @Codigo VARCHAR(50), @CategoriaEnum INT, @Stock DECIMAL(18,2);
            DECLARE @Nombre NVARCHAR(255), @Descripcion NVARCHAR(255), @PrecioCompra DECIMAL(18,2);
            DECLARE @PrecioVenta DECIMAL(18,2), @Estado BIT, @Fecha DATETIME, @StockMinimo DECIMAL(18,2);
            
            SELECT @ProductoId = ProductoId, @Codigo = Codigo, @CategoriaEnum = CategoriaEnum, 
                   @Stock = Stock, @Nombre = Nombre, @Descripcion = Descripcion, 
                   @PrecioCompra = PrecioCompra, @PrecioVenta = PrecioVenta, 
                   @Estado = Estado, @Fecha = Fecha, @StockMinimo = StockMinimo
            FROM Historial_Productos WHERE Id = @HistorialId;
            
            UPDATE Producto SET
                Codigo = @Codigo, CategoriaEnum = @CategoriaEnum, Stock = @Stock,
                Nombre = @Nombre, Descripcion = @Descripcion, PrecioCompra = @PrecioCompra,
                PrecioVenta = @PrecioVenta, Estado = @Estado, Fecha = @Fecha, StockMinimo = @StockMinimo
            WHERE Id = @ProductoId;
            
            -- Recalcular dígito verificador
            EXEC ActualizarDigitoVerificadorEntidad 'Producto', @ProductoId;
        END
        ELSE IF @TipoEntidad = 'Venta'
        BEGIN
            DECLARE @VentaId INT, @Comentario NVARCHAR(255), @MontoTotal DECIMAL(18,2);
            DECLARE @FechaVenta DATETIME, @TipoPagoEnum INT, @ClienteId INT;
            DECLARE @EstadoVenta INT, @UsuarioVendedorId INT;
            
            SELECT @VentaId = VentaId, @Comentario = Comentario, @MontoTotal = MontoTotal,
                   @FechaVenta = Fecha, @TipoPagoEnum = TipoPagoEnum, @ClienteId = ClienteId,
                   @EstadoVenta = EstadoVenta, @UsuarioVendedorId = UsuarioVendedorId
            FROM Historial_Ventas WHERE Id = @HistorialId;
            
            UPDATE Venta SET
                Comentario = @Comentario, MontoTotal = @MontoTotal, Fecha = @FechaVenta,
                TipoPagoEnum = @TipoPagoEnum, ClienteId = @ClienteId, EstadoVenta = @EstadoVenta,
                UsuarioVendedorId = @UsuarioVendedorId
            WHERE Id = @VentaId;
            
            -- Recalcular dígito verificador
            EXEC ActualizarDigitoVerificadorEntidad 'Venta', @VentaId;
        END
        
        COMMIT TRANSACTION;
        PRINT 'Restauración completada exitosamente';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- ==========================================
-- 6. CALCULAR DÍGITOS VERIFICADORES EXISTENTES
-- ==========================================

-- Actualizar dígitos verificadores para datos existentes
PRINT 'Calculando dígitos verificadores para registros existentes...';

-- Usuarios existentes
DECLARE @UsuarioId INT;
DECLARE cursor_usuarios CURSOR FOR SELECT Id FROM Usuarios;
OPEN cursor_usuarios;
FETCH NEXT FROM cursor_usuarios INTO @UsuarioId;
WHILE @@FETCH_STATUS = 0
BEGIN
    EXEC ActualizarDigitoVerificadorEntidad 'Usuario', @UsuarioId;
    FETCH NEXT FROM cursor_usuarios INTO @UsuarioId;
END
CLOSE cursor_usuarios;
DEALLOCATE cursor_usuarios;

-- Productos existentes
DECLARE @ProductoIdEx INT;
DECLARE cursor_productos_ex CURSOR FOR SELECT Id FROM Producto;
OPEN cursor_productos_ex;
FETCH NEXT FROM cursor_productos_ex INTO @ProductoIdEx;
WHILE @@FETCH_STATUS = 0
BEGIN
    EXEC ActualizarDigitoVerificadorEntidad 'Producto', @ProductoIdEx;
    FETCH NEXT FROM cursor_productos_ex INTO @ProductoIdEx;
END
CLOSE cursor_productos_ex;
DEALLOCATE cursor_productos_ex;

-- Ventas existentes
DECLARE @VentaIdEx INT;
DECLARE cursor_ventas_ex CURSOR FOR SELECT Id FROM Venta;
OPEN cursor_ventas_ex;
FETCH NEXT FROM cursor_ventas_ex INTO @VentaIdEx;
WHILE @@FETCH_STATUS = 0
BEGIN
    EXEC ActualizarDigitoVerificadorEntidad 'Venta', @VentaIdEx;
    FETCH NEXT FROM cursor_ventas_ex INTO @VentaIdEx;
END
CLOSE cursor_ventas_ex;
DEALLOCATE cursor_ventas_ex;

PRINT '=========================================';
PRINT 'SISTEMA DE DÍGITO VERIFICADOR Y CONTROL DE CAMBIOS IMPLEMENTADO EXITOSAMENTE';
PRINT '=========================================';
PRINT '';
PRINT 'RESUMEN:';
PRINT '✅ Dígito Verificador: Usuario, Producto, Venta';
PRINT '✅ Control de Cambios: Usuario, Producto, Venta';
PRINT '✅ Triggers automáticos para historial';
PRINT '✅ SPs genéricos para gestión';
PRINT '✅ Dígitos verificadores calculados para datos existentes';
PRINT '';
