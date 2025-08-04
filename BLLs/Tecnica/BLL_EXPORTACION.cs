using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.IO;
using Microsoft.Reporting.WinForms;

namespace BLLs.Tecnica
{
    public class BLL_EXPORTACION
    {
        private readonly BLL_CONFIGURACION bllConfiguracion;

        public BLL_EXPORTACION()
        {
            bllConfiguracion = new BLL_CONFIGURACION();
        }

        #region Exportación Excel

        /// <summary>
        /// Exporta un DataTable a Excel con formato simple
        /// </summary>
        public bool ExportarDataTableAExcel(System.Data.DataTable dataTable, string nombreArchivo, string tituloHoja = "Datos")
        {
            try
            {
                string rutaCompleta = GenerarRutaArchivo(nombreArchivo, "xlsx");

                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                try
                {
                    worksheet = workbook.ActiveSheet;
                    worksheet.Name = tituloHoja;

                    ExportarTablaAHoja(dataTable, worksheet, tituloHoja);

                    workbook.SaveAs(rutaCompleta);
                    return true;
                }
                finally
                {
                    workbook.Close();
                    app.Quit();

                    // Liberar recursos COM
                    if (worksheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al exportar a Excel: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Exporta múltiples DataTables a Excel con hojas separadas
        /// </summary>
        public bool ExportarMultiplesDataTablesAExcel(string nombreArchivo, params (System.Data.DataTable tabla, string nombreHoja, string titulo)[] datos)
        {
            try
            {
                string rutaCompleta = GenerarRutaArchivo(nombreArchivo, "xlsx");

                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                try
                {
                    // Primera hoja
                    if (datos.Length > 0)
                    {
                        worksheet = workbook.ActiveSheet;
                        worksheet.Name = datos[0].nombreHoja;
                        ExportarTablaAHoja(datos[0].tabla, worksheet, datos[0].titulo);
                    }

                    // Hojas adicionales
                    for (int i = 1; i < datos.Length; i++)
                    {
                        worksheet = workbook.Worksheets.Add();
                        worksheet.Name = datos[i].nombreHoja;
                        ExportarTablaAHoja(datos[i].tabla, worksheet, datos[i].titulo);
                    }

                    // Activar primera hoja
                    if (datos.Length > 0)
                    {
                        ((Microsoft.Office.Interop.Excel._Worksheet)workbook.Worksheets[1]).Activate();
                    }

                    workbook.SaveAs(rutaCompleta);
                    return true;
                }
                finally
                {
                    workbook.Close();
                    app.Quit();

                    // Liberar recursos COM
                    if (worksheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al exportar múltiples tablas a Excel: {ex.Message}", ex);
            }
        }

        private void ExportarTablaAHoja(System.Data.DataTable tabla, Microsoft.Office.Interop.Excel._Worksheet hoja, string titulo)
        {
            // Título
            if (!string.IsNullOrEmpty(titulo))
            {
                hoja.Cells[1, 1] = titulo;
                hoja.Range[hoja.Cells[1, 1], hoja.Cells[1, tabla.Columns.Count]].Merge();
                hoja.Range[hoja.Cells[1, 1], hoja.Cells[1, tabla.Columns.Count]].Font.Bold = true;
                hoja.Range[hoja.Cells[1, 1], hoja.Cells[1, tabla.Columns.Count]].Font.Size = 14;
                hoja.Range[hoja.Cells[1, 1], hoja.Cells[1, tabla.Columns.Count]].HorizontalAlignment = XlHAlign.xlHAlignCenter;
            }

            int filaInicio = string.IsNullOrEmpty(titulo) ? 1 : 3;

            // Encabezados
            for (int i = 0; i < tabla.Columns.Count; i++)
            {
                hoja.Cells[filaInicio, i + 1] = tabla.Columns[i].ColumnName;
                hoja.Cells[filaInicio, i + 1].Font.Bold = true;
                hoja.Cells[filaInicio, i + 1].Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            }

            // Datos
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                for (int j = 0; j < tabla.Columns.Count; j++)
                {
                    hoja.Cells[i + filaInicio + 1, j + 1] = tabla.Rows[i][j]?.ToString() ?? "";
                }
            }

            // Ajustar ancho de columnas
            hoja.Columns.AutoFit();
        }

        #endregion

        #region Exportación PDF

        /// <summary>
        /// Exporta un reporte desde ReportViewer a PDF usando un enfoque más seguro con protección contra PInvokeStackImbalance
        /// </summary>
        public bool ExportarReporteAPDF(Microsoft.Reporting.WinForms.ReportViewer reportViewer, string nombreArchivo)
        {
            try
            {
                // Generar la ruta completa del archivo
                string rutaCompleta = GenerarRutaArchivo(nombreArchivo, "pdf");
                
                // Asegurar que el directorio exista
                string directorio = Path.GetDirectoryName(rutaCompleta);
                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                // Usar ReportViewerFixer para proteger contra PInvokeStackImbalance
                bool resultado = ReportViewerFixer.ExecuteWithProtection(() => {
                    // Configuración del dispositivo de renderizado
                    string deviceInfo = @"<DeviceInfo>
                                         <OutputFormat>PDF</OutputFormat>
                                         <PageWidth>8.5in</PageWidth>
                                         <PageHeight>11in</PageHeight>
                                         <MarginTop>0.5in</MarginTop>
                                         <MarginLeft>0.5in</MarginLeft>
                                         <MarginRight>0.5in</MarginRight>
                                         <MarginBottom>0.5in</MarginBottom>
                                       </DeviceInfo>";

                    // Variables para capturar la salida de la renderización
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType = string.Empty;
                    string encoding = string.Empty;
                    string extension = string.Empty;

                    try
                    {
                        // Renderizar con parámetros explícitos
                        byte[] bytes = reportViewer.LocalReport.Render(
                            "PDF", 
                            deviceInfo, 
                            out mimeType,
                            out encoding, 
                            out extension,
                            out streamIds, 
                            out warnings);

                        // Escribir el archivo usando un FileStream para mejor control
                        using (FileStream fs = new FileStream(rutaCompleta, FileMode.Create))
                        {
                            fs.Write(bytes, 0, bytes.Length);
                            fs.Flush();
                            fs.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error durante la renderización del PDF: {ex.Message}", ex);
                    }
                });

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al exportar reporte a PDF: {ex.Message}", ex);
            }
        }

        #endregion

        #region Métodos Auxiliares

        private string GenerarRutaArchivo(string nombreArchivo, string extension)
        {
            try
            {
                // Usar el directorio de reportes para reportes
                string directorio = BLL_CONFIGURACION.ObtenerDirectorioReporteria();

                // Asegurar que el nombre no tenga extensión duplicada
                if (nombreArchivo.EndsWith($".{extension}", StringComparison.OrdinalIgnoreCase))
                {
                    nombreArchivo = Path.GetFileNameWithoutExtension(nombreArchivo);
                }

                return Path.Combine(directorio, $"{nombreArchivo}.{extension}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al generar ruta de archivo: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Genera un nombre de archivo único con timestamp
        /// </summary>
        public string GenerarNombreArchivoUnico(string prefijo = "Exportacion")
        {
            return $"{prefijo}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}";
        }

        /// <summary>
        /// Abre un archivo con la aplicación predeterminada del sistema
        /// </summary>
        public bool AbrirArchivo(string rutaCompleta)
        {
            try
            {
                if (File.Exists(rutaCompleta))
                {
                    System.Diagnostics.Process.Start(rutaCompleta);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al abrir archivo: {ex.Message}", ex);
            }
        }

        #endregion
    }
}