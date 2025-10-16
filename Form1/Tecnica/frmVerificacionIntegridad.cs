using BEs;
using BEs.Interfaces;
using BLLs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CheeseLogix.Tecnica
{
    public partial class frmVerificacionIntegridad : Form, IObservador
    {
        private SessionManager _sesion;
        private BLL_IDIOMA _bllIdioma;
        private BLL_TRADUCCION _bllTraduccion;
        private BLL_INTEGRIDAD _bllIntegridad;
        private List<InconsistenciaIntegridad> _inconsistencias;
        private List<Control> _listaControles = new List<Control>();

        public frmVerificacionIntegridad()
        {
            InitializeComponent();
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            _sesion = SessionManager.GetInstance();
            _bllIdioma = new BLL_IDIOMA();
            _bllTraduccion = new BLL_TRADUCCION();
            _bllIntegridad = new BLL_INTEGRIDAD();
            _inconsistencias = new List<InconsistenciaIntegridad>();

            ConfigurarDataGridView();
            ConfigurarEstilos();

            _sesion.RegistrarObservador(this);
            BuscarControles(this.Controls);
            Actualizar(_sesion.Idioma);
        }

        private void BuscarControles(ICollection controles)
        {
            foreach (Control c in controles)
            {
                _listaControles.Add(c);
                if (c.HasChildren)
                {
                    BuscarControles(c.Controls);
                }
            }
        }

        private void ConfigurarDataGridView()
        {
            dataGridViewInconsistencias.AutoGenerateColumns = false;
            dataGridViewInconsistencias.AllowUserToAddRows = false;
            dataGridViewInconsistencias.AllowUserToDeleteRows = false;
            dataGridViewInconsistencias.ReadOnly = true;
            dataGridViewInconsistencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewInconsistencias.MultiSelect = false;
            dataGridViewInconsistencias.RowHeadersVisible = false;
            dataGridViewInconsistencias.BackgroundColor = Color.White;

            dataGridViewInconsistencias.DataError += (s, e) =>
            {
                e.ThrowException = false;
            };

            dataGridViewInconsistencias.Columns.Clear();

            dataGridViewInconsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TipoEntidad",
                HeaderText = "Tipo de Entidad",
                DataPropertyName = "TipoEntidad",
                Width = 120,
                ReadOnly = true
            });

            dataGridViewInconsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EntidadId",
                HeaderText = "ID",
                DataPropertyName = "EntidadId",
                Width = 60,
                ReadOnly = true
            });

            dataGridViewInconsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Descripcion",
                HeaderText = "Descripción",
                DataPropertyName = "Descripcion",
                Width = 300,
                ReadOnly = true
            });

            dataGridViewInconsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DVEsperado",
                HeaderText = "DV Esperado",
                DataPropertyName = "DVEsperado",
                Width = 100,
                ReadOnly = true
            });

            dataGridViewInconsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DVActual",
                HeaderText = "DV Actual",
                DataPropertyName = "DVActual",
                Width = 100,
                ReadOnly = true
            });

            dataGridViewInconsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TipoError",
                HeaderText = "Tipo de Error",
                DataPropertyName = "TipoError",
                Width = 120,
                ReadOnly = true
            });

            dataGridViewInconsistencias.SelectionChanged += DataGridViewInconsistencias_SelectionChanged;
        }

        private void ConfigurarEstilos()
        {
            // Colores consistentes con el resto de la aplicación
            this.BackColor = ColorTranslator.FromHtml("#201E2D");

            panelHeader.BackColor = ColorTranslator.FromHtml("#201E2D");
            panelControles.BackColor = ColorTranslator.FromHtml("#201E2D");
            panelResultados.BackColor = ColorTranslator.FromHtml("#2C2A3B");

            lblTitulo.ForeColor = Color.White;
            lblEstadoIntegridad.ForeColor = Color.White;
            lblInconsistenciasEncontradas.ForeColor = Color.White;
            lblDetalleEntidad.ForeColor = Color.White;

            btnVerificar.BackColor = ColorTranslator.FromHtml("#3F3D56");
            btnVerificar.ForeColor = Color.White;
            btnVerificar.FlatStyle = FlatStyle.Flat;
            btnVerificar.FlatAppearance.BorderSize = 0;

            btnRestaurarSeleccionado.BackColor = ColorTranslator.FromHtml("#4CAF50");
            btnRestaurarSeleccionado.ForeColor = Color.White;
            btnRestaurarSeleccionado.FlatStyle = FlatStyle.Flat;
            btnRestaurarSeleccionado.FlatAppearance.BorderSize = 0;
            btnRestaurarSeleccionado.Enabled = false;

            btnRestaurarTodos.BackColor = ColorTranslator.FromHtml("#FF9800");
            btnRestaurarTodos.ForeColor = Color.White;
            btnRestaurarTodos.FlatStyle = FlatStyle.Flat;
            btnRestaurarTodos.FlatAppearance.BorderSize = 0;
            btnRestaurarTodos.Enabled = false;

            btnCerrar.BackColor = ColorTranslator.FromHtml("#F44336");
            btnCerrar.ForeColor = Color.White;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.FlatAppearance.BorderSize = 0;

            dataGridViewInconsistencias.BackgroundColor = Color.White;
            dataGridViewInconsistencias.GridColor = ColorTranslator.FromHtml("#E0E0E0");
            dataGridViewInconsistencias.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#3F3D56");
            dataGridViewInconsistencias.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewInconsistencias.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2C2A3B");
            dataGridViewInconsistencias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewInconsistencias.EnableHeadersVisualStyles = false;

            txtDetalleEntidad.BackColor = Color.White;
            txtDetalleEntidad.BorderStyle = BorderStyle.FixedSingle;
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                btnVerificar.Enabled = false;

                _inconsistencias.Clear();

                bool integridadOK = _bllIntegridad.VerificarIntegridadBaseDatos(out List<InconsistenciaIntegridad> errores);

                if (integridadOK)
                {
                    lblEstadoIntegridad.Text = "Integridad verificada correctamente";
                    lblEstadoIntegridad.ForeColor = Color.LimeGreen;
                    lblInconsistenciasEncontradas.Text = "Inconsistencias encontradas: 0";

                    MessageBox.Show(
                        "La verificación de integridad se completó exitosamente.\n\n" +
                        "No se encontraron inconsistencias en los dígitos verificadores.",
                        "Verificación Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    btnRestaurarSeleccionado.Enabled = false;
                    btnRestaurarTodos.Enabled = false;
                }
                else
                {
                    _inconsistencias = errores ?? new List<InconsistenciaIntegridad>();

                    lblEstadoIntegridad.Text = "⚠ Se encontraron inconsistencias";
                    lblEstadoIntegridad.ForeColor = Color.OrangeRed;
                    lblInconsistenciasEncontradas.Text = $"Inconsistencias encontradas: {_inconsistencias.Count}";

                    try
                    {
                        dataGridViewInconsistencias.DataSource = null;
                        dataGridViewInconsistencias.Refresh();
                        dataGridViewInconsistencias.DataSource = _inconsistencias;
                        dataGridViewInconsistencias.Refresh();
                    }
                    catch (Exception dgvEx)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error al asignar DataSource: {dgvEx.Message}");
                        // Si falla, limpiar completamente
                        dataGridViewInconsistencias.DataSource = null;
                        dataGridViewInconsistencias.Rows.Clear();
                    }

                    btnRestaurarSeleccionado.Enabled = _inconsistencias.Count > 0;
                    btnRestaurarTodos.Enabled = _inconsistencias.Count > 0;

                    MessageBox.Show(
                        $"⚠ Se encontraron {_inconsistencias.Count} inconsistencia(s) en los dígitos verificadores.\n\n" +
                        "Revise los detalles y proceda con la restauración.",
                        "Inconsistencias Detectadas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al verificar integridad:\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                Cursor = Cursors.Default;
                btnVerificar.Enabled = true;
            }
        }

        private void btnRestaurarSeleccionado_Click(object sender, EventArgs e)
        {
            if (dataGridViewInconsistencias.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Debe seleccionar una inconsistencia para restaurar.",
                    "Selección requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            var inconsistencia = dataGridViewInconsistencias.SelectedRows[0].DataBoundItem as InconsistenciaIntegridad;
            if (inconsistencia == null) return;

            var resultado = MessageBox.Show(
                $"¿Está seguro que desea restaurar el dígito verificador de:\n\n" +
                $"Entidad: {inconsistencia.TipoEntidad}\n" +
                $"ID: {inconsistencia.EntidadId}\n" +
                $"Descripción: {inconsistencia.Descripcion}\n\n" +
                $"Esto recalculará el DV basándose en los datos actuales de la entidad.",
                "Confirmar Restauración",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                RestaurarDigitoVerificador(inconsistencia);
            }
        }

        private void btnRestaurarTodos_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                $"🔄 SINCRONIZACIÓN COMPLETA 🔄\n\n" +
                $"Esta operación:\n" +
                $"1. Recalculará TODOS los DVH usando el algoritmo del código\n" +
                $"2. Recalculará TODOS los DVV basándose en los DVH nuevos\n" +
                $"3. Sincronizará completamente BD con código\n\n" +
                $"Esto puede tomar unos momentos.\n\n" +
                $"¿Continuar?",
                "Sincronizar BD con Código",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                SincronizarCompletamente();
            }
        }

        private void SincronizarCompletamente()
        {
            if (_inconsistencias == null || _inconsistencias.Count == 0)
            {
                MessageBox.Show(
                    "No hay inconsistencias para sincronizar.",
                    "Sin inconsistencias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            var resultado = MessageBox.Show(
                $"🔄 SINCRONIZAR BD CON CÓDIGO 🔄\n\n" +
                $"Esta operación reemplazará {_inconsistencias.Count} DVH inconsistentes\n" +
                $"con los valores calculados por el código.\n\n" +
                $"Los valores actuales (incorrectos) serán reemplazados\n" +
                $"con los valores esperados (correctos).\n\n" +
                $"¿Continuar?",
                "Sincronizar BD con Código",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                RestaurarTodosLosDigitosVerificadores();
            }
        }

        private void RestaurarDigitoVerificador(InconsistenciaIntegridad inconsistencia)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // Restaurar usando la BLL
                bool restaurado = _bllIntegridad.RestaurarDigitoVerificador(inconsistencia);

                if (restaurado)
                {
                    MessageBox.Show(
                        $"✓ Dígito verificador restaurado exitosamente.\n\n" +
                        $"Entidad: {inconsistencia.TipoEntidad} (ID: {inconsistencia.EntidadId})",
                        "Restauración Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Volver a verificar
                    btnVerificar_Click(null, null);
                }
                else
                {
                    MessageBox.Show(
                        $"No se pudo restaurar el dígito verificador.\n\n" +
                        $"Verifique que la entidad existe en la base de datos.",
                        "Error de Restauración",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al restaurar dígito verificador:\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void RestaurarTodosLosDigitosVerificadores()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                btnRestaurarTodos.Enabled = false;

                if (_inconsistencias == null || _inconsistencias.Count == 0)
                {
                    MessageBox.Show(
                        "No hay inconsistencias para restaurar.",
                        "Sin inconsistencias",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                // Restaurar todos usando la BLL
                var resultado = _bllIntegridad.RestaurarTodosDigitosVerificadores(_inconsistencias);
                int exitosos = resultado.exitosos;
                int fallidos = resultado.fallidos;

                MessageBox.Show(
                    $"Restauración masiva completada:\n\n" +
                    $"✓ Exitosos: {exitosos}\n" +
                    $"✗ Fallidos: {fallidos}\n\n" +
                    $"Total procesados: {_inconsistencias.Count}",
                    "Restauración Masiva Completada",
                    MessageBoxButtons.OK,
                    fallidos > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information
                );

                // Volver a verificar
                btnVerificar_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error durante la restauración masiva:\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                Cursor = Cursors.Default;
                btnRestaurarTodos.Enabled = true;
            }
        }

        private void DataGridViewInconsistencias_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewInconsistencias.Rows.Count == 0 ||
                    dataGridViewInconsistencias.SelectedRows.Count == 0)
                {
                    txtDetalleEntidad.Clear();
                    return;
                }

                var selectedRow = dataGridViewInconsistencias.SelectedRows[0];
                if (selectedRow?.DataBoundItem is InconsistenciaIntegridad inconsistencia)
                {
                    MostrarDetalleEntidad(inconsistencia);
                }
                else
                {
                    txtDetalleEntidad.Clear();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en SelectionChanged: {ex.Message}");
                txtDetalleEntidad.Clear();
            }
        }

        private void MostrarDetalleEntidad(InconsistenciaIntegridad inconsistencia)
        {
            string detalle = _bllIntegridad.ObtenerDetalleEntidadFormateado(inconsistencia);

            txtDetalleEntidad.Clear();
            txtDetalleEntidad.Text = detalle;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVerificacionIntegridad_Load(object sender, EventArgs e)
        {
            lblEstadoIntegridad.Text = "Presione 'Verificar Integridad' para iniciar";
            lblEstadoIntegridad.ForeColor = Color.White;
            lblInconsistenciasEncontradas.Text = "Inconsistencias encontradas: -";
            txtDetalleEntidad.Text = "Seleccione una inconsistencia para ver detalles.";
        }

        public void Actualizar(IIdioma idioma)
        {
            foreach (Control control in _listaControles)
            {
                if (control.Tag != null)
                {
                    string traduccion = _bllTraduccion.BuscarTraduccion(control.Tag.ToString(), idioma.Id);
                    if (!string.IsNullOrEmpty(traduccion))
                    {
                        control.Text = traduccion;
                    }
                }
            }
        }

        private void frmVerificacionIntegridad_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sesion?.DesregistrarObservador(this);
        }
    }
}
