using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repuestos_Arias.Clases
{
    class Cl_Productos
    {
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        private static int id_Producto;
        private static string codigo_Producto;
        private static string nombre_Producto;
        private static double precio_Compra;
        private static double precio_Venta;
        private static double unidades_Stock;
        private static int id_Categoria;
        private static int id_Marca;

        #region Encapsulamiento
        public  int Id_Producto { get => id_Producto; set => id_Producto = value; }
        public  string Codigo_Producto { get => codigo_Producto; set => codigo_Producto = value; }
        public  string Nombre_Producto { get => nombre_Producto; set => nombre_Producto = value; }
        public double Precio_Compra { get => precio_Compra; set => precio_Compra = value; }
        public double Precio_Venta { get => precio_Venta; set => precio_Venta = value; }
        public double Unidades_Stock { get => unidades_Stock; set => unidades_Stock = value; }
        public  int Id_Categoria { get => id_Categoria; set => id_Categoria = value; }
        public  int Id_Marca { get => id_Marca; set => id_Marca = value; }

        #endregion

        public void guardar()
        {
            string cadena;
            cadena = "Insert into Productos (Codigo_Producto, Nombre_Producto, Precio_Compra, Precio_Venta, Unidades_Stock, Id_Categoria, Id_Marca) " +
                "values('" + codigo_Producto + "', '" + nombre_Producto + "', " + precio_Compra + ", " + precio_Venta + ", " + unidades_Stock + ", " +
                "" + id_Categoria + ", " + id_Marca + ")";
            sql.Sql_Querys(cadena, "Producto añadido con exito", "Debe llenar todos los datos antes de añadir");
        }

        public void consultarDatos(DataGridView dgv)
        {
            dgv.DataSource = sql.Consulta("select *from Productos order by Nombre_Producto asc");
        }

        public void buscarDatos(DataGridView dgv)
        {
            dgv.DataSource = sql.Consulta("select *from Productos where Nombre_Producto Like '%" + nombre_Producto + "%' order by Nombre_Producto asc");
        }

        public void actualizarDatos()
        {
            string cadena;
            cadena = "Update Productos set Codigo_Producto = '"+codigo_Producto+"', Nombre_Producto = '"+nombre_Producto+"', Precio_Compra = "+precio_Compra+", " +
                "Precio_Venta = "+precio_Venta+", Unidades_Stock = "+unidades_Stock+", Id_Categoria = "+id_Categoria+", Id_Marca = "+id_Marca+
                " where Id_Producto = " + id_Producto;
            sql.Sql_Querys(cadena, "Producto actulizado con exito", "Debe llenar todos los datos antes de añadir");
        }

        public void eliminarDatos()
        {
            string cadena;
            cadena = "Delete from Productos where Id_Producto = " + id_Producto + "";
            sql.Sql_Querys(cadena, "Producto eliminado con exito", "Debe llenar todos los datos antes de añadir");
        }
    }
}
