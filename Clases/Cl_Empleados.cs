using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.clases_formularios
{
    class Cl_Empleados: Cl_SqlMaestra
    {
        //variables que almacenan la columnas de la tabla de la DB
        private static int idempleado;
        private static int idpuesto;
        private static int iddepto;
        private static string identidad;
        private static string nombre;
        private static string apellido;
        private static string telefono;
        private static string email;
        private static string direccion;
        private static bool estado;

        #region Encapsulamiento
        public int Idempleado { get => idempleado; set => idempleado = value; }
        public int Idpuesto { get => idpuesto; set => idpuesto = value; }
        public int Iddepto { get => iddepto; set => iddepto = value; }
        public string Identidad { get => identidad; set => identidad = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public bool Estado { get => estado; set => estado = value; }
        #endregion

        //Procedimientos que se heredan de la clase sql para hacer CRUD
        public void consultarDatos(DataGridView dgv)
        {
            dgv.DataSource = Consulta_registro("select *, (select [nombre_puesto]  from Puestos  where puestos.[id_puesto] = Empleados .[id_puesto] ) as Puesto,  (select [nombre_depto]  from Departamentos where  [id_depto] = Empleados .[id_depto]) " +
                "as Departamento from Empleados where estado_empleado = 1 order by nombre_empleado asc"); //Procedimiento para llenar el datagrid con los registros
        }

        public void buscardatos(DataGridView dgv) //Busquedas filtradas
        {
            dgv.DataSource = Consulta_registro("select *, (select [nombre_puesto]  from Puestos  where puestos.[id_puesto] = Empleados .[id_puesto] ) as Puesto,  (select [nombre_depto]  from Departamentos where  [id_depto] = Empleados .[id_depto]) " +
                "as Departamento from Empleados where estado_empleado = 1 and nombre_empleado like '%" + nombre+ "%' order by nombre_empleado asc");
        }

        public bool guardar() 
        {
            string cadena;
            cadena = "insert into Empleados values ("+idpuesto +", "+iddepto +", '"+identidad +"', '"+nombre +"','"+apellido +"'," +
                "'"+telefono+"','"+email +"', '"+direccion+"', "+ Convert.ToInt32(estado)+")";
            return Sql_query(cadena, "Empleado añadido con Exito", "Existen Datos Repetidos, Cambiar Identidad o Correo"); //si retorna falso hay algunos datos repetido como identidad o email
        }

        public bool update()
        {
            return Sql_query("update Empleados set [id_puesto] ="+idpuesto+", [id_depto] ="+iddepto+ " ,[identidad_empleado] ='" + identidad+ "',[nombre_empleado] ='" + nombre+ "',[apellido_empleado] ='" + apellido+ "',[telefono_empleado] ='" + telefono+"'," +
                "[correo_electronico] ='"+email+ "',[direccion_empleado] ='" + direccion+"' WHERE [id_empleado] ="+idempleado+ "",
                "Empleado actualizado con exito", "Existen Datos Repetidos, Cambiar Identidad o Correo");//si retorna falso hay algunos datos repetido como identidad o email
        }

        public void eliminar()
        {
            Sql_querys("update Empleados set estado_empleado = 0 where [id_empleado] =" + idempleado, "Se ha elminado al empleado", "Error al eliminar");
            Formularios.frm_empleados frm = Application.OpenForms.OfType<Formularios.frm_empleados>().SingleOrDefault();
            frm.Carga_empleado();
        }
    }
}
