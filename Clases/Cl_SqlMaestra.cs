using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Repuestos_Arias.Clases
{
    class Cl_SqlMaestra
    {
        private string Servidor = "DESKTOP-8Q1Q950";
        private string DataBase = "TECNOPC";
        private string cadena_coneccion;        
        SqlConnection connection = new SqlConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable Tabla_Resultados;       


        public Cl_SqlMaestra()
        {
            cadena_coneccion = "Data Source=" +Servidor+"; Initial Catalog="+DataBase+"; Integrated Security=True";
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
            adapter = new SqlDataAdapter(cadena, cadena_coneccion);
            Tabla_Resultados = new DataTable();
            adapter.Fill(Tabla_Resultados);
            Cerrar();

            return Tabla_Resultados;
        }

        public String Consulta2(String cadena)
        {
            string Resultado = "";

            Abrir();
            adapter = new SqlDataAdapter(cadena, cadena_coneccion);
            Tabla_Resultados = new DataTable();
            adapter.Fill(Tabla_Resultados);
            Resultado = Tabla_Resultados.Rows[0][0].ToString();
            Cerrar();

            return Resultado;
        }

        public void Sql_Querys(string cadena, string mensajeBueno, string mensajeMalo)
        {
            Abrir();
            cmd = new SqlCommand();
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

        public void Sql_Querys(string cadena)
        {
            Abrir();

            cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = cadena;
            cmd.ExecuteNonQuery();

            Cerrar();
        }
    }
}
