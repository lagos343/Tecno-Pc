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

        bool actualizar=false;
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
                txt_Ident.Text= dgv_datos.CurrentRow.Cells[2].Value.ToString();
                txt_Nombre.Text= dgv_datos.CurrentRow.Cells[3].Value.ToString();
                txt_Apell.Text= dgv_datos.CurrentRow.Cells[4].Value.ToString();
                txt_Tel.Text= dgv_datos.CurrentRow.Cells[5].Value.ToString();
                txt_Email.Text= dgv_datos.CurrentRow.Cells[6].Value.ToString();
                txt_Direccion.Text= dgv_datos.CurrentRow.Cells[7].Value.ToString();
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
            SendMessage(this.Handle, 0x112, 0xf012, 0);    }
}
