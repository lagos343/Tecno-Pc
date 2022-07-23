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
        //Declaracion de la Clases Necesarias para el funcionamiento del form
        Clases.Cl_Reportes rep = new Clases.Cl_Reportes();

        //Importacion de librerias propias de windows para movimiento del formulario 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        

        public frm_ReportVenta()
        {
            InitializeComponent();
            //ayuda mediante tooltip
            this.toolTip1.SetToolTip(this.btn_imprimir, "Crear Reporte");
            
            //inicializacion de los DateTimePicker
            dtp_desde.Enabled = false;
            dtp_hasta.Enabled = false;
            dtp_desde.TextColor = Color.White;
            dtp_hasta.TextColor = Color.White;
            dtp_hasta.Value = DateTime.Now;
            dtp_desde.Value = DateTime.Now.AddMonths(-1);
            dtp_desde.MaxDate = DateTime.Now;
            dtp_hasta.MaxDate = DateTime.Now;
        }

        private async void btn_imprimir_Click(object sender, EventArgs e) //generacion del reporte
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

                Task tar1 = new Task(Reporte_Ventas); //generamos un sub proceso en een base al prod de los reportes
                tar1.Start();
                await tar1;

                noti.Close();
                btn_imprimir.Enabled = true;

                Formularios.frm_principal frm = Application.OpenForms.OfType<Formularios.frm_principal>().SingleOrDefault();
                frm.abrirPdfs(new frm_Facturas()); //abrimos el pdf
                frm.BringToFront();
            }
        }

        private void Reporte_Ventas() //generamos un reporte en base a nuestra eleccion
        { 
            DateTime rango_desde = new DateTime(), rango_hasta = new DateTime();
            string titulo_reporte = "";   

            if (radio_hoy.Checked) //reporte del dia de hoy
            { 
                rep.Fecha = "";
                rango_desde = DateTime.Now;
                rango_hasta = DateTime.Now;
                titulo_reporte = "Reporte de Ventas " + rango_desde.ToString("dd-MM-yyyy");
            }
            else //reporte filrtado por fechas
            {
                rep.Fecha = "";
                rango_desde = dtp_desde.Value;
                rango_hasta = dtp_hasta.Value;
                titulo_reporte = "Reporte de Ventas " + rango_desde.ToString("dd-MM-yyyy") + " hasta " + rango_hasta.ToString("dd-MM-yyyy");
            }    
            
            //mandamos la informacion a la clase de reportes
            rep.Cadena_consulta = "select f.[id_factura], c.nombre_cliente + ' ' + c.apellido_cliente as Cliente, f.[fecha_venta], e.nombre_empleado + ' ' + e.apellido_empleado as Empleado, tr.[tipo_transaccion]  ,f.isv*100 [ISV]," +
                    "sum((df.[precio_historico] * df.cantidad) - (df.[precio_historico] * df.cantidad * df.descuentos)) as [total_venta] from Facturas f " +
                    "inner join DetalleFactura df on df.[id_factura] = f.[id_factura] inner join Clientes c on c.[id_cliente] = f.[id_cliente] " +
                    "inner join Empleados e on e.[id_empleado] = f.[id_empleado] inner join Transacciones tr on tr.[id_transaccion] = f.[id_transaccion] where ((f.[fecha_venta] <= '" + rango_hasta.ToString("yyyy-MM-dd") +"') and (f.[fecha_venta] >= '"
                    +rango_desde.ToString("yyyy-MM-dd") +"')) " +
                    "group by f.[id_factura], f.[fecha_venta], c.nombre_cliente + ' ' + c.apellido_cliente, e.nombre_empleado + ' ' + e.apellido_empleado, tr.[tipo_transaccion]  ,f.isv";
            rep.Carpeta = "Ventas";
            rep.Cabecera = new string[7] { "N° Factura", "Cliente", "Fecha", "Vendedor", "Transaccion", "ISV", "Total" };
            rep.Titulo = titulo_reporte;
            rep.Tamanios = new float[] { 2, 6, 2, 6, 2, 1, 2};
            rep.Vertical = false;
            rep.Generar_pdf(); //generamos el pdf
        }
   
        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //usamos las librerias ddl para mover el formulario desde este panel
        } 

        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void radio_fecha_CheckedChanged(object sender, EventArgs e)
        {
            //activamos los DateTimePicker
            dtp_desde.Enabled = true;
            dtp_hasta.Enabled = true;
            dtp_desde.TextColor = Color.Gray;
            dtp_hasta.TextColor = Color.Gray;
        }

        private void radio_hoy_CheckedChanged(object sender, EventArgs e)
        {
            //desactivamos los DateTimePicker
            dtp_desde.Enabled = false;
            dtp_hasta.Enabled = false;
            dtp_desde.TextColor = Color.White;
            dtp_hasta.TextColor = Color.White;
        }
    }
}
