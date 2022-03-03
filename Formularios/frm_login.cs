using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void btn_CerrarLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chk_paswordChar_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_paswordChar.Checked==true)
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
            txt_userName.Text = "admin";
            txt_pasword.Text = "admonuser1";
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
            user.Erp_contra = error_contraseña;
            user.Erp_usu = error_usuario;
            user.Txt_contra = txt_pasword;
            user.Txt_usu = txt_userName;
            user.Usuario_ = txt_userName.Text;

            if(user.ObtenerDatos(lnk_Re_usu_contra) == true)
            {
                this.Hide();
                txt_userName.Text = "Lagos343";
                txt_pasword.Text = "Manino10";
                chk_paswordChar.Checked = false;
                txt_pasword.UseSystemPasswordChar = true;
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
    }
}
