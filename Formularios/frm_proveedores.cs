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
    public partial class frm_proveedores : Form
    {

        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Proveedores proveedores = new Clases.Cl_Proveedores();


        public frm_proveedores()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.btn_contactos, "Gestionar Contactos");
            this.toolTip1.SetToolTip(this.btn_reporte, "Crear Reporte");
            this.toolTip1.SetToolTip(this.btn_nuevoUsuario, "Agregar Proveedor");
            this.toolTip1.SetToolTip(this.txt_buscar, "Buscar");

        }

        private void btn_nuevoUsuario_Click(object sender, EventArgs e)
        {
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_AñadirProveedores);

            if (frm == null)
            {
                frm_AñadirProveedores añapro = new frm_AñadirProveedores(1, dgv_Productos);
                añapro.Show();
            }
            else 
            {
                frm.BringToFront();
            }
        
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_contactos);
            if (frm == null)
            {
                frm_contactos contac = new frm_contactos();
                contac.Show();
            }
            else 
            {
                frm.BringToFront();
            }
        }

        private void frm_proveedores_Load(object sender, EventArgs e)
        {
            carga();
        }

        public void carga()
        {
            proveedores.consultarDatos(dgv_Productos);
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
            dgv_Productos.Columns[5].Visible = false;
            dgv_Productos.Columns[6].Visible = false;
            dgv_Productos.Columns[7].Visible = false;
            dgv_Productos.Columns[8].Visible = false;
            dgv_Productos.Columns[9].Visible = false;

            dgv_Productos.Columns[0].Width = 50;
            dgv_Productos.Columns[1].Width = 50;
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            proveedores.Nombre = txt_buscar.Text;
            proveedores.buscarDatos(dgv_Productos);
            operacionesdatarid();
        }

        private void dgv_Productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_Productos.Rows[e.RowIndex].Cells["Editar"].Selected)
                {
                    frm_AñadirProveedores añaem = new frm_AñadirProveedores(2, dgv_Productos);
                    añaem.ShowDialog();


                }
                else if (dgv_Productos.Rows[e.RowIndex].Cells["Eliminar"].Selected)
                {
                    Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea eliminar este proveedor?", 2);
                    noti.ShowDialog();

                    if (noti.Dialogresul == DialogResult.OK)
                    {
                        proveedores.IDProveedor = int.Parse(dgv_Productos.CurrentRow.Cells[2].Value.ToString());
                        proveedores.eliminar();
                        #region Limpieza
                        lbl_id.Text = "";
                        lbl_nombre.Text = "";
                        lbl_telefono.Text = "";
                        lbl_direccion.Text = "";
                        lbl_email.Text = "";
                        lbl_depto.Text = "";
                        #endregion
                    }

                    noti.Close();
                }
                else if (dgv_Productos.Rows[e.RowIndex].Cells["Nombre"].Selected)
                {
                    lbl_id.Text = dgv_Productos.CurrentRow.Cells[2].Value.ToString();
                    lbl_nombre.Text = dgv_Productos.CurrentRow.Cells[4].Value.ToString();
                    lbl_telefono.Text = dgv_Productos.CurrentRow.Cells[5].Value.ToString();
                    lbl_direccion.Text = dgv_Productos.CurrentRow.Cells[6].Value.ToString();
                    lbl_email.Text = dgv_Productos.CurrentRow.Cells[7].Value.ToString();
                    lbl_depto.Text = dgv_Productos.CurrentRow.Cells[9].Value.ToString();

                }
            }
            catch (Exception ex) { }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            /*Ignorar*/
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {

        }

        private async void btn_reporte_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                frm_notificacion noti = new frm_notificacion("", 4);
                noti.Show();

                Task tar1 = new Task(excelProveedores);
                tar1.Start();
                await tar1;

                noti.Close();
            }

        }


        public void excelProveedores()
        {
            System.Data.DataTable detalles = new System.Data.DataTable();
            int i = 0, j = 0;

            //Carga de los Productos

            detalles = sql.Consulta("SELECT Proveedores.Nombre, Proveedores.Telefono,Departamentos.[Nombre Depto] [Departamento], Proveedores.Direccion, Proveedores.[Correo Electronico] FROM    " +
                " Proveedores INNER JOIN  Departamentos ON Proveedores.[ID Depto] = Departamentos.[ID Depto]" +
                " WHERE Proveedores.Estado = 1 ORDER BY Nombre asc");

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
            objHoja.Cells[5, 3] = "Proveedor";
            objHoja.Cells[5, 4] = "Telefono";
            objHoja.Cells[5, 5] = "Departamento";
            objHoja.Cells[5, 6] = "Dirección";
            objHoja.Cells[5, 7] = "Correo Electrónico";

            //Titulo
            objHoja.Cells[2, 3] = "Tecno PC";
            objHoja.Cells[2, 3].Font.Size = 18;
            objHoja.Cells[2, 3].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            objHoja.Cells[2, 3].Borders[objExcel.XlBordersIndex.xlEdgeBottom].LineStyle = objExcel.XlLineStyle.xlContinuous;
            objHoja.Cells[2, 3].Borders[objExcel.XlBordersIndex.xlEdgeBottom].Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

            objHoja.Cells[3, 3] = "Reporte de Proveedores";
            objHoja.Cells[3, 3].Font.Size = 11;

            objHoja.Cells[2, 7] = "Fecha: "+DateTime.Now.ToShortDateString();
            objHoja.Cells[2, 7].HorizontalAlignment = objExcel.XlHAlign.xlHAlignRight;

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
            rango = objHoja.Range["C5", "G5"];
            rango.Style = "EstiloCabecera";
            rango.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            rango.Borders.LineStyle = objExcel.XlLineStyle.xlContinuous;


            //Fecha
           /* objHoja.Cells[2, 6] = "Fecha:";
            objHoja.Cells[2, 6].HorizontalAlignment = objExcel.XlHAlign.xlHAlignRight;
            objHoja.Cells[2, 6].Font.Bold = true;*/

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
