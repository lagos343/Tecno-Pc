using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repuestos_Arias.Clases
{
    class Cl_Categorias
    {
        Cl_SqlManaggement sql = new Cl_SqlManaggement();
        private static int id_Categoria;
        private static string nombre_Categoria;
        private static string descripcion_Categoria;      
        private static string descripcion_Categoria2;   

        #region Encapsulamiento
        public int Id_Categoria { get => id_Categoria; set => id_Categoria = value; }
        public string Nombre_Categoria { get => nombre_Categoria; set => nombre_Categoria = value; }
        public string Descripcion_Categoria { get => descripcion_Categoria; set => descripcion_Categoria = value; }
        #endregion

        public void guardar()
        {
            string cadena;
            cadena = "Insert into Categorias (Nombre_Categoria, Descripcion_Categoria) values('" + nombre_Categoria + "', '" + descripcion_Categoria + "')";
            sql.modi_guar_elim(cadena, "Categoria añadida con exito", "Debe llenar todos los datos antes de añadir");
        }

        public void consultarDatos(DataGridView dgv)
        {
            dgv.DataSource = sql.Consulta("select *from Categorias order by Nombre_Categoria asc");
        }

        public void buscarDatos(DataGridView dgv)
        {           
            dgv.DataSource = sql.Consulta("select *from Categorias where Nombre_Categoria Like '%" + nombre_Categoria + "%' order by Nombre_Categoria asc");
        }

        public void actualizarDatos()
        {
            string cadena;
            cadena = "Update Categorias set Nombre_Categoria = '" + nombre_Categoria + "', Descripcion_Categoria = '" + descripcion_Categoria + "' where Id_Categoria = " + id_Categoria + "";
            sql.modi_guar_elim(cadena, "Categoria actulizada con exito", "Debe llenar todos los datos antes de añadir");
        }

        public void eliminarDatos()
        {
            string cadena;
            cadena = "Delete from Categorias where Id_Categoria = " + id_Categoria + "";
            sql.modi_guar_elim(cadena, "Categoria eliminada con exito", "Debe llenar todos los datos antes de añadir");
        }
    }
}
