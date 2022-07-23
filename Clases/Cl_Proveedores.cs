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
        private static int id_Proveedor;
        private static int id_depto;
        private static string nombre_proveedor;
        private static string telefono_proveedor;
        private static string direccion_proveedor;
        private static string correo_electronico;
        private static bool estado_pedido;

        #region Encapsulamiento

        public int IDProveedor { get => id_Proveedor; set => id_Proveedor = value; }
        public int IDDepto { get => id_depto; set => id_depto = value; }
        public string Nombre { get => nombre_proveedor; set => nombre_proveedor = value; }
        public string Telefono { get => telefono_proveedor; set => telefono_proveedor = value; }
        public string Direccion { get => direccion_proveedor; set => direccion_proveedor = value; }
        public string CorreoElectronico { get => correo_electronico; set => correo_electronico = value; }
        public bool Estado { get => estado_pedido; set => estado_pedido = value; }

        #endregion

        //Procedimientos que se heredan de la clase sql para hacer CRUD 
        public bool Guardar_sql()
        {
            return Sql_query("insert into Proveedores values ("+id_depto+", '"+nombre_proveedor+"', '"+telefono_proveedor+"', '"+direccion_proveedor+"', '"+correo_electronico+"', " + Convert.ToInt32(estado_pedido) + ")", 
                "Proveedor añadid con exito", "Existen Datos Repetidos, Cambiar Correo o Nombre"); //si devuelve false el proveedor esta repetido o su correo
        }

        public void Consultar_datos(DataGridView dgv) //llena el datagrid con los registros
        {
            dgv.DataSource = Consulta_registro("select *, (select [nombre_depto]  from Departamentos where Departamentos .[id_depto] = Proveedores .[id_depto] ) as Departamento from Proveedores where " +
                "estado_proveedor = 1 order by nombre_proveedor asc");
        }

        public void Buscar_datos(DataGridView dgv) //busquedas filtradas
        {
            dgv.DataSource = Consulta_registro("select *, (select [nombre_depto]  from Departamentos where Departamentos .[id_depto] = Proveedores .[id_depto] ) as Departamento from Proveedores " +
                "where estado_proveedor = 1 and nombre_proveedor Like '%" + nombre_proveedor+ "%' order by nombre_proveedor asc");
        }

        public bool Actualizar_datos()
        {
            return Sql_query("update Proveedores set [id_depto] ="+id_depto + ", nombre_proveedor = '" + nombre_proveedor+ "', telefono_proveedor = '" + telefono_proveedor+ "', direccion_proveedor = '" + direccion_proveedor+"', [correo_electronico] = '"+correo_electronico+"' " +
                "where[id_proveedor] = "+id_Proveedor, "Categoria actualizada con exito", "Existen Datos Repetidos, Cambiar Correo o Nombre"); //si devuelve false el proveedor esta repetido o su correo
        }

        public void Eliminar_datos()
        {
            Sql_querys("update Proveedores set estado_proveedor = 0 where [id_proveedor] =" + id_Proveedor,"Se ha elminado al proveedor", "Error al eliminar");

            Formularios.frm_proveedores frm = Application.OpenForms.OfType<Formularios.frm_proveedores>().SingleOrDefault();
            frm.Carga_Proveedores();
        }
    }
}
