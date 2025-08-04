using BEs;
using BEs.Interfaces;
using BLLs.Tecnica;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Patagames.Pdf.Net.Controls.WinForms;
using BLLs;

namespace CheeseLogix.Tecnica
{
    public partial class frmAyuda : Form, IObservador
    {
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;

        public frmAyuda()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();

            sesion.RegistrarObservador(this);
            IIdioma oIdioma = sesion.Idioma;
            CargarIdiomas();
            Actualizar(oIdioma);
            CargarPDF();
        }

        private void CargarPDF()
        {
            try
            {
                // Buscar el PDF de ayuda en múltiples ubicaciones configurables
                string rutaPDF = BLL_CONFIGURACION.BuscarManualUsuario();
                
                if (File.Exists(rutaPDF))
                {
                    pdfViewer1.LoadDocument(rutaPDF);
                }
                else
                {
                    // Si no existe el archivo, mostrar mensaje con información de ubicaciones
                    string nombreArchivo = BLL_CONFIGURACION.ObtenerConfiguracion("ManualUsuarioPDF", "Manual_Usuario_CheeseLogix.pdf");
                    string directorioConfiguracion = BLL_CONFIGURACION.ObtenerDirectorioDocumentacion();
                    
                    MessageBox.Show($"El archivo de ayuda '{nombreArchivo}' no se encuentra.\n\n" +
                                  $"Ubicaciones verificadas:\n" +
                                  $"• {directorioConfiguracion}\n" +
                                  $"• {Path.Combine(Application.StartupPath, "Documentacion")}\n" +
                                  $"• Directorio del proyecto\n\n" +
                                  $"Asegúrese de que el archivo esté en alguna de estas ubicaciones.", 
                                  "Archivo no encontrado", 
                                  MessageBoxButtons.OK, 
                                  MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el PDF: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAbrirCarpeta_Click(object sender, EventArgs e)
        {
            try
            {
                // Usar el directorio de documentación configurado
                string rutaDocumentacion = BLL_CONFIGURACION.ObtenerDirectorioDocumentacion();
                
                // El método ObtenerDirectorioDocumentacion() ya crea el directorio si no existe
                System.Diagnostics.Process.Start("explorer.exe", rutaDocumentacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la carpeta: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        public void Actualizar(IIdioma idioma)
        {
            foreach (Control control in this.Controls)
            {
                if (control.Tag != null)
                {
                    string traduccion = Bll_Traduccion.BuscarTraduccion(control.Tag.ToString(), idioma.Id);
                    if (!string.IsNullOrEmpty(traduccion))
                    {
                        control.Text = traduccion;
                    }
                }

                if (control.HasChildren)
                {
                    foreach (Control controlChild in control.Controls)
                    {
                        if (controlChild.Tag != null)
                        {
                            string traduccion = Bll_Traduccion.BuscarTraduccion(controlChild.Tag.ToString(), idioma.Id);
                            if (!string.IsNullOrEmpty(traduccion))
                            {
                                controlChild.Text = traduccion;
                            }
                        }
                    }
                }
            }

            if (cboxIdiomas.DataSource != null && cboxIdiomas.Items.Count > 0 && cboxIdiomas.ValueMember != string.Empty)
            {
                cboxIdiomas.SelectedValue = idioma.Id;
            }
        }

        private void cboxIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboxIdiomas.SelectedValue != null && cboxIdiomas.SelectedValue != DBNull.Value)
                {
                    int idIdioma;
                    if (int.TryParse(cboxIdiomas.SelectedValue.ToString(), out idIdioma))
                    {
                        var idiomaSeleccionado = Bll_Idioma.ObtenerPorId(idIdioma);
                        if (idiomaSeleccionado != null)
                        {
                            sesion.CambiarIdioma(idiomaSeleccionado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar idioma: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
