using BEs;
using BEs.Clases;
using BEs.Clases.Negocio.Compras;
using BEs.Clases.Negocio.Compras.Enums;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Form1.Negocio
{
    public partial class frmVerificacionProductos : Form, IObservador
    {
        private frmGenerarOrdenCompra _formularioGenerarOrdenCompra;
        private BLL_COMPRA _bllCompra;
        private BLL_COTIZACION _bllCotizacion;
        private Compra _ordenCompraSeleccionada;
        private Cotizacion _cotizacionSeleccionada;
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        public frmVerificacionProductos()
        {
            InitializeComponent();
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
            _bllCompra = new BLL_COMPRA();
            _bllCotizacion = new BLL_COTIZACION();
            InicializarFirma();
        }

        private void btnAprobarRecepcion_Click(object sender, EventArgs e)
        {
            if (!FirmaRealizada())
            {
                MessageBox.Show("Debe realizar una firma antes de aprobar la recepción.", "Firma requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CamposValidosParaAprobacion())
            {
                MessageBox.Show("Recepción aprobada. El botón de pago será habilitado.", "Recepción Aprobada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (_formularioGenerarOrdenCompra != null)
                {
                    _formularioGenerarOrdenCompra.HabilitarBotonPago(true);
                    OnRecepcionAprobada?.Invoke();
                }
                else
                {
                    MessageBox.Show("El formulario de la orden de compra no está disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos antes de aprobar la recepción.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public event Action OnRecepcionRechazada;
        public event Action OnRecepcionAprobada;
        private void btnRechazarRecepcion_Click(object sender, EventArgs e)
        {
            if (!FirmaRealizada())
            {
                MessageBox.Show("Debe realizar una firma antes de rechazar la recepción.", "Firma requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _bllCompra.CambiarEstadoCompra(_ordenCompraSeleccionada.Id, EstadoCompra.Rechazada);
                _bllCotizacion.Eliminar(_cotizacionSeleccionada.Id);
                MessageBox.Show($"Se ha notificado al proveedor {_cotizacionSeleccionada.DescripcionProveedor} que los productos serán devueltos.", "Recepción Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnRecepcionRechazada?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar el estado de la orden de compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void frmVerificacionProductos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        #region metodosPrivados
        private void CargarDatos()
        {
            CargarDetallesCompra();

            CargarDetallesCotizacion();
        }

        private void CargarDetallesCompra()
        {
            var detallesCompra = _ordenCompraSeleccionada.oDetalleCompra;

            dataGridViewDetalleCompra.DataSource = detallesCompra;

            OcultarColumnasDetalleCompra();

            dataGridViewDetalleCompra.Columns["NombreProducto"].HeaderText = "Nombre Producto";
        }

        private void OcultarColumnasDetalleCompra()
        {
            dataGridViewDetalleCompra.Columns["ProductoId"].Visible = false;
            dataGridViewDetalleCompra.Columns["CompraId"].Visible = false;
            dataGridViewDetalleCompra.Columns["Precio"].Visible = false;
            dataGridViewDetalleCompra.Columns["SubTotal"].Visible = false;
            dataGridViewDetalleCompra.Columns["Fecha"].Visible = true;
            dataGridViewDetalleCompra.Columns["Cantidad"].Visible = true;
            dataGridViewDetalleCompra.Columns["oProducto"].Visible = false;
            dataGridViewDetalleCompra.Columns["Id"].Visible = false;
            dataGridViewDetalleCompra.Columns["oCompra"].Visible = false;
        }

        private void CargarDetallesCotizacion()
        {
            var detallesCotizacion = _cotizacionSeleccionada.DetallesCotizacion;

            dataGridViewDetalleCotizacion.DataSource = detallesCotizacion;

            OcultarColumnasDetalleCotizacion();

            dataGridViewDetalleCotizacion.Columns["NombreProducto"].HeaderText = "Nombre Producto";
        }

        private void OcultarColumnasDetalleCotizacion()
        {
            dataGridViewDetalleCotizacion.Columns["ProductoId"].Visible = false;
            dataGridViewDetalleCotizacion.Columns["CotizacionId"].Visible = false;
            dataGridViewDetalleCotizacion.Columns["Fecha"].Visible = true;
            dataGridViewDetalleCotizacion.Columns["Cantidad"].Visible = true;
            dataGridViewDetalleCotizacion.Columns["oProducto"].Visible = false;
            dataGridViewDetalleCotizacion.Columns["Id"].Visible = false;
        }

        public void CargarOrdenCompraYCotizacion(Compra ordenCompra, Cotizacion cotizacion)
        {
            _ordenCompraSeleccionada = ordenCompra;
            _cotizacionSeleccionada = cotizacion;

            _formularioGenerarOrdenCompra = (frmGenerarOrdenCompra)Owner;

            CargarDatos();
        }

        private bool CamposValidosParaAprobacion()
        {
            return checkBoxLlegaronProductos.Checked &&
                   checkBoxCondicionesProductos.Checked &&
                   checkBoxCantidadProductos.Checked &&
                   checkBoxEmpaqueProductos.Checked &&
                   !string.IsNullOrEmpty(textBoxObservaciones.Text);
        }

        #endregion

        #region variablesPrivadas
        bool isDrawing = false;
        Point lastPoint = Point.Empty;
        Bitmap firmaBitmap;
        #endregion

        #region metodosFirma
        private void pictureBoxFirma_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            lastPoint = e.Location;
        }

        private bool FirmaRealizada()
        {
            for (int x = 0; x < firmaBitmap.Width; x++)
            {
                for (int y = 0; y < firmaBitmap.Height; y++)
                {
                    if (firmaBitmap.GetPixel(x, y) != Color.White)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void InicializarFirma()
        {
            firmaBitmap = new Bitmap(pictureBoxFirma.Width, pictureBoxFirma.Height);
            pictureBoxFirma.Image = firmaBitmap;

            using (Graphics g = Graphics.FromImage(firmaBitmap))
            {
                g.Clear(Color.White);
            }
        }


        private void pictureBoxFirma_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && lastPoint != Point.Empty)
            {
                using (Graphics g = Graphics.FromImage(firmaBitmap))
                {
                    g.DrawLine(Pens.Black, lastPoint, e.Location);
                }
                pictureBoxFirma.Invalidate();
                lastPoint = e.Location;
            }
        }

        private void pictureBoxFirma_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
            lastPoint = Point.Empty;
        }

        private void GuardarFirma()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopPath, "FirmadoConforme");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, $"firma{DateTime.Now}.png");

            firmaBitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
            MessageBox.Show("Firma guardada correctamente en la carpeta 'FirmadoConforme' en el escritorio.", "Guardar Firma", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void LimpiarFirma()
        {
            using (Graphics g = Graphics.FromImage(firmaBitmap))
            {
                g.Clear(Color.White);
            }
            pictureBoxFirma.Invalidate();
        }

        #endregion

        private void btnFirmarConforme_Click(object sender, EventArgs e)
        {
            GuardarFirma();
        }

        private void btnLimpiarFirm_Click(object sender, EventArgs e)
        {
            LimpiarFirma();
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

            if (cboxIdiomas.DataSource != null && cboxIdiomas.Items.Count > 0 && cboxIdiomas.ValueMember != string.Empty)
            {
                cboxIdiomas.SelectedValue = idioma.Id;
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

        //Ajustar esta logica
        #region Extras
        int i = 0;
        public void Cerrar()
        {
            if (i == 0)
            {
                frmMenuPrincipal FormPrincipal = new frmMenuPrincipal();
                FormPrincipal.Show();
                i++;
                this.Close();
            }
        }
        #endregion Extras

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
    }
}
