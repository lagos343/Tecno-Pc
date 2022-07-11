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
            dgv.DataSource = Consulta("select *, (select [Nombre Puesto]  from Puestos  where puestos.[ID Puesto] = Empleados .[ID Puesto] ) as Puesto,  (select [Nombre Depto]  from Departamentos where  [ID Depto] = Empleados .[ID Depto]) " +
                "as Departamento from Empleados where estado = 1 order by Nombre asc"); //Procedimiento para llenar el datagrid con los rregistros
        }

        public void buscardatos(DataGridView dgv) //Busquedas filtradas
        {
            dgv.DataSource = Consulta("select *, (select [Nombre Puesto]  from Puestos  where puestos.[ID Puesto] = Empleados .[ID Puesto] ) as Puesto,  (select [Nombre Depto]  from Departamentos where  [ID Depto] = Empleados .[ID Depto]) " +
                "as Departamento from Empleados where estado = 1 and Nombre like '%"+nombre+"%' order by Nombre asc");
        }

        public bool guardar() 
        {
            string cadena;
            cadena = "insert into Empleados values ("+idpuesto +", "+iddepto +", '"+identidad +"', '"+nombre +"','"+apellido +"'," +
                "'"+telefono+"','"+email +"', '"+direccion+"', "+ Convert.ToInt32(estado)+")";
            return Sql_Query(cadena, "Empleado añadido con Exito", "Existen Datos Repetidos, Cambiar Identidad o Correo"); //si retorna falso hay algunos datos repetido como identidad o email
        }

        public bool update()
        {
            return Sql_Query("update Empleados set [ID Puesto] ="+idpuesto+", [ID Depto] ="+iddepto+" ,[Identidad] ='"+identidad+"',[Nombre] ='"+nombre+"',[Apellido] ='"+apellido+"',[Telefono] ='"+telefono+"'," +
                "[Correo Electronico] ='"+email+"',[Direccion] ='"+direccion+"' WHERE [ID Empleado] ="+idempleado+ "",
                "Empleado actualizado con exito", "Existen Datos Repetidos, Cambiar Identidad o Correo");//si retorna falso hay algunos datos repetido como identidad o email
        }

        public void eliminar()
        {
            Sql_Querys("update Empleados set Estado = 0 where [ID Empleado] =" + idempleado, "Se ha elminado al empleado", "Error al eliminar");
            Formularios.frm_empleados frm = Application.OpenForms.OfType<Formularios.frm_empleados>().SingleOrDefault();
            frm.carga();
        }
    }
}
