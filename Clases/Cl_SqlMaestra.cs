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
        private string Servidor = Properties.Settings.Default.Servidor.ToString();
        private string DataBase = "TECNOPC";    
        private string cadena_coneccion;        
        SqlConnection connection = new SqlConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable Tabla_Resultados;       


        public Cl_SqlMaestra() //constructor
        {
            if (Properties.Settings.Default.WindowsAuten == "false") //verificamos el tipo de autenticacion para crear la cadena de coonecion 
            {
                cadena_coneccion = "Data Source=" + Servidor + "; Initial Catalog=" + DataBase + "; User ID="+Properties.Settings.Default.Usuario.ToString()
                    +"; Password="+Properties.Settings.Default.Contraseña;
            }
            else
            {
                cadena_coneccion = "Data Source=" + Servidor + "; Initial Catalog=" + DataBase + "; Integrated Security=True";
            }
            connection.ConnectionString = cadena_coneccion; //creamos la sql conection
        }

       
        public void Abrir() //se encarga de abrrir la coneccion a sql
        {
            try
            {
                connection.Open(); //intentamos abrirrla
            }
            catch (Exception) //de no abrirse notificamos el error y preguntamos si desea configurar el sevidor ya que ese es el error mas comun
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

        public DataTable Consulta(String cadena) //se encarga dde consultas de muchos registros
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

        public String Consulta2(String cadena) //se encarga de consultas que retornan un solo dato
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

        public void Sql_Querys(string cadena, string mensajeBueno, string mensajeMalo) //se encarga de comandos transac sql que pueden mostrar errores
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

        public bool Sql_Query(string cadena, string mensajeBueno, string mensajeMalo) //se encarga de comandos transac sql que pueden mostrar errores de tipo sql exception por datos repetidos
        {
            bool retorno;
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
                retorno = true;
            }
            catch (Exception ex)
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion(mensajeMalo, 3);
                noti.ShowDialog();
                noti.Close();
                retorno = false;
            }
            Cerrar();
            return retorno;
        }

        public void Sql_Querys(string cadena) //sobrecarga del prod anterrior para comandos transac sql que deseas hacer en segundo plan sin notiicar nada al usuario
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
