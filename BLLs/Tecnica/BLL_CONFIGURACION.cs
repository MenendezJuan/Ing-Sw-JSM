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

        #region Configuraciones específicas de Reportes

        /// <summary>
        /// Obtiene el directorio de reportes
        /// </summary>
        /// <returns>Ruta del directorio de reportes</returns>
        public static string ObtenerDirectorioReporteria()
        {
            try
            {
                string directorio = ConfigurationManager.AppSettings["DirectorioExportaciones"];

                if (string.IsNullOrWhiteSpace(directorio))
                {
                    directorio = Path.Combine("C:", "CheeseLogix", "Reporteria");
                }

                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                return directorio;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener directorio de reportes: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene la ruta del reporte de ventas RDLC como recurso embebido
        /// </summary>
        public static string ObtenerRutaReporteVentas()
        {
            return ObtenerConfiguracion("ReporteVentasRDLC", "CheeseLogix.Negocio.Reportes.ReporteVentas.rdlc");
        }
        
        /// <summary>
        /// Obtiene la ruta del archivo RDLC usando rutas relativas
        /// </summary>
        public static string ObtenerRutaAbsolutaRDLC()
        {
            try
            {
                // Obtener la ruta relativa desde la configuración
                string rutaRelativa = ObtenerConfiguracion("ReporteVentasRDLCPath", @"Negocio\Reportes\ReporteVentas.rdlc");
                
                // Buscar en múltiples ubicaciones posibles
                string[] rutasAIntentar = new string[]
                {
                    // 1. Relativo al directorio de la aplicación
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaRelativa),
                    
                    // 2. Relativo al directorio de ejecución con carpeta Reportes
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reportes", "ReporteVentas.rdlc"),
                    
                    // 3. Relativo al directorio actual del proceso
                    Path.Combine(Environment.CurrentDirectory, rutaRelativa),
                    
                    // 4. En el directorio de salida bin
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "ReporteVentas.rdlc"),
                    
                    // 5. Buscar hacia arriba en la jerarquía de carpetas (modo desarrollo)
                    BuscarArchivoHaciaArriba("ReporteVentas.rdlc")
                };
                
                // Intentar cada ruta hasta encontrar el archivo
                foreach (string ruta in rutasAIntentar)
                {
                    if (!string.IsNullOrEmpty(ruta) && File.Exists(ruta))
                    {
                        return ruta;
                    }
                }
                
                // Si no se encuentra en ninguna ubicación, devolver la primera opción
                return rutasAIntentar[0];
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener ruta del archivo RDLC: {ex.Message}", ex);
            }
        }
        
        /// <summary>
        /// Busca un archivo hacia arriba en la jerarquía de carpetas
        /// </summary>
        private static string BuscarArchivoHaciaArriba(string nombreArchivo)
        {
            try
            {
                DirectoryInfo directorio = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                
                // Buscar hasta 5 niveles hacia arriba
                for (int i = 0; i < 5 && directorio != null; i++)
                {
                    // Buscar en subcarpetas comunes
                    string[] subCarpetas = { 
                        @"Form1\Negocio\Reportes", 
                        @"Negocio\Reportes", 
                        "Reportes" 
                    };
                    
                    foreach (string subCarpeta in subCarpetas)
                    {
                        string rutaCompleta = Path.Combine(directorio.FullName, subCarpeta, nombreArchivo);
                        if (File.Exists(rutaCompleta))
                        {
                            return rutaCompleta;
                        }
                    }
                    
                    directorio = directorio.Parent;
                }
                
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene el prefijo para archivos PDF de reportes
        /// </summary>
        public static string ObtenerPrefijoPDFReporte()
        {
            return ObtenerConfiguracion("PrefijoPDFReporte", "Reporte_CheeseLogix");
        }

        /// <summary>
        /// Obtiene el prefijo para archivos Excel de reportes
        /// </summary>
        public static string ObtenerPrefijoExcelReporte()
        {
            return ObtenerConfiguracion("PrefijoExcelReporte", "Reporte_CheeseLogix");
        }

        #endregion
    }
}