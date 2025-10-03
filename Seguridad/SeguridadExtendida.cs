using System;
using System.Data;
using System.IO;
using System.Linq;

namespace Seguridad
{
    /// <summary>
    /// Clase para el cálculo de dígitos verificadores (sin acceso a BD)
    /// </summary>
    public static class SeguridadExtendida
    {
        /// <summary>
        /// Calcula el dígito verificador horizontal para un DataRow según el tipo de entidad
        /// </summary>
        public static string CalcularDVHorizontal(string tipoEntidad, DataRow row)
        {
            try
            {
                object entidad = ConvertirDataRowAEntidad(tipoEntidad, row);

                if (entidad is BEs.Interfaces.IVerificableEntity verificable)
                {
                    string dvhCalculado = CalcularDigitoVerificadorHorizontalOriginal(verificable);
                    
                    // ✅ LOGGING: Guardar DVH completos en archivo para análisis
                    try
                    {
                        string logPath = @"C:\Logs\DVH_Calculados.txt";
                        Directory.CreateDirectory(Path.GetDirectoryName(logPath));
                        
                        int id = row.Table.Columns.Contains("Id") ? Convert.ToInt32(row["Id"]) : 0;
                        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {tipoEntidad} | ID:{id} | DVH:{dvhCalculado}";
                        File.AppendAllText(logPath, logEntry + Environment.NewLine);
                    }
                    catch
                    {
                        // Si falla el logging, continuar sin romper
                    }
                    
                    return dvhCalculado;
                }

                throw new Exception($"La entidad {tipoEntidad} no implementa IVerificableEntity");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al calcular DV horizontal para {tipoEntidad}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Algoritmo ORIGINAL del sistema viejo que funcionaba
        /// Basado en Ing-Software-master/Seguridad/Seguridad.cs líneas 30-56
        /// </summary>
        private static string CalcularDigitoVerificadorHorizontalOriginal(BEs.Interfaces.IVerificableEntity entity)
        {
            Type t = entity.GetType();
            string dvh = string.Empty;
            var props = t.GetProperties();

            foreach (var item in props)
            {
                var atributos = item.GetCustomAttributes(typeof(BEs.Clases.PropiedadVerificable), true);
                var verificable = atributos.FirstOrDefault() as BEs.Clases.PropiedadVerificable;

                int len = 0;
                if (item.Name == "DV") { continue; }
                if (verificable != null)
                {
                    dvh += item.GetValue(entity)?.ToString() ?? "";
                    foreach (char c in dvh)
                    {
                        int asciiValue = (int)c;
                        len += asciiValue;
                    }
                    dvh += len.ToString();
                }
            }

            return Seguridad.CalcularDigitoVerificador(dvh);
        }

        /// <summary>
        /// Convierte un DataRow a una entidad del tipo especificado
        /// </summary>
        private static object ConvertirDataRowAEntidad(string tipoEntidad, DataRow row)
        {
            switch (tipoEntidad)
            {
                case "Usuario":
                case "Usuarios":
                    return new BEs.Usuario
                    {
                        Id = row.Table.Columns.Contains("Id") ? Convert.ToInt32(row["Id"]) : 0,
                        Email = row.Table.Columns.Contains("Email") ? row["Email"]?.ToString() : string.Empty,
                        Contraseña = row.Table.Columns.Contains("Contraseña") ? row["Contraseña"]?.ToString() : string.Empty
                    };

                case "Producto":
                case "Productos":
                    return new BEs.Clases.Negocio.Producto
                    {
                        Id = row.Table.Columns.Contains("Id") ? Convert.ToInt32(row["Id"]) : 0,
                        Codigo = row.Table.Columns.Contains("Codigo") ? row["Codigo"]?.ToString() : string.Empty,
                        CategoriaEnum = row.Table.Columns.Contains("CategoriaEnum") ?
                            (BEs.Clases.Negocio.Categoria)Convert.ToInt32(row["CategoriaEnum"]) :
                            BEs.Clases.Negocio.Categoria.Quesos,
                        Nombre = row.Table.Columns.Contains("Nombre") ? row["Nombre"]?.ToString() : string.Empty,
                        Descripcion = row.Table.Columns.Contains("Descripcion") ? row["Descripcion"]?.ToString() : string.Empty,
                        PrecioCompra = row.Table.Columns.Contains("PrecioCompra") ? Convert.ToDecimal(row["PrecioCompra"]) : 0,
                        Estado = row.Table.Columns.Contains("Estado") && Convert.ToBoolean(row["Estado"]),
                        Fecha = row.Table.Columns.Contains("Fecha") ? Convert.ToDateTime(row["Fecha"]) : DateTime.Now
                    };

                case "Venta":
                case "Ventas":
                    return new BEs.Clases.Negocio.Ventas.Venta
                    {
                        Id = row.Table.Columns.Contains("Id") ? Convert.ToInt32(row["Id"]) : 0,
                        Comentario = row.Table.Columns.Contains("Comentario") ? row["Comentario"]?.ToString() : string.Empty,
                        MontoTotal = row.Table.Columns.Contains("MontoTotal") ? Convert.ToDecimal(row["MontoTotal"]) : 0,
                        Fecha = row.Table.Columns.Contains("Fecha") ? Convert.ToDateTime(row["Fecha"]) : DateTime.Now,
                        TipoPagoEnum = row.Table.Columns.Contains("TipoPagoEnum") && row["TipoPagoEnum"] != DBNull.Value ?
                            (BEs.Clases.Negocio.TipoPago)Convert.ToInt32(row["TipoPagoEnum"]) :
                            BEs.Clases.Negocio.TipoPago.Efectivo,
                        EstadoVentaEnum = row.Table.Columns.Contains("EstadoVenta") && row["EstadoVenta"] != DBNull.Value ?
                            (BEs.Clases.Negocio.Enums.EstadoVenta)Convert.ToInt32(row["EstadoVenta"]) :
                            BEs.Clases.Negocio.Enums.EstadoVenta.EnProceso,
                        ClienteId = row.Table.Columns.Contains("ClienteId") && row["ClienteId"] != DBNull.Value ?
                            Convert.ToInt32(row["ClienteId"]) :
                            (int?)null,
                        UsuarioVendedorId = row.Table.Columns.Contains("UsuarioVendedorId") && row["UsuarioVendedorId"] != DBNull.Value ?
                            Convert.ToInt32(row["UsuarioVendedorId"]) :
                            (int?)null
                    };

                default:
                    throw new ArgumentException($"Tipo de entidad no soportado: {tipoEntidad}");
            }
        }


        /// <summary>
        /// Calcula el dígito verificador vertical para una columna específica
        /// </summary>
        public static string CalcularDVVertical(DataTable tabla, string nombreColumna)
        {
            try
            {
                if (tabla == null || tabla.Rows.Count == 0)
                    return string.Empty;

                string datosColumna = string.Empty;

                foreach (DataRow row in tabla.Rows)
                {
                    if (tabla.Columns.Contains(nombreColumna) && row[nombreColumna] != DBNull.Value)
                    {
                        datosColumna += row[nombreColumna].ToString();
                    }
                }

                return Seguridad.CalcularDigitoVerificador(datosColumna);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al calcular DV vertical para columna {nombreColumna}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Extrae los datos relevantes de un DataRow según el tipo de entidad para calcular el DV
        /// </summary>
        private static string ExtraerDatosParaCalculo(string tipoEntidad, DataRow row)
        {
            string datos = string.Empty;

            try
            {
                switch (tipoEntidad)
                {
                    case "Usuario":
                        // SQL: Email + Contraseña
                        if (row.Table.Columns.Contains("Email") && row["Email"] != DBNull.Value)
                            datos += row["Email"].ToString();
                        if (row.Table.Columns.Contains("Contraseña") && row["Contraseña"] != DBNull.Value)
                            datos += row["Contraseña"].ToString();
                        break;

                    case "Producto":
                        // SQL: Codigo + CategoriaEnum + Nombre + Descripcion + PrecioCompra + Estado + Fecha
                        if (row.Table.Columns.Contains("Codigo") && row["Codigo"] != DBNull.Value)
                            datos += row["Codigo"].ToString();
                        if (row.Table.Columns.Contains("CategoriaEnum") && row["CategoriaEnum"] != DBNull.Value)
                            datos += row["CategoriaEnum"].ToString();
                        if (row.Table.Columns.Contains("Nombre") && row["Nombre"] != DBNull.Value)
                            datos += row["Nombre"].ToString();
                        if (row.Table.Columns.Contains("Descripcion") && row["Descripcion"] != DBNull.Value)
                            datos += row["Descripcion"].ToString();
                        if (row.Table.Columns.Contains("PrecioCompra") && row["PrecioCompra"] != DBNull.Value)
                            datos += row["PrecioCompra"].ToString();
                        if (row.Table.Columns.Contains("Estado") && row["Estado"] != DBNull.Value)
                            datos += row["Estado"].ToString();
                        if (row.Table.Columns.Contains("Fecha") && row["Fecha"] != DBNull.Value)
                            datos += Convert.ToDateTime(row["Fecha"]).ToString("yyyy-MM-dd HH:mm:ss.fff"); // Formato 121 de SQL
                        break;

                    case "Venta":
                        // SQL: MontoTotal + Fecha + TipoPagoEnum + ClienteId + EstadoVenta + UsuarioVendedorId
                        if (row.Table.Columns.Contains("MontoTotal") && row["MontoTotal"] != DBNull.Value)
                            datos += row["MontoTotal"].ToString();
                        if (row.Table.Columns.Contains("Fecha") && row["Fecha"] != DBNull.Value)
                            datos += Convert.ToDateTime(row["Fecha"]).ToString("yyyy-MM-dd HH:mm:ss.fff"); // Formato 121 de SQL
                        if (row.Table.Columns.Contains("TipoPagoEnum") && row["TipoPagoEnum"] != DBNull.Value)
                            datos += row["TipoPagoEnum"].ToString();
                        if (row.Table.Columns.Contains("ClienteId") && row["ClienteId"] != DBNull.Value)
                            datos += row["ClienteId"].ToString();
                        if (row.Table.Columns.Contains("EstadoVenta") && row["EstadoVenta"] != DBNull.Value)
                            datos += row["EstadoVenta"].ToString();
                        if (row.Table.Columns.Contains("UsuarioVendedorId") && row["UsuarioVendedorId"] != DBNull.Value)
                            datos += row["UsuarioVendedorId"].ToString();
                        break;

                    default:
                        throw new ArgumentException($"Tipo de entidad no soportado: {tipoEntidad}");
                }

                return datos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al extraer datos de {tipoEntidad}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene una descripción legible de una entidad a partir de su DataRow
        /// </summary>
        public static string ObtenerDescripcionEntidad(string tipoEntidad, DataRow row)
        {
            try
            {
                switch (tipoEntidad)
                {
                    case "Usuario":
                        string email = row.Table.Columns.Contains("Email") && row["Email"] != DBNull.Value
                            ? row["Email"].ToString()
                            : "Sin email";
                        return $"Usuario: {email}";

                    case "Producto":
                        string codigo = row.Table.Columns.Contains("Codigo") && row["Codigo"] != DBNull.Value
                            ? row["Codigo"].ToString()
                            : "Sin código";
                        string nombre = row.Table.Columns.Contains("Nombre") && row["Nombre"] != DBNull.Value
                            ? row["Nombre"].ToString()
                            : "Sin nombre";
                        return $"Producto: {codigo} - {nombre}";

                    case "Venta":
                        string monto = row.Table.Columns.Contains("MontoTotal") && row["MontoTotal"] != DBNull.Value
                            ? Convert.ToDecimal(row["MontoTotal"]).ToString("C")
                            : "$0";
                        string fecha = row.Table.Columns.Contains("Fecha") && row["Fecha"] != DBNull.Value
                            ? Convert.ToDateTime(row["Fecha"]).ToString("dd/MM/yyyy")
                            : "Sin fecha";
                        return $"Venta: {monto} - {fecha}";

                    case "Sistema":
                        return "Error crítico del sistema";

                    default:
                        return $"{tipoEntidad} ID: {(row?.Table?.Columns?.Contains("Id") == true ? row["Id"] : "N/A")}";
                }
            }
            catch
            {
                return $"{tipoEntidad} (descripción no disponible)";
            }
        }
    }
}
