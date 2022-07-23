using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.clases_formularios
{
    class Cl_Clientes: Cl_SqlMaestra
    {
        //variables que almacenan la columnas de la tabla de la DB
        private static int iDCliente;
        public static int iDDepto;
        private static string Identidad;
        private static string Nombre;
        private static string Apellido;
        private static string Telefono;
        private static string CorreoElectronico;
        private static string Direccion;
        private static bool estado;

        #region Encapsulamiento

        public int IDCliente { get => iDCliente; set => iDCliente = value; }
        public int IDDepto { get => iDDepto; set => iDDepto = value; }
        public string identidad { get => Identidad; set => Identidad = value; }
        public string Nombree { get => Nombre; set => Nombre = value; }
        public string Apellidoo { get => Apellido; set => Apellido = value; }
        public string Telefonoo { get => Telefono; set => Telefono = value; }
        public string CorreoElectronicoo { get => CorreoElectronico; set => CorreoElectronico = value; }
        public string Direccionn { get => Direccion; set => Direccion = value; }
        // public bool Estado { get => estado; set => estado = value; }
        #endregion

        //Procedimientos que se heredan de la clase sql para hacer CRUD 
        public bool guardar()
        {
            string cadena;
            cadena = "insert into Clientes values (" + iDDepto + ", '" + Identidad + "', '" + Nombre + "', '" + Apellido + "', '" + Telefono + "', '"+CorreoElectronico+"','"+Direccion+"', "+ 1 +"  )";
            return Sql_query(cadena, "Cliente añadido con Exito", "El numero de identidad ya esta en uso, ¡Cambielo!"); //si la sentencia sql devuelve false se repitio el numero de identidad
        }

        public void consultarDatos(DataGridView dgv) //Procedimiento que recibe un datagrid que mostrara los registos del formulario
        {
            dgv.DataSource = Consulta_registro(" select c.[id_cliente] as ID,c.nombre_cliente ,c.apellido_cliente,c.identidad_cliente,c.telefono_cliente,c.direccion_cliente,c.[correo_electronico]," +
                "d.[nombre_depto] from Clientes as c inner join Departamentos as d  on d.[id_depto] = c.[id_depto] Where estado_cliente = 1");       
        }

        public void buscarDatos(DataGridView dgv) //Procedimiento paraa las busquedas filtradas
        {
            dgv.DataSource = Consulta_registro("select * from Clientes where estado_cliente=1 and nombre_cliente LIKE '%"+Nombre+"%'");
        }

        public bool actualizarDatos() 
        {
            return Sql_query("update Clientes set [id_depto]="+iDDepto+",identidad_cliente='"+Identidad+ "',nombre_cliente='" + Nombre+ "',apellido_cliente='" + Apellido+ "',telefono_cliente='" + Telefono+"',[correo_electronico]='"
                +CorreoElectronico+ "',direccion_cliente='" + Direccion+"' where  [id_cliente]="+iDCliente+"", "Cliente actualizado con exito", "El numero de identidad ya esta en uso, ¡Cambielo!");
            //si la sentencia sql devuelve false se repitio el numero de identidad
        }

        public void eliminarDatos()
        {
            Sql_querys("Update Clientes set estado_cliente = 0 where [id_cliente] = " + iDCliente, "Se ha elminado este Cliente", "El numero de identidad ya esta en uso, ¡Cambielo!");
        }
    }
}

