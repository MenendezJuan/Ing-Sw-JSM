using MPPs.Tecnica;
using Servicios;
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
                return _mppControlCambios.RestaurarDesdeHistorial(tipoEntidad, historialId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al restaurar {tipoEntidad} desde historial: {ex.Message}", ex);
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
        /// Actualiza el dígito verificador de una entidad
        /// </summary>
        /// <param name="tipoEntidad">Tipo de entidad (Usuario, Producto, Venta)</param>
        /// <param name="entidadId">ID de la entidad</param>
        /// <returns>True si la actualización fue exitosa</returns>
        public bool ActualizarDigitoVerificador(string tipoEntidad, int entidadId)
        {
            try
            {
                return _mppControlCambios.ActualizarDigitoVerificador(tipoEntidad, entidadId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar dígito verificador para {tipoEntidad}: {ex.Message}", ex);
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
                    return Seguridad.Hash(concatenacion);
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

        /// <summary>
        /// Calcula hash SHA256 de una cadena usando la clase Seguridad existente
        /// </summary>
        /// <param name="input">Cadena de entrada</param>
        /// <returns>Hash SHA256 en hexadecimal</returns>
        private string CalcularSHA256(string input)
        {
            try
            {
                return Seguridad.Hash(input);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al calcular SHA256: {ex.Message}", ex);
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
    }
}