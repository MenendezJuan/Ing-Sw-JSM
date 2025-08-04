using BEs;
using BEs.Interfaces;
using BLLs;
using BLLs.Tecnica;
using System;
using System.IO;
using System.Windows.Forms;
using System.Linq; 

namespace CheeseLogix.Tecnica
{
    public partial class frmSerializacion : Form, IObservador
    {
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        private BLL_SERIALIZACION Bll_Serializacion;

        public frmSerializacion()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            Bll_Serializacion = new BLL_SERIALIZACION();

            sesion.RegistrarObservador(this);
            IIdioma oIdioma = sesion.Idioma;
            CargarIdiomas();
            Actualizar(oIdioma);
            
            ConfigurarControlesIniciales();
        }

        #region Métodos de Configuración

        private void ConfigurarControlesIniciales()
        {
            // Configurar ComboBox de tipos de datos
            if (cboTipoDato != null)
            {
                cboTipoDato.Items.Clear();
                cboTipoDato.Items.Add("Bitácora");
                cboTipoDato.Items.Add("Ventas");
                cboTipoDato.Items.Add("Usuarios");
                cboTipoDato.Items.Add("Excepción");
                cboTipoDato.SelectedIndex = 0;
                
                cboTipoDato.SelectedIndexChanged += CboTipoDato_SelectedIndexChanged;
            }

            // Configurar TextBoxes
            if (txtContenidoSerializar != null)
            {
                txtContenidoSerializar.Multiline = true;
                txtContenidoSerializar.ScrollBars = ScrollBars.Both;
                txtContenidoSerializar.ReadOnly = true;
            }

            if (txtContenidoDeserializar != null)
            {
                txtContenidoDeserializar.Multiline = true;
                txtContenidoDeserializar.ScrollBars = ScrollBars.Both;
                txtContenidoDeserializar.ReadOnly = true;
            }
        }

        private void CboTipoDato_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboTipoDato.SelectedItem != null)
                {
                    string tipoDato = cboTipoDato.SelectedItem.ToString();
                    string datosJSON = Bll_Serializacion.ObtenerDatosParaUI(tipoDato);
                    txtContenidoSerializar.Text = datosJSON;
                }
            }
            catch (Exception ex)
            {
                txtContenidoSerializar.Text = $"Error al cargar datos: {ex.Message}";
            }
        }

        #endregion

        #region Eventos de Botones

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            try
            {
                string tipoDato = cboTipoDato?.SelectedItem?.ToString() ?? "Bitácora";
                
                string datosJSON = Bll_Serializacion.ObtenerDatosParaUI(tipoDato);
                
                txtContenidoSerializar.Text = datosJSON;
                
                MessageBox.Show($"Datos de {tipoDato} cargados exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeserializar_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Archivos JSON (*.json)|*.json|Archivos XML (*.xml)|*.xml|Todos los archivos (*.*)|*.*";
                    openFileDialog.Title = "Seleccionar archivo para deserializar";
                    
                    // Usar directorio de exportaciones desde configuración
                    string directorioExportaciones = Bll_Serializacion.ObtenerDirectorioExportaciones();
                    openFileDialog.InitialDirectory = directorioExportaciones;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string contenido = Bll_Serializacion.DeserializarDesdeArchivo(openFileDialog.FileName);
                        txtContenidoDeserializar.Text = contenido;
                        
                        MessageBox.Show($"Archivo deserializado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al deserializar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarSerializado_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtContenidoSerializar.Text))
                {
                    MessageBox.Show("No hay contenido para guardar", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos JSON (*.json)|*.json|Archivos XML (*.xml)|*.xml";
                    saveFileDialog.Title = "Guardar archivo serializado";
                    saveFileDialog.FileName = $"Datos_{DateTime.Now:yyyyMMdd_HHmmss}";
                    
                    // Usar directorio de exportaciones desde configuración
                    string directorioExportaciones = Bll_Serializacion.ObtenerDirectorioExportaciones();
                    saveFileDialog.InitialDirectory = directorioExportaciones;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string formato = Path.GetExtension(saveFileDialog.FileName).ToLower();
                        bool exitoso = Bll_Serializacion.SerializarDesdeUI("datos", txtContenidoSerializar.Text, formato, saveFileDialog.FileName);
                        
                        if (exitoso)
                        {
                            MessageBox.Show($"Archivo guardado exitosamente en:\n{saveFileDialog.FileName}", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

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