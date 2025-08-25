-- ==========================================
-- CORRECCION DE STORED PROCEDURES PARA DIGITO VERIFICADOR
-- Sin errores de encoding - Version corregida
-- ==========================================

-- Eliminar procedimientos existentes si existen
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'CalcularDigitoVerificadorEntidad')
    DROP PROCEDURE [dbo].[CalcularDigitoVerificadorEntidad]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ActualizarDigitoVerificadorEntidad')
    DROP PROCEDURE [dbo].[ActualizarDigitoVerificadorEntidad]
GO

-- ==========================================
-- SP para calcular digito verificador
-- ==========================================
CREATE PROCEDURE [dbo].[CalcularDigitoVerificadorEntidad]
    @TipoEntidad NVARCHAR(50),
    @EntidadId INT
AS
BEGIN
    SET NOCOUNT ON;
    SET QUOTED_IDENTIFIER ON;
    
    DECLARE @CadenaVerificacion NVARCHAR(MAX) = '';
    DECLARE @DigitoVerificador NVARCHAR(255);
    
    -- Construir cadena segun el tipo de entidad
    IF @TipoEntidad = 'Usuario'
    BEGIN
        SELECT @CadenaVerificacion = ISNULL(Email, '') + ISNULL(Contraseña, '')
        FROM Usuarios 
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
        FROM Producto 
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
        FROM Venta 
        WHERE Id = @EntidadId;
    END
    
    -- Calcular hash SHA256
    SET @DigitoVerificador = CONVERT(NVARCHAR(255), HASHBYTES('SHA2_256', @CadenaVerificacion), 2);
    
    SELECT @DigitoVerificador AS DigitoVerificador;
END
GO

-- ==========================================
-- SP para actualizar digito verificador
-- ==========================================
CREATE PROCEDURE [dbo].[ActualizarDigitoVerificadorEntidad]
    @TipoEntidad NVARCHAR(50),
    @EntidadId INT
AS
BEGIN
    SET NOCOUNT ON;
    SET QUOTED_IDENTIFIER ON;
    
    DECLARE @DigitoVerificador NVARCHAR(255);
    DECLARE @CadenaVerificacion NVARCHAR(MAX) = '';
    
    IF @TipoEntidad = 'Usuario'
    BEGIN
        SELECT @CadenaVerificacion = ISNULL(Email, '') + ISNULL(Contraseña, '')
        FROM Usuarios 
        WHERE Id = @EntidadId;
        
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
        FROM Producto 
        WHERE Id = @EntidadId;
        
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
        FROM Venta 
        WHERE Id = @EntidadId;
        
        SET @DigitoVerificador = CONVERT(NVARCHAR(255), HASHBYTES('SHA2_256', @CadenaVerificacion), 2);
        
        UPDATE Venta 
        SET DigitoVerificador = @DigitoVerificador 
        WHERE Id = @EntidadId;
    END
    
    PRINT 'Digito verificador actualizado para ' + @TipoEntidad + ' ID: ' + CAST(@EntidadId AS NVARCHAR);
END
GO

-- ==========================================
-- CALCULAR DIGITOS VERIFICADORES PARA DATOS EXISTENTES
-- ==========================================
PRINT 'Calculando digitos verificadores para registros existentes...';

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
DECLARE @ProductoId INT;
DECLARE cursor_productos CURSOR FOR SELECT Id FROM Producto;
OPEN cursor_productos;
FETCH NEXT FROM cursor_productos INTO @ProductoId;
WHILE @@FETCH_STATUS = 0
BEGIN
    EXEC ActualizarDigitoVerificadorEntidad 'Producto', @ProductoId;
    FETCH NEXT FROM cursor_productos INTO @ProductoId;
END
CLOSE cursor_productos;
DEALLOCATE cursor_productos;

-- Ventas existentes
DECLARE @VentaId INT;
DECLARE cursor_ventas CURSOR FOR SELECT Id FROM Venta;
OPEN cursor_ventas;
FETCH NEXT FROM cursor_ventas INTO @VentaId;
WHILE @@FETCH_STATUS = 0
BEGIN
    EXEC ActualizarDigitoVerificadorEntidad 'Venta', @VentaId;
    FETCH NEXT FROM cursor_ventas INTO @VentaId;
END
CLOSE cursor_ventas;
DEALLOCATE cursor_ventas;

-- Registrar en bitacora la inicializacion
IF EXISTS (SELECT 1 FROM sys.objects WHERE name = 'Guardar_Bitacora' AND type = 'P')
BEGIN
    EXEC Guardar_Bitacora 
        @Fecha = NULL,
        @Accion = 89,
        @Usuario = 1,
        @Descripcion = 'SISTEMA DE DIGITO VERIFICADOR INICIALIZADO: Digitos verificadores calculados para todos los registros existentes (Usuarios, Productos, Ventas)';
END

PRINT '=========================================';
PRINT 'STORED PROCEDURES CORREGIDOS Y DIGITOS VERIFICADORES CALCULADOS';
PRINT '=========================================';
PRINT '';
PRINT 'RESULTADO:';
PRINT '✓ CalcularDigitoVerificadorEntidad creado correctamente';
PRINT '✓ ActualizarDigitoVerificadorEntidad creado correctamente';
PRINT '✓ Digitos verificadores calculados para datos existentes';
PRINT '✓ Sistema listo para usar';
