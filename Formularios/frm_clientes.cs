using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using objExcel = Microsoft.Office.Interop.Excel;

namespace Tecno_Pc.Formularios
{

    public partial class frm_clientes : Form
    {

        bool actualizar = false;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Clases.Cl_Clientes cli = new Clases.Cl_Clientes();
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();

        public frm_clientes()
        {

            InitializeComponent();
            InicializarCombobox();
            //Tooltip
            this.ttMensaje.SetToolTip(this.cmb_Depto, "Combobox de departamento");
            this.ttMensaje.SetToolTip(this.txt_Ident, "Caja de texto del No. de Identidad del Cliente");
            this.ttMensaje.SetToolTip(this.txt_Nombre, "Caja de texto del Nombre del Cliente");
            this.ttMensaje.SetToolTip(this.txt_Apell, "Caja de texto del Apellido del Cliente");
            this.ttMensaje.SetToolTip(this.txt_Tel, "Caja de texto del Telefono del Cliente");
            this.ttMensaje.SetToolTip(this.txt_Email, "Caja de texto del Correo del Cliente");
            this.ttMensaje.SetToolTip(this.txt_Direccion, "Caja de texto de la Direccion del Cliente");
            this.ttMensaje.SetToolTip(this.txt_buscar, "Caja de texto de busqueda filtrada por Nombre");
            this.ttMensaje.SetToolTip(this.btn_imprimir, "Boton para exportar reporte de Clientes a Excel");
            this.ttMensaje.SetToolTip(this.btn_salir, "Salir");
            this.ttMensaje.SetToolTip(this.btn_minimizar, "Minimizar");
            this.ttMensaje.SetToolTip(this.btn_nuevo, "Boton para Limpiar las cajas de texto");
            this.ttMensaje.SetToolTip(this.btn_editar, "Boton para Editar la informacion del Cliente");
            this.ttMensaje.SetToolTip(this.btn_eliminar, "Boton para Eliminar la informacion del Cliente");
            this.ttMensaje.SetToolTip(this.btn_guardar, "Boton para Guardar informacion del Cliente");


        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_guardarGuardado_Click(object sender, EventArgs e)
        {

        }
        private void Limnpiado()
        {
            cmb_Depto.SelectedIndex = -1;
            txt_Ident.Clear();
            txt_id.Clear();
            txt_Nombre.Clear();
            txt_Apell.Clear();
            txt_Tel.Clear();
            txt_Email.Clear();
            txt_Direccion.Clear();
            actualizar = false;
        }

        public void operacionesDataGrid()
        {
            dgv_datos.Columns[0].Visible = false;
            dgv_datos.Columns[1].Visible = false;
            dgv_datos.Columns[7].Visible = false;
            dgv_datos.Columns[8].Visible = false;

            dgv_datos.Columns[2].Width = 100;
            dgv_datos.Columns[5].Width = 80;

        }


        public void InicializarCombobox()
        {
            cmb_Depto.DataSource = sql.Consulta("select *from Departamentos order by [Nombre Depto] asc");
            cmb_Depto.DisplayMember = "Nombre Depto";
            cmb_Depto.ValueMember = "ID Depto";
            cmb_Depto.SelectedIndex = -1;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

            if (cmb_Depto.SelectedIndex == -1 || txt_Ident.Text == "" || txt_Nombre.Text == "" || txt_Apell.Text == "" || txt_Tel.Text == "" || txt_Email.Text == "" ||
                txt_Direccion.Text == "")
            {
                frm_notificacion noti = new frm_notificacion("Llene todos los datos", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {



                if (actualizar == true)
                {
                    cli.IDCliente = int.Parse(txt_id.Text.ToString());
                    cli.IDDepto = int.Parse(cmb_Depto.SelectedValue.ToString());
                    cli.identidad = txt_Ident.Text;
                    cli.Nombree = txt_Nombre.Text;
                    cli.Apellidoo = txt_Apell.Text;
                    cli.Telefonoo = txt_Tel.Text;
                    cli.CorreoElectronicoo = txt_Email.Text;
                    cli.Direccionn = txt_Direccion.Text;
                    cli.actualizarDatos();
                }
                else
                {
                    cli.IDDepto = int.Parse(cmb_Depto.SelectedValue.ToString());
                    cli.identidad = txt_Ident.Text;
                    cli.Nombree = txt_Nombre.Text;
                    cli.Apellidoo = txt_Apell.Text;
                    cli.Telefonoo = txt_Tel.Text;
                    cli.CorreoElectronicoo = txt_Email.Text;
                    cli.Direccionn = txt_Direccion.Text;
                    cli.guardar();
                }


                btn_guardar.Text = "Guardar";
                dgv_datos.DataSource = sql.Consulta("select * from Clientes where Estado=1");
                operacionesDataGrid();
                Limnpiado();
            }
        }

        private void frm_clientes_Load(object sender, EventArgs e)
        {
            dgv_datos.DataSource = sql.Consulta("select * from Clientes where Estado=1");
            operacionesDataGrid();
            InicializarCombobox();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {

            if (dgv_datos.CurrentRow == null)
            {
                frm_notificacion noti = new frm_notificacion("Escoja algo antes para poder modificarlo", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                InicializarCombobox();
                txt_id.Text = dgv_datos.CurrentRow.Cells[0].Value.ToString();
                cmb_Depto.SelectedValue = dgv_datos.CurrentRow.Cells[1].Value.ToString();
                txt_Ident.Text = dgv_datos.CurrentRow.Cells[2].Value.ToString();
                txt_Nombre.Text = dgv_datos.CurrentRow.Cells[3].Value.ToString();
                txt_Apell.Text = dgv_datos.CurrentRow.Cells[4].Value.ToString();
                txt_Tel.Text = dgv_datos.CurrentRow.Cells[5].Value.ToString();
                txt_Email.Text = dgv_datos.CurrentRow.Cells[6].Value.ToString();
                txt_Direccion.Text = dgv_datos.CurrentRow.Cells[7].Value.ToString();
                actualizar = true;
                btn_guardar.Text = "Actualizar";
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            cli.IDCliente = int.Parse(dgv_datos.CurrentRow.Cells[0].Value.ToString());
            cli.eliminarDatos();
            dgv_datos.DataSource = sql.Consulta("select * from Clientes where Estado=1");
            operacionesDataGrid();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            Limnpiado();
            btn_guardar.Text = "Guardar";
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            cli.Nombree = txt_buscar.Text;
            cli.buscarDatos(dgv_datos);
            operacionesDataGrid();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private async void btn_imprimir_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                frm_notificacion noti = new frm_notificacion("", 4);
                noti.Show();

                Task tar1 = new Task(excelClientes);
                tar1.Start();
                await tar1;

                noti.Close();

                //frm_notificacion noti2 = new frm_notificacion("Se ha guardado el excel con los datos", 1);
                //noti2.ShowDialog();
                //noti.Close();
            }

        }

        public void excelClientes()
        {

            System.Data.DataTable detalles = new System.Data.DataTable();
            int i = 0, j = 0;

            //Carga de los Productos
            detalles = sql.Consulta(" select  c.Nombre, c.Apellido, c.Identidad, c.Telefono, c.Direccion, c.[Correo Electronico], d.[Nombre Depto] from Clientes as c inner join Departamentos as D  on D.[ID Depto] = c.[ID Depto] Where Estado = 1");


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
            objHoja.Cells[5, 3] = "Nombre";
            objHoja.Cells[5, 5] = "Identidad";
            objHoja.Cells[5, 6] = "Telefono";
            objHoja.Cells[5, 4] = "Apellido";
            objHoja.Cells[5, 7] = "Direccion";
            objHoja.Cells[5, 8] = "Correo Electronico";
            objHoja.Cells[5, 9] = "Departamento";

            //Titulo
            objHoja.Cells[2, 3] = "Tecno PC";
            objHoja.Cells[2, 3].Font.Size = 18;
            objHoja.Cells[2, 3].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            objHoja.Cells[2, 3].Borders[objExcel.XlBordersIndex.xlEdgeBottom].LineStyle = objExcel.XlLineStyle.xlContinuous;
            objHoja.Cells[2, 3].Borders[objExcel.XlBordersIndex.xlEdgeBottom].Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

            objHoja.Cells[3, 3] = "Reporte de Clientes";
            objHoja.Cells[3, 3].Font.Size = 11;

            objHoja.Cells[2, 9] = DateTime.Now.ToShortDateString();


            //creacion de la hoja de calculo                   
            for (i = 0; i < detalles.Columns.Count; i++)
            {
                for (j = 0; j < detalles.Rows.Count; j++)
                {
                    if (i + 3 == 5)
                    {
                        objHoja.Cells[j + 6, i + 3] = "'" + detalles.Rows[j][i].ToString();
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

                //creacion de la cabecera
                rango = objHoja.Range["C5", "I5"];
                rango.Style = "EstiloCabecera";
                rango.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                rango.Borders.LineStyle = objExcel.XlLineStyle.xlContinuous;

            }
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
