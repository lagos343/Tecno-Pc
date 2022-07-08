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
            dgv_Facturas.DataSource = sql.Consulta("select [ID Factura], (c.Nombre +' '+ c.Apellido) Cliente, (e.Nombre +' '+ e.Apellido) Empleado, t.[Tipo Transaccion] Transaccion, f.[Fecha Venta], f.[Fecha Vencimiento], " +
                "f.ISV from Facturas f inner join Clientes c on c.[ID Cliente] = f.[ID Cliente] inner join Empleados e on e.[ID Empleado] = f.[ID Empleado] inner join Transacciones t on t.[ID Transaccion] " +
                "= f.[ID Transaccion] order by f.[ID Factura] desc");
            operacionesDatagrid();
            cbo_filtro.SelectedIndex = 1;
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
                rep.Dgv = sql.Consulta("select [ID Factura], (c.Nombre +' '+ c.Apellido) Cliente, (e.Nombre +' '+ e.Apellido) Empleado, t.[Tipo Transaccion] Transaccion, f.[Fecha Venta], " +
                    "f.[Fecha Vencimiento], f.ISV from Facturas f inner join Clientes c on c.[ID Cliente] = f.[ID Cliente] inner join Empleados e on e.[ID Empleado] = f.[ID Empleado] inner " +
                    "join Transacciones t on t.[ID Transaccion] = f.[ID Transaccion] where [ID Factura] = " + dgv_Facturas.Rows[e.RowIndex].Cells[1].Value.ToString() + " order by f.[ID Factura] desc");

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
                dgv_Facturas.DataSource = sql.Consulta("select [ID Factura], (c.Nombre +' '+ c.Apellido) Cliente, (e.Nombre +' '+ e.Apellido) Empleado, t.[Tipo Transaccion] Transaccion, f.[Fecha Venta], f.[Fecha Vencimiento], " +
                "f.ISV from Facturas f inner join Clientes c on c.[ID Cliente] = f.[ID Cliente] inner join Empleados e on e.[ID Empleado] = f.[ID Empleado] inner join Transacciones t on t.[ID Transaccion] " +
                "= f.[ID Transaccion] where f.[ID Factura] = "+txt_buscar.Text+" order by f.[ID Factura] desc");
                operacionesDatagrid();
            }else if (cbo_filtro.Text == "Cliente")
            {
                dgv_Facturas.DataSource = sql.Consulta("select [ID Factura], (c.Nombre +' '+ c.Apellido) Cliente, (e.Nombre +' '+ e.Apellido) Empleado, t.[Tipo Transaccion] Transaccion, f.[Fecha Venta], f.[Fecha Vencimiento], " +
                "f.ISV from Facturas f inner join Clientes c on c.[ID Cliente] = f.[ID Cliente] inner join Empleados e on e.[ID Empleado] = f.[ID Empleado] inner join Transacciones t on t.[ID Transaccion] " +
                "= f.[ID Transaccion] where (c.Nombre +' '+ c.Apellido) LIKE '%" + txt_buscar.Text + "%' order by f.[ID Factura] desc");
                operacionesDatagrid();
            }
            else if (txt_buscar.Text == "")
            {
                dgv_Facturas.DataSource = sql.Consulta("select [ID Factura], (c.Nombre +' '+ c.Apellido) Cliente, (e.Nombre +' '+ e.Apellido) Empleado, t.[Tipo Transaccion] Transaccion, f.[Fecha Venta], f.[Fecha Vencimiento], " +
               "f.ISV from Facturas f inner join Clientes c on c.[ID Cliente] = f.[ID Cliente] inner join Empleados e on e.[ID Empleado] = f.[ID Empleado] inner join Transacciones t on t.[ID Transaccion] " +
               "= f.[ID Transaccion] order by f.[ID Factura] desc");
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
    }
}
