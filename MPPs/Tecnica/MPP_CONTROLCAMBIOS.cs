using Servicios;
using System;
using System.Collections;
using System.Data;

namespace MPPs.Tecnica
{
    /// <summary>
    /// MPP para gestión de control de cambios y dígitos verificadores
    /// Respeta la arquitectura de capas accediendo directamente a la base de datos
    /// </summary>
    public class MPP_CONTROLCAMBIOS
    {
        private Conexion oCnx;

        public MPP_CONTROLCAMBIOS()
        {
            oCnx = Conexion.Instance;
        }

        #region Gestión de Historial

        /// <summary>
        /// Obtiene el historial de una entidad específica
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad (Usuario, Producto, Venta)</param>
        /// <param name="entidadId">ID de la entidad (null para obtener todos)</param>
        /// <returns>DataTable con el historial</returns>
        public DataTable ObtenerHistorialEntidad(string tipoEntidad, int? entidadId)
        {
            var parametros = new Hashtable();
            parametros.Add("@TipoEntidad", tipoEntidad);
            parametros.Add("@EntidadId", entidadId.HasValue ? (object)entidadId.Value : DBNull.Value);

            return oCnx.Leer("ListarHistorialEntidad", parametros);
        }

        /// <summary>
        /// Restaura una entidad desde su historial
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad</param>
        /// <param name="historialId">ID del registro de historial</param>
        /// <returns>True si la restauración fue exitosa</returns>
        public bool RestaurarDesdeHistorial(string tipoEntidad, int historialId)
        {
            var parametros = new Hashtable();
            parametros.Add("@TipoEntidad", tipoEntidad);
            parametros.Add("@HistorialId", historialId);

            return oCnx.Guardar("RestaurarDesdeHistorial", parametros);
        }

        #endregion Gestión de Historial

        #region Gestión de Dígitos Verificadores

        /// <summary>
        /// Calcula el dígito verificador de una entidad
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad</param>
        /// <param name="entidadId">ID de la entidad</param>
        /// <returns>DataTable con el dígito verificador calculado</returns>
        public DataTable CalcularDigitoVerificador(string tipoEntidad, int entidadId)
        {
            var parametros = new Hashtable();
            parametros.Add("@TipoEntidad", tipoEntidad);
            parametros.Add("@EntidadId", entidadId);

            return oCnx.Leer("CalcularDigitoVerificadorEntidad", parametros);
        }

        /// <summary>
        /// Actualiza el dígito verificador de una entidad
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad</param>
        /// <param name="entidadId">ID de la entidad</param>
        /// <returns>True si la actualización fue exitosa</returns>
        public bool ActualizarDigitoVerificador(string tipoEntidad, int entidadId)
        {
            var parametros = new Hashtable();
            parametros.Add("@TipoEntidad", tipoEntidad);
            parametros.Add("@EntidadId", entidadId);

            return oCnx.Guardar("ActualizarDigitoVerificadorEntidad", parametros);
        }

        /// <summary>
        /// Obtiene todos los dígitos verificadores de un tipo de entidad para cálculo vertical
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad</param>
        /// <returns>DataTable con todos los DVs</returns>
        public DataTable ObtenerDigitosVerificadoresVerticales(string tipoEntidad)
        {
            string consulta = string.Empty;

            switch (tipoEntidad.ToUpper())
            {
                case "USUARIO":
                    consulta = "SELECT ISNULL(DigitoVerificador, '') AS DV FROM Usuarios WHERE DigitoVerificador IS NOT NULL ORDER BY Id";
                    break;

                case "PRODUCTO":
                    consulta = "SELECT ISNULL(DigitoVerificador, '') AS DV FROM Producto WHERE DigitoVerificador IS NOT NULL ORDER BY Id";
                    break;

                case "VENTA":
                    consulta = "SELECT ISNULL(DigitoVerificador, '') AS DV FROM Venta WHERE DigitoVerificador IS NOT NULL ORDER BY Id";
                    break;

                default:
                    throw new ArgumentException($"Tipo de entidad no soportado: {tipoEntidad}");
            }

            return oCnx.LeerConConsulta(consulta, null);
        }

        /// <summary>
        /// Obtiene estadísticas de integridad para un tipo de entidad
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad</param>
        /// <returns>DataTable con estadísticas</returns>
        public DataTable ObtenerEstadisticasIntegridad(string tipoEntidad)
        {
            string consulta = string.Empty;

            switch (tipoEntidad.ToUpper())
            {
                case "USUARIO":
                    consulta = @"
                        SELECT
                            COUNT(*) AS TotalRegistros,
                            COUNT(DigitoVerificador) AS ConDV,
                            COUNT(*) - COUNT(DigitoVerificador) AS SinDV
                        FROM Usuarios";
                    break;

                case "PRODUCTO":
                    consulta = @"
                        SELECT
                            COUNT(*) AS TotalRegistros,
                            COUNT(DigitoVerificador) AS ConDV,
                            COUNT(*) - COUNT(DigitoVerificador) AS SinDV
                        FROM Producto";
                    break;

                case "VENTA":
                    consulta = @"
                        SELECT
                            COUNT(*) AS TotalRegistros,
                            COUNT(DigitoVerificador) AS ConDV,
                            COUNT(*) - COUNT(DigitoVerificador) AS SinDV
                        FROM Venta";
                    break;

                default:
                    throw new ArgumentException($"Tipo de entidad no soportado: {tipoEntidad}");
            }

            return oCnx.LeerConConsulta(consulta, null);
        }

        #endregion Gestión de Dígitos Verificadores

        #region Verificación de Integridad

        /// <summary>
        /// Registra una inconsistencia de integridad en la bitácora
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad</param>
        /// <param name="entidadId">ID de la entidad</param>
        /// <param name="dvEsperado">DV esperado</param>
        /// <param name="dvActual">DV actual</param>
        /// <param name="usuarioId">ID del usuario (si está disponible)</param>
        /// <returns>True si se registró correctamente</returns>
        public bool RegistrarInconsistenciaIntegridad(string tipoEntidad, int entidadId, string dvEsperado, string dvActual, int? usuarioId = null)
        {
            var parametros = new Hashtable();
            parametros.Add("@Fecha", DateTime.Now);
            parametros.Add("@Accion", 99); // Código especial para inconsistencias de integridad
            parametros.Add("@Usuario", usuarioId ?? 1); // Usuario sistema si no se especifica
            parametros.Add("@Descripcion", $"INCONSISTENCIA DE INTEGRIDAD DETECTADA - {tipoEntidad} ID: {entidadId}. DV Esperado: {dvEsperado}, DV Actual: {dvActual}");

            return oCnx.Guardar("Guardar_Bitacora", parametros);
        }

        /// <summary>
        /// Registra un evento de verificación de integridad exitosa
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad</param>
        /// <param name="totalVerificados">Total de registros verificados</param>
        /// <param name="inconsistenciasEncontradas">Número de inconsistencias encontradas</param>
        /// <param name="usuarioId">ID del usuario</param>
        /// <returns>True si se registró correctamente</returns>
        public bool RegistrarVerificacionIntegridad(string tipoEntidad, int totalVerificados, int inconsistenciasEncontradas, int? usuarioId = null)
        {
            var parametros = new Hashtable();
            parametros.Add("@Fecha", DateTime.Now);
            parametros.Add("@Accion", 98); // Código para verificaciones de integridad
            parametros.Add("@Usuario", usuarioId ?? 1);
            parametros.Add("@Descripcion", $"VERIFICACIÓN DE INTEGRIDAD COMPLETADA - {tipoEntidad}. Total: {totalVerificados}, Inconsistencias: {inconsistenciasEncontradas}");

            return oCnx.Guardar("Guardar_Bitacora", parametros);
        }

        #endregion Verificación de Integridad

        #region Dígito Verificador Vertical

        /// <summary>
        /// Obtiene todos los dígitos verificadores horizontales de un tipo de entidad
        /// (Solo acceso a datos - sin lógica de cálculo)
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad</param>
        /// <returns>DataTable con los DVs horizontales</returns>
        public DataTable ObtenerDigitosVerificadoresHorizontales(string tipoEntidad)
        {
            string consulta = string.Empty;

            switch (tipoEntidad.ToUpper())
            {
                case "USUARIO":
                    consulta = "SELECT ISNULL(DigitoVerificador, '') AS DV FROM Usuarios WHERE DigitoVerificador IS NOT NULL ORDER BY Id";
                    break;

                case "PRODUCTO":
                    consulta = "SELECT ISNULL(DigitoVerificador, '') AS DV FROM Producto WHERE DigitoVerificador IS NOT NULL ORDER BY Id";
                    break;

                case "VENTA":
                    consulta = "SELECT ISNULL(DigitoVerificador, '') AS DV FROM Venta WHERE DigitoVerificador IS NOT NULL ORDER BY Id";
                    break;

                default:
                    throw new ArgumentException($"Tipo de entidad no soportado: {tipoEntidad}");
            }

            return oCnx.LeerConConsulta(consulta, null);
        }

        /// <summary>
        /// Obtiene el dígito verificador almacenado de una entidad
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad</param>
        /// <param name="entidadId">ID de la entidad</param>
        /// <returns>DV almacenado</returns>
        public string ObtenerDigitoVerificadorAlmacenado(string tipoEntidad, int entidadId)
        {
            string consulta = string.Empty;
            var parametros = new Hashtable();
            parametros.Add("@Id", entidadId);

            switch (tipoEntidad.ToUpper())
            {
                case "USUARIO":
                    consulta = "SELECT DigitoVerificador FROM Usuarios WHERE Id = @Id";
                    break;

                case "PRODUCTO":
                    consulta = "SELECT DigitoVerificador FROM Producto WHERE Id = @Id";
                    break;

                case "VENTA":
                    consulta = "SELECT DigitoVerificador FROM Venta WHERE Id = @Id";
                    break;

                default:
                    throw new ArgumentException($"Tipo de entidad no soportado: {tipoEntidad}");
            }

            DataTable resultado = oCnx.LeerConConsulta(consulta, parametros);

            if (resultado.Rows.Count > 0 && resultado.Rows[0]["DigitoVerificador"] != DBNull.Value)
            {
                return resultado.Rows[0]["DigitoVerificador"].ToString();
            }

            return string.Empty;
        }

        #endregion Dígito Verificador Vertical
    }
}