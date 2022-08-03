using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Clases
{
    class Cl_Marcas: Cl_SqlMaestra
    {
        //variables que almacenan la columnas de la tabla de la DB
        private static int id_marca;
        private static string nombre_marca;

        #region Encapsulamiento

        public int Id_Marca { get => id_marca; set => id_marca = value; }
        public string Nombre_Marca { get => nombre_marca; set => nombre_marca = value; }


        #endregion

        //Procedimientos que se heredan de la clase sql para hacer CRUD 
        public bool Guardar()
        {
            string cadena;
            cadena = "Insert into Marcas values('" + nombre_marca + "')";
            return Sql_Query(cadena, "Marca añadida con exito", "¡Ya existe esta marca!"); //si la sentencia sql devuelve false ya existe este registro
        }

        public void Consultar_Datos(DataGridView dgv) //Procedimiento que recibe un datagrid que mostrara los registos del formulario
        {
            dgv.DataSource = Consulta_Registro("select *from Marcas order by [nombre_marca] asc"); 
        }

        public void Buscar_Datos(DataGridView dgv) //Procedimiento pa las busqueda filtradas 
        {
            dgv.DataSource = Consulta_Registro("select *from Marcas where [nombre_marca] Like '%"+nombre_marca+"%' order by [nombre_marca] asc");
        }

        public bool Actualizar_Datos()
        {
            string cadena;
            cadena = "Update Marcas set [nombre_marca] = '"+nombre_marca+"' where [id_marca] = "+id_marca+"";
            return Sql_Query(cadena, "Marca actulizada con exito", "¡Ya existe esta marca!"); //si la sentencia sql devuelve false ya existe este registro
        }       
    }
}
