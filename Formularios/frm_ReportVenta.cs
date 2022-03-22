using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using objExcel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;


namespace Tecno_Pc.Formularios
{

    public partial class frm_ReportVenta : Form
    {
        Clases.Cl_Excel ex = new Clases.Cl_Excel();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Clases.Cl_Excel excel = new Clases.Cl_Excel();

        public frm_ReportVenta()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.btn_imprimir, "Crear Reporte");
            dtp_desde.Enabled = false;
            dtp_hasta.Enabled = false;
            dtp_desde.TextColor = Color.White;
            dtp_hasta.TextColor = Color.White;
            dtp_hasta.Value = DateTime.Now;
            dtp_desde.Value = DateTime.Now.AddMonths(-1);
            dtp_desde.MaxDate = DateTime.Now;
            dtp_hasta.MaxDate = DateTime.Now;
        }

        private async void btn_imprimir_Click(object sender, EventArgs e)
        {
            if (radio_fecha.Checked == false && radio_hoy.Checked == false)
            {
                frm_notificacion noti = new frm_notificacion("Selecione un rango de fecha", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                btn_imprimir.Enabled = false;
                frm_notificacion noti = new frm_notificacion("", 4);
                noti.Show();

                Task tar1 = new Task(excelVentas);
                tar1.Start();
                await tar1;

                noti.Close();
                btn_imprimir.Enabled = true;
            }
        }

        private void excelVentas()
        {
            DateTime desde = new DateTime(), hasta = new DateTime();

            if (radio_hoy.Checked)
            { 
                ex.Fecha = DateTime.Now.ToShortDateString();
                desde = DateTime.Now;
                hasta = DateTime.Now;
            }
            else
            {
                ex.Fecha = dtp_desde.Value.ToShortDateString() + " hasta " + dtp_hasta.Value.ToShortDateString();
                desde = dtp_desde.Value;
                hasta = dtp_hasta.Value;
            }    
            
            ex.Cadena_consulta = "select f.[ID Factura], f.[Fecha Venta], c.Nombre + ' ' + c.Apellido as Cliente, e.Nombre + ' ' + e.Apellido as Empleado, tr.[Tipo Transaccion]  ,f.ISV*100 [ISV]," +
                    "sum((df.[Precio Historico] * df.Cantidad) + (df.[Precio Historico] * df.Cantidad * f.ISV)) as [Total Venta] from Facturas f " +
                    "inner join DetalleFactura df on df.[ID Factura] = f.[ID Factura] inner join Clientes c on c.[ID Cliente] = f.[ID Cliente] " +
                    "inner join Empleados e on e.[ID Empleado] = f.[ID Empleado] inner join Transacciones tr on tr.[ID Transaccion] = f.[ID Transaccion] where ((f.[Fecha Venta] <= '" + hasta.ToString("yyyy-MM-dd") +"') and (f.[Fecha Venta] >= '"
                    +desde.ToString("yyyy-MM-dd") +"')) " +
                    "group by f.[ID Factura], f.[Fecha Venta], c.Nombre + ' ' + c.Apellido, e.Nombre + ' ' + e.Apellido, tr.[Tipo Transaccion]  ,f.ISV";
            ex.Carpeta = "Ventas";
            ex.Cabecera = new string[7] { "#Factura", "Fecha", "Cliente", "Empleado", "Transaccion", "ISV", "Total" };
            ex.Titulo = "Reporte de Ventas";
            ex.RangoCabecera = "C5 I5";
            ex.GenerarExcel();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void radio_fecha_CheckedChanged(object sender, EventArgs e)
        {
            dtp_desde.Enabled = true;
            dtp_hasta.Enabled = true;
            dtp_desde.TextColor = Color.Gray;
            dtp_hasta.TextColor = Color.Gray;
        }

        private void radio_hoy_CheckedChanged(object sender, EventArgs e)
        {
            dtp_desde.Enabled = false;
            dtp_hasta.Enabled = false;
            dtp_desde.TextColor = Color.White;
            dtp_hasta.TextColor = Color.White;
        }
    }
}
