using BEs;
using BLLs.Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq; 
using System.Web.Script.Serialization;
using System.Xml;
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

        #region Métodos

        /// <summary>
        /// Obtiene datos para mostrar en la UI según el tipo seleccionado
        /// </summary>
        /// <param name="tipoDato">Tipo de dato a obtener</param>
        /// <returns>JSON formateado de los datos</returns>
        public string ObtenerDatosParaUI(string tipoDato)
        {
            try
            {
                object datos = null;
                
                switch (tipoDato.ToLower())
                {
                    case "bitácora":
                    case "bitacora":
                        datos = _bllBitacora.FiltrarXTipo(Enum_TiposBitacora.TODO);
                        break;
                    case "ventas":
                        datos = _bllVenta.ObtenerTodos();
                        break;
                    case "usuarios":
                        var usuarios = _bllUsuario.Listar();
                        datos = usuarios.Select(u => new
                        {
                            u.Id,
                            u.Email,
                            FechaCreacion = DateTime.Now
                        });
                        break;
                    case "excepción":
                    case "excepcion":
                        datos = new
                        {
                            Fecha = DateTime.Now,
                            TipoExcepcion = "InvalidOperationException",
                            Mensaje = "Ejemplo de excepción para demostración",
                            StackTrace = "StackTrace de ejemplo",
                            InnerException = "Inner exception de ejemplo"
                        };
                        break;
                    default:
                        throw new ArgumentException($"Tipo de dato no válido: {tipoDato}");
                }

                var serializer = new JavaScriptSerializer();
                var jsonString = serializer.Serialize(datos);

                return jsonString;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener datos para UI: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Serializa datos desde la UI
        /// </summary>
        /// <param name="tipoDato">Tipo de dato</param>
        /// <param name="contenido">Contenido a serializar</param>
        /// <param name="formato">Formato (json/xml)</param>
        /// <param name="rutaArchivo">Ruta del archivo</param>
        /// <returns>True si fue exitoso</returns>
        public bool SerializarDesdeUI(string tipoDato, string contenido, string formato, string rutaArchivo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(contenido))
                {
                    throw new ArgumentException("El contenido no puede estar vacío");
                }

                // Validar formato según el tipo
                if (formato.ToLower() == "json")
                {
                    var serializer = new JavaScriptSerializer();
                    serializer.Deserialize<object>(contenido); // Valida JSON
                }
                else if (formato.ToLower() == "xml")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(contenido); // Valida XML
                }

                // Crear directorio si no existe
                string directorio = Path.GetDirectoryName(rutaArchivo);
                if (!string.IsNullOrEmpty(directorio) && !Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                File.WriteAllText(rutaArchivo, contenido);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al serializar desde UI: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Deserializa datos desde archivo
        /// </summary>
        /// <param name="rutaArchivo">Ruta del archivo</param>
        /// <returns>Contenido deserializado</returns>
        public string DeserializarDesdeArchivo(string rutaArchivo)
        {
            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    throw new FileNotFoundException($"El archivo no existe: {rutaArchivo}");
                }

                return File.ReadAllText(rutaArchivo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al deserializar archivo: {ex.Message}", ex);
            }
        }

        #endregion

        #region Configuración

        /// <summary>
        /// Obtiene el directorio de exportaciones desde la configuración
        /// </summary>
        /// <returns>Ruta del directorio de exportaciones</returns>
        public string ObtenerDirectorioExportaciones()
        {
            return BLL_CONFIGURACION.ObtenerDirectorioExportaciones();
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