-- =============================================
-- CONFIGURACIÓN MULTI-IDIOMA PARA CHEESELOGIX
-- Script para insertar palabras faltantes y configurar Tags
-- Base de datos: IngenieriaSoftware
-- =============================================

USE [IngenieriaSoftware]
GO

-- =============================================
-- PARTE 1: INSERTAR PALABRAS NUEVAS FALTANTES
-- =============================================

-- Declarar variables para obtener el próximo ID
DECLARE @MaxIdPalabras INT;
SELECT @MaxIdPalabras = ISNULL(MAX(Id), 0) FROM Palabras;

-- **FORMULARIO: frmReporteInteligente**
-- Verificar e insertar palabras nuevas solo si no existen

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Idioma:')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Idioma:');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Fecha Inicio:')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Fecha Inicio:');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Fecha Fin:')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Fecha Fin:');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Recomendaciones Inteligentes')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Recomendaciones Inteligentes');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = '📄 PDF')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'📄 PDF');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = '📊 Excel')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'📊 Excel');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Reportes Inteligentes - CheeseLogix')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Reportes Inteligentes - CheeseLogix');
END

-- **FORMULARIO: frmSerializacion**
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Serialización')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Serialización');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Serializar')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Serializar');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Tipo dato:')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Tipo dato:');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Deserialización')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Deserialización');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Deserializar')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Deserializar');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Guardar')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Guardar');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Serialización de Datos - CheeseLogix')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Serialización de Datos - CheeseLogix');
END

-- **FORMULARIO: frmAyuda**
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Abrir Carpeta')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Abrir Carpeta');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Ayuda en Línea - CheeseLogix')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Ayuda en Línea - CheeseLogix');
END

-- **FORMULARIO: frmGestionStockProductos**
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Gestionar Productos')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Gestionar Productos');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Precio Compra')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Precio Compra');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Producto Seleccionado:')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Producto Seleccionado:');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Ingresar Datos')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Ingresar Datos');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Seleccione un proveedor para visualizar sus productos')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Seleccione un proveedor para visualizar sus productos');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Buscar por:')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Buscar por:');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Buscar en la Grilla')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Buscar en la Grilla');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Ver Productos Inactivos')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Ver Productos Inactivos');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Reactivar Producto')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Reactivar Producto');
END

-- **FORMULARIO: frmGestionarClientes**
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Gestionar Clientes')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Gestionar Clientes');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Reactivar Cliente')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Reactivar Cliente');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Ver Clientes Inactivos')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Ver Clientes Inactivos');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Export Excel')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Export Excel');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Refresh')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Refresh');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Apellido')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Apellido');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Mail')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Mail');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Teléfono')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Teléfono');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Cliente Seleccionado:')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Cliente Seleccionado:');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Direccion')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Direccion');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'CUIT')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'CUIT');
END

-- **FORMULARIO: frmMenuPrincipal**
IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Usuario:')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Usuario:');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Gestion Clientes')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Gestion Clientes');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Cobrar')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Cobrar');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Despachar Productos')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Despachar Productos');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'Ventas')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'Ventas');
END

IF NOT EXISTS (SELECT 1 FROM Palabras WHERE Texto = 'CheeseLogix')
BEGIN
    SET @MaxIdPalabras = @MaxIdPalabras + 1;
    INSERT INTO Palabras (Id, Texto) VALUES (@MaxIdPalabras, N'CheeseLogix');
END

-- =============================================
-- PARTE 2: ASOCIAR TAGS A PALABRAS EXISTENTES Y NUEVAS
-- =============================================

-- **FORMULARIO: frmReporteInteligente**
-- Tag para "Seleccionar idioma:" (reutilizar ID existente 9)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblSeleccionarIdioma_frmReporte')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblSeleccionarIdioma_frmReporte' 
    FROM Palabras WHERE Texto = 'Seleccionar idioma:';
END

-- Tag para "Fecha Inicio:"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblFechaInicio_frmReporte')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblFechaInicio_frmReporte' 
    FROM Palabras WHERE Texto = 'Fecha Inicio:';
END

-- Tag para "Fecha Fin:"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblFechaFin_frmReporte')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblFechaFin_frmReporte' 
    FROM Palabras WHERE Texto = 'Fecha Fin:';
END

-- Tag para "Actualizar" (reutilizar ID existente 32)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnActualizar_frmReporte')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnActualizar_frmReporte' 
    FROM Palabras WHERE Texto = 'Actualizar';
END

-- Tag para "Cerrar" (reutilizar ID existente 1061)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnCerrar_frmReporte')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnCerrar_frmReporte' 
    FROM Palabras WHERE Texto = 'Cerrar';
END

-- Tag para "📄 PDF"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnExportarPDF_frmReporte')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnExportarPDF_frmReporte' 
    FROM Palabras WHERE Texto = '📄 PDF';
END

-- Tag para "📊 Excel"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnExportarExcel_frmReporte')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnExportarExcel_frmReporte' 
    FROM Palabras WHERE Texto = '📊 Excel';
END

-- Tag para "Recomendaciones Inteligentes"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'groupBoxRecomendaciones_frmReporte')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'groupBoxRecomendaciones_frmReporte' 
    FROM Palabras WHERE Texto = 'Recomendaciones Inteligentes';
END

-- **FORMULARIO: frmSerializacion**
-- Tag para "Serialización"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'groupBoxSerializacion_frmSer')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'groupBoxSerializacion_frmSer' 
    FROM Palabras WHERE Texto = 'Serialización';
END

-- Tag para "Serializar"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnSerializar_frmSer')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnSerializar_frmSer' 
    FROM Palabras WHERE Texto = 'Serializar';
END

-- Tag para "Tipo dato:"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblTipoDato_frmSer')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblTipoDato_frmSer' 
    FROM Palabras WHERE Texto = 'Tipo dato:';
END

-- Tag para "Deserialización"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'groupBoxDeserializacion_frmSer')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'groupBoxDeserializacion_frmSer' 
    FROM Palabras WHERE Texto = 'Deserialización';
END

-- Tag para "Deserializar"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnDeserializar_frmSer')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnDeserializar_frmSer' 
    FROM Palabras WHERE Texto = 'Deserializar';
END

-- Tag para "Guardar"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnGuardarSerializado_frmSer')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnGuardarSerializado_frmSer' 
    FROM Palabras WHERE Texto = 'Guardar';
END

-- Tag para "Salir" (reutilizar ID existente 4)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnSalir_frmSer')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnSalir_frmSer' 
    FROM Palabras WHERE Texto = 'Salir';
END

-- Tag para "Idioma:" en serialización
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'labelIdioma_frmSer')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'labelIdioma_frmSer' 
    FROM Palabras WHERE Texto = 'Idioma:';
END

-- **FORMULARIO: frmAyuda**
-- Tag para "Idioma:" en ayuda (ya existe el tag lblSeleccionarIdioma_frmAyuda)
-- Usar diferente tag para evitar conflictos
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblSeleccionarIdioma_frmAyuda')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblSeleccionarIdioma_frmAyuda' 
    FROM Palabras WHERE Texto = 'Idioma:';
END

-- Tag para "Abrir Carpeta"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnAbrirCarpeta_frmAyuda')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnAbrirCarpeta_frmAyuda' 
    FROM Palabras WHERE Texto = 'Abrir Carpeta';
END

-- Tag para "Cerrar" en ayuda
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnCerrar_frmAyuda')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnCerrar_frmAyuda' 
    FROM Palabras WHERE Texto = 'Cerrar';
END

-- **FORMULARIO: frmGestionStockProductos**
-- Tag para "Gestionar Productos"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblTituloProductos_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblTituloProductos_frmStock' 
    FROM Palabras WHERE Texto = 'Gestionar Productos';
END

-- Tag para "Agregar" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'buttonAgregarProductoProveedorSelec_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'buttonAgregarProductoProveedorSelec_frmStock' 
    FROM Palabras WHERE Texto = 'Agregar';
END

-- Tag para "Actualizar" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'buttonActualizarProducto_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'buttonActualizarProducto_frmStock' 
    FROM Palabras WHERE Texto = 'Actualizar';
END

-- Tag para "Eliminar" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'buttonEliminarProducto_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'buttonEliminarProducto_frmStock' 
    FROM Palabras WHERE Texto = 'Eliminar';
END

-- Tag para "Precio Compra"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'label6_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'label6_frmStock' 
    FROM Palabras WHERE Texto = 'Precio Compra';
END

-- Tag para "Categoría" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'label4_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'label4_frmStock' 
    FROM Palabras WHERE Texto = 'Categoría';
END

-- Tag para "Producto Seleccionado:"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblSeleccionado_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblSeleccionado_frmStock' 
    FROM Palabras WHERE Texto = 'Producto Seleccionado:';
END

-- Tag para "Descripción" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'label3_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'label3_frmStock' 
    FROM Palabras WHERE Texto = 'Descripción';
END

-- Tag para "Borrar" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnBorrarIngresoDatos_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnBorrarIngresoDatos_frmStock' 
    FROM Palabras WHERE Texto = 'Borrar';
END

-- Tag para "Nombre" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'estadolbl_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'estadolbl_frmStock' 
    FROM Palabras WHERE Texto = 'Nombre';
END

-- Tag para "Aceptar" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnAceptar_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnAceptar_frmStock' 
    FROM Palabras WHERE Texto = 'Aceptar';
END

-- Tag para "Ingresar Datos"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblDatos_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblDatos_frmStock' 
    FROM Palabras WHERE Texto = 'Ingresar Datos';
END

-- Tag para "Código" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'label1_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'label1_frmStock' 
    FROM Palabras WHERE Texto = 'Código';
END

-- Tag para "Seleccione un proveedor para visualizar sus productos"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'labelSeleccionProveedor_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'labelSeleccionProveedor_frmStock' 
    FROM Palabras WHERE Texto = 'Seleccione un proveedor para visualizar sus productos';
END

-- Tag para "Buscar" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnBuscar_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnBuscar_frmStock' 
    FROM Palabras WHERE Texto = 'Buscar';
END

-- Tag para "Buscar por:"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'label2_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'label2_frmStock' 
    FROM Palabras WHERE Texto = 'Buscar por:';
END

-- Tag para "Buscar en la Grilla"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'label8_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'label8_frmStock' 
    FROM Palabras WHERE Texto = 'Buscar en la Grilla';
END

-- Tag para "Refrescar" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnRefresh_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnRefresh_frmStock' 
    FROM Palabras WHERE Texto = 'Refrescar';
END

-- Tag para "Ver Productos Inactivos"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'buttonReactivacionProducto_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'buttonReactivacionProducto_frmStock' 
    FROM Palabras WHERE Texto = 'Ver Productos Inactivos';
END

-- Tag para "Exportar Excel" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnExportar_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnExportar_frmStock' 
    FROM Palabras WHERE Texto = 'Exportar Excel';
END

-- Tag para "Reactivar Producto"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnReactivarProductos_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnReactivarProductos_frmStock' 
    FROM Palabras WHERE Texto = 'Reactivar Producto';
END

-- Tag para "Seleccionar idioma:" en stock (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblSeleccionarIdioma_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblSeleccionarIdioma_frmStock' 
    FROM Palabras WHERE Texto = 'Seleccionar idioma:';
END

-- Tag para "Cerrar" en stock
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnCerrar_frmStock')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnCerrar_frmStock' 
    FROM Palabras WHERE Texto = 'Cerrar';
END

-- **FORMULARIO: frmGestionarClientes**
-- Tag para "Seleccionar idioma:" en clientes (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblSeleccionarIdioma_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblSeleccionarIdioma_frmClientes' 
    FROM Palabras WHERE Texto = 'Seleccionar idioma:';
END

-- Tag para "Reactivar Cliente"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnReactivarCliente_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnReactivarCliente_frmClientes' 
    FROM Palabras WHERE Texto = 'Reactivar Cliente';
END

-- Tag para "Ver Clientes Inactivos"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'buttonReactivacionCli_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'buttonReactivacionCli_frmClientes' 
    FROM Palabras WHERE Texto = 'Ver Clientes Inactivos';
END

-- Tag para "Buscar" en clientes
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnBuscar_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnBuscar_frmClientes' 
    FROM Palabras WHERE Texto = 'Buscar';
END

-- Tag para "Buscar por:" en clientes
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'label2_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'label2_frmClientes' 
    FROM Palabras WHERE Texto = 'Buscar por:';
END

-- Tag para "Buscar en la Grilla" en clientes
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'label8_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'label8_frmClientes' 
    FROM Palabras WHERE Texto = 'Buscar en la Grilla';
END

-- Tag para "Export Excel"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnExportar_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnExportar_frmClientes' 
    FROM Palabras WHERE Texto = 'Export Excel';
END

-- Tag para "Refresh"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnRefresh_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnRefresh_frmClientes' 
    FROM Palabras WHERE Texto = 'Refresh';
END

-- Tag para "Apellido"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'labelApellido_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'labelApellido_frmClientes' 
    FROM Palabras WHERE Texto = 'Apellido';
END

-- Tag para "Mail"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'label5_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'label5_frmClientes' 
    FROM Palabras WHERE Texto = 'Mail';
END

-- Tag para "Teléfono"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'label4_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'label4_frmClientes' 
    FROM Palabras WHERE Texto = 'Teléfono';
END

-- Tag para "Cliente Seleccionado:"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblSeleccionado_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblSeleccionado_frmClientes' 
    FROM Palabras WHERE Texto = 'Cliente Seleccionado:';
END

-- Tag para "Direccion"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'label3_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'label3_frmClientes' 
    FROM Palabras WHERE Texto = 'Direccion';
END

-- Tag para "Nombre" en clientes
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblNombre_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblNombre_frmClientes' 
    FROM Palabras WHERE Texto = 'Nombre';
END

-- Tag para "CUIT"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'label1_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'label1_frmClientes' 
    FROM Palabras WHERE Texto = 'CUIT';
END

-- Tag para "Borrar" en clientes
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnBorrarIngresoDatos_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnBorrarIngresoDatos_frmClientes' 
    FROM Palabras WHERE Texto = 'Borrar';
END

-- Tag para "Aceptar" en clientes
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnAceptar_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnAceptar_frmClientes' 
    FROM Palabras WHERE Texto = 'Aceptar';
END

-- Tag para "Ingresar Datos" en clientes
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblDatos_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblDatos_frmClientes' 
    FROM Palabras WHERE Texto = 'Ingresar Datos';
END

-- Tag para "Eliminar" en clientes
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'buttonEliminarCliente_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'buttonEliminarCliente_frmClientes' 
    FROM Palabras WHERE Texto = 'Eliminar';
END

-- Tag para "Actualizar" en clientes
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'buttonActualizarCliente_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'buttonActualizarCliente_frmClientes' 
    FROM Palabras WHERE Texto = 'Actualizar';
END

-- Tag para "Agregar" en clientes
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'buttonAgregarCliente_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'buttonAgregarCliente_frmClientes' 
    FROM Palabras WHERE Texto = 'Agregar';
END

-- Tag para "Gestionar Clientes"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblTituloClientes_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblTituloClientes_frmClientes' 
    FROM Palabras WHERE Texto = 'Gestionar Clientes';
END

-- Tag para "Cerrar" en clientes
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnCerrar_frmClientes')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnCerrar_frmClientes' 
    FROM Palabras WHERE Texto = 'Cerrar';
END

-- **FORMULARIO: frmMenuPrincipal**
-- Tag para "Seleccionar idioma:" en menú principal
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblSeleccionarIdioma_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblSeleccionarIdioma_frmMenu' 
    FROM Palabras WHERE Texto = 'Seleccionar idioma:';
END

-- Tag para "Usuario" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'labelUsuario_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'labelUsuario_frmMenu' 
    FROM Palabras WHERE Texto = 'Usuario';
END

-- Tag para "Usuario:"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'labelUser_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'labelUser_frmMenu' 
    FROM Palabras WHERE Texto = 'Usuario:';
END

-- Tag para "LogOut" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'logOutToolStripMenuItem_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'logOutToolStripMenuItem_frmMenu' 
    FROM Palabras WHERE Texto = 'LogOut';
END

-- Tag para "Administracion" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'toolStripMenuItemAdministracion_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'toolStripMenuItemAdministracion_frmMenu' 
    FROM Palabras WHERE Texto = 'Administracion';
END

-- Tag para "Gestion de Usuarios" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'UsuariosToolStripMenuItem_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'UsuariosToolStripMenuItem_frmMenu' 
    FROM Palabras WHERE Texto = 'Gestion de Usuarios';
END

-- Tag para "Gestion de Permisos" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'perfilesToolStripMenuItem_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'perfilesToolStripMenuItem_frmMenu' 
    FROM Palabras WHERE Texto = 'Gestion de Permisos';
END

-- Tag para "Gestion de Idiomas" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'idiomasToolStripMenuItem_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'idiomasToolStripMenuItem_frmMenu' 
    FROM Palabras WHERE Texto = 'Gestion de Idiomas';
END

-- Tag para "Auditar Bitacora" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'bitacoraToolStripMenuItem_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'bitacoraToolStripMenuItem_frmMenu' 
    FROM Palabras WHERE Texto = 'Auditar Bitacora';
END

-- Tag para "Ayuda" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'toolStripMenuItemAyuda_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'toolStripMenuItemAyuda_frmMenu' 
    FROM Palabras WHERE Texto = 'Ayuda';
END

-- Tag para "Administracion" botón
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnAdministracion_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnAdministracion_frmMenu' 
    FROM Palabras WHERE Texto = 'Administracion';
END

-- Tag para "Reportes" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnReportes_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnReportes_frmMenu' 
    FROM Palabras WHERE Texto = 'Reportes';
END

-- Tag para "Gestion Proveedores" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'buttonGestionarProveedores_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'buttonGestionarProveedores_frmMenu' 
    FROM Palabras WHERE Texto = 'Gestion Proveedores';
END

-- Tag para "Gestion Clientes"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'buttonGestionarClientes_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'buttonGestionarClientes_frmMenu' 
    FROM Palabras WHERE Texto = 'Gestion Clientes';
END

-- Tag para "Entidades" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'buttonEntidades_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'buttonEntidades_frmMenu' 
    FROM Palabras WHERE Texto = 'Entidades';
END

-- Tag para "Cobrar"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnCobrarVenta_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnCobrarVenta_frmMenu' 
    FROM Palabras WHERE Texto = 'Cobrar';
END

-- Tag para "Caja" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnCaja_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnCaja_frmMenu' 
    FROM Palabras WHERE Texto = 'Caja';
END

-- Tag para "Despachar Productos"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnDespachoProducto_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnDespachoProducto_frmMenu' 
    FROM Palabras WHERE Texto = 'Despachar Productos';
END

-- Tag para "Ventas"
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnVentas_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnVentas_frmMenu' 
    FROM Palabras WHERE Texto = 'Ventas';
END

-- Tag para "Compras" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnComprasProductos_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnComprasProductos_frmMenu' 
    FROM Palabras WHERE Texto = 'Compras';
END

-- Tag para "Stock" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnStockProductos_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnStockProductos_frmMenu' 
    FROM Palabras WHERE Texto = 'Stock';
END

-- Tag para "Gestionar Productos" en menú
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnGestionProducto_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnGestionProducto_frmMenu' 
    FROM Palabras WHERE Texto = 'Gestionar Productos';
END

-- Tag para "Evaluar Cotizaciones" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'buttonEvaluarSolicitudes_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'buttonEvaluarSolicitudes_frmMenu' 
    FROM Palabras WHERE Texto = 'Evaluar Cotizaciones';
END

-- Tag para "Solicitar Cotizaciones" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'buttonSolicitarCotizacion_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'buttonSolicitarCotizacion_frmMenu' 
    FROM Palabras WHERE Texto = 'Solicitar Cotizaciones';
END

-- Tag para "Cotizaciones" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btnControl_frmMenu')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btnControl_frmMenu' 
    FROM Palabras WHERE Texto = 'Cotizaciones';
END

-- **FORMULARIO: frmInicioSesion**
-- Tag para "Iniciar Sesion" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'btn_IniciarSesion_frmLogin')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'btn_IniciarSesion_frmLogin' 
    FROM Palabras WHERE Texto = 'Iniciar Sesion';
END

-- Tag para "Email" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lbl_Email_frmLogin')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lbl_Email_frmLogin' 
    FROM Palabras WHERE Texto = 'Email';
END

-- Tag para "Contraseña" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lbl_Contraseña_frmLogin')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lbl_Contraseña_frmLogin' 
    FROM Palabras WHERE Texto = 'Contraseña';
END

-- Tag para "Ingrese su mail y contraseña" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lbl_InicioSesion_frmLogin')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lbl_InicioSesion_frmLogin' 
    FROM Palabras WHERE Texto = 'Ingrese su mail y contraseña';
END

-- Tag para "Seleccionar idioma:" en login
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'lblSeleccionarIdioma_frmLogin')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'lblSeleccionarIdioma_frmLogin' 
    FROM Palabras WHERE Texto = 'Seleccionar idioma:';
END

-- Tag para "Registrarse" (reutilizar existente)
IF NOT EXISTS (SELECT 1 FROM Palabras_Tags WHERE Tag = 'label_Registrarse_frmLogin')
BEGIN
    INSERT INTO Palabras_Tags (PalabraId, Tag) 
    SELECT Id, 'label_Registrarse_frmLogin' 
    FROM Palabras WHERE Texto = 'Registrarse';
END

-- =============================================
-- PARTE 3: VERIFICACIÓN Y REPORTE
-- =============================================

PRINT '============================================='
PRINT 'CONFIGURACIÓN MULTI-IDIOMA COMPLETADA'
PRINT '============================================='

-- Mostrar resumen de palabras agregadas
SELECT 'PALABRAS NUEVAS AGREGADAS:' as Resumen;
SELECT Id, Texto FROM Palabras WHERE Id > (
    SELECT MAX(Id) - 20 FROM Palabras  -- Mostrar las últimas 20 para verificar
)
ORDER BY Id;

-- Mostrar resumen de tags configurados para formularios
SELECT 'TAGS CONFIGURADOS PARA FORMULARIOS:' as Resumen;
SELECT pt.Tag, p.Texto 
FROM Palabras_Tags pt
INNER JOIN Palabras p ON pt.PalabraId = p.Id
WHERE pt.Tag LIKE '%_frmReporte%' 
   OR pt.Tag LIKE '%_frmSer%' 
   OR pt.Tag LIKE '%_frmAyuda%'
   OR pt.Tag LIKE '%_frmStock%'
   OR pt.Tag LIKE '%_frmClientes%'
   OR pt.Tag LIKE '%_frmMenu%'
   OR pt.Tag LIKE '%_frmLogin%'
ORDER BY pt.Tag;

PRINT '============================================='
PRINT 'SIGUIENTE PASO: AGREGAR TAGS A LOS ARCHIVOS DESIGNER.CS'
PRINT '============================================='
PRINT 'EJEMPLO:'
PRINT 'En frmReporteInteligente.Designer.cs:'
PRINT 'this.lblFechaInicio.Tag = "lblFechaInicio_frmReporte";'
PRINT 'this.btnActualizar.Tag = "btnActualizar_frmReporte";'
PRINT ''
PRINT 'En frmSerializacion.Designer.cs:'
PRINT 'this.btnSerializar.Tag = "btnSerializar_frmSer";'
PRINT 'this.lblTipoDato.Tag = "lblTipoDato_frmSer";'
PRINT ''
PRINT 'En frmGestionStockProductos.Designer.cs:'
PRINT 'this.lblTituloProductos.Tag = "lblTituloProductos_frmStock";'
PRINT 'this.btnExportar.Tag = "btnExportar_frmStock";'
PRINT ''
PRINT 'FORMULARIOS CONFIGURADOS EN ESTE SCRIPT:'
PRINT '- frmReporteInteligente (Reportes)'
PRINT '- frmSerializacion (Serialización)'  
PRINT '- frmAyuda (Ayuda en línea)'
PRINT '- frmGestionStockProductos (Gestión de productos)'
PRINT '- frmGestionarClientes (Gestión de clientes)'
PRINT '- frmMenuPrincipal (Menú principal)'
PRINT '- frmInicioSesion (Inicio de sesión)'
PRINT ''
PRINT 'RECUERDA: Solo agregar Tags a controles que muestran TEXTO'
PRINT 'y que necesitan ser traducidos (Labels, Buttons, GroupBoxes, etc.)'
PRINT '============================================='

GO