using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Clases
{
    class Cl_Proveedores
    {
        Cl_SqlMaestra sql = new Cl_SqlMaestra();
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

        public void guardar()
        {
            string cadena;
            cadena = "";
            sql.Sql_Querys(cadena, "Categoria añadida con exito", "Debe llenar todos los datos antes de añadir");
        }

        public void consultarDatos(DataGridView dgv)
        {
            dgv.DataSource = sql.Consulta("select *from Proveedores where Estado = 1 and Nombre Like '%"+nombre+"%' order by Nombre asc");
        }

        public void buscarDatos(DataGridView dgv)
        {
            dgv.DataSource = sql.Consulta("select *from Proveedores where Estado = 1 order by Nombre asc");
        }

        public void actualizarDatos()
        {
            string cadena;
            cadena = "";
            sql.Sql_Querys(cadena, "Categoria actulizada con exito", "Debe llenar todos los datos antes de añadir");
        }
    }
}
