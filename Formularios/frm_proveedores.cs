using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repuestos_Arias.Formularios
{
    public partial class frm_proveedores : Form
    {
        public frm_proveedores()
        {
            InitializeComponent();
        }

        private void btn_nuevoUsuario_Click(object sender, EventArgs e)
        {
            frm_AñadirProveedores añapro = new frm_AñadirProveedores();
            añapro.Show();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            frm_contactos contac = new frm_contactos();
            contac.Show();
        }
    }
}
