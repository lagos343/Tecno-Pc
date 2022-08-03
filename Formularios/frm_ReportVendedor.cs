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
        //Declaracion de la Clases Necesarias para el funcionamiento del form
        Clases.Cl_Reportes rep = new Clases.Cl_Reportes();

        //Importacion de librerias propias de windows para movimiento del formulario  
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public frm_ReportVendedor()  
        {
            InitializeComponent();
            //ayuda mediante tooltip
            this.toolTip1.SetToolTip(this.btn_imprimir, "Crear Reporte");
        }

        private async void btn_imprimir_Click(object sender, EventArgs e) //generacion del reporte
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

                Task tar1 = new Task(Reporte_Empleado); //generamos un sub proceso en een base al prod de los reportes
                tar1.Start();
                await tar1;

                noti.Close();
                btn_imprimir.Enabled = true;

                Formularios.frm_principal frm = Application.OpenForms.OfType<Formularios.frm_principal>().SingleOrDefault();
                frm.Abrir_Pdfs(new frm_empleados()); //abrimos el pdf
                frm.BringToFront();                
            }
        }

        private void Reporte_Empleado() //genera un reporte en base a la seleccion que hayamos hecho
        {
            if (radio_gen.Checked) //reporte general de empleados
            {
                rep.Cadena_consulta = "SELECT Empleados.nombre_empleado  +' ' + Empleados.apellido_empleado [Empleado], Empleados.identidad_empleado, Empleados.telefono_empleado, Empleados.[correo_electronico], " +
                    "Departamentos.[nombre_depto] [Departamento],Empleados.direccion_empleado  FROM     Empleados INNER JOIN Departamentos ON Empleados.[id_depto] =" +
                    " Departamentos.[id_depto] WHERE Empleados .estado_empleado = 1 ORDER BY Empleado ASC";
                rep.Cabecera = new string[6] { "Empleado", "Identidad", "Telefono", "Correo Electronico", "Departamento", "Dirección" };
                rep.Tamanios = new float[6] { 6, 4, 2, 5, 4, 8 };
                rep.Titulo = "Reporte de Empleados";
                rep.Carpeta = "Empleados";
                rep.Fecha = DateTime.Now.ToShortDateString();
                rep.Vertical = false;
                rep.Generar_Pdf();
            }
            else
            {
                //genera un reporte de de ventas totales por empleado
                rep.Cadena_consulta = "select (e.nombre_empleado + ' ' + e.apellido_empleado), e.identidad_empleado, Sum(df.[precio_historico] * df.cantidad - (df.[precio_historico] * df.cantidad * df.descuentos)) " +
                    "from Facturas f inner join DetalleFactura df on df.[id_factura] = f.[id_factura] inner join Empleados e on e.[id_empleado] = f.[id_empleado] group by(e.nombre_empleado +' ' + e.apellido_empleado), " +
                    "e.identidad_empleado";
                rep.Cabecera = new string[] { "Empleado", "Identidad", "Total de Ventas" };
                rep.Tamanios = new float[] { 6, 4, 4};
                rep.Titulo = "Reporte de Ventas totales por Empleado";
                rep.Carpeta = "Empleados";
                rep.Fecha = DateTime.Now.ToShortDateString();
                rep.Vertical = true;
                rep.Generar_Pdf();
            }
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
    }
}
