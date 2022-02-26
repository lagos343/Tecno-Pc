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
    public partial class frm_empleados : Form
    {

        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Empleados empleados = new Clases.Cl_Empleados();
        public frm_empleados()
        {
            InitializeComponent();
        }

        private void btn_nuevoUsuario_Click(object sender, EventArgs e)
        {
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_AñadirEmpleado);
            if (frm == null)
            {
                frm_AñadirEmpleado añaem = new frm_AñadirEmpleado(1, dgv_Productos);
                añaem.Show();
            }
            else 
            {
                frm.BringToFront();
            }
        }

        private void frm_empleados_Load(object sender, EventArgs e)
        {
            carga();
        }

        public void carga() 
        {
            empleados.consultarDatos(dgv_Productos);
            operacionesdatarid();
            foreach (DataGridViewColumn columna in dgv_Productos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        private void operacionesdatarid()
        {
            dgv_Productos.Columns[2].Visible = false;
            dgv_Productos.Columns[3].Visible = false;
            dgv_Productos.Columns[4].Visible = false;
            dgv_Productos.Columns[8].Visible = false;
            dgv_Productos.Columns[9].Visible = false;
            dgv_Productos.Columns[10].Visible = false;
            dgv_Productos.Columns[11].Visible = false;
            dgv_Productos.Columns[12].Visible = false;
            dgv_Productos.Columns[13].Visible = false;
            dgv_Productos.Columns[0].Width = 50;
            dgv_Productos.Columns[1].Width = 50;
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            empleados.Nombre = txt_buscar.Text;
            empleados.buscardatos(dgv_Productos);
            operacionesdatarid();
            
        }


        private void dgv_Productos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_Productos.Rows[e.RowIndex].Cells["Editar"].Selected)
                {
                    frm_AñadirEmpleado añaem = new frm_AñadirEmpleado(2, dgv_Productos);
                    añaem.ShowDialog();
                }
                else if (dgv_Productos.Rows[e.RowIndex].Cells["Eliminar"].Selected)
                {
                    Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea eliminar este empleado?", 2);
                    noti.ShowDialog();

                    if (noti.Dialogresul == DialogResult.OK)
                    {
                        empleados.Idempleado = int.Parse(dgv_Productos.CurrentRow.Cells[2].Value.ToString());
                        empleados.eliminar();
                        #region Limpieza
                        lbl_id.Text = lbl_email.Text = "";
                        lbl_depto.Text = lbl_email.Text = "";
                        lbl_direccion.Text = lbl_email.Text = "";
                        lbl_puesto.Text = lbl_email.Text = "";
                        lbl_email.Text = "";
                        lbl_email.Text = "";
                        #endregion
                    }

                    noti.Close();
                }
                else if (dgv_Productos.Rows[e.RowIndex].Cells["Nombre"].Selected || dgv_Productos.Rows[e.RowIndex].Cells["Identidad"].Selected || dgv_Productos.Rows[e.RowIndex].Cells["Apellido"].Selected)
                {
                    lbl_id.Text = dgv_Productos.CurrentRow.Cells[6].Value.ToString();
                    lbl_depto.Text = dgv_Productos.CurrentRow.Cells[13].Value.ToString();
                    lbl_direccion.Text = dgv_Productos.CurrentRow.Cells[10].Value.ToString();
                    lbl_puesto.Text = dgv_Productos.CurrentRow.Cells[12].Value.ToString();
                    lbl_telefono.Text = dgv_Productos.CurrentRow.Cells[8].Value.ToString();
                    lbl_email.Text = dgv_Productos.CurrentRow.Cells[9].Value.ToString();

                }

            }
            catch(Exception ex)
            {
            }

            
        }

        private async void btn_reporte_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                frm_notificacion noti = new frm_notificacion("", 4);
                noti.Show();

                Task tar1 = new Task(excelEmpleados);
                tar1.Start();
                await tar1;

                noti.Close();
            }
        }

        public void excelEmpleados()
        {

            System.Data.DataTable detalles = new System.Data.DataTable();
            int i = 0, j = 0;

            //Carga de los Productos

            detalles = sql.Consulta("SELECT Empleados.Nombre  +' ' + Empleados.Apellido [Empleado], Empleados.Identidad, Empleados.Telefono, Empleados.[Correo Electronico], Departamentos.[Nombre Depto] [Departamento],Empleados.Direccion  FROM     Empleados INNER JOIN Departamentos ON Empleados.[ID Depto] =" +
                " Departamentos.[ID Depto] WHERE Empleados .Estado = 1 ORDER BY Empleado ASC");

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
            objHoja.Cells[5, 3] = "Empleado";
            objHoja.Cells[5, 4] = "Identidad";
            objHoja.Cells[5, 5] = "Telefono";
            objHoja.Cells[5, 6] = "Correo Electronico";
            objHoja.Cells[5, 7] = "Departamento";
            objHoja.Cells[5, 8] = "Dirección";

            //Titulo
            objHoja.Cells[2, 3] = "Tecno PC";
            objHoja.Cells[2, 3].Font.Size = 18;
            objHoja.Cells[2, 3].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            objHoja.Cells[2, 3].Borders[objExcel.XlBordersIndex.xlEdgeBottom].LineStyle = objExcel.XlLineStyle.xlContinuous;
            objHoja.Cells[2, 3].Borders[objExcel.XlBordersIndex.xlEdgeBottom].Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

            objHoja.Cells[3, 3] = "Reporte de Empleados";
            objHoja.Cells[3, 3].Font.Size = 11;

            objHoja.Cells[2, 8] =DateTime.Now.ToShortDateString();

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
            rango = objHoja.Range["C5", "H5"];
            rango.Style = "EstiloCabecera";
            rango.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            rango.Borders.LineStyle = objExcel.XlLineStyle.xlContinuous;


            //Fecha
             objHoja.Cells[2, 7] = "Fecha:";
             objHoja.Cells[2, 7].HorizontalAlignment = objExcel.XlHAlign.xlHAlignRight;
             objHoja.Cells[2, 7].Font.Bold = true;

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


        }
    }
}
