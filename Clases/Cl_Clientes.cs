using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Clases
{
    class Cl_Clientes: Cl_SqlMaestra
    {
        //variables que almacenan la columnas de la tabla de la DB
        private static int id_cliente;
        public static int id_depto;
        private static string identidad_cliente;
        private static string nombre_cliente;
        private static string apellido_cliente;
        private static string telefono_cliente;
        private static string correo_electronico;
        private static string direccion_cliente;
        private static bool estado_cliente;

        #region Encapsulamiento

        public int Id_Cliente { get => id_cliente; set => id_cliente = value; }
        public int Id_Depto { get => id_depto; set => id_depto = value; }
        public string identidad_Cliente { get => identidad_cliente; set => identidad_cliente = value; }
        public string Nombre_Cliente { get => nombre_cliente; set => nombre_cliente = value; }
        public string Apellido_Cliente { get => apellido_cliente; set => apellido_cliente = value; }
        public string Telefono_Cliente { get => telefono_cliente; set => telefono_cliente = value; }
        public string Correo_Electronico { get => correo_electronico; set => correo_electronico = value; }
        public string Direccion_Cliente { get => direccion_cliente; set => direccion_cliente = value; }
        // public bool Estado { get => estado; set => estado = value; }
        #endregion

        //Procedimientos que se heredan de la clase sql para hacer CRUD 
        public bool Guardar_Cliente()
        {
            string cadena;
            cadena = "insert into Clientes values (" + id_depto + ", '" + identidad_cliente + "', '" + nombre_cliente + "', '" + apellido_cliente + "', '" + telefono_cliente + "', '"+correo_electronico+"','"+direccion_cliente+"', "+ 1 +"  )";
            return Sql_query(cadena, "Cliente añadido con Exito", "El numero de identidad ya esta en uso, ¡Cambielo!"); //si la sentencia sql devuelve false se repitio el numero de identidad
        }

        public void Consultar_Datos(DataGridView dgv) //Procedimiento que recibe un datagrid que mostrara los registos del formulario
        {
            dgv.DataSource = Consulta_registro(" select c.[id_cliente] as ID,c.nombre_cliente ,c.apellido_cliente,c.identidad_cliente,c.telefono_cliente,c.direccion_cliente,c.[correo_electronico]," +
                "d.[nombre_depto] from Clientes as c inner join Departamentos as d  on d.[id_depto] = c.[id_depto] Where estado_cliente = 1");       
        }

        public void Buscar_Datos(DataGridView dgv) //Procedimiento paraa las busquedas filtradas
        {            
            dgv.DataSource = Consulta_registro("select * from Clientes where estado_cliente=1 and nombre_cliente LIKE '%"+nombre_cliente+"%'");
        }

        public bool Actualizar_Datos() 
        {
            return Sql_query("update Clientes set [id_depto]="+id_depto+",identidad_cliente='"+identidad_cliente+ "',nombre_cliente='" + nombre_cliente+ "',apellido_cliente='" + apellido_cliente+ "',telefono_cliente='" + telefono_cliente+"',[correo_electronico]='"
                +correo_electronico+ "',direccion_cliente='" + direccion_cliente+"' where  [id_cliente]="+id_cliente+"", "Cliente actualizado con exito", "El numero de identidad ya esta en uso, ¡Cambielo!");
            //si la sentencia sql devuelve false se repitio el numero de identidad
        }

        public void Eliminar_Datos()
        {
            Sql_querys("Update Clientes set estado_cliente = 0 where [id_cliente] = " + id_cliente, "Se ha elminado este Cliente", "El numero de identidad ya esta en uso, ¡Cambielo!");
        }
    }
}

