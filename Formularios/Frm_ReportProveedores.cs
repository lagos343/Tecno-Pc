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
    public partial class Frm_ReportProveedores : Form
    {
        bool ReporteGenerado = false;
        Clases.Cl_Reportes rep = new Clases.Cl_Reportes();
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        public Frm_ReportProveedores()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.btn_imprimir, "Crear Reporte");

            cbo_proveedor.DataSource = sql.Consulta("select *from Proveedores where Estado = 1 order by Nombre asc");
            cbo_proveedor.DisplayMember = "Nombre";
            cbo_proveedor.ValueMember = "ID Proveedor";
            cbo_proveedor.SelectedIndex = -1;
        }

        private async void btn_imprimir_Click(object sender, EventArgs e)
        {
            if (radio_filtrado.Checked == false && radio_gen.Checked == false)
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

                Task tar1 = new Task(ReporteProveedor);
                tar1.Start();
                await tar1;

                noti.Close();
                btn_imprimir.Enabled = true;

                if (ReporteGenerado)
                {
                    Formularios.frm_principal frm = Application.OpenForms.OfType<Formularios.frm_principal>().SingleOrDefault();
                    frm.abrirPdfs(new frm_proveedores()); //abrimos el pdf
                    frm.BringToFront();
                    ReporteGenerado = false;
                }                
            }
        }

        private void ReporteProveedor()
        {
            if (radio_gen.Checked)
            {
                rep.Cadena_consulta = "SELECT Proveedores.Nombre, Proveedores.Telefono,Departamentos.[Nombre Depto] [Departamento], Proveedores.Direccion, Proveedores.[Correo Electronico] FROM    " +
                " Proveedores INNER JOIN  Departamentos ON Proveedores.[ID Depto] = Departamentos.[ID Depto]" +
                " WHERE Proveedores.Estado = 1 ORDER BY Nombre asc";
                rep.Cabecera = new string[5] { "Proveedor", "Telefono", "Departamento", "Direccion", "Email" };
                rep.Titulo = "Reporte de Proveedores";
                rep.Tamanios = new float[5] { 6, 3, 5, 9, 5 };
                rep.Carpeta = "Proveedores";
                rep.Fecha = DateTime.Now.ToShortDateString();
                rep.Vertical = false;
                rep.GenerarPdf();
                ReporteGenerado = true;
            }
            else
            {
                if (cbo_proveedor.SelectedIndex != -1)
                {
                    rep.Cadena_consulta = "select p.[Nombre Producto], p.Modelo, CAST(p.[Precio Unitario] AS decimal(9,2)), c.[Nombre Categoria], m.[Nombre Marca], pr.Nombre, " +
                    "(select Stock from Inventarios Where [ID Producto] = p.[ID Producto]) as Stock, CodBarra from Productos p " +
                    "inner join Categorias c on c.[ID Categoria] = p.[ID Categoria] inner join Marcas m on m.[ID Marca] = p.[ID Marca] inner join Proveedores pr on " +
                    "pr.[ID Proveedor] = p.[ID Proveedor] where p.Estado = 1 and p.[ID Proveedor] = " + cbo_proveedor.SelectedValue;
                    rep.Cabecera = new string[8] { "Producto", "Modelo", "Precio", "Categoria", "Marca", "Proveedor", "Stock", "Codigo de Barras" };
                    rep.Titulo = "Reporte de Productos de " + cbo_proveedor.Text;
                    rep.Tamanios = new float[8] { 6, 4, 3, 4, 4, 6, 2, 4 };
                    rep.Carpeta = "Productos";
                    rep.Fecha = DateTime.Now.ToShortDateString();
                    rep.Vertical = false;
                    rep.GenerarPdf();
                    ReporteGenerado = true;
                }
                else
                {
                    frm_notificacion noti = new frm_notificacion("Selecione un Proveedor", 3);
                    noti.ShowDialog();
                    noti.Close();
                }                
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

        private void radio_gen_CheckedChanged(object sender, EventArgs e)
        {
            cbo_proveedor.Enabled = false;
        }

        private void radio_filtrado_CheckedChanged(object sender, EventArgs e)
        {
            cbo_proveedor.Enabled = true;
        }
    }
}
