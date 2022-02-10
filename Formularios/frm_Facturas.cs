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
    public partial class frm_Facturas : Form
    {
        Clases.Cl_Facturas fac = new Clases.Cl_Facturas();

        public frm_Facturas()
        {
            InitializeComponent();
        }

        private void frm_Facturas_Load(object sender, EventArgs e)
        {
            //fac.consultarDatos(dgv_Facturas);
            //operacionesDatagrid();
            dgv_Facturas.Rows.Add("1", "01-09-2021", "18:48", "Inicio de sesion, Usuario con  Codigo 1");
            dgv_Facturas.Rows.Add("2", "01-10-2021", "17:48", "Registro de productos");
            dgv_Facturas.Rows.Add("3", "01-11-2021", "16:48", "Modificacion de precios");
            dgv_Facturas.Rows.Add("4", "01-12-2021", "15:48", "Deshabilitacion de Usuario Codigo 2");
            dgv_Facturas.Rows.Add("5", "01-01-2022", "14:48", "Cosulta de Facturas");
        }

        private void operacionesDatagrid()
        {            
            dgv_Facturas.Columns[0].Width = 50;
            dgv_Facturas.Columns[1].Width = 80;
            dgv_Facturas.Columns[2].Width = 130;
            dgv_Facturas.Columns[3].Width = 200;
            dgv_Facturas.Columns[4].Width = 250;

            dgv_Facturas.Columns[0].HeaderText = "";
            dgv_Facturas.Columns[1].HeaderText = "No.";
            dgv_Facturas.Columns[2].HeaderText = "Fecha";
            dgv_Facturas.Columns[3].HeaderText = "Cliente";
            dgv_Facturas.Columns[4].HeaderText = "Vendedor";
            dgv_Facturas.Columns[5].HeaderText = "Total";
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            if (cbo_filtro.Text == string.Empty)
            {                
                frm_notificacion noti = new frm_notificacion("Escoja un filtro de Busqueda", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                if (cbo_filtro.Text == "Usuario_Vendedor")
                {
                    fac.buscarDatos(dgv_Facturas, "us.Nombres_Propietario", txt_buscar);
                }
                else
                {
                    fac.buscarDatos(dgv_Facturas, cbo_filtro.Text, txt_buscar);
                }
                
            }
            
        }

        private void dgv_Facturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Facturas.Rows[e.RowIndex].Cells["Mostrar"].Selected)
            {
                frm_reportes rp = new frm_reportes(int.Parse(dgv_Facturas.Rows[e.RowIndex].Cells[1].Value.ToString()), dgv_Facturas.Rows[e.RowIndex].Cells[2].Value.ToString());
                rp.Show();
            }
        }
    }
}
