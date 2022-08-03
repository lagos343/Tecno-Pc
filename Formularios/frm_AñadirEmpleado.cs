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
        //Importacion de librerias propias de windows para movimiento del formulario  
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //definicion de objetos de las clases necesarias
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Empleados empleados = new Clases.Cl_Empleados();
        Clases.Cl_Validacion vld = new Clases.Cl_Validacion();


        public frm_AñadirEmpleado(int estado_form, DataGridView datos_registro) //el contructor recibe dos parametros, el primeo indicara si lo abrimos en modo nuevo registro o en modo actualizacion
        {                                                       //el segundo recibe los datos del datagrid para llenar los campos en el modo actualizacion
            InitializeComponent();
            if (estado_form == 1)
            {
                lbl_titulo.Text = "NUEVO EMPLEADO";
                btn_guardar.Click += Guarda_Click; //definimos el proceso subrogado para que el boton relice el proceso de guardar
                Iniciar_Combobox();
            }
            else if (estado_form == 2)
            {
                Iniciar_Combobox();
                lbl_titulo.Text = "ACTUALIZAR EMPLEADO";
                btn_guardar.Text = "ACTUALZIAR";
                btn_guardar.Click += Actualiza_Click; //definimos el proceso subrogado para que el boton relice el proceso de actualizar

                //llenado de los datos en cada control para luego hacer las modificaciones
                txt_id .Text = datos_registro.CurrentRow.Cells[0 + 2].Value.ToString();
                cbo_puesto.SelectedValue  = datos_registro.CurrentRow.Cells[1 + 2].Value.ToString();
                cbo_depto .SelectedValue = datos_registro.CurrentRow.Cells[2 + 2].Value.ToString();
                txt_identidad .Text = datos_registro.CurrentRow.Cells[3 + 2].Value.ToString();
                txt_nombre .Text = datos_registro.CurrentRow.Cells[4 + 2].Value.ToString();
                txt_apellido .Text = datos_registro.CurrentRow.Cells[5 + 2].Value.ToString();
                txt_telefono .Text = datos_registro.CurrentRow.Cells[6 + 2].Value.ToString();
                txt_correo .Text = datos_registro.CurrentRow.Cells[7 + 2].Value.ToString();
                txt_direccion .Text = datos_registro.CurrentRow.Cells[8 + 2].Value.ToString();
                this.Text = "Actualizar Empleado";
            }
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        public void Iniciar_Combobox() //llena los combobox desde la DB e indica el valor desplegado y el valor de selecion
        {
            cbo_puesto.DataSource = sql.Consulta_Registro("select * from Puestos order by [nombre_puesto] asc");
            cbo_puesto.DisplayMember = "nombre_puesto";
            cbo_puesto.ValueMember = "id_puesto";
            cbo_puesto.SelectedIndex = -1;

            cbo_depto.DataSource = sql.Consulta_Registro("select * from Departamentos order by [nombre_depto] asc");
            cbo_depto.DisplayMember = "nombre_depto";
            cbo_depto.ValueMember = "id_depto";
            cbo_depto.SelectedIndex = -1;           
        }


        public void Definicion_Array() //define las propiedades enviadas a la clase de Validaciones mediante Arrays con todos los Textbox y sus correspondientes expresiones regulares 
        {
            vld.Text  =  new TextBox [6] {txt_nombre, txt_identidad, txt_apellido, txt_direccion, txt_correo, txt_telefono};
            vld.Error = new ErrorProvider[6] {erp_nom, erp_id, erp_ape, erp_dir, erp_email, erp_tel};
            vld.Minimo = new int[6] {2,13,2,3,10,8};
            vld.Regular = new string[6] {"[A-Z, a-z]" ,"(0[1-9]|1[0-8])(0[1-9]|1[0-9]|2[0-8])[0-9]{4}[0-9]{5}", "[A-Z, a-z]", "[A-Z, a-z, 0-9,.,#]",
                "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$", 
                "(2|3|8|9)[ -]*([0-9]*)" };
            vld.Msj = new string [6] {"Solo caracteres", "Solo digitos numericos, tomar\nen cuenta tambien el formato valido\n(depto + municipio) (año) (tomo+folio)",
                "Solo caracteres","Caracteres especiales no validos", "solo emails validos: example@dominio.algo", "Solo digitos numericos y que empiecen por 2,3,8 y 9"};
            
        }       

        public void Escoger_Erp() //muestra los errores que puedan ocurrir en los combobox
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

        private void Guarda_Click(object sender, EventArgs e) // proceso subrogado que usara el boton cuando requiramos guardar 
        {
            Definicion_Array();
            if (vld.Comprobar_Txt() == true && cbo_puesto.SelectedIndex != -1 && cbo_depto.SelectedIndex != -1 && vld.Validar_Letrascorreos(txt_correo, erp_email) == true 
                && vld.Buscar_Repetidos(txt_telefono, erp_tel) == true)
            { 
                empleados.Identidad_Empleado = txt_identidad.Text;
                empleados.Nombre_Empleado = txt_nombre.Text;
                empleados.Apellido_Empleado = txt_apellido.Text;
                empleados.Telefono_Empleado = txt_telefono.Text;
                empleados.Direccion_Empleado = txt_direccion.Text;
                empleados.Email_Empleado = txt_correo.Text;
                empleados.Id_Depto = int.Parse(cbo_depto.SelectedValue.ToString());
                empleados.Id_Puesto = int.Parse(cbo_puesto.SelectedValue.ToString());
                empleados.Estado_Empleado = Convert.ToBoolean(true);

                if (empleados.Guardar_Empleado()) //verificamos que no devuelva error el comando sql
                {
                    Limpiado_Empleados();
                }
                     
            }
            else  
            {                
                frm_notificacion noti = new frm_notificacion("Error al guardar, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                Escoger_Erp();
                if (vld.Validar_Letrascorreos(txt_correo, erp_email) == true) ;
                if (vld.Buscar_Repetidos(txt_telefono, erp_tel) == true) ;
            }

            Formularios.frm_empleados frm = Application.OpenForms.OfType<Formularios.frm_empleados>().SingleOrDefault();
            frm.Carga_Empleado(); //recargamos el formulario
        }

        private void Actualiza_Click(object sender, EventArgs e) // proceso subrogado que usara el boton cuando requiramos actualizar
        {
            Definicion_Array();
            if (vld.Comprobar_Txt() == true && cbo_puesto.SelectedIndex != -1 && cbo_depto.SelectedIndex != -1 && vld.Validar_Letrascorreos(txt_correo, erp_email) == true
                && vld.Buscar_Repetidos(txt_telefono, erp_tel) == true)
            {
                empleados.Id_Empleado = int.Parse(txt_id.Text);
                empleados.Identidad_Empleado = txt_identidad.Text;
                empleados.Nombre_Empleado = txt_nombre.Text;
                empleados.Apellido_Empleado = txt_apellido.Text;
                empleados.Telefono_Empleado = txt_telefono.Text;
                empleados.Direccion_Empleado = txt_direccion.Text;
                empleados.Email_Empleado = txt_correo.Text;
                empleados.Id_Depto = int.Parse(cbo_depto.SelectedValue.ToString());
                empleados.Id_Puesto = int.Parse(cbo_puesto.SelectedValue.ToString());

                if (empleados.Update_Empleado()) //verificamos que no devuelva error el comando sql
                {
                    Limpiado_Empleados();
                    this.Close();
                }                              
            }
            else 
            {
                frm_notificacion noti = new frm_notificacion("Error al actualizar, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                Escoger_Erp();
                if (vld.Validar_Letrascorreos(txt_correo, erp_email) == true) ;
                if (vld.Buscar_Repetidos(txt_telefono, erp_tel) == true) ;                
            }
            Formularios.frm_empleados frm = Application.OpenForms.OfType<Formularios.frm_empleados>().SingleOrDefault();
            frm.Carga_Empleado();//revcargamos el formulario
        }

        public void Limpiado_Empleados()
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
            SendMessage(this.Handle, 0x112, 0xf012, 0); //usamos las librerias ddl para mover el formulario desde este panel
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
