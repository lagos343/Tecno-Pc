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
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr h_wnd, int w_msg, int w_param, int l_param);
                        
        bool editar = false;
        Clases.Cl_Marcas mar_form = new Clases.Cl_Marcas();
        Clases.Cl_Categorias cate_form = new Clases.Cl_Categorias();
        Clases.Cl_NotificacionCompra  noti_form = new Clases.Cl_NotificacionCompra();
        Clases.Cl_Validacion vld_form = new Clases.Cl_Validacion();

        public frm_MarcasCategorias(int valor_marcas)
        {          
            InitializeComponent();            

            if (valor_marcas == 1)
            {
                lbl_titulo.Text = "CATEGORIAS";
                btn_guardar.Click += btn_guardarCategorias;
                txt_buscar.TextChanged += txt_buscarCategorias_TextChanged;
                btn_editar.Click += btn_editarCategorias_Click;                            
                this.Text = "Categorias";
                cate_form.consultarDatos(dgv_datos);                
            }
            else if (valor_marcas == 2)
            {
                lbl_titulo.Text = "MARCAS";
                btn_guardar.Click += btn_guardarMarcas;
                txt_buscar.TextChanged += txt_buscarMarcas_TextChanged;
                btn_editar.Click += btn_editarMarcas_Click;            
                this.Text = "Marcas";
                mar_form.consultarDatos(dgv_datos);                
            }
            else if (valor_marcas == 3)
            {
                txt_buscar.TextChanged += txt_buscarNotificacion_TextChanged;
                btn_nuevo.Click += btn_seleccionar_Click;
                btn_guardar.Click += btn_hecho_Click;
                carga();                
            }
        }
        
        private void panel1_MouseDown(object sender_panel, MouseEventArgs index_e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_salir_Click(object sender_salir, EventArgs index_e)
        {            
            this.Close();
        }

        public void definicionarrayMarcas()
        {
            vld_form.Text = new System.Windows.Forms.TextBox[1] {txt_nombre};
            vld_form.Error = new ErrorProvider[1] {erp_nombre};
            vld_form.Minimo = new int[1] {3};
            vld_form.Regular = new string[1] {"[A-Z, a-z, 0-9, ¡ * + % & $ # _]"};
            vld_form.Msj = new string[1] { @"Solo alfanumericos y especiales como: (¡ * + % & $ # _)" };
        }

        public void definicionarrayCategorias()
        {
            vld_form.Text = new System.Windows.Forms.TextBox[1] { txt_nombre };
            vld_form.Error = new ErrorProvider[1] { erp_nombre };
            vld_form.Minimo = new int[1] { 3 };
            vld_form.Regular = new string[1] { "[A-Z, a-z, 0-9]" };
            vld_form.Msj = new string[1] { "Solo alfanumericos" };
        }

        #region Botones del form

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            limpiarDatos();
            btn_guardar.Text = "GUARDAR";
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void limpiarDatos()
        {
            txt_nombre.Clear();
            txt_id.Clear();
            txt_buscar.Clear();
            txt_buscar.Focus();
            editar = false;
        }                
               
        #endregion

        #region Categorias Botones
        private void btn_guardarCategorias (object sender, EventArgs e)
        {
            definicionarrayCategorias();

            if (vld_form.comprobartxt() == false || vld_form.ValidarLetras(txt_nombre, erp_nombre) == false)
            {                
                frm_notificacion noti = new frm_notificacion("Operacion imcompleta por errores, ¡Corrija todos los errores!", 3);
                noti.ShowDialog();
                noti.Close();
                if (vld_form.ValidarLetras(txt_nombre, erp_nombre) == false);
            }
            else
            {
                if (editar == true)
                {
                    cate_form.IDCategoria = int.Parse(txt_id.Text);
                    cate_form.NombreCategoria = txt_nombre.Text;
                    if (cate_form.actualizarDatos())
                    {
                        limpiarDatos();
                        btn_guardar.Text = "Guardar";
                        cate_form.consultarDatos(dgv_datos);
                    }
                }
                else
                {
                    cate_form.NombreCategoria = txt_nombre.Text;
                    if (cate_form.guardar())
                    {
                        limpiarDatos();
                        btn_guardar.Text = "Guardar";
                        cate_form.consultarDatos(dgv_datos);
                    }
                }                
            }           
        }

        private void txt_buscarCategorias_TextChanged(object sender, EventArgs e)
        {
            cate_form.NombreCategoria = txt_buscar.Text;
            cate_form.buscarDatos(dgv_datos);
        }

        private void btn_editarCategorias_Click(object sender, EventArgs e)
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
                editar = true;
                btn_guardar.Text = "Actualizar";
            }
        }
                
        #endregion

        #region Marcas Botones
        private void btn_guardarMarcas(object sender, EventArgs e)
        {
            definicionarrayMarcas();

            if (vld_form.comprobartxt() == false || vld_form.ValidarLetras(txt_nombre, erp_nombre) == false)
            {
                frm_notificacion noti = new frm_notificacion("Operacion imcompleta por errores, ¡Corrija todos los errores!", 3);
                noti.ShowDialog();
                noti.Close();
                if (vld_form.ValidarLetras(txt_nombre, erp_nombre) == false) ;
            }
            else
            {
                if (editar == true)
                {
                    mar_form.IDMarca = int.Parse(txt_id.Text);
                    mar_form.NombreMarca = txt_nombre.Text;
                    if (mar_form.actualizarDatos())
                    {
                        limpiarDatos();
                        btn_guardar.Text = "Guardar";
                        mar_form.consultarDatos(dgv_datos);
                    }
                }
                else
                {
                    mar_form.NombreMarca = txt_nombre.Text;
                    if (mar_form.guardar())
                    {
                        limpiarDatos();
                        btn_guardar.Text = "Guardar";
                        mar_form.consultarDatos(dgv_datos);
                    }
                }                
            }
        }

        private void txt_buscarMarcas_TextChanged(object sender, EventArgs e)
        {
            mar_form.NombreMarca = txt_buscar.Text;
            mar_form.buscarDatos(dgv_datos);
        }

        private void btn_editarMarcas_Click(object sender, EventArgs e)
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
                editar = true;
                btn_guardar.Text = "Actualizar";
            }
        }

        #endregion

        #region Notificacion Compra

        private void btn_hecho_Click(object sender, EventArgs e)
        {
            if (editar == true)
            {
                noti_form.Id_noti = int.Parse(txt_id.Text);
                noti_form.eliminar();
            }
            else if (editar == false)
            {
                frm_notificacion noti = new frm_notificacion("Seleccioné algo antes", 3);
                noti.ShowDialog();
                noti.Close();
            }

        }

        private void txt_buscarNotificacion_TextChanged(object sender, EventArgs e)
        {
            noti_form.Producto = txt_buscar.Text;
            noti_form.buscardatos(dgv_datos);
        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
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
                editar = true;
            }            
        }

        public void carga()
        {
            lbl_titulo.Text = "PRODUCTOS POR COMPRAR";
            btn_nuevo.Text = "Seleccionar";
            gunaLabel3.Text = "Descripcion";
            btn_guardar.Text = "HECHO";
            this.Text = "PRODUCTOS POR COMPRAR";
            btn_editar.Hide();            

            txt_nombre.Enabled = false;
            editar = false;
            txt_nombre.Text = "";
            txt_id.Text = "";            

            noti_form.consultarDatos(dgv_datos);

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
