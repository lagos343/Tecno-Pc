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

    public partial class frm_clientes : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Clases.Cl_Clientes cli = new Clases.Cl_Clientes();
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();

        public frm_clientes()
        {
            InitializeComponent();
            btn_guardar.Click += btn_guardarGuardado_Click;
            InicializarCombobox();

        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_guardarGuardado_Click(object sender, EventArgs e)
        {
            if (txt_Nombre.Text == "" || txt_Ident.Text == "" || txt_Apell.Text == "" || txt_Tel.Text == "" ||
                txt_Direccion.Text==""|| cmb_Depto.SelectedIndex == -1 )
            {
                frm_notificacion noti = new frm_notificacion("Llene todos los datos", 3);
        noti.ShowDialog();
                noti.Close();
            }
            else
            {
                //cli. = int.Parse(cmb_Depto.SelectedValue.ToString());
               

               
            }
        }
        private void Limnpiado()

{   cmb_Depto.SelectedIndex = -1;
    txt_Ident.Clear();
    txt_id.Clear();
    txt_Nombre.Clear();
    txt_Apell.Clear();
    txt_Tel.Clear();
    txt_Email.Clear();
    txt_Direccion.Clear();
}

public void InicializarCombobox()
        {
            cmb_Depto.DataSource = sql.Consulta("select *from Departamentos order by [Nombre Depto] asc");
            cmb_Depto.DisplayMember = "Nombre Depto";
            cmb_Depto.ValueMember = "ID Depto";

           
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {
           
        }

        private void frm_clientes_Load(object sender, EventArgs e)
        {
            InicializarCombobox();
        }
    }
}
