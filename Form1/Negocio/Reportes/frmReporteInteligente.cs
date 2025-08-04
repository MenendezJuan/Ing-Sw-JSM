using BEs;
using BEs.Interfaces;
using BLLs;
using BLLs.Negocio;
using BLLs.Tecnica;
using Microsoft.Reporting.WinForms; 
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        private BLL_EXPORTACION Bll_Exportacion;

        public frmReporteInteligente()
        {
            InitializeComponent();
            sesion = SessionManager.GetInstance();
            Bll_Idioma = new BLL_IDIOMA();
            Bll_Traduccion = new BLL_TRADUCCION();
            Bll_Reportes = new BLL_REPORTES();
            Bll_Exportacion = new BLL_EXPORTACION();

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

                // PRIMERO: Cargar el reporte usando rutas relativas
                bool reporteCargado = false;
                try 
                {
                    // Obtener la ruta del archivo RDLC
                    string rutaReporte = BLL_CONFIGURACION.ObtenerRutaAbsolutaRDLC();
                    
                    // Verificar que el archivo existe
                    if (File.Exists(rutaReporte))
                    {
                        // Usar ReportPath para archivos físicos
                        reportViewer1.LocalReport.ReportPath = rutaReporte;
                        reporteCargado = true;
                    }
                    else
                    {
                        // Intentar como recurso embebido si no se encuentra el archivo físico
                        try
                        {
                            string rutaEmbebida = BLL_CONFIGURACION.ObtenerRutaReporteVentas();
                            reportViewer1.LocalReport.ReportEmbeddedResource = rutaEmbebida;
                            reporteCargado = true;
                        }
                        catch
                        {
                            // Mostrar información detallada para depuración
                            string mensaje = $"No se pudo cargar el reporte RDLC.\n\n" +
                                           $"Archivo físico intentado: {rutaReporte}\n" +
                                           $"Directorio actual: {Environment.CurrentDirectory}\n" +
                                           $"Directorio base: {AppDomain.CurrentDomain.BaseDirectory}\n\n" +
                                           $"Por favor, verifica que el archivo ReporteVentas.rdlc esté en la ubicación correcta.";
                            
                            MessageBox.Show(mensaje, "Error de carga de reporte", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Salir si no se puede cargar el reporte
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el reporte: {ex.Message}", 
                        "Error de carga de reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir si hay error
                }

                // Solo continuar si el reporte se cargó correctamente
                if (!reporteCargado)
                {
                    MessageBox.Show("No se pudo cargar el reporte. Verifique la configuración.", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // SEGUNDO: Obtener datos para los reportes usando métodos optimizados
                DataTable productosMasVendidos = Bll_Reportes.ObtenerProductosTopReporte(fechaInicio, fechaFin, 10);
                DataTable clientesMejores = Bll_Reportes.ObtenerClientesTopGrafico(fechaInicio, fechaFin, 5);
                DataTable ventasPorMes = Bll_Reportes.ObtenerVentasPorMes(fechaFin.Year);

                // Los nuevos métodos ya devuelven las columnas con los nombres correctos
                // Solo ajustar las de ventas por mes si es necesario
                if (ventasPorMes.Columns.Contains("NombreMes") && !ventasPorMes.Columns.Contains("Mes"))
                    ventasPorMes.Columns["NombreMes"].ColumnName = "Mes";
                
                if (ventasPorMes.Columns.Contains("NumeroVentas") && !ventasPorMes.Columns.Contains("CantidadVentas"))
                    ventasPorMes.Columns["NumeroVentas"].ColumnName = "CantidadVentas";

                // TERCERO: Configurar ReportViewer con datos reales
                reportViewer1.LocalReport.DataSources.Clear();
                
                ReportDataSource dataSourceProductos = new ReportDataSource("ProductosMasVendidos", productosMasVendidos);
                ReportDataSource dataSourceClientes = new ReportDataSource("ClientesMejores", clientesMejores);
                ReportDataSource dataSourceVentasMes = new ReportDataSource("VentasPorMes", ventasPorMes);
                
                reportViewer1.LocalReport.DataSources.Add(dataSourceProductos);
                reportViewer1.LocalReport.DataSources.Add(dataSourceClientes);
                reportViewer1.LocalReport.DataSources.Add(dataSourceVentasMes);
                
                // CUARTO: Configurar parámetros de fecha (DESPUÉS de cargar el reporte)
                ReportParameter paramFechaInicio = new ReportParameter("FechaInicio", fechaInicio.ToString("dd/MM/yyyy"));
                ReportParameter paramFechaFin = new ReportParameter("FechaFin", fechaFin.ToString("dd/MM/yyyy"));
                
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { paramFechaInicio, paramFechaFin });
                
                // QUINTO: Refrescar el reporte
                reportViewer1.RefreshReport();
                

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

        private void frmReporteInteligente_Load_1(object sender, EventArgs e)
        {
        }

        #region Exportación

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                // Usar un método alternativo para exportar PDF que evita el error PInvokeStackImbalance
                string nombreArchivo = Bll_Exportacion.GenerarNombreArchivoUnico(BLL_CONFIGURACION.ObtenerPrefijoPDFReporte());
                string rutaCompleta = Path.Combine(BLL_CONFIGURACION.ObtenerDirectorioReporteria(), $"{nombreArchivo}.pdf");
                
                // Asegurar que el directorio exista
                string directorio = Path.GetDirectoryName(rutaCompleta);
                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                // Mostrar un mensaje de espera
                using (Form waitForm = new Form())
                {
                    Label waitLabel = new Label
                    {
                        Text = "Exportando reporte a PDF...\nEsto puede tardar unos segundos.",
                        AutoSize = false,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill
                    };
                    waitForm.Controls.Add(waitLabel);
                    waitForm.Size = new System.Drawing.Size(300, 100);
                    waitForm.StartPosition = FormStartPosition.CenterParent;
                    waitForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    waitForm.ControlBox = false;
                    waitForm.Text = "Exportando...";
                    
                    // Mostrar el formulario de espera en un hilo separado
                    System.Threading.Thread thread = new System.Threading.Thread(() => {
                        waitForm.ShowDialog();
                    });
                    thread.Start();
                    
                    try
                    {
                        // Usar el método mejorado de exportación
                        bool resultado = Bll_Exportacion.ExportarReporteAPDF(reportViewer1, nombreArchivo);
                        
                        // Cerrar el formulario de espera
                        waitForm.Invoke(new Action(() => { waitForm.Close(); }));
                        thread.Join();
                        
                        if (resultado)
                        {
                            MessageBox.Show($"Reporte exportado exitosamente a:\n{rutaCompleta}", 
                                "Exportación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            // Preguntar si desea abrir el archivo
                            if (MessageBox.Show("¿Desea abrir el archivo PDF?", "Abrir archivo", 
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Bll_Exportacion.AbrirArchivo(rutaCompleta);
                            }
                        }
                    }
                    catch
                    {
                        // Asegurar que el formulario de espera se cierre en caso de error
                        if (waitForm.IsHandleCreated && !waitForm.IsDisposed)
                            waitForm.Invoke(new Action(() => { waitForm.Close(); }));
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar PDF: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Forzar liberación de recursos
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener datos actuales
                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;
                
                DataTable productosMasVendidos = Bll_Reportes.ObtenerProductosTopReporte(fechaInicio, fechaFin);
                DataTable clientesMejores = Bll_Reportes.ObtenerClientesTopGrafico(fechaInicio, fechaFin);
                DataTable ventasPorMes = Bll_Reportes.ObtenerVentasPorMes(fechaFin.Year);

                string nombreArchivo = Bll_Exportacion.GenerarNombreArchivoUnico(BLL_CONFIGURACION.ObtenerPrefijoExcelReporte());
                string rutaCompleta = Path.Combine(BLL_CONFIGURACION.ObtenerDirectorioReporteria(), $"{nombreArchivo}.xlsx");

                var datosParaExportar = new[]
                {
                    (productosMasVendidos, "Productos Más Vendidos", "📊 PRODUCTOS MÁS VENDIDOS"),
                    (clientesMejores, "Mejores Clientes", "👥 MEJORES CLIENTES"),
                    (ventasPorMes, "Ventas por Mes", "📈 VENTAS POR MES")
                };

                if (Bll_Exportacion.ExportarMultiplesDataTablesAExcel(nombreArchivo, datosParaExportar))
                {
                    MessageBox.Show($"Reporte exportado exitosamente a:\n{rutaCompleta}", 
                        "Exportación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Abrir el archivo Excel
                    Bll_Exportacion.AbrirArchivo(rutaCompleta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar Excel: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #endregion

    }
}
