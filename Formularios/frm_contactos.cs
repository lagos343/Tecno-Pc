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
using System.Text.RegularExpressions;



namespace Tecno_Pc.Formularios
{
    public partial class frm_contactos : Form
    {
        bool actualizar = false;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Clases.Cl_Contactos con = new Clases.Cl_Contactos();
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();


        public frm_contactos()
        {
            InitializeComponent();
            InicializarCombobox();
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

        
        private void Limnpiado()
        {
            cmb_depto.SelectedIndex = -1;
            cmb_proveedor.SelectedIndex = -1;
            txt_id.Clear();
            txt_nombre.Clear();
            txt_apellido.Clear();
            txt_telefono.Clear();
            txt_email.Clear();
            txt_direccion.Clear();
            actualizar = false;
            erp_apellido.Clear();
            erp_depto.Clear();
            erp_direccion.Clear();
            erp_email.Clear();
            erp_nombre.Clear();
            erp_porveedor.Clear();
            erp_telefono.Clear();
        }

        public void operacionesDataGrid()
        {
            dgv_datos.Columns[0].Visible = false;
            dgv_datos.Columns[1].Visible = false;
            dgv_datos.Columns[6].Visible = false;
            dgv_datos.Columns[8].Visible = false;
        }

        public void InicializarCombobox()
        {
            cmb_depto.DataSource = sql.Consulta("select *from Departamentos order by [Nombre Depto] asc");
            cmb_depto.DisplayMember = "Nombre Depto";
            cmb_depto.ValueMember = "ID Depto";
            cmb_depto.SelectedIndex = -1;

            cmb_proveedor.DataSource = sql.Consulta("select * from Proveedores order by [Nombre] asc");
            cmb_proveedor.DisplayMember = "Nombre";
            cmb_proveedor.ValueMember = "ID Proveedor";
            cmb_proveedor.SelectedIndex = -1;
        }


        private void frm_contactos_Load(object sender, EventArgs e)
                
        private void frm_contactos_Load(object sender, EventArgs e)
        {
            dgv_datos.DataSource = sql.Consulta(" select * from Contactos where Estado=1");
            operacionesDataGrid();
            InicializarCombobox();
        }



            
        private void btn_nuevo_Click_1(object sender, EventArgs e)
        {
            Limnpiado();
            btn_guardar.Text = "Guardar";
        }

        private void btn_guardar_Click_1(object sender, EventArgs e)
        {

            if (cmb_proveedor.SelectedIndex == -1 || cmb_depto.SelectedIndex == -1 || txt_nombre.Text == "" || txt_apellido.Text == "" || txt_telefono.Text == "" || txt_email.Text == "" ||
                txt_direccion.Text == "" || ValidarEmail(txt_email.Text) == false)
            {
                frm_notificacion noti = new frm_notificacion("Error, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                escoger_erp();
            }
            else
            {

                if (actualizar == true)
                {
                    con.IDContacto = int.Parse(txt_id.Text.ToString());
                    con.IDProveedor = int.Parse(cmb_proveedor.SelectedValue.ToString());
                    con.IDDepto = int.Parse(cmb_depto.SelectedValue.ToString());
                    con.Nombree = txt_nombre.Text;
                    con.Apellidoo = txt_apellido.Text;
                    con.Telefonoo = txt_telefono.Text;
                    con.CorreoElectronicoo = txt_email.Text;
                    con.Direccionn = txt_direccion.Text;
                    con.actualizarDatos();
                }
                else
                {
                    //con.IDContacto = int.Parse(txt_id.ToString());
                    con.IDProveedor = int.Parse(cmb_proveedor.SelectedValue.ToString());
                    con.IDDepto = int.Parse(cmb_depto.SelectedValue.ToString());
                    con.Nombree = txt_nombre.Text;
                    con.Apellidoo = txt_apellido.Text;
                    con.Telefonoo = txt_telefono.Text;
                    con.CorreoElectronicoo = txt_email.Text;
                    con.Direccionn = txt_direccion.Text;
                    con.Estadoo = Convert.ToBoolean(true);
                    con.guardar();
                }


                btn_guardar.Text = "Guardar";
                dgv_datos.DataSource = sql.Consulta("select * from Contactos where Estado=1");
                operacionesDataGrid();
                Limnpiado();
            }
        }

        private void escoger_erp()
        {
            if (cmb_proveedor.SelectedIndex == -1)
            {
                erp_porveedor.Clear();
                erp_porveedor.SetError(cmb_proveedor, "No puede quedar vacio");
            }

            if (cmb_depto.SelectedIndex == -1)
            {
                erp_depto.Clear();
                erp_depto.SetError(cmb_depto, "No puede quedar vacio");
            }

            if (txt_nombre.Text == "")
            {
                erp_nombre.Clear();
                erp_nombre.SetError(txt_nombre, "No puede quedar vacio");
            }

            if (txt_apellido.Text == "")
            {
                erp_apellido.Clear();
                erp_apellido.SetError(txt_apellido, "No puede quedar vacio");
            }

            if (txt_telefono.Text == "")
            {
                erp_telefono.Clear();
                erp_telefono.SetError(txt_telefono, "No puede quedar vacio");
            }

            if (txt_email.Text == "")
            {
                erp_email.Clear();
                erp_email.SetError(txt_email, "No puede quedar vacio");
            }
            else
            {
                if (ValidarEmail(txt_email.Text)==false)
                {
                    erp_email.Clear();
                    erp_email.SetError(txt_email, "solo emails validos: Example@dominio.algo");
                }
            }

            if (txt_direccion.Text == "")
            {
                erp_direccion.Clear();
                erp_direccion.SetError(txt_direccion, "No puede quedar vacio");
            }
        }

        public static bool ValidarEmail(string comprobarEmail)
        {
            string emailFormato;
            emailFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(comprobarEmail, emailFormato))
            {
                if (Regex.Replace(comprobarEmail, emailFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void btn_editar_Click_1(object sender, EventArgs e)
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
                cmb_depto.SelectedValue = dgv_datos.CurrentRow.Cells[2].Value.ToString();
                cmb_proveedor.SelectedValue = dgv_datos.CurrentRow.Cells[1].Value.ToString();
                txt_nombre.Text = dgv_datos.CurrentRow.Cells[3].Value.ToString();
                txt_apellido.Text = dgv_datos.CurrentRow.Cells[4].Value.ToString();
                txt_telefono.Text = dgv_datos.CurrentRow.Cells[5].Value.ToString();
                txt_email.Text = dgv_datos.CurrentRow.Cells[6].Value.ToString();
                txt_direccion.Text = dgv_datos.CurrentRow.Cells[7].Value.ToString();
                actualizar = true;
                btn_guardar.Text = "Actualizar";
            }
        }

        private void btn_eliminar_Click_1(object sender, EventArgs e)
        {
            if (dgv_datos.CurrentRow != null)
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea eliminar este contacto?", 2);
                noti.ShowDialog();

                if (noti.Dialogresul == DialogResult.OK)
                {
                    con.IDContacto = int.Parse(dgv_datos.CurrentRow.Cells[0].Value.ToString());
                    con.eliminarDatos();
                    dgv_datos.DataSource = sql.Consulta(" select*from Contactos where Estado=1");
                    operacionesDataGrid();
                }                    
            }
            else
            {
                frm_notificacion noti = new frm_notificacion("Debe selecionar algo antes de eliminar", 3);
                noti.ShowDialog();
                noti.Close();
            }
                
        }

        private void txt_buscar_TextChanged_1(object sender, EventArgs e)
        {
            con.Nombree = txt_buscar.Text;
            con.buscarDatos(dgv_datos);
            operacionesDataGrid();
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #region keypress

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void txt_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        //Limpiado de los Error Provider

        private void cmb_proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            erp_porveedor.Clear();
        }

        private void cmb_depto_SelectedIndexChanged(object sender, EventArgs e)
        {
            erp_depto.Clear();
        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {
            erp_nombre.Clear();
        }

        private void txt_apellido_TextChanged(object sender, EventArgs e)
        {
            erp_apellido.Clear();
        }

        private void txt_telefono_TextChanged(object sender, EventArgs e)
        {
            erp_telefono.Clear();
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            erp_email.Clear();
        }

        private void txt_direccion_TextChanged(object sender, EventArgs e)
        {
            erp_direccion.Clear();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {

        }


        #endregion

        private async void btn_imprimir_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                frm_notificacion noti = new frm_notificacion("", 4);
                noti.Show();

                Task tar1 = new Task(excelContactos);
                tar1.Start();
                await tar1;

                noti.Close();
            }
        }

        public void excelContactos()
        {

            System.Data.DataTable detalles = new System.Data.DataTable();
            int i = 0, j = 0;

            //Carga de los Productos

            detalles = sql.Consulta("Select '-' + Contactos.[ID Contacto] + '-'[Identidad],[Proveedores].Nombre[Proveedores], Departamentos.[Nombre Depto][Departamento], Contactos.Nombre + ' ' + Contactos.Apellido[Contacto], Contactos.Telefono, Contactos.[Correo Electronico], Contactos.Direccion from Contactos INNER JOIN Departamentos ON Contactos.[ID Depto] =" +
                "Departamentos.[ID Depto] inner join Proveedores ON Contactos.[ID Proveedor] = Proveedores.[ID Proveedor] WHERE Contactos.Estado = 1 ORDER BY Contacto ASC");

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
            objHoja.Cells[5, 3] = "ID Contacto";
            objHoja.Cells[5, 4] = "Proveedor";
            objHoja.Cells[5, 5] = "Departamento";
            objHoja.Cells[5, 6] = "Nombre";
            objHoja.Cells[5, 7] = "Telefono";
            objHoja.Cells[5, 8] = "Correo Electronico";
            objHoja.Cells[5, 9] = "Dirección";

            //Titulo
            objHoja.Cells[2, 3] = "Tecno PC";
            objHoja.Cells[2, 3].Font.Size = 18;
            objHoja.Cells[2, 3].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            objHoja.Cells[2, 3].Borders[objExcel.XlBordersIndex.xlEdgeBottom].LineStyle = objExcel.XlLineStyle.xlContinuous;
            objHoja.Cells[2, 3].Borders[objExcel.XlBordersIndex.xlEdgeBottom].Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);

            objHoja.Cells[3, 3] = "Reporte de Contactos";
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


        }


    }
}

    
