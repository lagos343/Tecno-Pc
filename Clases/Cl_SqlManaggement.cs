using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace Repuestos_Arias.Clases
{
    class Cl_SqlManaggement
    {
        private string cadena_coneccion;
        OleDbDataReader read;
        OleDbConnection connection = new OleDbConnection();
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        OleDbCommand cmd = new OleDbCommand();
        DataTable Tabla_Resultados;

        public Cl_SqlManaggement()
        {
            cadena_coneccion = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source = Repuestos_Arias_Database.mdb";
            connection.ConnectionString = cadena_coneccion;            
        }

        public void Abrir()
        {
            connection.Open();
        }

        public void Cerrar()
        {
            connection.Close();
        }

        public DataTable Consulta(String cadena)
        {
            Abrir();
            adapter = new OleDbDataAdapter(cadena, cadena_coneccion);
            Tabla_Resultados = new DataTable();
            adapter.Fill(Tabla_Resultados);
            Cerrar();

            return Tabla_Resultados;
        }

        public void modi_guar_elim(string cadena, string mensajeBueno, string mensajeMalo)
        {
            Abrir();
            cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = cadena;

            try
            {
                cmd.ExecuteNonQuery();
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion(mensajeBueno, 1);
                noti.ShowDialog();
                noti.Close();
            }
            catch (Exception ex)
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion(mensajeMalo, 3);
                noti.ShowDialog();
                noti.Close();
            }
            Cerrar();
        }

        public void modi_guar_elim(string cadena)
        {
            Abrir();
            cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = cadena;

            try
            {
                cmd.ExecuteNonQuery();                
            }
            catch (Exception ex){}
            Cerrar();
        }
    }
}
