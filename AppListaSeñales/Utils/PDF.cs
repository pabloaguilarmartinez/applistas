using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AppListaSeñales.Entity;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace AppListaSeñales.Utils
{
    class PDF
    {
        
        public static void extraerPDF(String nombreExplotacion, String nombreEstacion, int numeroEstacion, DataTable analogicas, DataTable digitales, DataTable contadores, DataTable consignas, DataTable telemandos, int numeroEsclavo)
        {
            Dictionary<String, String> consignasAsociadas = new Dictionary<String, String>();
            Cell cell = new Cell();
            // Fuentes
            PdfFont chapterFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLDOBLIQUE); // set 26 size
            PdfFont paragraphFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA); // 12
            PdfFont paragraphFontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD); // 12 texto, 18 categoría, 16 subcategoría 
            // Elegimos donde se va a guardar el pdf
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            String fic = "";
            String fecha = DateTime.Now.ToString("ddMMyyyy");
            dialog.Description = "Seleccione una carpeta";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fic = dialog.SelectedPath + "\\" + nombreExplotacion + " - " + nombreEstacion + " " + fecha + ".pdf";
            }
            // Creamos documento
            PdfWriter writer = new PdfWriter(fic);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf, PageSize.A4, false);
            // Cabecera
            Paragraph cabecera = new Paragraph();
            Text izquierdaCabecera = new Text("Lista de Señales - Estaciones Remotas").SetFont(paragraphFontBold).SetTextAlignment(TextAlignment.LEFT).SetFontSize(12);
            Text impresion = new Text("\t\t\t\t\t\t\t\t\t Impresión: ").SetFont(paragraphFontBold).SetTextAlignment(TextAlignment.RIGHT).SetFontSize(12);
            Text fechaImpresion = new Text(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")).SetFont(paragraphFontBold).SetTextAlignment(TextAlignment.RIGHT).SetFontSize(12);
            cabecera.Add(izquierdaCabecera).Add(impresion).Add(fechaImpresion);
            // Línea separadora
            LineSeparator ls = new LineSeparator(new SolidLine());
            // Datos estación
            Paragraph datosEstacion = new Paragraph();
            Text explotacion = new Text("Explotación: ").SetFont(paragraphFontBold).SetTextAlignment(TextAlignment.LEFT).SetFontSize(12);
            Text estacion = new Text("Estación: ").SetFont(paragraphFontBold).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER).SetFontSize(12);
            Text numero = new Text("Nº de Estación: ").SetFont(paragraphFontBold).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT).SetFontSize(12);
            Text numeroEsclavoTexto = new Text("Nº de Esclavo: ").SetFont(paragraphFontBold).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT).SetFontSize(12);
            datosEstacion.Add(explotacion);
            datosEstacion.Add(nombreExplotacion + "\n").SetFont(paragraphFont).SetTextAlignment(TextAlignment.LEFT).SetFontSize(12);
            datosEstacion.Add(estacion);
            datosEstacion.Add(nombreEstacion + "\n").SetFont(paragraphFont).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER).SetFontSize(12);
            datosEstacion.Add(numero);
            datosEstacion.Add(numeroEstacion.ToString() + "\n").SetFont(paragraphFont).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT).SetFontSize(12);
            datosEstacion.Add(numeroEsclavoTexto);
            datosEstacion.Add(numeroEsclavo.ToString()).SetFont(paragraphFont).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT).SetFontSize(12);
            /****************************************************************************************************************************************************************************/
            // Señales Analógicas
            document.Add(cabecera);
            document.Add(ls);
            Paragraph entradasAnalogicas = new Paragraph();
            entradasAnalogicas.Add("Entradas Analógicas").SetFont(chapterFont).SetTextAlignment(TextAlignment.LEFT).SetFontSize(18);
            document.Add(entradasAnalogicas);
            document.Add(ls);
            document.Add(datosEstacion);
            document.Add(ls);
            document.Add(new Paragraph(""));
            // Tabla
            Table tablaAnalogicas = new Table(11, false);
            // Cabeceras tabla
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Salida")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaAnalogicas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Nº\nLóg.")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaAnalogicas.AddHeaderCell(cell);     
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Nº\nFís.")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaAnalogicas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Tag")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaAnalogicas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Descripción")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaAnalogicas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("MinEU")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaAnalogicas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("MaxEU")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaAnalogicas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("MinRaw")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaAnalogicas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("MaxRaw")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaAnalogicas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Unid.")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaAnalogicas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Hist.")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaAnalogicas.AddHeaderCell(cell);
            // Datos
            for (int i = 0; i< analogicas.Rows.Count; i++)
            {
                if (!String.IsNullOrEmpty(analogicas.Rows[i]["direccionPlc"].ToString()))
                {
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(analogicas.Rows[i]["direccionPlc"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaAnalogicas.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(analogicas.Rows[i]["numeroLogico"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaAnalogicas.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(analogicas.Rows[i]["numeroFisico"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaAnalogicas.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(analogicas.Rows[i]["tag"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaAnalogicas.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(analogicas.Rows[i]["descripcion"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaAnalogicas.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(analogicas.Rows[i]["minEngUnits"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaAnalogicas.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(analogicas.Rows[i]["maxEngUnits"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaAnalogicas.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(analogicas.Rows[i]["minRaw"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaAnalogicas.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(analogicas.Rows[i]["maxRaw"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaAnalogicas.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(analogicas.Rows[i]["unidad"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaAnalogicas.AddCell(cell);
                    if (analogicas.Rows[i]["historico"].ToString().Equals("No"))
                    {
                        cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("No")).SetFont(paragraphFont).SetFontSize(7);
                    }
                    else
                    {
                        cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Sí")).SetFont(paragraphFont).SetFontSize(7);
                    }
                    tablaAnalogicas.AddCell(cell);
                    if (analogicas.Rows[i]["codigo"].ToString().Substring(24, 1).Equals("C"))
                    {
                        consignasAsociadas.Add(analogicas.Rows[i]["codigo"].ToString(), analogicas.Rows[i]["tag"].ToString());
                    }
                }
                
            }
            tablaAnalogicas.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            document.Add(tablaAnalogicas);
            /****************************************************************************************************************************************************************************/
            // Señales Digitales
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            document.Add(cabecera);
            document.Add(ls);
            Paragraph entradasDigitales = new Paragraph();
            entradasDigitales.Add("Entradas Digitales").SetFont(chapterFont).SetTextAlignment(TextAlignment.LEFT).SetFontSize(18);
            document.Add(entradasDigitales);
            document.Add(ls);
            document.Add(datosEstacion);
            document.Add(ls);
            document.Add(new Paragraph(""));
            // Tabla
            Table tablaDigitales = new Table(9, false);
            // Cabeceras tabla
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Salida")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaDigitales.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("NºLóg.")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaDigitales.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("NºFís.")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaDigitales.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Tag")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaDigitales.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Descripción")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaDigitales.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Etiqueta On/Off")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaDigitales.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Alr.")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaDigitales.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Inv.")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaDigitales.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Hist.")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaDigitales.AddHeaderCell(cell);
            // Datos
            for (int i = 0; i < digitales.Rows.Count; i++)
            {
                if (!String.IsNullOrEmpty(digitales.Rows[i]["direccionPlc"].ToString())) 
                {
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(digitales.Rows[i]["direccionPlc"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaDigitales.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(digitales.Rows[i]["numeroLogico"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaDigitales.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(digitales.Rows[i]["numeroFisico"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaDigitales.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(digitales.Rows[i]["tag"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaDigitales.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(digitales.Rows[i]["descripcion"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaDigitales.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(digitales.Rows[i]["onMsg"].ToString() + "/" + digitales.Rows[i]["offMsg"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaDigitales.AddCell(cell);
                    if (digitales.Rows[i]["alarma"].ToString().Equals("On"))
                    {
                        cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Sí")).SetFont(paragraphFont).SetFontSize(7);
                    }
                    else
                    {
                        cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("No")).SetFont(paragraphFont).SetFontSize(7);
                    }
                    tablaDigitales.AddCell(cell);
                    if (digitales.Rows[i]["invertida"].ToString().Equals("Direct"))
                    {
                        cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("No")).SetFont(paragraphFont).SetFontSize(7);
                    }
                    else
                    {
                        cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Sí")).SetFont(paragraphFont).SetFontSize(7);
                    }
                    tablaDigitales.AddCell(cell);
                    if (digitales.Rows[i]["historico"].ToString().Equals("No"))
                    {
                        cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("No")).SetFont(paragraphFont).SetFontSize(7);
                    }
                    else
                    {
                        cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Sí")).SetFont(paragraphFont).SetFontSize(7);
                    }
                    tablaDigitales.AddCell(cell);
                }
                    
            }
            tablaDigitales.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            document.Add(tablaDigitales);
            /****************************************************************************************************************************************************************************/
            // Consignas
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            document.Add(cabecera);
            document.Add(ls);
            Paragraph entradasConsignas = new Paragraph();
            entradasConsignas.Add("Consignas").SetFont(chapterFont).SetTextAlignment(TextAlignment.LEFT).SetFontSize(18);
            document.Add(entradasConsignas);
            document.Add(ls);
            document.Add(datosEstacion);
            document.Add(ls);
            document.Add(new Paragraph(""));
            // Tabla
            Table tablaConsignas = new Table(11, false);
            // Cabeceras tabla
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Salida")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaConsignas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Nº\nLóg.")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaConsignas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Tag")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaConsignas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Descripción")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaConsignas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Entrada\nAsociada")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaConsignas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("MinEU")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaConsignas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("MaxEU")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaConsignas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("MinRaw")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaConsignas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("MaxRaw")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaConsignas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Unid.")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaConsignas.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Hist.")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaConsignas.AddHeaderCell(cell);
            // Datos
            for (int i = 0; i < consignas.Rows.Count; i++)
            {
                if (!String.IsNullOrEmpty(consignas.Rows[i]["direccionPlc"].ToString()))
                {
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(consignas.Rows[i]["direccionPlc"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaConsignas.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(consignas.Rows[i]["numeroLogico"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaConsignas.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(consignas.Rows[i]["tag"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaConsignas.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(consignas.Rows[i]["descripcion"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaConsignas.AddCell(cell);
                    if (consignasAsociadas.ContainsKey(consignas.Rows[i]["codigo"].ToString().Replace(".P_", ".C_")))
                    {
                        cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(consignasAsociadas[consignas.Rows[i]["codigo"].ToString().Replace(".P_", ".C_")])).SetFont(paragraphFont).SetFontSize(7);
                    }
                    else
                    {
                        cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("")).SetFont(paragraphFont).SetFontSize(7);
                    }
                    tablaConsignas.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(consignas.Rows[i]["minEngUnits"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaConsignas.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(consignas.Rows[i]["maxEngUnits"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaConsignas.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(consignas.Rows[i]["minRaw"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaConsignas.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(consignas.Rows[i]["maxRaw"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaConsignas.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(consignas.Rows[i]["unidad"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaConsignas.AddCell(cell);
                    if (consignas.Rows[i]["historico"].ToString().Equals("No"))
                    {
                        cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("No")).SetFont(paragraphFont).SetFontSize(7);
                    }
                    else
                    {
                        cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Sí")).SetFont(paragraphFont).SetFontSize(7);
                    }
                    tablaConsignas.AddCell(cell);
                }    
            }
            tablaConsignas.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            document.Add(tablaConsignas);
            /****************************************************************************************************************************************************************************/
            // Contadores
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            document.Add(cabecera);
            document.Add(ls);
            Paragraph entradasContador = new Paragraph();
            entradasContador.Add("Entradas de Contador").SetFont(chapterFont).SetTextAlignment(TextAlignment.LEFT).SetFontSize(18);
            document.Add(entradasContador);
            document.Add(ls);
            document.Add(datosEstacion);
            document.Add(ls);
            document.Add(new Paragraph(""));
            // Tabla
            Table tablaContadores = new Table(6, false);
            // Cabeceras tabla
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Salida")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaContadores.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("NºLóg.")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaContadores.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("NºFís.")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaContadores.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Tag")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaContadores.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Descripción")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaContadores.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Hist.")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaContadores.AddHeaderCell(cell);
            // Datos
            for (int i = 0; i < contadores.Rows.Count; i++)
            {
                if (!String.IsNullOrEmpty(contadores.Rows[i]["direccionPlc"].ToString()))
                {
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(contadores.Rows[i]["direccionPlc"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaContadores.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(contadores.Rows[i]["numeroLogico"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaContadores.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(contadores.Rows[i]["numeroFisico"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaContadores.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(contadores.Rows[i]["tag"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaContadores.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(contadores.Rows[i]["descripcion"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaContadores.AddCell(cell);
                    if (contadores.Rows[i]["historico"].ToString().Equals("No"))
                    {
                        cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("No")).SetFont(paragraphFont).SetFontSize(7);
                    }
                    else
                    {
                        cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Sí")).SetFont(paragraphFont).SetFontSize(7);
                    }
                    tablaContadores.AddCell(cell);
                }               
            }
            tablaContadores.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            document.Add(tablaContadores);
            /****************************************************************************************************************************************************************************/
            // Telemandos
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            document.Add(cabecera);
            document.Add(ls);
            Paragraph entradasTelemandos = new Paragraph();
            entradasTelemandos.Add("Telemandos").SetFont(chapterFont).SetTextAlignment(TextAlignment.LEFT).SetFontSize(18);
            document.Add(entradasTelemandos);
            document.Add(ls);
            document.Add(datosEstacion);
            document.Add(ls);
            document.Add(new Paragraph(""));
            // Tabla
            Table tablaTelemandos = new Table(4, false);
            // Cabeceras tabla
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Salida")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaTelemandos.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("NºLóg.")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaTelemandos.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Tag")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaTelemandos.AddHeaderCell(cell);
            cell = new Cell().SetBackgroundColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Descripción")).SetFont(paragraphFontBold).SetFontSize(9);
            tablaTelemandos.AddHeaderCell(cell);
            // Datos
            for (int i = 0; i < telemandos.Rows.Count; i++)
            {
                if (!String.IsNullOrEmpty(telemandos.Rows[i]["direccionPlc"].ToString()))
                {
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(telemandos.Rows[i]["direccionPlc"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaTelemandos.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(telemandos.Rows[i]["numeroLogico"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaTelemandos.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(telemandos.Rows[i]["tag"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaTelemandos.AddCell(cell);
                    cell = new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(telemandos.Rows[i]["descripcion"].ToString())).SetFont(paragraphFont).SetFontSize(7);
                    tablaTelemandos.AddCell(cell);
                }               
            }
            tablaTelemandos.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            document.Add(tablaTelemandos);
            /****************************************************************************************************************************************************************************/
            // Número Página
            int n = pdf.GetNumberOfPages();
            for (int i = 1; i <= n; i++)
            {
                document.ShowTextAligned(new Paragraph(String
                   .Format("Página " + i + " de " + n + " Lista Señales")),
                    555, 25, i, TextAlignment.RIGHT,
                    VerticalAlignment.MIDDLE, 0);
            }
            document.Close();
            MessageBox.Show("PDF exportado.");
        }

    }
}
