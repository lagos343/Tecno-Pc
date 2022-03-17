using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Tecno_Pc.Clases
{
    class Cl_SqlMaestra
    {
        private string Servidor = Properties.Settings.Default.Servidor.ToString();
        private string DataBase = "TECNOPC";    
        private string cadena_coneccion;        
        SqlConnection connection = new SqlConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable Tabla_Resultados;       


        public Cl_SqlMaestra()
        {
            if (Properties.Settings.Default.WindowsAuten == "false")
            {
                cadena_coneccion = "Data Source=" + Servidor + "; Initial Catalog=" + DataBase + "; User ID="+Properties.Settings.Default.Usuario.ToString()
                    +"; Password="+Properties.Settings.Default.Contraseña;
            }
            else
            {
                cadena_coneccion = "Data Source=" + Servidor + "; Initial Catalog=" + DataBase + "; Integrated Security=True";
            }
            connection.ConnectionString = cadena_coneccion;
        }

       
        public void Abrir()
        {
            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("Error al conectar con el server o la DB, ¿Desea abrir la configuracion?", 2);
                noti.ShowDialog();

                if (noti.Dialogresul == DialogResult.OK)
                {   
                    Formularios.frm_ConfigurarDB bd = new Formularios.frm_ConfigurarDB(true);
                    bd.Show();

                    Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Form1);
                    if (frm != null)
                    {
                        frm.Hide();
                    }
                }
                
                noti.Close(); 
            }            
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
            try
            {
                adapter.Fill(Tabla_Resultados);
            }
            catch (Exception){}            
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
