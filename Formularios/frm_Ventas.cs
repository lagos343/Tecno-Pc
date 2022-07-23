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
        //Declaracion de la Clases Necesarias para el funcionamiento del form
        Clases.Cl_UsuarioLogueado user = new Clases.Cl_UsuarioLogueado();
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Reportes rep = new Clases.Cl_Reportes();

        public frm_Ventas()
        {
            InitializeComponent();

            //definicion de la ayuda visual con tooltip
            this.toolTip1.SetToolTip(this.txt_buscar, "Buscar");

            //verificamos si estamos en modo de Escaner de Barras
            if (Properties.Settings.Default.CodBar == "true")
            {
                dgv_Productos.Enabled = false;                
                txt_cant.Enabled = false;
                btn_añadir.Enabled = false;
            }
        }

        private void frm_Ventas_Load(object sender, EventArgs e)
        {
            //mostramos la informacion inicial del form
            dgv_Productos.DataSource = sql.Consulta("select *, (select stock_producto from Inventarios Where [id_producto] = p.[id_producto]) as Stock " +
                "from Productos p where estado_producto = 1 order by [nombre_producto] asc");
            Operaciones_Datagrid1();
            Inicializar_Combobox();
            txt_buscar.Focus();
        }   

        private void Inicializar_Combobox() //carga la informacion de la DB en los Combobox y establece el valor de Vista y Seleccion
        {
            lbl_fechaCompra.Text = DateTime.Now.ToShortDateString();
            cbo_cliente.DataSource = sql.Consulta("select [id_cliente], (nombre_cliente + ' ' + apellido_cliente) Nombre from Clientes where estado_cliente = 1");
            cbo_cliente.DisplayMember = "Nombre";
            cbo_cliente.ValueMember = "id_cliente";
            cbo_cliente.SelectedIndex = -1;

            cbo_tipoPago.DataSource = sql.Consulta("select * from Transacciones");
            cbo_tipoPago.DisplayMember = "tipo_transaccion";
            cbo_tipoPago.ValueMember = "id_transaccion";
            cbo_tipoPago.SelectedIndex = -1;
        }

        private void Operaciones_Datagrid1() //prod que se encarga de ocultar columnas y dar apariencia a el Datagrid de los productos
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

        private void Operaciones_Datagrid2() //prod que se encarga de ocultar columnas y dar apariencia a el Datagrid de la lista de ventas
        {
            dgv_Factura.Columns[1].Visible = false;
            dgv_Factura.Columns[0].Width = 30;
            dgv_Factura.Columns[2].Width = 250;            
        }

        private void Limpiar_Producto_Seleccionado()
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

        private int Buscar_Repetidos(string id) //prod que busca si mandamos una producto que ya estaba en la lista de ventas
        {
            int coin_rep = 0;

            //recorremos las filas del datagrid y buscamos el prod
            foreach (DataGridViewRow fila_actual in dgv_Factura.Rows )
            {
                if (fila_actual.Cells[1].Value.ToString() == id)
                {
                    //en caso de encontrar una coincidencia sumamos la cant que estaba en el a la nueva cantidad
                    coin_rep = coin_rep + int.Parse(fila_actual.Cells[3].Value.ToString());                    
                }
            }
            return coin_rep;
        }

        private double Calcular_Total_Venta() //recorre todas las filas de detalle de venta y calcular el total de esta
        {
            double coin_rep = 0;

            foreach (DataGridViewRow fila_actual in dgv_Factura.Rows)
            {                                
                coin_rep = coin_rep + double.Parse(fila_actual.Cells[4].Value.ToString());        
            }                 
            
            return coin_rep;
        }

        private void btn_añadir_Click(object sender, EventArgs e) //añade productos a la lista de ventas
        {
            try
            {
                erp_dgvfactura.Clear();
                int cant_prod = 0;

                if (txt_cant.Text != string.Empty && lbl_Id.Text != string.Empty) //verificamos que la caantidad sea positiva y llamamos la busqueda de repetidos
                {
                    cant_prod = int.Parse(txt_cant.Text);
                    cant_prod += Buscar_Repetidos(lbl_Id.Text);
                }

                //validaciones basicas para evitar errores
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
                else if(cant_prod > int.Parse(lbl_stock.Text))
                {
                    frm_notificacion noti = new frm_notificacion("Escogio vender " + cant_prod.ToString() + " unidades de '" + lbl_producto.Text + 
                        "' pero solo hay " + lbl_stock.Text + " unidades en existencia", 3);
                    noti.ShowDialog();
                    noti.Close();
                    erp_cant.Clear();
                    erp_cant.SetError(txt_cant, "indique una cantidad dentro del stock");
                }
                else
                {
                    double total_prod, desc_prod = 0;

                    //verificamos si una fila ya tenia ese produto y la eliminamos para añadir una nueva con la suma de las 2 cantidades 
                    foreach (DataGridViewRow fila_actual in dgv_Factura.Rows)
                    {
                        if (fila_actual.Cells[1].Value.ToString() == lbl_Id.Text)
                        {
                            dgv_Factura.Rows.Remove(fila_actual);
                        }
                    }

                    total_prod = cant_prod * double.Parse(lbl_precio.Text);

                    //si hay descuento lo calculamos 
                    if (chk_desc.Checked)
                    {
                        desc_prod = double.Parse("0." + Num_Descv.Value);
                        total_prod = total_prod - (total_prod * desc_prod);
                    }

                    //añadimos la nueva fila    
                    dgv_Factura.Rows.Add(Tecno_Pc.Properties.Resources.EliminarProducto, lbl_Id.Text, lbl_producto.Text, cant_prod.ToString(), total_prod.ToString(), desc_prod.ToString());

                    lbl_TotalVenta.Text = Calcular_Total_Venta().ToString();
                    Operaciones_Datagrid2();
                    Limpiar_Producto_Seleccionado();
                }
            }
            catch (Exception)
            {
                erp_cant.Clear();
                erp_cant.SetError(txt_cant, "Solo se permiten Numeros");
            }
        }

        private void dgv_Factura_CellContentClick(object sender, DataGridViewCellEventArgs e) //prod que verifica si estamos tocando el boton de eliminar del datagrid de factura
        {
            if (dgv_Factura.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                dgv_Factura.Rows.RemoveAt(e.RowIndex);
            }

            lbl_TotalVenta.Text = Calcular_Total_Venta().ToString();
        }

        private void btn_nuevaVenta_Click(object sender, EventArgs e) //prod que limpia los datagrid y la info de una venta para realizar una nueva
        {
            //limpiamos la lista de compras
            foreach (DataGridViewRow fila in dgv_Factura.Rows)
            {
                dgv_Factura.Rows.Remove(fila);
            }

            foreach (DataGridViewRow fila in dgv_Factura.Rows)
            {
                dgv_Factura.Rows.Remove(fila);
            }

            txt_buscar.Clear();
            Inicializar_Combobox();            
            dgv_Productos.DataSource = sql.Consulta("select *, (select stock_producto from Inventarios Where [id_producto] = p.[id_producto]) as Stock " +
                "from Productos p where estado_producto = 1 order by [nombre_producto] asc");
                    
            Limpiar_Producto_Seleccionado();
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
                Escoger_Erp();
            }
            else
            {
                //buscamos la informacion de la SAR para ver si hay facturas disponobles
                long id_factura = long.Parse(sql.Consulta2("select top 1 [id_factura] from Facturas order by [id_factura] desc"));
                DataTable sar_tabla = sql.Consulta("select top 1 id_sar from Sar where fecha_limite >= GETDATE() and ((" + (id_factura + 1)+") >= (ran_desde - 1) " +
                    "and ("+(id_factura + 1)+ ") <= ran_hasta ) order by id_sar desc");

                //verificamos si hay registrso validos
                if(sar_tabla.Rows.Count > 0)
                {
                    long id_sar = long.Parse(sar_tabla.Rows[0][0].ToString());
                    long ultima_sar = long.Parse(sql.Consulta2("select top 1 id_sar from sar order by id_sar desc"));

                    if(id_sar == ultima_sar) //verificamos que la ultima SAR registrada sea la seleccionada
                    {
                        //creamos el registro de la factura
                        sql.Sql_Querys("insert into Facturas values(" + (id_factura + 1) + ", " + cbo_cliente.SelectedValue.ToString() + ", " + user.IdEmpleado_ + ", " + cbo_tipoPago.SelectedValue.ToString() +
                        ", GETDATE(), 0.15, " + id_sar + ")");
                        
                        //recorremos la lista de ventas para ir añadiendo a la BD esos registros del Detalle
                        foreach (DataGridViewRow fila_actual in dgv_Factura.Rows)
                        {
                            int cant = int.Parse(fila_actual.Cells[3].Value.ToString());
                            int id_producto = int.Parse(fila_actual.Cells[1].Value.ToString());
                            sql.Sql_Querys("insert into DetalleFactura values (" + (id_factura + 1) + ", "
                                + id_producto + ", (Select [precio_unitario] from Productos where [id_producto] = " + id_producto + "), " + cant + ", " + fila_actual.Cells[5].Value.ToString() + ")");
                        }

                        Generar_Factura(); //mostramos el pdf de la factura
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
         
        private async void Generar_Factura() //mandamos la informacion de la factura para mostrarala
        {
            rep.Dgv = sql.Consulta("select Top 1 [id_factura], (c.nombre_cliente +' '+ c.apellido_cliente) Cliente, (e.nombre_empleado +' '+ e.apellido_empleado) Empleado, t.[tipo_transaccion] Transaccion, f.[fecha_venta], " +
                    "f.isv, f.[id_sar] from Facturas f inner join Clientes c on c.[id_cliente] = f.[id_cliente] inner join Empleados e on e.[id_empleado] = f.[id_empleado] inner " +
                    "join Transacciones t on t.[id_transaccion] = f.[id_transaccion] order by f.[id_factura] desc");

            frm_notificacion noti = new frm_notificacion("", 4);
            noti.Show();

            Task tar1 = new Task(rep.PdfFacturas); //creamos un subproceso en base a las facturas 
            tar1.Start();
            await tar1;

            noti.Close();
            noti = new frm_notificacion("Venta realizada con Exito", 1);
            noti.ShowDialog();
            noti.Close();

            Formularios.frm_principal frm = Application.OpenForms.OfType<Formularios.frm_principal>().SingleOrDefault();
            frm.abrirPdfs(new frm_Ventas()); //abrimos el pdf
        }

        private void Escoger_Erp() //muestra los posibles errores de los Combobox
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

        private void dgv_Productos_CellContentClick_1(object sender, DataGridViewCellEventArgs e) //prod que verifica si estamos tocando el boton de añadir del datagrid
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

        private void txt_buscar_TextChanged(object sender, EventArgs e) //hace busquedas en el datagrid de productos y sirve como filtro para el Escaner de Barras
        {
            if (txt_buscar.Text != "") //verficamos que no este vacio
            {
                if (Properties.Settings.Default.CodBar == "true") //vemos si estamos en modo Escaner
                {
                    dgv_Productos.DataSource = sql.Consulta("select *, (select stock_producto from Inventarios Where [id_producto] = p.[id_producto]) as Stock " +
                    "from Productos p where estado_producto = 1 and cod_barra = '" + txt_buscar.Text + "' order by [nombre_producto] asc");
                    Operaciones_Datagrid1(); //hacemos la busqueda en base a el cod de barras leido por el escaner

                    if (txt_buscar.Text.Length == 12) 
                    {
                        if (dgv_Productos.Rows.Count != 0) //revisamos si se encontro ese producto en el sistema
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
                            Limpiar_Producto_Seleccionado();
                        }
                    }
                }
                else
                {
                    dgv_Productos.DataSource = sql.Consulta("select *, (select stock_producto from Inventarios Where [id_producto] = p.[id_producto]) as Stock " +
                    "from Productos p where estado_producto = 1 and [nombre_producto] LIKE '%" + txt_buscar.Text + "%' order by [nombre_producto] asc");
                    Operaciones_Datagrid1();
                }
            }
            else
            {
                dgv_Productos.DataSource = sql.Consulta("select *, (select stock_producto from Inventarios Where [id_producto] = p.[id_producto]) as Stock " +
                    "from Productos p where estado_producto = 1 and [nombre_producto] LIKE '%" + txt_buscar.Text + "%' order by [nombre_producto] asc");
                Operaciones_Datagrid1();
            }           
            
        }

        private void dgv_Factura_CellContentClick_1(object sender, DataGridViewCellEventArgs e) //prod que verifica si estamos tocando el boton de eliminar del datagrid de factura
        {
            if (dgv_Factura.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                dgv_Factura.Rows.RemoveAt(e.RowIndex);
            }

            lbl_TotalVenta.Text = Calcular_Total_Venta().ToString();
        }

        private void num_ISV_ValueChanged(object sender, EventArgs e)
        {
            lbl_TotalVenta.Text = Calcular_Total_Venta().ToString();
        }

        private void chk_desc_CheckedChanged(object sender, EventArgs e) //dependiendo de su estado podremos usar el Nmeric para indicar el descuento
        {
            if (chk_desc.Checked) Num_Descv.Enabled = true;
            else Num_Descv.Enabled = false;
        }
    }
}
