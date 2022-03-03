using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Clases
{
    class Cl_Clientes
    {

        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
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
        public void guardar()
        {
            string cadena;
            cadena = "insert into Clientes values (" + iDDepto + ", " + Identidad + ", '" + Nombre + "', '" + Apellido + "', '" + Telefono + "', '"+CorreoElectronico+"','"+Direccion+"', "+ 1 +"  )";
            sql.Sql_Querys(cadena, "Cliente añadido con Exito", "Debe llenar todos los datos antes de añadir");
        }

        public void consultarDatos(DataGridView dgv)
        {
            dgv.DataSource = sql.Consulta(" select c.[ID Cliente] as ID,c.Nombre ,c.Apellido,c.Identidad,c.Telefono,c.Direccion,c.[Correo Electronico],d.[Nombre Depto] from Clientes as c inner join Departamentos as D  on D.[ID Depto] = c.[ID Depto] Where Estado = 1");
       
        }

        public void buscarDatos(DataGridView dgv)
        {
            dgv.DataSource = sql.Consulta("select * from Clientes where Estado=1 and Nombre LIKE '%"+Nombre+"%'");
        }

        public void actualizarDatos()
        {
            sql.Sql_Querys("update Clientes set [ID Depto]="+iDDepto+",Identidad='"+Identidad+"',Nombre='"+Nombre+"',Apellido='"+Apellido+"',Telefono='"+Telefono+"',[Correo Electronico]='"+CorreoElectronico+"',Direccion='"+Direccion+"' where  [ID Cliente]="+iDCliente+"", "Cliente actualizado con exito", "Error 504");
        }

        public void eliminarDatos()
        {
            sql.Sql_Querys("Update Clientes set Estado = 0 where [ID Cliente] = " + iDCliente, "Se ha elminado este Cliente", "Error al eliminar");
        }

    }
}

