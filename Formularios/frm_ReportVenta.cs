using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Tecno_Pc.Formularios
{

    public partial class frm_ReportVenta : Form
    {
        Clases.Cl_Reportes rep = new Clases.Cl_Reportes();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        

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

                Task tar1 = new Task(ReporteVentas);
                tar1.Start();
                await tar1;

                noti.Close();
                btn_imprimir.Enabled = true;

                Formularios.frm_principal frm = Application.OpenForms.OfType<Formularios.frm_principal>().SingleOrDefault();
                frm.abrirPdfs(new frm_Facturas()); //abrimos el pdf
                frm.BringToFront();
            }
        }

        private void ReporteVentas()
        {
            DateTime desde = new DateTime(), hasta = new DateTime();
            string titulo = "";   

            if (radio_hoy.Checked)
            { 
                rep.Fecha = "";
                desde = DateTime.Now;
                hasta = DateTime.Now;
                titulo = "Reporte de Ventas " + desde.ToString("dd-MM-yyyy");
            }
            else
            {
                rep.Fecha = "";
                desde = dtp_desde.Value;
                hasta = dtp_hasta.Value;
                titulo = "Reporte de Ventas " + desde.ToString("dd-MM-yyyy") + " hasta " + hasta.ToString("dd-MM-yyyy");
            }    
            
            rep.Cadena_consulta = "select f.[id_factura], c.nombre_cliente + ' ' + c.apellido_cliente as Cliente, f.[fecha_venta], e.nombre_empleado + ' ' + e.apellido_empleado as Empleado, tr.[tipo_transaccion]  ,f.isv*100 [ISV]," +
                    "sum((df.[precio_historico] * df.cantidad) - (df.[precio_historico] * df.cantidad * df.descuentos)) as [total_venta] from Facturas f " +
                    "inner join DetalleFactura df on df.[id_factura] = f.[id_factura] inner join Clientes c on c.[id_cliente] = f.[id_cliente] " +
                    "inner join Empleados e on e.[id_empleado] = f.[id_empleado] inner join Transacciones tr on tr.[id_transaccion] = f.[id_transaccion] where ((f.[fecha_venta] <= '" + hasta.ToString("yyyy-MM-dd") +"') and (f.[fecha_venta] >= '"
                    +desde.ToString("yyyy-MM-dd") +"')) " +
                    "group by f.[id_factura], f.[fecha_venta], c.nombre_cliente + ' ' + c.apellido_cliente, e.nombre_empleado + ' ' + e.apellido_empleado, tr.[tipo_transaccion]  ,f.isv";
            rep.Carpeta = "Ventas";
            rep.Cabecera = new string[7] { "N° Factura", "Cliente", "Fecha", "Vendedor", "Transaccion", "ISV", "Total" };
            rep.Titulo = titulo;
            rep.Tamanios = new float[] { 2, 6, 2, 6, 2, 1, 2};
            rep.Vertical = false;
            rep.GenerarPdf();
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
