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

namespace Repuestos_Arias.Formularios
{
    public partial class frm_AñadirProductos : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Clases.Cl_SqlManaggement sql = new Clases.Cl_SqlManaggement();
        Clases.Cl_Productos prod = new Clases.Cl_Productos();

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
                btn_guardar.Click += btn_guardarActualizado_Click;
                txt_id.Text = dat.CurrentRow.Cells[2].Value.ToString();
                txt_codigo.Text = dat.CurrentRow.Cells[3].Value.ToString();
                txt_nombre.Text = dat.CurrentRow.Cells[4].Value.ToString();
                txt_pCompra.Text = dat.CurrentRow.Cells[5].Value.ToString();
                txt_pVenta.Text = dat.CurrentRow.Cells[6].Value.ToString();
                txt_stock.Text = dat.CurrentRow.Cells[7].Value.ToString();
                cbo_categorias.SelectedValue = int.Parse(dat.CurrentRow.Cells[8].Value.ToString());
                cbo_marcas.SelectedValue = int.Parse(dat.CurrentRow.Cells[9].Value.ToString());                
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
            DataTable marcasTabla = new DataTable();
            DataTable catesTabla = new DataTable();

            catesTabla = sql.Consulta("select *from Categorias");
            marcasTabla = sql.Consulta("select *from Marcas");

            cbo_categorias.DataSource = catesTabla;
            cbo_categorias.ValueMember = "Id_Categoria";
            cbo_categorias.DisplayMember = "Nombre_Categoria";

            cbo_marcas.DataSource = marcasTabla;
            cbo_marcas.ValueMember = "Id_Marca";
            cbo_marcas.DisplayMember = "Nombre_Marca";
        }

        private void btn_guardarGuardado_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text == "" || txt_nombre.Text == "" || txt_pCompra.Text == "" || txt_pVenta.Text == "" || 
                txt_stock.Text == "" || cbo_categorias.SelectedIndex == -1 || cbo_marcas.SelectedIndex == -1)
            {
                frm_notificacion noti = new frm_notificacion("Llene todos los datos", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                prod.Codigo_Producto = txt_codigo.Text;
                prod.Nombre_Producto = txt_nombre.Text;
                prod.Precio_Compra = Double.Parse(txt_pCompra.Text);
                prod.Precio_Venta = Double.Parse(txt_pVenta.Text);
                prod.Unidades_Stock = Double.Parse(txt_stock.Text);
                prod.Id_Marca = int.Parse(cbo_marcas.SelectedValue.ToString());
                prod.Id_Categoria = int.Parse(cbo_categorias.SelectedValue.ToString());

                prod.guardar();
                Limnpiado();
            }            
        }

        private void btn_guardarActualizado_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text == "" || txt_nombre.Text == "" || txt_pCompra.Text == "" || txt_pVenta.Text == "" ||
                txt_stock.Text == "" || cbo_categorias.SelectedIndex == -1 || cbo_marcas.SelectedIndex == -1)
            {
                frm_notificacion noti = new frm_notificacion("Llene todos los datos", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                prod.Codigo_Producto = txt_codigo.Text;
                prod.Nombre_Producto = txt_nombre.Text;
                prod.Precio_Compra = Double.Parse(txt_pCompra.Text);
                prod.Precio_Venta = Double.Parse(txt_pVenta.Text);
                prod.Unidades_Stock = Double.Parse(txt_stock.Text);
                prod.Id_Marca = int.Parse(cbo_marcas.SelectedValue.ToString());
                prod.Id_Categoria = int.Parse(cbo_categorias.SelectedValue.ToString());
                prod.Id_Producto = int.Parse(txt_id.Text);

                prod.actualizarDatos();
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
            txt_stock.Clear();
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
