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
        private static int iDMarca;
        private static string nombreMarca;

        #region Encapsulamiento

        public int IDMarca { get => iDMarca; set => iDMarca = value; }
        public string NombreMarca { get => nombreMarca; set => nombreMarca = value; }


        #endregion

        //Procedimientos que se heredan de la clase sql para hacer CRUD 
        public bool guardar()
        {
            string cadena;
            cadena = "Insert into Marcas values('" + nombreMarca + "')";
            return Sql_query(cadena, "Marca añadida con exito", "¡Ya existe esta marca!"); //si la sentencia sql devuelve false ya existe este registro
        }

        public void consultarDatos(DataGridView dgv) //Procedimiento que recibe un datagrid que mostrara los registos del formulario
        {
            dgv.DataSource = Consulta_registro("select *from Marcas order by [nombre_marca] asc"); 
        }

        public void buscarDatos(DataGridView dgv) //Procedimiento pa las busqueda filtradas 
        {
            dgv.DataSource = Consulta_registro("select *from Marcas where [nombre_marca] Like '%"+nombreMarca+"%' order by [nombre_marca] asc");
        }

        public bool actualizarDatos()
        {
            string cadena;
            cadena = "Update Marcas set [nombre_marca] = '"+nombreMarca+"' where [id_marca] = "+iDMarca+"";
            return Sql_query(cadena, "Marca actulizada con exito", "¡Ya existe esta marca!"); //si la sentencia sql devuelve false ya existe este registro
        }       
    }
}
