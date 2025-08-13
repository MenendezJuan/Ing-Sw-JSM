-- ==========================================
-- TABLA Y SPs PARA DEVOLUCIONES
-- ==========================================

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Devolucion]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Devolucion](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Origen] [int] NOT NULL, -- 0 Cliente, 1 Proveedor
		[VentaId] [int] NULL,
		[CompraId] [int] NULL,
		[ProductoId] [int] NOT NULL,
		[Cantidad] [decimal](18, 2) NOT NULL,
		[Motivo] [nvarchar](300) NULL,
		[AptoParaVenta] [bit] NOT NULL DEFAULT(0),
		[Fecha] [datetime] NOT NULL DEFAULT(getdate()),
		[UsuarioId] [int] NULL,
		CONSTRAINT [PK_Devolucion] PRIMARY KEY CLUSTERED ([Id] ASC),
		CONSTRAINT [FK_Devolucion_Producto] FOREIGN KEY([ProductoId]) REFERENCES [dbo].[Producto] ([Id])
	);
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertarDevolucion')
	DROP PROCEDURE [dbo].[InsertarDevolucion]
GO

CREATE PROCEDURE [dbo].[InsertarDevolucion]
	@Origen INT,
	@VentaId INT = NULL,
	@CompraId INT = NULL,
	@ProductoId INT,
	@Cantidad DECIMAL(18,2),
	@Motivo NVARCHAR(300) = NULL,
	@AptoParaVenta BIT = 0,
	@Fecha DATETIME,
	@UsuarioId INT = NULL
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Devolucion(Origen, VentaId, CompraId, ProductoId, Cantidad, Motivo, AptoParaVenta, Fecha, UsuarioId)
	VALUES (@Origen, @VentaId, @CompraId, @ProductoId, @Cantidad, @Motivo, @AptoParaVenta, @Fecha, @UsuarioId);
	SELECT SCOPE_IDENTITY();
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ListarDevoluciones')
	DROP PROCEDURE [dbo].[ListarDevoluciones]
GO

CREATE PROCEDURE [dbo].[ListarDevoluciones]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, Origen, VentaId, CompraId, ProductoId, Cantidad, Motivo, AptoParaVenta, Fecha, UsuarioId
	FROM Devolucion ORDER BY Fecha DESC;
END
GO

