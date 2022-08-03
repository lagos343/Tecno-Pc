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
        //Importacion de libreias propias de windows para movimiento del formulario  
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr h_wnd, int w_msg, int w_param, int l_param);

        //variable que devuelve el boton que presionamos 
        private static DialogResult dialog_resul = new DialogResult();
        public DialogResult dialogs_resul { get => dialog_resul; set => dialog_resul = value; }

        public frm_notificacion(string mensaje_notificacion, int estado_notificacion) //contructor
        {
            InitializeComponent();
            lbl_Mensaje.Text = mensaje_notificacion;

            if (estado_notificacion == 1) //sirve para confirmaciones positivas
            {
                btn_confirmar.Visible = true;
                pic_confirmation.Visible = true;
                gunaCircleProgressBar1.Visible = false;
            }

            if(estado_notificacion == 2) //sirve para escoger entre hacer o no hacer una operacion
            {
                btn_confirmar.Visible = true;
                btn_cancelar.Visible = true;
                pic_exclamation.Visible = true;
                gunaCircleProgressBar1.Visible = false;
            }

            if (estado_notificacion == 3) //sirve para confirmaciones negativas o errores
            {
                btn_confirmar.Visible = true;                
                pic_exclamation.Visible = true;
                gunaCircleProgressBar1.Visible = false;
            }

            if (estado_notificacion == 4) //sirve para el estado de barra de carga de un procesoq que tarde bastante 
            {               
                pic_exclamation.Visible = true;
                gunaCircleProgressBar1.Visible = true;
                lbl_Mensaje.Visible = false;
            }

            btn_confirmar.Focus();
        }

        public void Barra_Carga() //hace la animacion de la barra de carga
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

        private void btn_confirmar_Click(object sender_confirmar, EventArgs index_e) //boton que devuelve el Resutado OK
        {
            dialogs_resul = DialogResult.OK;
            this.Hide();      
        }

        private void btn_cancelar_Click(object sender_cancelar, EventArgs index_e)//boton que devuelve el Resutado CANCEL
        {            
            dialogs_resul = DialogResult.Cancel;
            this.Hide();
        }

        private void panel1_MouseDown(object sender_panel, MouseEventArgs index_e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //llamado de las librerias ddl para mover el form desde este panel
        }
        
        private void pic_exclamation_MouseDown(object sender_exclamation, MouseEventArgs index_e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //llamado de las librerias ddl para mover el form desde este panel
        }

        private void pic_confirmation_MouseDown(object sender_confirmation, MouseEventArgs index_e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //llamado de las librerias ddl para mover el form desde este panel
        }

        private async void frm_notificacion_Load(object sender_notificacion, EventArgs index_e) //load
        {
            //mostramos de manera asincrona la barra de Carga
            Task task_1 = new Task(Barra_Carga);
            task_1.Start();
            await task_1;            
        }
    }
}
