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

namespace Tecno_Pc.Formularios
{
    public partial class frm_AñadirProductos : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        

        public frm_AñadirProductos(int estado, DataGridView dat)
        {
            InitializeComponent();
            if (estado == 1)
            {
                lbl_titulo.Text = "NUEVO PRODUCTO";
                btn_guardar.Click += btn_guardarGuardado_Click;
                InicializarCombobox();
            }
            else if (estado == 2)
            {
                lbl_titulo.Text = "ACTUALIZAR PRODUCTO";
                InicializarCombobox();               
            }
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_AñadirProductos_Load(object sender, EventArgs e)
        {
            
        }

        public void InicializarCombobox()
        {
            
        }

        private void btn_guardarGuardado_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text == "" || txt_nombre.Text == "" || txt_pCompra.Text == "" || txt_pVenta.Text == "" || 
                 cbo_categorias.SelectedIndex == -1 || cbo_marcas.SelectedIndex == -1)
            {
                frm_notificacion noti = new frm_notificacion("Llene todos los datos", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                
            }            
        }

        private void btn_guardarActualizado_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text == "" || txt_nombre.Text == "" || txt_pCompra.Text == "" || txt_pVenta.Text == "" || cbo_categorias.SelectedIndex == -1 || cbo_marcas.SelectedIndex == -1)
            {
                frm_notificacion noti = new frm_notificacion("Llene todos los datos", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {              
                this.Close();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Limnpiado()
        {
            txt_codigo.Clear();
            txt_id.Clear();
            txt_nombre.Clear();
            txt_pCompra.Clear();
            txt_pVenta.Clear();          
            cbo_categorias.SelectedIndex = -1;
            cbo_marcas.SelectedIndex = -1;
        }

        #region KeyPress
        private void txt_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {                
                    e.Handled = true;                
                }
        }

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txt_pCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txt_pVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txt_stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        #endregion

    }
}
