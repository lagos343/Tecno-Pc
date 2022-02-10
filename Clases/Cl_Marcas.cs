using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repuestos_Arias.Clases
{
    class Cl_Marcas
    {
        Cl_SqlManaggement sql = new Cl_SqlManaggement();
        private static int id_Marca;
        private static string nombre_Marca;
        private static string descripcion_Marca;

        #region Encapsulamiento
        public int Id_Marca { get => id_Marca; set => id_Marca = value; }
        public string Nombre_Marca { get => nombre_Marca; set => nombre_Marca = value; }
        public string Descripcion_Marca { get => descripcion_Marca; set => descripcion_Marca = value; }
        #endregion

        public void guardar()
        {
            string cadena;
            cadena = "Insert into Marcas (Nombre_Marca, Descripcion_Marca) values('" + nombre_Marca + "', '" + descripcion_Marca + "')";
            sql.modi_guar_elim(cadena, "Marca añadida con exito", "Debe llenar todos los datos antes de añadir");
        }

        public void consultarDatos(DataGridView dgv)
        {
            dgv.DataSource = sql.Consulta("select *from Marcas order by Nombre_Marca asc");
        }

        public void buscarDatos(DataGridView dgv)
        {
            dgv.DataSource = sql.Consulta("select *from Marcas where Nombre_Marca Like '%" + nombre_Marca + "%' order by Nombre_Marca asc");
        }

        public void actualizarDatos()
        {
            string cadena;
            cadena = "Update Marcas set Nombre_Marca = '" + nombre_Marca + "', Descripcion_Marca = '" + descripcion_Marca + "' where Id_Marca = " + id_Marca + "";
            sql.modi_guar_elim(cadena, "Marca actulizada con exito", "Debe llenar todos los datos antes de añadir");
        }

        public void eliminarDatos()
        {
            string cadena;
            cadena = "Delete from Marcas where Id_Marca = " + id_Marca + "";
            sql.modi_guar_elim(cadena, "Marca eliminada con exito", "Debe llenar todos los datos antes de añadir");
        }
    }
}
