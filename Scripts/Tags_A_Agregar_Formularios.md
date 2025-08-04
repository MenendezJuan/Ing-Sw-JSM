# TAGS A AGREGAR EN FORMULARIOS DESIGNER.CS

## Instrucciones Generales
Después de ejecutar el script SQL `ConfiguracionMultiIdioma_CheeseLogix.sql`, agregar los siguientes Tags en los archivos Designer.cs correspondientes.

**Ubicación:** En la sección `InitializeComponent()` de cada formulario, después de configurar el texto del control.

---

## 1. frmReporteInteligente.Designer.cs

```csharp
// En InitializeComponent(), agregar:
this.lblSeleccionarIdioma.Tag = "lblSeleccionarIdioma_frmReporte";
this.lblFechaInicio.Tag = "lblFechaInicio_frmReporte";
this.lblFechaFin.Tag = "lblFechaFin_frmReporte";
this.btnActualizar.Tag = "btnActualizar_frmReporte";
this.btnCerrar.Tag = "btnCerrar_frmReporte";
this.btnExportarPDF.Tag = "btnExportarPDF_frmReporte";
this.btnExportarExcel.Tag = "btnExportarExcel_frmReporte";
this.groupBoxRecomendaciones.Tag = "groupBoxRecomendaciones_frmReporte";
```

---

## 2. frmSerializacion.Designer.cs

```csharp
// En InitializeComponent(), agregar:
this.groupBoxSerializacion.Tag = "groupBoxSerializacion_frmSer";
this.btnSerializar.Tag = "btnSerializar_frmSer";
this.lblTipoDato.Tag = "lblTipoDato_frmSer";
this.groupBoxDeserializacion.Tag = "groupBoxDeserializacion_frmSer";
this.btnDeserializar.Tag = "btnDeserializar_frmSer";
this.btnGuardarSerializado.Tag = "btnGuardarSerializado_frmSer";
this.btnSalir.Tag = "btnSalir_frmSer";
this.labelIdioma.Tag = "labelIdioma_frmSer";
```

---

## 3. frmAyuda.Designer.cs

**NOTA:** Este formulario ya tiene algunos Tags configurados. Solo agregar los faltantes:

```csharp
// En InitializeComponent(), agregar:
this.btnAbrirCarpeta.Tag = "btnAbrirCarpeta_frmAyuda";
this.btnCerrar.Tag = "btnCerrar_frmAyuda";
// El lblSeleccionarIdioma ya tiene Tag configurado
```

---

## 4. frmGestionStockProductos.Designer.cs

```csharp
// En InitializeComponent(), agregar:
this.lblTituloProductos.Tag = "lblTituloProductos_frmStock";
this.buttonAgregarProductoProveedorSelec.Tag = "buttonAgregarProductoProveedorSelec_frmStock";
this.buttonActualizarProducto.Tag = "buttonActualizarProducto_frmStock";
this.buttonEliminarProducto.Tag = "buttonEliminarProducto_frmStock";
this.label6.Tag = "label6_frmStock";  // Precio Compra
this.label4.Tag = "label4_frmStock";  // Categoría
this.lblSeleccionado.Tag = "lblSeleccionado_frmStock";
this.label3.Tag = "label3_frmStock";  // Descripción
this.btnBorrarIngresoDatos.Tag = "btnBorrarIngresoDatos_frmStock";
this.estadolbl.Tag = "estadolbl_frmStock";  // Nombre
this.btnAceptar.Tag = "btnAceptar_frmStock";
this.lblDatos.Tag = "lblDatos_frmStock";
this.label1.Tag = "label1_frmStock";  // Código
this.labelSeleccionProveedor.Tag = "labelSeleccionProveedor_frmStock";
this.btnBuscar.Tag = "btnBuscar_frmStock";
this.label2.Tag = "label2_frmStock";  // Buscar por:
this.label8.Tag = "label8_frmStock";  // Buscar en la Grilla
this.btnRefresh.Tag = "btnRefresh_frmStock";
this.buttonReactivacionProducto.Tag = "buttonReactivacionProducto_frmStock";
this.btnExportar.Tag = "btnExportar_frmStock";
this.btnReactivarProductos.Tag = "btnReactivarProductos_frmStock";
this.lblSeleccionarIdioma.Tag = "lblSeleccionarIdioma_frmStock";
this.btnCerrar.Tag = "btnCerrar_frmStock";
```

---

## 5. frmGestionarClientes.Designer.cs

```csharp
// En InitializeComponent(), agregar:
this.lblSeleccionarIdioma.Tag = "lblSeleccionarIdioma_frmClientes";
this.btnReactivarCliente.Tag = "btnReactivarCliente_frmClientes";
this.buttonReactivacionCli.Tag = "buttonReactivacionCli_frmClientes";
this.btnBuscar.Tag = "btnBuscar_frmClientes";
this.label2.Tag = "label2_frmClientes";  // Buscar por:
this.label8.Tag = "label8_frmClientes";  // Buscar en la Grilla
this.btnExportar.Tag = "btnExportar_frmClientes";
this.btnRefresh.Tag = "btnRefresh_frmClientes";
this.labelApellido.Tag = "labelApellido_frmClientes";
this.label5.Tag = "label5_frmClientes";  // Mail
this.label4.Tag = "label4_frmClientes";  // Teléfono
this.lblSeleccionado.Tag = "lblSeleccionado_frmClientes";
this.label3.Tag = "label3_frmClientes";  // Direccion
this.lblNombre.Tag = "lblNombre_frmClientes";
this.label1.Tag = "label1_frmClientes";  // CUIT
this.btnBorrarIngresoDatos.Tag = "btnBorrarIngresoDatos_frmClientes";
this.btnAceptar.Tag = "btnAceptar_frmClientes";
this.lblDatos.Tag = "lblDatos_frmClientes";
this.buttonEliminarCliente.Tag = "buttonEliminarCliente_frmClientes";
this.buttonActualizarCliente.Tag = "buttonActualizarCliente_frmClientes";
this.buttonAgregarCliente.Tag = "buttonAgregarCliente_frmClientes";
this.lblTituloClientes.Tag = "lblTituloClientes_frmClientes";
this.btnCerrar.Tag = "btnCerrar_frmClientes";
```

---

## 6. frmMenuPrincipal.Designer.cs

```csharp
// En InitializeComponent(), agregar:
this.lblSeleccionarIdioma.Tag = "lblSeleccionarIdioma_frmMenu";
this.labelUsuario.Tag = "labelUsuario_frmMenu";
this.labelUser.Tag = "labelUser_frmMenu";
this.toolStripMenuItemUsuario.Tag = "toolStripMenuItemUsuario_frmMenu";
this.logOutToolStripMenuItem.Tag = "logOutToolStripMenuItem_frmMenu";
this.toolStripMenuItemAdministracion.Tag = "toolStripMenuItemAdministracion_frmMenu";
this.UsuariosToolStripMenuItem.Tag = "UsuariosToolStripMenuItem_frmMenu";
this.perfilesToolStripMenuItem.Tag = "perfilesToolStripMenuItem_frmMenu";
this.idiomasToolStripMenuItem.Tag = "idiomasToolStripMenuItem_frmMenu";
this.bitacoraToolStripMenuItem.Tag = "bitacoraToolStripMenuItem_frmMenu";
this.toolStripMenuItemAyuda.Tag = "toolStripMenuItemAyuda_frmMenu";
this.btnAdministracion.Tag = "btnAdministracion_frmMenu";
this.btnReportes.Tag = "btnReportes_frmMenu";
this.buttonGestionarProveedores.Tag = "buttonGestionarProveedores_frmMenu";
this.buttonGestionarClientes.Tag = "buttonGestionarClientes_frmMenu";
this.buttonEntidades.Tag = "buttonEntidades_frmMenu";
this.btnCobrarVenta.Tag = "btnCobrarVenta_frmMenu";
this.btnCaja.Tag = "btnCaja_frmMenu";
this.btnDespachoProducto.Tag = "btnDespachoProducto_frmMenu";
this.btnVentas.Tag = "btnVentas_frmMenu";
this.btnComprasProductos.Tag = "btnComprasProductos_frmMenu";
this.btnStockProductos.Tag = "btnStockProductos_frmMenu";
this.btnGestionProducto.Tag = "btnGestionProducto_frmMenu";
this.buttonEvaluarSolicitudes.Tag = "buttonEvaluarSolicitudes_frmMenu";
this.buttonSolicitarCotizacion.Tag = "buttonSolicitarCotizacion_frmMenu";
this.btnControl.Tag = "btnControl_frmMenu";
```

---

## 7. frmInicioSesion.Designer.cs

```csharp
// En InitializeComponent(), agregar:
this.btn_IniciarSesion.Tag = "btn_IniciarSesion_frmLogin";
this.lbl_Email.Tag = "lbl_Email_frmLogin";
this.lbl_Contraseña.Tag = "lbl_Contraseña_frmLogin";
this.lbl_InicioSesion.Tag = "lbl_InicioSesion_frmLogin";
this.lblSeleccionarIdioma.Tag = "lblSeleccionarIdioma_frmLogin";
this.label_Registrarse.Tag = "label_Registrarse_frmLogin";
```

---

## Verificación Post-Implementación

Después de agregar todos los Tags:

1. **Compilar** el proyecto para verificar que no hay errores de sintaxis.
2. **Ejecutar** el script SQL en la base de datos `IngenieriaSoftware`.
3. **Probar** el cambio de idioma en algunos formularios para verificar que funciona.

## Notas Importantes

- **NO agregar Tags** a controles que no muestran texto visible (como TextBoxes de entrada, ComboBoxes, etc.)
- **SÍ agregar Tags** a Labels, Buttons, GroupBoxes, títulos de formularios, etc.
- Los **Tags deben ser únicos** en todo el sistema
- La **nomenclatura** sigue el patrón: `nombreControl_frmFormulario`

## Formularios Adicionales

Si hay más formularios en el sistema, seguir el mismo patrón:
1. Identificar controles con texto
2. Crear Tags únicos siguiendo la nomenclatura
3. Agregar palabras al script SQL si no existen
4. Asociar Tags a palabras en Palabras_Tags