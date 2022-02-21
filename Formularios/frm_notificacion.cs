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
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Variable de Resultado de Dialogo para revisar la confirmacion del ShowDialog
        private static DialogResult dialogresul = new DialogResult();
        public DialogResult Dialogresul { get => dialogresul; set => dialogresul = value; }

        public frm_notificacion(string mensaje, int estado)
        {
            InitializeComponent();
            lbl_Mensaje.Text = mensaje;

            if (estado == 1)
            {
                btn_confirmar.Visible = true;
                pic_confirmation.Visible = true;
                gunaCircleProgressBar1.Visible = false;
            }

            if(estado == 2)
            {
                btn_confirmar.Visible = true;
                btn_cancelar.Visible = true;
                pic_exclamation.Visible = true;
                gunaCircleProgressBar1.Visible = false;
            }

            if (estado == 3)
            {
                btn_confirmar.Visible = true;                
                pic_exclamation.Visible = true;
                gunaCircleProgressBar1.Visible = false;
            }

            if (estado == 4)
            {               
                pic_exclamation.Visible = true;
                gunaCircleProgressBar1.Visible = true;
                lbl_Mensaje.Visible = false;
            }
        }

        public void barra()
        {
            for (int i = 0; i <= 100; i+= 1)
            {
                Thread.Sleep(1);
                gunaCircleProgressBar1.Value = i;
                gunaCircleProgressBar1.Update();

                if (i == 100)
                {
                    i = 0;
                }
            }
        }

        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            Dialogresul = DialogResult.OK;
            this.Hide();      
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {            
            Dialogresul = DialogResult.Cancel;
            this.Hide();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        
        private void pic_exclamation_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pic_confirmation_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private async void frm_notificacion_Load(object sender, EventArgs e)
        {
            Task tas1 = new Task(barra);
            tas1.Start();
            await tas1;
        }
    }
}
