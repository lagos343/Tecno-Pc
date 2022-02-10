using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repuestos_Arias.Formularios
{
    public partial class frm_compras : Form
    {
        Clases.Cl_SqlManaggement sql = new Clases.Cl_SqlManaggement();

        public frm_compras()
        {
            InitializeComponent();
        }

        private void frm_compras_Load(object sender, EventArgs e)
        {
            dgv_Productos.DataSource = sql.Consulta("select Id_Producto, Nombre_Producto, Precio_Venta, Unidades_Stock from Productos");
            Operacionesdatagrid1();
            Operacionesdatagrid2();
            LimpiarProductoSeleccionado();
        }

        private void Operacionesdatagrid1()
        {
            dgv_Productos.Columns[1].Visible = false;
            dgv_Productos.Columns[0].Width = 30;
            dgv_Productos.Columns[2].Width = 230;

            dgv_Productos.Columns[2].HeaderText = "Producto";
            dgv_Productos.Columns[3].HeaderText = "Precio";
            dgv_Productos.Columns[4].HeaderText = "Stock";
        }

        private void Operacionesdatagrid2()
        {
            dgv_Factura.Columns[1].Visible = false;
            dgv_Factura.Columns[0].Width = 30;
            dgv_Factura.Columns[2].Width = 270;
        }

        private void LimpiarProductoSeleccionado()
        {
            txt_cant.Clear();            
            lbl_Id.Text = "";
            lbl_precio.Text = "";
            lbl_producto.Text = "";
            lbl_stock.Text = "";
        }

        private int buscarRepetidos(string id)
        {
            int coin = 0;
            foreach (DataGridViewRow fila in dgv_Factura.Rows)
            {
                if (fila.Cells[1].Value.ToString() == id)
                {
                    coin = coin + int.Parse(fila.Cells[3].Value.ToString());
                }
            }
            return coin;
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            dgv_Productos.DataSource = sql.Consulta("select Id_Producto, Nombre_Producto, Precio_Venta, Unidades_Stock " +
                "from Productos where Nombre_Producto LIKE '%" + txt_buscar.Text + "%'");
            Operacionesdatagrid1();
        }

        private void dgv_Productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Productos.Rows[e.RowIndex].Cells["Añadir"].Selected)
            {
                txt_cant.Clear();                
                lbl_Id.Text = dgv_Productos.Rows[e.RowIndex].Cells[1].Value.ToString();
                lbl_precio.Text = dgv_Productos.Rows[e.RowIndex].Cells[3].Value.ToString();
                lbl_producto.Text = dgv_Productos.Rows[e.RowIndex].Cells[2].Value.ToString();
                lbl_stock.Text = dgv_Productos.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void btn_añadir_Click(object sender, EventArgs e)
        {
            int cant = 0;

            if (txt_cant.Text != string.Empty && lbl_Id.Text != string.Empty)
            {
                cant = int.Parse(txt_cant.Text);
                cant += buscarRepetidos(lbl_Id.Text);
            }

            if (lbl_Id.Text == "")
            {
                frm_notificacion noti = new frm_notificacion("¡Debe Escoger un Producto antes!", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else if (txt_cant.Text == string.Empty)
            {
                frm_notificacion noti = new frm_notificacion("Debe indicar la cantidad comprada", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else if (int.Parse(txt_cant.Text) <= 0)
            {
                frm_notificacion noti = new frm_notificacion("Debe indicar una cantidad mayor a 0", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {                          
                foreach (DataGridViewRow fila in dgv_Factura.Rows)
                {
                    if (fila.Cells[1].Value.ToString() == lbl_Id.Text)
                    {
                        dgv_Factura.Rows.Remove(fila);
                    }
                }                
                
                dgv_Factura.Rows.Add(Image.FromFile("EliminarProducto.png"), lbl_Id.Text, lbl_producto.Text, cant.ToString());                
                Operacionesdatagrid2();
                LimpiarProductoSeleccionado();
            }
        }

        private void dgv_Factura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Factura.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                dgv_Factura.Rows.RemoveAt(e.RowIndex);
            }

            //lbl_TotalVenta.Text = calcularTotaleventa().ToString();
        }

        private void btn_nuevaCompra_Click(object sender, EventArgs e)
        {
            txt_buscar.Clear();
            dgv_Productos.DataSource = sql.Consulta("select Id_Producto, Nombre_Producto, Precio_Venta, Unidades_Stock from Productos");
            Operacionesdatagrid1();
            LimpiarProductoSeleccionado();            
            dgv_Factura.Rows.Clear();            
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (dgv_Factura.Rows.Count == 0)
            {
                frm_notificacion noti = new frm_notificacion("Debe añadir productos a la Compra antes de guardar", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {               
                foreach (DataGridViewRow fila in dgv_Factura.Rows)
                {                    
                    sql.modi_guar_elim("Update Productos set Unidades_Stock = Unidades_Stock + " + int.Parse(fila.Cells[3].Value.ToString()) + " " +
                        "where Id_Producto = " + int.Parse(fila.Cells[1].Value.ToString()));
                }

                frm_notificacion noti = new frm_notificacion("Compra registrada con Exito", 1);
                noti.ShowDialog();
                noti.Close();
                btn_nuevaCompra.PerformClick();
            }
        }

        private void txt_cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
