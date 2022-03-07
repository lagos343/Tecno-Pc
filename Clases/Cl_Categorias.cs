using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Clases
{
    class Cl_Categorias: Cl_SqlMaestra
    {
        private static int iDCategoria;
        private static string nombreCategoria;

        #region Encapsulamiento

        public int IDCategoria { get => iDCategoria; set => iDCategoria = value; }
        public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }

        #endregion

        public void guardar()
        {
            string cadena;
            cadena = "Insert into Categorias values('" + nombreCategoria + "')";
            Sql_Querys(cadena, "Categoria añadida con exito", "Debe llenar todos los datos antes de añadir");
        }

        public void consultarDatos(DataGridView dgv)
        {
            dgv.DataSource = Consulta("select *from Categorias order by [Nombre Categoria] asc");
        }

        public void buscarDatos(DataGridView dgv)
        {           
            dgv.DataSource = Consulta("select *from Categorias where [Nombre Categoria] Like '%"+nombreCategoria+"%' order by [Nombre Categoria] asc");
        }

        public void actualizarDatos()
        {
            string cadena;
            cadena = "Update Categorias set [Nombre Categoria] = '"+nombreCategoria+"' where [ID Categoria] = "+iDCategoria+"";
            Sql_Querys(cadena, "Categoria actulizada con exito", "Debe llenar todos los datos antes de añadir");
        }        
    }
}
