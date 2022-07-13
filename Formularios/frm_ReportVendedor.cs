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
    public partial class frm_ReportVendedor : Form
    {
        Clases.Cl_Reportes rep = new Clases.Cl_Reportes();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public frm_ReportVendedor()  
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.btn_imprimir, "Crear Reporte");
        }

        private async void btn_imprimir_Click(object sender, EventArgs e)
        {
            if (radio_ventas.Checked == false && radio_gen.Checked == false)
            {
                frm_notificacion noti = new frm_notificacion("Selecione un tipo de reporte", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                btn_imprimir.Enabled = false;
                frm_notificacion noti = new frm_notificacion("", 4);
                noti.Show();

                Task tar1 = new Task(ReporteEmnpleado);
                tar1.Start();
                await tar1;

                noti.Close();
                btn_imprimir.Enabled = true;

                Formularios.frm_principal frm = Application.OpenForms.OfType<Formularios.frm_principal>().SingleOrDefault();
                frm.abrirPdfs(new frm_empleados()); //abrimos el pdf
                frm.BringToFront();                
            }
        }

        private void ReporteEmnpleado()
        {
            if (radio_gen.Checked)
            {
                rep.Cadena_consulta = "SELECT Empleados.Nombre  +' ' + Empleados.Apellido [Empleado], Empleados.Identidad, Empleados.Telefono, Empleados.[Correo Electronico], " +
                    "Departamentos.[Nombre Depto] [Departamento],Empleados.Direccion  FROM     Empleados INNER JOIN Departamentos ON Empleados.[ID Depto] =" +
                    " Departamentos.[ID Depto] WHERE Empleados .Estado = 1 ORDER BY Empleado ASC";
                rep.Cabecera = new string[6] { "Empleado", "Identidad", "Telefono", "Correo Electronico", "Departamento", "Dirección" };
                rep.Tamanios = new float[6] { 6, 4, 2, 5, 4, 8 };
                rep.Titulo = "Reporte de Empleados";
                rep.Carpeta = "Empleados";
                rep.Fecha = DateTime.Now.ToShortDateString();
                rep.Vertical = false;
                rep.GenerarPdf();
            }
            else
            {
                rep.Cadena_consulta = "select (e.Nombre + ' ' + e.Apellido), e.Identidad, Sum(df.[Precio Historico] * df.Cantidad - (df.[Precio Historico] * df.Cantidad * df.Descuentos)) " +
                    "from Facturas f inner join DetalleFactura df on df.[ID Factura] = f.[ID Factura] inner join Empleados e on e.[ID Empleado] = f.[ID Empleado] group by(e.Nombre +' ' + e.Apellido), " +
                    "e.Identidad";
                rep.Cabecera = new string[] { "Empleado", "Identidad", "Total de Ventas" };
                rep.Tamanios = new float[] { 6, 4, 4};
                rep.Titulo = "Reporte de Ventas totales por Empleado";
                rep.Carpeta = "Empleados";
                rep.Fecha = DateTime.Now.ToShortDateString();
                rep.Vertical = true;
                rep.GenerarPdf();
            }
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
    }
}
