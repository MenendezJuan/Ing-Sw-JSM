using Form1.Negocio;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Form1
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
            CustomizeDesing();
            InicializarEstilos();
        }

        #region PropiedadesFrm
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        #endregion

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
        }


        #region MetodosPrivados
        public void OcultarPanel()
        {
            panelCentral.Visible = false;
        }

        private void CustomizeDesing()
        {
            panelInsumos.Visible = false;
            panelCotizaciones.Visible = false;
            PanelEntidades.Visible = false;
        }

        private void HideSubMenu()
        {
            if (panelInsumos.Visible)
                panelInsumos.Visible = false;
            if (panelCotizaciones.Visible)
                panelCotizaciones.Visible = false;
            if (PanelEntidades.Visible)
                PanelEntidades.Visible = false;
        }
        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void AbrirFormularioHijo(Form formHijo)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            formHijo.MdiParent = this;
            formHijo.WindowState = FormWindowState.Maximized;
            formHijo.Show();
        }

        public void FormHijo(Form hijo)
        {
            hijo.TopLevel = false;
            panelCentral.Visible = true;
            this.panelCentral.Controls.Clear();
            this.panelCentral.Controls.Add(hijo);
            hijo.Size = panelCentral.Size;
            hijo.Show();
        }

        private void ConfirmarSalida()
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir del programa?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #region Estilos
        private void AplicarEstiloBoton(Button boton)
        {
            boton.MouseEnter += (s, e) => Boton_MouseEnter(boton);
            boton.MouseLeave += (s, e) => Boton_MouseLeave(boton);
        }

        private void Boton_MouseEnter(Button boton)
        {
            boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            boton.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 70);
            boton.FlatAppearance.BorderSize = 2;
            boton.ForeColor = Color.White;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100);
        }

        private void Boton_MouseLeave(Button boton)
        {
            boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(11, 7, 17);
            boton.FlatStyle = FlatStyle.Flat;
        }

        private void InicializarEstilos()
        {
            AplicarEstiloBoton(btnProductos);
            AplicarEstiloBoton(btnComprasProductos);
            AplicarEstiloBoton(btnControl);
            AplicarEstiloBoton(btnCaja);
            AplicarEstiloBoton(btnFacturar);
            AplicarEstiloBoton(btnReportes);
            AplicarEstiloBoton(btnStockProductos);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        #endregion Estilos
        #endregion

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelInsumos);
        }

        private void btnStockProductos_Click(object sender, EventArgs e)
        {
            frmGestionStockProductos stockProductos = new frmGestionStockProductos();
            AddOwnedForm(stockProductos);
            FormHijo(stockProductos);
            HideSubMenu();
        }


        private void gestionIdiomasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenuAdmin gestorIdiomas = new frmMenuAdmin();
            AddOwnedForm(gestorIdiomas);
            FormHijo(gestorIdiomas);
            HideSubMenu();
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelCotizaciones);
        }

        private void buttonSolicitarCotizacion_Click(object sender, EventArgs e)
        {
            frmGestionCotizacionProductos solicitarCotizacion = new frmGestionCotizacionProductos();
            AddOwnedForm(solicitarCotizacion);
            FormHijo(solicitarCotizacion);
            HideSubMenu();
        }

        private void buttonEvaluarSolicitudes_Click(object sender, EventArgs e)
        {
            frmControlSolicitudesCotizacion controlSolicitudesCotizacion = new frmControlSolicitudesCotizacion();
            AddOwnedForm(controlSolicitudesCotizacion);
            FormHijo(controlSolicitudesCotizacion);
            HideSubMenu();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {

        }

        private void btnCaja_Click(object sender, EventArgs e)
        {

        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {

        }

        private void btnComprasProductos_Click(object sender, EventArgs e)
        {
            frmGenerarOrdenCompra compraProductos = new frmGenerarOrdenCompra();
            AddOwnedForm(compraProductos);
            FormHijo(compraProductos);
            HideSubMenu();
        }

        private void buttonGestionarProveedores_Click(object sender, EventArgs e)
        {
            frmGestionarProveedores gestionarProveedores = new frmGestionarProveedores();
            AddOwnedForm(gestionarProveedores);
            FormHijo(gestionarProveedores);
            HideSubMenu();
        }

        private void buttonEntidades_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelEntidades);
        }
    }
}
