﻿using System;
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
    public partial class frm_Usuarios : Form
    {
        public frm_Usuarios()
        {
            InitializeComponent();            
        }    

        private void frm_Usuarios_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_nuevoUsuario_Click(object sender, EventArgs e)
        {
            frm_AñadirUsuarios a_usu = new frm_AñadirUsuarios();
            a_usu.ShowDialog();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            frm_clientes cli = new frm_clientes();
            cli.ShowDialog();
        }
    }
}
