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
    class Cl_SqlMaestra //clase que se encarga de todos los procedimientoos que tengan que ver con la DB 
    {
        //Propiedades usadas para brindar conecccion a la DB a todos los formularios 
        private string servidor_sql = Properties.Settings.Default.Servidor.ToString();
        private string data_base = "TECNOPC";    
        private string cadena_coneccion;        
        SqlConnection connection_sql = new SqlConnection();
        SqlDataAdapter adapter_sql = new SqlDataAdapter();
        SqlCommand cmd_sql = new SqlCommand();
        DataTable tabla_resultados;       


        public Cl_SqlMaestra() //constructor
        {
            if (Properties.Settings.Default.WindowsAuten == "false") //verificamos el tipo de autenticacion para crear la cadena de coonecion 
            {
                cadena_coneccion = "Data Source=" + servidor_sql + "; Initial Catalog=" + data_base + "; User ID="+Properties.Settings.Default.Usuario.ToString()
                    +"; Password="+Properties.Settings.Default.Contraseña;
            }
            else
            {
                cadena_coneccion = "Data Source=" + servidor_sql + "; Initial Catalog=" + data_base + "; Integrated Security=True";
            }
            connection_sql.ConnectionString = cadena_coneccion; //creamos la sql conection
        }

       
        public void Abrir_coneccion() //se encarga de abrrir la coneccion a sql
        {
            try
            {
                connection_sql.Open(); //intentamos abrirrla
            }
            catch (Exception) //de no abrirse notificamos el error y preguntamos si desea configurar el sevidor ya que ese es el error mas comun
            {
                Formularios.frm_notificacion noti_sql = new Formularios.frm_notificacion("Error al conectar con el server o la DB, ¿Desea abrir la configuracion?", 2);
                noti_sql.ShowDialog(); 

                if (noti_sql.Dialogresul == DialogResult.OK) 
                {   
                    Formularios.frm_ConfigurarDB bd = new Formularios.frm_ConfigurarDB(true);
                    bd.Show();

                    Form frm_sql = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Form1);
                    if (frm_sql != null)
                    {
                        frm_sql.Hide();
                    }
                }
                
                noti_sql.Close(); 
            }            
        }

        public void Cerrar()
        {
            connection_sql.Close();
        }

        public DataTable Consulta_registro(String cadena_consulta) //se encarga dde consultas de muchos registros
        {
            Abrir_coneccion();
            adapter_sql = new SqlDataAdapter(cadena_consulta, cadena_coneccion);
            tabla_resultados = new DataTable();
            try
            {
                adapter_sql.Fill(tabla_resultados);
            }
            catch (Exception){}            
            Cerrar();

            return tabla_resultados;
        }

        public String Consulta2_registro(String cadena_consulta) //se encarga de consultas que retornan un solo dato
        {
            string resultado_consulta = "";

            Abrir_coneccion();
            adapter_sql = new SqlDataAdapter(cadena_consulta, cadena_coneccion);
            tabla_resultados = new DataTable();
            adapter_sql.Fill(tabla_resultados);
            resultado_consulta = tabla_resultados.Rows[0][0].ToString();
            Cerrar();

            return resultado_consulta;
        }

        public void Sql_querys(string cadena_sql, string mensaje_bueno, string mensaje_malo) //se encarga de comandos transac sql que pueden mostrar errores
        {
            Abrir_coneccion();
            cmd_sql = new SqlCommand();
            cmd_sql.Connection = connection_sql;
            cmd_sql.CommandText = cadena_sql;

            try
            {
                cmd_sql.ExecuteNonQuery();
                Formularios.frm_notificacion noti_sql = new Formularios.frm_notificacion(mensaje_bueno, 1);
                noti_sql.ShowDialog();
                noti_sql.Close();
            }
            catch (Exception ex)
            {
                Formularios.frm_notificacion noti_sql = new Formularios.frm_notificacion(mensaje_malo, 3);
                noti_sql.ShowDialog();
                noti_sql.Close();
            }
            Cerrar();
        }

        public bool Sql_query(string cadena_sql, string mensaje_bueno, string mensaje_malo) //se encarga de comandos transac sql que pueden mostrar errores de tipo sql exception por datos repetidos
        {
            bool retorno_sql;
            Abrir_coneccion();
            cmd_sql = new SqlCommand();
            cmd_sql.Connection = connection_sql;
            cmd_sql.CommandText = cadena_sql;

            try
            {
                cmd_sql.ExecuteNonQuery();
                Formularios.frm_notificacion noti_sql = new Formularios.frm_notificacion(mensaje_bueno, 1);
                noti_sql.ShowDialog();
                noti_sql.Close();
                retorno_sql = true;
            }
            catch (Exception ex)
            {
                Formularios.frm_notificacion noti_sql = new Formularios.frm_notificacion(mensaje_malo, 3);
                noti_sql.ShowDialog();
                noti_sql.Close();
                retorno_sql = false;
            }
            Cerrar();
            return retorno_sql;
        }

        public void Sql_querys(string cadena_sql) //sobrecarga del prod anterrior para comandos transac sql que deseas hacer en segundo plan sin notiicar nada al usuario
        {
            Abrir_coneccion();

            cmd_sql = new SqlCommand();
            cmd_sql.Connection = connection_sql;
            cmd_sql.CommandText = cadena_sql;
            cmd_sql.ExecuteNonQuery();

            Cerrar();
        }        
    }
}
