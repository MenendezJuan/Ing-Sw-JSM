-- =============================================
-- CONFIGURACIÓN MULTI-IDIOMA CORREGIDA PARA CHEESELOGIX
-- Script para insertar palabras faltantes y configurar Tags FALTANTES
-- Base de datos: IngenieriaSoftware
-- =============================================

USE [IngenieriaSoftware]
GO

-- =============================================
-- ANÁLISIS: TAGS FALTANTES EN FORMULARIOS
-- =============================================

-- Los siguientes formularios YA TIENEN Tags configurados y traducidos:
-- ✓ frmInicioSesion - COMPLETO
-- ✓ frmGestionStockProductos - COMPLETO (visto en código)
-- ✓ frmMenuPrincipal - COMPLETO
-- ✓ frmGestorBitacora - COMPLETO
-- ✓ frmGestorIdiomas - COMPLETO
-- ✓ frmGestorPermisos - COMPLETO
-- ✓ frmGestorUsuarios - COMPLETO
-- ✓ frmConfigurarIdioma - COMPLETO

-- FORMULARIOS QUE NECESITAN TAGS:
-- ❌ frmReporteInteligente - SIN TAGS
-- ❌ frmSerializacion - SIN TAGS
-- ❌ frmAyuda - PARCIAL (solo lblSeleccionarIdioma)
-- ❌ frmGestionarClientes - ALGUNOS Tags pero incompleto
-- ❌ frmGestionarProveedores - ALGUNOS Tags pero incompleto

-- =============================================
-- PARTE 1: INSERTAR PALABRAS NUEVAS FALTANTES
-- =============================================

-- Declarar variables para obtener el próximo ID
DECLARE @MaxIdPalabras INT;
SELECT @MaxIdPalabras = ISNULL(MAX(Id), 0) FROM Palabras;

-- **FORMULARIO: frmReporteInteligente** (NO tiene ningún Tag)
-- Verificar e insertar palabras nuevas solo si no existen

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

-- "Reportes Inteligentes - CheeseLogix" - NUEVA
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Reportes Inteligentes - CheeseLogix')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Reportes Inteligentes - CheeseLogix');
    PRINT 'Insertada: Reportes Inteligentes - CheeseLogix - ID: ' + CAST(@MaxIdPalabras AS VARCHAR);
END

-- **FORMULARIO: frmSerializacion** (NO tiene ningún Tag)
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

-- "Serialización de Datos - CheeseLogix" - NUEVA
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Serialización de Datos - CheeseLogix')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Serialización de Datos - CheeseLogix');
    PRINT 'Insertada: Serialización de Datos - CheeseLogix - ID: ' + CAST(@MaxIdPalabras AS VARCHAR);
END

-- **FORMULARIO: frmAyuda** (Parcial - le faltan algunos)
-- "Abrir Carpeta" - NUEVA
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Abrir Carpeta')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Abrir Carpeta');
    PRINT 'Insertada: Abrir Carpeta - ID: ' + CAST(@MaxIdPalabras AS VARCHAR);
END

-- "Ayuda en Línea - CheeseLogix" - NUEVA
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Ayuda en Línea - CheeseLogix')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Ayuda en Línea - CheeseLogix');
    PRINT 'Insertada: Ayuda en Línea - CheeseLogix - ID: ' + CAST(@MaxIdPalabras AS VARCHAR);
END

-- =============================================
-- PARTE 2: ASOCIAR TAGS A PALABRAS (SOLO LOS FALTANTES)
-- =============================================

-- **FORMULARIO: frmReporteInteligente** (NINGÚN TAG EXISTE)
-- Tag para "Seleccionar idioma:" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblSeleccionarIdioma_frmReporte')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblSeleccionarIdioma_frmReporte' 
    FROM Palabras WHERE Texto = 'Seleccionar idioma:';
    PRINT 'Tag asociado: lblSeleccionarIdioma_frmReporte';
END

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

-- Tag para "Actualizar" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnActualizar_frmReporte')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnActualizar_frmReporte' 
    FROM Palabras WHERE Texto = 'Actualizar';
    PRINT 'Tag asociado: btnActualizar_frmReporte';
END

-- Tag para "Cerrar" (reutilizar existente)
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

-- **FORMULARIO: frmSerializacion** (NINGÚN TAG EXISTE)
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

-- Tag para "Salir" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnSalir_frmSer')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnSalir_frmSer' 
    FROM Palabras WHERE Texto = 'Salir';
    PRINT 'Tag asociado: btnSalir_frmSer';
END

-- Tag para "Idioma:" en serialización (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'labelIdioma_frmSer')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'labelIdioma_frmSer' 
    FROM Palabras WHERE Texto = 'Seleccionar idioma:';
    PRINT 'Tag asociado: labelIdioma_frmSer';
END

-- **FORMULARIO: frmAyuda** (PARCIAL - le faltan algunos)
-- Tag para "Abrir Carpeta"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnAbrirCarpeta_frmAyuda')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnAbrirCarpeta_frmAyuda' 
    FROM Palabras WHERE Texto = 'Abrir Carpeta';
    PRINT 'Tag asociado: btnAbrirCarpeta_frmAyuda';
END

-- Tag para "Cerrar" en ayuda
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnCerrar_frmAyuda')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnCerrar_frmAyuda' 
    FROM Palabras WHERE Texto = 'Cerrar';
    PRINT 'Tag asociado: btnCerrar_frmAyuda';
END

-- =============================================
-- PARTE 3: VERIFICACIÓN Y REPORTE ESPECÍFICO
-- =============================================

PRINT '============================================='
PRINT 'CONFIGURACIÓN MULTI-IDIOMA FALTANTE COMPLETADA'
PRINT '============================================='

-- Mostrar resumen de palabras agregadas
SELECT 'PALABRAS NUEVAS AGREGADAS:' as Resumen;
SELECT Id, Texto FROM Palabras WHERE Id > (
    SELECT MAX(Id) - 15 FROM Palabras  -- Mostrar las últimas 15 para verificar
)
ORDER BY Id;

-- Mostrar resumen de tags configurados NUEVOS
SELECT 'TAGS NUEVOS CONFIGURADOS:' as Resumen;
SELECT pt.Tag, p.Texto 
FROM Palabras_Tags pt
INNER JOIN Palabras p ON pt.PalabraId = p.Id
WHERE pt.Tag LIKE '%_frmReporte%' 
   OR pt.Tag LIKE '%_frmSer%' 
   OR pt.Tag LIKE '%_frmAyuda%'
ORDER BY pt.Tag;

PRINT '============================================='
PRINT 'FORMULARIOS QUE NECESITAN TAGS AGREGADOS MANUALMENTE:'
PRINT ''
PRINT '1. frmReporteInteligente.Designer.cs - TODOS LOS CONTROLES'
PRINT '2. frmSerializacion.Designer.cs - TODOS LOS CONTROLES'
PRINT '3. frmAyuda.Designer.cs - SOLO btnAbrirCarpeta y btnCerrar'
PRINT ''
PRINT 'EJEMPLO DE AGREGADO EN DESIGNER.CS:'
PRINT 'this.lblFechaInicio.Tag = "lblFechaInicio_frmReporte";'
PRINT 'this.btnSerializar.Tag = "btnSerializar_frmSer";'
PRINT 'this.btnAbrirCarpeta.Tag = "btnAbrirCarpeta_frmAyuda";'
PRINT '============================================='

GO