using System;
using System.Data;

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
                string datos = ExtraerDatosParaCalculo(tipoEntidad, row);
                return Seguridad.CalcularDigitoVerificador(datos);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al calcular DV horizontal para {tipoEntidad}: {ex.Message}", ex);
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
                        if (row.Table.Columns.Contains("Email") && row["Email"] != DBNull.Value)
                            datos += row["Email"].ToString();
                        if (row.Table.Columns.Contains("Activo") && row["Activo"] != DBNull.Value)
                            datos += row["Activo"].ToString();
                        break;

                    case "Producto":
                        if (row.Table.Columns.Contains("Codigo") && row["Codigo"] != DBNull.Value)
                            datos += row["Codigo"].ToString();
                        if (row.Table.Columns.Contains("Nombre") && row["Nombre"] != DBNull.Value)
                            datos += row["Nombre"].ToString();
                        if (row.Table.Columns.Contains("PrecioVenta") && row["PrecioVenta"] != DBNull.Value)
                            datos += row["PrecioVenta"].ToString();
                        if (row.Table.Columns.Contains("Stock") && row["Stock"] != DBNull.Value)
                            datos += row["Stock"].ToString();
                        if (row.Table.Columns.Contains("Estado") && row["Estado"] != DBNull.Value)
                            datos += row["Estado"].ToString();
                        break;

                    case "Venta":
                        if (row.Table.Columns.Contains("MontoTotal") && row["MontoTotal"] != DBNull.Value)
                            datos += row["MontoTotal"].ToString();
                        if (row.Table.Columns.Contains("EstadoVenta") && row["EstadoVenta"] != DBNull.Value)
                            datos += row["EstadoVenta"].ToString();
                        if (row.Table.Columns.Contains("Fecha") && row["Fecha"] != DBNull.Value)
                            datos += Convert.ToDateTime(row["Fecha"]).ToString("yyyyMMddHHmmss");
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

                    default:
                        return $"{tipoEntidad} ID: {row["Id"]}";
                }
            }
            catch
            {
                return $"{tipoEntidad} (descripción no disponible)";
            }
        }
    }
}
