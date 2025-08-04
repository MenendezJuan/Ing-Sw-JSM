using BEs.Clases.Negocio.Ventas;
using BLLs.Tecnica;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Linq;

namespace BLLs.Negocio
{
    public class BLL_FACTURACION
    {
        private readonly BLL_VENTA _bllVenta;

        public BLL_FACTURACION()
        {
            _bllVenta = new BLL_VENTA();
        }

        /// <summary>
        /// Genera una factura en PDF para la venta especificada
        /// </summary>
        /// <param name="venta">Venta para la cual generar la factura</param>
        /// <returns>Ruta completa del archivo PDF generado</returns>
        public string GenerarFacturaPDF(Venta venta)
        {
            if (venta == null)
                throw new ArgumentNullException(nameof(venta), "La venta no puede ser nula");

            try
            {
                // Obtener configuraciones
                string directorioFacturas = BLL_CONFIGURACION.ObtenerDirectorioFacturas();
                string prefijoFactura = BLL_CONFIGURACION.ObtenerPrefijoFactura();
                string formatoNumero = BLL_CONFIGURACION.ObtenerFormatoNumeroFactura();

                // Generar nombre del archivo
                string nombreArchivo = $"{prefijoFactura}_{venta.Id.ToString(formatoNumero)}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string rutaCompleta = Path.Combine(directorioFacturas, nombreArchivo);

                // Crear el documento PDF
                using (var documento = new Document(PageSize.A4))
                {
                    using (var writer = PdfWriter.GetInstance(documento, new FileStream(rutaCompleta, FileMode.Create)))
                    {
                        documento.Open();

                        // Configurar fuentes
                        var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                        var fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                        var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                        var fuentePequeña = FontFactory.GetFont(FontFactory.HELVETICA, 8);

                        // Agregar contenido
                        AgregarEncabezado(documento, venta, fuenteTitulo, fuenteSubtitulo, fuenteNormal);
                        AgregarDatosCliente(documento, venta, fuenteSubtitulo, fuenteNormal);
                        AgregarDetalleVenta(documento, venta, fuenteSubtitulo, fuenteNormal);
                        AgregarTotales(documento, venta, fuenteTitulo, fuenteNormal);
                        AgregarPiePagina(documento, fuentePequeña);

                        documento.Close();
                    }
                }

                return rutaCompleta;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al generar la factura: {ex.Message}", ex);
            }
        }

        private void AgregarEncabezado(Document documento, Venta venta, 
            iTextSharp.text.Font fuenteTitulo, iTextSharp.text.Font fuenteSubtitulo, iTextSharp.text.Font fuenteNormal)
        {
            // Encabezado con logo, empresa y factura
            var tablaHeader = new PdfPTable(3) { WidthPercentage = 100 };
            tablaHeader.SetWidths(new float[] { 20f, 50f, 30f });

            // CELDA 1: LOGO
            var celdaLogo = new PdfPCell();
            celdaLogo.Border = Rectangle.NO_BORDER;
            celdaLogo.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaLogo.VerticalAlignment = Element.ALIGN_MIDDLE;

            bool logoAgregado = AgregarLogoEmpresa(celdaLogo, fuenteTitulo);

            // CELDA 2: INFORMACIÓN DE LA EMPRESA
            var celdaEmpresa = new PdfPCell();
            celdaEmpresa.Border = Rectangle.NO_BORDER;
            celdaEmpresa.AddElement(new Paragraph("CHEESE LOGIX S.A.", fuenteTitulo));
            celdaEmpresa.AddElement(new Paragraph("CUIT: 30-12345678-9", fuenteNormal));
            celdaEmpresa.AddElement(new Paragraph("Av. Corrientes 1234, CABA", fuenteNormal));
            celdaEmpresa.AddElement(new Paragraph("Tel: (011) 1234-5678", fuenteNormal));
            celdaEmpresa.AddElement(new Paragraph("www.cheeselogix.com", fuenteNormal));

            // CELDA 3: INFORMACIÓN DE LA FACTURA
            var celdaFactura = new PdfPCell();
            celdaFactura.Border = Rectangle.BOX;
            celdaFactura.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaFactura.AddElement(new Paragraph("FACTURA", fuenteTitulo));
            
            string formatoNumero = BLL_CONFIGURACION.ObtenerFormatoNumeroFactura();
            celdaFactura.AddElement(new Paragraph($"Nº {venta.Id.ToString(formatoNumero)}", fuenteSubtitulo));
            celdaFactura.AddElement(new Paragraph($"Fecha: {venta.Fecha:dd/MM/yyyy}", fuenteNormal));

            tablaHeader.AddCell(celdaLogo);
            tablaHeader.AddCell(celdaEmpresa);
            tablaHeader.AddCell(celdaFactura);
            documento.Add(tablaHeader);
            documento.Add(new Paragraph(" ")); // Espacio
        }

        private bool AgregarLogoEmpresa(PdfPCell celda, iTextSharp.text.Font fuenteTitulo)
        {
            try
            {
                // Buscar el logo de CheeseLogix usando las mismas rutas que BLL_EXPORTACION
                string[] posiblesRutas = {
                    Path.Combine(System.Windows.Forms.Application.StartupPath, "..", "..", "icons8-battle.net.ico"),
                    Path.Combine(System.Windows.Forms.Application.StartupPath, "icons8-battle.net.ico"),
                    Path.Combine(System.Windows.Forms.Application.StartupPath, "..", "..", "Form1", "icons8-battle.net.ico")
                };

                foreach (string ruta in posiblesRutas)
                {
                    if (File.Exists(ruta))
                    {
                        using (var icon = new System.Drawing.Icon(ruta))
                        {
                            using (var bitmap = icon.ToBitmap())
                            {
                                using (var ms = new MemoryStream())
                                {
                                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    var logoImage = iTextSharp.text.Image.GetInstance(ms.ToArray());
                                    logoImage.ScaleToFit(50f, 50f);
                                    logoImage.Alignment = Element.ALIGN_CENTER;
                                    celda.AddElement(logoImage);
                                    return true;
                                }
                            }
                        }
                    }
                }

                // Fallback: Solo las iniciales
                celda.AddElement(new Paragraph("CL", fuenteTitulo) { Alignment = Element.ALIGN_CENTER });
                return false;
            }
            catch
            {
                // Fallback: Solo las iniciales
                celda.AddElement(new Paragraph("CL", fuenteTitulo) { Alignment = Element.ALIGN_CENTER });
                return false;
            }
        }

        private void AgregarDatosCliente(Document documento, Venta venta, 
            iTextSharp.text.Font fuenteSubtitulo, iTextSharp.text.Font fuenteNormal)
        {
            var tablaCliente = new PdfPTable(1) { WidthPercentage = 100 };
            var celdaCliente = new PdfPCell();
            celdaCliente.AddElement(new Paragraph("DATOS DEL CLIENTE:", fuenteSubtitulo));
            celdaCliente.AddElement(new Paragraph($"Nombre: {venta.oCliente?.NombreCompleto ?? "N/A"}", fuenteNormal));
            celdaCliente.AddElement(new Paragraph($"CUIT: {venta.oCliente?.CUIT ?? "N/A"}", fuenteNormal));
            celdaCliente.AddElement(new Paragraph($"Dirección: {venta.oCliente?.Direccion ?? "N/A"}", fuenteNormal));
            tablaCliente.AddCell(celdaCliente);
            documento.Add(tablaCliente);
            documento.Add(new Paragraph(" ")); // Espacio
        }

        private void AgregarDetalleVenta(Document documento, Venta venta, 
            iTextSharp.text.Font fuenteSubtitulo, iTextSharp.text.Font fuenteNormal)
        {
            var tablaDetalle = new PdfPTable(4) { WidthPercentage = 100 };
            tablaDetalle.SetWidths(new float[] { 50f, 15f, 20f, 15f });

            // Encabezados
            tablaDetalle.AddCell(new PdfPCell(new Phrase("Producto", fuenteSubtitulo)) { HorizontalAlignment = Element.ALIGN_CENTER });
            tablaDetalle.AddCell(new PdfPCell(new Phrase("Cant.", fuenteSubtitulo)) { HorizontalAlignment = Element.ALIGN_CENTER });
            tablaDetalle.AddCell(new PdfPCell(new Phrase("Precio Unit.", fuenteSubtitulo)) { HorizontalAlignment = Element.ALIGN_CENTER });
            tablaDetalle.AddCell(new PdfPCell(new Phrase("Subtotal", fuenteSubtitulo)) { HorizontalAlignment = Element.ALIGN_CENTER });

            // Detalles
            var detalles = _bllVenta.ObtenerDetallesPorVentaId(venta.Id);
            foreach (var detalle in detalles)
            {
                tablaDetalle.AddCell(new PdfPCell(new Phrase(detalle.NombreProducto, fuenteNormal)));
                tablaDetalle.AddCell(new PdfPCell(new Phrase(detalle.Cantidad.ToString("N2"), fuenteNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });
                tablaDetalle.AddCell(new PdfPCell(new Phrase(detalle.Precio.ToString("C2"), fuenteNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                tablaDetalle.AddCell(new PdfPCell(new Phrase(detalle.SubTotal.ToString("C2"), fuenteNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT });
            }

            documento.Add(tablaDetalle);
            documento.Add(new Paragraph(" ")); // Espacio
        }

        private void AgregarTotales(Document documento, Venta venta, 
            iTextSharp.text.Font fuenteTitulo, iTextSharp.text.Font fuenteNormal)
        {
            var tablaTotal = new PdfPTable(2) { WidthPercentage = 100 };
            tablaTotal.SetWidths(new float[] { 70f, 30f });

            var celdaMetodo = new PdfPCell();
            celdaMetodo.Border = Rectangle.NO_BORDER;
            celdaMetodo.AddElement(new Paragraph($"Método de pago: {ObtenerNombreTipoPago(venta.TipoPagoEnum)}", fuenteNormal));
            celdaMetodo.AddElement(new Paragraph($"Estado: {ObtenerNombreEstadoVenta(venta.EstadoVentaEnum)}", fuenteNormal));

            var celdaTotal = new PdfPCell();
            celdaTotal.Border = Rectangle.BOX;
            celdaTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
            celdaTotal.AddElement(new Paragraph($"TOTAL: {venta.MontoTotal:C2}", fuenteTitulo));

            tablaTotal.AddCell(celdaMetodo);
            tablaTotal.AddCell(celdaTotal);
            documento.Add(tablaTotal);
        }

        private void AgregarPiePagina(Document documento, iTextSharp.text.Font fuentePequeña)
        {
            documento.Add(new Paragraph(" ")); // Espacio
            documento.Add(new Paragraph("Gracias por su compra", fuentePequeña) { Alignment = Element.ALIGN_CENTER });
            documento.Add(new Paragraph($"Factura generada el {DateTime.Now:dd/MM/yyyy HH:mm}", fuentePequeña) { Alignment = Element.ALIGN_CENTER });
        }

        private string ObtenerNombreTipoPago(BEs.Clases.Negocio.TipoPago tipoPago)
        {
            switch (tipoPago)
            {
                case BEs.Clases.Negocio.TipoPago.Efectivo: return "Efectivo";
                case BEs.Clases.Negocio.TipoPago.Credito: return "Tarjeta de Crédito";
                case BEs.Clases.Negocio.TipoPago.Debito: return "Tarjeta de Débito";
                default: return "No especificado";
            }
        }

        private string ObtenerNombreEstadoVenta(BEs.Clases.Negocio.Enums.EstadoVenta estado)
        {
            switch (estado)
            {
                case BEs.Clases.Negocio.Enums.EstadoVenta.EnProceso: return "En Proceso";
                case BEs.Clases.Negocio.Enums.EstadoVenta.Cobrada: return "Cobrada";
                case BEs.Clases.Negocio.Enums.EstadoVenta.Entregada: return "Entregada";
                case BEs.Clases.Negocio.Enums.EstadoVenta.Cancelada: return "Cancelada";
                default: return "Desconocido";
            }
        }
    }
}