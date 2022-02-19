using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using objExcel = Microsoft.Office.Interop.Excel;

namespace Tecno_Pc.Formularios
{
    public partial class frm_proveedores : Form
    {

        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Proveedores proveedores = new Clases.Cl_Proveedores();


        public frm_proveedores()
        {
            InitializeComponent();
        }

        private void btn_nuevoUsuario_Click(object sender, EventArgs e)
        {
            frm_AñadirProveedores añapro = new frm_AñadirProveedores(1, dgv_Productos);
            añapro.Show();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            frm_contactos contac = new frm_contactos();
            contac.Show();
        }

        private void frm_proveedores_Load(object sender, EventArgs e)
        {
            proveedores.consultarDatos(dgv_Productos);
            operacionesdatarid();
        }

        private void operacionesdatarid()
        {
            dgv_Productos.Columns[2].Visible = false;
            dgv_Productos.Columns[3].Visible = false;
            dgv_Productos.Columns[5].Visible = false;
            dgv_Productos.Columns[6].Visible = false;
            dgv_Productos.Columns[7].Visible = false;
            dgv_Productos.Columns[8].Visible = false;
            dgv_Productos.Columns[9].Visible = false;

            dgv_Productos.Columns[0].Width = 50;
            dgv_Productos.Columns[1].Width = 50;
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            proveedores.Nombre = txt_buscar.Text;
            proveedores.buscarDatos(dgv_Productos);
            operacionesdatarid();
        }

        private void dgv_Productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Productos.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                frm_AñadirProveedores añaem = new frm_AñadirProveedores(2, dgv_Productos);
                añaem.ShowDialog();


            }
            else if (dgv_Productos.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea eliminar este proveedor?", 2);
                noti.ShowDialog();

                if (noti.Dialogresul == DialogResult.OK)
                {
                    proveedores.IDProveedor = int.Parse(dgv_Productos.CurrentRow.Cells[2].Value.ToString());
                    proveedores.eliminar();
                }

                noti.Close();
            }
            else if (dgv_Productos.Rows[e.RowIndex].Cells["Nombre"].Selected)
            {
                lbl_id.Text = dgv_Productos.CurrentRow.Cells[2].Value.ToString();
                lbl_nombre.Text = dgv_Productos.CurrentRow.Cells[4].Value.ToString();
                lbl_telefono.Text = dgv_Productos.CurrentRow.Cells[5].Value.ToString();
                lbl_direccion.Text = dgv_Productos.CurrentRow.Cells[6].Value.ToString();
                lbl_email.Text = dgv_Productos.CurrentRow.Cells[7].Value.ToString();
                lbl_depto.Text = dgv_Productos.CurrentRow.Cells[9].Value.ToString();

            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            /*Ignorar*/
        }
    }
}
