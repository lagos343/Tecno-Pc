using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Formularios
{
    public partial class frm_AñadirUsuarios : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Usuarios user = new Clases.Cl_Usuarios();
        public frm_AñadirUsuarios(int estado, DataGridView dat)
        {
            InitializeComponent();
            if (estado == 1)
            {
                lbl_titulo.Text = "NUEVO USUARIO";
                btn_guardar.Text = "GUARDAR";
                btn_guardar.Click += guarda_click;
                iniciar1();
            }else if (estado == 2)
            {
                iniciar1();
                lbl_titulo.Text = "ACTUALIZAR USUARIO";
                btn_guardar.Text = "ACTUALIZAR";
                btn_guardar.Click += actualiza_click;
                txt_id.Text = dat.CurrentRow.Cells[0 + 2].Value.ToString();
                cboempleado.SelectedValue = dat.CurrentRow.Cells[2 + 2].Value.ToString();
                cborol.SelectedValue = dat.CurrentRow.Cells[1 + 2].Value.ToString();
                txt_usuario.Text = dat.CurrentRow.Cells[3 + 2].Value.ToString();
                txt_pass.Text = dat.CurrentRow.Cells[4 + 2].Value.ToString();
            }
        }
        public void iniciar1()
        {
            cboempleado.DataSource = sql.Consulta("select * from Empleados where Estado = 1 order by Nombre asc");
            cboempleado.DisplayMember = "Nombre";
            cboempleado.ValueMember = "ID Empleado";
            cboempleado.SelectedIndex = -1;

            cborol.DataSource = sql.Consulta("select * from Roles order by [Nombre Rol] asc");
            cborol.DisplayMember = "Nombre Rol";
            cborol.ValueMember = "IDRol";
            cborol.SelectedIndex = -1;
        }

        private void guarda_click(object sender, EventArgs e)
        {
            if(txt_usuario.Text == "" || txt_pass.Text == "" || cborol.SelectedIndex == -1 || cboempleado.SelectedIndex == -1)
            {
                frm_notificacion noti = new frm_notificacion("Llene todos los datos", 3);
                noti.ShowDialog();
                noti.Close();
                escoger_erp();
            }
            else
            {
                user.Nombre_usuario = txt_usuario.Text;
                user.Clave = txt_pass.Text;
                user.Id_rol = int.Parse(cborol.SelectedValue.ToString());
                user.Id_empleado = int.Parse(cboempleado.SelectedValue.ToString());
                user.Estado = Convert.ToBoolean(true);
                user.guardar();
                limpiar();
            }

            Formularios.frm_Usuarios frm = Application.OpenForms.OfType<Formularios.frm_Usuarios>().SingleOrDefault();
            frm.carga();
        }

        private void escoger_erp() 
        {
            if (txt_pass.Text == "")
            {
                erp_contra.Clear();
                erp_contra.SetError(txt_pass, "No puede quedar vacio");
            }   

            if (txt_usuario.Text == "")
            {
                erp_usuario.Clear();
                erp_usuario.SetError(txt_usuario, "No puede quedar vacio");
            }

            if (cboempleado.SelectedIndex == -1)
            {
                erp_empleado.Clear();
                erp_empleado.SetError(cboempleado, "No puede quedar vacio");
            }

            if (cborol.SelectedIndex == -1)
            {
                erp_rol.Clear();
                erp_rol.SetError(cborol, "No puede quedar vacio");
            }
        }

        private void actualiza_click(object sender, EventArgs e)
        {
            if (txt_usuario.Text == "" || txt_pass.Text == "" || cborol.SelectedIndex == -1 || cboempleado.SelectedIndex == -1)
            {
                frm_notificacion noti = new frm_notificacion("Llene todos los datos", 3);
                noti.ShowDialog();
                noti.Close();
                escoger_erp();
            }
            else
            {
                user.Id_usuarios = int.Parse(txt_id.Text);
                user.Nombre_usuario = txt_usuario.Text;
                user.Clave = txt_pass.Text;
                user.Id_rol = int.Parse(cborol.SelectedValue.ToString());
                user.Id_empleado = int.Parse(cboempleado.SelectedValue.ToString());
                user.Estado = Convert.ToBoolean(true);
                user.actualizarDatos();
                this.Close();
            }
            Formularios.frm_Usuarios frm = Application.OpenForms.OfType<Formularios.frm_Usuarios>().SingleOrDefault();
            frm.carga();

        }

        public void limpiar()
        {
            txt_usuario.Clear();
            txt_pass.Clear();
            cboempleado.SelectedIndex = -1;
            cborol.SelectedIndex = -1;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        #region keypress

        private void txt_usuario_TextChanged(object sender, EventArgs e)
        {
            erp_usuario.Clear();
        }

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {
            erp_contra.Clear();
        }

        private void cboempleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            erp_empleado.Clear();
        }

        private void cborol_SelectedIndexChanged(object sender, EventArgs e)
        {
            erp_rol.Clear();
        }

        #endregion
    }
}
