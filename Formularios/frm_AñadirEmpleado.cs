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
    public partial class frm_AñadirEmpleado : Form
    {

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Empleados empleados = new Clases.Cl_Empleados();


        public frm_AñadirEmpleado(int estado, DataGridView dat)
        {
            InitializeComponent();
            if (estado == 1)
            {
                lbl_titulo.Text = "NUEVO EMPLEADO";
                btn_guardar.Click += guarda_click;
                iniciarcombobox();
            }
            else if (estado == 2)
            {
                iniciarcombobox();
                lbl_titulo.Text = "ACTUALIZAR EMPLEADO";
                btn_guardar.Text = "ACTUALZIAR";
                btn_guardar.Click += actualiza_click;
                txt_id .Text = dat.CurrentRow.Cells[0 + 2].Value.ToString();
                cbo_puesto.SelectedValue  = dat.CurrentRow.Cells[1 + 2].Value.ToString();
                cbo_depto .SelectedValue = dat.CurrentRow.Cells[2 + 2].Value.ToString();
                txt_identidad .Text = dat.CurrentRow.Cells[3 + 2].Value.ToString();
                txt_nombre .Text = dat.CurrentRow.Cells[4 + 2].Value.ToString();
                txt_apellido .Text = dat.CurrentRow.Cells[5 + 2].Value.ToString();
                txt_telefono .Text = dat.CurrentRow.Cells[6 + 2].Value.ToString();
                txt_correo .Text = dat.CurrentRow.Cells[7 + 2].Value.ToString();
                txt_direccion .Text = dat.CurrentRow.Cells[8 + 2].Value.ToString();
            }

        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        public void iniciarcombobox()
        {

            cbo_puesto.DataSource = sql.Consulta("select * from Puestos order by [Nombre Puesto] asc");
            cbo_puesto.DisplayMember = "Nombre Puesto";
            cbo_puesto.ValueMember = "ID Puesto";

            cbo_depto.DataSource = sql.Consulta("select * from Departamentos order by [Nombre Depto] asc");
            cbo_depto.DisplayMember = "Nombre Depto";
            cbo_depto.ValueMember = "ID Depto";
            

        }

        private void guarda_click(object sender, EventArgs e)
        {

            if (txt_identidad.Text == "" || txt_nombre.Text == "" || txt_apellido.Text == "" || txt_telefono.Text == "" || txt_direccion.Text == "" 
                || txt_correo.Text == "" || cbo_puesto.SelectedIndex == -1 || cbo_depto.SelectedIndex == -1)
            {
                frm_notificacion noti = new frm_notificacion("Llene todos los datos", 3);
                noti.ShowDialog();
                noti.Close();

            }
            else 
            {
                empleados.Identidad = txt_identidad.Text;
                empleados.Nombre = txt_nombre.Text;
                empleados.Apellido = txt_apellido.Text;
                empleados.Telefono = txt_telefono.Text;
                empleados.Direccion = txt_direccion.Text;
                empleados.Email = txt_correo.Text;
                empleados.Iddepto = int.Parse(cbo_depto.SelectedValue.ToString());
                empleados.Idpuesto = int.Parse(cbo_puesto.SelectedValue.ToString());
                empleados.Estado = Convert.ToBoolean(true);
                empleados.guardar();
                limpiado();
            }

        }

        private void actualiza_click(object sender, EventArgs e) 
        {
            if (txt_identidad.Text == "" || txt_nombre.Text == "" || txt_apellido.Text == "" || txt_telefono.Text == "" || txt_direccion.Text == ""
                || txt_correo.Text == "" || cbo_puesto.SelectedIndex == -1 || cbo_depto.SelectedIndex == -1)
            {
                frm_notificacion noti = new frm_notificacion("Llene todos los datos", 3);
                noti.ShowDialog();
                noti.Close();

            }
            else 
            {
                empleados.Idempleado = int.Parse(txt_id.Text);
                empleados.Identidad = txt_identidad.Text;
                empleados.Nombre = txt_nombre.Text;
                empleados.Apellido = txt_apellido.Text;
                empleados.Telefono = txt_telefono.Text;
                empleados.Direccion = txt_direccion.Text;
                empleados.Email = txt_correo.Text;
                empleados.Iddepto = int.Parse(cbo_depto.SelectedValue.ToString());
                empleados.Idpuesto = int.Parse(cbo_puesto.SelectedValue.ToString());
                empleados.update();
                this.Close();
            }
        }


        public void limpiado() 
        {
            txt_identidad.Clear();
            txt_nombre.Clear();
            txt_apellido.Clear();
            txt_telefono.Clear();
            txt_direccion.Clear();
            txt_correo.Clear();
            cbo_depto.SelectedIndex = -1;
            cbo_puesto.SelectedIndex = -1;
        
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
