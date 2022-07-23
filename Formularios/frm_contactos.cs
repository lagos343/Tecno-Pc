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
    public partial class frm_contactos : Form
    {
        //Importacion de libreias propias de windows para movimiento del formulario  
        bool actualizar = false;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //definicion de objetos de las clases necesarias
        Clases.Cl_Contactos con = new Clases.Cl_Contactos();
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Reportes rep = new Clases.Cl_Reportes();
        Clases.Cl_Validacion vld = new Clases.Cl_Validacion();

        public frm_contactos()
        {
            InitializeComponent();
            Inicializar_Combobox();

            //definicion de la ayuda visual con tooltip
            this.toolTip1.SetToolTip(this.cmb_depto, "Combobox de departamento");
            this.toolTip1.SetToolTip(this.cmb_proveedor, "Combobox de proveedor");
            this.toolTip1.SetToolTip(this.txt_id, "Caja de texto del No. de Identidad del Contacto");
            this.toolTip1.SetToolTip(this.txt_nombre, "Caja de texto del Nombre del Contacto");
            this.toolTip1.SetToolTip(this.txt_apellido, "Caja de texto del Apellido del Contacto");
            this.toolTip1.SetToolTip(this.txt_telefono, "Caja de texto del Telefono del Contacto");
            this.toolTip1.SetToolTip(this.txt_email, "Caja de texto del Correo del Contacto");
            this.toolTip1.SetToolTip(this.txt_direccion, "Caja de texto de la Direccion del Contacto");
            this.toolTip1.SetToolTip(this.txt_buscar, "Caja de texto de busqueda filtrada por Contacto");
            this.toolTip1.SetToolTip(this.Btn_Imprimir, "Boton para exportar reporte de Contacto a Excel");
            this.toolTip1.SetToolTip(this.Btn_Salir, "Salir");
            this.toolTip1.SetToolTip(this.Btn_Minimizar, "Minimizar");
            this.toolTip1.SetToolTip(this.Btn_Nuevo, "Boton para Limpiar las cajas de texto");
            this.toolTip1.SetToolTip(this.Btn_Editar, "Boton para Editar la informacion del Contacto");
            this.toolTip1.SetToolTip(this.Btn_Eliminar, "Boton para Eliminar la informacion del Contacto");
            this.toolTip1.SetToolTip(this.Btn_Guardar, "Boton para Guardar informacion del Contacto");
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void Limnpiado_Contactos()
        {
            cmb_depto.SelectedIndex = -1;
            cmb_proveedor.SelectedIndex = -1;
            txt_id.Clear();
            txt_nombre.Clear();
            txt_apellido.Clear();
            txt_telefono.Clear();
            txt_email.Clear();
            txt_direccion.Clear();
            actualizar = false;
            erp_apellido.Clear();
            erp_depto.Clear();
            erp_direccion.Clear();
            erp_email.Clear();
            erp_nombre.Clear();
            erp_porveedor.Clear();
            erp_telefono.Clear();
        }

        public void Operaciones_Datagrid()  //prod que se encarga de ocultar columnas y dar apariencia a el Datagrid de los contactos
        {
            dgv_datos.Columns[0].Visible = false;
            dgv_datos.Columns[1].Visible = false;
            dgv_datos.Columns[2].Visible = false;
            dgv_datos.Columns[6].Visible = false;
            dgv_datos.Columns[8].Visible = false;
        }

        public void Inicializar_Combobox() //llena los combobox desde la DB e indica el valor desplegado y el valor de selecion
        {
            cmb_depto.DataSource = sql.Consulta("select *from Departamentos order by [nombre_depto] asc");
            cmb_depto.DisplayMember = "nombre_depto";
            cmb_depto.ValueMember = "id_depto";
            cmb_depto.SelectedIndex = -1;

            cmb_proveedor.DataSource = sql.Consulta("select * from Proveedores order by [nombre_proveedor] asc");
            cmb_proveedor.DisplayMember = "nombre_proveedor";
            cmb_proveedor.ValueMember = "id_proveedor";
            cmb_proveedor.SelectedIndex = -1;
        }

        public void Definicion_Array()  //define las propiedades enviadas a la clase de Validaciones mediante Arrays con todos los Textbox y sus correspondientes expresiones regulares
        {
            vld.Text = new TextBox [5] { txt_nombre, txt_apellido, txt_direccion,txt_telefono,txt_email };
            vld.Error = new ErrorProvider[5] {erp_nombre,erp_apellido, erp_direccion, erp_telefono, erp_email  };
            vld.Minimo = new int[5] { 2, 2 , 3, 8, 10 };
            vld.Regular = new string[5] { "[A-Z, a-z]", "[A-Z, a-z]", "[A-Z, a-z, 0-9,.,#]", "(2|3|8|9)[ -]*([0-9]*)",
                "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$" };
            vld.Msj = new string[5] {"Solo caracteres",  "Solo caracteres", "Caracteres especiales no validos", "Solo digitos numericos y que empiecen por 2,3,8 y 9",  "solo emails validos: example@dominio.algo" };

        }
                
        private void frm_contactos_Load(object sender, EventArgs e)
        {
            dgv_datos.DataSource = sql.Consulta(" select * from Contactos where estado_contacto=1");
            Operaciones_Datagrid();
            Inicializar_Combobox();
        }

        private void btn_nuevo_Click_1(object sender, EventArgs e) //se encarga de limpiar la cajas de texto y reiniciar el form para añadir un nuevo registro
        {
            Limnpiado_Contactos();
            Btn_Guardar.Text = "Guardar";
        }

        private void btn_guardar_Click_1(object sender, EventArgs e) //proceso subrogado que usara el boton cuando requiramos guardar
        {
            Definicion_Array();
            if (vld.Comprobar_Txt()==true && cmb_depto.SelectedIndex != -1 && cmb_proveedor.SelectedIndex != -1 && vld.Validar_Letrascorreos(txt_email, erp_email) == true && vld.Buscar_Repetidos(txt_telefono, erp_telefono) == true)
            {
                if (actualizar == true) //verificamos si vamos a guardar o actulizar
                {
                    con.Id_Contacto = int.Parse(txt_id.Text.ToString());
                    con.Id_Proveedor = int.Parse(cmb_proveedor.SelectedValue.ToString());
                    con.Id_Depto = int.Parse(cmb_depto.SelectedValue.ToString());
                    con.Nombre_Contacto = txt_nombre.Text;
                    con.Apellido_Contacto = txt_apellido.Text;
                    con.Telefono_Contacto = txt_telefono.Text;
                    con.Correo_Electronico = txt_email.Text;
                    con.Direccion_Contacto = txt_direccion.Text;

                    if (con.Actualizar_Datos()) //verificamos que no devuelva error el comando sql
                    {
                        Btn_Guardar.Text = "Guardar";
                        dgv_datos.DataSource = sql.Consulta("select * from Contactos where estado_contacto=1");
                        Operaciones_Datagrid();
                        Limnpiado_Contactos();
                    }
                }
                else
                {
                    con.Id_Proveedor = int.Parse(cmb_proveedor.SelectedValue.ToString());
                    con.Id_Depto = int.Parse(cmb_depto.SelectedValue.ToString());
                    con.Nombre_Contacto = txt_nombre.Text;
                    con.Apellido_Contacto = txt_apellido.Text;
                    con.Telefono_Contacto = txt_telefono.Text;
                    con.Correo_Electronico = txt_email.Text;
                    con.Direccion_Contacto = txt_direccion.Text;
                    con.Estado_Contacto = Convert.ToBoolean(true);

                    if (con.Guardar_Contacto()) //verificamos que no devuelva error el comando sql
                    {
                        Btn_Guardar.Text = "Guardar";
                        dgv_datos.DataSource = sql.Consulta("select * from Contactos where estado_contacto=1");
                        Operaciones_Datagrid();
                        Limnpiado_Contactos();
                    }
                }                
            }
            else
            {
                //mostramos los errores
                frm_notificacion noti = new frm_notificacion("Error, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                Escoger_Erp();
                if (vld.Validar_Letrascorreos(txt_email, erp_email) == true) ;
                if (vld.Buscar_Repetidos(txt_telefono, erp_telefono) == true) ;
            }
        }

        private void Escoger_Erp()  //muestra los errores que puedan ocurrir en los combobox
        {
            if (cmb_proveedor.SelectedIndex == -1)
            {
                erp_porveedor.Clear();
                erp_porveedor.SetError(cmb_proveedor, "No puede quedar vacio");
            }

            if (cmb_depto.SelectedIndex == -1)
            {
                erp_depto.Clear();
                erp_depto.SetError(cmb_depto, "No puede quedar vacio");
            }
        }

        
        private void btn_editar_Click_1(object sender, EventArgs e) //prod que llena los campos con el registro seleccionado para editar su informacion 
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
                cmb_depto.SelectedValue = dgv_datos.CurrentRow.Cells[2].Value.ToString();
                cmb_proveedor.SelectedValue = dgv_datos.CurrentRow.Cells[1].Value.ToString();
                txt_nombre.Text = dgv_datos.CurrentRow.Cells[3].Value.ToString();
                txt_apellido.Text = dgv_datos.CurrentRow.Cells[4].Value.ToString();
                txt_telefono.Text = dgv_datos.CurrentRow.Cells[5].Value.ToString();
                txt_email.Text = dgv_datos.CurrentRow.Cells[6].Value.ToString();
                txt_direccion.Text = dgv_datos.CurrentRow.Cells[7].Value.ToString();
                actualizar = true;
                Btn_Guardar.Text = "Actualizar";
            }
        }

        private void btn_eliminar_Click_1(object sender, EventArgs e) //prod que oculta registros y actuliza su estado a inactivos
        {
            if (dgv_datos.CurrentRow != null)
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea eliminar este contacto?", 2);
                noti.ShowDialog();

                if (noti.Dialogresul == DialogResult.OK) //si presionamos ok se oculta el registro
                {
                    con.Id_Contacto = int.Parse(dgv_datos.CurrentRow.Cells[0].Value.ToString());
                    con.Eliminar_Datos();
                    dgv_datos.DataSource = sql.Consulta(" select*from Contactos where estado_contacto=1");
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

        private void txt_buscar_TextChanged_1(object sender, EventArgs e) //se encarga de relizar as busqueda filtradas que se cargaran el el datagrid
        {
            con.Nombre_Contacto = txt_buscar.Text;
            con.Buscar_Datos(dgv_datos);
            Operaciones_Datagrid();
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //llamado de las librerias ddl para mover el form desde este panel
        }

        #region keypress

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void txt_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        
        private void cmb_proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            erp_porveedor.Clear();
        }

        private void cmb_depto_SelectedIndexChanged(object sender, EventArgs e)
        {
            erp_depto.Clear();
        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {
            erp_nombre.Clear();
        }

        private void txt_apellido_TextChanged(object sender, EventArgs e)
        {
            erp_apellido.Clear();
        }

        private void txt_telefono_TextChanged(object sender, EventArgs e)
        {
            erp_telefono.Clear();
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            erp_email.Clear();
        }

        private void txt_direccion_TextChanged(object sender, EventArgs e)
        {
            erp_direccion.Clear();
        }

        #endregion

        private async void btn_imprimir_Click(object sender, EventArgs e)
        {
            Btn_Imprimir.Enabled = false;
            frm_notificacion noti = new frm_notificacion("", 4);
            noti.Show();

            Task tar1 = new Task(Reporte_Contactos); //llamaos el subproceso en base a el prod que abre el reporte
            tar1.Start();
            await tar1;

            noti.Close();
            Btn_Imprimir.Enabled = true;

            Formularios.frm_principal frm = Application.OpenForms.OfType<Formularios.frm_principal>().SingleOrDefault();
            frm.abrirPdfs(new frm_proveedores()); //abrimos el pdf
            frm.BringToFront();
        }

        public void Reporte_Contactos() //prod que genera el reporte
        {
            rep.Cadena_consulta = "Select Contactos.nombre_contacto + ' ' + Contactos.apellido_contacto[Contacto], [Proveedores].nombre_proveedor[Proveedores], Departamentos.[nombre_depto][Departamento], " +
                "Contactos.telefono_contacto, Contactos.[correo_electronico], Contactos.direccion_contacto from Contactos INNER JOIN Departamentos ON Contactos.[id_depto] =" +
                "Departamentos.[id_depto] inner join Proveedores ON Contactos.[id_proveedor] = Proveedores.[id_proveedor] WHERE Contactos.estado_contacto = 1 ORDER BY Contacto ASC";
            rep.Cabecera = new string[6] { "Contacto", "Proveedor", "Departamento", "Telefono", "Correo Electrónico", "Dirección" };
            rep.Tamanios = new float[6] { 6, 5, 3, 2, 5, 8};
            rep.Titulo = "Reporte de Contactos";
            rep.Carpeta = "Contactos";
            rep.Fecha = DateTime.Now.ToShortDateString();
            rep.Vertical = false;
            rep.GenerarPdf();
        }

        private void txt_direccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Btn_Guardar.PerformClick();
            }
        }
    }       
}

    
