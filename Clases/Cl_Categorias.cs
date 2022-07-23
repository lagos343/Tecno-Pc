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
        private static int id_categoria;
        private static string nombre_categoria;

        #region Encapsulamiento0
        public int Id_Categoria { get => id_categoria; set => id_categoria = value; }
        public string Nombre_Categoria { get => nombre_categoria; set => nombre_categoria = value; }

        #endregion

        //Procedimientos que se heredan de la clase sql para hacer CRUD 
        public bool Guardar_Categoria()
        {
            string cadena;
            cadena = "Insert into Categorias values('" + nombre_categoria + "')";
            return Sql_Query(cadena, "Categoria añadida con exito", "¡Ya existe esta categoria!"); //si la sentencia sql devuelve false ya existe este registro
        }

        public void Consultar_Datos(DataGridView dgv) //Procedimiento que recibe un datagrid que mostrara los registos del formulario 
        {
            dgv.DataSource = Consulta("select *from Categorias order by [nombre_categoria] asc");
        }

        public void Buscar_Datos(DataGridView dgv) //Procedimiento pa las busqueda filtradas
        {           
            dgv.DataSource = Consulta("select *from Categorias where [nombre_categoria] Like '%"+nombre_categoria+"%' order by [nombre_categoria] asc");
        }

        public bool Actualizar_Datos() 
        {
            string cadena;
            cadena = "Update Categorias set [nombre_categoria] = '"+nombre_categoria+"' where [id_categoria] = "+id_categoria+"";
            return Sql_Query(cadena, "Categoria actulizada con exito", "¡Ya existe esta categoria!"); //si la sentencia sql devuelve false la infformacion actulizada repite un registro ya existente
        }        
    }
}
