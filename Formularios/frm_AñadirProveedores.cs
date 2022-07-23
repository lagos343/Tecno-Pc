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
        //Importacion de libreias propias de windows para movimiento del formulario  
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //definicion de objetos de las clases necesarias
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Proveedores proveedores = new Clases.Cl_Proveedores();
        Clases.Cl_Validacion vld = new Clases.Cl_Validacion();

        public frm_AñadirProveedores(int estado_form, DataGridView datos_registro)//el contructor recibe dos parametros, el primeo indicara si lo abrimos en modo nuevo registro o en modo actualizacion
        {                                                         //el segundo recibe los datos del datagrid para llenar los campos en el modo actualizacion
            InitializeComponent();
            if (estado_form == 1)
            {
                lbl_titulo.Text = "NUEVO PROVEEDOR";
                btn_guardar.Text = "GUARDAR";
                btn_guardar.Click += Guarda_Click; //definimos el proceso subrogado para que el boton relice el proceso de guardar
                Iniciar_Combobox();
            }
            else if (estado_form == 2)
            {
                Iniciar_Combobox();
                lbl_titulo.Text = "ACTUALIZAR PROVEEDOR";
                btn_guardar.Text = "ACTUALIZAR";
                btn_guardar.Click += Actualiza_Click; //definimos el proceso subrogado para que el boton relice el proceso de actualizar

                //llenado de los datos en cada control para luego hacer las modificaciones
                txt_id.Text = datos_registro.CurrentRow.Cells[0 + 2].Value.ToString();
                cbo_depto.SelectedValue = datos_registro.CurrentRow.Cells[1 + 2].Value.ToString();
                txt_nombre.Text = datos_registro.CurrentRow.Cells[2 + 2].Value.ToString();
                txt_telefono.Text = datos_registro.CurrentRow.Cells[3 + 2].Value.ToString();
                txt_direccion.Text = datos_registro.CurrentRow.Cells[4 + 2].Value.ToString();
                txt_email.Text = datos_registro.CurrentRow.Cells[5 + 2].Value.ToString();
                this.Text = "Actualizar Proveedores";
            }
        }


        public void Iniciar_Combobox() //llena los combobox desde la DB e indica el valor desplegado y el valor de selecion
        {
            cbo_depto.DataSource = sql.Consulta("select * from Departamentos order by [nombre_depto] asc");
            cbo_depto.DisplayMember = "nombre_depto";
            cbo_depto.ValueMember = "id_depto";
            cbo_depto.SelectedIndex = -1;
        }

        public void Definicion_Array() //define las propiedades enviadas a la clase de Validaciones mediante Arrays con todos los Textbox y sus correspondientes expresiones regulares
        {
            vld.Text = new TextBox[4] {txt_nombre, txt_telefono, txt_email, txt_direccion};
            vld.Error = new ErrorProvider[4] {erp_nombre, erp_telefono, erp_correo, erp_direccion };
            vld.Minimo = new int[4] {2,8,10,3};
            vld.Regular = new string[4] {"[A-Z, a-z]", "(2|3|8|9)[ -]*([0-9]*)",
                "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$", 
                "[A-Z, a-z, 0-9, ., #]" };
            vld.Msj = new string[4] { "Solo caracteres" , "Solo digitos numericos y que empiecen por 2,3,8 y 9", "solo emails validos: example@dominio.algo" , "Caracteres especiales no validos" };

        }


        private void Guarda_Click(object sender, EventArgs e) // proceso subrogado que usara el boton cuando requiramos guardar
        {
            Definicion_Array();

            if (vld.comprobartxt() == true && cbo_depto.SelectedIndex != -1 && vld.ValidarLetrasCorreos(txt_email, erp_correo) == true && vld.buscarRepetidos(txt_telefono, erp_telefono) == true)
            {
                proveedores.Nombre = txt_nombre.Text;
                proveedores.Telefono = txt_telefono.Text;
                proveedores.CorreoElectronico = txt_email.Text;
                proveedores.Direccion = txt_direccion.Text;
                proveedores.IDDepto = int.Parse(cbo_depto.SelectedValue.ToString());
                proveedores.Estado = Convert.ToBoolean(true);

                if (proveedores.guardar()) //verificamos que no devuelva error el comando sql
                {
                    Limpiado_Proveedores();
                }
            }
            else
            {
                frm_notificacion noti = new frm_notificacion("Error al guardar, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                Escoger_Erp();
                if(vld.ValidarLetrasCorreos(txt_email, erp_correo) == true) ;
                if (vld.buscarRepetidos(txt_telefono, erp_telefono) == true) ;
            }

            Formularios.frm_proveedores frm = Application.OpenForms.OfType<Formularios.frm_proveedores>().SingleOrDefault();
            frm.carga();
        }

        private void Actualiza_Click(object sender, EventArgs e) // proceso subrogado que usara el boton cuando requiramos actualizar
        {
            Definicion_Array();

            if (vld.comprobartxt() == true && cbo_depto.SelectedIndex != -1 && vld.ValidarLetrasCorreos(txt_email, erp_correo) == true && vld.buscarRepetidos(txt_telefono, erp_telefono) == true)
            {
                proveedores.IDProveedor = int.Parse(txt_id.Text);
                proveedores.Nombre = txt_nombre.Text;
                proveedores.Telefono = txt_telefono.Text;
                proveedores.CorreoElectronico = txt_email.Text;
                proveedores.Direccion = txt_direccion.Text;
                proveedores.IDDepto = int.Parse(cbo_depto.SelectedValue.ToString());

                if (proveedores.actualizarDatos()) //verifimacmos que no devuelva error el comando sql
                {
                    Limpiado_Proveedores();
                    this.Close();
                }
                
            }
            else
            {
                frm_notificacion noti = new frm_notificacion("Error al actualizar, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                Escoger_Erp();
                if (vld.ValidarLetrasCorreos(txt_email, erp_correo) == true) ;
                if (vld.buscarRepetidos(txt_telefono, erp_telefono) == true) ;

            }
            Formularios.frm_proveedores frm = Application.OpenForms.OfType<Formularios.frm_proveedores>().SingleOrDefault();
            frm.carga(); //recargar el form
        }

        private void Escoger_Erp() //muestra los errores que puedan ocurrir en los combobox
        {
            if (cbo_depto.SelectedIndex == -1)
            {
                erp_departamento.Clear();
                erp_departamento.SetError(cbo_depto, "No puede quedar vacio");
            }
        }


        public void Limpiado_Proveedores()
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
            SendMessage(this.Handle, 0x112, 0xf012, 0); //llamado de las librerias ddl para mover el form desde este panel
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
