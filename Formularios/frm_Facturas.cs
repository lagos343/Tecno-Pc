using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using objExcel = Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Formularios
{
    public partial class frm_Facturas : Form
    {
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        DataGridView dgv = new DataGridView();
        DataGridView dgvDetalle = new DataGridView();

        public frm_Facturas()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void frm_Facturas_Load(object sender, EventArgs e)
        {
            dgv_Facturas.DataSource = sql.Consulta("select [ID Factura], (c.Nombre +' '+ c.Apellido) Cliente, (e.Nombre +' '+ e.Apellido) Empleado, t.[Tipo Transaccion] Transaccion, f.[Fecha Venta], f.[Fecha Vencimiento] " +
                "from Facturas f inner join Clientes c on c.[ID Cliente] = f.[ID Cliente] inner join Empleados e on e.[ID Empleado] = f.[ID Empleado] inner join Transacciones t on t.[ID Transaccion] " +
                "= f.[ID Transaccion] order by f.[ID Factura] desc");
            operacionesDatagrid();
        }

        private void operacionesDatagrid()
        {            
            dgv_Facturas.Columns[0].Width = 30;
            dgv_Facturas.Columns[4].Width = 100;
            dgv_Facturas.Columns[5].Width = 100;           

            dgv_Facturas.Columns[1].Visible = false;
            dgv_Facturas.Columns[6].Visible = false;
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
                        
        }

        private async void dgv_Facturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Facturas.Rows[e.RowIndex].Cells["Mostrar"].Selected)
            {
                dgv = dgv_Facturas; 
                
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    frm_notificacion noti = new frm_notificacion("", 4);
                    noti.Show();

                    Task tar1 = new Task(exelFacturas); 
                    tar1.Start();
                    await tar1;

                    noti.Close();
                }
                
            }
        }

        public void exelFacturas()
        {
            //Variables            
            System.Data.DataTable detalles = new System.Data.DataTable();
            string id, empleado, cliente, transac, Fventa, Fvenci;            

            //Carga de datos desde el datagrid
            id = dgv.CurrentRow.Cells[1].Value.ToString();
            empleado = dgv.CurrentRow.Cells[3].Value.ToString();
            cliente = dgv.CurrentRow.Cells[2].Value.ToString();
            transac = dgv.CurrentRow.Cells[4].Value.ToString();
            Fventa = dgv.CurrentRow.Cells[5].Value.ToString();
            Fvenci = dgv.CurrentRow.Cells[6].Value.ToString();

            //carga de lo detalles
            detalles = sql.Consulta("select df.[ID Factura], p.[Nombre Producto], df.[Precio Historico], df.Cantidad, (df.[Precio Historico] * df.Cantidad) Total from DetalleFactura df " +
                "inner join Productos p on p.[ID Producto] = df.[ID Producto] where df.[ID Factura] =" + id);

            //inicio del objeto excel
            string ruta = saveFileDialog1.FileName;
            objExcel.Application objAplicacion = new objExcel.Application();
            Workbook objLibro = objAplicacion.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet objHoja = (Worksheet)objAplicacion.ActiveSheet;
            objExcel.Range rango = null;
            objExcel.Style style = objLibro.Styles.Add("EstiloCabecera");       
            objHoja.Cells.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            objHoja.Cells.RowHeight = 18;

            //definimos el estilo que tendra las cabeceras
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            style.Font.Bold = true;
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);                     


            //creacion de la hoja de calculo                   
            for (int i=1; i< detalles.Columns.Count; i++)
            {               
                for (int j=0; j<detalles.Rows.Count; j++)
                {
                    objHoja.Cells[j+13, i+2] = detalles.Rows[j][i].ToString();
                    objHoja.Cells[j + 13, i + 2].Borders.LineStyle = objExcel.XlLineStyle.xlContinuous;
                }

                rango = objHoja.Columns[i+3];
                //rango.Columns.AutoFit();
                rango.HorizontalAlignment = objExcel.XlHAlign.xlHAlignLeft;
            }

            //Cargando la cabecera
            objHoja.Cells[12, 3] = "Descripcion";
            objHoja.Cells[12, 4] = "Precio Unitario";
            objHoja.Cells[12, 5] = "Cant.";
            objHoja.Cells[12, 6] = "Total";

            rango = objHoja.Columns[3];
            rango.ColumnWidth = 45;
            rango = objHoja.Columns[4];
            rango.ColumnWidth = 20;
            rango = objHoja.Columns[5];
            rango.ColumnWidth = 14;
            rango = objHoja.Columns[6];
            rango.ColumnWidth = 13;

            //creacion de la cabecera
            rango = objHoja.Range["C12", "f12"];
            rango.Style = "EstiloCabecera";
            rango.HorizontalAlignment = objExcel.XlHAlign.xlHAlignCenter;
            rango.VerticalAlignment = objExcel.XlVAlign.xlVAlignCenter;


            //Nombre de la empresa y Datos
            objHoja.Cells[2, 3] = "Tecno PC";
            objHoja.Cells[2, 3].Font.Size = 18;
            objHoja.Cells[2, 3].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);

            objHoja.Cells[3, 3] = "Edificio Plaza América Colonia Florencia Norte";
            objHoja.Cells[3, 3].Font.Size = 11;
            objHoja.Cells[4, 3] = "pctecno536@gmail.com";
            objHoja.Cells[4, 3].Font.Size = 11;
            objHoja.Cells[5, 3] = "9875-2356";
            objHoja.Cells[5, 3].Font.Size = 11;

            //Datos cliente y vendedor
            objHoja.Cells[7, 3] = "Cliente";
            objHoja.Cells[7, 3].Font.Size = 11;
            objHoja.Cells[7, 3].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            objHoja.Cells[8, 3] = cliente;
            objHoja.Cells[8, 3].Font.Size = 11;

            objHoja.Cells[9, 3] = "Empleado";
            objHoja.Cells[9, 3].Font.Size = 11;
            objHoja.Cells[9, 3].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            objHoja.Cells[10, 3] = empleado;
            objHoja.Cells[10, 3].Font.Size = 11;

            //no factura
            objHoja.Cells[2, 6] = "Factura #" + id;
            objHoja.Cells[2, 6].Font.Size = 18;
            objHoja.Cells[2, 6].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
            objHoja.Cells[2, 6].Font.Bold = true;

            rango = objHoja.Range["E2:F2"];
            rango.Columns.MergeCells = true;
            rango.HorizontalAlignment = objExcel.XlHAlign.xlHAlignRight;
            rango.VerticalAlignment = objExcel.XlVAlign.xlVAlignCenter;

            //Fechas y transacciones
            objHoja.Cells[7, 5] = "Transaccion";                  
            objHoja.Cells[7, 5].Font.Bold = true;

            objHoja.Cells[8, 5] = "Fecha";
            objHoja.Cells[8, 5].Font.Bold = true;

            objHoja.Cells[9, 5] = "Vencimiento";
            objHoja.Cells[9, 5].Font.Bold = true;

            rango = objHoja.Range["E7:E10"];
            rango.HorizontalAlignment = objExcel.XlHAlign.xlHAlignRight;

            objHoja.Cells[7, 6] = transac;    
            objHoja.Cells[8, 6] = Fventa.Substring(0, 8).ToString();           
            objHoja.Cells[9, 6] = Fvenci.Substring(0, 8).ToString();

            rango = objHoja.Range["F7:F10"];
            rango.HorizontalAlignment = objExcel.XlHAlign.xlHAlignLeft;

            objAplicacion.Visible = true;//si es true se abrira automaticamente si es false no se abrira  

            //guardado del libro
            try
            {
                objLibro.SaveAs(ruta);
            }
            catch (Exception ex)
            {
                frm_notificacion noti2 = new frm_notificacion("No se puede modificar un archivo en uso, en su lugar se creo uno nuevo", 3);
                noti2.ShowDialog();
                noti2.Close();
            }

            //objLibro.Close();
            //objAplicacion.Quit();            
        }
    }
}
