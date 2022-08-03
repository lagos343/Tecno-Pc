using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Clases
{
    class Cl_Empleados: Cl_SqlMaestra
    {
        //variables que almacenan la columnas de la tabla de la DB
        private static int id_empleado;
        private static int id_puesto;
        private static int id_depto;
        private static string identidad_empleado;
        private static string nombre_empleado;
        private static string apellido_empleado;
        private static string telefono_empleado;
        private static string email_empleado;
        private static string direccion_empleado;
        private static bool estado_empleado;

        #region Encapsulamiento
        public int Id_Empleado { get => id_empleado; set => id_empleado = value; }
        public int Id_Puesto { get => id_puesto; set => id_puesto = value; }
        public int Id_Depto { get => id_depto; set => id_depto = value; }
        public string Identidad_Empleado { get => identidad_empleado; set => identidad_empleado = value; }
        public string Nombre_Empleado { get => nombre_empleado; set => nombre_empleado = value; }
        public string Apellido_Empleado { get => apellido_empleado; set => apellido_empleado = value; }
        public string Telefono_Empleado { get => telefono_empleado; set => telefono_empleado = value; }
        public string Email_Empleado { get => email_empleado; set => email_empleado = value; }
        public string Direccion_Empleado { get => direccion_empleado; set => direccion_empleado = value; }
        public bool Estado_Empleado { get => estado_empleado; set => estado_empleado = value; }
        #endregion

        //Procedimientos que se heredan de la clase sql para hacer CRUD
        public void Consultar_Datos(DataGridView dgv)
        {
            dgv.DataSource = Consulta_Registro("select *, (select [nombre_puesto]  from Puestos  where puestos.[id_puesto] = Empleados .[id_puesto] ) as Puesto,  (select [nombre_depto]  from Departamentos where  [id_depto] = Empleados .[id_depto]) " +
                "as Departamento from Empleados where estado_empleado = 1 order by nombre_empleado asc"); //Procedimiento para llenar el datagrid con los registros
        }

        public void Buscar_Datos(DataGridView dgv) //Busquedas filtradas
        {
            dgv.DataSource = Consulta_Registro("select *, (select [nombre_puesto]  from Puestos  where puestos.[id_puesto] = Empleados .[id_puesto] ) as Puesto,  (select [nombre_depto]  from Departamentos where  [id_depto] = Empleados .[id_depto]) " +
                "as Departamento from Empleados where estado_empleado = 1 and nombre_empleado like '%" + nombre_empleado+ "%' order by nombre_empleado asc");
        }

        public bool Guardar_Empleado() 
        {
            string cadena;
            cadena = "insert into Empleados values ("+id_puesto +", "+id_depto +", '"+identidad_empleado +"', '"+nombre_empleado +"','"+apellido_empleado +"'," +
                "'"+telefono_empleado+"','"+email_empleado +"', '"+direccion_empleado+"', "+ Convert.ToInt32(estado_empleado)+")";
            return Sql_Query(cadena, "Empleado añadido con Exito", "Existen Datos Repetidos, Cambiar Identidad o Correo"); //si retorna falso hay algunos datos repetido como identidad o email
        }

        public bool Update_Empleado()
        {
            return Sql_Query("update Empleados set [id_puesto] ="+id_puesto+", [id_depto] ="+id_depto+ " ,[identidad_empleado] ='" + identidad_empleado+ "',[nombre_empleado] ='" + nombre_empleado+ "',[apellido_empleado] ='" + apellido_empleado+ "',[telefono_empleado] ='" + telefono_empleado+"'," +
                "[correo_electronico] ='"+email_empleado+ "',[direccion_empleado] ='" + direccion_empleado+"' WHERE [id_empleado] ="+id_empleado+ "",
                "Empleado actualizado con exito", "Existen Datos Repetidos, Cambiar Identidad o Correo");//si retorna falso hay algunos datos repetido como identidad o email
        }

        public void Eliminar_Empleado()
        {
            Sql_Querys("update Empleados set estado_empleado = 0 where [id_empleado] =" + id_empleado, "Se ha elminado al empleado", "Error al eliminar");
            Formularios.frm_empleados frm = Application.OpenForms.OfType<Formularios.frm_empleados>().SingleOrDefault();
            frm.Carga_Empleado();
        }
    }
}
