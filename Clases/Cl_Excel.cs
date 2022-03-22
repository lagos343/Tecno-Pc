using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using objExcel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace Tecno_Pc.Clases
{
    class Cl_Excel: Cl_SqlMaestra
    {
        private string cadena_consulta;
        private string carpeta;
        private string[] cabecera;
        private string titulo;
        private string rangocabecera;
        private string fecha;

        Cl_Validacion vld = new Cl_Validacion();

        #region Encapsulamiento
        public string Cadena_consulta { get => cadena_consulta; set => cadena_consulta = value; }        
        public string[] Cabecera { get => cabecera; set => cabecera = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string RangoCabecera { get => rangocabecera; set => rangocabecera = value; }
        public string Carpeta { get => carpeta; set => carpeta = value; }
        public string Fecha { get => fecha; set => fecha = value; }

        #endregion

        public void GenerarExcel()
        {
            System.Data.DataTable detalles = new System.Data.DataTable();
            int i = 0, j = 0, fec = 0;
            string var;
            
            detalles = Consulta(cadena_consulta);

                       
            objExcel.Application objAplicacion = new objExcel.Application();
            Workbook objLibro = objAplicacion.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet objHoja = (Worksheet)objAplicacion.ActiveSheet;
            objExcel.Range rango = null;
            objExcel.Style style = objLibro.Styles.Add("EstiloCabecera");
            objHoja.Cells.RowHeight = 18;
            objHoja.Cells.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);


            
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            style.Font.Bold = true;
            style.HorizontalAlignment = objExcel.XlHAlign.xlHAlignCenter;
            style.VerticalAlignment = objExcel.XlVAlign.xlVAlignCenter;
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

            
            for (int k = 0; k < detalles.Columns.Count; k++)
            {
                objHoja.Cells[5, k + 3] = Cabecera[k];

                if (Cabecera[k] == "Total")
                {
                    rango = objHoja.Columns[k + 3];
                    rango.HorizontalAlignment = objExcel.XlHAlign.xlHAlignRight;
                    rango.NumberFormat = @"_(L #,##0.00_)";
                }

                if (Cabecera[k] == "Fecha")
                {
                    fec = k + 3;
                }
            }

            
            objHoja.Cells[2, 3] = "Tecno PC";
            objHoja.Cells[2, 3].Font.Size = 18;
            objHoja.Cells[2, 3].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            objHoja.Cells[2, 3].Borders[objExcel.XlBordersIndex.xlEdgeBottom].LineStyle = objExcel.XlLineStyle.xlContinuous;
            objHoja.Cells[2, 3].Borders[objExcel.XlBordersIndex.xlEdgeBottom].Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
            objHoja.Cells[3, 3] = titulo;
            objHoja.Cells[3, 3].Font.Size = 11;    
                        

                               
            for (i = 0; i < detalles.Columns.Count; i++)
            {
                for (j = 0; j < detalles.Rows.Count; j++)
                {
                    if (i+3 == fec)
                    {
                        var = detalles.Rows[j][i].ToString().Replace("00", "");
                        var.Replace(":", "");                        
                        objHoja.Cells[j + 6, i + 3] = Convert.ToDateTime(var.Replace(":", "")).ToString("yyyy-MM-dd");
                        objHoja.Cells[j + 6, i + 3].Borders.LineStyle = objExcel.XlLineStyle.xlContinuous;
                        objHoja.Cells[j + 6, i + 3].Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                    }
                    else
                    {
                        objHoja.Cells[j + 6, i + 3] = detalles.Rows[j][i].ToString();
                        objHoja.Cells[j + 6, i + 3].Borders.LineStyle = objExcel.XlLineStyle.xlContinuous;
                        objHoja.Cells[j + 6, i + 3].Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                    }                    
                }
                                
                rango = objHoja.Columns[i + 3];
                rango.Columns.AutoFit();
                rango.HorizontalAlignment = objExcel.XlHAlign.xlHAlignLeft;
            }

            i = detalles.Columns.Count;
            objHoja.Cells[2, i + 2] = "Fecha: " + fecha;

            objHoja.Cells[2, i + 2].HorizontalAlignment = objExcel.XlHAlign.xlHAlignRight;
            objHoja.Cells[2, i + 2].Font.Bold = true;
            rango = objHoja.Range[rangocabecera.Substring(0, 2), rangocabecera.Substring(3, 2)];
            rango.Style = "EstiloCabecera";
            rango.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            rango.Borders.LineStyle = objExcel.XlLineStyle.xlContinuous;            

            objAplicacion.Visible = true;

            
            try
            {
                vld.ValidarCarpetas(carpeta);
                objLibro.SaveAs(Properties.Settings.Default.RutaReportes + @"\Reportes Tecno Pc\" + carpeta + @"\" + titulo + " " + fecha.Replace("/", "-"));
            }
            catch (Exception)
            {
                Formularios.frm_notificacion noti2 = new Formularios.frm_notificacion("Ocurrio un error al modificar el archivo, en su lugar se creo uno nuevo", 3);
                noti2.ShowDialog();
                noti2.Close();
            }      
        }
    }
}
