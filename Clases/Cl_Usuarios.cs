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
        //variables que almacenan la columnas de la tabla de la DB
        private static int id_usuarios;
        private static int id_rol;
        private static int id_empleado;
        private static string nombre_usuario;
        private static string clave_usuarios;
        private static bool estado_usuario;

        #region encapsulamiento
        
        public  int Id_usuarios { get => id_usuarios; set => id_usuarios = value; }
        public  int Id_rol { get => id_rol; set => id_rol = value; }
        public  int Id_empleado { get => id_empleado; set => id_empleado = value; }
        public  string Nombre_usuario { get => nombre_usuario; set => nombre_usuario = value; }
        public  string Clave_Usuario { get => clave_usuarios; set => clave_usuarios = value; }
        public  bool Estado_Usuario { get => estado_usuario; set => estado_usuario = value; }
        #endregion

        //Procedimientos que se heredan de la clase sql para hacer CRUD 
        public bool Guardar_Usuario()
        {
            return Sql_Query("insert into Usuarios values ("+id_rol+", "+Id_empleado+", '"+nombre_usuario+ "', ENCRYPTBYPASSPHRASE('TecnoPc', N'" + Clave_Usuario+"'), "+ Convert.ToInt32(estado_usuario) + ")",
                "Usuario añadido con exito", "¡Este nombre de usuario ya esta ocupado!"); //si devuelve falso significa que ya existe ese usuario
        }
        public void Consultar_Datos(DataGridView dgv) //llena el datagrid con los registros  
        {
            dgv.DataSource = Consulta("select [id_usuario], [id_rol], [id_empleado], [nombre_usuario] [Nombre Usuario], convert(nvarchar, DECRYPTBYPASSPHRASE('TecnoPc' , [clave_usuario])), [estado_usuario], (select nombre_empleado from Empleados  " +
                "where Empleados .[id_empleado] = Usuarios .[id_empleado] ) as Empleado, " +
                "(select [nombre_rol]  from Roles where Roles .id_rol = Usuarios .[id_rol] ) as Rol  from Usuarios where estado_usuario = 1 order by [nombre_usuario] asc");
        }

        public void Buscar_Datos(DataGridView dgv) //hace busquedas iltrradas
        {
            dgv.DataSource = Consulta("select [id_usuario], [id_rol], [id_empleado], [nombre_usuario] [Nombre Usuario], convert(nvarchar, DECRYPTBYPASSPHRASE('TecnoPc' ,[clave_usuario])), [estado_usuario], " +
                "(select nombre_empleado from Empleados  where Empleados .[id_empleado] = Usuarios .[id_empleado] ) " +
                "as Empleado, (select [nombre_rol]  from Roles where Roles .id_rol = Usuarios .[id_rol] ) " +
                "as Rol  from Usuarios where estado_usuario = 1 and [nombre_usuario] like '%"+nombre_usuario+"%' order by [nombre_usuario] asc"); 
        }

        public bool Actualizar_Datos() 
        {
            return Sql_Query("update Usuarios set [id_rol] = "+id_rol+", [id_empleado] = "+Id_empleado+", " +
                "[nombre_usuario] = '"+nombre_usuario+ "', clave_usuario = ENCRYPTBYPASSPHRASE('TecnoPc', N'" + Clave_Usuario+"') where [id_usuario] = "+id_usuarios, 
                "Usuario actualizado con exito", "¡Este nombre de usuario ya esta ocupado!"); //si devuelve falso significa que ya existe ese usuario
        }

        public void Eliminar_Datos()
        {
            Sql_Querys("update Usuarios set estado_usuario = 0 where [id_usuario] ="+id_usuarios);
            Formularios.frm_Usuarios frm = Application.OpenForms.OfType<Formularios.frm_Usuarios>().SingleOrDefault();
            frm.carga();
        }
    }

}
