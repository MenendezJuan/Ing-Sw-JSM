-- ==========================================
-- Alertas: conteos para UI
-- Seguro para múltiples ejecuciones
-- Requisitos: Tabla Producto con StockMinimo; lógica de StockDisponible
-- ==========================================

-- 1) SP: ContarAjustesPendientes
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ContarAjustesPendientes')
    DROP PROCEDURE [dbo].[ContarAjustesPendientes];
GO

CREATE PROCEDURE [dbo].[ContarAjustesPendientes]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*)
    FROM AjusteStock WITH (NOLOCK)
    WHERE Estado = 0; -- Pendiente
END
GO

-- 2) SP: ContarProductosBajoStock
-- Nota: si existe una vista/función que devuelva StockDisponible por producto, úsala aquí.
-- Aquí asumimos que StockDisponible = Producto.Stock - isnull(Reservado.Reservado,0)

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ContarProductosBajoStock')
    DROP PROCEDURE [dbo].[ContarProductosBajoStock];
GO

CREATE PROCEDURE [dbo].[ContarProductosBajoStock]
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH Reserva AS (
        SELECT dv.ProductoId, SUM(dv.Cantidad) AS Reservado
        FROM DetalleVenta dv WITH (NOLOCK)
        INNER JOIN Venta v WITH (NOLOCK) ON v.Id = dv.VentaId
        WHERE v.Estado = 0 OR v.Estado = 1 -- EnProceso o Cobrada, ajustar según Enum
        GROUP BY dv.ProductoId
    )
    SELECT COUNT(*)
    FROM Producto p WITH (NOLOCK)
    LEFT JOIN Reserva r ON r.ProductoId = p.Id
    WHERE p.Estado = 1
      AND (p.Stock - ISNULL(r.Reservado,0)) <= ISNULL(p.StockMinimo, 0);
END
GO

PRINT '- ContarAjustesPendientes y ContarProductosBajoStock creados/recreados'


