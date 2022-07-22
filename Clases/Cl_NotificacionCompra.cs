using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Clases
{
    class Cl_NotificacionCompra: Cl_SqlMaestra
    {
        //variables que almacenan la columnas de la tabla de la DB
        private static int id_noti;
        private static string producto_compra;
        private static string descripcion_compra;
        private static string fecha_compra;
        private static bool estado_compra;

        #region Encapsulamiento
        public int Id_Noti { get => id_noti; set => id_noti = value; }
        public string Producto_Compra { get => producto_compra; set => producto_compra = value; }
        public string Descripcion_Compra { get => descripcion_compra; set => descripcion_compra = value; }
        public  string Fecha_Compra { get => fecha_compra; set => fecha_compra = value; }
        public  bool Estado_Compra { get => estado_compra; set => estado_compra = value; }

        #endregion

        //Procedimientos que se heredan de la clase sql para hacer CRUD 
        public void consultarDatos(DataGridView dgv) //prod que llena el datagrid con las ntificaciones recientes
        {
            dgv.DataSource = Consulta("select * from [Notificacion] where estado_noti = 1 order by producto asc");
        }

        public void buscardatos(DataGridView dgv) //prod para las busquedas filtadas
        {
            dgv.DataSource = Consulta("select * from [Notificacion] where estado_noti = 1 and producto like '%"+producto_compra+"%' order by producto asc");
        }

        public void eliminar() //quita la notificacion de la lista y actualiza el formulario
        {
            Sql_Querys("update [Notificacion] set estado_noti = 0 where [id_noti]= "+id_noti, "Producto ya comprado", "Error al eliminar");
            Formularios.frm_MarcasCategorias  frm = Application.OpenForms.OfType<Formularios.frm_MarcasCategorias >().SingleOrDefault();
            frm.carga();
        }
    }
}
