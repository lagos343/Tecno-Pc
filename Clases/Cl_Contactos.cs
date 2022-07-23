using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Clases
{ 
    class Cl_Contactos: Cl_SqlMaestra
    {
        //variables que almacenan la columnas de la tabla de la DB
        private static int id_contacto;
        public static int id_proveedor;
        private static int id_depto;
        private static string nombre_contacto;
        private static string apellido_contacto;
        private static string telefono_contacto;
        private static string correo_electronico;
        private static string direccion_contacto;
        private static bool estado_contacto;
        
        #region Encapsulamiento
        public int Id_Contacto { get => id_contacto; set => id_contacto = value; }
        public int Id_Proveedor { get => id_proveedor; set => id_proveedor = value; }
        public int Id_Depto { get => id_depto; set => id_depto = value; }
        public string Nombre_Contacto { get => nombre_contacto; set => nombre_contacto = value; }
        public string Apellido_Contacto { get => apellido_contacto; set => apellido_contacto = value; }
        public string Telefono_Contacto { get => telefono_contacto; set => telefono_contacto = value; }
        public string Correo_Electronico { get => correo_electronico; set => correo_electronico = value; }
        public string Direccion_Contacto { get => direccion_contacto; set => direccion_contacto = value; }
        public bool Estado_Contacto { get => estado_contacto; set => estado_contacto = value; }
        #endregion

        //Procedimientos que se heredan de la clase sql para hacer CRUD 
        public bool Guardar_Contacto()
        {
            string cadena;
            cadena = "insert into Contactos values (" + id_proveedor + ", " + id_depto + ", '" + nombre_contacto + "', '" + apellido_contacto + "', '" + telefono_contacto + "', '" + correo_electronico + "'," +
                "'" + direccion_contacto + "', " + Convert.ToInt32(estado_contacto)+")" ;
            return Sql_query(cadena, "Contacto añadido con Exito", "El correo electronico ya esta en uso, ¡Cambielo!"); //si la sentencia sql devuelve false, se ingreo un correo que ya fue registrado
        }

        public void Consultar_Datos(DataGridView dgv) //Procedimiento que recibe un datagrid que mostrara los registos del formulario
        {
            dgv.DataSource = Consulta_registro(" select *, (select [nombre_depto]  from Departamentos where Departamentos .[id_depto] = [dbo].[Contactos].[id_depto] ) as Departamento ,(select [nombre_proveedor] " +
                "from [dbo].[Proveedores] where [dbo].[Proveedores].[id_proveedor]=[dbo].[Contactos].[id_proveedor]) as Proveedor from Contactos where estado_contacto = 1 order by nombre_contacto asc");
        }

        public void Buscar_Datos(DataGridView dgv) //Procedimiento paraa las busquedas filtradas 
        {
            dgv.DataSource = Consulta_registro("	 select *, (select [nombre_depto]  from Departamentos where Departamentos .[id_depto] = [dbo].[Contactos].[id_depto] ) as Departamento ," +
                "(select [nombre_proveedor] from [dbo].[Proveedores] where [dbo].[Proveedores].[id_proveedor]=[dbo].[Contactos].[id_proveedor]) as Proveedor from Contactos where nombre_contacto Like '%"+nombre_contacto+"%'  " +
                "and estado_contacto = 1  order by nombre_contacto asc");
        }

        public bool Actualizar_Datos()
        {
            return Sql_query("update Contactos set  [id_proveedor]="+ id_proveedor+ ",[id_depto]=" + id_depto +  ",nombre_contacto='" + nombre_contacto + "',apellido_contacto='" + apellido_contacto + "',telefono_contacto='" + telefono_contacto + "'," +
                "[correo_electronico]='" + correo_electronico + "',direccion_contacto='" + direccion_contacto + "' where  [id_contacto]=" + id_contacto + "", "Contacto actualizado con exito", 
                "El correo electronico ya esta en uso, ¡Cambielo!"); //si la sentencia sql devuelve false, se ingreo un correo que ya fue registrado
        }

        public void Eliminar_Datos()
        {
            Sql_querys("Update Contactos set estado_contacto = 0 where [id_contacto ] = " + id_contacto, "Se ha elminado este Contacto", "El correo electronico ya esta en uso, ¡Cambielo!");
        }
    }







}
