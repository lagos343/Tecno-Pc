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
    public partial class frm_Usuarios : Form
    {
        public frm_Usuarios()
        {
            InitializeComponent();
            Clases.Cl_UsuarioLogueado user = new Clases.Cl_UsuarioLogueado();
            lbl_user.Text = user.Nombre_usuario;
            lbl_id.Text = user.Id_usuario.ToString();
            lbl_contra.Text = user.Contraseña_usuario.Substring(0, 2) + "*******";
            lbl_propietario.Text = user.Nombres_propietario + " " + user.Apellidos_propietarios;
            lbl_email.Text = user.Correo_usuario;
            lbl_tel.Text = user.Telefono;
            lbl_tipo.Text = user.Tipo_usuario;
        }    

        private void frm_Usuarios_Load(object sender, EventArgs e)
        {
            Clases.Cl_SqlManaggement sql = new Clases.Cl_SqlManaggement();
            dgv_Productos.DataSource = sql.Consulta("Select us.Id_Usuario as [Id], us.Nombre_Usuario as [Usuario], (us.Nombres_Propietario + ' ' + us.Apellidos_Propietario) as [Propietario], " +
                "us.Correo_Usuario as [Correo], tu.Descripcion_TipoUsuario as [Tipo Usuario] from Usuarios us inner join TipoUsuario tu on tu.Id_TipoUsuario = us.Id_TipoUsuario");
            dgv_Productos.Columns[0].Width = 60;
            dgv_Productos.Columns[1].Width = 60;
            dgv_Productos.Columns[2].Width = 60;
            dgv_Productos.Columns[3].Width = 150;
            dgv_Productos.Columns[6].Width = 110;
        }

        private void btn_nuevoUsuario_Click(object sender, EventArgs e)
        {
            frm_AñadirUsuarios a_usu = new frm_AñadirUsuarios();
            a_usu.ShowDialog();
        }
    }
}
