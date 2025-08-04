using System;
using System.IO;
using System.Windows.Forms;
using Patagames.Pdf.Net.Controls.WinForms;

namespace CheeseLogix.Tecnica
{
    public partial class frmAyuda : Form
    {
        public frmAyuda()
        {
            InitializeComponent();
            CargarPDF();
        }

        private void CargarPDF()
        {
            try
            {
                // Cargar el PDF de ayuda desde recursos
                string rutaPDF = Path.Combine(Application.StartupPath, "Documentacion", "Manual_Usuario_CheeseLogix.pdf");
                
                if (File.Exists(rutaPDF))
                {
                    pdfViewer.LoadDocument(rutaPDF);
                }
                else
                {
                    // Si no existe el archivo, mostrar mensaje
                    MessageBox.Show("El archivo de ayuda no se encuentra.\n" +
                                  "Asegúrese de que el archivo 'Manual_Usuario_CheeseLogix.pdf' esté en la carpeta 'Documentacion'.", 
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
                string rutaDocumentacion = Path.Combine(Application.StartupPath, "Documentacion");
                
                if (Directory.Exists(rutaDocumentacion))
                {
                    System.Diagnostics.Process.Start("explorer.exe", rutaDocumentacion);
                }
                else
                {
                    Directory.CreateDirectory(rutaDocumentacion);
                    System.Diagnostics.Process.Start("explorer.exe", rutaDocumentacion);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la carpeta: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
