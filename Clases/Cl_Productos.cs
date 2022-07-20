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
        private static int iDProducto;
        private static int iDCategoria;
        private static int iDMarca;
        private static int iDProveedor;
        private static string nombreProducto; 
        private static string modelo;
        private static double precioUnitario;
        private static bool estado;
        private static string codbarra;

        #region Encapsulamiento

        public int IDProducto { get => iDProducto; set => iDProducto = value; }
        public int IDCategoria { get => iDCategoria; set => iDCategoria = value; }
        public int IDMarca { get => iDMarca; set => iDMarca = value; }
        public int IDProveedor { get => iDProveedor; set => iDProveedor = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public double PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public bool Estado { get => estado; set => estado = value; }
        public string Codbarra { get => codbarra; set => codbarra = value; }

        #endregion

        //Procedimientos que se heredan de la clase sql para hacer CRUD 
        public bool guardar()
        {
            string cadena;
            cadena = "insert into Productos values ("+iDCategoria+", "+iDMarca+", "+iDProveedor+", '"+nombreProducto+"', '"+modelo+"', "+precioUnitario+", "+Convert.ToInt32(estado)+", '"+codbarra+"')";
            return sql_query(cadena, "Producto añadido con Exito", "¡El codigo de barra especificado ya esta en uso!"); //si sql devuelve error, hay un codigo de barras repetido
        }

        public void consultarDatos(DataGridView dgv) //llena el datagrid con los registros
        {
            dgv.DataSource = consulta_registro("select *, (select stock_producto from Inventarios Where [id_producto] = p.[id_producto]) as Stock from Productos p where estado_producto = 1 " +
                "order by [nombre_producto] asc");
        }

        public void buscarDatos(DataGridView dgv) //busquedas filtradas 
        {
            dgv.DataSource = consulta_registro("select *, (select stock_producto from Inventarios Where [id_producto] = p.[id_producto]) as Stock from Productos p where estado_producto = 1 " +
                "and [nombre_producto] Like '%" + nombreProducto + "%' order by [nombre_producto] asc");
        }

        public bool actualizarDatos() 
        {
            return sql_query("Update Productos set [id_categoria] = " + iDCategoria + ", [id_marca] = " + iDMarca + ", [id_proveedor] = " + iDProveedor + ", [nombre_producto] = '" + nombreProducto + "', " +
                "modelo_producto = '" + modelo + "', [precio_unitario] = " + precioUnitario + ", estado_producto = " + Convert.ToInt32(estado) + ", cod_barra = '"+codbarra+"' where [id_producto] = " + iDProducto + "", 
                "Producto actualizado con exito", "¡El codigo de barra especificado ya esta en uso!"); //si sql devuelve error, hay un codigo de barras repetido
        }

        public void eliminarDatos()
        {
            sql_querys("Update Productos set estado_producto = 0 where [id_producto] = " + iDProducto, "Se ha elminado este producto", "Error al eliminar");            
        }
    }
}
