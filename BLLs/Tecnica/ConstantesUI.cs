namespace BLLs.Tecnica
{
    public static class ConstantesUI
    {
        public static class Estados
        {
            public const string Activo = "Activo";
            public const string Inactivo = "Inactivo";
        }

        public static class Titulos
        {
            public const string Error = "Error";
            public const string Informacion = "Información";
            public const string Validacion = "Validación";
            public const string AbrirArchivo = "Abrir Archivo";
            public const string Confirmacion = "Confirmación";
            public const string Exito = "Éxito";
            public const string Advertencia = "Advertencia";
        }

        public static class Mensajes
        {
            public const string NoHayDatosParaExportar = "No hay datos para exportar.";
            public const string ErrorExportacion = "Error al exportar el archivo.";
            public const string DeseaAbrirArchivoExportado = "¿Desea abrir el archivo exportado?";
        }

        public static class Validaciones
        {
            public const string SeleccioneCriterioBusqueda = "Seleccione un criterio de búsqueda.";
            public const string IngreseTextoBusqueda = "Ingrese un texto para buscar.";
            public const string EstadoInvalido = "Estado debe ser 'Activo' o 'Inactivo'.";
            public const string CUITSoloNumeros = "El CUIT debe contener solo números y guiones opcionales.";
            public const string IngreseAlMenos4Cuit = "Ingrese al menos 4 dígitos para buscar por CUIT.";
            public const string CUITNoValido = "El CUIT ingresado no es válido.";
            public const string IngreseAlMenos3Email = "Ingrese al menos 3 caracteres para email.";
            public const string EmailNoValido = "Formato de email no válido.";
            public const string IngreseAlMenos4Telefono = "Ingrese al menos 4 caracteres para teléfono.";
            public const string IngreseAlMenos2 = "Ingrese al menos 2 caracteres para buscar.";
            public const string CategoriaNoValida = "Categoría no válida.";
            public const string CriterioBusquedaNoValido = "Criterio de búsqueda no válido.";
        }

        public static class Plantillas
        {
            public static string Ingrese(string complemento)
            {
                return $"Por favor, ingrese {complemento}.";
            }

            public static string Seleccione(string complemento)
            {
                return $"Por favor, seleccione {complemento}.";
            }

            public static string NoPuedeActualizarInactivo(string entidad)
            {
                return $"No se puede actualizar un {entidad} inactivo.";
            }

            public static string NoHayInactivosParaMostrar(string entidadPlural)
            {
                return $"No hay {entidadPlural} inactivos para mostrar.";
            }

            public static string ConfirmarEliminacion(string entidad)
            {
                return $"¿Estás seguro de que deseas eliminar este {entidad}?";
            }

            public static string EliminadoCorrectamente(string entidad)
            {
                return $"{entidad} eliminado correctamente.";
            }
        }

        public static class Exportacion
        {
            public const string HojaProductos = "Productos";
            public const string HojaClientes = "Clientes";
            public const string HojaProveedores = "Proveedores";
            public const string HojaProductosMasVendidos = "Productos Más Vendidos";
            public const string HojaMejoresClientes = "Mejores Clientes";
            public const string HojaVentasPorMes = "Ventas por Mes";

            public const string TituloProductos = "Información de Productos - CheeseLogix";
            public const string TituloClientes = "Información de Clientes - CheeseLogix";
            public const string TituloProveedores = "Información de Proveedores - CheeseLogix";
            public const string TituloProductosMasVendidos = "📊 PRODUCTOS MÁS VENDIDOS";
            public const string TituloMejoresClientes = "👥 MEJORES CLIENTES";
            public const string TituloVentasPorMes = "📈 VENTAS POR MES";
        }

        public static class Marca
        {
            public const string NombreEmpresa = "CheeseLogix";
            public const string TituloSistema = "Sistema de Gestión Empresarial";
        }
    }
}