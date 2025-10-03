using MPPs.Tecnica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLLs.Tecnica
{
    /// <summary>
    /// BLL genérica para gestión de control de cambios y dígitos verificadores
    /// Maneja múltiples tipos de entidades de forma parametrizable
    /// </summary>
    public class BLL_CONTROLCAMBIOS
    {
        private readonly MPP_CONTROLCAMBIOS _mppControlCambios;

        public BLL_CONTROLCAMBIOS()
        {
            _mppControlCambios = new MPP_CONTROLCAMBIOS();
        }

        #region Gestión de Historial

        /// <summary>
        /// Obtiene el historial completo de una entidad específica
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad (Usuario, Producto, Venta)</param>
        /// <param name="entidadId">ID de la entidad</param>
        /// <returns>DataTable con el historial</returns>
        public DataTable ObtenerHistorialEntidad(string tipoEntidad, int entidadId)
        {
            try
            {
                return _mppControlCambios.ObtenerHistorialEntidad(tipoEntidad, entidadId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener historial de {tipoEntidad}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene el historial completo de un tipo de entidad
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad (Usuario, Producto, Venta)</param>
        /// <returns>DataTable con todos los historiales del tipo</returns>
        public DataTable ObtenerHistorialTipoEntidad(string tipoEntidad)
        {
            try
            {
                return _mppControlCambios.ObtenerHistorialEntidad(tipoEntidad, null);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener historial completo de {tipoEntidad}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Restaura una entidad desde su historial
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad (Usuario, Producto, Venta)</param>
        /// <param name="historialId">ID del registro de historial</param>
        /// <returns>True si la restauración fue exitosa</returns>
        public bool RestaurarDesdeHistorial(string tipoEntidad, int historialId)
        {
            try
            {
                if (tipoEntidad.Equals("Venta", StringComparison.OrdinalIgnoreCase))
                {
                    RevertirTransicionesDeStockAntesDeRestaurarVenta(historialId);
                }

                bool resultado = _mppControlCambios.RestaurarDesdeHistorial(tipoEntidad, historialId);

                if (resultado)
                {
                    RecalcularDVHDespuesDeRestaurar(tipoEntidad, historialId);
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al restaurar {tipoEntidad} desde historial: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Recalcula los DVH usando el algoritmo C# original después de una restauración
        /// </summary>
        private void RecalcularDVHDespuesDeRestaurar(string tipoEntidad, int historialId)
        {
            try
            {
                int entidadId = _mppControlCambios.ObtenerEntidadIdDesdeHistorial(tipoEntidad, historialId);

                if (entidadId > 0)
                {
                    bool dvhActualizado = ActualizarDigitoVerificador(tipoEntidad, entidadId);

                    if (dvhActualizado)
                    {
                        System.Diagnostics.Debug.WriteLine($"✓ DVH recalculado correctamente para {tipoEntidad} ID {entidadId}");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"⚠ No se pudo recalcular DVH para {tipoEntidad} ID {entidadId}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"⚠ Error al recalcular DVH después de restaurar: {ex.Message}");
            }
        }

        /// <summary>
        /// Revierte las transiciones de stock cuando se restaura una venta a un estado anterior
        /// IMPORTANTE: Este método se ejecuta ANTES de llamar al SP que restaura los datos
        /// </summary>
        private void RevertirTransicionesDeStockAntesDeRestaurarVenta(int historialId)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"✓ Preparando restauración de venta desde historial ID: {historialId}");
                System.Diagnostics.Debug.WriteLine($"  El SP manejará automáticamente las transiciones de stock");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"✗ Error al preparar restauración: {ex.Message}");
                throw new Exception($"Error al preparar la restauración de la venta: {ex.Message}", ex);
            }
        }

        #endregion Gestión de Historial

        #region Gestión de Dígitos Verificadores

        /// <summary>
        /// Calcula el dígito verificador de una entidad específica
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad (Usuario, Producto, Venta)</param>
        /// <param name="entidadId">ID de la entidad</param>
        /// <returns>Dígito verificador calculado</returns>
        public string CalcularDigitoVerificador(string tipoEntidad, int entidadId)
        {
            try
            {
                DataTable resultado = _mppControlCambios.CalcularDigitoVerificador(tipoEntidad, entidadId);

                if (resultado.Rows.Count > 0)
                {
                    return resultado.Rows[0]["DigitoVerificador"].ToString();
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al calcular dígito verificador para {tipoEntidad}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Actualiza el dígito verificador de una entidad Y el DVV de la tabla
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad (Usuario, Producto, Venta)</param>
        /// <param name="entidadId">ID de la entidad</param>
        /// <returns>True si la actualización fue exitosa</returns>
        public bool ActualizarDigitoVerificador(string tipoEntidad, int entidadId)
        {
            try
            {
                bool dvhActualizado = ActualizarDVHConAlgoritmoOriginal(tipoEntidad, entidadId);

                if (dvhActualizado)
                {
                    // 2. Recalcular y actualizar DVV de toda la tabla
                    string dvvCalculado = CalcularDigitoVerificadorVertical(tipoEntidad);
                    string nombreTabla = ConvertirNombreEntidadATabla(tipoEntidad);
                    bool dvvActualizado = _mppControlCambios.GuardarDigitoVerificadorVertical(nombreTabla, dvvCalculado);

                    System.Diagnostics.Debug.WriteLine($"DVH actualizado para {tipoEntidad} ID:{entidadId}, DVV actualizado: {dvvActualizado}");
                    return dvvActualizado;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar dígito verificador para {tipoEntidad}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Actualiza el DVH de una entidad usando el algoritmo C# original (no SQL)
        /// </summary>
        private bool ActualizarDVHConAlgoritmoOriginal(string tipoEntidad, int entidadId)
        {
            try
            {
                // 1. Obtener la entidad desde la BD
                DataTable tabla = _mppControlCambios.ObtenerEntidadParaActualizar(tipoEntidad, entidadId);

                if (tabla != null && tabla.Rows.Count > 0)
                {
                    DataRow row = tabla.Rows[0];

                    // 2. Calcular DVH usando el algoritmo C# original
                    string dvhNuevo = Seguridad.SeguridadExtendida.CalcularDVHorizontal(tipoEntidad, row);

                    // 3. Actualizar en la BD usando consulta directa (no SP)
                    return _mppControlCambios.ActualizarDVHDirecto(tipoEntidad, entidadId, dvhNuevo);
                }

                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al actualizar DVH con algoritmo original: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifica la integridad de una entidad comparando su dígito verificador
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad (Usuario, Producto, Venta)</param>
        /// <param name="entidadId">ID de la entidad</param>
        /// <returns>True si la integridad es correcta</returns>
        public bool VerificarIntegridad(string tipoEntidad, int entidadId)
        {
            try
            {
                // Obtener DV almacenado
                string dvAlmacenado = ObtenerDigitoVerificadorAlmacenado(tipoEntidad, entidadId);

                // Calcular DV actual
                string dvCalculado = CalcularDigitoVerificador(tipoEntidad, entidadId);

                // Comparar
                return dvAlmacenado.Equals(dvCalculado, StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al verificar integridad de {tipoEntidad}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene el dígito verificador almacenado de una entidad
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad</param>
        /// <param name="entidadId">ID de la entidad</param>
        /// <returns>Dígito verificador almacenado</returns>
        private string ObtenerDigitoVerificadorAlmacenado(string tipoEntidad, int entidadId)
        {
            try
            {
                return _mppControlCambios.ObtenerDigitoVerificadorAlmacenado(tipoEntidad, entidadId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener DV almacenado de {tipoEntidad}: {ex.Message}", ex);
            }
        }

        #endregion Gestión de Dígitos Verificadores

        #region Dígito Verificador Vertical (DVV)

        /// <summary>
        /// Calcula el dígito verificador vertical para todas las entidades de un tipo
        /// Concatena todos los DV horizontales y genera un hash maestro
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad (Usuario, Producto, Venta)</param>
        /// <returns>Dígito verificador vertical</returns>
        public string CalcularDigitoVerificadorVertical(string tipoEntidad)
        {
            try
            {
                // 1. Obtener todos los DVs horizontales de la BD (solo datos)
                DataTable digitosHorizontales = _mppControlCambios.ObtenerDigitosVerificadoresHorizontales(tipoEntidad);

                // 2. BLL maneja la lógica de concatenación
                string concatenacion = string.Empty;
                foreach (DataRow row in digitosHorizontales.Rows)
                {
                    concatenacion += row["DV"].ToString();
                }

                // 3. BLL maneja el cálculo del hash usando Seguridad
                if (!string.IsNullOrEmpty(concatenacion))
                {
                    return Seguridad.Seguridad.Hash(concatenacion);
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al calcular DVV para {tipoEntidad}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Verifica la integridad vertical de un tipo de entidad
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad</param>
        /// <param name="dvvAlmacenado">DVV almacenado para comparar</param>
        /// <returns>True si la integridad vertical es correcta</returns>
        public bool VerificarIntegridadVertical(string tipoEntidad, string dvvAlmacenado)
        {
            try
            {
                string dvvCalculado = CalcularDigitoVerificadorVertical(tipoEntidad);
                return dvvAlmacenado.Equals(dvvCalculado, StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al verificar integridad vertical de {tipoEntidad}: {ex.Message}", ex);
            }
        }



        #endregion Dígito Verificador Vertical (DVV)

        #region Métodos de Utilidad

        /// <summary>
        /// Obtiene lista de tipos de entidades soportados
        /// </summary>
        /// <returns>Lista de tipos de entidades</returns>
        public List<string> ObtenerTiposEntidadesSoportados()
        {
            return new List<string> { "Usuario", "Producto", "Venta" };
        }

        /// <summary>
        /// Valida si un tipo de entidad es soportado
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad a validar</param>
        /// <returns>True si es soportado</returns>
        public bool EsTipoEntidadSoportado(string tipoEntidad)
        {
            var tiposSoportados = ObtenerTiposEntidadesSoportados();
            return tiposSoportados.Any(t => t.Equals(tipoEntidad, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Obtiene estadísticas de integridad para un tipo de entidad
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad</param>
        /// <returns>Información de integridad</returns>
        public Dictionary<string, object> ObtenerEstadisticasIntegridad(string tipoEntidad)
        {
            try
            {
                var estadisticas = new Dictionary<string, object>();
                DataTable resultado = _mppControlCambios.ObtenerEstadisticasIntegridad(tipoEntidad);

                if (resultado.Rows.Count > 0)
                {
                    var row = resultado.Rows[0];
                    estadisticas["TipoEntidad"] = tipoEntidad;
                    estadisticas["TotalRegistros"] = Convert.ToInt32(row["TotalRegistros"]);
                    estadisticas["ConDigitoVerificador"] = Convert.ToInt32(row["ConDV"]);
                    estadisticas["SinDigitoVerificador"] = Convert.ToInt32(row["SinDV"]);
                    estadisticas["PorcentajeIntegridad"] =
                        estadisticas["TotalRegistros"].ToString() != "0"
                            ? Math.Round((double)estadisticas["ConDigitoVerificador"] / (double)estadisticas["TotalRegistros"] * 100, 2)
                            : 0.0;
                }

                return estadisticas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener estadísticas de {tipoEntidad}: {ex.Message}", ex);
            }
        }

        #endregion Métodos de Utilidad

        #region Verificación Global de Seguridad

        /// <summary>
        /// Verifica la integridad de TODAS las tablas controladas al iniciar la aplicación
        /// SOLO verifica consistencia
        /// </summary>
        public void VerificarSeguridadGlobal()
        {
            try
            {
                var tablasControladas = new List<string> { "Usuario", "Producto", "Venta" };
                var errores = new List<string>();

                foreach (string tabla in tablasControladas)
                {
                    try
                    {
                        // 1. Calcular DVV actual de la tabla
                        string dvvCalculado = CalcularDigitoVerificadorVertical(tabla);

                        // 2. Obtener DVV almacenado
                        string nombreTabla = ConvertirNombreEntidadATabla(tabla);
                        string dvvAlmacenado = _mppControlCambios.ObtenerDigitoVerificadorVerticalAlmacenado(nombreTabla);

                        // 3. Verificar que existe DVV
                        if (string.IsNullOrEmpty(dvvAlmacenado) || dvvAlmacenado == "-1")
                        {
                            errores.Add($"TABLA {tabla}: No tiene DVV configurado en ControlSeguridad");
                        }
                        // 4. Verificar consistencia
                        else if (!dvvCalculado.Equals(dvvAlmacenado, StringComparison.OrdinalIgnoreCase))
                        {
                            errores.Add($"TABLA {tabla}: DVV_Calculado({dvvCalculado}) != DVV_Almacenado({dvvAlmacenado})");
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine($"DVV OK para {tabla}: {dvvCalculado}");
                        }
                    }
                    catch (Exception ex)
                    {
                        errores.Add($"ERROR en tabla {tabla}: {ex.Message}");
                    }
                }

                // Si hay errores, lanzar excepción detallada
                if (errores.Count > 0)
                {
                    string mensajeError = "La base de datos fue comprometida. Detalles:\n" + string.Join("\n", errores);
                    throw new Exception(mensajeError);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en verificación global de seguridad: {ex.Message}", ex);
            }
        }



        /// <summary>
        /// Convierte nombre de entidad a nombre de tabla
        /// </summary>
        /// <param name="entidad">Nombre de entidad (Usuario, Producto, Venta)</param>
        /// <returns>Nombre de tabla (Usuarios, Productos, Ventas)</returns>
        private string ConvertirNombreEntidadATabla(string entidad)
        {
            switch (entidad.ToUpper())
            {
                case "USUARIO":
                    return "Usuarios";
                case "PRODUCTO":
                    return "Productos";
                case "VENTA":
                    return "Ventas";
                default:
                    return entidad;
            }
        }

        /// <summary>
        /// Verifica la integridad de forma silenciosa (sin lanzar excepciones)
        /// Para usar en validaciones periódicas del sistema
        /// </summary>
        /// <returns>True si todo está correcto, False si hay inconsistencias</returns>
        public bool VerificarIntegridadSilenciosa()
        {
            try
            {
                var tablasControladas = new List<string> { "Usuario", "Producto", "Venta" };
                var inconsistencias = new List<string>();

                foreach (string tabla in tablasControladas)
                {
                    try
                    {
                        string dvvCalculado = CalcularDigitoVerificadorVertical(tabla);
                        string nombreTabla = ConvertirNombreEntidadATabla(tabla);
                        string dvvAlmacenado = _mppControlCambios.ObtenerDigitoVerificadorVerticalAlmacenado(nombreTabla);

                        if (!string.IsNullOrEmpty(dvvAlmacenado) &&
                            dvvAlmacenado != "-1" &&
                            !dvvCalculado.Equals(dvvAlmacenado, StringComparison.OrdinalIgnoreCase))
                        {
                            inconsistencias.Add($"{tabla}: Calculado({dvvCalculado}) != Almacenado({dvvAlmacenado})");
                        }
                    }
                    catch (Exception ex)
                    {
                        inconsistencias.Add($"{tabla}: Error - {ex.Message}");
                    }
                }

                if (inconsistencias.Count > 0)
                {
                    // Log para debugging
                    System.Diagnostics.Debug.WriteLine("INCONSISTENCIAS DETECTADAS:");
                    foreach (string inconsistencia in inconsistencias)
                    {
                        System.Diagnostics.Debug.WriteLine($"  - {inconsistencia}");
                    }
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en verificación silenciosa: {ex.Message}");
                return false;
            }
        }

        #endregion Verificación Global de Seguridad
    }
}