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
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public frm_ConfigurarDB(bool modi)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            toolTip1.SetToolTip(this.btn_bd, "Escoge la ruta donde esta guradada la Base de Datos");
            toolTip1.SetToolTip(this.btn_guardar, "Guardar la configuracion inicial");
            toolTip1.SetToolTip(this.btn_minimizar, "Minimizar");
            toolTip1.SetToolTip(this.btn_ruta, "Escoge la ruta donde se guardaran los reportes");
            toolTip1.SetToolTip(this.btn_salir, "Salir");
            toolTip1.SetToolTip(this.btn_servers, "Refrescar la lista de Servidores");
            toolTip1.SetToolTip(this.cbo_autenticaciones, "Autenticacion de logueo al server");

            if (modi == true)
            {
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
            }            
        }

        private void frm_ConfigurarDB_Load(object sender, EventArgs e)
        {
            txt_password.UseSystemPasswordChar = true;
        }

        private void CargarServers()
        {
            DataTable sqls = new DataTable(); 
            sqls = SqlDataSourceEnumerator.Instance.GetDataSources();
            DataColumn server = new DataColumn("server", typeof(System.String));
            DataTable sqls2 = new DataTable();
            sqls2.Columns.Add(server);
            
            for(int i = 0; i < sqls.Rows.Count; i++)
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

            cbo_servers.DataSource = sqls2;                               
        }

        private async void btn_actualizar_Click(object sender, EventArgs e)
        {
            frm_notificacion noti = new frm_notificacion("", 4);
            noti.Show();

            Task tar = new Task(CargarServers);
            tar.Start();
            await tar;

            cbo_servers.DisplayMember = "server";    
            cbo_servers.ValueMember = "server";
            cbo_servers.SelectedIndex = -1;
            noti.Close();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea Salir de configuracion inicial de Tecno Pc?", 2);
            noti.ShowDialog();

            if (noti.Dialogresul == DialogResult.OK)
            {
                Application.Exit();
            }

            noti.Close();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_ruta.Text = folderBrowserDialog1.SelectedPath;
                erp_rutReports.Clear();
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {                    
            if (cbo_servers.Text != "" && cbo_autenticaciones.SelectedIndex != -1 && txt_db.Text != "" && txt_ruta.Text != "")
            { 
                if (cbo_autenticaciones.SelectedIndex == 1 && (txt_password.Text == "" || txt_user.Text == ""))
                {
                    frm_notificacion noti3 = new frm_notificacion("Indique las credenciales de Sql server", 3);
                    noti3.ShowDialog();
                    noti3.Close();
                    escoger_erp();
                }
                else
                {
                    Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea guardar esta configuracion?", 2);
                    noti.ShowDialog();

                    if (noti.Dialogresul == DialogResult.OK)
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

                        Properties.Settings.Default.RutaReportes = txt_ruta.Text;
                        Directory.CreateDirectory(txt_ruta.Text + @"\Reportes Tecno Pc");
                        Directory.CreateDirectory(txt_ruta.Text + @"\Reportes Tecno Pc\Clientes");
                        Directory.CreateDirectory(txt_ruta.Text + @"\Reportes Tecno Pc\Contactos");
                        Directory.CreateDirectory(txt_ruta.Text + @"\Reportes Tecno Pc\Empleados");
                        Directory.CreateDirectory(txt_ruta.Text + @"\Reportes Tecno Pc\Proveedores");
                        Directory.CreateDirectory(txt_ruta.Text + @"\Reportes Tecno Pc\Productos");
                        Directory.CreateDirectory(txt_ruta.Text + @"\Reportes Tecno Pc\Usuarios");
                        Directory.CreateDirectory(txt_ruta.Text + @"\Reportes Tecno Pc\Facturas");

                        Properties.Settings.Default.Save();

                        ProcessStartInfo cmd;
                        cmd = new ProcessStartInfo("sqlcmd", "-S " + cbo_servers.Text + " -i " + txt_db.Text);
                        cmd.UseShellExecute = false;
                        cmd.CreateNoWindow = true;
                        cmd.RedirectStandardOutput = true;

                        Process ejecutar = new Process();
                        ejecutar.StartInfo = cmd;
                        ejecutar.Start();

                        noti.Close();
                        Formularios.frm_notificacion noti2 = new Formularios.frm_notificacion("Configuracion guardada con exito", 1);
                        noti2.ShowDialog();
                        Form1 login = new Form1();
                        login.Show();
                        this.Hide();
                    }                    
                }
            }
            else
            {
                frm_notificacion noti3 = new frm_notificacion("Llene todos los datos", 3);
                noti3.ShowDialog();
                noti3.Close();
                escoger_erp();
            }         
        }

        public void escoger_erp()
        {
            if (cbo_servers.Text != "")
            {
                erp_servidor.Clear();
                erp_servidor.SetError(cbo_servers, "Escoja un servidor");
            }

            if (cbo_autenticaciones.SelectedIndex == -1)
            {
                erp_auten.Clear();
                erp_auten.SetError(cbo_autenticaciones, "Escoja un tipo de Autenticacion");
            }

            if (txt_db.Text == "")
            {
                erp_bd.Clear();
                erp_bd.SetError(txt_db, "Especifique la ruta");
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

        private void cbo_autenticaciones_SelectedIndexChanged(object sender, EventArgs e)
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
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_bd_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Sql Documents|*.sql";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 11, 7) == "TecnoPc")
                {
                    txt_db.Text = openFileDialog1.FileName;
                    erp_bd.Clear();
                }
                else
                {                   
                    frm_notificacion noti = new frm_notificacion("Escoja la base de datos de Tecno Pc", 3);
                    noti.ShowDialog();
                    noti.Close();
                    txt_db.Text = "";
                }                
            }
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

        private void cbo_servers_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
