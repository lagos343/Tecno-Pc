using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Formularios
{
    public partial class frm_Usuarios : Form
    {

        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Usuarios user = new Clases.Cl_Usuarios();
        Clases.Cl_UsuarioLogueado login = new Clases.Cl_UsuarioLogueado();
        Clases.Cl_Reportes rep = new Clases.Cl_Reportes();
        public frm_Usuarios()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.btn_reporte, "Crear Reporte");
            this.toolTip1.SetToolTip(this.btn_nuevoUsuario, "Agregar Usuario");
            this.toolTip1.SetToolTip(this.gunaGradientButton1, "Gestionar Cliente");
            this.toolTip1.SetToolTip(this.txt_buscar, "Buscar");
        }    

        public void carga()
        {
            user.consultarDatos(dgv_Productos);
            operacionesdgv();
            usuarios();

            foreach(DataGridViewColumn columna in dgv_Productos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        private void frm_Usuarios_Load(object sender, EventArgs e)
        {
            carga();
        }

        private void btn_nuevoUsuario_Click(object sender, EventArgs e)
        {
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_AñadirUsuarios);

            if (frm == null)
            {
                frm_AñadirUsuarios añausu = new frm_AñadirUsuarios(1, dgv_Productos);
                añausu.Show();
            }
            else
            {
                frm.BringToFront();
            }
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_clientes);
            if (frm == null)
            {
                frm_clientes cli = new frm_clientes();
                cli.Show();
            }
            else
            {
                frm.BringToFront();
            }
        }
        private void operacionesdgv()
        {
            dgv_Productos.Columns[2].Visible = false;
            dgv_Productos.Columns[3].Visible = false;
            dgv_Productos.Columns[4].Visible = false;
            dgv_Productos.Columns[6].Visible = false;
            dgv_Productos.Columns[7].Visible = false;
            dgv_Productos.Columns[8].Visible = false;
            dgv_Productos.Columns[9].Visible = false;

            dgv_Productos.Columns[0].Width = 50;
            dgv_Productos.Columns[1].Width = 50;
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            user.Nombre_usuario = txt_buscar.Text;
            user.buscarDatos(dgv_Productos);
            operacionesdgv();
        }

        private void dgv_Productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                if (dgv_Productos.Rows[e.RowIndex].Cells["Editar"].Selected)
                {
                    frm_AñadirUsuarios añaem = new frm_AñadirUsuarios(2, dgv_Productos);
                    añaem.ShowDialog();


                }
                else if (dgv_Productos.Rows[e.RowIndex].Cells["Eliminar"].Selected)
                {
                    Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea eliminar este usuario?", 2);
                    noti.ShowDialog();

                    if (noti.Dialogresul == DialogResult.OK)
                    {
                        user.Id_usuarios = int.Parse(dgv_Productos.CurrentRow.Cells[2].Value.ToString());
                        user.eliminar();

                        #region limpieza
                        lbl_id.Text = "";
                        lbl_contra.Text = "";
                        lbl_propietario.Text = "";
                        lbl_tipo.Text = "";
                        lbl_user.Text = "";
                        #endregion
                    }

                    noti.Close();
                }
                else if (dgv_Productos.Rows[e.RowIndex].Cells["Nombre Usuario"].Selected)
                {
                    lbl_id.Text = dgv_Productos.CurrentRow.Cells[2].Value.ToString();
                    lbl_user.Text = dgv_Productos.CurrentRow.Cells[5].Value.ToString();
                    lbl_contra.Text = dgv_Productos.CurrentRow.Cells[6].Value.ToString().Substring(0, 2) + "**********"; 
                    lbl_propietario.Text = dgv_Productos.CurrentRow.Cells[8].Value.ToString();
                    lbl_tipo.Text = dgv_Productos.CurrentRow.Cells[9].Value.ToString();
                }
            }
            catch(Exception ex) { }
            
        }



        private void usuarios()
        {
            if (login.IdRol_ == 3 || login.IdRol_ == 2)
            {
                btn_nuevoUsuario.Hide();
                dgv_Productos.Hide();
                txt_buscar.Hide();
                pictureBox5.Hide();
                pictureBox6.Hide();
                lbl_id.Text = login.IdRol_.ToString();
                lbl_user.Text = login.Usuario_;
                lbl_contra.Text = login.Contraseña_.Substring(0, 2)+"**********";
                lbl_propietario.Text = login.Propietario_;
                lbl_tipo.Text = login.Rol_;
                btn_reporte.Hide();
            }
            if (login.IdRol_ == 3 || login.IdRol_ == 4)
            {
                gunaGradientButton1.Hide();
            }

        }

        private async void btn_reporte_Click(object sender, EventArgs e)
        {
            btn_reporte.Enabled = false;
            frm_notificacion noti = new frm_notificacion("", 4);
            noti.Show();

            Task tar1 = new Task(ReporteUsuarios);
            tar1.Start();
            await tar1;

            noti.Close();
            btn_reporte.Enabled = true;

            Formularios.frm_principal frm = Application.OpenForms.OfType<Formularios.frm_principal>().SingleOrDefault();
            frm.abrirPdfs(new frm_Usuarios()); //abrimos el pdf
        }

        public void ReporteUsuarios()
        {
            rep.Cadena_consulta = "Select Usuarios.[id_usuario] [Id], Roles.[nombre_rol] [Roles], " +
            "Empleados.nombre_empleado + ' ' + Empleados.apellido_empleado [Empleados], Usuarios.[nombre_usuario] [Nombre] " +
            " from Usuarios " +
            " inner join Roles on Usuarios.[id_rol] = Roles.id_rol inner join " +
            "Empleados on Usuarios.[id_empleado] = Empleados.[id_empleado] " +
            "WHERE Empleados.estado_empleado = 1 ORDER BY nombre_empleado ASC";
            rep.Cabecera = new string[4] { "Id" , "Roles" , "Propietario", "Usuario" };
            rep.Titulo = "Reporte de Usuarios";
            rep.Tamanios = new float[4] { 4, 4, 8, 4 };
            rep.Carpeta = "Usuarios";
            rep.Fecha = DateTime.Now.ToShortDateString();
            rep.Vertical = true;
            rep.generar_pdf();
        }
    }
}
