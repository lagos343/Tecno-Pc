﻿using System;
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
    public partial class frm_Ventas : Form
    {
        Clases.Cl_SqlManaggement sql = new Clases.Cl_SqlManaggement();
        Clases.Cl_UsuarioLogueado usu = new Clases.Cl_UsuarioLogueado();

        public frm_Ventas()
        {
            InitializeComponent();
        }

        private void frm_Ventas_Load(object sender, EventArgs e)
        {
            dgv_Productos.DataSource = sql.Consulta("select Id_Producto, Nombre_Producto, Precio_Venta, Unidades_Stock " +
                "from Productos where Unidades_Stock > 0");
            Operacionesdatagrid1();
            Operacionesdatagrid2();
            LimpiarProductoSeleccionado();
            ActualizarCatosFactura();
        }

        private void Operacionesdatagrid1()
        {
            dgv_Productos.Columns[1].Visible = false;
            dgv_Productos.Columns[0].Width = 30;
            dgv_Productos.Columns[2].Width = 300;

            dgv_Productos.Columns[2].HeaderText = "Producto";
            dgv_Productos.Columns[3].HeaderText = "Precio";
            dgv_Productos.Columns[4].HeaderText = "Stock";
        }

        private void Operacionesdatagrid2()
        {
            dgv_Factura.Columns[1].Visible = false;
            dgv_Factura.Columns[0].Width = 30;
            dgv_Factura.Columns[2].Width = 230;            
        }

        private void LimpiarProductoSeleccionado()
        {
            txt_cant.Clear();
            txt_rebaja.Text = "";
            lbl_Id.Text = "";
            lbl_precio.Text = "";
            lbl_producto.Text = "";
            lbl_stock.Text = "";
        }

        private int buscarRepetidos(string id)
        {
            int coin = 0;
            foreach (DataGridViewRow fila in dgv_Factura.Rows )
            {
                if (fila.Cells[1].Value.ToString() == id)
                {
                    coin = coin + int.Parse(fila.Cells[3].Value.ToString());                    
                }
            }
            return coin;
        }

        private int calcularTotaleventa()
        {
            int coin = 0;
            foreach (DataGridViewRow fila in dgv_Factura.Rows)
            {                                
                coin = coin + int.Parse(fila.Cells[4].Value.ToString());        
            }
            return coin;
        }

        private void ActualizarCatosFactura()
        {
            lbl_fechaCompra.Text = DateTime.Now.ToShortDateString();
            DataTable UltimaFactura = new DataTable();
            UltimaFactura = sql.Consulta("Select Top 1 No_Factura from Factura where Fecha_Compra = '" + DateTime.Now.ToShortDateString() + "' order by No_Factura desc");

            if(UltimaFactura.Rows.Count == 0)
            {
                lbl_noFactura.Text = "1";
            }
            else
            {
                lbl_noFactura.Text = (int.Parse(UltimaFactura.Rows[0][0].ToString()) + 1).ToString();
            }
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            dgv_Productos.DataSource = sql.Consulta("select Id_Producto, Nombre_Producto, Precio_Venta, Unidades_Stock " +
                "from Productos where Unidades_Stock > 0 and Nombre_Producto LIKE '%" + txt_buscar.Text + "%'");
            Operacionesdatagrid1();
        }

        private void dgv_Productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Productos.Rows[e.RowIndex].Cells["Añadir"].Selected)
            {
                txt_cant.Clear();
                txt_rebaja.Text = "";
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
                frm_notificacion noti = new frm_notificacion("Debe indicar la cantidad vendida", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else if (int.Parse(txt_cant.Text) <= 0)
            {
                frm_notificacion noti = new frm_notificacion("Debe indicar una cantidad mayor a 0", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else if(cant > int.Parse(lbl_stock.Text))
            {
                frm_notificacion noti = new frm_notificacion("Escogio vender " + cant.ToString() + " unidades de '" + lbl_producto.Text + 
                    "' pero solo hay " + lbl_stock.Text + " unidades en existencia", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                int rebaja, subtotal, total;

                if (txt_rebaja.Text == string.Empty)
                {
                    rebaja = 0;
                }
                else
                {
                    rebaja = int.Parse(txt_rebaja.Text);
                }

                foreach (DataGridViewRow fila in dgv_Factura.Rows)
                {
                    if (fila.Cells[1].Value.ToString() == lbl_Id.Text)
                    {
                        dgv_Factura.Rows.Remove(fila);
                    }
                }

                subtotal = int.Parse(lbl_precio.Text) - rebaja;
                total = subtotal * cant;
                dgv_Factura.Rows.Add(Image.FromFile("EliminarProducto.png"), lbl_Id.Text, lbl_producto.Text, 
                    cant.ToString(), total.ToString());
                lbl_TotalVenta.Text = calcularTotaleventa().ToString();
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

            lbl_TotalVenta.Text = calcularTotaleventa().ToString();
        }

        private void btn_nuevaVenta_Click(object sender, EventArgs e)
        {
            txt_buscar.Clear();
            dgv_Productos.DataSource = sql.Consulta("select Id_Producto, Nombre_Producto, Precio_Venta, Unidades_Stock " +
                "from Productos where Unidades_Stock > 0");
            Operacionesdatagrid1();
            LimpiarProductoSeleccionado();
            ActualizarCatosFactura();           
            dgv_Factura.Rows.Clear();            
            lbl_TotalVenta.Text = calcularTotaleventa().ToString();
            txt_nomCliente.Clear();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_nomCliente.Text == string.Empty || dgv_Factura.Rows.Count == 0)
            {
                frm_notificacion noti = new frm_notificacion("Debe añadir productos a la Factura y especificar nombre de Cliente antes de guardar", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                sql.modi_guar_elim("insert into Factura values(" + int.Parse(lbl_noFactura.Text) + ", '" + lbl_fechaCompra.Text +
                "', '" + txt_nomCliente.Text + "', " + usu.Id_usuario + ")");

                foreach (DataGridViewRow fila in dgv_Factura.Rows)
                {
                    sql.modi_guar_elim("insert into DetallesFactura values(" + int.Parse(fila.Cells[1].Value.ToString()) + ", '" + lbl_fechaCompra.Text + "'" +
                        ", " + int.Parse(lbl_noFactura.Text) + ", " + int.Parse(fila.Cells[3].Value.ToString()) + ", " + int.Parse(fila.Cells[4].Value.ToString()) + ")");

                    sql.modi_guar_elim("Update Productos set Unidades_Stock = Unidades_Stock - " + int.Parse(fila.Cells[3].Value.ToString()) + " " +
                        "where Id_Producto = " + int.Parse(fila.Cells[1].Value.ToString()));
                }

                frm_notificacion noti = new frm_notificacion("Venta realizada con Exito", 1);
                noti.ShowDialog();
                noti.Close();
                btn_nuevaVenta.PerformClick();
            }            
        }

        #region KeyPres

        private void txt_nomCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txt_cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txt_rebaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        #endregion       
    }
}
