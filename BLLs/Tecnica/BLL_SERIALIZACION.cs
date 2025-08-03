using BEs;
using BLLs.Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq; 
using System.Text.Json;
using System.Xml.Serialization;

namespace BLLs.Tecnica
{
    public class BLL_SERIALIZACION
    {
        private readonly BLL_BITACORA _bllBitacora;
        private readonly BLL_VENTA _bllVenta;
        private readonly BLL_USUARIO _bllUsuario;

        public BLL_SERIALIZACION()
        {
            _bllBitacora = new BLL_BITACORA();
            _bllVenta = new BLL_VENTA();
            _bllUsuario = new BLL_USUARIO();
        }

        #region Serialización JSON

        /// <summary>
        /// Exporta la bitácora completa a formato JSON
        /// </summary>
        /// <param name="rutaArchivo">Ruta donde guardar el archivo JSON</param>
        /// <returns>True si la exportación fue exitosa</returns>
        public bool ExportarBitacoraJSON(string rutaArchivo)
        {
            try
            {
                var bitacoras = _bllBitacora.Listar();
                var jsonString = JsonSerializer.Serialize(bitacoras, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                File.WriteAllText(rutaArchivo, jsonString);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al exportar bitácora a JSON: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Exporta las ventas a formato JSON
        /// </summary>
        /// <param name="rutaArchivo">Ruta donde guardar el archivo JSON</param>
        /// <param name="fechaDesde">Fecha desde para filtrar</param>
        /// <param name="fechaHasta">Fecha hasta para filtrar</param>
        /// <returns>True si la exportación fue exitosa</returns>
        public bool ExportarVentasJSON(string rutaArchivo, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            try
            {
                var ventas = _bllVenta.Listar();

                // Filtrar por fechas si se especifican
                if (fechaDesde.HasValue && fechaHasta.HasValue)
                {
                    ventas = ventas.FindAll(v => v.Fecha >= fechaDesde.Value && v.Fecha <= fechaHasta.Value);
                }

                var jsonString = JsonSerializer.Serialize(ventas, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                File.WriteAllText(rutaArchivo, jsonString);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al exportar ventas a JSON: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Exporta información de usuarios a formato JSON
        /// </summary>
        /// <param name="rutaArchivo">Ruta donde guardar el archivo JSON</param>
        /// <returns>True si la exportación fue exitosa</returns>
        public bool ExportarUsuariosJSON(string rutaArchivo)
        {
            try
            {
                var usuarios = _bllUsuario.Listar();

                // Crear objeto anónimo sin contraseñas por seguridad
                var usuariosSeguros = usuarios.Select(u => new
                {
                    u.Id,
                    u.Email,
                    FechaCreacion = DateTime.Now // Simulado
                });

                var jsonString = JsonSerializer.Serialize(usuariosSeguros, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                File.WriteAllText(rutaArchivo, jsonString);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al exportar usuarios a JSON: {ex.Message}", ex);
            }
        }

        #endregion

        #region Serialización XML

        /// <summary>
        /// Exporta la bitácora a formato XML
        /// </summary>
        /// <param name="rutaArchivo">Ruta donde guardar el archivo XML</param>
        /// <returns>True si la exportación fue exitosa</returns>
        public bool ExportarBitacoraXML(string rutaArchivo)
        {
            try
            {
                var bitacoras = _bllBitacora.Listar();
                var serializer = new XmlSerializer(typeof(List<Bitacora>));

                using (var writer = new StreamWriter(rutaArchivo))
                {
                    serializer.Serialize(writer, bitacoras);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al exportar bitácora a XML: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Exporta las ventas a formato XML
        /// </summary>
        /// <param name="rutaArchivo">Ruta donde guardar el archivo XML</param>
        /// <param name="fechaDesde">Fecha desde para filtrar</param>
        /// <param name="fechaHasta">Fecha hasta para filtrar</param>
        /// <returns>True si la exportación fue exitosa</returns>
        public bool ExportarVentasXML(string rutaArchivo, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            try
            {
                var ventas = _bllVenta.Listar();

                // Filtrar por fechas si se especifican
                if (fechaDesde.HasValue && fechaHasta.HasValue)
                {
                    ventas = ventas.FindAll(v => v.Fecha >= fechaDesde.Value && v.Fecha <= fechaHasta.Value);
                }

                var serializer = new XmlSerializer(typeof(List<Venta>));

                using (var writer = new StreamWriter(rutaArchivo))
                {
                    serializer.Serialize(writer, ventas);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al exportar ventas a XML: {ex.Message}", ex);
            }
        }

        #endregion

        #region Serialización de Excepciones

        /// <summary>
        /// Serializa información de excepciones del sistema
        /// </summary>
        /// <param name="excepcion">Excepción a serializar</param>
        /// <param name="rutaArchivo">Ruta donde guardar el archivo</param>
        /// <returns>True si la serialización fue exitosa</returns>
        public bool SerializarExcepcion(Exception excepcion, string rutaArchivo)
        {
            try
            {
                var infoExcepcion = new
                {
                    Fecha = DateTime.Now,
                    TipoExcepcion = excepcion.GetType().Name,
                    Mensaje = excepcion.Message,
                    StackTrace = excepcion.StackTrace,
                    InnerException = excepcion.InnerException?.Message
                };

                var jsonString = JsonSerializer.Serialize(infoExcepcion, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                File.WriteAllText(rutaArchivo, jsonString);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al serializar excepción: {ex.Message}", ex);
            }
        }

        #endregion

        #region Validaciones

        /// <summary>
        /// Valida que la ruta de archivo sea válida
        /// </summary>
        /// <param name="rutaArchivo">Ruta a validar</param>
        /// <returns>True si la ruta es válida</returns>
        public bool ValidarRutaArchivo(string rutaArchivo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(rutaArchivo))
                    return false;

                var directorio = Path.GetDirectoryName(rutaArchivo);
                if (!string.IsNullOrEmpty(directorio) && !Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}