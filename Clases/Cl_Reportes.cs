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
        private string carpeta_reporte;
        private string[] cabecera_reporte;
        private string titulo;
        private string fecha;
        private bool vertical;
        private float[] tamanios;
        private DataTable dgv;

        Cl_Validacion vld = new Cl_Validacion();
        Cl_UsuarioLogueado user = new Cl_UsuarioLogueado();

        #region Encapsulamiento
        public string Cadena_consulta { get => cadena_consulta; set => cadena_consulta = value; }
        public string[] Cabecera { get => cabecera_reporte; set => cabecera_reporte = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Carpeta { get => carpeta_reporte; set => carpeta_reporte = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public bool Vertical { get => vertical; set => vertical = value; }
        public float[] Tamanios { get => tamanios; set => tamanios = value; }
        public DataTable Dgv { get => dgv; set => dgv = value; }

        #endregion

        public void GenerarPdf() //procedimiento que se encarga de los reportes de todo el programa en formato pdff
        {
            //indicamos el reporte que se abrira el el formulario de PDFs
            Properties.Settings.Default.ReporteActual = Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\" + carpeta_reporte + @"\" + titulo + " " + fecha.Replace("/", "-") + ".pdf";
            Properties.Settings.Default.Save();

            //inicializamos las variables del PDF
            vld.ValidarCarpetas(carpeta_reporte);
            PdfWriter EscritorPdf = new PdfWriter(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\" + carpeta_reporte + @"\Reporte.pdf");
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

            foreach (var columna in cabecera_reporte)
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

            pdf = new PdfDocument(new PdfReader(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\" + carpeta_reporte + @"\Reporte.pdf"), 
                new PdfWriter(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\" + carpeta_reporte + @"\" + titulo + " " + fecha.Replace("/", "-")+".pdf"));
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
            File.Delete(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\" + carpeta_reporte + @"\Reporte.pdf");
        }
              
        public void PdfFacturas() //se encarga de las facturas y de la generacion de estas mismas tanto desde la pantalla de facturas como desde ventas  
        {
            
            //Inializacion de las variables que almacenaran los datos            
            System.Data.DataTable registros = new System.Data.DataTable();
            string id, empleado, cliente, transac, Fventa, idsar;
            double isv;
            string[] cabecera = new string[] { "Descripcion", "Precio Unitario", "Cant", "Descuento", "Total" };
            float[] tamanios = new float[] { 11, 2, 1, 2, 2 };

            //Extraccion de la Cabecera desde el DGV            
            id = Dgv.Rows[0][0].ToString();
            empleado = Dgv.Rows[0][2].ToString();
            cliente = Dgv.Rows[0][1].ToString();
            transac = Dgv.Rows[0][3].ToString();
            Fventa = Dgv.Rows[0][4].ToString().Replace("00", "");
            isv = double.Parse(Dgv.Rows[0][5].ToString());
            idsar = Dgv.Rows[0][6].ToString();

            //Extraccion de Los datos de la SAR
            System.Data.DataTable Sar = new System.Data.DataTable();
            long desde, hasta;
            string limite;

            Sar = Consulta("select *from Sar where id_sar = "+idsar);
            desde = long.Parse(Sar.Rows[0][1].ToString());
            hasta = long.Parse(Sar.Rows[0][2].ToString());
            limite = Sar.Rows[0][3].ToString().Replace("00", "");

            //Extraccion de los detalles de la Factura
            registros = Consulta("select (p.[nombre_producto] +' '+ p.[modelo_producto]), CAST(df.[precio_historico] AS decimal(9,2)), df.cantidad, CAST((df.[precio_historico]) * descuentos " +
                "AS decimal(9, 2)), CAST(((df.[precio_historico] * df.cantidad) - (df.[precio_historico] * df.cantidad * descuentos)) AS decimal(9, 2)) Total from DetalleFactura df inner join " +
                "Productos p on p.[id_producto] = df.[id_producto] where df.[id_factura] =" + id);            

            //indicamos el reporte que se abrira el el formulario de PDFs
            Properties.Settings.Default.ReporteActual = Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\Facturas\Factura N° " + id + ".pdf";
            Properties.Settings.Default.Save(); 
            
            //Creacion del Pdf
            vld.ValidarCarpetas("Facturas");
            PdfWriter EscritorPdf = new PdfWriter(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\Facturas\Factura N° " + id + ".pdf");
            PdfDocument pdf = new PdfDocument(EscritorPdf);
            Document documento;


            documento = new Document(pdf, new PageSize(612, 504));

            //Personalizacion
            documento.SetMargins(10, 10, 10, 10);

            //Creamos los tipos de fuentes
            PdfFont FontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont FontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            //Creando el Encabezado 
            documento.Add(new Paragraph("Tecno PC").SetFont(FontColumnas).SetFontSize(12));
            documento.Add(new Paragraph(Properties.Settings.Default.Direccion.ToString()+"\nEmail: "+Properties.Settings.Default.Email.ToString()+"\nTel: (504) " + Properties.Settings.Default.Telefono.ToString() +
                "\nRango Autorizado: 000-001-1-0-0" +desde.ToString("0000000")+" - 000-001-01-0-0"+ hasta.ToString("0000000") + "\nCliente: " + cliente + 
                "\t\tVendedor: " + empleado).SetFont(FontContenido).SetFontSize(8));

            float y = pdf.GetPage(1).GetPageSize().GetTop() - 10; //calculando la cordenada y para posicionar los parrafos de la derecha
            float x = pdf.GetPage(1).GetPageSize().GetRight() - 10; //calculando la cordenada x para posicionar los parrafos de la derecha
            documento.ShowTextAligned(new Paragraph("Factura N° 000-001-01-0" + long.Parse(id).ToString("0000000")).SetFont(FontColumnas).SetFontSize(12), x, y - 6, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            documento.ShowTextAligned(new Paragraph("").SetFont(FontContenido).SetFontSize(8), x, y - 37, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            documento.ShowTextAligned(new Paragraph("Transaccion: " + transac).SetFont(FontContenido).SetFontSize(8), x, y - 31, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            documento.ShowTextAligned(new Paragraph("Fecha Venta: " + Fventa.Replace(":", "")).SetFont(FontContenido).SetFontSize(8), x, y - 42, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            documento.ShowTextAligned(new Paragraph("Fecha Limite: " + limite.Replace(":", "")).SetFont(FontContenido).SetFontSize(8), x, y - 54, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            documento.ShowTextAligned(new Paragraph("RTN: "+ Properties.Settings.Default.RTN.ToString()).SetFont(FontContenido).SetFontSize(8), x, y - 67, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            documento.ShowTextAligned(new Paragraph("C.A.I: "+ Properties.Settings.Default.CAI.ToString()).SetFont(FontContenido).SetFontSize(8), x, y - 80, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);            

            //Creando la Cabecera
            Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (var columna in cabecera)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(FontColumnas)).SetFontSize(8));
            }

            //añadiendo los registros a la tabla
            for (int i = 0; i < registros.Rows.Count; i++)
            {
                for (int j = 0; j < registros.Columns.Count; j++)
                {
                    tabla.AddCell(new Cell().Add(new Paragraph(registros.Rows[i][j].ToString()).SetFontSize(8)));
                }
            }

            if(tabla.GetNumberOfRows() < 17)
            {
                for (int i = tabla.GetNumberOfRows(); i <= 17; i++)
                {                    
                    tabla.AddCell(new Cell().Add(new Paragraph("\n").SetFontSize(8)));
                    tabla.AddCell(new Cell().Add(new Paragraph("\n").SetFontSize(8)));
                    tabla.AddCell(new Cell().Add(new Paragraph("\n").SetFontSize(8)));
                    tabla.AddCell(new Cell().Add(new Paragraph("\n").SetFontSize(8)));
                    tabla.AddCell(new Cell().Add(new Paragraph("\n").SetFontSize(8)));
                }
            }

            documento.Add(tabla);

            //Creando la parte calculada de la Factura        
            double Descuentos, Gravado;

            try
            {
                Descuentos = double.Parse(Consulta2("select Sum(CAST(([precio_historico] * cantidad * descuentos) AS decimal(9, 2))) Descuento from " +
                "DetalleFactura where [id_factura] = " + id + " and descuentos > 0.00"));
            }
            catch (Exception)
            {Descuentos = 0.00;}

            try
            {
                Gravado = double.Parse(Consulta2("select Sum(CAST((([precio_historico] * cantidad)) AS decimal(9, 2))) Excento from " +
                "DetalleFactura where [id_factura] = " + id));
            }
            catch (Exception)
            {Gravado = 0.00;}
            

            documento.Add(new Paragraph("Descuentos Otorgados: L " + Descuentos + "\nImporte Gravado 15%: L " + (Gravado - (Gravado * isv)).ToString("0.00") + "\nISV 15%: L " + 
                (isv * Gravado).ToString("0.00")).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT));
            
            documento.Add(new Paragraph("TOTAL A PAGAR L " + (Gravado - Descuentos)).SetFont(FontColumnas).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT));

            documento.Close(); //cerramos el doc
        }
    }
}
 