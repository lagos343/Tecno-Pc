
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
        //llamamos el sub proceso que mostrara la factura
        Clases.Cl_UsuarioLogueado user_login = new Clases.Cl_UsuarioLogueado();
        Clases.Cl_RecuperarContraseña recu_login = new Clases.Cl_RecuperarContraseña();

        public Form1()
        {
            InitializeComponent();
            //definicion de la ayuda visual con tooltip
            this.ttMensaje.SetToolTip(this.txt_pasword, "Contraseña");
            this.ttMensaje.SetToolTip(this.txt_userName, "Nombre de usuario");
            this.ttMensaje.SetToolTip(this.chk_paswordChar, "Activar/Desactivar vista de la contraseña");
            this.ttMensaje.SetToolTip(this.btn_CerrarLogin, "Salir");
            this.ttMensaje.SetToolTip(this.btn_ingresar, "Ingresar al sistema");
        }

        private void btn_CerrarLogin_Click(object sender_cerrar, EventArgs index_e)
        {
            Application.Exit();
        }

        private void chk_paswordChar_CheckedChanged(object sender_password, EventArgs index_e)
        {
            //muestra o no la contraseña dependiendo del estado del Checkbox
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
        //estos eventos dan estetica a los textbox si estan vacios
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

        private void lnk_Re_usu_contra_LinkClicked(object sender_contra, LinkLabelLinkClickedEventArgs index_e) //el linklabel que manda el correo de recuperacion
        {
            recu_login.Enviar_Correo();
        }

        private void btn_ingresar_Click(object sender_ingresar, EventArgs index_e) //se encarga de verificar si se ingresa la sistema o no
        {
            user_login.Erp_Contra = error_contraseña;
            user_login.Erp_Usu = error_usuario;
            user_login.Txt_Contra = txt_pasword;
            user_login.Txt_Usu = txt_userName;
            user_login.Usuario = txt_userName.Text;

            if (user_login.Obtener_Datos(lnk_Re_usu_contra) == true) //si la obtencion de datos es correcta, podremos entrar al sistema
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
    }
}
