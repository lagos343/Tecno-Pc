using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Clases
{
    class Cl_Proveedores: Cl_SqlMaestra
    {
        //variables que almacenan la columnas de la tabla de la DB
        private static int iDProveedor;
        private static int iDDepto;
        private static string nombre;
        private static string telefono;
        private static string direccion;
        private static string correoElectronico;
        private static bool estado;

        #region Encapsulamiento

        public int IDProveedor { get => iDProveedor; set => iDProveedor = value; }
        public int IDDepto { get => iDDepto; set => iDDepto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }
        public bool Estado { get => estado; set => estado = value; }

        #endregion

        //Procedimientos que se heredan de la clase sql para hacer CRUD 
        public bool guardar()
        {
            return Sql_Query("insert into Proveedores values ("+iDDepto+", '"+nombre+"', '"+telefono+"', '"+direccion+"', '"+correoElectronico+"', " + Convert.ToInt32(estado) + ")", 
                "Proveedor añadid con exito", "Existen Datos Repetidos, Cambiar Correo o Nombre"); //si devuelve false el proveedor esta repetido o su correo
        }

        public void consultarDatos(DataGridView dgv) //llena el datagrid con los registros
        {
            dgv.DataSource = Consulta("select *, (select [nombre_depto]  from Departamentos where Departamentos .[id_depto] = Proveedores .[id_depto] ) as Departamento from Proveedores where " +
                "estado_proveedor = 1 order by nombre_proveedor asc");
        }

        public void buscarDatos(DataGridView dgv) //busquedas filtradas
        {
            dgv.DataSource = Consulta("select *, (select [nombre_depto]  from Departamentos where Departamentos .[id_depto] = Proveedores .[id_depto] ) as Departamento from Proveedores " +
                "where estado_proveedor = 1 and nombre_proveedor Like '%" + nombre+ "%' order by nombre_proveedor asc");
        }

        public bool actualizarDatos()
        {
            return Sql_Query("update Proveedores set [id_depto] ="+iDDepto + ", nombre_proveedor = '" + nombre+ "', telefono_proveedor = '" + telefono+ "', direccion_proveedor = '" + direccion+"', [correo_electronico] = '"+correoElectronico+"' " +
                "where[id_proveedor] = "+iDProveedor, "Categoria actualizada con exito", "Existen Datos Repetidos, Cambiar Correo o Nombre"); //si devuelve false el proveedor esta repetido o su correo
        }

        public void eliminar()
        {
            Sql_Querys("update Proveedores set estado_proveedor = 0 where [id_proveedor] =" + iDProveedor,"Se ha elminado al proveedor", "Error al eliminar");

            Formularios.frm_proveedores frm = Application.OpenForms.OfType<Formularios.frm_proveedores>().SingleOrDefault();
            frm.Carga_Proveedores();
        }
    }
}
