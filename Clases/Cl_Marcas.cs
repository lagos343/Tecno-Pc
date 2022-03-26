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
        private static int iDMarca;
        private static string nombreMarca;

        #region Encapsulamiento

        public int IDMarca { get => iDMarca; set => iDMarca = value; }
        public string NombreMarca { get => nombreMarca; set => nombreMarca = value; }


        #endregion

        public bool guardar()
        {
            string cadena;
            cadena = "Insert into Marcas values('" + nombreMarca + "')";
            return Sql_Query(cadena, "Marca añadida con exito", "¡Ya existe esta marca!");
        }

        public void consultarDatos(DataGridView dgv)
        {
            dgv.DataSource = Consulta("select *from Marcas order by [Nombre Marca] asc");
        }

        public void buscarDatos(DataGridView dgv)
        {
            dgv.DataSource = Consulta("select *from Marcas where [Nombre Marca] Like '%"+nombreMarca+"%' order by [Nombre Marca] asc");
        }

        public bool actualizarDatos()
        {
            string cadena;
            cadena = "Update Marcas set [Nombre Marca] = '"+nombreMarca+"' where [ID Marca] = "+iDMarca+"";
            return Sql_Query(cadena, "Marca actulizada con exito", "¡Ya existe esta marca!");
        }       
    }
}
