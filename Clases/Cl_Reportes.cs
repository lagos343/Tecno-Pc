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
        private string titulo_reporte;
        private string fecha_reporte;
        private bool vertical_reporte;
        private float[] tamanios_reporte;
        private DataTable dgv_reporte;

        Cl_Validacion vld_ci = new Cl_Validacion();
        Cl_UsuarioLogueado user_log = new Cl_UsuarioLogueado();

        #region Encapsulamiento
        public string Cadena_consulta { get => cadena_consulta; set => cadena_consulta = value; }
        public string[] Cabecera { get => cabecera_reporte; set => cabecera_reporte = value; }
        public string Titulo { get => titulo_reporte; set => titulo_reporte = value; }
        public string Carpeta { get => carpeta_reporte; set => carpeta_reporte = value; }
        public string Fecha { get => fecha_reporte; set => fecha_reporte = value; }
        public bool Vertical { get => vertical_reporte; set => vertical_reporte = value; }
        public float[] Tamanios { get => tamanios_reporte; set => tamanios_reporte = value; }
        public DataTable Dgv { get => dgv_reporte; set => dgv_reporte = value; }

        #endregion

        public void Generar_pdf() //procedimiento que se encarga de los reportes de todo el programa en formato pdf
        {
            //indicamos el reporte que se abrira el el formulario de PDFs
            Properties.Settings.Default.ReporteActual = Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\" + carpeta_reporte + @"\" + titulo_reporte + " " + fecha_reporte.Replace("/", "-") + ".pdf";
            Properties.Settings.Default.Save();

            //inicializamos las variables del PDF
            vld_ci.Validar_Carpetas(carpeta_reporte);
            PdfWriter EscritorPdf = new PdfWriter(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\" + carpeta_reporte + @"\Reporte.pdf");
            PdfDocument pdf = new PdfDocument(EscritorPdf);
            Document documento;

            if (vertical_reporte != true)
            {
                documento_reporte = new Document(pdf_reporte, PageSize.LETTER.Rotate());
            }
            else
            {
                documento_reporte = new Document(pdf_reporte, PageSize.LETTER);
            }

            //Personalizacion
            documento_reporte.SetMargins(75, 20, 55, 20);

            //Creamos los tipos de fuentes
            PdfFont font_columnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont font_contenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            //Creando la Cabecera
            Table tabla_reporte = new Table(UnitValue.CreatePercentArray(tamanios_reporte));
            tabla_reporte.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (var columna_reporte in cabecera_reporte)
            {
                tabla_reporte.AddHeaderCell(new Cell().Add(new Paragraph(columna_reporte).SetFont(font_columnas)).SetFontSize(11));
            }

            //Datos de los registros
            System.Data.DataTable registros_reporte = Consulta_registro(cadena_consulta);

            for (int i = 0; i < registros_reporte.Rows.Count; i++)
            {
                for (int j = 0; j < registros_reporte.Columns.Count; j++)
                {
                    tabla_reporte.AddCell(new Cell().Add(new Paragraph(registros_reporte.Rows[i][j].ToString()).SetFontSize(11)));
                }                
            }

            documento_reporte.Add(tabla_reporte);     
            documento_reporte.Close();

            //Encabezado
            ImageConverter converter_reporte = new ImageConverter();
            var logo_reporte = new iText.Layout.Element.Image
                (ImageDataFactory.Create((byte[])converter_reporte.ConvertTo(Properties.Resources.LogoTecnoPcCompleto, typeof(byte[])))).SetWidth(40);
            var plogo_reporte = new Paragraph("").Add(logo_reporte);

            var Partitulo_reporte = new Paragraph(titulo_reporte);
            Partitulo_reporte.SetTextAlignment(TextAlignment.LEFT);
            Partitulo_reporte.SetFontSize(12);

            var fechal_reporte = new Paragraph("Fecha: " + DateTime.Now.ToShortDateString() + "\nHora: " + DateTime.Now.ToShortTimeString());
            fechal_reporte.SetFontSize(12);

            pdf_reporte = new PdfDocument(new PdfReader(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\" + carpeta_reporte + @"\Reporte.pdf"), 
                new PdfWriter(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\" + carpeta_reporte + @"\" + titulo_reporte + " " + fecha_reporte.Replace("/", "-")+".pdf"));
            documento_reporte = new Document(pdf_reporte);

            //obtenemos el numero de paginas del documetno
            for (int i = 1; i <= pdf_reporte.GetNumberOfPages(); i++)
            {
                PdfPage page = pdf.GetPage(i);//obtenemos la pagina para añadir el emcabezado
                float y = pdf.GetPage(i).GetPageSize().GetTop() - 15;
                documento_reporte.ShowTextAligned(plogo, 36, y + 5, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                documento_reporte.ShowTextAligned(Partitulo.SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)), 70, y, i, TextAlignment.LEFT, VerticalAlignment.TOP, 0);
                documento_reporte.ShowTextAligned(new Paragraph("Tecno Pc").SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)), 70, y - 15, i, TextAlignment.LEFT, VerticalAlignment.TOP, 0);
                documento_reporte.ShowTextAligned(new Paragraph("Solicitado por: ").SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)), 70, y - 30, i, TextAlignment.LEFT, VerticalAlignment.TOP, 0);
                documento_reporte.ShowTextAligned(new Paragraph(user.Propietario_Usuario), 160, y - 30, i, TextAlignment.LEFT, VerticalAlignment.TOP, 0);
                documento_reporte.ShowTextAligned(new Paragraph("Este Reporte fue Generado"), pdf.GetPage(i).GetPageSize().GetRight() - 91, y, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                documento_reporte.ShowTextAligned(Fecha, pdf.GetPage(i).GetPageSize().GetRight() - 91, y - 15, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

                documento_reporte.ShowTextAligned(new Paragraph("Pagina " + i + " de " + pdf_reporte.GetNumberOfPages()), pdf_reporte.GetPage(i).GetPageSize().GetWidth() / 2
                    ,pdf_reporte.GetPage(i).GetPageSize().GetBottom() + 30, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            }

            
            documento_reporte.Close();
            File.Delete(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\" + carpeta_reporte + @"\Reporte.pdf");
        }
              
        public void pdf_facturas() //se encarga de las facturas y de la generacion de estas mismas tanto desde la pantalla de facturas como desde ventas  
        {
            
            //Inializacion de las variables que almacenaran los datos            
            System.Data.DataTable registros_factura = new System.Data.DataTable();
            string id_factura, empleado_factura, cliente_factura, transac_factura, fventa_factura, idsar_factura;
            double isv_factura;
            string[] cabecera_factura = new string[] { "Descripcion", "Precio Unitario", "Cant", "Descuento", "Total" };
            float[] tamanios_factura = new float[] { 11, 2, 1, 2, 2 };

            //Extraccion de la Cabecera desde el DGV            
            id_factura = Dgv.Rows[0][0].ToString();
            empleado_factura = Dgv.Rows[0][2].ToString();
            cliente_factura = Dgv.Rows[0][1].ToString();
            transac_factura = Dgv.Rows[0][3].ToString();
            fventa_factura = Dgv.Rows[0][4].ToString().Replace("00", "");
            isv_factura = double.Parse(Dgv.Rows[0][5].ToString());
            idsar_factura = Dgv.Rows[0][6].ToString();

            //Extraccion de Los datos de la SAR
            System.Data.DataTable sar_factura = new System.Data.DataTable();
            long desde_factura, hasta_factura;
            string limite_factura;

            sar_factura = Consulta_registro("select *from Sar where id_sar = "+idsar_factura);
            desde_factura = long.Parse(sar_factura.Rows[0][1].ToString());
            hasta_factura = long.Parse(sar_factura.Rows[0][2].ToString());
            limite_factura = sar_factura.Rows[0][3].ToString().Replace("00", "");

            //Extraccion de los detalles de la Factura
            registros_factura = Consulta_registro("select (p.[nombre_producto] +' '+ p.[modelo_producto]), CAST(df.[precio_historico] AS decimal(9,2)), df.cantidad, CAST((df.[precio_historico]) * descuentos " +
                "AS decimal(9, 2)), CAST(((df.[precio_historico] * df.cantidad) - (df.[precio_historico] * df.cantidad * descuentos)) AS decimal(9, 2)) Total from DetalleFactura df inner join " +
                "Productos p on p.[id_producto] = df.[id_producto] where df.[id_factura] =" + id_factura);            

            //indicamos el reporte que se abrira el el formulario de PDFs
            Properties.Settings.Default.ReporteActual = Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\Facturas\Factura N° " + id_factura + ".pdf";
            Properties.Settings.Default.Save();

            //Creacion del Pdf
            vld_ci.Validar_Carpetas("Facturas");
            PdfWriter EscritorPdf = new PdfWriter(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\Facturas\Factura N° " + id + ".pdf");
            PdfDocument pdf = new PdfDocument(EscritorPdf);
            Document documento;


            documento_factura = new Document(pdf_factura, new PageSize(612, 504));

            //Personalizacion
            documento_factura.SetMargins(10, 10, 10, 10);

            //Creamos los tipos de fuentes
            PdfFont font_columnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont font_contenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            //Creando el Encabezado 
            documento_factura.Add(new Paragraph("Tecno PC").SetFont(font_columnas).SetFontSize(12));
            documento_factura.Add(new Paragraph(Properties.Settings.Default.Direccion.ToString()+"\nEmail: "+Properties.Settings.Default.Email.ToString()+"\nTel: (504) " + Properties.Settings.Default.Telefono.ToString() +
                "\nRango Autorizado: 000-001-1-0-0" +desde_factura.ToString("0000000")+" - 000-001-01-0-0"+ hasta_factura.ToString("0000000") + "\nCliente: " + cliente_factura + 
                "\t\tVendedor: " + empleado_factura).SetFont(font_contenido).SetFontSize(8));

            float y = pdf_factura.GetPage(1).GetPageSize().GetTop() - 10; //calculando la cordenada y para posicionar los parrafos de la derecha
            float x = pdf_factura.GetPage(1).GetPageSize().GetRight() - 10; //calculando la cordenada x para posicionar los parrafos de la derecha
            documento_factura.ShowTextAligned(new Paragraph("Factura N° 000-001-01-0" + long.Parse(id_factura).ToString("0000000")).SetFont(font_columnas).SetFontSize(12), x, y - 6, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            documento_factura.ShowTextAligned(new Paragraph("").SetFont(font_contenido).SetFontSize(8), x, y - 37, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            documento_factura.ShowTextAligned(new Paragraph("Transaccion: " + transac_factura).SetFont(font_contenido).SetFontSize(8), x, y - 31, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            documento_factura.ShowTextAligned(new Paragraph("Fecha Venta: " + fventa_factura.Replace(":", "")).SetFont(font_contenido).SetFontSize(8), x, y - 42, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            documento_factura.ShowTextAligned(new Paragraph("Fecha Limite: " + limite_factura.Replace(":", "")).SetFont(font_contenido).SetFontSize(8), x, y - 54, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            documento_factura.ShowTextAligned(new Paragraph("RTN: "+ Properties.Settings.Default.RTN.ToString()).SetFont(font_contenido).SetFontSize(8), x, y - 67, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            documento_factura.ShowTextAligned(new Paragraph("C.A.I: "+ Properties.Settings.Default.CAI.ToString()).SetFont(font_contenido).SetFontSize(8), x, y - 80, 1, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);            

            //Creando la Cabecera
            Table tabla_factura = new Table(UnitValue.CreatePercentArray(tamanios_factura));
            tabla_factura.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (var columna_factura in cabecera_factura)
            {
                tabla_factura.AddHeaderCell(new Cell().Add(new Paragraph(columna_factura).SetFont(font_columnas)).SetFontSize(8));
            }

            //añadiendo los registros a la tabla
            for (int i = 0; i < registros_factura.Rows.Count; i++)
            {
                for (int j = 0; j < registros_factura.Columns.Count; j++)
                {
                    tabla_factura.AddCell(new Cell().Add(new Paragraph(registros_factura.Rows[i][j].ToString()).SetFontSize(8)));
                }
            }

            if(tabla_factura.GetNumberOfRows() < 17)
            {
                for (int i = tabla_factura.GetNumberOfRows(); i <= 17; i++)
                {                    
                    tabla_factura.AddCell(new Cell().Add(new Paragraph("\n").SetFontSize(8)));
                    tabla_factura.AddCell(new Cell().Add(new Paragraph("\n").SetFontSize(8)));
                    tabla_factura.AddCell(new Cell().Add(new Paragraph("\n").SetFontSize(8)));
                    tabla_factura.AddCell(new Cell().Add(new Paragraph("\n").SetFontSize(8)));
                    tabla_factura.AddCell(new Cell().Add(new Paragraph("\n").SetFontSize(8)));
                }
            }

            documento_factura.Add(tabla_factura);

            //Creando la parte calculada de la Factura        
            double descuentos_factura, Gravado_factura;

            try
            {
                descuentos_factura = double.Parse(Consulta2_registro("select Sum(CAST(([precio_historico] * cantidad * descuentos) AS decimal(9, 2))) Descuento from " +
                "DetalleFactura where [id_factura] = " + id_factura + " and descuentos > 0.00"));
            }
            catch (Exception)
            {descuentos_factura = 0.00;}

            try
            {
                Gravado_factura = double.Parse(Consulta2_registro("select Sum(CAST((([precio_historico] * cantidad)) AS decimal(9, 2))) Excento from " +
                "DetalleFactura where [id_factura] = " + id_factura));
            }
            catch (Exception)
            {Gravado_factura = 0.00;}
            

            documento_factura.Add(new Paragraph("Descuentos Otorgados: L " + descuentos_factura + "\nImporte Gravado 15%: L " + (Gravado_factura - (Gravado_factura * isv_factura)).ToString("0.00") + "\nISV 15%: L " + 
                (isv_factura * Gravado_factura).ToString("0.00")).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT));
            
            documento_factura.Add(new Paragraph("TOTAL A PAGAR L " + (Gravado_factura - descuentos_factura)).SetFont(font_columnas).SetFontSize(8).SetTextAlignment(TextAlignment.RIGHT));

            documento_factura.Close(); //cerramos el doc
        }
    }
}
 