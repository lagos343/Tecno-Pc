using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Tecno_Pc.Formularios
{

    public partial class frm_clientes : Form
    {

        bool actualizar = false;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Clases.Cl_Clientes cli = new Clases.Cl_Clientes();
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Validacion vld = new Clases.Cl_Validacion();
        Clases.Cl_Reportes rep = new Clases.Cl_Reportes();


        public frm_clientes()
        {
            InitializeComponent();
            Inicializar_Combobox();
            
            this.ttMensaje.SetToolTip(this.cmb_Depto, "Combobox de departamento");
            this.ttMensaje.SetToolTip(this.txt_Ident, "Caja de texto del No. de Identidad del Cliente");
            this.ttMensaje.SetToolTip(this.txt_Nombre, "Caja de texto del Nombre del Cliente");
            this.ttMensaje.SetToolTip(this.txt_Apell, "Caja de texto del Apellido del Cliente");
            this.ttMensaje.SetToolTip(this.txt_Tel, "Caja de texto del Telefono del Cliente");
            this.ttMensaje.SetToolTip(this.txt_Email, "Caja de texto del Correo del Cliente");
            this.ttMensaje.SetToolTip(this.txt_Direccion, "Caja de texto de la Direccion del Cliente");
            this.ttMensaje.SetToolTip(this.txt_buscar, "Caja de texto de busqueda filtrada por Nombre");
            this.ttMensaje.SetToolTip(this.Btn_Imprimir, "Boton para exportar reporte de Clientes");
            this.ttMensaje.SetToolTip(this.Btn_Salir, "Salir");
            this.ttMensaje.SetToolTip(this.Btn_Minimizar, "Minimizar");
            this.ttMensaje.SetToolTip(this.Btn_Nuevo, "Boton para Limpiar las cajas de texto");
            this.ttMensaje.SetToolTip(this.Btn_Editar, "Boton para Editar la informacion del Cliente");
            this.ttMensaje.SetToolTip(this.Btn_Eliminar, "Boton para Eliminar la informacion del Cliente");
            this.ttMensaje.SetToolTip(this.Btn_Guardar, "Boton para Guardar informacion del Cliente");
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void Limpiado_Clientes()
        {
            cmb_Depto.SelectedIndex = -1;
            txt_Ident.Clear();
            txt_id.Clear();
            txt_Nombre.Clear();
            txt_Apell.Clear();
            txt_Tel.Clear();
            txt_Email.Clear();
            txt_Direccion.Clear();
            actualizar = false;
            erp_apellido.Clear();
            erp_depto.Clear();
            erp_direccion.Clear();
            erp_email.Clear();
            erp_identidad.Clear();
            erp_nombre.Clear();
            erp_telefono.Clear();            
        }

        public void Operaciones_Datagrid()
        {
            dgv_datos.Columns[0].Visible = false;
            dgv_datos.Columns[1].Visible = false;
            dgv_datos.Columns[7].Visible = false;
            dgv_datos.Columns[8].Visible = false;
            dgv_datos.Columns[2].Width = 100;
            dgv_datos.Columns[5].Width = 80;
        }


        public void Inicializar_Combobox()
        {
            cmb_Depto.DataSource = sql.Consulta("select *from Departamentos order by [nombre_depto] asc");
            cmb_Depto.DisplayMember = "nombre_depto";
            cmb_Depto.ValueMember = "id_depto";
            cmb_Depto.SelectedIndex = -1;
        }

        public void Definicion_Array()
        {
            vld.Text = new TextBox [6] { txt_Ident, txt_Nombre, txt_Apell, txt_Tel, txt_Email, txt_Direccion };
            vld.Error = new ErrorProvider[6] { erp_identidad,erp_nombre, erp_apellido, erp_telefono, erp_email, erp_direccion  };
            vld.Minimo = new int[6] { 13,2, 2, 8, 10, 3};
            vld.Regular = new string[6] { "(0[1-9]|1[0-8])(0[1-9]|1[0-9]|2[0-8])[0-9]{4}[0-9]{5}","[A-Z, a-z]", "[A-Z, a-z]", "(2|3|8|9)[ -]*([0-9]*)",
                "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$",
                "[A-Z, a-z, 0-9,.,#]" };
            vld.Msj = new string[6] { "Solo digitos numericos, tomar\nen cuenta tambien el formato valido\n(depto + municipio) (año) (tomo+folio)" ,"Solo caracteres", "Solo caracteres", "Solo digitos numericos y que empiecen por 2,3,8 y 9", "solo emails validos: example@dominio.algo", "Caracteres especiales no validos" };
            
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            definicionarray();
            if (vld.Comprobar_Txt() == true && cmb_Depto.SelectedIndex != -1 && vld.Validar_Letrascorreos(txt_Email, erp_email) == true && vld.Buscar_Repetidos(txt_Tel, erp_telefono) == true)
            {
                if (actualizar == true)
                {
                    cli.Id_Cliente = int.Parse(txt_id.Text.ToString());
                    cli.Id_Depto = int.Parse(cmb_Depto.SelectedValue.ToString());
                    cli.identidad_Cliente = txt_Ident.Text;
                    cli.Nombre_Cliente = txt_Nombre.Text;
                    cli.Apellido_Cliente = txt_Apell.Text;
                    cli.Telefono_Cliente = txt_Tel.Text;
                    cli.Correo_Electronico = txt_Email.Text;
                    cli.Direccion_Cliente = txt_Direccion.Text;

                    if (cli.Actualizar_Datos())
                    {
                        Btn_Guardar.Text = "Guardar";
                        dgv_datos.DataSource = sql.Consulta("select * from Clientes where estado_cliente=1");
                        Operaciones_Datagrid();
                        Limpiado_Clientes();
                    }
                }
                else
                {
                    cli.Id_Depto = int.Parse(cmb_Depto.SelectedValue.ToString());
                    cli.identidad_Cliente = txt_Ident.Text;
                    cli.Nombre_Cliente = txt_Nombre.Text;
                    cli.Apellido_Cliente = txt_Apell.Text;
                    cli.Telefono_Cliente = txt_Tel.Text;
                    cli.Correo_Electronico = txt_Email.Text;
                    cli.Direccion_Cliente = txt_Direccion.Text;

                    if (cli.Guardar_Cliente())
                    {
                        Btn_Guardar.Text = "Guardar";
                        dgv_datos.DataSource = sql.Consulta("select * from Clientes where estado_cliente=1");
                        Operaciones_Datagrid();
                        Limpiado_Clientes();
                    }
                }               
            }
            else
            {
                frm_notificacion noti = new frm_notificacion("Error, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                escoger_erp();
                if (vld.Validar_Letrascorreos(txt_Email, erp_email) == true) ;
                if (vld.Buscar_Repetidos(txt_Tel, erp_telefono) == true) ;
            }              
        }

        private void Escoger_Erp()
        {
            if (cmb_Depto.SelectedIndex == -1)
            {
                erp_depto.Clear();
                erp_depto.SetError(cmb_Depto, "No puede quedar vacio");
            }
        }

        private void frm_clientes_Load(object sender, EventArgs e)
        {
            dgv_datos.DataSource = sql.Consulta("select * from Clientes where estado_cliente=1");
            Operaciones_Datagrid();
            Inicializar_Combobox();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (dgv_datos.CurrentRow == null)
            {
                frm_notificacion noti = new frm_notificacion("Escoja algo antes para poder modificarlo", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                Inicializar_Combobox();
                txt_id.Text = dgv_datos.CurrentRow.Cells[0].Value.ToString();
                cmb_Depto.SelectedValue = dgv_datos.CurrentRow.Cells[1].Value.ToString();
                txt_Ident.Text = dgv_datos.CurrentRow.Cells[2].Value.ToString();
                txt_Nombre.Text = dgv_datos.CurrentRow.Cells[3].Value.ToString();
                txt_Apell.Text = dgv_datos.CurrentRow.Cells[4].Value.ToString();
                txt_Tel.Text = dgv_datos.CurrentRow.Cells[5].Value.ToString();
                txt_Email.Text = dgv_datos.CurrentRow.Cells[6].Value.ToString();
                txt_Direccion.Text = dgv_datos.CurrentRow.Cells[7].Value.ToString();
                actualizar = true;
                Btn_Guardar.Text = "Actualizar";
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if(dgv_datos.CurrentRow != null)
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea eliminar este cliente?", 2);
                noti.ShowDialog();

                if (noti.Dialogresul == DialogResult.OK)
                {
                    noti.Close();
                    cli.Id_Cliente = int.Parse(dgv_datos.CurrentRow.Cells[0].Value.ToString());
                    cli.Eliminar_Datos();
                    dgv_datos.DataSource = sql.Consulta("select * from Clientes where estado_cliente=1");
                    Operaciones_Datagrid();
                }                
            }
            else
            {
                frm_notificacion noti = new frm_notificacion("Debe selecionar algo antes de eliminar", 3);
                noti.ShowDialog();
                noti.Close();
            }            
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            Limpiado_Clientes();
            Btn_Guardar.Text = "Guardar";
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            cli.Nombre_Cliente = txt_buscar.Text;
            cli.Buscar_Datos(dgv_datos);
            operacionesDataGrid();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private async void btn_imprimir_Click(object sender, EventArgs e)
        {
            Btn_Imprimir.Enabled = false;
            frm_notificacion noti = new frm_notificacion("", 4);
            noti.Show();

            Task tar1 = new Task(Reporte_Clientes);
            tar1.Start();
            await tar1;

            noti.Close();
            Btn_Imprimir.Enabled = true;

            Formularios.frm_principal frm = Application.OpenForms.OfType<Formularios.frm_principal>().SingleOrDefault();
            frm.abrirPdfs(new frm_Usuarios()); //abrimos el pdf
            frm.BringToFront();
        }

        public void Reporte_Clientes()
        {
            rep.Cadena_consulta = " select (c.nombre_cliente +' '+ c.Apellido) as [Cliente], c.Identidad, c.Telefono, c.Direccion, c.[Correo Electronico], d.[Nombre Depto] " +
                "from Clientes as c inner join Departamentos as D  on D.[ID Depto] = c.[ID Depto] Where Estado = 1";
            rep.Carpeta = "Clientes";
            rep.Cabecera = new string[6] { "Nombre del Cliente", "Identidad", "Telefono", "Direccion", "Correo Electronico","Departamento"};
            rep.Tamanios = new float[6] { 8, 4, 3, 8, 5, 3 };
            rep.Titulo = "Reporte de Clientes";
            rep.Fecha = DateTime.Now.ToShortDateString();
            rep.Vertical = false;
            rep.GenerarPdf();       
        }

        #region keypress              

        private void txt_Ident_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txt_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void txt_Apell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void txt_Tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void cmb_Depto_SelectedIndexChanged(object sender, EventArgs e)
        {
            erp_depto.Clear();
        }

        private void txt_Ident_TextChanged(object sender, EventArgs e)
        {
            erp_identidad.Clear();
        }

        private void txt_Nombre_TextChanged(object sender, EventArgs e)
        {
            erp_nombre.Clear();
        }

        private void txt_Apell_TextChanged(object sender, EventArgs e)
        {
            erp_apellido.Clear();
        }

        private void txt_Tel_TextChanged(object sender, EventArgs e)
        {
            erp_telefono.Clear();
        }

        private void txt_Email_TextChanged(object sender, EventArgs e)
        {
            erp_email.Clear();
        }

        private void txt_Direccion_TextChanged(object sender, EventArgs e)
        {
            erp_direccion.Clear();
        }

        #endregion

        private void txt_Direccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Btn_Guardar.PerformClick();
            }
        }
    }
}
