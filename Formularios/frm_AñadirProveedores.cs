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
                lbl_titulo.Text = "NUEVO PROVEEDOR";
                btn_guardar.Text = "GUARDAR";
                btn_guardar.Click += guarda_click;
                iniciarcombobox();
            }
            else if (estado == 2)
            {
                iniciarcombobox();
                lbl_titulo.Text = "ACTUALIZAR PROVEEDOR";
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
            cbo_depto.SelectedIndex = -1;
        }


        private void guarda_click(object sender, EventArgs e)
        {

            if (txt_nombre.Text == "" || txt_telefono.Text == "" || txt_email.Text == "" || txt_direccion.Text == "" || cbo_depto.SelectedIndex == -1 || ValidarEmail(txt_email.Text) == false)
            {
                frm_notificacion noti = new frm_notificacion("Error al guardar, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                escoger_erp();
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

            Formularios.frm_proveedores frm = Application.OpenForms.OfType<Formularios.frm_proveedores>().SingleOrDefault();
            frm.carga();
        }

        private void actualiza_click(object sender, EventArgs e)
        {

            if (txt_nombre.Text == "" || txt_telefono.Text == "" || txt_email.Text == "" || txt_direccion.Text == "" || cbo_depto.SelectedIndex == -1 || ValidarEmail(txt_email.Text) == false)
            {
                frm_notificacion noti = new frm_notificacion("Error al actualizar, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                escoger_erp();
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
            Formularios.frm_proveedores frm = Application.OpenForms.OfType<Formularios.frm_proveedores>().SingleOrDefault();
            frm.carga();
        }

        private void escoger_erp()  
        {
            if(txt_nombre.Text == "")
            {
                erp_nombre.Clear();
                erp_nombre.SetError(txt_nombre, "No puede quedar vacio");
            }

            if (txt_telefono.Text == "")
            {
                erp_telefono.Clear();
                erp_telefono.SetError(txt_telefono, "No puede quedar vacio");
            }

            if (txt_email.Text == "")
            {
                erp_correo.Clear();
                erp_correo.SetError(txt_email, "No puede quedar vacio");
            }
            else
            {
                if (ValidarEmail(txt_email.Text) == false)
                {
                    erp_correo.Clear();
                    erp_correo.SetError(txt_email, "solo emails validos: Example@dominio.algo");
                }
            }

            if (txt_direccion.Text == "")
            {
                erp_direccion.Clear();
                erp_direccion.SetError(txt_direccion, "No puede quedar vacio");
            }

            if (cbo_depto.SelectedIndex == -1)
            {
                erp_departamento.Clear();
                erp_departamento.SetError(cbo_depto, "No puede quedar vacio");
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
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

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {
            erp_nombre.Clear();
        }

        private void txt_telefono_TextChanged(object sender, EventArgs e)
        {
            erp_telefono.Clear();
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            erp_correo.Clear();
        }

        private void txt_direccion_TextChanged(object sender, EventArgs e)
        {
            erp_direccion.Clear();
        }

        private void cbo_depto_SelectedIndexChanged(object sender, EventArgs e)
        {
            erp_departamento.Clear();
        }

        #endregion

        private void btn_guardar_Click(object sender, EventArgs e)
        {

        }                
    }
}
