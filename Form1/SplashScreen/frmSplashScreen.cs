using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace CheeseLogix.SplashScreen
{
    public partial class frmSplashScreen : MaterialForm
    {
        private MaterialSkinManager materialSkinManager;
        private Timer timer;
        private int progressValue = 0;

        public frmSplashScreen()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK; // O DARK

            // Esquema de color
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue500, Primary.Blue700,
                Primary.Blue200, Accent.LightBlue200,
                TextShade.WHITE);

            // Configuración de la ventana
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 50; // Intervalo de actualización
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            progressValue += 2;
            if (progressValue <= 100)
            {
                metroProgressBar1.Value = progressValue;
            }
            else
            {
                timer.Stop();
                this.Close(); // Cierra el splash screen después de que el progreso llega al 100%
            }
        }
    }
}
