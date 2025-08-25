using BEs;
using BEs.Interfaces;
using BLLs;
using BLLs.Tecnica;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
                    try
                    {
                        pdfViewer1.LoadDocument(rutaPDF);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"No se pudo cargar el visor PDF integrado: {ex.Message}\n\n" +
                                      "Se abrirá el PDF con el visor predeterminado del sistema.", 
                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        AbrirPDFExterno(rutaPDF);
                        
                        MostrarMensajeAlternativo();
                    }
                }
                else
                {
                    string nombreArchivo = BLL_CONFIGURACION.ObtenerConfiguracion("ManualUsuarioPDF", "Manual_Usuario_CheeseLogix.pdf");
                    string directorioConfiguracion = BLL_CONFIGURACION.ObtenerDirectorioDocumentacion();

                    MessageBox.Show($"El archivo de ayuda '{nombreArchivo}' no se encuentra.\n\n" +
                                  $"Ubicaciones verificadas:\n" +
                                  $"• {directorioConfiguracion}\n" +
                                  $"• {Path.Combine(Application.StartupPath, "Documentacion")}\n" +
                                  $"• Directorio del proyecto\n\n" +
                                  $"Asegúrese de que el archivo esté en alguna de estas ubicaciones.",
                                  ConstantesUI.Titulos.Informacion,
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el PDF: {ex.Message}", ConstantesUI.Titulos.Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirPDFExterno(string rutaPDF)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = rutaPDF,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el PDF: {ex.Message}", 
                    ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarMensajeAlternativo()
        {
            try
            {
                pdfViewer1.Visible = false;
                
                var lblMensaje = new Label
                {
                    Text = "El PDF de ayuda se ha abierto en el visor predeterminado de su sistema.\n\n" +
                           "Si desea integrar el visor PDF, verifique la instalación de la librería Patagames.Pdf.",
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    ForeColor = System.Drawing.Color.White,
                    BackColor = System.Drawing.Color.FromArgb(45, 45, 45),
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular)
                };
                
                if (pdfViewer1.Parent != null)
                {
                    pdfViewer1.Parent.Controls.Add(lblMensaje);
                    lblMensaje.BringToFront();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en MostrarMensajeAlternativo: {ex.Message}");
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
                string rutaDocumentacion = BLL_CONFIGURACION.ObtenerDirectorioDocumentacion();

                System.Diagnostics.Process.Start("explorer.exe", rutaDocumentacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la carpeta: {ex.Message}", ConstantesUI.Titulos.Error,
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
                MessageBox.Show($"Error al cargar los idiomas: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error al cambiar idioma: {ex.Message}", ConstantesUI.Titulos.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
