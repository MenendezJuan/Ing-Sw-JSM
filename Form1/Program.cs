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
            using (var splashScreen = new SplashScreen.frmSplashScreen())
            {
                splashScreen.ShowDialog();
            }
            Application.Run(new frmInicioSesion());
        }
    }
}