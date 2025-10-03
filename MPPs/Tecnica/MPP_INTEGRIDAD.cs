using Servicios;
using Seguridad;
using System;
using System.Collections.Generic;
using System.Data;

namespace MPPs
{
    /// <summary>
    /// MPP para operaciones de verificación y restauración de integridad
    /// </summary>
    public class MPP_INTEGRIDAD
    {
        private readonly Conexion oCnx = Conexion.Instance;

        /// <summary>
        /// Obtiene todas las entidades de un tipo específico desde la base de datos
        /// </summary>
        public DataTable ObtenerEntidadesPorTipo(string tipoEntidad)
        {
            try
            {
                string consulta = string.Empty;

                switch (tipoEntidad)
                {
                    case "Usuario":
                        consulta = "SELECT Id, Email, Activo, DigitoVerificador FROM Usuarios ORDER BY Id";
                        break;
                    case "Producto":
                        consulta = "SELECT Id, Codigo, Nombre, PrecioVenta, Stock, Estado, DigitoVerificador FROM Producto ORDER BY Id";
                        break;
                    case "Venta":
                        consulta = "SELECT Id, MontoTotal, EstadoVenta, Fecha, DigitoVerificador FROM Venta ORDER BY Id";
                        break;
                    default:
                        throw new ArgumentException($"Tipo de entidad no soportado: {tipoEntidad}");
                }

                return oCnx.LeerConConsulta(consulta, null);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener entidades de tipo {tipoEntidad}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene los dígitos verificadores verticales desde la base de datos
        /// </summary>
        public DataTable ObtenerDigitosVerticales()
        {
            try
            {
                string consulta = "SELECT TipoEntidad, Columna, DigitoVerificador FROM DigitosVerticales";
                return oCnx.LeerConConsulta(consulta, null);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener dígitos verticales: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Restaura el dígito verificador horizontal de una entidad específica
        /// </summary>
        public bool RestaurarDVHorizontal(string tipoEntidad, int entidadId, string nuevoDV)
        {
            try
            {
                string tabla = string.Empty;

                switch (tipoEntidad)
                {
                    case "Usuario":
                        tabla = "Usuarios";
                        break;
                    case "Producto":
                        tabla = "Producto";
                        break;
                    case "Venta":
                        tabla = "Venta";
                        break;
                    default:
                        throw new ArgumentException($"Tipo de entidad no soportado: {tipoEntidad}");
                }

                string consulta = $"UPDATE {tabla} SET DigitoVerificador = '{nuevoDV}' WHERE Id = {entidadId}";
                return oCnx.EjecutarComandoSQL(consulta);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al restaurar DV horizontal para {tipoEntidad} ID {entidadId}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Restaura el dígito verificador vertical para una columna específica
        /// </summary>
        public bool RestaurarDVVertical(string tipoEntidad, string columna, string nuevoDV)
        {
            try
            {
                // Primero verificamos si existe el registro
                string consultaExiste = $"SELECT COUNT(*) FROM DigitosVerticales WHERE TipoEntidad = '{tipoEntidad}' AND Columna = '{columna}'";
                var tablaExiste = oCnx.LeerConConsulta(consultaExiste, null);
                int count = tablaExiste.Rows.Count > 0 ? Convert.ToInt32(tablaExiste.Rows[0][0]) : 0;

                string consulta = string.Empty;

                if (count > 0)
                {
                    // UPDATE si ya existe
                    consulta = $"UPDATE DigitosVerticales SET DigitoVerificador = '{nuevoDV}' " +
                               $"WHERE TipoEntidad = '{tipoEntidad}' AND Columna = '{columna}'";
                }
                else
                {
                    // INSERT si no existe
                    consulta = $"INSERT INTO DigitosVerticales (TipoEntidad, Columna, DigitoVerificador) " +
                               $"VALUES ('{tipoEntidad}', '{columna}', '{nuevoDV}')";
                }

                return oCnx.EjecutarComandoSQL(consulta);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al restaurar DV vertical para {tipoEntidad}.{columna}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene el detalle completo de una entidad por ID
        /// </summary>
        public DataRow ObtenerDetalleEntidad(string tipoEntidad, int entidadId)
        {
            try
            {
                string consulta = string.Empty;

                switch (tipoEntidad)
                {
                    case "Usuario":
                        consulta = $"SELECT * FROM Usuarios WHERE Id = {entidadId}";
                        break;
                    case "Producto":
                        consulta = $"SELECT * FROM Producto WHERE Id = {entidadId}";
                        break;
                    case "Venta":
                        consulta = $"SELECT * FROM Venta WHERE Id = {entidadId}";
                        break;
                    default:
                        throw new ArgumentException($"Tipo de entidad no soportado: {tipoEntidad}");
                }

                var tabla = oCnx.LeerConConsulta(consulta, null);
                
                if (tabla != null && tabla.Rows.Count > 0)
                {
                    return tabla.Rows[0];
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener detalle de {tipoEntidad} ID {entidadId}: {ex.Message}", ex);
            }
        }
    }
}

