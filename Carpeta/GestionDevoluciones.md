# GESTIÓN DE DEVOLUCIONES - PROCESO PASO A PASO

## DETALLE DEL PROCESO

### 1. INICIAR DEVOLUCIÓN (Encargado de Ventas/Vendedor)

1. El vendedor accede a la sección **Gestión de Devoluciones** desde el menú principal de Ventas.

2. El sistema mostrará un listado de todas las devoluciones existentes con sus estados actuales:
   - **Nro. Devolución**
   - **Fecha Solicitud**
   - **Cliente**
   - **Nro. Venta**
   - **Estado** (Iniciada, En Evaluación, Autorizada, Rechazada, Procesada)

3. Para iniciar una nueva devolución, el vendedor debe hacer clic en el botón **"Nueva Devolución"**.

4. El sistema mostrará un formulario donde el vendedor debe:
   - **Seleccionar una venta** de un listado desplegable que muestra solo las ventas que:
     - Están en estado "Entregada"
     - No tienen una devolución ya iniciada (independientemente del estado)
     - Cumplen con el plazo de 15 días desde la fecha de venta
   
5. Una vez seleccionada la venta, el sistema cargará automáticamente los productos de esa venta en una grilla con las siguientes columnas:
   - **Producto**: Nombre del producto
   - **Vendida**: Cantidad originalmente vendida
   - **Ya Devuelta**: Cantidad ya devuelta en devoluciones anteriores
   - **A Devolver**: Campo editable donde el vendedor ingresa la cantidad a devolver (debe ser ≤ Vendida - Ya Devuelta)
   - **Unidad**: Unidad de medida del producto

6. El vendedor debe:
   - Seleccionar los productos a devolver y especificar la cantidad en la columna "A Devolver"
   - Completar el campo **"Motivo de la Devolución"** con la razón por la cual el cliente solicita la devolución

7. El sistema validará que:
   - La cantidad a devolver no supere la cantidad disponible (Vendida - Ya Devuelta)
   - Se haya seleccionado al menos un producto
   - Se haya completado el motivo de la devolución
   - La venta esté dentro del plazo de 15 días desde la fecha de venta

8. Al hacer clic en **"Guardar"**, el sistema:
   - Creará la devolución con estado **"Iniciada"**
   - Registrará los detalles de productos a devolver
   - Actualizará los dígitos verificadores (DVH/DVV) para mantener la integridad de los datos
   - Registrará el evento en la bitácora del sistema

---

### 2. EVALUAR DEVOLUCIÓN (Gerente)

1. El gerente accede a la sección **Gestión de Devoluciones** desde el menú principal.

2. El sistema mostrará el listado de devoluciones. El gerente puede filtrar por:
   - Cliente
   - Nro. Venta
   - Estado

3. Para evaluar una devolución, el gerente debe:
   - Seleccionar una devolución con estado **"Iniciada"** o **"En Evaluación"**
   - Hacer clic en el botón **"Evaluar"** o hacer doble clic en la fila de la devolución

4. Si la devolución está en estado **"Iniciada"**, el sistema automáticamente la cambiará a estado **"En Evaluación"** al abrir el formulario de evaluación.

5. El formulario de evaluación mostrará:
   - **Información de la Venta**: Número de venta y cliente asociado
   - **Estado Actual**: Estado de la devolución
   - **Motivo de la Devolución**: Motivo ingresado por el vendedor
   - **Detalles de Productos**: Grilla con los productos y cantidades solicitadas para devolución
   - **Observaciones del Gerente**: Campo de texto donde el gerente debe ingresar sus observaciones

6. El gerente debe revisar:
   - La validez de la solicitud de devolución
   - Los productos y cantidades solicitadas
   - El motivo proporcionado por el cliente

7. El gerente puede tomar una de las siguientes decisiones:
   - **Aprobar la Devolución**: Hacer clic en el botón **"Autorizar"**
     - El sistema cambiará el estado a **"Autorizada"**
     - Registrará la fecha de decisión, usuario gerente y observaciones
     - La devolución quedará disponible para ser procesada por el depósito
   
   - **Rechazar la Devolución**: Hacer clic en el botón **"Rechazar"**
     - El sistema cambiará el estado a **"Rechazada"**
     - Registrará la fecha de decisión, usuario gerente y observaciones
     - La devolución finalizará su proceso y no podrá ser procesada

8. Al autorizar o rechazar, el sistema:
   - Actualizará el estado de la devolución
   - Registrará la fecha y hora de la decisión
   - Guardará las observaciones del gerente
   - Actualizará los dígitos verificadores (DVH/DVV)
   - Registrará el evento en la bitácora del sistema

---

### 3. PROCESAR DEVOLUCIÓN (Encargado de Depósito)

1. El encargado de depósito accede a la sección **Gestión de Devoluciones** desde el menú principal.

2. El sistema mostrará el listado de devoluciones. El encargado puede filtrar para ver solo las devoluciones **"Autorizadas"**.

3. Para procesar una devolución autorizada, el encargado debe:
   - Seleccionar una devolución con estado **"Autorizada"**
   - Hacer clic en el botón **"Procesar"** o hacer doble clic en la fila de la devolución

4. El formulario de procesamiento mostrará:
   - **Información de la Venta**: Número de venta y cliente asociado
   - **Estado Actual**: "Autorizada"
   - **Motivo de la Devolución**: Motivo ingresado por el vendedor
   - **Observaciones del Gerente**: Observaciones ingresadas por el gerente al autorizar
   - **Detalles de Productos**: Grilla con los productos y cantidades a devolver
   - **Observaciones del Depósito**: Campo de texto obligatorio donde el encargado debe ingresar las observaciones sobre el estado de los productos recibidos

5. El sistema validará que:
   - La devolución esté en estado "Autorizada"
   - Haya suficiente stock disponible para los productos de reemplazo (si aplica)
   - Se hayan completado las observaciones del depósito

6. El encargado de depósito debe:
   - Revisar los productos devueltos
   - Verificar que los productos de reemplazo estén en buenas condiciones
   - Completar el campo **"Observaciones del Depósito"** con información relevante sobre el estado de los productos

7. Una vez completadas las observaciones, el encargado debe hacer clic en el botón **"Firmar Conforme"**.

8. El sistema mostrará un mensaje de confirmación preguntando:
   - *"¿Confirma que los productos de reemplazo están en buenas condiciones y han sido entregados al cliente?"*

9. Al confirmar, el sistema:
   - Cambiará el estado de la devolución a **"Procesada"**
   - Generará un archivo TXT de conformidad con la siguiente información:
     - Número de Devolución
     - Información de la Venta asociada
     - Cliente
     - Productos y cantidades devueltas
     - Usuario del depósito que procesó
     - Fecha y hora de procesamiento
   - El archivo se guardará en: `C:\CheeseLogix\FirmadoConforme\Conforme_Devolucion_{Id}_{yyyyMMddHHmm}.txt`
   - Actualizará el stock de productos (si aplica)
   - Actualizará los dígitos verificadores (DVH/DVV)
   - Registrará el evento en la bitácora del sistema
   - Mostrará un mensaje con la ruta completa del archivo generado
   - Cerrará el formulario automáticamente

---

## ESTADOS DE LA DEVOLUCIÓN

El sistema maneja los siguientes estados para las devoluciones:

1. **Iniciada**: La devolución ha sido creada por el vendedor y está pendiente de evaluación.

2. **En Evaluación**: La devolución está siendo revisada por el gerente.

3. **Autorizada**: El gerente ha aprobado la devolución y está lista para ser procesada por el depósito.

4. **Rechazada**: El gerente ha rechazado la devolución. El proceso finaliza aquí.

5. **Procesada**: El depósito ha completado el proceso de devolución. El proceso finaliza aquí.

---

## VALIDACIONES DEL SISTEMA

### Validaciones al Iniciar Devolución:
- La venta debe estar en estado "Entregada"
- No debe existir una devolución previa para la misma venta
- La fecha de solicitud debe estar dentro de los 15 días desde la fecha de venta
- La cantidad a devolver no puede superar la cantidad vendida menos la cantidad ya devuelta
- Debe seleccionarse al menos un producto
- Debe completarse el motivo de la devolución

### Validaciones al Evaluar:
- Solo se pueden evaluar devoluciones en estado "Iniciada" o "En Evaluación"
- Deben completarse las observaciones del gerente antes de autorizar o rechazar

### Validaciones al Procesar:
- Solo se pueden procesar devoluciones en estado "Autorizada"
- Debe haber suficiente stock disponible para productos de reemplazo
- Deben completarse las observaciones del depósito antes de firmar conforme

---

## REGISTROS Y TRAZABILIDAD

El sistema registra automáticamente:

- **Bitácora**: Todos los eventos importantes (Iniciar, Autorizar, Rechazar, Procesar)
- **Dígitos Verificadores**: Mantiene la integridad de los datos mediante DVH (Dígito Verificador Horizontal) y DVV (Dígito Verificador Vertical)
- **Archivo de Conformidad**: Genera un archivo TXT con toda la información de la devolución procesada
- **Fechas y Usuarios**: Registra quién y cuándo realizó cada acción en el proceso

---

## PERMISOS REQUERIDOS

- **Button_NuevaDevolucion_GesDev**: Permite iniciar nuevas devoluciones (Vendedor)
- **Button_EvaluarDevolucion_GesDev**: Permite evaluar devoluciones (Gerente)
- **Button_ProcesarDevolucion_GesDev**: Permite procesar devoluciones autorizadas (Encargado de Depósito)

---

## NOTAS IMPORTANTES

1. Una vez que una venta tiene una devolución iniciada (en cualquier estado), no podrá aparecer nuevamente en el listado de ventas disponibles para nuevas devoluciones.

2. El sistema permite múltiples productos por devolución, cada uno con su cantidad específica.

3. El proceso de devolución es secuencial: debe pasar por todos los estados en orden (Iniciada → En Evaluación → Autorizada → Procesada).

4. Una devolución rechazada o procesada no puede modificarse ni revertirse.

5. El archivo de conformidad se genera automáticamente al procesar la devolución y contiene toda la información necesaria para auditoría.

