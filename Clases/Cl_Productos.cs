﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Clases
{
    class Cl_Productos
    {
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        private static int iDProducto;
        private static int iDCategoria;
        private static int iDMarca;
        private static int iDProveedor;
        private static string nombreProducto; 
        private static string modelo;
        private static double precioUnitario;
        private static bool estado;


        #region Encapsulamiento

        public int IDProducto { get => iDProducto; set => iDProducto = value; }
        public int IDCategoria { get => iDCategoria; set => iDCategoria = value; }
        public int IDMarca { get => iDMarca; set => iDMarca = value; }
        public int IDProveedor { get => iDProveedor; set => iDProveedor = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public double PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public bool Estado { get => estado; set => estado = value; }

        #endregion

        public void guardar()
        {
            string cadena;
            cadena = "insert into Productos values ("+iDCategoria+", "+iDMarca+", "+iDProveedor+", '"+nombreProducto+"', '"+modelo+"', "+precioUnitario+", "+Convert.ToInt32(estado)+")";
            sql.Sql_Querys(cadena, "Producto añadido con Exito", "Debe llenar todos los datos antes de añadir");
        }

        public void consultarDatos(DataGridView dgv)
        {
            dgv.DataSource = sql.Consulta("select *, (select Stock from Inventarios Where [ID Producto] = p.[ID Producto]) as Stock from Productos p where Estado = 1 order by [Nombre Producto] asc");
        }

        public void buscarDatos(DataGridView dgv)
        {
            dgv.DataSource = sql.Consulta("select *, (select Stock from Inventarios Where [ID Producto] = p.[ID Producto]) as Stock from Productos p where Estado = 1 and [Nombre Producto] " +
                "Like '%" + nombreProducto + "%' order by [Nombre Producto] asc");
        }

        public void actualizarDatos()
        {
            sql.Sql_Querys("Update Productos set [ID Categoria] = " + iDCategoria + ", [ID Marca] = " + iDMarca + ", [ID Proveedor] = " + iDProveedor + ", [Nombre Producto] = '" + nombreProducto + "', " +
                "Modelo = '" + modelo + "', [Precio Unitario] = " + precioUnitario + ", Estado = " + Convert.ToInt32(estado) + " where [ID Producto] = " + iDProducto + "", 
                "Proucto actualizado con exito", "Error 504");
        }

        public void eliminarDatos()
        {
            sql.Sql_Querys("Update Productos set Estado = 0 where [ID Producto] = " + iDProducto, "Se ha elminado este producto", "Error al eliminar");
        }
    }
}
