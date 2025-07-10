using BEs;
using BEs.Clases;
using BEs.Interfaces;
using BLLs;
using Form1.Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Form1
{
    public partial class frmMenuPrincipal : Form, IObservador
    {
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        public frmMenuPrincipal()
        {
            InitializeComponent();
            this.MdiChildActivate += frmMenuPrincipal_MdiChildActivate;
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            sesion.RegistrarObservador(this);
            IIdioma oIdioma = sesion.Idioma;
            CargarIdiomas();
            Actualizar(oIdioma);
            if (sesion.Permisos != null)
            {
                BuscarControles(this.Controls);
                Buscar(sesion.Permisos[0]);
            }
            labelNombreUser.Text = CargarUsuarioLabel();
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
            labelDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }


        #region MetodosPrivados

        private string CargarUsuarioLabel()
        {
            var nombreUsuario = sesion.oUsuario.Email;
            return nombreUsuario;
        }
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

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sesion.DesregistrarObservador(this);
            SessionManager.Logout();
            CerrarFrmPrin();
        }

        private void AusuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void idiomasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenuAdmin gestorIdiomas = new frmMenuAdmin();
            AddOwnedForm(gestorIdiomas);
            FormHijo(gestorIdiomas);
            HideSubMenu();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #region Idiomas
        private void CargarIdiomas()
        {
            try
            {
                var idiomas = Bll_Idioma.ListarTodos();
                cboxIdiomas.DataSource = idiomas;
                cboxIdiomas.DisplayMember = "Nombre";
                cboxIdiomas.ValueMember = "Id";

                var idiomaPredeterminado = idiomas.FirstOrDefault(i => i.Nombre == "Español");
                if (idiomaPredeterminado != null)
                {
                    cboxIdiomas.SelectedValue = idiomaPredeterminado.Id;
                    sesion.CambiarIdioma(idiomaPredeterminado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los idiomas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarTextosControles(Idioma idioma)
        {
            try
            {
                var traducciones = Bll_Traduccion.ListarPorIdioma(idioma.Id);

                foreach (Control control in ListaControles)
                {
                    var traduccion = traducciones.FirstOrDefault(t => t.Palabra == control.Text);
                    if (traduccion != null)
                    {
                        control.Text = traduccion.TraduccionTexto;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar los textos de los controles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Actualizar(IIdioma idioma)
        {
            foreach (Control control in ListaControles)
            {
                if (control.Tag != null)
                {
                    string traduccion = Bll_Traduccion.BuscarTraduccion(control.Tag.ToString(), idioma.Id);
                    if (!string.IsNullOrEmpty(traduccion))
                    {
                        control.Text = traduccion;
                    }
                }
            }

            TraducirMenuStrip(menuStripPrincipal, idioma);

            if (cboxIdiomas.DataSource != null && cboxIdiomas.Items.Count > 0 && cboxIdiomas.ValueMember != string.Empty)
            {
                cboxIdiomas.SelectedValue = idioma.Id;
            }
        }

        private void TraducirMenuStrip(MenuStrip menuStrip, IIdioma idioma)
        {
            foreach (ToolStripItem item in menuStrip.Items)
            {
                TraducirMenuStripItem(item, idioma);
            }
        }

        private void TraducirMenuStripItem(ToolStripItem item, IIdioma idioma)
        {
            if (item.Tag != null)
            {
                string traduccion = Bll_Traduccion.BuscarTraduccion(item.Tag.ToString(), idioma.Id);
                if (!string.IsNullOrEmpty(traduccion))
                {
                    item.Text = traduccion;
                }
            }

            // Si el item tiene submenús, los traducimos también
            if (item is ToolStripMenuItem menuItem && menuItem.DropDownItems.Count > 0)
            {
                foreach (ToolStripItem subItem in menuItem.DropDownItems)
                {
                    TraducirMenuStripItem(subItem, idioma);
                }
            }
        }
        #endregion Idiomas

        List<Control> ListaControles = new List<Control>();
        public void BuscarControles(ICollection controles)
        {
            foreach (Control c in controles)
            {
                ListaControles.Add(c);
                if (c.HasChildren)
                {
                    BuscarControles(c.Controls);
                }
            }
        }

        #region Permisos
        public void Buscar(Componente c)
        {
            GrupoPermisos grupo = (GrupoPermisos)c;
            foreach (Componente p in grupo.Permisos)
            {
                if (p is GrupoPermisos)
                {
                    Buscar(p);
                    Comprobar(p);
                }
                else
                {
                    Comprobar(p);
                }
            }
        }

        public void Comprobar(Componente p)
        {
            foreach (Control c in ListaControles)
            {
                if (c.Tag != null && c.Tag.ToString() == p.Nombre)
                {
                    c.Visible = true;
                }
            }
        }
        #endregion Permisos

        #region Extras
        int i = 0;
        public void CerrarFrmPrin()
        {
            if (i == 0)
            {
                frmInicioSesion frmIniciarSesion = new frmInicioSesion();
                frmIniciarSesion.Show();
                i++;
                this.Hide();
            }
        }

        public void Cerrar()
        {
            Form frmMenu = Application.OpenForms.OfType<frmMenuPrincipal>().FirstOrDefault();

            if (frmMenu == null)
            {
                // Si no existe una instancia de frmMenuPrincipal, crea una nueva
                frmMenuPrincipal FormPrincipal = new frmMenuPrincipal();
                FormPrincipal.Show();
            }
            else
            {
                // Si ya existe, simplemente enfócalo
                frmMenu.BringToFront();
            }

            // Cierra el formulario actual
            this.Close();
        }
        #endregion Extras

        private Timer fadeOutTimer;
        private int fadeOutValue = 100;
        private bool isClosing = false;
        private void frmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isClosing)
            {
                e.Cancel = false;
                return;
            }

            e.Cancel = true;

            isClosing = true;

            if (fadeOutTimer != null && fadeOutTimer.Enabled)
            {
                fadeOutTimer.Stop();
            }

            fadeOutTimer = new Timer();
            fadeOutTimer.Interval = 10;
            fadeOutTimer.Tick += FadeOutTimer_Tick;
            fadeOutTimer.Start();
        }

        private void FadeOutTimer_Tick(object sender, EventArgs e)
        {
            if (fadeOutValue > 0)
            {
                fadeOutValue--;
                this.Opacity = fadeOutValue / 100.0;
            }
            else
            {
                fadeOutTimer.Stop();
                this.Close();

                isClosing = false;
                Application.Exit();
            }
        }

        private void cboxIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxIdiomas.SelectedItem != null)
            {
                Idioma idiomaSeleccionado = (Idioma)cboxIdiomas.SelectedItem;
                ListaControles.Clear();
                BuscarControles(this.Controls);
                ActualizarTextosControles(idiomaSeleccionado);
                sesion.CambiarIdioma(idiomaSeleccionado);
            }
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            frmMenuAdmin frmAdmin = new frmMenuAdmin();
            AddOwnedForm(frmAdmin);
            FormHijo(frmAdmin);
            HideSubMenu();
        }

        private void toolStripMenuItemUsuario_Click(object sender, EventArgs e)
        {

        }

        private void frmMenuPrincipal_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                menuStripPrincipal.Visible = true;
            }
        }
    }
}
