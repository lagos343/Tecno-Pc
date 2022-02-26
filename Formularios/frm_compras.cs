using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Formularios
{
    public partial class frm_compras : Form
    {
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Productos productos = new Clases.Cl_Productos();



        public frm_compras()
        {
            InitializeComponent();
        }

        private void frm_compras_Load(object sender, EventArgs e)
        {
            productos.consultarDatos(dgv_Productos);
            Operacionesdatagrid1();
        }

        private void Operacionesdatagrid1()
        {
            dgv_Productos.Columns[1].Visible = false;
            dgv_Productos.Columns[2].Visible = false;
            dgv_Productos.Columns[3].Visible = false;
            dgv_Productos.Columns[4].Visible = false;
            dgv_Productos.Columns[6].Visible = false;
            dgv_Productos.Columns[8].Visible = false;
            dgv_Productos.Columns[0].Width = 50;

            dgv_Productos.Columns[5].HeaderText = "Producto";
            dgv_Productos.Columns[7].HeaderText = "Precio";
            dgv_Productos.Columns[9].HeaderText = "Stock";
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
            
        }

        private void dgv_Productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Productos.Rows[e.RowIndex].Cells["Añadir"].Selected)
            {
                txt_cant.Clear();                
                lbl_Id.Text = dgv_Productos.Rows[e.RowIndex].Cells[1].Value.ToString();
                lbl_precio.Text = dgv_Productos.Rows[e.RowIndex].Cells[7].Value.ToString();
                lbl_producto.Text = dgv_Productos.Rows[e.RowIndex].Cells[5].Value.ToString();
                lbl_stock.Text = dgv_Productos.Rows[e.RowIndex].Cells[9].Value.ToString();
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
            dgv_Productos.DataSource = sql.Consulta("select *, (select Stock from Inventarios Where [ID Producto] = p.[ID Producto]) as Stock " +
                "from Productos p where Estado = 1 order by [Nombre Producto] asc");
            LimpiarProductoSeleccionado();
            foreach (DataGridViewRow fila in dgv_Factura.Rows)
            {
                //dgv_Factura.Rows.Remove(fila);
                dgv_Factura.Rows.Clear();
                
            }
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
                    int idprod = int.Parse(fila.Cells[1].Value.ToString());
                    double precio = double.Parse(fila.Cells[4].Value.ToString()) / double.Parse(fila.Cells[3].Value.ToString());
                    int cant = int.Parse(fila.Cells[3].Value.ToString());
                    sql.Sql_Querys("insert into Compras values ("+idprod+",getdate(),"+cant+", "+precio+")");
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

        private void btn_notificacion_Click(object sender, EventArgs e)
        {
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_MarcasCategorias);
            if (frm == null)
            {
                frm_MarcasCategorias catego = new frm_MarcasCategorias(3);
                catego.Show();
            }
            else
            {
                frm.BringToFront();
            }
        }

        private void txt_buscar_TextChanged_1(object sender, EventArgs e)
        {
            productos.NombreProducto = txt_buscar.Text;
            productos.buscarDatos(dgv_Productos);
            Operacionesdatagrid1();
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

                double total = double.Parse(txt_cant.Text) * double.Parse(lbl_precio.Text);
                dgv_Factura.Rows.Add(Tecno_Pc.Properties.Resources.EliminarProducto, lbl_Id.Text, lbl_producto.Text, cant.ToString(), total.ToString());
                Operacionesdatagrid2();
                LimpiarProductoSeleccionado();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Ignorar
        }

        private void txt_cant_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
