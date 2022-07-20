using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Tecno_Pc.Formularios
{
    public partial class frm_sar : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();

        public frm_sar()
        {
            InitializeComponent();
            dtp_limite.MinDate = DateTime.Now.AddMonths(1);
            dtp_limite.Value = DateTime.Now.AddMonths(1);
            toolTip1.SetToolTip(btn_guardar, "Guardar nuevo rango de facturacion");
            lbl_desde.Text = (long.Parse(sql.consulta2_registro("select top 1 id_factura from Facturas order by id_factura desc")) + 1).ToString();
            txt_hasta.Focus();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txt_hasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_hasta.Text == "")
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¡Llene el Rango Final!", 1);
                noti.ShowDialog();
                noti.Close();                
            }
            else if (long.Parse(txt_hasta.Text) <= long.Parse(lbl_desde.Text)) 
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¡El Rango Final debe ser mayor al Rango Inicial!", 1);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Esta seguro del Rango Ingresado, desea Guardarlo?", 2);
                noti.ShowDialog();

                if (noti.Dialogresul == DialogResult.OK)
                {
                    sql.sql_querys("insert into Sar values("+lbl_desde.Text+", "+txt_hasta.Text+",'"+ dtp_limite.Value.ToString("yyyy-MM-dd") + "')", 
                        "El nuevo rango de Facturacion se guardo con exito", "Error al guarar");
                    this.Close();
                }

                noti.Close();
            }
        }
    }
}
