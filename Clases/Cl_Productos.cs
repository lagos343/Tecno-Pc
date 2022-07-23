using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Clases
{
    class Cl_Productos: Cl_SqlMaestra
    {
        //variables que almacenan la columnas de la tabla de la DB
        private static int id_producto;
        private static int id_categoria;
        private static int id_marca;
        private static int id_proveedor;
        private static string nombre_producto; 
        private static string modelo_producto;
        private static double precio_unitario;
        private static bool estado_producto;
        private static string cod_barra;

        #region Encapsulamiento

        public int IDProducto { get => id_producto; set => id_producto = value; }
        public int Id_Categoria { get => id_categoria; set => id_categoria = value; }
        public int Id_Marca { get => id_marca; set => id_marca = value; }
        public int Id_Proveedor { get => id_proveedor; set => id_proveedor = value; }
        public string Nombre_Producto { get => nombre_producto; set => nombre_producto = value; }
        public string Modelo_Producto { get => modelo_producto; set => modelo_producto = value; }
        public double Precio_Unitario { get => precio_unitario; set => precio_unitario = value; }
        public bool Estado_Producto { get => estado_producto; set => estado_producto = value; }
        public string Cod_Barra { get => cod_barra; set => cod_barra = value; }

        #endregion

        //Procedimientos que se heredan de la clase sql para hacer CRUD 
        public bool guardar()
        {
            string cadena;
            cadena = "insert into Productos values ("+id_categoria+", "+id_marca+", "+id_proveedor+", '"+nombre_producto+"', '"+modelo_producto+"', "+precio_unitario+", "+Convert.ToInt32(estado_producto)+", '"+cod_barra+"')";
            return Sql_query(cadena, "Producto añadido con Exito", "¡El codigo de barra especificado ya esta en uso!"); //si sql devuelve error, hay un codigo de barras repetido
        }

        public void consultarDatos(DataGridView dgv) //llena el datagrid con los registros
        {
            dgv.DataSource = Consulta_registro("select *, (select stock_producto from Inventarios Where [id_producto] = p.[id_producto]) as Stock from Productos p where estado_producto = 1 " +
                "order by [nombre_producto] asc");
        }

        public void buscarDatos(DataGridView dgv) //busquedas filtradas 
        {
            dgv.DataSource = Consulta_registro("select *, (select stock_producto from Inventarios Where [id_producto] = p.[id_producto]) as Stock from Productos p where estado_producto = 1 " +
                "and [nombre_producto] Like '%" + nombre_producto + "%' order by [nombre_producto] asc");
        }

        public bool actualizarDatos() 
        {
            return Sql_query("Update Productos set [id_categoria] = " + id_categoria + ", [id_marca] = " + id_marca + ", [id_proveedor] = " + id_proveedor + ", [nombre_producto] = '" + nombre_producto + "', " +
                "modelo_producto = '" + modelo_producto + "', [precio_unitario] = " + precio_unitario + ", estado_producto = " + Convert.ToInt32(estado_producto) + ", cod_barra = '"+cod_barra+"' where [id_producto] = " + id_producto + "", 
                "Producto actualizado con exito", "¡El codigo de barra especificado ya esta en uso!"); //si sql devuelve error, hay un codigo de barras repetido
        }

        public void eliminarDatos()
        {
            Sql_querys("Update Productos set estado_producto = 0 where [id_producto] = " + id_producto, "Se ha elminado este producto", "Error al eliminar");            
        }
    }
}
