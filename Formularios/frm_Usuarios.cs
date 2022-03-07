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
    public partial class frm_Usuarios : Form
    {

        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Usuarios user = new Clases.Cl_Usuarios();
        Clases.Cl_UsuarioLogueado login = new Clases.Cl_UsuarioLogueado();
        public frm_Usuarios()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.btn_reporte, "Crear Reporte");
            this.toolTip1.SetToolTip(this.btn_nuevoUsuario, "Agregar Usuario");
            this.toolTip1.SetToolTip(this.gunaGradientButton1, "Gestionar Cliente");
            this.toolTip1.SetToolTip(this.txt_buscar, "Buscar");
        }    

        public void carga()
        {
            user.consultarDatos(dgv_Productos);
            operacionesdgv();
            usuarios();

            foreach(DataGridViewColumn columna in dgv_Productos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        private void frm_Usuarios_Load(object sender, EventArgs e)
        {
            carga();
        }

        private void btn_nuevoUsuario_Click(object sender, EventArgs e)
        {
            frm_AñadirUsuarios a_usu = new frm_AñadirUsuarios(1, dgv_Productos);
            a_usu.ShowDialog();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            frm_clientes cli = new frm_clientes();
            cli.ShowDialog();
        }
        private void operacionesdgv()
        {
            dgv_Productos.Columns[2].Visible = false;
            dgv_Productos.Columns[3].Visible = false;
            dgv_Productos.Columns[4].Visible = false;
            dgv_Productos.Columns[6].Visible = false;
            dgv_Productos.Columns[7].Visible = false;
            dgv_Productos.Columns[8].Visible = false;
            dgv_Productos.Columns[9].Visible = false;

            dgv_Productos.Columns[0].Width = 50;
            dgv_Productos.Columns[1].Width = 50;
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            user.Nombre_usuario = txt_buscar.Text;
            user.buscarDatos(dgv_Productos);
            operacionesdgv();
        }

        private void dgv_Productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                if (dgv_Productos.Rows[e.RowIndex].Cells["Editar"].Selected)
                {
                    frm_AñadirUsuarios añaem = new frm_AñadirUsuarios(2, dgv_Productos);
                    añaem.ShowDialog();


                }
                else if (dgv_Productos.Rows[e.RowIndex].Cells["Eliminar"].Selected)
                {
                    Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea eliminar este usuario?", 2);
                    noti.ShowDialog();

                    if (noti.Dialogresul == DialogResult.OK)
                    {
                        user.Id_usuarios = int.Parse(dgv_Productos.CurrentRow.Cells[2].Value.ToString());
                        user.eliminar();

                        #region limpieza
                        lbl_id.Text = "";
                        lbl_contra.Text = "";
                        lbl_propietario.Text = "";
                        lbl_tipo.Text = "";
                        lbl_user.Text = "";
                        #endregion
                    }

                    noti.Close();
                }
                else if (dgv_Productos.Rows[e.RowIndex].Cells["Nombre Usuario"].Selected)
                {
                    lbl_id.Text = dgv_Productos.CurrentRow.Cells[2].Value.ToString();
                    lbl_user.Text = dgv_Productos.CurrentRow.Cells[5].Value.ToString();
                    lbl_contra.Text = dgv_Productos.CurrentRow.Cells[6].Value.ToString().Substring(0, 2) + "**********"; 
                    lbl_propietario.Text = dgv_Productos.CurrentRow.Cells[8].Value.ToString();
                    lbl_tipo.Text = dgv_Productos.CurrentRow.Cells[9].Value.ToString();
                }
            }
            catch(Exception ex) { }
            
        }



        private void usuarios()
        {
            if (login.IdRol_ == 3 || login.IdRol_ == 2)
            {
                btn_nuevoUsuario.Hide();
                dgv_Productos.Hide();
                txt_buscar.Hide();
                pictureBox5.Hide();
                pictureBox6.Hide();
                lbl_id.Text = login.IdRol_.ToString();
                lbl_user.Text = login.Usuario_;
                lbl_contra.Text = login.Contraseña_.Substring(0, 2)+"**********";
                lbl_propietario.Text = login.Propietario_;
                lbl_tipo.Text = login.Rol_;
                btn_reporte.Hide();
            }
            if (login.IdRol_ == 3 || login.IdRol_ == 4)
            {
                gunaGradientButton1.Hide();
            }

        }

        private async void btn_reporte_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                frm_notificacion noti = new frm_notificacion("", 4);
                noti.Show();

                Task tar1 = new Task(excelusuarios);
                tar1.Start();
                await tar1;

                noti.Close();
            }
        }
        public void excelusuarios()
        {

            System.Data.DataTable detalles = new System.Data.DataTable();
            int i = 0, j = 0;

            //Carga de los Productos

            detalles = sql.Consulta("Select Usuarios.[ID Usuario] [Id], Roles.[Nombre Rol] [Roles], " + 
            "Empleados.Nombre + ' ' + Empleados.Apellido [Empleados], Usuarios.[Nombre Usuario] [Nombre] " +
            " from Usuarios " +   
            " inner join Roles on Usuarios.[ID Rol] = Roles.IDRol inner join "+
            "Empleados on Usuarios.[ID Empleado] = Empleados.[ID Empleado] "+
            "WHERE Empleados.Estado = 1 ORDER BY Nombre ASC");

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
            objHoja.Cells[5, 3] = "Id";
            objHoja.Cells[5, 4] = "Roles";
            objHoja.Cells[5, 5] = "Empleados";
            objHoja.Cells[5, 6] = "Nombre";

            //Titulo
            objHoja.Cells[2, 3] = "Tecno PC";
            objHoja.Cells[2, 3].Font.Size = 18;
            objHoja.Cells[2, 3].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            objHoja.Cells[2, 3].Borders[objExcel.XlBordersIndex.xlEdgeBottom].LineStyle = objExcel.XlLineStyle.xlContinuous;
            objHoja.Cells[2, 3].Borders[objExcel.XlBordersIndex.xlEdgeBottom].Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

            objHoja.Cells[3, 3] = "Reporte de Usuarios";
            objHoja.Cells[3, 3].Font.Size = 11;

            objHoja.Cells[2, 6] = DateTime.Now.ToShortDateString();

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
                rango.Cells.ColumnWidth = 20;
                rango.HorizontalAlignment = objExcel.XlHAlign.xlHAlignLeft;
            }

            //creacion de la cabecera
            rango = objHoja.Range["C5", "F5"];
            rango.Style = "EstiloCabecera";
            rango.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            rango.Borders.LineStyle = objExcel.XlLineStyle.xlContinuous;


            //Fecha
            objHoja.Cells[2, 5] = "Fecha:";
            objHoja.Cells[2, 5].HorizontalAlignment = objExcel.XlHAlign.xlHAlignRight;
            objHoja.Cells[2, 5].Font.Bold = true;

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
