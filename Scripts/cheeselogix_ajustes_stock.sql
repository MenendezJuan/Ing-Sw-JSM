-- ==========================================
-- TABLA Y SPs PARA AJUSTES DE STOCK
-- ==========================================

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AjusteStock]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[AjusteStock](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[ProductoId] [int] NOT NULL,
		[Cantidad] [decimal](18, 2) NOT NULL,
		[Tipo] [int] NOT NULL, -- 0 Entrada, 1 Salida
		[Motivo] [nvarchar](300) NULL,
		[Fecha] [datetime] NOT NULL DEFAULT(getdate()),
		[UsuarioSolicitanteId] [int] NULL,
		[UsuarioAprobadorId] [int] NULL,
		[Estado] [int] NOT NULL, -- 0 Pendiente, 1 Aprobado, 2 Rechazado
		CONSTRAINT [PK_AjusteStock] PRIMARY KEY CLUSTERED ([Id] ASC),
		CONSTRAINT [FK_AjusteStock_Producto] FOREIGN KEY([ProductoId]) REFERENCES [dbo].[Producto] ([Id])
	);
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertarAjusteStock')
	DROP PROCEDURE [dbo].[InsertarAjusteStock]
GO

CREATE PROCEDURE [dbo].[InsertarAjusteStock]
	@ProductoId INT,
	@Cantidad DECIMAL(18,2),
	@Tipo INT,
	@Motivo NVARCHAR(300),
	@Fecha DATETIME,
	@UsuarioSolicitanteId INT = NULL,
	@Estado INT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO AjusteStock(ProductoId, Cantidad, Tipo, Motivo, Fecha, UsuarioSolicitanteId, Estado)
	VALUES (@ProductoId, @Cantidad, @Tipo, @Motivo, @Fecha, @UsuarioSolicitanteId, @Estado);
	SELECT SCOPE_IDENTITY();
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'AprobarAjusteStock')
	DROP PROCEDURE [dbo].[AprobarAjusteStock]
GO

CREATE PROCEDURE [dbo].[AprobarAjusteStock]
	@AjusteId INT,
	@UsuarioAprobadorId INT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ProductoId INT, @Cantidad DECIMAL(18,2), @Tipo INT;

	SELECT @ProductoId = ProductoId, @Cantidad = Cantidad, @Tipo = Tipo
	FROM AjusteStock WHERE Id = @AjusteId AND Estado = 0;

	IF @ProductoId IS NULL RETURN;

	-- Aplicar ajuste
	IF @Tipo = 0 -- Entrada
		UPDATE Producto SET Stock = Stock + @Cantidad WHERE Id = @ProductoId;
	ELSE -- Salida
		UPDATE Producto SET Stock = CASE WHEN (Stock - @Cantidad) < 0 THEN 0 ELSE (Stock - @Cantidad) END WHERE Id = @ProductoId;

	-- Marcar como aprobado
	UPDATE AjusteStock 
	SET Estado = 1, UsuarioAprobadorId = @UsuarioAprobadorId
	WHERE Id = @AjusteId;
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'RechazarAjusteStock')
	DROP PROCEDURE [dbo].[RechazarAjusteStock]
GO

CREATE PROCEDURE [dbo].[RechazarAjusteStock]
	@AjusteId INT,
	@UsuarioAprobadorId INT,
	@Motivo NVARCHAR(300) = NULL
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE AjusteStock 
	SET Estado = 2, UsuarioAprobadorId = @UsuarioAprobadorId, Motivo = ISNULL(@Motivo, Motivo)
	WHERE Id = @AjusteId AND Estado = 0;
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ListarAjustesPendientes')
	DROP PROCEDURE [dbo].[ListarAjustesPendientes]
GO

CREATE PROCEDURE [dbo].[ListarAjustesPendientes]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, ProductoId, Cantidad, Tipo, Motivo, Fecha, UsuarioSolicitanteId, UsuarioAprobadorId, Estado
	FROM AjusteStock WHERE Estado = 0 ORDER BY Fecha DESC;
END
GO

