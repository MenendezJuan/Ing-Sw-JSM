using System;
using System.Configuration;
using System.IO;

namespace BLLs.Tecnica
{
    public class BLL_CONFIGURACION
    {
        /// <summary>
        /// Obtiene el directorio de exportaciones desde la configuración
        /// </summary>
        /// <returns>Ruta del directorio de exportaciones</returns>
        public static string ObtenerDirectorioExportaciones()
        {
            try
            {
                string directorio = ConfigurationManager.AppSettings["DirectorioExportaciones"];

                if (string.IsNullOrWhiteSpace(directorio))
                {
                    // Valor por defecto si no está configurado
                    directorio = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CheeseLogix", "Exportaciones");
                }

                // Crear el directorio si no existe
                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                return directorio;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener directorio de exportaciones: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Valida y crea un directorio si no existe
        /// </summary>
        /// <param name="ruta">Ruta del directorio</param>
        /// <returns>True si el directorio existe o se pudo crear</returns>
        public static bool ValidarYCrearDirectorio(string ruta)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ruta))
                    return false;

                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Obtiene una configuración del App.config
        /// </summary>
        /// <param name="clave">Clave de configuración</param>
        /// <param name="valorPorDefecto">Valor por defecto si no existe</param>
        /// <returns>Valor de la configuración</returns>
        public static string ObtenerConfiguracion(string clave, string valorPorDefecto = "")
        {
            try
            {
                string valor = ConfigurationManager.AppSettings[clave];
                return string.IsNullOrWhiteSpace(valor) ? valorPorDefecto : valor;
            }
            catch
            {
                return valorPorDefecto;
            }
        }
    }
}