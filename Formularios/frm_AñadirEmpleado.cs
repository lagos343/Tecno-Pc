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
        Clases.Cl_Validacion vld = new Clases.Cl_Validacion();


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


        public void definicionarray()
        {
            vld.Text  =  new TextBox [6] {txt_nombre, txt_identidad, txt_apellido, txt_direccion, txt_correo, txt_telefono};
            vld.Error = new ErrorProvider[6] {erp_nom, erp_id, erp_ape, erp_dir, erp_email, erp_tel};
            vld.Minimo = new int[6] {2,13,2,5,10,8};
            vld.Regular = new string[6] {"[A-Z, a-z]" ,"[0-9]", "[A-Z, a-z]", "[A-Z, a-z, 0-9]", "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", "(2|3|8|9)[ -]*([0-9]*)" };
            vld.Msj = new string [6] {"Solo caracteres", "Solo digitos numericos","Solo caracteres","Caracteres especiales no validos", "solo emails validos: Example@dominio.algo", "Solo digitos numericos y que empiecen por 2,3,8 y 9"};
            
        }

        public void escoger_rp()
        {
            if(cbo_depto.SelectedIndex == -1)
            {
                erp_depto.Clear();
                erp_depto.SetError(cbo_depto, "Seleccione algo valido");
            }
            if (cbo_puesto.SelectedIndex == -1)
            {
                erp_puesto.Clear();
                erp_puesto.SetError(cbo_puesto, "Seleccione algo valido");
            }
        }

        private void guarda_click(object sender, EventArgs e)
        {
            definicionarray();
            if (vld.comprobartxt() == true && cbo_puesto.SelectedIndex != -1 && cbo_depto.SelectedIndex != -1)
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
            else  
            {                
                frm_notificacion noti = new frm_notificacion("Error al guardar, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                escoger_rp();
            }

            Formularios.frm_empleados frm = Application.OpenForms.OfType<Formularios.frm_empleados>().SingleOrDefault();
            frm.carga();
        }

        private void actualiza_click(object sender, EventArgs e) 
        {
            definicionarray();
            if (vld.comprobartxt() == true && cbo_puesto.SelectedIndex != -1 && cbo_depto.SelectedIndex != -1)
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
            else 
            {
                frm_notificacion noti = new frm_notificacion("Error al actualizar, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                escoger_rp();
            }
            Formularios.frm_empleados frm = Application.OpenForms.OfType<Formularios.frm_empleados>().SingleOrDefault();
            frm.carga();
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
     
    }
}
