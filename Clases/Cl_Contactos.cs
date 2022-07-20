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
        private static int iDContacto;
        public static int iDProveedor;
        private static int iDDepto;
        private static string Nombre;
        private static string Apellido;
        private static string Telefono;
        private static string CorreoElectronico;
        private static string Direccion;
        private static bool estado;
        
        #region Encapsulamiento
        public int IDContacto { get => iDContacto; set => iDContacto = value; }
        public int IDProveedor { get => iDProveedor; set => iDProveedor = value; }
        public int IDDepto { get => iDDepto; set => iDDepto = value; }
        public string Nombree { get => Nombre; set => Nombre = value; }
        public string Apellidoo { get => Apellido; set => Apellido = value; }
        public string Telefonoo { get => Telefono; set => Telefono = value; }
        public string CorreoElectronicoo { get => CorreoElectronico; set => CorreoElectronico = value; }
        public string Direccionn { get => Direccion; set => Direccion = value; }
        public bool Estadoo { get => estado; set => estado = value; }
        #endregion

        //Procedimientos que se heredan de la clase sql para hacer CRUD 
        public bool guardar()
        {
            string cadena;
            cadena = "insert into Contactos values (" + iDProveedor + ", " + iDDepto + ", '" + Nombre + "', '" + Apellido + "', '" + Telefono + "', '" + CorreoElectronico + "'," +
                "'" + Direccion + "', " + Convert.ToInt32(estado)+")" ;
            return sql_query(cadena, "Contacto añadido con Exito", "El correo electronico ya esta en uso, ¡Cambielo!"); //si la sentencia sql devuelve false, se ingreo un correo que ya fue registrado
        }

        public void consultarDatos(DataGridView dgv) //Procedimiento que recibe un datagrid que mostrara los registos del formulario
        {
            dgv.DataSource = consulta_registro(" select *, (select [nombre_depto]  from Departamentos where Departamentos .[id_depto] = [dbo].[Contactos].[id_depto] ) as Departamento ,(select [nombre_proveedor] " +
                "from [dbo].[Proveedores] where [dbo].[Proveedores].[id_proveedor]=[dbo].[Contactos].[id_proveedor]) as Proveedor from Contactos where estado_contacto = 1 order by nombre_contacto asc");
        }

        public void buscarDatos(DataGridView dgv) //Procedimiento paraa las busquedas filtradas 
        {
            dgv.DataSource = consulta_registro("	 select *, (select [nombre_depto]  from Departamentos where Departamentos .[id_depto] = [dbo].[Contactos].[id_depto] ) as Departamento ," +
                "(select [nombre_proveedor] from [dbo].[Proveedores] where [dbo].[Proveedores].[id_proveedor]=[dbo].[Contactos].[id_proveedor]) as Proveedor from Contactos where nombre_contacto Like '%"+Nombre+"%'  " +
                "and estado_contacto = 1  order by nombre_contacto asc");
        }

        public bool actualizarDatos()
        {
            return sql_query("update Contactos set  [id_proveedor]="+ iDProveedor+ ",[id_depto]=" + iDDepto +  ",nombre_contacto='" + Nombre + "',apellido_contacto='" + Apellido + "',telefono_contacto='" + Telefono + "'," +
                "[correo_electronico]='" + CorreoElectronico + "',direccion_contacto='" + Direccion + "' where  [id_contacto]=" + iDContacto + "", "Contacto actualizado con exito", 
                "El correo electronico ya esta en uso, ¡Cambielo!"); //si la sentencia sql devuelve false, se ingreo un correo que ya fue registrado
        }

        public void eliminarDatos()
        {
            sql_querys("Update Contactos set estado_contacto = 0 where [id_contacto ] = " + iDContacto, "Se ha elminado este Contacto", "El correo electronico ya esta en uso, ¡Cambielo!");
        }
    }







}
