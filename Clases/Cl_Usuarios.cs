using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Clases
{
    class Cl_Usuarios: Cl_SqlMaestra
    {
        private static int id_usuarios;
        private static int id_rol;
        private static int id_empleado;
        private static string nombre_usuario;
        private static string clave;
        private static bool estado;

        #region encapsulamiento
        
        public  int Id_usuarios { get => id_usuarios; set => id_usuarios = value; }
        public  int Id_rol { get => id_rol; set => id_rol = value; }
        public  int Id_empleado { get => id_empleado; set => id_empleado = value; }
        public  string Nombre_usuario { get => nombre_usuario; set => nombre_usuario = value; }
        public  string Clave { get => clave; set => clave = value; }
        public  bool Estado { get => estado; set => estado = value; }
        #endregion

        public void guardar()
        {
            Sql_Querys("insert into Usuarios values ("+id_rol+", "+Id_empleado+", '"+nombre_usuario+"', '"+Clave+"', "+ Convert.ToInt32(estado) + ")",
                "Usuario añadido con exito", "Debe llenar todos los datos antes de añadir");
        }
        public void consultarDatos(DataGridView dgv)
        {
            dgv.DataSource = Consulta("select *, (select Nombre from Empleados  where Empleados .[ID Empleado] = Usuarios .[ID Empleado] ) as Empleado, " +
                "(select [Nombre Rol]  from Roles where Roles .IDRol = Usuarios .[ID Rol] ) as Rol  from Usuarios where Estado = 1 order by [Nombre Usuario] asc");
        }

        public void buscarDatos(DataGridView dgv)
        {
            dgv.DataSource = Consulta("select *, (select Nombre from Empleados  where Empleados .[ID Empleado] = Usuarios .[ID Empleado] ) " +
                "as Empleado, (select [Nombre Rol]  from Roles where Roles .IDRol = Usuarios .[ID Rol] ) " +
                "as Rol  from Usuarios where Estado = 1 and [Nombre Usuario] like '%"+nombre_usuario+"%' order by [Nombre Usuario] asc");
        }

        public void actualizarDatos()
        {
            Sql_Querys("update Usuarios set [ID Rol] = "+id_rol+", [ID Empleado] = "+Id_empleado+", " +
                "[Nombre Usuario] = '"+nombre_usuario+"', Clave = '"+Clave+"' where [ID Usuario] = "+id_usuarios, 
                "Usuario actualizado con exito", "Debe llenar todos los datos antes de añadir");
        }

        public void eliminar()
        {
            Sql_Querys("update Usuarios set Estado = 0 where [ID Usuario] ="+id_usuarios);
            Formularios.frm_Usuarios frm = Application.OpenForms.OfType<Formularios.frm_Usuarios>().SingleOrDefault();
            frm.carga();
        }
    }

}
