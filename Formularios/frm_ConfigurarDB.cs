using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Tecno_Pc.Formularios
{
    public partial class frm_ConfigurarDB : Form
    {
        //definicion de objetos de las clases necesarias
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        public bool EscribirServer = false;

        //Importacion de libreias propias de windows para movimiento del formulario  
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        Clases.Cl_Validacion vld = new Clases.Cl_Validacion();

        public frm_ConfigurarDB(bool modi)
        {
            InitializeComponent();            
            Control.CheckForIllegalCrossThreadCalls = false;
            toolTip1.SetToolTip(this.Btn_Guardar, "Guardar la configuracion inicial");
            toolTip1.SetToolTip(this.Btn_Minimizar, "Minimizar");
            toolTip1.SetToolTip(this.Btn_Ruta, "Escoge la ruta donde se guardaran los reportes");
            toolTip1.SetToolTip(this.Btn_Salir, "Salir");
            toolTip1.SetToolTip(this.Btn_Servers, "Refrescar la lista de Servidores");
            toolTip1.SetToolTip(this.cbo_autenticaciones, "Autenticacion de logueo al server");

            if (modi == true) //verificamos si entramos a modificar datos o no
            {
                //mostramos toda la informacion almacenada en las variables del sistema
                cbo_servers.Text = Properties.Settings.Default.Servidor.ToString();

                if (Properties.Settings.Default.WindowsAuten == "true")
                {
                    cbo_autenticaciones.SelectedIndex = 0;
                }
                else
                {
                    cbo_autenticaciones.SelectedIndex = 1;
                    txt_user.Text = Properties.Settings.Default.Usuario.ToString();
                    txt_password.Text = Properties.Settings.Default.Contraseña.ToString();
                }

                txt_ruta.Text = Properties.Settings.Default.RutaReportes.ToString();
                txt_rtn.Text = Properties.Settings.Default.RTN.ToString();
                txt_cai.Text = Properties.Settings.Default.CAI.ToString();
                txt_dir.Text = Properties.Settings.Default.Direccion.ToString();
                txt_correo.Text = Properties.Settings.Default.Email.ToString();
                txt_telefono.Text = Properties.Settings.Default.Telefono.ToString();
            }            
        }

        private void frm_ConfigurarDB_Load(object sender, EventArgs e)
        {
            txt_password.UseSystemPasswordChar = true;
        }

        private void Cargar_Servers() //prod que se encarga de buscar los servers sql del pc y los lista en el Combobox
        {
            //variables necesarias
            DataTable sqls = new DataTable(); 
            sqls = SqlDataSourceEnumerator.Instance.GetDataSources();
            DataColumn server = new DataColumn("server", typeof(System.String));
            DataTable sqls2 = new DataTable();
            sqls2.Columns.Add(server);

            //recorremos la lista de servidores y de haber una instancia con nombre se agrega
            for (int i = 0; i < sqls.Rows.Count; i++)
            {
                if (sqls.Rows[i][1].ToString() == "")
                {
                    sqls2.Rows.Add(sqls.Rows[i][0].ToString());
                }
                else
                {
                    sqls2.Rows.Add(sqls.Rows[i][0].ToString() + @"\" + sqls.Rows[i][1].ToString());
                }
            }                            

            cbo_servers.DataSource = sqls2;  //devolvermos la lista de servidores                             
        }

        private async void btn_actualizar_Click(object sender, EventArgs e) //boton que da la orden de buscar lso servidores
        {
            Btn_Servers.Enabled = false;
            frm_notificacion noti = new frm_notificacion("", 4);
            noti.Show();

            Task tar = new Task(Cargar_Servers);
            tar.Start();
            await tar;
            noti.Close();

            if (cbo_servers.Items.Count != 0) //si hay servidores se despliega el combobox
            {
                cbo_servers.DisplayMember = "server";
                cbo_servers.ValueMember = "server";
                cbo_servers.SelectedIndex = -1;
                EscribirServer = false;
            }
            else
            {
                //si no se le permite al ususario escribir el nombre del server por el mismo
                Formularios.frm_notificacion noti2 = new Formularios.frm_notificacion("Hubo un error al intentar encontrar servidores, Escriba el servidor manualmente", 3);
                noti2.ShowDialog();
                noti2.Close();
                EscribirServer = true;
            }
            Btn_Servers.Enabled = true;
        }

        private void btn_salir_Click(object sender, EventArgs e) 
        {
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_principal);
            if (frm != null) //si estamos desde el form principal solo cerramos el formulario de config
            {
                this.Close();
            }
            else
            {
                //si estamos desde el login cerramos el programa
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea Salir de configuracion inicial de Tecno Pc?", 2);
                noti.ShowDialog();

                if (noti.dialogs_resul == DialogResult.OK)
                {
                    Application.Exit();
                }

                noti.Close();
            }            
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e) //boton que se encarga de buscar la ruta donde estara la carpeta de reportes
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_ruta.Text = folderBrowserDialog1.SelectedPath;
                erp_rutReports.Clear();
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e) //boton que guarda toda la configuracion
        {
            Definicion_Array();
            if (vld.Comprobar_Txt() == true && cbo_servers.Text != "" && cbo_autenticaciones.SelectedIndex != -1 && txt_ruta.Text != "" && txt_cai.Text.Length == 37)
            { 
                if (cbo_autenticaciones.SelectedIndex == 1 && (txt_password.Text == "" || txt_user.Text == "")) //verificamos el modo de autenticacion 
                {
                    frm_notificacion noti3 = new frm_notificacion("Indique las credenciales de Sql server", 3);
                    noti3.ShowDialog();
                    noti3.Close();
                    Escoger_Erp();
                }
                else
                {
                    Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea guardar esta configuracion?", 2);
                    noti.ShowDialog();

                    if (noti.dialogs_resul == DialogResult.OK) //si presionamos ok se procedera a guardar la informacion
                    {
                        Properties.Settings.Default.Servidor = cbo_servers.Text;

                        if (cbo_autenticaciones.SelectedIndex == 1)
                        {
                            Properties.Settings.Default.WindowsAuten = "false";
                            Properties.Settings.Default.Usuario = txt_user.Text;
                            Properties.Settings.Default.Contraseña = txt_password.Text;
                        }
                        else
                        {
                            Properties.Settings.Default.WindowsAuten = "true";
                        }

                        //creamos las  carpetas de los reportes en la ruta escogida 
                        Properties.Settings.Default.RutaReportes = txt_ruta.Text;
                        Directory.CreateDirectory(txt_ruta.Text + @"\Reportes Tecno Pc");
                        Directory.CreateDirectory(txt_ruta.Text + @"\Reportes Tecno Pc\Clientes");
                        Directory.CreateDirectory(txt_ruta.Text + @"\Reportes Tecno Pc\Contactos");
                        Directory.CreateDirectory(txt_ruta.Text + @"\Reportes Tecno Pc\Empleados");
                        Directory.CreateDirectory(txt_ruta.Text + @"\Reportes Tecno Pc\Proveedores");
                        Directory.CreateDirectory(txt_ruta.Text + @"\Reportes Tecno Pc\Productos");
                        Directory.CreateDirectory(txt_ruta.Text + @"\Reportes Tecno Pc\Usuarios");
                        Directory.CreateDirectory(txt_ruta.Text + @"\Reportes Tecno Pc\Facturas");
                        Directory.CreateDirectory(txt_ruta.Text + @"\Reportes Tecno Pc\Ventas");

                        //Datos de Facturacion
                        Properties.Settings.Default.RTN = txt_rtn.Text;
                        Properties.Settings.Default.CAI = txt_cai.Text;
                        Properties.Settings.Default.Direccion = txt_dir.Text;
                        Properties.Settings.Default.Email = txt_correo.Text;
                        Properties.Settings.Default.Telefono = txt_telefono.Text;

                        Properties.Settings.Default.Save(); //guardamos las variables de entorno                                                

                        noti.Close();
                        Formularios.frm_notificacion noti2 = new Formularios.frm_notificacion("Configuracion guardada con exito", 1);
                        noti2.ShowDialog();

                        Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_principal);
                        if (frm == null)
                        {
                            Form1 login = new Form1(); //cargamos el login
                            login.Show();
                        }                                                                      
                        this.Hide();
                    }                    
                }
            }
            else
            {
                frm_notificacion noti3 = new frm_notificacion("Error al guardar, corrija las Advertencias", 3);
                noti3.ShowDialog();
                noti3.Close();
                Escoger_Erp();
            }         
        }

        public void Escoger_Erp()  //muestra los errores que puedan ocurrir en los combobox
        {
            if (txt_cai.Text.Length != 37)
            {
                erp_cai.Clear();
                erp_cai.SetError(txt_cai, "Llene todo el campo");
            }

            if (cbo_servers.Text == "")
            {
                erp_servidor.Clear();
                erp_servidor.SetError(cbo_servers, "Escoja un servidor");
            }

            if (cbo_autenticaciones.SelectedIndex == -1)
            {
                erp_auten.Clear();
                erp_auten.SetError(cbo_autenticaciones, "Escoja un tipo de Autenticacion");
            }                      

            if (txt_ruta.Text == "")
            {
                erp_rutReports.Clear();
                erp_rutReports.SetError(txt_ruta, "Especifique la ruta");
            }

            if (cbo_autenticaciones.SelectedIndex == 1)
            {
                if(txt_password.Text == "")
                {
                    erp_contra.Clear();
                    erp_contra.SetError(txt_password, "No puede quedar vacio");
                }

                if (txt_user.Text == "")
                {
                    erp_usu.Clear();
                    erp_usu.SetError(txt_user, "No puede quedar vacio");
                }
            }
        }

        private void cbo_autenticaciones_SelectedIndexChanged(object sender, EventArgs e) //dependiendo del modo de autenticacion seleccionado activamos o no el user y password de sql 
        {
            erp_auten.Clear();

            if (cbo_autenticaciones.SelectedIndex == 1)
            {
                txt_password.Enabled = true;
                txt_user.Enabled = true;
            }
            else
            {
                txt_password.Enabled = false;
                txt_user.Enabled = false;
            }           
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //llamado de las librerias ddl para mover el form desde este panel
        }

        public void Definicion_Array() //define las propiedades enviadas a la clase de Validaciones mediante Arrays con todos los Textbox y sus correspondientes expresiones regulares 
        {
            vld.Text = new TextBox[] { txt_dir, txt_correo, txt_telefono, txt_rtn};
            vld.Error = new ErrorProvider[] { erp_dir, erp_correo, erp_tel, erp_rtn };
            vld.Minimo = new int[] { 3, 10, 8, 14 , 37};
            vld.Regular = new string[] {"[A-Z, a-z, 0-9,.,#]", "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$",
                "(2|3|8|9)[ -]*([0-9]*)", "[0-9]"};
            vld.Msj = new string[] { "Caracteres especiales no validos", "solo emails validos: example@dominio.algo", "Solo digitos numericos y que empiecen por 2,3,8 y 9" , "Solo Carcateres Numericos"};

        }

        #region limpiar_erps

        private void cbo_servers_SelectedIndexChanged(object sender, EventArgs e)
        {
            erp_servidor.Clear();
        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {
            erp_usu.Clear();
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            erp_contra.Clear();
        }

        #endregion

        #region keypress
        private void cbo_servers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EscribirServer == false)
            e.Handled = true;
        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            erp_tel.Clear();

            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_rtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            erp_rtn.Clear();

            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_correo_KeyPress(object sender, KeyPressEventArgs e)
        {
            erp_correo.Clear();
        }

        private void txt_cai_KeyPress(object sender, KeyPressEventArgs e)
        {
            erp_cai.Clear();

            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsLetter(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }            
        }

        private void txt_dir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Btn_Guardar.PerformClick();
            }
        }

        #endregion
    }
}
