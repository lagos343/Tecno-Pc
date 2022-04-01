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

        public bool guardar()
        {
            string cadena;
            cadena = "insert into Contactos values (" + iDProveedor + ", " + iDDepto + ", '" + Nombre + "', '" + Apellido + "', '" + Telefono + "', '" + CorreoElectronico + "','" + Direccion + "', " + Convert.ToInt32(estado)+")" ;
            return Sql_Query(cadena, "Contacto añadido con Exito", "El correo electronico ya esta en uso, ¡Cambielo!");
        }

        public void consultarDatos(DataGridView dgv)
        {
            dgv.DataSource = Consulta(" select *, (select [Nombre Depto]  from Departamentos where Departamentos .[ID Depto] = [dbo].[Contactos].[ID Depto] ) as Departametno ,(select [Nombre] " +
                "from [dbo].[Proveedores] where [dbo].[Proveedores].[ID Proveedor]=[dbo].[Contactos].[ID Proveedor]) as Proveedor from Contactos where Estado = 1 order by Nombre asc");
        }

        public void buscarDatos(DataGridView dgv)
        {
            dgv.DataSource = Consulta("	 select *, (select [Nombre Depto]  from Departamentos where Departamentos .[ID Depto] = [dbo].[Contactos].[ID Depto] ) as Departametno ," +
                "(select [Nombre] from [dbo].[Proveedores] where [dbo].[Proveedores].[ID Proveedor]=[dbo].[Contactos].[ID Proveedor]) as Proveedor from Contactos where Nombre Like '%"+Nombre+"%'  " +
                "and Estado = 1  order by Nombre asc");
        }

        public bool actualizarDatos()
        {
            return Sql_Query("update Contactos set  [ID Proveedor]="+ iDProveedor+ ",[ID Depto]=" + iDDepto +  ",Nombre='" + Nombre + "',Apellido='" + Apellido + "',Telefono='" + Telefono + "'," +
                "[Correo Electronico]='" + CorreoElectronico + "',Direccion='" + Direccion + "' where  [ID Contacto]=" + iDContacto + "", "Contacto actualizado con exito", "Error 504");
        }

        public void eliminarDatos()
        {
            Sql_Querys("Update Contactos set Estado = 0 where [ID Contacto ] = " + iDContacto, "Se ha elminado este Contacto", "El correo electronico ya esta en uso, ¡Cambielo!");
        }
    }







}
