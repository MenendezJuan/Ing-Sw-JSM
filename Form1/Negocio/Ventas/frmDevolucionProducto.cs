using BEs;
using BEs.Clases;
using BEs.Clases.Negocio.Enums;
using BEs.Clases.Negocio.Ventas;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix
{
    public partial class frmDevolucionProducto : Form, IObservador
    {
        private readonly BLL_DEVOLUCION _bllDevolucion;
        private readonly BLL_VENTA _bllVenta;
        private readonly BLL_CLIENTE _bllCliente;
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;

        public frmDevolucionProducto()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            _bllDevolucion = new BLL_DEVOLUCION();
            _bllVenta = new BLL_VENTA();
            _bllCliente = new BLL_CLIENTE();

            CargarIdiomas();
            sesion.RegistrarObservador(this); // Registrarse como observador para multiidioma
            Actualizar(sesion.Idioma);
            ConfigurarDataGrid();
            CargarFiltros();
            CargarDatos();

            if (sesion.Permisos != null && sesion.Permisos.Count > 0)
            {
                BuscarControles(this.Controls);
                Buscar(sesion.Permisos[0]);
            }
        }

        private void ConfigurarDataGrid()
        {
            // Configurar columnas del DataGrid
            dataGridViewDevoluciones.AutoGenerateColumns = false;
            dataGridViewDevoluciones.Columns.Clear();

            dataGridViewDevoluciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Nro. Devolución",
                Name = "NroDevolucion_Column",
                Tag = "grid_NroDevolucion_Column",
                Width = 120,
                ReadOnly = true
            });

            dataGridViewDevoluciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaSolicitud",
                HeaderText = "Fecha",
                Name = "Fecha_Column",
                Tag = "grid_Fecha_Column",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            dataGridViewDevoluciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCliente",
                HeaderText = "Cliente",
                Name = "Cliente_Column",
                Tag = "grid_Cliente_Column",
                Width = 150,
                ReadOnly = true
            });

            dataGridViewDevoluciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NumeroVenta",
                HeaderText = "Nro. Venta",
                Name = "NroVenta_Column",
                Tag = "grid_NroVenta_Column",
                Width = 100,
                ReadOnly = true
            });

            dataGridViewDevoluciones.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EstadoTexto",
                HeaderText = "Estado",
                Name = "Estado_Column",
                Tag = "grid_Estado_Column",
                Width = 120,
                ReadOnly = true
            });

            // Configurar estilos del DataGrid
            dataGridViewDevoluciones.BackgroundColor = System.Drawing.Color.White;
            dataGridViewDevoluciones.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dataGridViewDevoluciones.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridViewDevoluciones.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(32, 30, 45);
            dataGridViewDevoluciones.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewDevoluciones.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(32, 30, 45);
            dataGridViewDevoluciones.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridViewDevoluciones.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            dataGridViewDevoluciones.EnableHeadersVisualStyles = false;

            // Ocultar columna ID técnica
            if (dataGridViewDevoluciones.Columns.Contains("Id"))
            {
                dataGridViewDevoluciones.Columns["Id"].Visible = false;
            }
        }

        private void CargarFiltros()
        {
            try
            {
                // Cargar combo de clientes
                var clientes = _bllCliente.ObtenerTodos();
                var clienteDefault = new { Id = (int?)null, Nombre = "Todos los clientes" };
                var clientesCombo = new List<dynamic> { clienteDefault };
                clientesCombo.AddRange(clientes.Select(c => new { Id = (int?)c.Id, Nombre = c.NombreCompleto }));

                comboCliente.DataSource = clientesCombo;
                comboCliente.DisplayMember = "Nombre";
                comboCliente.ValueMember = "Id";
                comboCliente.SelectedIndex = 0;

                // Cargar combo de estados
                var estados = new List<dynamic>
                {
                    new { Id = (EstadoDevolucion?)null, Nombre = "Todos los estados" },
                    new { Id = (EstadoDevolucion?)EstadoDevolucion.Iniciada, Nombre = "Iniciada" },
                    new { Id = (EstadoDevolucion?)EstadoDevolucion.EnEvaluacion, Nombre = "En Evaluación" },
                    new { Id = (EstadoDevolucion?)EstadoDevolucion.Autorizada, Nombre = "Autorizada" },
                    new { Id = (EstadoDevolucion?)EstadoDevolucion.Rechazada, Nombre = "Rechazada" },
                    new { Id = (EstadoDevolucion?)EstadoDevolucion.Procesada, Nombre = "Procesada" }
                };

                comboEstado.DataSource = estados;
                comboEstado.DisplayMember = "Nombre";
                comboEstado.ValueMember = "Id";
                comboEstado.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar filtros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            try
            {
                var clienteId = comboCliente.SelectedValue as int?;
                var ventaId = string.IsNullOrWhiteSpace(txtNroVenta.Text) ? (int?)null : int.Parse(txtNroVenta.Text);
                var estado = comboEstado.SelectedValue as EstadoDevolucion?;

                var devoluciones = _bllDevolucion.Listar(clienteId, ventaId, estado);
                dataGridViewDevoluciones.DataSource = devoluciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevaDevolucion_Click(object sender, EventArgs e)
        {
            using (var frmDetalle = new frmDevolucionDetalle())
            {
                frmDetalle.Modo = ModoDevolucion.Iniciar;
                if (frmDetalle.ShowDialog() == DialogResult.OK)
                {
                    CargarDatos();
                }
            }
        }

        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            if (dataGridViewDevoluciones.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una devolución para evaluar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var devolucion = dataGridViewDevoluciones.CurrentRow.DataBoundItem as Devolucion;
            if (devolucion == null) return;

            if (devolucion.Estado == EstadoDevolucion.Iniciada && TienePermiso("Button_EvaluarDevolucion_GesDev"))
            {
                try
                {
                    _bllDevolucion.EnviarAEvaluacion(devolucion.Id, SessionManager.GetInstance().oUsuario.Id);
                    CargarDatos();
                    devolucion = _bllDevolucion.ObtenerPorId(devolucion.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo enviar a evaluación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (devolucion.Estado != EstadoDevolucion.EnEvaluacion)
            {
                MessageBox.Show("Solo se pueden evaluar devoluciones en estado 'En Evaluación'.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var frmDetalle = new frmDevolucionDetalle())
            {
                frmDetalle.DevolucionId = devolucion.Id;
                frmDetalle.Modo = ModoDevolucion.Evaluar;
                if (frmDetalle.ShowDialog() == DialogResult.OK)
                {
                    CargarDatos();
                }
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (dataGridViewDevoluciones.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una devolución para procesar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var devolucion = dataGridViewDevoluciones.CurrentRow.DataBoundItem as Devolucion;
            if (devolucion == null) return;

            if (devolucion.Estado != EstadoDevolucion.Autorizada)
            {
                MessageBox.Show("Solo se pueden procesar devoluciones autorizadas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var frmDetalle = new frmDevolucionDetalle())
            {
                frmDetalle.DevolucionId = devolucion.Id;
                frmDetalle.Modo = ModoDevolucion.Procesar;
                if (frmDetalle.ShowDialog() == DialogResult.OK)
                {
                    CargarDatos();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            comboCliente.SelectedIndex = 0;
            txtNroVenta.Text = string.Empty;
            comboEstado.SelectedIndex = 0;
            CargarDatos();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            try
            {
                CheeseLogix.Negocio.Ventas.frmHistorialDevoluciones frmHistorial = new CheeseLogix.Negocio.Ventas.frmHistorialDevoluciones();
                frmHistorial.ShowDialog();
                
                // Refrescar la lista después de cerrar el historial
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir historial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewDevoluciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var devolucion = dataGridViewDevoluciones.Rows[e.RowIndex].DataBoundItem as Devolucion;
                if (devolucion == null) return;

                using (var frmDetalle = new frmDevolucionDetalle())
                {
                    // Determinar modo según estado y permisos del usuario
                    if (devolucion.Estado == EstadoDevolucion.Iniciada && TienePermiso("Button_EvaluarDevolucion_GesDev"))
                    {
                        // Transicionar automáticamente a 'En Evaluación'
                        try
                        {
                            _bllDevolucion.EnviarAEvaluacion(devolucion.Id, SessionManager.GetInstance().oUsuario.Id);
                            devolucion = _bllDevolucion.ObtenerPorId(devolucion.Id);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"No se pudo enviar a evaluación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        frmDetalle.DevolucionId = devolucion.Id;
                        frmDetalle.Modo = ModoDevolucion.Evaluar;
                    }
                    else if (devolucion.Estado == EstadoDevolucion.Autorizada && TienePermiso("Button_ProcesarDevolucion_GesDev"))
                    {
                        frmDetalle.DevolucionId = devolucion.Id;
                        frmDetalle.Modo = ModoDevolucion.Procesar;
                    }
                    else
                    {
                        frmDetalle.DevolucionId = devolucion.Id;
                        frmDetalle.Modo = ModoDevolucion.Ver;
                    }

                    if (frmDetalle.ShowDialog() == DialogResult.OK)
                    {
                        CargarDatos();
                    }
                }
            }
        }

        private bool TienePermiso(string permiso)
        {
            if (sesion?.Permisos == null) return false;
            foreach (var raiz in sesion.Permisos)
            {
                if (ContienePermisoRecursivo(raiz, permiso)) return true;
            }
            return false;
        }

        private bool ContienePermisoRecursivo(Componente componente, string permisoBuscado)
        {
            if (componente == null) return false;
            if (string.Equals(componente.Nombre, permisoBuscado, StringComparison.OrdinalIgnoreCase)) return true;

            if (componente is GrupoPermisos grupo && grupo.Permisos != null)
            {
                foreach (var hijo in grupo.Permisos)
                {
                    if (ContienePermisoRecursivo(hijo, permisoBuscado)) return true;
                }
            }
            return false;
        }

        private void CargarIdiomas()
        {
            try
            {
                var idiomas = Bll_Idioma.ListarTodos();
                cboxIdiomas.DataSource = idiomas;
                cboxIdiomas.DisplayMember = "Nombre";
                cboxIdiomas.ValueMember = "Id";

                if (sesion.Idioma != null)
                {
                    cboxIdiomas.SelectedValue = sesion.Idioma.Id;
                }
                else
                {
                    var idiomaPredeterminado = idiomas.FirstOrDefault(i => i.Nombre == "Español");
                    if (idiomaPredeterminado != null)
                    {
                        cboxIdiomas.SelectedValue = idiomaPredeterminado.Id;
                    }
                }

                cboxIdiomas.SelectedIndexChanged += CboxIdiomas_SelectedIndexChanged;
            }
            catch { }
        }

        private void CboxIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxIdiomas.SelectedItem is IIdioma idiomaSeleccionado)
            {
                sesion.CambiarIdioma(idiomaSeleccionado);
            }
        }

        public void Actualizar(IIdioma idioma)
        {
            foreach (Control control in ListaControles)
            {
                if (control.Tag != null)
                {
                    string traduccion = Bll_Traduccion.BuscarTraduccion(control.Tag.ToString(), idioma.Id);
                    if (!string.IsNullOrEmpty(traduccion)) control.Text = traduccion;
                }
            }
            RecorrerDataGridTraduccion(idioma);
            if (cboxIdiomas.DataSource != null && cboxIdiomas.Items.Count > 0 && cboxIdiomas.ValueMember != string.Empty)
            {
                cboxIdiomas.SelectedValue = idioma.Id;
            }
        }

        public void RecorrerDataGridTraduccion(IIdioma idioma)
        {
            foreach (Control control in ListaControles)
            {
                if (control is DataGridView dataGridView)
                {
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Tag != null)
                        {
                            string traduccion = Bll_Traduccion.BuscarTraduccion(column.Tag.ToString(), idioma.Id);
                            if (!string.IsNullOrEmpty(traduccion)) column.HeaderText = traduccion;
                        }
                    }
                }
            }
        }

        private List<Control> ListaControles = new List<Control>();

        public void BuscarControles(System.Collections.ICollection controles)
        {
            foreach (Control control in controles)
            {
                ListaControles.Add(control);
                if (control.Controls.Count > 0) BuscarControles(control.Controls);
            }
        }

        public void Buscar(BEs.Clases.Componente componente)
        {
            GrupoPermisos grupo = (GrupoPermisos)componente;
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

        public void Comprobar(BEs.Clases.Componente p)
        {
            foreach (Control control in ListaControles)
            {
                if (control.Tag != null && control.Tag.ToString() == p.Nombre)
                {
                    control.Visible = true;
                    control.Enabled = true;
                }
            }
        }
    }
}
