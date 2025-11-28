# CheeseLogix

## Descripción General
CheeseLogix es un sistema integral de gestión para distribuidoras, diseñado para administrar eficientemente los procesos de compra, venta, control de inventario y devoluciones. El software permite optimizar el flujo de trabajo, asegurando la integridad de los datos y proporcionando herramientas de reporte y auditoría.

## Requisitos del Sistema
- **Sistema Operativo:** Windows 10 o superior.
- **Framework:** .NET Framework 4.7.2.
- **Base de Datos:** SQL Server (2014 o superior recomendado).
- **Hardware:**
  - Procesador: Intel Core i3 o superior (o equivalente AMD).
  - RAM: 4 GB mínimo (8 GB recomendado).
  - Espacio en Disco: 500 MB para la aplicación + espacio para base de datos.

## Funcionamiento Básico
El sistema se divide en módulos principales accesibles desde el menú lateral:

1. **Ventas:**
   - Gestión de clientes.
   - Proceso de venta (Carrito de compras, Cobro).
   - Historial de ventas y devoluciones.
2. **Compras:**
   - Gestión de proveedores.
   - Solicitudes de cotización y Órdenes de compra.
3. **Inventario (Stock):**
   - Control de stock de productos.
   - Ajustes y despacho de mercadería.
4. **Administración:**
   - Gestión de usuarios y permisos.
   - Respaldo y restauración del sistema (Backup/Restore).
   - Bitácora de eventos y control de cambios.

## Instalación
1. Asegúrese de tener los requisitos previos instalados.
2. Restaure la base de datos utilizando los scripts proporcionados en la carpeta `Scripts`.
3. Configure la cadena de conexión en el archivo `App.config` si es necesario.
4. Ejecute el archivo `CheeseLogix.exe`.
