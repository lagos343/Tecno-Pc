using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using objExcel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace Tecno_Pc.Clases
{
    class Cl_Excel: Cl_SqlMaestra
    {
        private string consulta;
        private string ruta;
        private string[] cabecera;
        private string titulo;
        private string rangocabecera;

        #region Encapsulamiento
        public string Consulta { get => consulta; set => consulta = value; }
        public string Ruta { get => ruta; set => ruta = value; }
        public string[] Cabecera { get => cabecera; set => cabecera = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string RangoCabecera { get => rangocabecera; set => rangocabecera = value; }

        #endregion

        public void GenerarExcel()
        {
            System.Data.DataTable detalles = new System.Data.DataTable();
            int i = 0, j = 0;

            //Carga de los Productos
            detalles = Consulta(consulta);

            //Llamado a la api de Excle y declaracion de las variables pertinentes            
            objExcel.Application objAplicacion = new objExcel.Application();
            Workbook objLibro = objAplicacion.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet objHoja = (Worksheet)objAplicacion.ActiveSheet;
            objExcel.Range rango = null;
            objExcel.Style style = objLibro.Styles.Add("EstiloCabecera");
            objHoja.Cells.RowHeight = 18;
            objHoja.Cells.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);


            //definimos el estilo que tendra las cabeceras
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            style.Font.Bold = true;
            style.HorizontalAlignment = objExcel.XlHAlign.xlHAlignCenter;
            style.VerticalAlignment = objExcel.XlVAlign.xlVAlignCenter;
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

            //definicion de los valores de la Cabecera
            for (int k = 0; k < detalles.Columns.Count; k++)
            {
                objHoja.Cells[5, k + 3] = Cabecera[k];
            }

            //Titulo
            objHoja.Cells[2, 3] = "Tecno PC";
            objHoja.Cells[2, 3].Font.Size = 18;
            objHoja.Cells[2, 3].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            objHoja.Cells[2, 3].Borders[objExcel.XlBordersIndex.xlEdgeBottom].LineStyle = objExcel.XlLineStyle.xlContinuous;
            objHoja.Cells[2, 3].Borders[objExcel.XlBordersIndex.xlEdgeBottom].Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
            objHoja.Cells[3, 3] = titulo;
            objHoja.Cells[3, 3].Font.Size = 11;

            //Fecha
            i = detalles.Columns.Count;
            objHoja.Cells[2, i + 2] = "Fecha: " + DateTime.Now.ToShortDateString();            

            //creacion de la hoja de calculo                   
            for (i = 0; i < detalles.Columns.Count; i++)
            {
                for (j = 0; j < detalles.Rows.Count; j++)
                {
                    objHoja.Cells[j + 6, i + 3] = detalles.Rows[j][i].ToString();
                    objHoja.Cells[j + 6, i + 3].Borders.LineStyle = objExcel.XlLineStyle.xlContinuous;
                    objHoja.Cells[j + 6, i + 3].Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                }

                rango = objHoja.Columns[i + 3];
                rango.Columns.AutoFit();
                rango.HorizontalAlignment = objExcel.XlHAlign.xlHAlignLeft;
            }

            //creacion de la cabecera
            objHoja.Cells[2, i + 2].HorizontalAlignment = objExcel.XlHAlign.xlHAlignRight;
            objHoja.Cells[2, i + 2].Font.Bold = true;
            rango = objHoja.Range[rangocabecera.Substring(0, 2), rangocabecera.Substring(3, 2)];
            rango.Style = "EstiloCabecera";
            rango.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            rango.Borders.LineStyle = objExcel.XlLineStyle.xlContinuous;            

            objAplicacion.Visible = true;//si es true se abrira automaticamente si es false no se abrira 

            //guardado del libro
            try
            {
                objLibro.SaveAs(ruta);
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
