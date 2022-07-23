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
        //Importacion de libreias propias de windows para movimiento del formulario  
        bool actualizar = false;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //definicion de objetos de las clases necesarias
        Clases.Cl_Clientes cli = new Clases.Cl_Clientes();
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Validacion vld = new Clases.Cl_Validacion();
        Clases.Cl_Reportes rep = new Clases.Cl_Reportes();


        public frm_clientes()
        {
            InitializeComponent();
            InicializarCombobox();

            //definicion de la ayuda visual con tooltip
            this.ttMensaje.SetToolTip(this.cmb_Depto, "Combobox de departamento");
            this.ttMensaje.SetToolTip(this.txt_Ident, "Caja de texto del No. de Identidad del Cliente");
            this.ttMensaje.SetToolTip(this.txt_Nombre, "Caja de texto del Nombre del Cliente");
            this.ttMensaje.SetToolTip(this.txt_Apell, "Caja de texto del Apellido del Cliente");
            this.ttMensaje.SetToolTip(this.txt_Tel, "Caja de texto del Telefono del Cliente");
            this.ttMensaje.SetToolTip(this.txt_Email, "Caja de texto del Correo del Cliente");
            this.ttMensaje.SetToolTip(this.txt_Direccion, "Caja de texto de la Direccion del Cliente");
            this.ttMensaje.SetToolTip(this.txt_buscar, "Caja de texto de busqueda filtrada por Nombre");
            this.ttMensaje.SetToolTip(this.btn_imprimir, "Boton para exportar reporte de Clientes");
            this.ttMensaje.SetToolTip(this.btn_salir, "Salir");
            this.ttMensaje.SetToolTip(this.btn_minimizar, "Minimizar");
            this.ttMensaje.SetToolTip(this.btn_nuevo, "Boton para Limpiar las cajas de texto");
            this.ttMensaje.SetToolTip(this.btn_editar, "Boton para Editar la informacion del Cliente");
            this.ttMensaje.SetToolTip(this.btn_eliminar, "Boton para Eliminar la informacion del Cliente");
            this.ttMensaje.SetToolTip(this.btn_guardar, "Boton para Guardar informacion del Cliente");
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void Limnpiado()
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

        public void operacionesDataGrid() //prod que se encarga de ocultar columnas y dar apariencia a el Datagrid de los clientes
        {
            dgv_datos.Columns[0].Visible = false;
            dgv_datos.Columns[1].Visible = false;
            dgv_datos.Columns[7].Visible = false;
            dgv_datos.Columns[8].Visible = false;
            dgv_datos.Columns[2].Width = 100;
            dgv_datos.Columns[5].Width = 80;
        }


        public void InicializarCombobox() //llena los combobox desde la DB e indica el valor desplegado y el valor de selecion
        {
            cmb_Depto.DataSource = sql.Consulta("select *from Departamentos order by [nombre_depto] asc");
            cmb_Depto.DisplayMember = "nombre_depto";
            cmb_Depto.ValueMember = "id_depto";
            cmb_Depto.SelectedIndex = -1;
        }

        public void definicionarray() //define las propiedades enviadas a la clase de Validaciones mediante Arrays con todos los Textbox y sus correspondientes expresiones regulares
        {
            vld.Text = new TextBox [6] { txt_Ident, txt_Nombre, txt_Apell, txt_Tel, txt_Email, txt_Direccion };
            vld.Error = new ErrorProvider[6] { erp_identidad,erp_nombre, erp_apellido, erp_telefono, erp_email, erp_direccion  };
            vld.Minimo = new int[6] { 13,2, 2, 8, 10, 3};
            vld.Regular = new string[6] { "(0[1-9]|1[0-8])(0[1-9]|1[0-9]|2[0-8])[0-9]{4}[0-9]{5}","[A-Z, a-z]", "[A-Z, a-z]", "(2|3|8|9)[ -]*([0-9]*)",
                "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$",
                "[A-Z, a-z, 0-9,.,#]" };
            vld.Msj = new string[6] { "Solo digitos numericos, tomar\nen cuenta tambien el formato valido\n(depto + municipio) (año) (tomo+folio)" ,"Solo caracteres", "Solo caracteres", "Solo digitos numericos y que empiecen por 2,3,8 y 9", "solo emails validos: example@dominio.algo", "Caracteres especiales no validos" };
            
        }

        private void btn_guardar_Click(object sender, EventArgs e) //proceso subrogado que usara el boton cuando requiramos guardar
        {
            definicionarray();
            if (vld.comprobartxt() == true && cmb_Depto.SelectedIndex != -1 && vld.ValidarLetrasCorreos(txt_Email, erp_email) == true && vld.buscarRepetidos(txt_Tel, erp_telefono) == true)
            {
                if (actualizar == true) //verificamos si vamos a guardar o actulizar
                {
                    cli.IDCliente = int.Parse(txt_id.Text.ToString());
                    cli.IDDepto = int.Parse(cmb_Depto.SelectedValue.ToString());
                    cli.identidad = txt_Ident.Text;
                    cli.Nombree = txt_Nombre.Text;
                    cli.Apellidoo = txt_Apell.Text;
                    cli.Telefonoo = txt_Tel.Text;
                    cli.CorreoElectronicoo = txt_Email.Text;
                    cli.Direccionn = txt_Direccion.Text;

                    if (cli.actualizarDatos()) //verificamos que no devuelva error el comando sql
                    {
                        btn_guardar.Text = "Guardar";
                        dgv_datos.DataSource = sql.Consulta("select * from Clientes where estado_cliente=1");
                        operacionesDataGrid();
                        Limnpiado();
                    }
                }
                else
                {
                    cli.IDDepto = int.Parse(cmb_Depto.SelectedValue.ToString());
                    cli.identidad = txt_Ident.Text;
                    cli.Nombree = txt_Nombre.Text;
                    cli.Apellidoo = txt_Apell.Text;
                    cli.Telefonoo = txt_Tel.Text;
                    cli.CorreoElectronicoo = txt_Email.Text;
                    cli.Direccionn = txt_Direccion.Text;

                    if (cli.guardar()) //verificamos que no devuelva error el comando sql
                    {
                        btn_guardar.Text = "Guardar";
                        dgv_datos.DataSource = sql.Consulta("select * from Clientes where estado_cliente=1");
                        operacionesDataGrid();
                        Limnpiado();
                    }
                }               
            }
            else
            {
                //mostramos los errores
                frm_notificacion noti = new frm_notificacion("Error, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                escoger_erp();
                if (vld.ValidarLetrasCorreos(txt_Email, erp_email) == true) ;
                if (vld.buscarRepetidos(txt_Tel, erp_telefono) == true) ;
            }              
        }

        private void escoger_erp() //muestra los errores que puedan ocurrir en los combobox
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
            operacionesDataGrid();
            InicializarCombobox();
        }

        private void btn_editar_Click(object sender, EventArgs e) //prod que llena los campos con el registro seleccionado para editar su informacion 
        {
            if (dgv_datos.CurrentRow == null) 
            {
                frm_notificacion noti = new frm_notificacion("Escoja algo antes para poder modificarlo", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                InicializarCombobox();
                txt_id.Text = dgv_datos.CurrentRow.Cells[0].Value.ToString();
                cmb_Depto.SelectedValue = dgv_datos.CurrentRow.Cells[1].Value.ToString();
                txt_Ident.Text = dgv_datos.CurrentRow.Cells[2].Value.ToString();
                txt_Nombre.Text = dgv_datos.CurrentRow.Cells[3].Value.ToString();
                txt_Apell.Text = dgv_datos.CurrentRow.Cells[4].Value.ToString();
                txt_Tel.Text = dgv_datos.CurrentRow.Cells[5].Value.ToString();
                txt_Email.Text = dgv_datos.CurrentRow.Cells[6].Value.ToString();
                txt_Direccion.Text = dgv_datos.CurrentRow.Cells[7].Value.ToString();
                actualizar = true;
                btn_guardar.Text = "Actualizar";
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e) //prod que oculta registros y actuliza su estado a inactivos
        {
            if(dgv_datos.CurrentRow != null)
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea eliminar este cliente?", 2);
                noti.ShowDialog();

                if (noti.Dialogresul == DialogResult.OK) //si presionamos ok se oculta el registro
                {
                    noti.Close();
                    cli.IDCliente = int.Parse(dgv_datos.CurrentRow.Cells[0].Value.ToString());
                    cli.eliminarDatos();
                    dgv_datos.DataSource = sql.Consulta("select * from Clientes where estado_cliente=1");
                    operacionesDataGrid();
                }                
            }
            else
            {
                frm_notificacion noti = new frm_notificacion("Debe selecionar algo antes de eliminar", 3);
                noti.ShowDialog();
                noti.Close();
            }            
        }

        private void btn_nuevo_Click(object sender, EventArgs e) //se encarga de limpiar la cajas de texto y reiniciar el form para añadir un nuevo registro
        {
            Limnpiado();
            btn_guardar.Text = "Guardar";
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e) //se encarga de relizar as busqueda filtradas que se cargaran el el datagrid
        {
            cli.Nombree = txt_buscar.Text;
            cli.buscarDatos(dgv_datos);
            operacionesDataGrid();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //llamado de las librerias ddl para mover el form desde este panel
        }

        private async void btn_imprimir_Click(object sender, EventArgs e)
        {
            btn_imprimir.Enabled = false;
            frm_notificacion noti = new frm_notificacion("", 4);
            noti.Show();

            Task tar1 = new Task(ReporteClientes);//llamaos el subproceso en base a el prod que abre el reporte
            tar1.Start();
            await tar1;

            noti.Close();
            btn_imprimir.Enabled = true;

            Formularios.frm_principal frm = Application.OpenForms.OfType<Formularios.frm_principal>().SingleOrDefault();
            frm.abrirPdfs(new frm_Usuarios()); //abrimos el pdf
            frm.BringToFront();
        }

        public void ReporteClientes() //prod que genera el reporte 
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
                btn_guardar.PerformClick();
            }
        }
    }
}
