using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.IO.Source;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Tecno_Pc.Formularios
{
    public partial class frm_Facturas : Form
    {
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Validacion vld = new Clases.Cl_Validacion();
        Clases.Cl_Reportes rep = new Clases.Cl_Reportes();
        DataGridView dgv = new DataGridView();        

        public frm_Facturas()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.toolTip1.SetToolTip(this.txt_buscar, "Buscar");
            this.toolTip1.SetToolTip(this.cbo_filtro, "Seleccionar Filtro de Busqueda");
            this.toolTip1.SetToolTip(this.btn_imprimir, "Reportes de Ventas");
        }

        private void frm_Facturas_Load(object sender, EventArgs e)
        {
            dgv_Facturas.DataSource = sql.Consulta("select [id_factura], (c.nombre_cliente +' '+ c.apellido_cliente) Cliente, (e.nombre_empleado +' '+ e.apellido_empleado) Empleado, t.[tipo_transaccion] Transaccion, f.[fecha_venta], " +
                "f.isv, f.[id_sar] from Facturas f inner join Clientes c on c.[id_cliente] = f.[id_cliente] inner join Empleados e on e.[id_empleado] = f.[id_empleado] inner join Transacciones t on t.[id_transaccion] " +
                "= f.[id_transaccion] where [id_factura] > 0 order by f.[id_factura] desc");
            operacionesDatagrid();
            cbo_filtro.SelectedIndex = 1;
            txt_buscar.ShortcutsEnabled = false;
        }

        private void operacionesDatagrid()
        {
            dgv_Facturas.Columns[1].Visible = false;
            dgv_Facturas.Columns[6].Visible = false;
            dgv_Facturas.Columns[7].Visible = false;

            dgv_Facturas.Columns[0].Width = 50;
            dgv_Facturas.Columns[2].Width = 280;
            dgv_Facturas.Columns[3].Width = 280;            
        }        

        private async void dgv_Facturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Facturas.Rows[e.RowIndex].Cells["Mostrar"].Selected)
            {
                rep.Dgv = sql.Consulta("select [id_factura], (c.nombre_cliente +' '+ c.apellido_cliente) Cliente, (e.nombre_empleado +' '+ e.apellido_empleado) Empleado, t.[tipo_transaccion] Transaccion, f.[fecha_venta], " +
                    "f.isv, f.[id_sar] from Facturas f inner join Clientes c on c.[id_cliente] = f.[id_cliente] inner join Empleados e on e.[id_empleado] = f.[id_empleado] inner " +
                    "join Transacciones t on t.[id_transaccion] = f.[id_transaccion] where [id_factura] = " + dgv_Facturas.Rows[e.RowIndex].Cells[1].Value.ToString() + " order by f.[id_factura] desc");

                frm_notificacion noti = new frm_notificacion("", 4);
                noti.Show();

                Task tar1 = new Task(rep.PdfFacturas);
                tar1.Start();
                await tar1;

                noti.Close();
                Formularios.frm_principal frm = Application.OpenForms.OfType<Formularios.frm_principal>().SingleOrDefault();
                frm.abrirPdfs(new frm_Facturas()); //abrimos el pdf
            }
        }
       
        private void txt_buscar_TextChanged_1(object sender, EventArgs e)
        {
            if (cbo_filtro.Text == "ID Factura" && txt_buscar.Text != "")
            {
                dgv_Facturas.DataSource = sql.Consulta("select [id_factura], (c.nombre_cliente +' '+ c.apellido_cliente) Cliente, (e.nombre_empleado +' '+ e.apellido_empleado) Empleado, t.[tipo_transaccion] Transaccion, f.[fecha_venta], " +
                "f.isv, f.[id_sar] from Facturas f inner join Clientes c on c.[id_cliente] = f.[id_cliente] inner join Empleados e on e.[id_empleado] = f.[id_empleado] inner join Transacciones t on t.[id_transaccion] " +
                "= f.[id_transaccion] where f.[id_factura] = "+txt_buscar.Text+ " and [id_factura] > 0 order by f.[id_factura] desc");
                operacionesDatagrid();
            }else if (cbo_filtro.Text == "Cliente")
            {
                dgv_Facturas.DataSource = sql.Consulta("select [id_factura], (c.nombre_cliente +' '+ c.apellido_cliente) Cliente, (e.nombre_empleado +' '+ e.apellido_empleado) Empleado, t.[tipo_transaccion] Transaccion, f.[fecha_venta], " +
                "f.isv, f.[id_sar] from Facturas f inner join Clientes c on c.[id_cliente] = f.[id_cliente] inner join Empleados e on e.[id_empleado] = f.[id_empleado] inner join Transacciones t on t.[id_transaccion] " +
                "= f.[id_transaccion] where (c.nombre_cliente +' '+ c.apellido_cliente) LIKE '%" + txt_buscar.Text + "%' and [id_factura] > 0 order by f.[id_factura] desc");
                operacionesDatagrid();
            }
            else if (txt_buscar.Text == "")
            {
                dgv_Facturas.DataSource = sql.Consulta("select [id_factura], (c.nombre_cliente +' '+ c.apellido_cliente) Cliente, (e.nombre_empleado +' '+ e.apellido_empleado) Empleado, t.[tipo_transaccion] Transaccion, f.[fecha_venta], " +
               "f.isv, f.[id_sar] from Facturas f inner join Clientes c on c.[id_cliente] = f.[id_cliente] inner join Empleados e on e.[id_empleado] = f.[id_empleado] inner join Transacciones t on t.[id_transaccion] " +
               "= f.[id_transaccion] where [id_factura] > 0 order by f.[id_factura] desc");
                operacionesDatagrid();                
            }
            else{}
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_ReportVenta);

            if (frm == null)
            {
                frm_ReportVenta report = new frm_ReportVenta();
                report.Show();
            }
            else
            {
                frm.BringToFront();
            }
        }

        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbo_filtro.Text == "ID Factura" && Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_sar_Click(object sender, EventArgs e)
        {
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_sar);

            if (frm == null)
            {
                frm_sar sar = new frm_sar();
                sar.Show();
            }
            else
            {
                frm.BringToFront();
            }
        }
    }
}
