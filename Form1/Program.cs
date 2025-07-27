using System;
using System.Windows.Forms;

namespace CheeseLogix
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Mostrar el splash screen
            using (var splashScreen = new SplashScreen.frmSplashScreen())
            {
                splashScreen.ShowDialog(); // Mostrar como ventana modal para detener el flujo hasta que se cierre
            }

            // Después de cerrar el splash screen, iniciar el formulario principal
            Application.Run(new frmInicioSesion());
            //Application.Run(new frmInicioSesion());
        }
    }
}