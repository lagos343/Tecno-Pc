using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Formularios
{
    public partial class frm_reportes : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

       

        public frm_reportes(int reporte)
        {
            //InitializeComponent();
            //if (reporte == 1)
            //{
            //    table = sql.Consulta("select *from Categorias order by Nombre_Categoria asc");
            //    reportViewer1.LocalReport.ReportEmbeddedResource = "Repuestos_Arias.Formularios.Report_Categorias.rdlc";
            //}
            //else if (reporte == 2)
            //{
            //    table = sql.Consulta("select *from Marcas order by Nombre_Marca asc");
            //    reportViewer1.LocalReport.ReportEmbeddedResource = "Repuestos_Arias.Formularios.Report_Marcas.rdlc";
            //}
            //else if (reporte == 3)
            //{
            //    table = sql.Consulta("select *from Productos order by Nombre_Producto asc");
            //    reportViewer1.LocalReport.ReportEmbeddedResource = "Repuestos_Arias.Formularios.Report_Productos.rdlc";
            //}
            //else if (reporte == 4)
            //{
            //    table = sql.Consulta("select *from Productos order by Nombre_Producto asc");
            //}                       
        }

        public frm_reportes(int No_Factura, string Fecha_Compra)
        {
            //InitializeComponent();
            //table = sql.Consulta("select fa.No_Factura, fa.Fecha_Compra, fa.Nombre_Cliente, (us.Nombres_Propietario + ' ' + us.Apellidos_Propietario) as Usuario_Vendedor, " +
            //    "(select SUM(Total) from DetallesFactura df where df.Fecha_Compra = fa.Fecha_Compra and df.No_Factura = fa.No_Factura) as Total_Compra " +
            //    "from Factura fa inner join Usuarios us on us.Id_Usuario = fa.Usuario_Vendedor where fa.No_Factura = " + No_Factura + " " +
            //    "and fa.Fecha_Compra = '" + Fecha_Compra + "'");

            //table2 = sql.Consulta("select pd.Nombre_Producto, df.Cant, df.Total, (df.Total / df.Cant) as Precio_Unitario " +
            //    "from DetallesFactura df inner join Productos pd on pd.Id_Producto = df.Id_Producto where df.No_Factura = " + No_Factura + " " +
            //    "and df.Fecha_Compra = '" + Fecha_Compra + "'");

            //reportViewer1.LocalReport.ReportEmbeddedResource = "Repuestos_Arias.Formularios.Report_Facturas.rdlc";
        }

        private void frm_reportes_Load(object sender, EventArgs e)
        {
            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", table));            

            //try
            //{               
            //    reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", table2));
            //    this.reportViewer1.RefreshReport();
            //}
            //catch (Exception ex){}
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }        
    }
}
