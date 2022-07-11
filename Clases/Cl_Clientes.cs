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
        public String identidad { get => Identidad; set => Identidad = value; }
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
            cadena = "insert into Clientes values (" + iDDepto + ", " + Identidad + ", '" + Nombre + "', '" + Apellido + "', '" + Telefono + "', '"+CorreoElectronico+"','"+Direccion+"', "+ 1 +"  )";
            return Sql_Query(cadena, "Cliente añadido con Exito", "El numero de identidad ya esta en uso, ¡Cambielo!"); //si la sentencia sql devuelve false se repitio el numero de identidad
        }

        public void consultarDatos(DataGridView dgv) //Procedimiento que recibe un datagrid que mostrara los registos del formulario
        {
            dgv.DataSource = Consulta(" select c.[ID Cliente] as ID,c.Nombre ,c.Apellido,c.Identidad,c.Telefono,c.Direccion,c.[Correo Electronico],d.[Nombre Depto] from Clientes as c inner join " +
                "Departamentos as D  on D.[ID Depto] = c.[ID Depto] Where Estado = 1");       
        }

        public void buscarDatos(DataGridView dgv) //Procedimiento paraa las busquedas filtradas
        {
            dgv.DataSource = Consulta("select * from Clientes where Estado=1 and Nombre LIKE '%"+Nombre+"%'");
        }

        public bool actualizarDatos() 
        {
            return Sql_Query("update Clientes set [ID Depto]="+iDDepto+",Identidad='"+Identidad+"',Nombre='"+Nombre+"',Apellido='"+Apellido+"',Telefono='"+Telefono+"',[Correo Electronico]='"
                +CorreoElectronico+"',Direccion='"+Direccion+"' where  [ID Cliente]="+iDCliente+"", "Cliente actualizado con exito", "El numero de identidad ya esta en uso, ¡Cambielo!");
            //si la sentencia sql devuelve false se repitio el numero de identidad
        }

        public void eliminarDatos()
        {
            Sql_Querys("Update Clientes set Estado = 0 where [ID Cliente] = " + iDCliente, "Se ha elminado este Cliente", "El numero de identidad ya esta en uso, ¡Cambielo!");
        }
    }
}

