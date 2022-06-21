﻿using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.IO.Source;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Clases
{
    class Cl_Reportes: Cl_SqlMaestra
    {
        //propiedades para crear reportes de manera general
        private string cadena_consulta;
        private string carpeta;
        private string[] cabecera;
        private string titulo;
        private string fecha;
        private bool vertical;
        private float[] tamanios;
        private DataTable dgv;

        Cl_Validacion vld = new Cl_Validacion();
        Cl_UsuarioLogueado user = new Cl_UsuarioLogueado();

        #region Encapsulamiento
        public string Cadena_consulta { get => cadena_consulta; set => cadena_consulta = value; }
        public string[] Cabecera { get => cabecera; set => cabecera = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Carpeta { get => carpeta; set => carpeta = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public bool Vertical { get => vertical; set => vertical = value; }
        public float[] Tamanios { get => tamanios; set => tamanios = value; }
        public DataTable Dgv { get => dgv; set => dgv = value; }

        #endregion

        public void GenerarPdf() //procedimiento que se encarga de los reportes de todo el programa en formato pdff
        {
            vld.ValidarCarpetas(carpeta);
            PdfWriter EscritorPdf = new PdfWriter(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\" + carpeta + @"\Reporte.pdf");
            PdfDocument pdf = new PdfDocument(EscritorPdf);
            Document documento;

            if (vertical != true)
            {
                documento = new Document(pdf, PageSize.LETTER.Rotate());
            }
            else
            {
                documento = new Document(pdf, PageSize.LETTER);
            }

            //Personalizacion
            documento.SetMargins(75, 20, 55, 20);

            //Creamos los tipos de fuentes
            PdfFont FontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont FontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            //Creando la Cabecera
            Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (var columna in cabecera)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(FontColumnas)).SetFontSize(11));
            }

            //Datos de los registros
            System.Data.DataTable registros = Consulta(cadena_consulta);

            for (int i = 0; i < registros.Rows.Count; i++)
            {
                for (int j = 0; j < registros.Columns.Count; j++)
                {
                    tabla.AddCell(new Cell().Add(new Paragraph(registros.Rows[i][j].ToString()).SetFontSize(11)));
                }                
            }

            documento.Add(tabla);     
            documento.Close();

            //Encabezado
            ImageConverter converter = new ImageConverter();
            var logo = new iText.Layout.Element.Image
                (ImageDataFactory.Create((byte[])converter.ConvertTo(Properties.Resources.LogoTecnoPcCompleto, typeof(byte[])))).SetWidth(40);
            var plogo = new Paragraph("").Add(logo);

            var Partitulo = new Paragraph(titulo);
            Partitulo.SetTextAlignment(TextAlignment.LEFT);
            Partitulo.SetFontSize(12);

            var Fecha = new Paragraph("Fecha: " + DateTime.Now.ToShortDateString() + "\nHora: " + DateTime.Now.ToShortTimeString());
            Fecha.SetFontSize(12);

            pdf = new PdfDocument(new PdfReader(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\" + carpeta + @"\Reporte.pdf"), 
                new PdfWriter(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\" + carpeta + @"\" + titulo + " " + fecha.Replace("/", "-")+".pdf"));
            documento = new Document(pdf);

            //obtenemos el numero de paginas del documetno
            for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
            {
                PdfPage page = pdf.GetPage(i);//obtenemos la pagina para añadir el emcabezado
                float y = pdf.GetPage(i).GetPageSize().GetTop() - 15;
                documento.ShowTextAligned(plogo, 36, y + 5, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                documento.ShowTextAligned(Partitulo.SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)), 70, y, i, TextAlignment.LEFT, VerticalAlignment.TOP, 0);
                documento.ShowTextAligned(new Paragraph("Tecno Pc").SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)), 70, y - 15, i, TextAlignment.LEFT, VerticalAlignment.TOP, 0);
                documento.ShowTextAligned(new Paragraph("Solicitado por: ").SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)), 70, y - 30, i, TextAlignment.LEFT, VerticalAlignment.TOP, 0);
                documento.ShowTextAligned(new Paragraph(user.Propietario_), 160, y - 30, i, TextAlignment.LEFT, VerticalAlignment.TOP, 0);
                documento.ShowTextAligned(new Paragraph("Este Reporte fue Generado"), pdf.GetPage(i).GetPageSize().GetRight() - 91, y, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                documento.ShowTextAligned(Fecha, pdf.GetPage(i).GetPageSize().GetRight() - 91, y - 15, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

                documento.ShowTextAligned(new Paragraph("Pagina " + i + " de " + pdf.GetNumberOfPages()), pdf.GetPage(i).GetPageSize().GetWidth() / 2
                    ,pdf.GetPage(i).GetPageSize().GetBottom() + 30, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            }

            
            documento.Close();
            File.Delete(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\" + carpeta + @"\Reporte.pdf");
            Process.Start(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\" + carpeta + @"\" + titulo + " " + fecha.Replace("/", "-") + ".pdf");
        }
              
        public void PdfFacturas() // se encarga de las facturas y de la generacion de estas mismas tanto desde la pantalla de facturas como desde ventas  
        {
            //Inializacion de las variables que almacenaran los datos            
            System.Data.DataTable registros = new System.Data.DataTable();
            string id, empleado, cliente, transac, Fventa, Fvenci;
            double isv;
            string[] cabecera = new string[] { "Descripcion", "Precio Unitario", "Cant", "Total" };
            float[] tamanios = new float[] { 8, 4, 3, 4 };

            //Extraccion de la Cabecera desde el DGV            
            id = Dgv.Rows[0][0].ToString();
            empleado = Dgv.Rows[0][2].ToString();
            cliente = Dgv.Rows[0][1].ToString();
            transac = Dgv.Rows[0][3].ToString();
            Fventa = Dgv.Rows[0][4].ToString().Replace("00", "");
            Fvenci = Dgv.Rows[0][5].ToString().Replace("00", "");
            isv = double.Parse(Dgv.Rows[0][6].ToString());

            //Extraccion de los detalles de la Factura
            registros = Consulta("select (p.[Nombre Producto] +' '+ p.[Modelo]), CAST(df.[Precio Historico] AS decimal(9,2)), df.Cantidad, " +
                "CAST((df.[Precio Historico] * df.Cantidad) AS decimal(9, 2)) " +
                "Total from DetalleFactura df inner join Productos p on p.[ID Producto] = df.[ID Producto] where df.[ID Factura] =" + id);

            double subtot = double.Parse(Consulta2("select Sum([Precio Historico] * Cantidad) SubTotal from DetalleFactura where [ID Factura] = " + id));

            //Creacion del Pdf
            vld.ValidarCarpetas("Facturas");
            PdfWriter EscritorPdf = new PdfWriter(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\Facturas\Factura N° " + id + ".pdf");
            PdfDocument pdf = new PdfDocument(EscritorPdf);
            Document documento;

            documento = new Document(pdf, PageSize.LETTER);

            //Personalizacion
            documento.SetMargins(40, 40, 40, 40);

            //Creamos los tipos de fuentes
            PdfFont FontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont FontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            //Creando el Encabezado 
            documento.Add(new Paragraph("Tecno PC").SetFont(FontColumnas).SetFontSize(15));
            documento.Add(new Paragraph("Tecno Edificio Plaza América Colonia Florencia Norte\npctecno536@gmail.com\n9875-2356").SetFont(FontContenido).SetFontSize(11));
            documento.Add(new Paragraph("    ").SetFont(FontContenido).SetFontSize(11));
            documento.Add(new Paragraph("Cliente:").SetFont(FontColumnas).SetFontSize(11));
            documento.Add(new Paragraph(cliente).SetFont(FontContenido).SetFontSize(11));
            documento.Add(new Paragraph("Vendedor:").SetFont(FontColumnas).SetFontSize(11));
            documento.Add(new Paragraph(empleado).SetFont(FontContenido).SetFontSize(11));

            float y = pdf.GetPage(1).GetPageSize().GetTop() - 40; //calculando la cordenada y para posicionar los parrafos de la derecha
            float x = pdf.GetPage(1).GetPageSize().GetRight() - 40; //calculando la cordenada x para posicionar los parrafos de la derecha
            documento.ShowTextAligned(new Paragraph("Factura N° " + id).SetFont(FontColumnas).SetFontSize(15), x, y - 5, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            documento.ShowTextAligned(new Paragraph("RTN: 14011992000298" + id).SetFont(FontContenido).SetFontSize(11), x, y - 37, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            documento.ShowTextAligned(new Paragraph("Transaccion: " + transac).SetFont(FontContenido).SetFontSize(11), x, y - 53, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            documento.ShowTextAligned(new Paragraph("Fecha Venta: " + Fventa.Replace(":", "")).SetFont(FontContenido).SetFontSize(11), x, y - 69, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            documento.ShowTextAligned(new Paragraph("Vencimiento: " + Fvenci.Replace(":", "")).SetFont(FontContenido).SetFontSize(11), x, y - 85, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);

            //Creando la Cabecera
            Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (var columna in cabecera)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(FontColumnas)).SetFontSize(11));
            }

            //añadiendo los registros a la tabla
            for (int i = 0; i < registros.Rows.Count; i++)
            {
                for (int j = 0; j < registros.Columns.Count; j++)
                {
                    tabla.AddCell(new Cell().Add(new Paragraph(registros.Rows[i][j].ToString()).SetFontSize(11)));
                }
            }

            documento.Add(tabla);

            //Creando la parte calculada de la Factura
            documento.Add(new Paragraph("Sub Total: L " + subtot + "\nISV: " + (isv * 100) + "%\nImpuesto: L " + (isv * subtot)).SetFont(FontContenido).SetFontSize(11).
                SetTextAlignment(TextAlignment.RIGHT));
            documento.Add(new Paragraph("TOTAL FACTURA: L " + ((isv * subtot) + subtot)).SetFont(FontColumnas).SetFontSize(13).SetTextAlignment(TextAlignment.RIGHT));

            documento.Close(); //cerramos el doc
            Process.Start(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\Facturas\Factura N° " + id + ".pdf");  //abrimos el pdf
        }
    }
}
