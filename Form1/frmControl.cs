using System;
using System.Windows.Forms;

namespace Form1
{
    public partial class frmControl : Form
    {
        public frmControl()
        {
            InitializeComponent();
        }

        private void btnEvOrdenCompra_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal pform = Owner as frmMenuPrincipal;
            frmControlSolicitudesCotizacion evaluarSolicitudes = new frmControlSolicitudesCotizacion();
            pform.AddOwnedForm(evaluarSolicitudes);
            pform.FormHijo(evaluarSolicitudes);
            this.Close();
        }
    }
}
