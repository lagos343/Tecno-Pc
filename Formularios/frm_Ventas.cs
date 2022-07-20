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
    public partial class frm_Ventas : Form
    {
        Clases.Cl_UsuarioLogueado user = new Clases.Cl_UsuarioLogueado();
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Reportes rep = new Clases.Cl_Reportes();

        public frm_Ventas()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.txt_buscar, "Buscar");

            if (Properties.Settings.Default.CodBar == "true")
            {
                dgv_Productos.Enabled = false;                
                txt_cant.Enabled = false;
                btn_añadir.Enabled = false;
            }
        }

        private void frm_Ventas_Load(object sender, EventArgs e)
        {
            dgv_Productos.DataSource = sql.consulta_registro("select *, (select stock_producto from Inventarios Where [id_producto] = p.[id_producto]) as Stock " +
                "from Productos p where estado_producto = 1 order by [nombre_producto] asc");
            Operacionesdatagrid1();
            InicializarCombobox();
            txt_buscar.Focus();
        }   

        private void InicializarCombobox()
        {
            lbl_fechaCompra.Text = DateTime.Now.ToShortDateString();
            cbo_cliente.DataSource = sql.consulta_registro("select [id_cliente], (nombre_cliente + ' ' + apellido_cliente) Nombre from Clientes where estado_cliente = 1");
            cbo_cliente.DisplayMember = "Nombre";
            cbo_cliente.ValueMember = "id_cliente";
            cbo_cliente.SelectedIndex = -1;

            cbo_tipoPago.DataSource = sql.consulta_registro("select * from Transacciones");
            cbo_tipoPago.DisplayMember = "tipo_transaccion";
            cbo_tipoPago.ValueMember = "id_transaccion";
            cbo_tipoPago.SelectedIndex = -1;
        }

        private void Operacionesdatagrid1()
        {
            dgv_Productos.Columns[1].Visible = false;
            dgv_Productos.Columns[2].Visible = false;
            dgv_Productos.Columns[3].Visible = false;
            dgv_Productos.Columns[4].Visible = false;
            dgv_Productos.Columns[8].Visible = false;
            dgv_Productos.Columns[9].Visible = false;

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
            txt_buscar.Clear();
            txt_buscar.Focus();
            erp_cant.Clear();
            erp_cliente.Clear();
            erp_dgvfactura.Clear();
            erp_tipopagos.Clear();            
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

            foreach (DataGridViewRow fila in dgv_Factura.Rows)
            {                                
                coin = coin + double.Parse(fila.Cells[4].Value.ToString());        
            }                 
            
            return coin;
        }

        private void btn_añadir_Click(object sender, EventArgs e)
        {
            try
            {
                erp_dgvfactura.Clear();
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
                    erp_cant.Clear();
                    erp_cant.SetError(txt_cant, "indique la cantidad vendida");
                }
                else if (int.Parse(txt_cant.Text) <= 0)
                {
                    frm_notificacion noti = new frm_notificacion("Debe indicar una cantidad mayor a 0", 3);
                    noti.ShowDialog();
                    noti.Close();
                    erp_cant.Clear();
                    erp_cant.SetError(txt_cant, "indique una cantidad positiva");
                }
                else if(cant > int.Parse(lbl_stock.Text))
                {
                    frm_notificacion noti = new frm_notificacion("Escogio vender " + cant.ToString() + " unidades de '" + lbl_producto.Text + 
                        "' pero solo hay " + lbl_stock.Text + " unidades en existencia", 3);
                    noti.ShowDialog();
                    noti.Close();
                    erp_cant.Clear();
                    erp_cant.SetError(txt_cant, "indique una cantidad dentro del stock");
                }
                else
                {
                    double total, desc = 0;                         
                
                    foreach (DataGridViewRow fila in dgv_Factura.Rows)
                    {
                        if (fila.Cells[1].Value.ToString() == lbl_Id.Text)
                        {
                            dgv_Factura.Rows.Remove(fila);
                        }
                    }

                    total = cant * double.Parse(lbl_precio.Text);

                    if (chk_desc.Checked)
                    {
                        desc = double.Parse("0." + Num_Descv.Value);
                        total = total - (total * desc);
                    }
                        
                    dgv_Factura.Rows.Add(Tecno_Pc.Properties.Resources.EliminarProducto, lbl_Id.Text, lbl_producto.Text, cant.ToString(), total.ToString(), desc.ToString());

                    lbl_TotalVenta.Text = calcularTotaleventa().ToString();
                    Operacionesdatagrid2();
                    LimpiarProductoSeleccionado();
                }
            }
            catch (Exception)
            {
                erp_cant.Clear();
                erp_cant.SetError(txt_cant, "Solo se permiten Numeros");
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
            dgv_Productos.DataSource = sql.consulta_registro("select *, (select stock_producto from Inventarios Where [id_producto] = p.[id_producto]) as Stock " +
                "from Productos p where estado_producto = 1 order by [nombre_producto] asc");
                    
            LimpiarProductoSeleccionado();
            foreach (DataGridViewRow fila in dgv_Factura.Rows)
            {                
                dgv_Factura.Rows.Clear();
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (dgv_Factura.Rows.Count == 0 || cbo_cliente.SelectedIndex == -1 || cbo_tipoPago.SelectedIndex == -1)
            {
                frm_notificacion noti = new frm_notificacion("Error al guardar la Factura, ¡faltan datos!", 3);
                noti.ShowDialog();
                noti.Close();
                escoger_erp();
            }
            else
            {
                long id = long.Parse(sql.consulta2_registro("select top 1 [id_factura] from Facturas order by [id_factura] desc"));
                DataTable Sar = sql.consulta_registro("select top 1 id_sar from Sar where fecha_limite >= GETDATE() and ((" + (id+1)+") >= (ran_desde - 1) " +
                    "and ("+(id+1)+ ") <= ran_hasta ) order by id_sar desc");

                if(Sar.Rows.Count > 0)
                {
                    long IdSar = long.Parse(Sar.Rows[0][0].ToString());
                    long ultimasar = long.Parse(sql.consulta2_registro("select top 1 id_sar from sar order by id_sar desc"));

                    if(IdSar == ultimasar)
                    {
                        sql.sql_querys("insert into Facturas values(" + (id + 1) + ", " + cbo_cliente.SelectedValue.ToString() + ", " + user.IdEmpleado_ + ", " + cbo_tipoPago.SelectedValue.ToString() +
                        ", GETDATE(), 0.15, " + IdSar + ")");

                        foreach (DataGridViewRow fila in dgv_Factura.Rows)
                        {
                            int cant = int.Parse(fila.Cells[3].Value.ToString());
                            int idprod = int.Parse(fila.Cells[1].Value.ToString());
                            sql.sql_querys("insert into DetalleFactura values (" + (id + 1) + ", "
                                + idprod + ", (Select [precio_unitario] from Productos where [id_producto] = " + idprod + "), " + cant + ", " + fila.Cells[5].Value.ToString() + ")");
                        }

                        GenerarFactura();
                        btn_nuevaVenta.PerformClick();
                    }
                    else
                    {
                        frm_notificacion noti = new frm_notificacion("Error al guardar la Factura, Se ha quedado sin Facturas Disponibles", 3);
                        noti.ShowDialog();
                        noti.Close();
                    }                    
                }
                else
                {
                    frm_notificacion noti = new frm_notificacion("Error al guardar la Factura, Se ha quedado sin Facturas Disponibles", 3);
                    noti.ShowDialog();
                    noti.Close();                   
                }                               
            }            
        }
         
        private async void GenerarFactura()
        {
            rep.Dgv = sql.consulta_registro("select Top 1 [id_factura], (c.nombre_cliente +' '+ c.apellido_cliente) Cliente, (e.nombre_empleado +' '+ e.apellido_empleado) Empleado, t.[tipo_transaccion] Transaccion, f.[fecha_venta], " +
                    "f.isv, f.[id_sar] from Facturas f inner join Clientes c on c.[id_cliente] = f.[id_cliente] inner join Empleados e on e.[id_empleado] = f.[id_empleado] inner " +
                    "join Transacciones t on t.[id_transaccion] = f.[id_transaccion] order by f.[id_factura] desc");

            frm_notificacion noti = new frm_notificacion("", 4);
            noti.Show();

            Task tar1 = new Task(rep.pdf_facturas);
            tar1.Start();
            await tar1;

            noti.Close();
            noti = new frm_notificacion("Venta realizada con Exito", 1);
            noti.ShowDialog();
            noti.Close();

            Formularios.frm_principal frm = Application.OpenForms.OfType<Formularios.frm_principal>().SingleOrDefault();
            frm.abrirPdfs(new frm_Ventas()); //abrimos el pdf
        }

        private void escoger_erp()
        {
            if (dgv_Factura.Rows.Count == 0)
            {
                erp_dgvfactura.Clear();
                erp_dgvfactura.SetError(dgv_Factura, "Añada productos a la factura");
            }

            if (cbo_cliente.SelectedIndex == -1)
            {
                erp_cliente.Clear();
                erp_cliente.SetError(cbo_cliente, "Escoja un cliente");
            }

            if (cbo_tipoPago.SelectedIndex == -1)
            {
                erp_tipopagos.Clear();
                erp_tipopagos.SetError(cbo_tipoPago, "Esgoja un tipo de pago");
            }
        }

        #region KeyPres
        
        private void cbo_tipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            erp_tipopagos.Clear();
        }

        private void txt_cant_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbo_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            erp_cliente.Clear();
        }

        #endregion

        private void dgv_Productos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Productos.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                txt_cant.Clear();
                lbl_Id.Text = dgv_Productos.Rows[e.RowIndex].Cells[1].Value.ToString();
                lbl_precio.Text = dgv_Productos.Rows[e.RowIndex].Cells[7].Value.ToString();
                lbl_producto.Text = dgv_Productos.Rows[e.RowIndex].Cells[5].Value.ToString() + " " + dgv_Productos.Rows[e.RowIndex].Cells[6].Value.ToString();
                lbl_stock.Text = dgv_Productos.Rows[e.RowIndex].Cells[10].Value.ToString();
                txt_cant.Focus();
            }
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text != "")
            {
                if (Properties.Settings.Default.CodBar == "true")
                {
                    dgv_Productos.DataSource = sql.consulta_registro("select *, (select stock_producto from Inventarios Where [id_producto] = p.[id_producto]) as Stock " +
                    "from Productos p where estado_producto = 1 and cod_barra = '" + txt_buscar.Text + "' order by [nombre_producto] asc");
                    Operacionesdatagrid1();

                    if (txt_buscar.Text.Length == 12)
                    {
                        if (dgv_Productos.Rows.Count != 0)
                        {
                            txt_cant.Text = "1";
                            lbl_Id.Text = dgv_Productos.Rows[0].Cells[1].Value.ToString();
                            lbl_precio.Text = dgv_Productos.Rows[0].Cells[7].Value.ToString();
                            lbl_producto.Text = dgv_Productos.Rows[0].Cells[5].Value.ToString() + " " + dgv_Productos.Rows[0].Cells[6].Value.ToString();
                            lbl_stock.Text = dgv_Productos.Rows[0].Cells[10].Value.ToString();
                            btn_añadir.PerformClick();                            
                        }
                        else
                        {
                            frm_notificacion noti = new frm_notificacion("No se encontro el Producto", 3);
                            noti.ShowDialog();
                            noti.Close();
                            LimpiarProductoSeleccionado();
                        }
                    }
                }
                else
                {
                    dgv_Productos.DataSource = sql.consulta_registro("select *, (select stock_producto from Inventarios Where [id_producto] = p.[id_producto]) as Stock " +
                    "from Productos p where estado_producto = 1 and [nombre_producto] LIKE '%" + txt_buscar.Text + "%' order by [nombre_producto] asc");
                    Operacionesdatagrid1();
                }
            }
            else
            {
                dgv_Productos.DataSource = sql.consulta_registro("select *, (select stock_producto from Inventarios Where [id_producto] = p.[id_producto]) as Stock " +
                    "from Productos p where estado_producto = 1 and [nombre_producto] LIKE '%" + txt_buscar.Text + "%' order by [nombre_producto] asc");
                Operacionesdatagrid1();
            }           
            
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

        private void chk_desc_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_desc.Checked) Num_Descv.Enabled = true;
            else Num_Descv.Enabled = false;
        }
    }
}
