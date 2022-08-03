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
    public partial class frm_MarcasCategorias : Form
    {
        //Importacion de libreias propias de windows para movimiento del formulario 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr h_wnd, int w_msg, int w_param, int l_param);

        //definicion de objetos de las clases necesarias
        bool editar_registro = false;
        Clases.Cl_Marcas mar_form = new Clases.Cl_Marcas();
        Clases.Cl_Categorias cate_form = new Clases.Cl_Categorias();
        Clases.Cl_NotificacionCompra  noti_form = new Clases.Cl_NotificacionCompra();
        Clases.Cl_Validacion vld_form = new Clases.Cl_Validacion();

        public frm_MarcasCategorias(int valor_marcas) //contructor
        {          
            InitializeComponent();            

            if (valor_marcas == 1) //este valor es el modo categorias
            {
                lbl_titulo.Text = "CATEGORIAS";
                btn_guardar.Click += btn_guardarCategorias;
                txt_buscar.TextChanged += txt_buscarCategorias_TextChanged;
                btn_editar.Click += btn_editarCategorias_Click;                            
                this.Text = "Categorias";
                cate_form.Consultar_Datos(dgv_datos);                
            }

            else if (valor_marcas == 2) //este valor es el modo marcas
            {
                lbl_titulo.Text = "MARCAS";
                btn_guardar.Click += btn_guardarMarcas;
                txt_buscar.TextChanged += txt_buscarMarcas_TextChanged;
                btn_editar.Click += btn_editarMarcas_Click;            
                this.Text = "Marcas";
                mar_form.Consultar_Datos(dgv_datos);                
            }
            else if (valor_marcas == 3) //este valor es el modo notificacion
            {
                txt_buscar.TextChanged += txt_buscarNotificacion_TextChanged;
                btn_nuevo.Click += btn_seleccionar_Click;
                btn_guardar.Click += btn_hecho_Click;
                Carga_Noti();                
            }
        }
        
        private void panel1_MouseDown(object sender_panel, MouseEventArgs index_e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //llamado de las librerias ddl para mover el form desde este panel
        }

        private void btn_salir_Click(object sender_salir, EventArgs index_e)
        {            
            this.Close();
        }

        public void Definicion_Array_Marcas() //define las propiedades     enviadas a la clase de Validaciones mediante Arrays con todos los Textbox y sus correspondientes expresiones regulares
        {
            vld_form.Text = new System.Windows.Forms.TextBox[1] {txt_nombre};
            vld_form.Error = new ErrorProvider[1] {erp_nombre};
            vld_form.Minimo = new int[1] {3};
            vld_form.Regular = new string[1] {"[A-Z, a-z, 0-9, ¡ * + % & $ # _]"};
            vld_form.Msj = new string[1] { @"Solo alfanumericos y especiales como: (¡ * + % & $ # _)" };
        }

        public void Definicion_Array_Categorias() //define las propiedades enviadas a la clase de Validaciones mediante Arrays con todos los Textbox y sus correspondientes expresiones regulares
        {
            vld_form.Text = new System.Windows.Forms.TextBox[1] { txt_nombre };
            vld_form.Error = new ErrorProvider[1] { erp_nombre };
            vld_form.Minimo = new int[1] { 3 };
            vld_form.Regular = new string[1] { "[A-Z, a-z, 0-9]" };
            vld_form.Msj = new string[1] { "Solo alfanumericos" };
        }

        #region Botones del form

        private void btn_nuevo_Click(object sender, EventArgs e) //limpia los datos
        {
            Limpiar_Datos();
            btn_guardar.Text = "GUARDAR";
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Limpiar_Datos()
        {
            txt_nombre.Clear();
            txt_id.Clear();
            txt_buscar.Clear();
            txt_buscar.Focus();
            editar_registro = false;
        }                
               
        #endregion

        #region Categorias Botones
        private void btn_guardarCategorias (object sender, EventArgs e) //se encarga de guardar
        {
            Definicion_Array_Categorias();

            if (vld_form.Comprobar_Txt() == false || vld_form.Validar_Letras(txt_nombre, erp_nombre) == false)
            {                
                frm_notificacion noti = new frm_notificacion("Operacion imcompleta por errores, ¡Corrija todos los errores!", 3);
                noti.ShowDialog();
                noti.Close();
                if (vld_form.Validar_Letras(txt_nombre, erp_nombre) == false);
            }
            else
            {
                if (editar_registro == true) //verificamos si estamos editando o guardando
                {
                    cate_form.Id_Categoria = int.Parse(txt_id.Text);
                    cate_form.Nombre_Categoria = txt_nombre.Text;
                    if (cate_form.Actualizar_Datos()) //verificamos que no devuelva error el comando sql
                    {
                        Limpiar_Datos();
                        btn_guardar.Text = "Guardar";
                        cate_form.Consultar_Datos(dgv_datos);
                    }
                }
                else
                {
                    cate_form.Nombre_Categoria = txt_nombre.Text;
                    if (cate_form.Guardar_Categoria()) //verificamos que no devuelva error el comando sql
                    {
                        Limpiar_Datos();
                        btn_guardar.Text = "Guardar";
                        cate_form.Consultar_Datos(dgv_datos);
                    }
                }                
            }           
        }

        private void txt_buscarCategorias_TextChanged(object sender, EventArgs e) //se encarga de buscar los registros filtrados
        {
            cate_form.Nombre_Categoria = txt_buscar.Text;
            cate_form.Buscar_Datos(dgv_datos);
        }

        private void btn_editarCategorias_Click(object sender, EventArgs e) //manda la informacion del registro seleccionado a los textbox para editarlo
        {
            if (dgv_datos.CurrentRow == null)
            {
                frm_notificacion noti = new frm_notificacion("Escoja algo antes para poder modificarlo", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                txt_id.Text = dgv_datos.CurrentRow.Cells[0].Value.ToString();                
                txt_nombre.Text = dgv_datos.CurrentRow.Cells[1].Value.ToString();
                editar_registro = true;
                btn_guardar.Text = "Actualizar";
            }
        }
                
        #endregion

        #region Marcas Botones
        private void btn_guardarMarcas(object sender, EventArgs e) //se encarga de guardar
        {
            Definicion_Array_Marcas();

            if (vld_form.Comprobar_Txt() == false || vld_form.Validar_Letras(txt_nombre, erp_nombre) == false)
            {
                frm_notificacion noti = new frm_notificacion("Operacion imcompleta por errores, ¡Corrija todos los errores!", 3);
                noti.ShowDialog();
                noti.Close();
                if (vld_form.Validar_Letras(txt_nombre, erp_nombre) == false) ;
            }
            else
            {
                if (editar_registro == true) //verificamos si estamos editando o guardando
                {

                    mar_form.Id_Marca = int.Parse(txt_id.Text);
                    mar_form.Nombre_Marca = txt_nombre.Text;
                    if (mar_form.Actualizar_Datos())  //verificamos que no devuelva error el comando sql
                    {
                        Limpiar_Datos();
                        btn_guardar.Text = "Guardar";
                        mar_form.Consultar_Datos(dgv_datos);
                    }
                }
                else
                {
                    mar_form.Nombre_Marca = txt_nombre.Text;
                    if (mar_form.Guardar())
                    {
                        Limpiar_Datos(); //verificamos que no devuelva error el comando sql
                        btn_guardar.Text = "Guardar";
                        mar_form.Consultar_Datos(dgv_datos);
                    }
                }                
            }
        }

        private void txt_buscarMarcas_TextChanged(object sender, EventArgs e) //se encarga de buscar los registros filtrados
        {
            mar_form.Nombre_Marca = txt_buscar.Text;
            mar_form.Buscar_Datos(dgv_datos);
        }

        private void btn_editarMarcas_Click(object sender, EventArgs e) //manda la informacion del registro seleccionado a los textbox para editarlo
        {
            if (dgv_datos.CurrentRow == null)
            {
                frm_notificacion noti = new frm_notificacion("Escoja algo antes para poder modificarlo", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                txt_id.Text = dgv_datos.CurrentRow.Cells[0].Value.ToString();
                txt_nombre.Text = dgv_datos.CurrentRow.Cells[1].Value.ToString();
                editar_registro = true;
                btn_guardar.Text = "Actualizar";
            }
        }

        #endregion

        #region Notificacion Compra

        private void btn_hecho_Click(object sender, EventArgs e) //se encarga de limpiar una notificacion ya realizada
        {
            if (editar_registro == true)
            {
                noti_form.Id_Noti = int.Parse(txt_id.Text);
                noti_form.Eliminar_Datos();
            }
            else if (editar_registro == false)
            {
                frm_notificacion noti = new frm_notificacion("Seleccioné algo antes", 3);
                noti.ShowDialog();
                noti.Close();
            }

        }

        private void txt_buscarNotificacion_TextChanged(object sender, EventArgs e) //se encarga de buscar los registros filtrados
        {
            noti_form.Producto_Compra = txt_buscar.Text;
            noti_form.Buscar_Datos(dgv_datos);
        }

        private void btn_seleccionar_Click(object sender, EventArgs e) //manda la informacion de la notificacion seleccionada a los textbox
        {
            if (dgv_datos.CurrentRow == null)
            {
                frm_notificacion noti = new frm_notificacion("Seleccion algo antes", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                btn_guardar.Text = "HECHO";
                txt_id.Text = dgv_datos.CurrentRow.Cells[0].Value.ToString();
                txt_nombre.Text = dgv_datos.CurrentRow.Cells[2].Value.ToString();
                editar_registro = true;
            }            
        }

        public void Carga_Noti() //muestra la info relacionada a las notificaciones y prepara el form para esta mecanicas
        {
            lbl_titulo.Text = "PRODUCTOS POR COMPRAR";
            btn_nuevo.Text = "Seleccionar";
            gunaLabel3.Text = "Descripcion";
            btn_guardar.Text = "HECHO";
            this.Text = "PRODUCTOS POR COMPRAR";
            btn_editar.Hide();            

            txt_nombre.Enabled = false;
            editar_registro = false;
            txt_nombre.Text = "";
            txt_id.Text = "";            

            noti_form.Consultar_Datos(dgv_datos);

            dgv_datos.Columns[0].Visible = false;
            dgv_datos.Columns[2].Visible = false;
            dgv_datos.Columns[4].Visible = false;
        }

        #endregion        

        private void txt_nombre_TextChanged(object sender_nombre, EventArgs index_e)
        {
            erp_nombre.Clear();
        }

        private void txt_nombre_KeyPress(object sender_nombre, KeyPressEventArgs index_e)
        {
            if (index_e.KeyChar == (char)Keys.Enter)
            {
                index_e.Handled = true;
                btn_guardar.PerformClick();                
            }
        }
    }
}
