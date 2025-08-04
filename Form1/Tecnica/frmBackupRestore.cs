using BEs;
using BEs.Clases;
using BEs.Interfaces;
using BLLs;
using BLLs.Tecnica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix.Tecnica
{
    public partial class frmBackupRestore : Form, IObservador
    {
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        private BLL_BACKUP Bll_Backup;
        private string backupDirectory;

        public frmBackupRestore()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            Bll_Backup = new BLL_BACKUP();

            // Configurar directorio de backup desde configuración
            try
            {
                backupDirectory = BLL_CONFIGURACION.ObtenerDirectorioBackups();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener directorio de backups: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Fallback al directorio por defecto
                backupDirectory = Path.Combine("C:", "CheeseLogix", "Backups");
                Directory.CreateDirectory(backupDirectory);
            }

            // Cargar backups disponibles
            CargarBackupsDisponibles();

            sesion.RegistrarObservador(this);
            IIdioma oIdioma = sesion.Idioma;
            CargarIdiomas();
            Actualizar(oIdioma);
            if (sesion.Permisos != null)
            {
                BuscarControles(this.Controls);
                Buscar(sesion.Permisos[0]);
            }
        }

        #region Métodos de Backup y Restore

        private void CrearDirectorioBackupSiNoExiste()
        {
            try
            {
                if (!Directory.Exists(backupDirectory))
                {
                    Directory.CreateDirectory(backupDirectory);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el directorio de backup: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarBackupsDisponibles()
        {
            try
            {
                cmbBackupDisponibles.Items.Clear();

                if (Directory.Exists(backupDirectory))
                {
                    string[] backupFiles = Directory.GetFiles(backupDirectory, "*.bak");

                    foreach (string file in backupFiles)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        FileInfo fileInfo = new FileInfo(file);

                        string displayText = $"{fileName} - {fileInfo.CreationTime:dd/MM/yyyy HH:mm}";
                        cmbBackupDisponibles.Items.Add(new BackupItem { FileName = fileName, FilePath = file, DisplayText = displayText });
                    }

                    cmbBackupDisponibles.DisplayMember = "DisplayText";

                    if (cmbBackupDisponibles.Items.Count > 0)
                    {
                        cmbBackupDisponibles.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los backups disponibles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener nombre del backup
                string nombreBackup = ObtenerNombreBackupDelFormulario();

                if (string.IsNullOrWhiteSpace(nombreBackup))
                {
                    MessageBox.Show("Por favor, ingrese un nombre para el backup.", "Nombre requerido",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear backup a través de la BLL
                string rutaCompleta = Bll_Backup.CrearBackup(nombreBackup, backupDirectory);

                MessageBox.Show($"Backup creado exitosamente:\n{Path.GetFileName(rutaCompleta)}", "Backup completado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar lista de backups disponibles
                CargarBackupsDisponibles();

                // Limpiar campo de nombre
                LimpiarCampoNombreBackup();
            }
            catch (InvalidOperationException ex)
            {
                // Error de negocio - mostrar opción de sobrescribir
                if (ex.Message.Contains("Ya existe un backup"))
                {
                    var resultado = MessageBox.Show($"{ex.Message}\n\n¿Desea sobrescribirlo?",
                        "Backup existente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        // Permitir sobrescribir eliminando el archivo existente
                        SobrescribirBackupExistente();
                    }
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error de validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el backup: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Métodos auxiliares para el formulario
        private string ObtenerNombreBackupDelFormulario()
        {
            return txtNombreBackup.Text.Trim();
        }

        private void LimpiarCampoNombreBackup()
        {
            txtNombreBackup.Text = string.Empty;
        }

        private void SobrescribirBackupExistente()
        {
            try
            {
                string nombreBackup = ObtenerNombreBackupDelFormulario();

                // Crear nombre completo con fecha
                string fechaActual = DateTime.Now.ToString("ddMMyyyy");
                string nombreCompleto = $"{nombreBackup}_{fechaActual}";
                string rutaCompleta = Path.Combine(backupDirectory, $"{nombreCompleto}.bak");

                // Eliminar archivo existente
                if (File.Exists(rutaCompleta))
                {
                    File.Delete(rutaCompleta);
                }

                // Crear nuevo backup
                string rutaBackup = Bll_Backup.CrearBackup(nombreBackup, backupDirectory);

                MessageBox.Show($"Backup sobrescrito exitosamente:\n{Path.GetFileName(rutaBackup)}", "Backup completado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar lista y limpiar campo
                CargarBackupsDisponibles();
                LimpiarCampoNombreBackup();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al sobrescribir el backup: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBackupDisponibles.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un backup para restaurar.", "Backup no seleccionado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BackupItem selectedBackup = (BackupItem)cmbBackupDisponibles.SelectedItem;

                var resultado = MessageBox.Show(
                    $"¿Está seguro que desea restaurar el backup '{selectedBackup.FileName}'?\n\n" +
                    "ADVERTENCIA: Esta operación reemplazará completamente la base de datos actual. " +
                    "Todos los datos no guardados se perderán.",
                    "Confirmar restauración",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    // Restaurar a través de la BLL
                    bool exitoso = Bll_Backup.RestaurarBackup(selectedBackup.FilePath);

                    if (exitoso)
                    {
                        MessageBox.Show("Base de datos restaurada exitosamente.", "Restauración completada",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("La restauración no se completó correctamente.", "Error en restauración",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al restaurar el backup: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #endregion

        #region Eventos

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbBackupDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aquí podrías mostrar información adicional del backup seleccionado
        }

        #endregion

        #region Gestión de Idiomas y Permisos

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

        #endregion
    }

    #region Clase auxiliar para items de backup

    public class BackupItem
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string DisplayText { get; set; }
    }

    #endregion
}
