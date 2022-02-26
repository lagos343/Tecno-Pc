using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Clases
{
    class Cl_NotificacionCompra
    {
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        private static int id_noti;
        private static string producto;
        private static string descripcion;
        private static string fecha;
        private static bool estado;

        #region Encapsulamiento
        public int Id_noti { get => id_noti; set => id_noti = value; }
        public string Producto { get => producto; set => producto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public  string Fecha { get => fecha; set => fecha = value; }
        public  bool Estado { get => estado; set => estado = value; }

        #endregion

        public void consultarDatos(DataGridView dgv)
        {
            dgv.DataSource = sql.Consulta("select * from [Notificacion Compra] where Estado = 1 order by Producto asc");

        }

        public void buscardatos(DataGridView dgv)
        {
            dgv.DataSource = sql.Consulta("select * from [Notificacion Compra] where Estado = 1 and Producto like '%"+producto+"%' order by Producto asc");
        }

        public void eliminar()
        {
            sql.Sql_Querys("update [Notificacion Compra] set Estado = 0 where [ID NOTI]= "+id_noti, "Producto ya comprado", "Error al eliminar");
            Formularios.frm_MarcasCategorias  frm = Application.OpenForms.OfType<Formularios.frm_MarcasCategorias >().SingleOrDefault();
            frm.carga();

        }


    }
}
