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
using System.Text.RegularExpressions;

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
            cbo_puesto.SelectedIndex = -1;

            cbo_depto.DataSource = sql.Consulta("select * from Departamentos order by [Nombre Depto] asc");
            cbo_depto.DisplayMember = "Nombre Depto";
            cbo_depto.ValueMember = "ID Depto";
            cbo_depto.SelectedIndex = -1;
            

        }

        private void guarda_click(object sender, EventArgs e)
        {

            if (txt_identidad.Text == "" || txt_nombre.Text == "" || txt_apellido.Text == "" || txt_telefono.Text == "" || txt_direccion.Text == "" 
                || txt_correo.Text == "" || cbo_puesto.SelectedIndex == -1 || cbo_depto.SelectedIndex == -1 || ValidarEmail(txt_correo.Text) == false)
            {
                frm_notificacion noti = new frm_notificacion("Error al guardar, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                escoger_erp();
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

            Formularios.frm_empleados frm = Application.OpenForms.OfType<Formularios.frm_empleados>().SingleOrDefault();
            frm.carga();

        }

        private void actualiza_click(object sender, EventArgs e) 
        {
            if (txt_identidad.Text == "" || txt_nombre.Text == "" || txt_apellido.Text == "" || txt_telefono.Text == "" || txt_direccion.Text == ""
                || txt_correo.Text == "" || cbo_puesto.SelectedIndex == -1 || cbo_depto.SelectedIndex == -1 || ValidarEmail(txt_correo.Text) == false)
            {
                frm_notificacion noti = new frm_notificacion("Error al actualizar, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                escoger_erp();
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
            Formularios.frm_empleados frm = Application.OpenForms.OfType<Formularios.frm_empleados>().SingleOrDefault();
            frm.carga();
        }

        private void escoger_erp()
        {
            if (txt_identidad.Text == "")
            {
                erp_id.Clear();
                erp_id.SetError(txt_identidad, "No puede quedar vacio");
            }

            if (txt_nombre.Text == "")
            {
                erp_nom.Clear();
                erp_nom.SetError(txt_nombre, "No puede quedar vacio");
            }

            if (txt_apellido.Text == "")
            {
                erp_ape.Clear();
                erp_ape.SetError(txt_apellido, "No puede quedar vacio");
            }

            if (txt_telefono.Text == "")
            {
                erp_tel.Clear();
                erp_tel.SetError(txt_telefono, "No puede quedar vacio");
            }

            if (txt_direccion.Text == "")
            {
                erp_dir.Clear();
                erp_dir.SetError(txt_direccion, "No puede quedar vacio");
            }

            if (cbo_puesto.SelectedIndex == -1)
            {
                erp_puesto.Clear();
                erp_puesto.SetError(cbo_puesto, "No puede quedar vacio");
            }

            if (cbo_depto.SelectedIndex == -1)
            {
                erp_depto.Clear();
                erp_depto.SetError(cbo_depto, "No puede quedar vacio");
            }            

            if (txt_correo.Text == "")
            {
                erp_email.Clear();
                erp_email.SetError(txt_correo, "No puede quedar vacio");
            }
            else
            {
                if (ValidarEmail(txt_correo.Text) == false)
                {
                    erp_email.Clear();
                    erp_email.SetError(txt_correo, "solo emails validos: Example@dominio.algo");
                }
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Ignorar
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #region Keypress

        private void txt_identidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

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

        private void txt_identidad_TextChanged(object sender, EventArgs e)
        {
            erp_id.Clear();
        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {
            erp_nom.Clear();
        }

        private void txt_apellido_TextChanged(object sender, EventArgs e)
        {
            erp_ape.Clear();
        }

        private void cbo_puesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            erp_puesto.Clear();
        }

        private void cbo_depto_SelectedIndexChanged(object sender, EventArgs e)
        {
            erp_depto.Clear();
        }

        private void txt_telefono_TextChanged(object sender, EventArgs e)
        {
            erp_tel.Clear();
        }

        private void txt_correo_TextChanged(object sender, EventArgs e)
        {
            erp_email.Clear();
        }

        private void txt_direccion_TextChanged(object sender, EventArgs e)
        {
            erp_dir.Clear();
        }

        #endregion

        private void btn_guardar_Click(object sender, EventArgs e)
        {

        }        
    }
}
