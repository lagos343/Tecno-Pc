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
        //Importacion de libreias propias de windows para movimiento del formulario  
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //definicion de objetos de las clases necesarias
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Validacion vld = new Clases.Cl_Validacion();
        Clases.Cl_Usuarios user = new Clases.Cl_Usuarios();

        public frm_AñadirUsuarios(int estado_form, DataGridView datos_registro) //el contructor recibe dos parametros, el primeo indicara si lo abrimos en modo nuevo registro o en modo actualizacion
        {                                                       //el segundo recibe los datos del datagrid para llenar los campos en el modo actualizacion
            InitializeComponent();
            if (estado_form == 1)
            {
                lbl_titulo.Text = "NUEVO USUARIO";
                btn_guardar.Text = "GUARDAR";
                btn_guardar.Click += Guarda_Click; //definimos el proceso subrogado para que el boton relice el proceso de guardar
                Inicializar_Combobox();
            }else if (estado_form == 2)
            {
                Inicializar_Combobox();
                lbl_titulo.Text = "ACTUALIZAR USUARIO";
                btn_guardar.Text = "ACTUALIZAR";
                btn_guardar.Click += Actualiza_Click; //definimos el proceso subrogado para que el boton relice el proceso de actualizar

                //llenado de los datos en cada control para luego hacer las modificaciones
                txt_id.Text = datos_registro.CurrentRow.Cells[0 + 2].Value.ToString();
                cboempleado.SelectedValue = datos_registro.CurrentRow.Cells[2 + 2].Value.ToString();
                cborol.SelectedValue = datos_registro.CurrentRow.Cells[1 + 2].Value.ToString();
                txt_usuario.Text = datos_registro.CurrentRow.Cells[3 + 2].Value.ToString();
                txt_pass.Text = datos_registro.CurrentRow.Cells[4 + 2].Value.ToString();
                this.Text = "Actualizar Usuario";
            }
        }

        public void Inicializar_Combobox() //llena los combobox desde la DB e indica el valor desplegado y el valor de selecion
        {
            cboempleado.DataSource = sql.Consulta_Registro("select * from Empleados where estado_empleado = 1 order by nombre_empleado asc");
            cboempleado.DisplayMember = "nombre_empleado";
            cboempleado.ValueMember = "id_empleado";
            cboempleado.SelectedIndex = -1;

            cborol.DataSource = sql.Consulta_Registro("select * from Roles order by [nombre_rol] asc");
            cborol.DisplayMember = "nombre_rol";
            cborol.ValueMember = "id_rol";
            cborol.SelectedIndex = -1;
        }

        public void Definicion_Array_User() //define las propiedades enviadas a la clase de Validaciones mediante Arrays con todos los Textbox y sus correspondientes expresiones regulares
        {
            vld.Text = new TextBox[2] { txt_usuario, txt_pass };
            vld.Error = new ErrorProvider[2] {erp_usuario, erp_contra};
            vld.Ctrl_user = new int[2] {1,2};            
        }
        
        private void Guarda_Click(object sender, EventArgs e) //proceso subrogado que usara el boton cuando requiramos guardar
        {
            Definicion_Array_User();
            if (vld.Validar_Usuario() == true && cborol.SelectedIndex != -1 && cboempleado.SelectedIndex != -1)
            {
                user.Nombre_usuario = txt_usuario.Text;
                user.Clave_Usuario = txt_pass.Text;
                user.Id_rol = int.Parse(cborol.SelectedValue.ToString());
                user.Id_empleado = int.Parse(cboempleado.SelectedValue.ToString());
                user.Estado_Usuario = Convert.ToBoolean(true);

                if (user.Guardar_Usuario()) //verificamos que no devuelva error el comando sql 
                {
                    Limpiar_Usuarios();
                }                
            }
            else
            {
                frm_notificacion noti = new frm_notificacion("Error al guardar, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                Escoger_Erp();     
            }

            Formularios.frm_Usuarios frm = Application.OpenForms.OfType<Formularios.frm_Usuarios>().SingleOrDefault();
            frm.Carga_Grid();
        }

        private void Escoger_Erp()  //muestra los errores que puedan ocurrir en los combobox
        {

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

        private void Actualiza_Click(object sender, EventArgs e) //proceso subrogado que usara el boton cuando requiramos actualizar
        {
            Definicion_Array_User();

            if (vld.Validar_Usuario() == true && cborol.SelectedIndex != -1 && cboempleado.SelectedIndex != -1)
            {
                user.Id_usuarios = int.Parse(txt_id.Text);
                user.Nombre_usuario = txt_usuario.Text;
                user.Clave_Usuario = txt_pass.Text;
                user.Id_rol = int.Parse(cborol.SelectedValue.ToString());
                user.Id_empleado = int.Parse(cboempleado.SelectedValue.ToString());
                user.Estado_Usuario = Convert.ToBoolean(true);

                if (user.Actualizar_Datos()) //verifimacmos que no devuelva error el comando sql
                {
                    this.Close();
                }                
            }
            else
            {
                frm_notificacion noti = new frm_notificacion("Error al actualizar, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                Escoger_Erp();                
            }

            Formularios.frm_Usuarios frm = Application.OpenForms.OfType<Formularios.frm_Usuarios>().SingleOrDefault();
            frm.Carga_Grid(); //recargar el form
        }

        public void Limpiar_Usuarios()
        {
            txt_usuario.Clear();
            txt_pass.Clear();
            cboempleado.SelectedIndex = -1;
            cborol.SelectedIndex = -1;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //llamado de las librerias ddl para mover el form desde este panel
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

        private void txt_usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void txt_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }

        #endregion

    }
}
