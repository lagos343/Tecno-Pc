﻿using System;
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
    public partial class frm_Ventas : Form
    {
        Clases.Cl_UsuarioLogueado user = new Clases.Cl_UsuarioLogueado();
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();

        public frm_Ventas()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.txt_buscar, "Buscar");
        }

        private void frm_Ventas_Load(object sender, EventArgs e)
        {
            dgv_Productos.DataSource = sql.Consulta("select *, (select Stock from Inventarios Where [ID Producto] = p.[ID Producto]) as Stock " +
                "from Productos p where Estado = 1 order by [Nombre Producto] asc");
            Operacionesdatagrid1();
            InicializarCombobox();
        }

        private void InicializarCombobox()
        {
            lbl_fechaCompra.Text = DateTime.Now.ToShortDateString();
            cbo_cliente.DataSource = sql.Consulta("select [ID Cliente], (Nombre + ' ' + Apellido) Nombre from Clientes where Estado = 1");
            cbo_cliente.DisplayMember = "Nombre";
            cbo_cliente.ValueMember = "ID Cliente";
            cbo_cliente.SelectedIndex = -1;

            cbo_tipoPago.DataSource = sql.Consulta("select * from Transacciones");
            cbo_tipoPago.DisplayMember = "Tipo Transaccion";
            cbo_tipoPago.ValueMember = "ID transaccion";
            cbo_tipoPago.SelectedIndex = -1;
        }

        private void Operacionesdatagrid1()
        {
            dgv_Productos.Columns[1].Visible = false;
            dgv_Productos.Columns[2].Visible = false;
            dgv_Productos.Columns[3].Visible = false;
            dgv_Productos.Columns[4].Visible = false;
            dgv_Productos.Columns[8].Visible = false;

            dgv_Productos.Columns[0].Width = 30;
            dgv_Productos.Columns[5].Width = 190;           

            dgv_Productos.Columns[7].HeaderText = "Precio";
        }

        private void Operacionesdatagrid2()
        {
            dgv_Factura.Columns[1].Visible = false;
            dgv_Factura.Columns[0].Width = 30;
            dgv_Factura.Columns[2].Width = 250;            
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
            foreach (DataGridViewRow fila in dgv_Factura.Rows )
            {
                if (fila.Cells[1].Value.ToString() == id)
                {
                    coin = coin + int.Parse(fila.Cells[3].Value.ToString());                    
                }
            }
            return coin;
        }

        private double calcularTotaleventa()
        {
            double coin = 0;
            string ISV;

            foreach (DataGridViewRow fila in dgv_Factura.Rows)
            {                                
                coin = coin + int.Parse(fila.Cells[4].Value.ToString());        
            }

            ISV = num_ISV.Value.ToString();
            ISV = "0." + ISV;
            coin = coin + (coin * double.Parse(ISV));
            return coin;
        }

        private void ActualizarCatosFactura()
        {
            
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
                double total;                         
                
                foreach (DataGridViewRow fila in dgv_Factura.Rows)
                {
                    if (fila.Cells[1].Value.ToString() == lbl_Id.Text)
                    {
                        dgv_Factura.Rows.Remove(fila);
                    }
                }

                total = double.Parse(txt_cant.Text) * double.Parse(lbl_precio.Text);
                dgv_Factura.Rows.Add(Tecno_Pc.Properties.Resources.EliminarProducto, lbl_Id.Text, lbl_producto.Text, cant.ToString(), total.ToString());

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
            foreach (DataGridViewRow fila in dgv_Factura.Rows)
            {
                dgv_Factura.Rows.Remove(fila);
            }

            foreach (DataGridViewRow fila in dgv_Factura.Rows)
            {
                dgv_Factura.Rows.Remove(fila);
            }

            txt_buscar.Clear();
            InicializarCombobox();            
            dgv_Productos.DataSource = sql.Consulta("select *, (select Stock from Inventarios Where [ID Producto] = p.[ID Producto]) as Stock " +
                "from Productos p where Estado = 1 order by [Nombre Producto] asc");
                    
            LimpiarProductoSeleccionado();
            foreach (DataGridViewRow fila in dgv_Factura.Rows)
            {
                // dgv_Factura.Rows.Remove(fila);
                dgv_Factura.Rows.Clear();
            }
            num_ISV.Value = 15;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (dgv_Factura.Rows.Count == 0 || cbo_cliente.SelectedIndex == -1 || cbo_tipoPago.SelectedIndex == -1)
            {
                frm_notificacion noti = new frm_notificacion("Debe añadir productos a la Factura y llenar todos sus datos antes", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                string ISV;
                ISV = num_ISV.Value.ToString();
                ISV = "0." + ISV;

                sql.Sql_Querys("insert into Facturas values("+cbo_cliente.SelectedValue.ToString()+", "+user.IdEmpleado_+", "+cbo_tipoPago.SelectedValue.ToString()+", " +
                    "GETDATE(), DATEADD(MONTH, 1, GETDATE()), "+ISV+")");

                foreach (DataGridViewRow fila in dgv_Factura.Rows)
                {
                    int idprod = int.Parse(fila.Cells[1].Value.ToString());
                    double precio = double.Parse(fila.Cells[4].Value.ToString()) / double.Parse(fila.Cells[3].Value.ToString());
                    int cant = int.Parse(fila.Cells[3].Value.ToString());
                    sql.Sql_Querys("insert into DetalleFactura values ((select Top 1 [ID Factura] from Facturas order by [ID Factura] desc), "
                        +idprod+", "+precio+", "+cant+")");
                    //sql.Sql_Querys("update Inventarios set Stock -= "+cant+" where[ID Producto] = " + idprod);
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

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
                     
        }

        private void dgv_Productos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Productos.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                txt_cant.Clear();
                lbl_Id.Text = dgv_Productos.Rows[e.RowIndex].Cells[1].Value.ToString();
                lbl_precio.Text = dgv_Productos.Rows[e.RowIndex].Cells[7].Value.ToString();
                lbl_producto.Text = dgv_Productos.Rows[e.RowIndex].Cells[5].Value.ToString() + " " + dgv_Productos.Rows[e.RowIndex].Cells[6].Value.ToString();
                lbl_stock.Text = dgv_Productos.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            dgv_Productos.DataSource = sql.Consulta("select *, (select Stock from Inventarios Where [ID Producto] = p.[ID Producto]) as Stock " +
                "from Productos p where Estado = 1 and [Nombre Producto] LIKE '%"+txt_buscar.Text+"%' order by [Nombre Producto] asc");
            Operacionesdatagrid1();
        }

        private void dgv_Factura_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Factura.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                dgv_Factura.Rows.RemoveAt(e.RowIndex);
            }

            lbl_TotalVenta.Text = calcularTotaleventa().ToString();
        }

        private void num_ISV_ValueChanged(object sender, EventArgs e)
        {
            lbl_TotalVenta.Text = calcularTotaleventa().ToString();
        }
    }
}
