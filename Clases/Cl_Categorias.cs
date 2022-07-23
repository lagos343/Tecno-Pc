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
        //variables que almacenan la columnas de la tabla de la DB
        private static int iDCategoria;
        private static string nombreCategoria;

        #region Encapsulamiento0
        public int IDCategoria { get => iDCategoria; set => iDCategoria = value; }
        public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }

        #endregion

        //Procedimientos que se heredan de la clase sql para hacer CRUD 
        public bool guardar()
        {
            string cadena;
            cadena = "Insert into Categorias values('" + nombreCategoria + "')";
            return Sql_query(cadena, "Categoria añadida con exito", "¡Ya existe esta categoria!"); //si la sentencia sql devuelve false ya existe este registro
        }

        public void consultarDatos(DataGridView dgv) //Procedimiento que recibe un datagrid que mostrara los registos del formulario 
        {
            dgv.DataSource = Consulta_registro("select *from Categorias order by [nombre_categoria] asc");
        }

        public void buscarDatos(DataGridView dgv) //Procedimiento pa las busqueda filtradas
        {           
            dgv.DataSource = Consulta_registro("select *from Categorias where [nombre_categoria] Like '%"+nombreCategoria+"%' order by [nombre_categoria] asc");
        }

        public bool actualizarDatos() 
        {
            string cadena;
            cadena = "Update Categorias set [nombre_categoria] = '"+nombreCategoria+"' where [id_categoria] = "+iDCategoria+"";
            return Sql_query(cadena, "Categoria actulizada con exito", "¡Ya existe esta categoria!"); //si la sentencia sql devuelve false la infformacion actulizada repite un registro ya existente
        }        
    }
}
