using BEs;
using BEs.Interfaces;
using BLLs;
using BLLs.Tecnica;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix.Tecnica
{
    public partial class frmSerializacion : Form, IObservador
    {
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        private BLL_SERIALIZACION Bll_Serializacion;
        private bool _vistaEstructurada = false;

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

            // Configurar TreeView
            if (treeViewDeserializado != null)
            {
                treeViewDeserializado.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
                treeViewDeserializado.ForeColor = System.Drawing.Color.White;
                treeViewDeserializado.Font = new System.Drawing.Font("Consolas", 9F);
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

        #endregion Métodos de Configuración

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

                        // Mostrar vista estructurada si está habilitada
                        if (_vistaEstructurada)
                        {
                            MostrarVistaEstructurada(contenido, openFileDialog.FileName);
                        }

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

        private void btnCambiarVista_Click(object sender, EventArgs e)
        {
            _vistaEstructurada = !_vistaEstructurada;

            if (_vistaEstructurada)
            {
                btnCambiarVista.Text = "Vista Raw";
                btnCambiarVista.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);

                // Mostrar TreeView y ocultar TextBox
                treeViewDeserializado.Visible = true;
                txtContenidoDeserializar.Visible = false;

                // Si hay contenido, mostrarlo estructurado
                if (!string.IsNullOrEmpty(txtContenidoDeserializar.Text))
                {
                    MostrarVistaEstructurada(txtContenidoDeserializar.Text, "datos.json");
                }
                // Si no hay contenido pero hay contenido en serializar, usar ese
                else if (!string.IsNullOrEmpty(txtContenidoSerializar.Text))
                {
                    txtContenidoDeserializar.Text = txtContenidoSerializar.Text;
                    MostrarVistaEstructurada(txtContenidoSerializar.Text, "datos.json");
                }
            }
            else
            {
                btnCambiarVista.Text = "Vista Estructurada";
                btnCambiarVista.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);

                // Ocultar TreeView y mostrar TextBox
                treeViewDeserializado.Visible = false;
                txtContenidoDeserializar.Visible = true;
            }
        }

        private void MostrarVistaEstructurada(string contenido, string nombreArchivo)
        {
            try
            {
                treeViewDeserializado.Nodes.Clear();

                if (string.IsNullOrEmpty(contenido))
                {
                    treeViewDeserializado.Nodes.Add("Sin contenido para mostrar");
                    return;
                }

                string extension = Path.GetExtension(nombreArchivo).ToLower();

                if (extension == ".json")
                {
                    MostrarJSONEstructurado(contenido);
                }
                else if (extension == ".xml")
                {
                    MostrarXMLEstructurado(contenido);
                }
                else
                {
                    // Intentar detectar formato automáticamente
                    string contenidoTrimmed = contenido.TrimStart();
                    if (contenidoTrimmed.StartsWith("{") || contenidoTrimmed.StartsWith("["))
                    {
                        MostrarJSONEstructurado(contenido);
                    }
                    else if (contenidoTrimmed.StartsWith("<"))
                    {
                        MostrarXMLEstructurado(contenido);
                    }
                    else
                    {
                        treeViewDeserializado.Nodes.Add("Formato no reconocido");
                    }
                }
            }
            catch (Exception ex)
            {
                treeViewDeserializado.Nodes.Add($"Error al procesar: {ex.Message}");
            }
        }

        private void MostrarJSONEstructurado(string json)
        {
            try
            {
                // Parsear JSON y crear nodos del TreeView
                var token = JToken.Parse(json);

                if (token is JArray jArray)
                {
                    var rootNode = new TreeNode($"Array ({jArray.Count} elementos)");
                    treeViewDeserializado.Nodes.Add(rootNode);
                    CrearNodosJSONArray(jArray, rootNode);
                }
                else if (token is JObject jObject)
                {
                    var rootNode = new TreeNode("Objeto");
                    treeViewDeserializado.Nodes.Add(rootNode);
                    CrearNodosJSON(jObject, rootNode.Nodes);
                }
                else
                {
                    treeViewDeserializado.Nodes.Add($"Valor: {token}");
                }

                // Expandir el primer nivel
                foreach (TreeNode node in treeViewDeserializado.Nodes)
                {
                    node.Expand();
                }
            }
            catch (Exception ex)
            {
                treeViewDeserializado.Nodes.Add($"Error al parsear JSON: {ex.Message}");
            }
        }

        private void MostrarXMLEstructurado(string xml)
        {
            try
            {
                var xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.LoadXml(xml);

                var rootNode = xmlDoc.DocumentElement;
                var treeNode = new TreeNode(rootNode.Name);
                treeViewDeserializado.Nodes.Add(treeNode);

                CrearNodosXML(rootNode, treeNode);
            }
            catch (Exception ex)
            {
                treeViewDeserializado.Nodes.Add($"Error al parsear XML: {ex.Message}");
            }
        }

        private void CrearNodosJSON(JObject jObject, TreeNodeCollection nodes)
        {
            foreach (var property in jObject.Properties())
            {
                string nodeName = property.Name;
                string nodeValue = "";

                if (property.Value is JArray jArray)
                {
                    nodeName += $" (Array [{jArray.Count}])";
                    var node = new TreeNode(nodeName);
                    nodes.Add(node);
                    CrearNodosJSONArray(jArray, node);
                }
                else if (property.Value is JObject childObject)
                {
                    nodeName += " (Objeto)";
                    var node = new TreeNode(nodeName);
                    nodes.Add(node);
                    CrearNodosJSON(childObject, node.Nodes);
                }
                else
                {
                    nodeValue = property.Value?.ToString() ?? "null";

                    // Formatear valores especiales
                    if (property.Value?.Type == JTokenType.Date)
                    {
                        nodeValue = $"Fecha: {nodeValue}";
                    }
                    else if (property.Value?.Type == JTokenType.String && nodeValue.Contains("/Date("))
                    {
                        nodeValue = $"Fecha JSON: {nodeValue}";
                    }
                    else if (property.Value?.Type == JTokenType.Null)
                    {
                        nodeValue = "(null)";
                    }

                    var node = new TreeNode($"{nodeName}: {nodeValue}");
                    nodes.Add(node);
                }
            }
        }

        private void CrearNodosJSONArray(JArray jArray, TreeNode parentNode)
        {
            for (int i = 0; i < jArray.Count; i++)
            {
                var item = jArray[i];

                if (item is JObject jObject)
                {
                    var node = new TreeNode($"[{i}] Objeto");
                    parentNode.Nodes.Add(node);
                    CrearNodosJSON(jObject, node.Nodes);
                }
                else if (item is JArray innerArray)
                {
                    var node = new TreeNode($"[{i}] Array ({innerArray.Count})");
                    parentNode.Nodes.Add(node);
                    CrearNodosJSONArray(innerArray, node);
                }
                else
                {
                    string itemValue = item?.ToString() ?? "null";

                    // Formatear valores especiales en arrays
                    if (item?.Type == JTokenType.Date)
                    {
                        itemValue = $"Fecha: {itemValue}";
                    }
                    else if (item?.Type == JTokenType.String && itemValue.Contains("/Date("))
                    {
                        itemValue = $"Fecha JSON: {itemValue}";
                    }
                    else if (item?.Type == JTokenType.Null)
                    {
                        itemValue = "(null)";
                    }

                    var node = new TreeNode($"[{i}]: {itemValue}");
                    parentNode.Nodes.Add(node);
                }
            }
        }

        private void CrearNodosXML(System.Xml.XmlNode xmlNode, TreeNode treeNode)
        {
            foreach (System.Xml.XmlNode childNode in xmlNode.ChildNodes)
            {
                if (childNode.NodeType == System.Xml.XmlNodeType.Element)
                {
                    var node = new TreeNode(childNode.Name);
                    treeNode.Nodes.Add(node);

                    if (childNode.HasChildNodes)
                    {
                        CrearNodosXML(childNode, node);
                    }
                    else if (!string.IsNullOrEmpty(childNode.InnerText))
                    {
                        node.Nodes.Add(childNode.InnerText);
                    }
                }
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

        #endregion Eventos de Botones

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

        #endregion Idiomas
    }
}