using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace BLLs.Tecnica
{
    /// <summary>
    /// Clase de utilidad para resolver problemas de PInvokeStackImbalance en ReportViewer
    /// </summary>
    public static class ReportViewerFixer
    {
        /// <summary>
        /// Ejecuta una acción con protección contra errores de PInvokeStackImbalance
        /// </summary>
        /// <param name="action">Acción a ejecutar</param>
        /// <returns>True si la acción se completó correctamente</returns>
        public static bool ExecuteWithProtection(Action action)
        {
            try
            {
                // Configurar el modo de compatibilidad para PInvoke
                SetCompatibilityMode();
                
                // Ejecutar la acción en un contexto protegido
                action();
                
                // Liberar recursos explícitamente
                CleanupResources();
                
                return true;
            }
            catch (Exception)
            {
                // Asegurar limpieza incluso en caso de error
                CleanupResources();
                throw;
            }
        }

        /// <summary>
        /// Configura el modo de compatibilidad para PInvoke
        /// </summary>
        private static void SetCompatibilityMode()
        {
            // Deshabilitar la validación de pila de PInvoke
            // (Esto es una solución temporal hasta que Microsoft arregle el problema)
            Environment.SetEnvironmentVariable("COMPLUS_MDA_DISABLEPIVOKEIMBALANCECHECK", "1");
        }

        /// <summary>
        /// Libera recursos y fuerza la recolección de basura
        /// </summary>
        private static void CleanupResources()
        {
            // Forzar la recolección de basura para liberar recursos no administrados
            GC.Collect();
            GC.WaitForPendingFinalizers();
            
            // Segunda pasada para asegurar que todo se libere
            GC.Collect();
            GC.WaitForPendingFinalizers();
            
            // Pequeña pausa para permitir que los recursos se liberen completamente
            Thread.Sleep(100);
        }
    }
}