-- =============================================
-- CONFIGURACIÓN MULTI-IDIOMA - SOLO FALTANTES REALES
-- Script para insertar SOLO palabras y Tags que realmente faltan
-- Base de datos: IngenieriaSoftware
-- =============================================

USE [IngenieriaSoftware]
GO

-- =============================================
-- ANÁLISIS: REUTILIZAR TAGS EXISTENTES
-- =============================================

-- TAGS QUE YA EXISTEN Y PODEMOS REUTILIZAR:
-- ✓ PalabraId 9 (Seleccionar idioma:) -> Ya tiene: lblSeleccionarIdioma_frmReporte
-- ✓ PalabraId 32 (Actualizar) -> Ya tiene: btnActualizar_frmReporte  
-- ✓ PalabraId 1061 (Cerrar) -> Necesita crear nuevos Tags específicos
-- ✓ PalabraId 4 (Salir) -> Ya tiene: btnSalir_frmSer

-- =============================================
-- PARTE 1: INSERTAR SOLO PALABRAS NUEVAS FALTANTES
-- =============================================

DECLARE @MaxIdPalabras INT;
SELECT @MaxIdPalabras = ISNULL(MAX(Id), 0) FROM Palabras;

-- **PALABRAS NUEVAS QUE SÍ FALTAN**

-- "Fecha Inicio:" - NUEVA
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Fecha Inicio:')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Fecha Inicio:');
    PRINT 'Insertada: Fecha Inicio: - ID: ' + CAST(@MaxIdPalabras AS VARCHAR);
END

-- "Fecha Fin:" - NUEVA
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Fecha Fin:')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Fecha Fin:');
    PRINT 'Insertada: Fecha Fin: - ID: ' + CAST(@MaxIdPalabras AS VARCHAR);
END

-- "Recomendaciones Inteligentes" - NUEVA
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Recomendaciones Inteligentes')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Recomendaciones Inteligentes');
    PRINT 'Insertada: Recomendaciones Inteligentes - ID: ' + CAST(@MaxIdPalabras AS VARCHAR);
END

-- "📄 PDF" - NUEVA
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = '📄 PDF')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'📄 PDF');
    PRINT 'Insertada: 📄 PDF - ID: ' + CAST(@MaxIdPalabras AS VARCHAR);
END

-- "📊 Excel" - NUEVA
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = '📊 Excel')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'📊 Excel');
    PRINT 'Insertada: 📊 Excel - ID: ' + CAST(@MaxIdPalabras AS VARCHAR);
END

-- "Serialización" - NUEVA
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Serialización')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Serialización');
    PRINT 'Insertada: Serialización - ID: ' + CAST(@MaxIdPalabras AS VARCHAR);
END

-- "Serializar" - NUEVA
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Serializar')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Serializar');
    PRINT 'Insertada: Serializar - ID: ' + CAST(@MaxIdPalabras AS VARCHAR);
END

-- "Tipo dato:" - NUEVA
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Tipo dato:')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Tipo dato:');
    PRINT 'Insertada: Tipo dato: - ID: ' + CAST(@MaxIdPalabras AS VARCHAR);
END

-- "Deserialización" - NUEVA
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Deserialización')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Deserialización');
    PRINT 'Insertada: Deserialización - ID: ' + CAST(@MaxIdPalabras AS VARCHAR);
END

-- "Deserializar" - NUEVA
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Deserializar')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Deserializar');
    PRINT 'Insertada: Deserializar - ID: ' + CAST(@MaxIdPalabras AS VARCHAR);
END

-- "Guardar" - NUEVA
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Guardar')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Guardar');
    PRINT 'Insertada: Guardar - ID: ' + CAST(@MaxIdPalabras AS VARCHAR);
END

-- "Abrir Carpeta" - NUEVA
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Abrir Carpeta')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Abrir Carpeta');
    PRINT 'Insertada: Abrir Carpeta - ID: ' + CAST(@MaxIdPalabras AS VARCHAR);
END

-- =============================================
-- PARTE 2: ASOCIAR SOLO TAGS FALTANTES (REUTILIZANDO EXISTENTES)
-- =============================================

-- **FORMULARIO: frmReporteInteligente** 
-- REUTILIZAR TAGS EXISTENTES:
-- ✓ lblSeleccionarIdioma_frmReporte (Ya existe)
-- ✓ btnActualizar_frmReporte (Ya existe)

-- Agregar solo los NUEVOS tags faltantes:

-- Tag para "Fecha Inicio:"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblFechaInicio_frmReporte')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblFechaInicio_frmReporte' 
    FROM Palabras WHERE Texto = 'Fecha Inicio:';
    PRINT 'Tag asociado: lblFechaInicio_frmReporte';
END

-- Tag para "Fecha Fin:"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblFechaFin_frmReporte')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblFechaFin_frmReporte' 
    FROM Palabras WHERE Texto = 'Fecha Fin:';
    PRINT 'Tag asociado: lblFechaFin_frmReporte';
END

-- Tag para "Cerrar" en reportes (NUEVO TAG para palabra existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnCerrar_frmReporte')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnCerrar_frmReporte' 
    FROM Palabras WHERE Texto = 'Cerrar';
    PRINT 'Tag asociado: btnCerrar_frmReporte';
END

-- Tag para "📄 PDF"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnExportarPDF_frmReporte')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnExportarPDF_frmReporte' 
    FROM Palabras WHERE Texto = '📄 PDF';
    PRINT 'Tag asociado: btnExportarPDF_frmReporte';
END

-- Tag para "📊 Excel"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnExportarExcel_frmReporte')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnExportarExcel_frmReporte' 
    FROM Palabras WHERE Texto = '📊 Excel';
    PRINT 'Tag asociado: btnExportarExcel_frmReporte';
END

-- Tag para "Recomendaciones Inteligentes"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'groupBoxRecomendaciones_frmReporte')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'groupBoxRecomendaciones_frmReporte' 
    FROM Palabras WHERE Texto = 'Recomendaciones Inteligentes';
    PRINT 'Tag asociado: groupBoxRecomendaciones_frmReporte';
END

-- **FORMULARIO: frmSerializacion** 
-- REUTILIZAR TAGS EXISTENTES:
-- ✓ btnSalir_frmSer (Ya existe)
-- ✓ labelIdioma_frmSer (Ya existe)

-- Agregar solo los NUEVOS tags faltantes:

-- Tag para "Serialización"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'groupBoxSerializacion_frmSer')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'groupBoxSerializacion_frmSer' 
    FROM Palabras WHERE Texto = 'Serialización';
    PRINT 'Tag asociado: groupBoxSerializacion_frmSer';
END

-- Tag para "Serializar"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnSerializar_frmSer')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnSerializar_frmSer' 
    FROM Palabras WHERE Texto = 'Serializar';
    PRINT 'Tag asociado: btnSerializar_frmSer';
END

-- Tag para "Tipo dato:"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblTipoDato_frmSer')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblTipoDato_frmSer' 
    FROM Palabras WHERE Texto = 'Tipo dato:';
    PRINT 'Tag asociado: lblTipoDato_frmSer';
END

-- Tag para "Deserialización"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'groupBoxDeserializacion_frmSer')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'groupBoxDeserializacion_frmSer' 
    FROM Palabras WHERE Texto = 'Deserialización';
    PRINT 'Tag asociado: groupBoxDeserializacion_frmSer';
END

-- Tag para "Deserializar"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnDeserializar_frmSer')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnDeserializar_frmSer' 
    FROM Palabras WHERE Texto = 'Deserializar';
    PRINT 'Tag asociado: btnDeserializar_frmSer';
END

-- Tag para "Guardar"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnGuardarSerializado_frmSer')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnGuardarSerializado_frmSer' 
    FROM Palabras WHERE Texto = 'Guardar';
    PRINT 'Tag asociado: btnGuardarSerializado_frmSer';
END

-- **FORMULARIO: frmAyuda** 
-- NOTA: lblSeleccionarIdioma ya tiene Tag configurado manualmente

-- Tag para "Abrir Carpeta"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnAbrirCarpeta_frmAyuda')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnAbrirCarpeta_frmAyuda' 
    FROM Palabras WHERE Texto = 'Abrir Carpeta';
    PRINT 'Tag asociado: btnAbrirCarpeta_frmAyuda';
END

-- Tag para "Cerrar" en ayuda (NUEVO TAG para palabra existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnCerrar_frmAyuda')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnCerrar_frmAyuda' 
    FROM Palabras WHERE Texto = 'Cerrar';
    PRINT 'Tag asociado: btnCerrar_frmAyuda';
END

-- =============================================
-- PARTE 3: VERIFICACIÓN Y REPORTE
-- =============================================

PRINT '============================================='
PRINT 'CONFIGURACIÓN FALTANTE COMPLETADA'
PRINT '============================================='

-- Mostrar resumen de palabras agregadas
SELECT 'PALABRAS NUEVAS AGREGADAS:' as Resumen;
SELECT Id, Texto FROM Palabras WHERE Id > (
    SELECT MAX(Id) - 12 FROM Palabras  -- Mostrar las últimas 12 nuevas
)
ORDER BY Id;

-- Mostrar TODOS los tags para los formularios que trabajamos
SELECT 'TODOS LOS TAGS PARA FORMULARIOS TRABAJADOS:' as Resumen;
SELECT pt.Tag, p.Texto 
FROM Palabras_Tags pt
INNER JOIN Palabras p ON pt.PalabraId = p.Id
WHERE pt.Tag LIKE '%_frmReporte%' 
   OR pt.Tag LIKE '%_frmSer%' 
   OR pt.Tag LIKE '%_frmAyuda%'
ORDER BY pt.Tag;

PRINT '============================================='
PRINT 'TAGS A AGREGAR MANUALMENTE EN DESIGNER.CS:'
PRINT ''
PRINT 'frmReporteInteligente:'
PRINT '  this.lblFechaInicio.Tag = "lblFechaInicio_frmReporte";'
PRINT '  this.lblFechaFin.Tag = "lblFechaFin_frmReporte";'
PRINT '  this.btnCerrar.Tag = "btnCerrar_frmReporte";'
PRINT '  this.btnExportarPDF.Tag = "btnExportarPDF_frmReporte";'
PRINT '  this.btnExportarExcel.Tag = "btnExportarExcel_frmReporte";'
PRINT '  this.groupBoxRecomendaciones.Tag = "groupBoxRecomendaciones_frmReporte";'
PRINT '  (lblSeleccionarIdioma y btnActualizar YA TIENEN TAGS)'
PRINT ''
PRINT 'frmSerializacion:'
PRINT '  this.groupBoxSerializacion.Tag = "groupBoxSerializacion_frmSer";'
PRINT '  this.btnSerializar.Tag = "btnSerializar_frmSer";'
PRINT '  this.lblTipoDato.Tag = "lblTipoDato_frmSer";'
PRINT '  this.groupBoxDeserializacion.Tag = "groupBoxDeserializacion_frmSer";'
PRINT '  this.btnDeserializar.Tag = "btnDeserializar_frmSer";'
PRINT '  this.btnGuardarSerializado.Tag = "btnGuardarSerializado_frmSer";'
PRINT '  (btnSalir y labelIdioma YA TIENEN TAGS)'
PRINT ''
PRINT 'frmAyuda:'
PRINT '  this.btnAbrirCarpeta.Tag = "btnAbrirCarpeta_frmAyuda";'
PRINT '  this.btnCerrar.Tag = "btnCerrar_frmAyuda";'
PRINT '  (lblSeleccionarIdioma YA TIENE TAG)'
PRINT '============================================='

GO