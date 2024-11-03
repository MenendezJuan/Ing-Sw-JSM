using System;
using System.Windows.Forms;

namespace Form1
{
    public partial class frmGestionCompraProductos : Form
    {
        public frmGestionCompraProductos()
        {
            InitializeComponent();
        }

        private void btnSolicitarCotizacion_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal pform = Owner as frmMenuPrincipal;
            frmAgregarComprasProductos compraInsumo = new frmAgregarComprasProductos();
            pform.AddOwnedForm(compraInsumo);
            pform.FormHijo(compraInsumo);
            this.Close();
        }
    }
}
