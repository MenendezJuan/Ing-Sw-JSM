-- ==========================================
-- STORED PROCEDURE PARA BUSCAR CLIENTE POR CUIT
-- ==========================================

-- Procedure para buscar cliente por CUIT
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ObtenerClientePorCUIT')
    DROP PROCEDURE [dbo].[ObtenerClientePorCUIT]
GO

CREATE PROCEDURE [dbo].[ObtenerClientePorCUIT]
    @CUIT VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
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
    FROM Cliente 
    WHERE CUIT = @CUIT AND Estado = 1;
END
GO

PRINT 'Stored procedure ObtenerClientePorCUIT creado exitosamente.'; 