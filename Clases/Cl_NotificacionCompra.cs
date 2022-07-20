﻿using System;
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

        //Procedimientos que se heredan de la clase sql para hacer CRUD 
        public void consultarDatos(DataGridView dgv) //prod que llena el datagrid con las ntificaciones recientes
        {
            dgv.DataSource = consulta_registro("select * from [Notificacion] where estado_noti = 1 order by producto asc");
        }

        public void buscardatos(DataGridView dgv) //prod para las busquedas filtadas
        {
            dgv.DataSource = consulta_registro("select * from [Notificacion] where estado_noti = 1 and producto like '%"+producto+"%' order by producto asc");
        }

        public void eliminar() //quita la notificacion de la lista y actualiza el formulario
        {
            sql_querys("update [Notificacion] set estado_noti = 0 where [id_noti]= "+id_noti, "Producto ya comprado", "Error al eliminar");
            Formularios.frm_MarcasCategorias  frm = Application.OpenForms.OfType<Formularios.frm_MarcasCategorias >().SingleOrDefault();
            frm.carga();
        }
    }
}
