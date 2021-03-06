
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
        Clases.Cl_UsuarioLogueado user = new Clases.Cl_UsuarioLogueado();
        Clases.Cl_RecuperarContraseña recu = new Clases.Cl_RecuperarContraseña();

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

        private void btn_CerrarLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chk_paswordChar_CheckedChanged(object sender, EventArgs e)
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

        private void Form1_Load(object sender, EventArgs e)
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

        private void lnk_Re_usu_contra_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            recu.EnviarCorreo();
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            user.Erp_Contra = error_contraseña;
            user.Erp_Usu = error_usuario;
            user.Txt_Contra = txt_pasword;
            user.Txt_Usu = txt_userName;
            user.Usuario = txt_userName.Text;

            if (user.Obtener_Datos(lnk_Re_usu_contra) == true)
            {
                this.Hide();
                txt_userName.Text = "Usuario";
                txt_pasword.Text = "Contraseña";
                chk_paswordChar.Checked = false;
                txt_pasword.UseSystemPasswordChar = true;
                lnk_Re_usu_contra.Visible = false;
                Formularios.frm_principal prin = new Formularios.frm_principal();
                prin.Show();
            }
        }

        private void txt_userName_TextChanged(object sender, EventArgs e)
        {
            error_usuario.Clear();
        }

        private void txt_pasword_TextChanged(object sender, EventArgs e)
        {
            error_contraseña.Clear();
        }

        private void txt_pasword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_ingresar.PerformClick();
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
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
            Clases.Cl_Reportes rep = new Clases.Cl_Reportes();
            rep.Vertical = true;
            rep.Carpeta = "Facturas";
            rep.GenerarPdf();
        }
    }
}
