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

        Clases.Cl_Productos prod = new Clases.Cl_Productos(); 
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();             


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
                InicializarCombobox();
                lbl_titulo.Text = "ACTUALIZAR PRODUCTO";
                btn_guardar.Text = "ACTUALIZAR";
                btn_guardar.Click += btn_guardarActualizado_Click;
                txt_id.Text = dat.CurrentRow.Cells[0+2].Value.ToString();
                cbo_marca.SelectedValue = dat.CurrentRow.Cells[2 + 2].Value.ToString();
                cbo_categoria.SelectedValue = dat.CurrentRow.Cells[1 + 2].Value.ToString();
                cbo_proveedor.SelectedValue = dat.CurrentRow.Cells[3 + 2].Value.ToString();
                txt_nombre.Text = dat.CurrentRow.Cells[4 + 2].Value.ToString();
                txt_modelo.Text = dat.CurrentRow.Cells[5 + 2].Value.ToString();
                txt_precio.Text = dat.CurrentRow.Cells[6 + 2].Value.ToString();
                swt_estado.Checked = Convert.ToBoolean(dat.CurrentRow.Cells[7 + 2].Value.ToString());
                txt_stock.Text = sql.Consulta2("Select Stock from Inventarios where [ID Producto] = "+txt_id.Text);
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
            cbo_marca.DataSource = sql.Consulta("select *from Marcas order by [Nombre Marca] asc");
            cbo_marca.DisplayMember = "Nombre Marca";
            cbo_marca.ValueMember = "ID Marca";
            cbo_marca.SelectedIndex = -1;

            cbo_categoria.DataSource = sql.Consulta("select *from Categorias order by [Nombre Categoria] asc");
            cbo_categoria.DisplayMember = "Nombre Categoria";
            cbo_categoria.ValueMember = "ID Categoria";
            cbo_categoria.SelectedIndex = -1;

            cbo_proveedor.DataSource = sql.Consulta("select *from Proveedores where Estado = 1 order by Nombre asc");
            cbo_proveedor.DisplayMember = "Nombre";
            cbo_proveedor.ValueMember = "ID Proveedor";
            cbo_proveedor.SelectedIndex = -1;
        }        

        private void btn_guardarGuardado_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text == "" || txt_modelo.Text == "" || txt_precio.Text == "" || txt_stock.Text == "" || 
                 cbo_categoria.SelectedIndex == -1 || cbo_marca.SelectedIndex == -1 || cbo_proveedor.SelectedIndex == -1)
            {
                frm_notificacion noti = new frm_notificacion("Llene todos los datos", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {               
                prod.IDMarca = int.Parse(cbo_marca.SelectedValue.ToString());
                prod.IDCategoria = int.Parse(cbo_categoria.SelectedValue.ToString());
                prod.IDProveedor = int.Parse(cbo_proveedor.SelectedValue.ToString());
                prod.NombreProducto = txt_nombre.Text;
                prod.Modelo = txt_modelo.Text;
                prod.PrecioUnitario = Convert.ToDouble(txt_precio.Text);
                prod.Estado = Convert.ToBoolean(swt_estado.Checked);
                prod.guardar();
                sql.Sql_Querys("insert into Inventarios values((select top 1 [ID Producto] from Productos order by[ID Producto] desc), "+txt_stock.Text+")");
                Limnpiado();
            }

            Formularios.frm_productos frm = Application.OpenForms.OfType<Formularios.frm_productos>().SingleOrDefault();
            frm.Dashboard();
        }

        private void btn_guardarActualizado_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text == "" || txt_modelo.Text == "" || txt_precio.Text == "" || txt_stock.Text == "" ||
                 cbo_categoria.SelectedIndex == -1 || cbo_marca.SelectedIndex == -1 || cbo_proveedor.SelectedIndex == -1)
            {
                frm_notificacion noti = new frm_notificacion("Llene todos los datos", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                prod.IDProducto = int.Parse(txt_id.Text);
                prod.IDMarca = int.Parse(cbo_marca.SelectedValue.ToString());
                prod.IDCategoria = int.Parse(cbo_categoria.SelectedValue.ToString());
                prod.IDProveedor = int.Parse(cbo_proveedor.SelectedValue.ToString());
                prod.NombreProducto = txt_nombre.Text;
                prod.Modelo = txt_modelo.Text;
                prod.PrecioUnitario = Convert.ToDouble(txt_precio.Text);
                prod.Estado = swt_estado.Checked;
                prod.actualizarDatos();
                sql.Sql_Querys("update Inventarios set Stock = " + txt_stock.Text + " where [ID Producto] = " + txt_id.Text);
                this.Close();
            }

            Formularios.frm_productos frm = Application.OpenForms.OfType<Formularios.frm_productos>().SingleOrDefault();
            frm.Dashboard();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Limnpiado()
        {
            txt_nombre.Clear();
            txt_id.Clear();
            txt_modelo.Clear();
            txt_precio.Clear();
            txt_stock.Clear();          
            cbo_categoria.SelectedIndex = -1;
            cbo_marca.SelectedIndex = -1;
            cbo_proveedor.SelectedIndex = -1;
        }


        #region KeyPress

        private void txt_precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)))
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
