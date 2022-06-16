using iText.IO.Font.Constants;
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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecno_Pc.Clases
{
    class Cl_Reportes: Cl_SqlMaestra
    {
        private string cadena_consulta;
        private string carpeta;
        private string[] cabecera;
        private string titulo;
        private string fecha;
        private bool vertical;
        private float[] tamanios;

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

        #endregion

        public void GenerarPdf()
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

            //Emcabezado
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
    }
}
