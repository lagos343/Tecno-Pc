﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea Salir de Tecno Pc?", 2);
            noti.ShowDialog();

            if (noti.Dialogresul == DialogResult.OK)
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

        private void AbrirFormulario(Form formHijo)
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

        private void pic_flecha_Click(object sender, EventArgs e)
        {

        }

        private void frm_principal_Load(object sender, EventArgs e)
        {
            carga();                             
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            
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

            if (noti.Dialogresul == DialogResult.OK)
            {
                noti.Close();
                Form1 frm = Application.OpenForms.OfType<Form1>().SingleOrDefault();
                frm.Show();
                this.Close();
            }                       
        }
    }
}
