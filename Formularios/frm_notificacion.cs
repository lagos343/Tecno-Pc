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
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        
        //variable que devuelve el boton que presionamos 
        private static DialogResult dialogresul = new DialogResult();
        public DialogResult Dialogresul { get => dialogresul; set => dialogresul = value; }

        public frm_notificacion(string mensaje, int estado) //contructor
        {
            InitializeComponent();
            lbl_Mensaje.Text = mensaje;

            if (estado == 1) //sirve para confirmaciones positivas
            {
                btn_confirmar.Visible = true;
                pic_confirmation.Visible = true;
                gunaCircleProgressBar1.Visible = false;
            }

            if(estado == 2) //sirve para escoger entre hacer o no hacer una operacion
            {
                btn_confirmar.Visible = true;
                btn_cancelar.Visible = true;
                pic_exclamation.Visible = true;
                gunaCircleProgressBar1.Visible = false;
            }

            if (estado == 3) //sirve para confirmaciones negativas o errores
            {
                btn_confirmar.Visible = true;                
                pic_exclamation.Visible = true;
                gunaCircleProgressBar1.Visible = false;
            }

            if (estado == 4) //sirve para el estado de barra de carga de un procesoq que tarde bastante 
            {               
                pic_exclamation.Visible = true;
                gunaCircleProgressBar1.Visible = true;
                lbl_Mensaje.Visible = false;
            }

            btn_confirmar.Focus();
        }

        public void barra() //hace la animacion de la barra de carga
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

        private void btn_confirmar_Click(object sender, EventArgs e) //boton que devuelve el Resutado OK
        {
            Dialogresul = DialogResult.OK;
            this.Hide();      
        }

        private void btn_cancelar_Click(object sender, EventArgs e) //boton que devuelve el Resutado CANCEL
        {            
            Dialogresul = DialogResult.Cancel;
            this.Hide();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //llamado de las librerias ddl para mover el form desde este panel
        }
        
        private void pic_exclamation_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //llamado de las librerias ddl para mover el form desde este panel
        }

        private void pic_confirmation_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //llamado de las librerias ddl para mover el form desde este panel
        }

        private async void frm_notificacion_Load(object sender, EventArgs e) //load
        {
            //mostramos de manera asincrona la barra de Carga
            Task tas1 = new Task(barra);
            tas1.Start();
            await tas1;
        }
    }
}
