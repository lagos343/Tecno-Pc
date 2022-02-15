using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repuestos_Arias.Clases
{
    class Cl_Facturas
    {
        Cl_SqlMaestra sql = new Cl_SqlMaestra();
        DataTable datosFacturas = new DataTable();

        //datos de la Factura
        private static int no_Factura;
        private static int total_Compra;
        private static string fecha_Compra;
        private static string nombre_Cliente;
        private static string usuario_Vendedor;

        //Datos de los productos
        private static string nombre_Producto;        
        private static int cant;
        private static int precio_Unitario;
        private static int total;

        #region Encapsulado

        public int No_Factura { get => no_Factura; set => no_Factura = value; }
        public string Fecha_Compra { get => fecha_Compra; set => fecha_Compra = value; }
        public string Nombre_Cliente { get => nombre_Cliente; set => nombre_Cliente = value; }
        public string Usuario_Vendedor { get => usuario_Vendedor; set => usuario_Vendedor = value; }
        public string Nombre_Producto { get => nombre_Producto; set => nombre_Producto = value; }
        public int Cant { get => cant; set => cant = value; }
        public int Total { get => total; set => total = value; }
        public int Precio_Unitario { get => precio_Unitario; set => precio_Unitario = value; }
        public int Total_Compra { get => total_Compra; set => total_Compra = value; }

        #endregion

        public void consultarDatos(DataGridView dgv)
        {
            dgv.DataSource = sql.Consulta("select fa.No_Factura, fa.Fecha_Compra, fa.Nombre_Cliente, (us.Nombres_Propietario + ' ' + us.Apellidos_Propietario) as Nombre, " +
                "(select SUM(Total) from DetallesFactura df where df.Fecha_Compra = fa.Fecha_Compra and df.No_Factura = fa.No_Factura) as Total " +
                "from Factura fa inner join Usuarios us on us.Id_Usuario = fa.Usuario_Vendedor");
        }


        public void buscarDatos(DataGridView dgv, string filtro, TextBox txt_buscar)
        {
            dgv.DataSource = sql.Consulta("select fa.No_Factura, fa.Fecha_Compra, fa.Nombre_Cliente, (us.Nombres_Propietario + ' ' + us.Apellidos_Propietario) as Nombre, " +
                "(select SUM(Total) from DetallesFactura df where df.Fecha_Compra = fa.Fecha_Compra and df.No_Factura = fa.No_Factura) as Total " +
                "from Factura fa inner join Usuarios us on us.Id_Usuario = fa.Usuario_Vendedor where " + filtro + " LIKE '%" + txt_buscar.Text + "%'");
        }        
    }
}
