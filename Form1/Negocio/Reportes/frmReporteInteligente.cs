using BEs;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using BLLs.Tecnica;
using Microsoft.Reporting.WinForms; 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CheeseLogix.Negocio.Reportes
{
    public partial class frmReporteInteligente : Form, IObservador
    {
        private SessionManager sesion;
        private BLL_IDIOMA Bll_Idioma;
        private BLL_TRADUCCION Bll_Traduccion;
        private BLL_REPORTES Bll_Reportes;

        public frmReporteInteligente()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            Bll_Reportes = new BLL_REPORTES();

            sesion.RegistrarObservador(this);
            IIdioma oIdioma = sesion.Idioma;
            CargarIdiomas();
            Actualizar(oIdioma);
            
            ConfigurarReporte();
        }

        private void ConfigurarReporte()
        {
            try
            {
                // Configurar fechas por defecto (último mes)
                DateTime fechaFin = DateTime.Now;
                DateTime fechaInicio = fechaFin.AddMonths(-1);
                
                dtpFechaInicio.Value = fechaInicio;
                dtpFechaFin.Value = fechaFin;

                GenerarReporte();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar reporte: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarReporte()
        {
            try
            {
                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;

                // Obtener datos para los reportes
                DataTable productosMasVendidos = Bll_Reportes.ObtenerProductosMasVendidos(fechaInicio, fechaFin);
                DataTable clientesMejores = Bll_Reportes.ObtenerClientesMejores(fechaInicio, fechaFin);
                DataTable ventasPorMes = Bll_Reportes.ObtenerVentasPorMes(fechaFin.Year);

                // TODO: Configurar ReportViewer cuando se resuelvan las referencias
                // Por ahora mostramos información temporal
                Label lblTemporal = new Label();
                lblTemporal.Text = "🔧 Panel de Reportes (En desarrollo)\n\n" +
                                  "📊 Productos más vendidos: " + productosMasVendidos.Rows.Count + " registros\n" +
                                  "👥 Clientes mejores: " + clientesMejores.Rows.Count + " registros\n" +
                                  "📈 Ventas por mes: " + ventasPorMes.Rows.Count + " registros\n\n" +
                                  "Se implementará ReportViewer en siguiente versión";
                lblTemporal.Dock = DockStyle.Fill;
                lblTemporal.ForeColor = System.Drawing.Color.White;
                lblTemporal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lblTemporal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
                
                reportViewer.Controls.Clear();
                reportViewer.Controls.Add(lblTemporal);

                // Generar recomendaciones
                var recomendaciones = Bll_Reportes.GenerarRecomendaciones();
                txtRecomendaciones.Text = string.Join(Environment.NewLine + Environment.NewLine, recomendaciones);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void frmReporteInteligente_Load(object sender, EventArgs e)
        {

        }
    }
}
