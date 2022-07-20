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
        Clases.Cl_Validacion vld = new Clases.Cl_Validacion();

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
                this.Text = "Actualizar Proveedores";
            }
        }


        public void iniciarcombobox()
        {
            cbo_depto.DataSource = sql.Consulta("select * from Departamentos order by [nombre_depto] asc");
            cbo_depto.DisplayMember = "nombre_depto";
            cbo_depto.ValueMember = "id_depto";
            cbo_depto.SelectedIndex = -1;
        }

        public void definicionarrayPro()
        {
            vld.Text = new TextBox[4] {txt_nombre, txt_telefono, txt_email, txt_direccion};
            vld.Error = new ErrorProvider[4] {erp_nombre, erp_telefono, erp_correo, erp_direccion };
            vld.Minimo = new int[4] {2,8,10,3};
            vld.Regular = new string[4] {"[A-Z, a-z]", "(2|3|8|9)[ -]*([0-9]*)",
                "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$", 
                "[A-Z, a-z, 0-9, ., #]" };
            vld.Msj = new string[4] { "Solo caracteres" , "Solo digitos numericos y que empiecen por 2,3,8 y 9", "solo emails validos: example@dominio.algo" , "Caracteres especiales no validos" };

        }


        private void guarda_click(object sender, EventArgs e)
        {
            definicionarrayPro();

            if (vld.comprobartxt() == true && cbo_depto.SelectedIndex != -1 && vld.ValidarLetrasCorreos(txt_email, erp_correo) == true && vld.buscarRepetidos(txt_telefono, erp_telefono) == true)
            {
                proveedores.Nombre = txt_nombre.Text;
                proveedores.Telefono = txt_telefono.Text;
                proveedores.CorreoElectronico = txt_email.Text;
                proveedores.Direccion = txt_direccion.Text;
                proveedores.IDDepto = int.Parse(cbo_depto.SelectedValue.ToString());
                proveedores.Estado = Convert.ToBoolean(true);

                if (proveedores.guardar())
                {
                    limpiado();
                }
            }
            else
            {
                frm_notificacion noti = new frm_notificacion("Error al guardar, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                escoger_erp();
                if(vld.ValidarLetrasCorreos(txt_email, erp_correo) == true) ;
                if (vld.buscarRepetidos(txt_telefono, erp_telefono) == true) ;
            }

            Formularios.frm_proveedores frm = Application.OpenForms.OfType<Formularios.frm_proveedores>().SingleOrDefault();
            frm.carga();
        }

        private void actualiza_click(object sender, EventArgs e)
        {
            definicionarrayPro();

            if (vld.comprobartxt() == true && cbo_depto.SelectedIndex != -1 && vld.ValidarLetrasCorreos(txt_email, erp_correo) == true && vld.buscarRepetidos(txt_telefono, erp_telefono) == true)
            {
                proveedores.IDProveedor = int.Parse(txt_id.Text);
                proveedores.Nombre = txt_nombre.Text;
                proveedores.Telefono = txt_telefono.Text;
                proveedores.CorreoElectronico = txt_email.Text;
                proveedores.Direccion = txt_direccion.Text;
                proveedores.IDDepto = int.Parse(cbo_depto.SelectedValue.ToString());

                if (proveedores.actualizarDatos())
                {
                    limpiado();
                    this.Close();
                }
                
            }
            else
            {
                frm_notificacion noti = new frm_notificacion("Error al actualizar, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                escoger_erp();
                if (vld.ValidarLetrasCorreos(txt_email, erp_correo) == true) ;
                if (vld.buscarRepetidos(txt_telefono, erp_telefono) == true) ;

            }
            Formularios.frm_proveedores frm = Application.OpenForms.OfType<Formularios.frm_proveedores>().SingleOrDefault();
            frm.carga();
        }

        private void escoger_erp()  
        {
            if (cbo_depto.SelectedIndex == -1)
            {
                erp_departamento.Clear();
                erp_departamento.SetError(cbo_depto, "No puede quedar vacio");
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

        private void txt_direccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btn_guardar.PerformClick();
            }
        }

        #endregion

    }
}
