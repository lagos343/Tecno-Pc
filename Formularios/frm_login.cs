
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc
{
    public partial class Form1 : Form
    {
        Clases.Cl_UsuarioLogueado user_login = new Clases.Cl_UsuarioLogueado();
        Clases.Cl_RecuperarContraseña recu_login = new Clases.Cl_RecuperarContraseña();

        public Form1()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txt_pasword, "Contraseña");
            this.ttMensaje.SetToolTip(this.txt_userName, "Nombre de usuario");
            this.ttMensaje.SetToolTip(this.chk_paswordChar, "Activar/Desactivar vista de la contraseña");
            this.ttMensaje.SetToolTip(this.btn_CerrarLogin, "Salir");
            this.ttMensaje.SetToolTip(this.btn_ingresar, "Ingresar al sistema");

            //Properties.Settings.Default.Servidor = "";
            //Properties.Settings.Default.Save();
        }

        private void btn_CerrarLogin_Click(object sender_cerrar, EventArgs index_e)
        {
            Application.Exit();
        }

        private void chk_paswordChar_CheckedChanged(object sender_password, EventArgs index_e)
        {
            if (chk_paswordChar.Checked == true)
            {
                txt_pasword.UseSystemPasswordChar = false;
            }
            else
            {
                txt_pasword.UseSystemPasswordChar = true;
            }
        }

        private void Form1_Load(object sender_form, EventArgs index_e)
        {
            txt_pasword.UseSystemPasswordChar = true;
        }

        #region Eventos Enter y Leave de los textbox               
        private void txt_userName_Enter(object sender, EventArgs e)
        {
            if (txt_userName.Text == "Usuario")
            {
                txt_userName.Clear();
            }
        }

        private void txt_userName_Leave(object sender, EventArgs e)
        {
            if (txt_userName.Text == "")
            {
                txt_userName.Text = "Usuario";
            }
        }

        private void txt_pasword_Enter(object sender, EventArgs e)
        {
            if (txt_pasword.Text == "Contraseña")
            {
                txt_pasword.Clear();
            }
        }

        private void txt_pasword_Leave(object sender, EventArgs e)
        {
            if (txt_pasword.Text == "")
            {
                txt_pasword.Text = "Contraseña";
            }
        }

        #endregion

        private void lnk_Re_usu_contra_LinkClicked(object sender_contra, LinkLabelLinkClickedEventArgs index_e)
        {
            recu_login.Enviar_correo();
        }

        private void btn_ingresar_Click(object sender_ingresar, EventArgs index_e)
        {
            user_login.Erp_contra = error_contraseña;
            user_login.Erp_usu = error_usuario;
            user_login.Txt_contra = txt_pasword;
            user_login.Txt_usu = txt_userName;
            user_login.Usuario_ = txt_userName.Text;

            if (user_login.ObtenerDatos(lnk_Re_usu_contra) == true)
            {
                this.Hide();
                txt_userName.Text = "Usuario";
                txt_pasword.Text = "Contraseña";
                chk_paswordChar.Checked = false;
                txt_pasword.UseSystemPasswordChar = true;
                lnk_Re_usu_contra.Visible = false;
                Formularios.frm_principal prin_form = new Formularios.frm_principal();
                prin_form.Show();
            }
        }

        private void txt_userName_TextChanged(object sender_user, EventArgs index_e)
        {
            error_usuario.Clear();
        }

        private void txt_pasword_TextChanged(object sender_password, EventArgs index_e)
        {
            error_contraseña.Clear();
        }

        private void txt_pasword_KeyPress(object sender_password, KeyPressEventArgs index_e)
        {
            if (index_e.KeyChar == (char)Keys.Enter)
            {
                btn_ingresar.PerformClick();
            }
        }

        private void gunaButton1_Click(object sender_guna, EventArgs index_e)
        {
            //using (var document = PdfDocument.Load(@"C:\Users\loren\Documents\UNICAH\2022\II Trimestre\Salud y Nutricion\I Parcial\Cuadro Comparativo.pdf"))
            //{
            //    var printerSettings = new PrinterSettings
            //    {
            //        PrinterName = "EPSON L380 Series",
            //        Copies = (short)1,
            //    };

            //    using (var printDocument = document.CreatePrintDocument())
            //    {
            //        printDocument.PrinterSettings = printerSettings;
            //        printDocument.PrintController = new StandardPrintController();
            //        printDocument.Print();
            //    }
            //}
            Clases.Cl_Reportes rep_form = new Clases.Cl_Reportes();
            rep_form.Vertical = true;
            rep_form.Carpeta = "Facturas";
            rep_form.Generar_pdf();
        }
    }
}
