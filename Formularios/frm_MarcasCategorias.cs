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
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
                        
        bool editar = false;
        Clases.Cl_Marcas mar = new Clases.Cl_Marcas();
        Clases.Cl_Categorias cate = new Clases.Cl_Categorias();
        Clases.Cl_NotificacionCompra  noti = new Clases.Cl_NotificacionCompra();
        Clases.Cl_Validacion vld = new Clases.Cl_Validacion();

        public frm_MarcasCategorias(int valor)
        {          
            InitializeComponent();            

            if (valor == 1)
            {
                lbl_titulo.Text = "CATEGORIAS";
                btn_guardar.Click += btn_guardarCategorias;
                txt_buscar.TextChanged += txt_buscarCategorias_TextChanged;
                btn_editar.Click += btn_editarCategorias_Click;                            
                this.Text = "Categorias";
                cate.consultarDatos(dgv_datos);                
            }
            else if (valor == 2)
            {
                lbl_titulo.Text = "MARCAS";
                btn_guardar.Click += btn_guardarMarcas;
                txt_buscar.TextChanged += txt_buscarMarcas_TextChanged;
                btn_editar.Click += btn_editarMarcas_Click;            
                this.Text = "Marcas";
                mar.consultarDatos(dgv_datos);                
            }
            else if (valor == 3)
            {
                txt_buscar.TextChanged += txt_buscarNotificacion_TextChanged;
                btn_nuevo.Click += btn_seleccionar_Click;
                btn_guardar.Click += btn_hecho_Click;
                carga();                
            }
        }
        
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        public void definicionarrayMarcas()
        {
            vld.Text = new System.Windows.Forms.TextBox[1] {txt_nombre};
            vld.Error = new ErrorProvider[1] {erp_nombre};
            vld.Minimo = new int[1] {3};
            vld.Regular = new string[1] {"[A-Z, a-z, 0-9, ¡ * + % & $ # _]"};
            vld.Msj = new string[1] { @"Solo alfanumericos y especiales como: (¡ * + % & $ # _)" };
        }

        public void definicionarrayCategorias()
        {
            vld.Text = new System.Windows.Forms.TextBox[1] { txt_nombre };
            vld.Error = new ErrorProvider[1] { erp_nombre };
            vld.Minimo = new int[1] { 3 };
            vld.Regular = new string[1] { "[A-Z, a-z, 0-9]" };
            vld.Msj = new string[1] { "Solo alfanumericos" };
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

            if (vld.comprobartxt() == false || vld.ValidarLetras(txt_nombre, erp_nombre) == false)
            {                
                frm_notificacion noti = new frm_notificacion("Operacion imcompleta por errores, ¡Corrija todos los errores!", 3);
                noti.ShowDialog();
                noti.Close();
                if (vld.ValidarLetras(txt_nombre, erp_nombre) == false);
            }
            else
            {
                if (editar == true)
                {
                    cate.IDCategoria = int.Parse(txt_id.Text);
                    cate.NombreCategoria = txt_nombre.Text;
                    if (cate.actualizarDatos())
                    {
                        limpiarDatos();
                        btn_guardar.Text = "Guardar";
                        cate.consultarDatos(dgv_datos);
                    }
                }
                else
                {
                    cate.NombreCategoria = txt_nombre.Text;
                    if (cate.guardar())
                    {
                        limpiarDatos();
                        btn_guardar.Text = "Guardar";
                        cate.consultarDatos(dgv_datos);
                    }
                }                
            }           
        }

        private void txt_buscarCategorias_TextChanged(object sender, EventArgs e)
        {
            cate.NombreCategoria = txt_buscar.Text;
            cate.buscarDatos(dgv_datos);
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

            if (vld.comprobartxt() == false || vld.ValidarLetras(txt_nombre, erp_nombre) == false)
            {
                frm_notificacion noti = new frm_notificacion("Operacion imcompleta por errores, ¡Corrija todos los errores!", 3);
                noti.ShowDialog();
                noti.Close();
                if (vld.ValidarLetras(txt_nombre, erp_nombre) == false) ;
            }
            else
            {
                if (editar == true)
                {
                    mar.IDMarca = int.Parse(txt_id.Text);
                    mar.NombreMarca = txt_nombre.Text;
                    if (mar.actualizarDatos())
                    {
                        limpiarDatos();
                        btn_guardar.Text = "Guardar";
                        mar.consultarDatos(dgv_datos);
                    }
                }
                else
                {
                    mar.NombreMarca = txt_nombre.Text;
                    if (mar.guardar())
                    {
                        limpiarDatos();
                        btn_guardar.Text = "Guardar";
                        mar.consultarDatos(dgv_datos);
                    }
                }                
            }
        }

        private void txt_buscarMarcas_TextChanged(object sender, EventArgs e)
        {
            mar.NombreMarca = txt_buscar.Text;
            mar.buscarDatos(dgv_datos);
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
                noti.Id_noti = int.Parse(txt_id.Text);
                noti.eliminar();
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
            noti.Producto = txt_buscar.Text;
            noti.buscardatos(dgv_datos);
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

            noti.consultarDatos(dgv_datos);

            dgv_datos.Columns[0].Visible = false;
            dgv_datos.Columns[2].Visible = false;
            dgv_datos.Columns[4].Visible = false;
        }

        #endregion        

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {
            erp_nombre.Clear();
        }

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btn_guardar.PerformClick();                
            }
        }
    }
}
