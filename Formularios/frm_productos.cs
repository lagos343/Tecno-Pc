using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using objExcel = Microsoft.Office.Interop.Excel;

namespace Tecno_Pc.Formularios
{
    public partial class frm_productos : Form
    {
        Clases.Cl_Productos prod = new Clases.Cl_Productos();
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();

        public frm_productos()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void frm_productos_Load(object sender, EventArgs e)
        {
            Dashboard();
        }

        public void Dashboard()
        {
            lbl_totalProductos.Text = sql.Consulta("select *from Productos where Estado = 1").Rows.Count.ToString();
            lbl_totalMarcas.Text = sql.Consulta("select *from Marcas").Rows.Count.ToString();
            lbl_TotalCategorias.Text = sql.Consulta("select *from Categorias").Rows.Count.ToString();
            lbl_ProductosTotales.Text = sql.Consulta2("select sum(Stock) as Stock from Inventarios");

            prod.consultarDatos(dgv_Productos);            
            operacionesDataGrid();
        }

        public void operacionesDataGrid()        
        {            
            dgv_Productos.Columns[2].Visible = false;
            dgv_Productos.Columns[3].Visible = false;
            dgv_Productos.Columns[4].Visible = false;
            dgv_Productos.Columns[5].Visible = false;
            dgv_Productos.Columns[9].Visible = false;

            dgv_Productos.Columns[0].Width = 50;
            dgv_Productos.Columns[1].Width = 50;            
        }

        private void btn_categorias_Click(object sender, EventArgs e)
        {
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_MarcasCategorias);
            if (frm == null)
            {
                frm_MarcasCategorias catego = new frm_MarcasCategorias(1);
                catego.Show();
            }
            else
            {
                frm.BringToFront();
            }                                 
        }

        private void btn_Marcas_Click(object sender, EventArgs e)
        {
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_MarcasCategorias);
            if (frm == null)
            {
                frm_MarcasCategorias marcas = new frm_MarcasCategorias(2);
                marcas.Show();
            }
            else
            {
                frm.BringToFront();
            }                    
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            prod.NombreProducto = txt_buscar.Text;
            prod.buscarDatos(dgv_Productos);
            operacionesDataGrid();
        }

        private void btn_nuevoProducto_Click(object sender, EventArgs e)
        {
            frm_AñadirProductos prod = new frm_AñadirProductos(1, dgv_Productos);
            prod.ShowDialog();
            
        }

        private void dgv_Productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Productos.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                frm_AñadirProductos aña = new frm_AñadirProductos(2, dgv_Productos);
                aña.ShowDialog();
                

            } else if (dgv_Productos.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea eliminar este producto?", 2);
                noti.ShowDialog();

                if (noti.Dialogresul == DialogResult.OK)
                {
                    prod.IDProducto = int.Parse(dgv_Productos.CurrentRow.Cells[2].Value.ToString());
                    prod.eliminarDatos();
                }

                noti.Close();
            }
        }

        private async void btn_Imprimir_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                frm_notificacion noti = new frm_notificacion("", 4);
                noti.Show();

                Task tar1 = new Task(excelProductos);
                tar1.Start();
                await tar1;

                noti.Close();

                //frm_notificacion noti2 = new frm_notificacion("Se ha guardado el excel con los datos", 1);
                //noti2.ShowDialog();
                //noti.Close();
            }                                                 
        }

        public void excelProductos()
        {
            System.Data.DataTable detalles = new System.Data.DataTable();
            int i = 0, j = 0;

            //Carga de los Productos
            detalles = sql.Consulta("select p.[Nombre Producto], p.Modelo, p.[Precio Unitario], c.[Nombre Categoria], m.[Nombre Marca], pr.Nombre, " +
                "(select Stock from Inventarios Where [ID Producto] = p.[ID Producto]) as Stock from Productos p " +
                "inner join Categorias c on c.[ID Categoria] = p.[ID Categoria] inner join Marcas m on m.[ID Marca] = p.[ID Marca] inner join Proveedores pr on " +
                "pr.[ID Proveedor] = p.[ID Proveedor] where p.Estado = 1");

            //Llamado a la api de Excle y declaracion de las variables pertinentes
            string ruta = saveFileDialog1.FileName;
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

            //definicion de los valores de la Cabevcera
            objHoja.Cells[5, 3] = "Producto";
            objHoja.Cells[5, 4] = "Modelo";
            objHoja.Cells[5, 5] = "Precio";
            objHoja.Cells[5, 6] = "Categoria";
            objHoja.Cells[5, 7] = "Marca";
            objHoja.Cells[5, 8] = "Proveedor";
            objHoja.Cells[5, 9] = "Stock";


            //Titulo
            objHoja.Cells[2, 3] = "Tecno PC";
            objHoja.Cells[2, 3].Font.Size = 18;
            objHoja.Cells[2, 3].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            objHoja.Cells[2, 3].Borders[objExcel.XlBordersIndex.xlEdgeBottom].LineStyle = objExcel.XlLineStyle.xlContinuous;
            objHoja.Cells[2, 3].Borders[objExcel.XlBordersIndex.xlEdgeBottom].Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);            

            objHoja.Cells[3, 3] = "Reporte de Inventarios de Productos";
            objHoja.Cells[3, 3].Font.Size = 11;

            objHoja.Cells[2, 9] = DateTime.Now.ToShortDateString();


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
            rango = objHoja.Range["C5", "I5"];
            rango.Style = "EstiloCabecera";
            rango.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            rango.Borders.LineStyle = objExcel.XlLineStyle.xlContinuous;


            //Fecha
            objHoja.Cells[2, 8] = "Fecha:";
            objHoja.Cells[2, 8].HorizontalAlignment = objExcel.XlHAlign.xlHAlignRight;
            objHoja.Cells[2, 8].Font.Bold = true;         
            
            objAplicacion.Visible = true;//si es true se abrira automaticamente si es false no se abrira 

            //guardado del libro
            try
            {
                objLibro.SaveAs(ruta);
            }
            catch (Exception ex)
            {
                frm_notificacion noti2 = new frm_notificacion("Ocurrio un error al modificar el archivo, en su lugar se creo uno nuevo", 3);
                noti2.ShowDialog();
                noti2.Close();
            }

            //objLibro.Close();
            //objAplicacion.Quit();            
        }
    }
}
