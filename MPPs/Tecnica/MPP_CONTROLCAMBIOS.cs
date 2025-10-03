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

        /// <summary>
        /// Obtiene el ID de la entidad desde un registro de historial
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad</param>
        /// <param name="historialId">ID del registro de historial</param>
        /// <returns>ID de la entidad</returns>
        public int ObtenerEntidadIdDesdeHistorial(string tipoEntidad, int historialId)
        {
            try
            {
                string consulta = string.Empty;
                var parametros = new Hashtable();
                parametros.Add("@HistorialId", historialId);

                switch (tipoEntidad.ToUpper())
                {
                    case "USUARIO":
                        consulta = "SELECT UsuarioId FROM Historial_Usuarios WHERE Id = @HistorialId";
                        break;
                    case "PRODUCTO":
                        consulta = "SELECT ProductoId FROM Historial_Productos WHERE Id = @HistorialId";
                        break;
                    case "VENTA":
                        consulta = "SELECT VentaId FROM Historial_Ventas WHERE Id = @HistorialId";
                        break;
                    default:
                        throw new ArgumentException($"Tipo de entidad no soportado: {tipoEntidad}");
                }

                DataTable resultado = oCnx.LeerConConsulta(consulta, parametros);
                
                if (resultado.Rows.Count > 0 && resultado.Rows[0][0] != DBNull.Value)
                {
                    return Convert.ToInt32(resultado.Rows[0][0]);
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener ID de entidad desde historial: {ex.Message}", ex);
            }
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
        /// Obtiene una entidad completa para actualizar su DVH
        /// </summary>
        public DataTable ObtenerEntidadParaActualizar(string tipoEntidad, int entidadId)
        {
            try
            {
                string consulta = string.Empty;
                var parametros = new Hashtable();
                parametros.Add("@Id", entidadId);

                switch (tipoEntidad.ToUpper())
                {
                    case "USUARIO":
                    case "USUARIOS":
                        consulta = "SELECT Id, Email, Contraseña FROM Usuarios WHERE Id = @Id";
                        break;
                    case "PRODUCTO":
                    case "PRODUCTOS":
                        consulta = "SELECT Id, Codigo, CategoriaEnum, Nombre, Descripcion, PrecioCompra, Estado, Fecha FROM Producto WHERE Id = @Id";
                        break;
                    case "VENTA":
                    case "VENTAS":
                        consulta = "SELECT Id, Comentario, MontoTotal, Fecha, TipoPagoEnum, EstadoVenta, ClienteId, UsuarioVendedorId FROM Venta WHERE Id = @Id";
                        break;
                    default:
                        throw new ArgumentException($"Tipo de entidad no soportado: {tipoEntidad}");
                }

                return oCnx.LeerConConsulta(consulta, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener entidad para actualizar: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Actualiza el DVH de una entidad usando consulta SQL directa (no SP)
        /// </summary>
        public bool ActualizarDVHDirecto(string tipoEntidad, int entidadId, string nuevoDVH)
        {
            try
            {
                string consulta = string.Empty;
                var parametros = new Hashtable();
                parametros.Add("@Id", entidadId);
                parametros.Add("@DVH", nuevoDVH);

                switch (tipoEntidad.ToUpper())
                {
                    case "USUARIO":
                    case "USUARIOS":
                        consulta = "UPDATE Usuarios SET DigitoVerificador = @DVH WHERE Id = @Id";
                        break;
                    case "PRODUCTO":
                    case "PRODUCTOS":
                        consulta = "UPDATE Producto SET DigitoVerificador = @DVH WHERE Id = @Id";
                        break;
                    case "VENTA":
                    case "VENTAS":
                        consulta = "UPDATE Venta SET DigitoVerificador = @DVH WHERE Id = @Id";
                        break;
                    default:
                        throw new ArgumentException($"Tipo de entidad no soportado: {tipoEntidad}");
                }

                // Ejecutar UPDATE usando LeerConConsulta (devuelve DataTable vacía si es exitoso)
                DataTable resultado = oCnx.LeerConConsulta(consulta, parametros);
                return true; // Si no lanza excepción, fue exitoso
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar DVH directo: {ex.Message}", ex);
            }
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
                    consulta = "SELECT ISNULL(DigitoVerificador, '') AS DV FROM Usuarios WITH (NOLOCK) WHERE DigitoVerificador IS NOT NULL ORDER BY Id";
                    break;

                case "PRODUCTO":
                    consulta = "SELECT ISNULL(DigitoVerificador, '') AS DV FROM Producto WITH (NOLOCK) WHERE DigitoVerificador IS NOT NULL ORDER BY Id";
                    break;

                case "VENTA":
                    consulta = "SELECT ISNULL(DigitoVerificador, '') AS DV FROM Venta WITH (NOLOCK) WHERE DigitoVerificador IS NOT NULL ORDER BY Id";
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

        /// <summary>
        /// Obtiene el DVV almacenado para un tipo de entidad
        /// </summary>
        /// <param name="tabla">Nombre de la tabla</param>
        /// <returns>DVV almacenado o "-1" si no existe</returns>
        public string ObtenerDigitoVerificadorVerticalAlmacenado(string tabla)
        {
            try
            {
                Hashtable parametros = new Hashtable();
                parametros.Add("@Tabla", tabla);

                DataTable resultado = oCnx.Leer("ListarControlSeguridad", parametros);

                if (resultado.Rows.Count > 0)
                {
                    return resultado.Rows[0]["Digito"].ToString();
                }

                return "-1";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener DVV almacenado para {tabla}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Guarda el DVV para un tipo de entidad
        /// </summary>
        /// <param name="tabla">Nombre de la tabla</param>
        /// <param name="dvv">DVV a guardar</param>
        /// <returns>True si se guardó correctamente</returns>
        public bool GuardarDigitoVerificadorVertical(string tabla, string dvv)
        {
            try
            {
                Hashtable parametros = new Hashtable();
                parametros.Add("@Tabla", tabla);
                parametros.Add("@DVV", dvv);

                return oCnx.Guardar("Guardar_DigitoVertical", parametros);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar DVV para {tabla}: {ex.Message}", ex);
            }
        }

        #endregion Dígito Verificador Vertical
    }
}
