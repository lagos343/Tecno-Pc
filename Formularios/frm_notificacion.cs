using System;
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
    public partial class frm_notificacion : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr h_wnd, int w_msg, int w_param, int l_param);
        
        private static DialogResult dialog_resul = new DialogResult();
        public DialogResult dialogs_resul { get => dialog_resul; set => dialog_resul = value; }

        public frm_notificacion(string mensaje_notificacion, int estado_notificacion)
        {
            InitializeComponent();
            lbl_Mensaje.Text = mensaje_notificacion;

            if (estado_notificacion == 1)
            {
                btn_confirmar.Visible = true;
                pic_confirmation.Visible = true;
                gunaCircleProgressBar1.Visible = false;
            }

            if(estado_notificacion == 2)
            {
                btn_confirmar.Visible = true;
                btn_cancelar.Visible = true;
                pic_exclamation.Visible = true;
                gunaCircleProgressBar1.Visible = false;
            }

            if (estado_notificacion == 3)
            {
                btn_confirmar.Visible = true;                
                pic_exclamation.Visible = true;
                gunaCircleProgressBar1.Visible = false;
            }

            if (estado_notificacion == 4)
            {               
                pic_exclamation.Visible = true;
                gunaCircleProgressBar1.Visible = true;
                lbl_Mensaje.Visible = false;
            }

            btn_confirmar.Focus();
        }

        public void barra()
        {
            for (int i = 0; i <= 100; i+= 1)
            {
                Thread.Sleep(2);
                gunaCircleProgressBar1.Value = i;
                gunaCircleProgressBar1.Update();

                if (i == 100)
                {
                    i = 0;
                }
            }
        }

        private void btn_confirmar_Click(object sender_confirmar, EventArgs index_e)
        {
            dialogs_resul = DialogResult.OK;
            this.Hide();      
        }

        private void btn_cancelar_Click(object sender_cancelar, EventArgs index_e)
        {            
            dialogs_resul = DialogResult.Cancel;
            this.Hide();
        }

        private void panel1_MouseDown(object sender_panel, MouseEventArgs index_e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        
        private void pic_exclamation_MouseDown(object sender_exclamation, MouseEventArgs index_e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pic_confirmation_MouseDown(object sender_confirmation, MouseEventArgs index_e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private async void frm_notificacion_Load(object sender_notificacion, EventArgs index_e)
        {
            Task task_1 = new Task(barra);
            task_1.Start();
            await task_1;
        }
    }
}
