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
    public partial class frm_AñadirProveedores : Form
    {

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Proveedores proveedores = new Clases.Cl_Proveedores();

        public frm_AñadirProveedores(int estado, DataGridView dat)
        {
            InitializeComponent();
            if (estado == 1)
            {
                lbl_titulo.Text = "NUEVO EMPLEADO";
                btn_guardar.Text = "GUARDAR";
                btn_guardar.Click += guarda_click;
                iniciarcombobox();
            }
            else if (estado == 2)
            {
                iniciarcombobox();
                lbl_titulo.Text = "ACTUALIZAR EMPLEADO";
                btn_guardar.Text = "ACTUALIZAR";
                btn_guardar.Click += actualiza_click;
                txt_id.Text = dat.CurrentRow.Cells[0 + 2].Value.ToString();
                cbo_depto.SelectedValue = dat.CurrentRow.Cells[1 + 2].Value.ToString();
                txt_nombre.Text = dat.CurrentRow.Cells[2 + 2].Value.ToString();
                txt_telefono.Text = dat.CurrentRow.Cells[3 + 2].Value.ToString();
                txt_direccion.Text = dat.CurrentRow.Cells[4 + 2].Value.ToString();
                txt_email.Text = dat.CurrentRow.Cells[5 + 2].Value.ToString();


            }

        }


        public void iniciarcombobox()
        {
            cbo_depto.DataSource = sql.Consulta("select * from Departamentos order by [Nombre Depto] asc");
            cbo_depto.DisplayMember = "Nombre Depto";
            cbo_depto.ValueMember = "ID Depto";

        }


        private void guarda_click(object sender, EventArgs e)
        {

            if (txt_nombre.Text == "" || txt_telefono.Text == "" || txt_email.Text == "" || txt_direccion.Text == "" || cbo_depto.SelectedIndex == -1)
            {
                frm_notificacion noti = new frm_notificacion("Llene todos los datos", 3);
                noti.ShowDialog();
                noti.Close();

            }
            else
            {
                proveedores.Nombre = txt_nombre.Text;
                proveedores.Telefono = txt_telefono.Text;
                proveedores.CorreoElectronico = txt_email.Text;
                proveedores.Direccion = txt_direccion.Text;
                proveedores.IDDepto = int.Parse(cbo_depto.SelectedValue.ToString());
                proveedores.Estado = Convert.ToBoolean(true);
                proveedores.guardar();
                limpiado();

            }

        }

        private void actualiza_click(object sender, EventArgs e)
        {

            if (txt_nombre.Text == "" || txt_telefono.Text == "" || txt_email.Text == "" || txt_direccion.Text == "" || cbo_depto.SelectedIndex == -1)
            {
                frm_notificacion noti = new frm_notificacion("Llene todos los datos", 3);
                noti.ShowDialog();
                noti.Close();

            }
            else
            {
                proveedores.IDProveedor = int.Parse(txt_id.Text);
                proveedores.Nombre = txt_nombre.Text;
                proveedores.Telefono = txt_telefono.Text;
                proveedores.CorreoElectronico = txt_email.Text;
                proveedores.Direccion = txt_direccion.Text;
                proveedores.IDDepto = int.Parse(cbo_depto.SelectedValue.ToString());
                proveedores.actualizarDatos();
                this.Close();

            }

        }

        public void limpiado()
        {
            txt_nombre.Clear();
            txt_telefono.Clear();
            txt_email.Clear();
            txt_direccion.Clear();
            cbo_depto.SelectedIndex = -1;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
