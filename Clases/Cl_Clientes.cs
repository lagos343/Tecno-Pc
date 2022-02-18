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


        public void guardar()
        {
            string cadena;
            cadena = "insert into Clientes values (" + iDCliente + ", " + iDDepto + ", " + Identidad + ", '" + Nombre + "', '" + Apellido + "', '" + Telefono + "', '"+CorreoElectronico+"','"+Direccion+"'" + Convert.ToInt32(estado) + ")";
            sql.Sql_Querys(cadena, "Cliente añadido con Exito", "Debe llenar todos los datos antes de añadir");
        }

        public void consultarDatos(DataGridView dgv)
        {
            dgv.DataSource = sql.Consulta(" select c.[ID Cliente] as ID,c.Nombre ,c.Apellido,c.Identidad,c.Telefono,c.Direccion,c.[Correo Electronico],d.[Nombre Depto] from Clientes as c inner join Departamentos as D  on D.[ID Depto] = c.[ID Depto] Where Estado = 1");
        }

        public void buscarDatos(DataGridView dgv)
        {
            dgv.DataSource = sql.Consulta("	select c.[ID Cliente] as ID,c.Nombre ,c.Apellido,c.Identidad,c.Telefono,c.Direccion,c.[Correo Electronico],d.[Nombre Depto] from Clientes as c inner join Departamentos as D  on D.[ID Depto]=c.[ID Depto] Where (c.Nombre Like '%' + '"+ Nombre +"' + '%' )  and Estado=1");
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
