-- =============================================
-- Stored Procedure: ObtenerClientePorCUIT
-- Descripción: Busca un cliente por su CUIT y retorna toda su información
-- Parámetros: @CUIT - CUIT del cliente a buscar
-- =============================================

USE [CheeseLogix]
GO

-- Eliminar el procedimiento si ya existe
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

-- Probar el procedimiento
PRINT 'Stored Procedure ObtenerClientePorCUIT creado exitosamente.' 