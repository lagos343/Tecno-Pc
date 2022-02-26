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

        {
            cmb_depto.SelectedIndex = -1;
            cmb_proveedor.SelectedIndex=-1;
            txt_id.Clear();
            txt_nombre.Clear();
            txt_apellido.Clear();
            txt_telefono.Clear();
            txt_email.Clear();
            txt_direccion.Clear();
            actualizar = false;
        }
        public void operacionesDataGrid()
        {
            dgv_datos.Columns[0].Visible = false;
            dgv_datos.Columns[1].Visible = false;
            dgv_datos.Columns[6].Visible = false;


        }

        public void InicializarCombobox()
        {
            cmb_depto.DataSource = sql.Consulta("select *from Departamentos order by [Nombre Depto] asc");
            cmb_depto.DisplayMember = "Nombre Depto";
            cmb_depto.ValueMember = "ID Depto";
            
            cmb_proveedor.DataSource = sql.Consulta("select * from Proveedores order by [Nombre] asc");
            cmb_proveedor.DisplayMember = "Nombre";
            cmb_proveedor.ValueMember = "ID Proveedor";

        }

        
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
                txt_direccion.Text == "")
            {
                frm_notificacion noti = new frm_notificacion("Llene todos los datos", 3);
                noti.ShowDialog();
                noti.Close();
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
                    con.Estadoo= Convert.ToBoolean(true);
                    con.guardar();
                }


                btn_guardar.Text = "Guardar";
                dgv_datos.DataSource = sql.Consulta("select * from Contactos where Estado=1");
                operacionesDataGrid();
                Limnpiado();
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
            con.IDContacto = int.Parse(dgv_datos.CurrentRow.Cells[0].Value.ToString());
            con.eliminarDatos();
            dgv_datos.DataSource = sql.Consulta(" select*from Contactos where Estado=1");
            operacionesDataGrid();
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

        #endregion

        //private void dgv_datos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //  }
    }

}
