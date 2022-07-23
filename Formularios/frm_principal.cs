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
        //Importacion de libreias propias de windows para movimiento del formulario  
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //definicion de objetos de las clases necesarias
        Clases.Cl_UsuarioLogueado user = new Clases.Cl_UsuarioLogueado();
        private Form formActivado = null;

        public frm_principal()
        {
            InitializeComponent();
            //definicion de la ayuda visual con tooltip
            Control.CheckForIllegalCrossThreadCalls = false;
            toolTip1.SetToolTip(btn_LogOut, "Cerrar sesion");
            toolTip1.SetToolTip(btn_cerrar, "Salir");
            toolTip1.SetToolTip(gunaPictureBox3, "Minimizar");
            toolTip1.SetToolTip(swt_codbar, "Activar/Desactivar Scanner de Barras");
            toolTip1.SetToolTip(btn_server, "Configuracion inicial");
            toolTip1.SetToolTip(btn_info, "Ver la Ayuda");

            if (Properties.Settings.Default.CodBar == "") //activa o desactiva el switch dependiendo de si esta o no activado el EcanerdeBarra
            {
                Properties.Settings.Default.CodBar = "false";
                Properties.Settings.Default.Save();
            }           
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            //si presionamos OK cerrar el Programa
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
            SendMessage(this.Handle, 0x112, 0xf012, 0); //llamado de las librerias ddl para mover el form desde este panel
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

        public void abrirPdfs(Form form) //se encarga de abrir los pdfs y mostrarlos en el form principal
        {
            AbrirFormulario(new Formularios.frm_pdfs(Properties.Settings.Default.ReporteActual, form));
        } 

        private void SeleccionBoton(Guna.UI.WinForms.GunaGradientButton boton) //resalta el boton seleccionado y devuelve a normal los demas
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

        private void Flecha(Guna.UI.WinForms.GunaGradientButton boton) //posiciona la flecha en el boton seleccionado
        {
            pic_flecha.Top = boton.Top + 242;
        }

        public void AbrirFormulario(Form formHijo) //abre los formularios hijos en el panel 
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
            Carga_Principal();

            if (Properties.Settings.Default.CodBar == "true")
            {
                swt_codbar.Checked = true;
            }
            else
            {
                swt_codbar.Checked = false;
            }
        }                

        private void Carga_Principal()
        {
            lbl_nombreUsuario.Text = user.Propietario_Usuario;

            if (user.Id_Rol == 2)    //Rol Vendedor
            {
                btn_compras.Hide();
                btn_proveedores.Hide();
                btn_empleados.Hide();
            }
            else if (user.Id_Rol == 3)  //Rol Jefe de Compras
            {
                btn_ventas.Hide();
                btn_Facturas.Hide();
                btn_empleados.Hide();
                
            }
            else if (user.Id_Rol == 4)  //Rol Empleador
            {
                btn_Facturas.Hide();
                btn_ventas.Hide();
                btn_Productos.Hide();
                btn_compras.Hide();
                btn_proveedores.Hide();
            }
        }

        private void btn_LogOut_Click(object sender, EventArgs e) //cerrar sesion
        {
            Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea cerrar Sesion?", 2);
            noti.ShowDialog();

            //Si presionamos OK cerrar sesion y nos mandara al login

            if (noti.dialogs_resul == DialogResult.OK)
            {
                noti.Close();
                Form1 frm = Application.OpenForms.OfType<Form1>().SingleOrDefault();
                frm.Show();
                this.Close();
            }                       
        }

        private void swt_codbar_CheckedChanged(object sender, EventArgs e) // activa o desactuva el modo EscanerdeBarras
        {
            //activamos o desactivamos
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

            //de estar en el form de ventas lo recargamos 
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_Ventas);
            if (frm != null)
            {
                btn_ventas.PerformClick();
            }

            //de estar en el form de compras lo recargamos 
            Form frm2 = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_compras);
            if (frm2 != null)
            {
                btn_compras.PerformClick();
            }
        }

        private void btn_server_Click(object sender, EventArgs e) //abre la configuracion de la DB
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

        private async void btn_info_Click(object sender, EventArgs e) //abre la ayuda en html
        {
            btn_info.Enabled = false;
            frm_notificacion noti = new frm_notificacion("", 4);
            noti.Show();

            Task tar1 = new Task(Mostrar_Ayuda); //crea un subproceso en base a el prod de ayuda 
            tar1.Start();
            await tar1;

            noti.Close();
            btn_info.Enabled = true;
        }

        private void Mostrar_Ayuda() //abre el archivo de la ayuda y lo ejecuta 
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
