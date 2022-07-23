using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Formularios 
{
    public partial class frm_principal : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Clases.Cl_UsuarioLogueado user = new Clases.Cl_UsuarioLogueado();
        private Form formActivado = null;

        public frm_principal()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            toolTip1.SetToolTip(btn_LogOut, "Cerrar sesion");
            toolTip1.SetToolTip(btn_cerrar, "Salir");
            toolTip1.SetToolTip(gunaPictureBox3, "Minimizar");
            toolTip1.SetToolTip(swt_codbar, "Activar/Desactivar Scanner de Barras");
            toolTip1.SetToolTip(btn_server, "Configuracion inicial");
            toolTip1.SetToolTip(btn_info, "Ver la Ayuda");

            if (Properties.Settings.Default.CodBar == "")
            {
                Properties.Settings.Default.CodBar = "false";
                Properties.Settings.Default.Save();
            }           
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea Salir de Tecno Pc?", 2);
            noti.ShowDialog();

            if (noti.dialogs_resul == DialogResult.OK)
            {
                Application.Exit();
            }

            noti.Close();            
        }

        private void panel_Header_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #region Procesos de Los botones del menu       
        private void btn_ventas_Click(object sender, EventArgs e)
        {
            SeleccionBoton(btn_ventas);
            AbrirFormulario(new frm_Ventas());
            Flecha((Guna.UI.WinForms.GunaGradientButton)sender);
        }               

        private void btn_Productos_Click(object sender, EventArgs e)
        {
            SeleccionBoton(btn_Productos);
            AbrirFormulario(new frm_productos());
            Flecha((Guna.UI.WinForms.GunaGradientButton)sender);
            
        }

        private void btn_Facturas_Click(object sender, EventArgs e)
        {
            SeleccionBoton(btn_Facturas);
            AbrirFormulario(new frm_Facturas());
            Flecha((Guna.UI.WinForms.GunaGradientButton)sender);
        }

        private void btn_compras_Click(object sender, EventArgs e)
        {
            SeleccionBoton(btn_compras);
            AbrirFormulario(new frm_compras());
            Flecha((Guna.UI.WinForms.GunaGradientButton)sender);
        }

        private void btn_Usuarios_Click(object sender, EventArgs e)
        {
            SeleccionBoton(btn_Usuarios);
            AbrirFormulario(new frm_Usuarios());
            Flecha((Guna.UI.WinForms.GunaGradientButton)sender);
        }

        private void btn_empleados_Click(object sender, EventArgs e)
        {
            SeleccionBoton(btn_empleados);
            AbrirFormulario(new frm_empleados());
            Flecha((Guna.UI.WinForms.GunaGradientButton)sender);
        }

        private void btn_proveedores_Click(object sender, EventArgs e)
        {
            SeleccionBoton(btn_proveedores);
            AbrirFormulario(new frm_proveedores());
            Flecha((Guna.UI.WinForms.GunaGradientButton)sender);
        }

        public void abrirPdfs(Form form)
        {
            AbrirFormulario(new Formularios.frm_pdfs(Properties.Settings.Default.ReporteActual, form));
        } 

        private void SeleccionBoton(Guna.UI.WinForms.GunaGradientButton boton)
        {
            btn_ventas.ForeColor = Color.White; 
            btn_Productos.ForeColor = Color.White;
            btn_Facturas.ForeColor = Color.White;
            btn_compras.ForeColor = Color.White;
            btn_Usuarios.ForeColor = Color.White;
            btn_empleados.ForeColor = Color.White;
            btn_proveedores.ForeColor = Color.White;
            boton.ForeColor = Color.FromArgb(98, 195, 140);
        }

        private void Flecha(Guna.UI.WinForms.GunaGradientButton boton)
        {
            pic_flecha.Top = boton.Top + 242;
        }

        public void AbrirFormulario(Form formHijo)
        {
            if (formActivado != null)
                formActivado.Close();
            formActivado = formHijo;
            formHijo.TopLevel = false;
            formHijo.Dock = DockStyle.Fill;
            panel_container.Controls.Add(formHijo);
            formHijo.BringToFront();
            formHijo.Show();
        }

        #endregion

        private void gunaPictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }               

        private void frm_principal_Load(object sender, EventArgs e)
        {
            carga();

            if (Properties.Settings.Default.CodBar == "true")
            {
                swt_codbar.Checked = true;
            }
            else
            {
                swt_codbar.Checked = false;
            }
        }                

        private void carga()
        {
            lbl_nombreUsuario.Text = user.Propietario_;

            if (user.IdRol_ == 2)    //Rol Vendedor
            {
                btn_compras.Hide();
                btn_proveedores.Hide();
                btn_empleados.Hide();
            }
            else if (user.IdRol_ == 3)  //Rol Jefe de Compras
            {
                btn_ventas.Hide();
                btn_Facturas.Hide();
                btn_empleados.Hide();
                
            }
            else if (user.IdRol_ == 4)  //Rol Empleador
            {
                btn_Facturas.Hide();
                btn_ventas.Hide();
                btn_Productos.Hide();
                btn_compras.Hide();
                btn_proveedores.Hide();
            }
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea cerrar Sesion?", 2);
            noti.ShowDialog();

            if (noti.dialogs_resul == DialogResult.OK)
            {
                noti.Close();
                Form1 frm = Application.OpenForms.OfType<Form1>().SingleOrDefault();
                frm.Show();
                this.Close();
            }                       
        }

        private void swt_codbar_CheckedChanged(object sender, EventArgs e)
        {
            if (swt_codbar.Checked == true)
            {
                Properties.Settings.Default.CodBar = "true";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.CodBar = "false";
                Properties.Settings.Default.Save();
            }

            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_Ventas);
            if (frm != null)
            {
                btn_ventas.PerformClick();
            }

            Form frm2 = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_compras);
            if (frm2 != null)
            {
                btn_compras.PerformClick();
            }
        }

        private void btn_server_Click(object sender, EventArgs e)
        {
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_ConfigurarDB);
            if (frm == null)
            {
                frm_ConfigurarDB db = new frm_ConfigurarDB(true);
                db.Show();
            }
            else
            {
                frm.Show();   
                frm.BringToFront();
            }
        }

        private async void btn_info_Click(object sender, EventArgs e)
        {
            btn_info.Enabled = false;
            frm_notificacion noti = new frm_notificacion("", 4);
            noti.Show();

            Task tar1 = new Task(MostrarAyuda);
            tar1.Start();
            await tar1;

            noti.Close();
            btn_info.Enabled = true;
        }

        private void MostrarAyuda()
        {
            try
            {
                Process.Start("Ayuda al Usuario - Tecno Pc.chm");
            }
            catch (Exception)
            {
                frm_notificacion noti = new frm_notificacion("No se encuentra el Archivo de ayuda (Ayuda al Usuario - Tecno Pc.chm), revise la carpeta raiz", 3);
                noti.ShowDialog();
                noti.Close();
            }            
        }
    }
}
