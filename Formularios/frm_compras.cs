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
            this.toolTip1.SetToolTip(this.Btn_Notificacion, "Productos por Comprar");
            this.toolTip1.SetToolTip(this.txt_buscar, "Buscar");

            if (Properties.Settings.Default.CodBar == "true")
            {
                dgv_Productos.Enabled = false;
                txt_cant.Enabled = false;
            }
        }

        private void frm_compras_Load(object sender, EventArgs e)
        {
            productos.consultarDatos(dgv_Productos);
            Operaciones_Datagrid1();
            txt_buscar.Focus();
        }

        private void Operaciones_Datagrid1()
        {
            dgv_Productos.Columns[1].Visible = false;
            dgv_Productos.Columns[2].Visible = false;
            dgv_Productos.Columns[3].Visible = false;
            dgv_Productos.Columns[4].Visible = false;
            dgv_Productos.Columns[6].Visible = false;
            dgv_Productos.Columns[8].Visible = false;
            dgv_Productos.Columns[9].Visible = false;
            dgv_Productos.Columns[0].Width = 50;

            dgv_Productos.Columns[5].HeaderText = "Producto";
            dgv_Productos.Columns[7].HeaderText = "Precio";
            dgv_Productos.Columns[9].HeaderText = "Stock";
        }

        private void Operaciones_Datagrid2()
        {
            dgv_Factura.Columns[1].Visible = false;
            dgv_Factura.Columns[0].Width = 30;
            dgv_Factura.Columns[2].Width = 270;
        }

        private void Limpiar_Productoseleccionado()
        {
            txt_cant.Clear();            
            lbl_Id.Text = "";
            lbl_precio.Text = "";
            lbl_producto.Text = "";
            lbl_stock.Text = "";
            txt_buscar.Clear();
            txt_buscar.Focus();
            erp_cant.Clear();
            erp_dgvfactura.Clear();
        }

        private int buscar_Repetidos(string id)
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
        
        private void dgv_Productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Productos.Rows[e.RowIndex].Cells["Añadir"].Selected)
            {
                txt_cant.Clear();                
                lbl_Id.Text = dgv_Productos.Rows[e.RowIndex].Cells[1].Value.ToString();
                lbl_precio.Text = dgv_Productos.Rows[e.RowIndex].Cells[7].Value.ToString();
                lbl_producto.Text = dgv_Productos.Rows[e.RowIndex].Cells[5].Value.ToString();
                lbl_stock.Text = dgv_Productos.Rows[e.RowIndex].Cells[10].Value.ToString();
                txt_cant.Focus();
            }
        }


        private void dgv_Factura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Factura.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                dgv_Factura.Rows.RemoveAt(e.RowIndex);            
            }

        }

        private void btn_nuevaCompra_Click(object sender, EventArgs e)
        {
            txt_buscar.Clear();
            dgv_Productos.DataSource = sql.Consulta("select *, (select stock_producto from Inventarios Where [id_producto] = p.[id_producto]) as Stock " +
                "from Productos p where estado_producto = 1 order by [nombre_producto] asc");
            Limpiar_Productoseleccionado();

            foreach (DataGridViewRow fila in dgv_Factura.Rows)
            {
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
                erp_dgvfactura.Clear();
                erp_dgvfactura.SetError(dgv_Factura, "Agregue productos a la venta");
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
                Btn_Nuevacompra.PerformClick();
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
            if (txt_buscar.Text != "")
            {
                if (Properties.Settings.Default.CodBar == "true")
                {
                    dgv_Productos.DataSource = sql.Consulta("select *, (select stock_producto from Inventarios Where [id_producto] = p.[id_producto]) as Stock " +
                    "from Productos p where estado_producto = 1 and cod_barra = '" + txt_buscar.Text + "' order by [nombre_producto] asc");
                    Operaciones_Datagrid1();

                    if (txt_buscar.Text.Length == 12)
                    {
                        if (dgv_Productos.Rows.Count != 0)
                        {                            
                            lbl_Id.Text = dgv_Productos.Rows[0].Cells[1].Value.ToString();
                            lbl_precio.Text = dgv_Productos.Rows[0].Cells[7].Value.ToString();
                            lbl_producto.Text = dgv_Productos.Rows[0].Cells[5].Value.ToString() + " " + dgv_Productos.Rows[0].Cells[6].Value.ToString();
                            lbl_stock.Text = dgv_Productos.Rows[0].Cells[10].Value.ToString();
                            txt_cant.Enabled = true;
                            txt_cant.Focus();
                        }
                        else
                        {
                            frm_notificacion noti = new frm_notificacion("No se encontro el Producto", 3);
                            noti.ShowDialog();
                            noti.Close();
                            Limpiar_Productoseleccionado();
                        }
                    }
                }
                else
                {
                    productos.Nombre_Producto = txt_buscar.Text;
                    productos.buscarDatos(dgv_Productos);
                    Operaciones_Datagrid1();
                }
            }
            else
            {
                productos.Nombre_Producto = txt_buscar.Text;
                productos.buscarDatos(dgv_Productos);
                Operaciones_Datagrid1();
            }
            
        }

        private void btn_añadir_Click(object sender, EventArgs e)
        {
            try
            {
                int cant = 0;
                erp_dgvfactura.Clear();

                if (txt_cant.Text != string.Empty && lbl_Id.Text != string.Empty)
                {
                    cant = int.Parse(txt_cant.Text);
                    cant += buscar_Repetidos(lbl_Id.Text);
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
                    erp_cant.Clear();
                    erp_cant.SetError(txt_cant, "Indique la cantidad");
                }
                else if (int.Parse(txt_cant.Text) <= 0)
                {
                    frm_notificacion noti = new frm_notificacion("Debe indicar una cantidad mayor a 0", 3);
                    noti.ShowDialog();
                    noti.Close();
                    erp_cant.Clear();
                    erp_cant.SetError(txt_cant, "Indique una cantidad positiva");
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

                    double total = cant * double.Parse(lbl_precio.Text);
                    dgv_Factura.Rows.Add(Tecno_Pc.Properties.Resources.EliminarProducto, lbl_Id.Text, lbl_producto.Text, cant.ToString(), total.ToString());
                    Operaciones_Datagrid2();
                    Limpiar_Productoseleccionado();
                }
            }
            catch (Exception)
            {                
                erp_cant.Clear();
                erp_cant.SetError(txt_cant, "Solo se permiten Numeros");
            }
        }


        private void txt_cant_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            else
            {
                erp_cant.Clear();
            }
        }
    }
}
