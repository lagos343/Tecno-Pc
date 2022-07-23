using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Formularios
{
    public partial class frm_proveedores : Form
    {
        //definicion de objetos de las clases necesarias 
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Proveedores proveedores = new Clases.Cl_Proveedores();
        Clases.Cl_Reportes rep = new Clases.Cl_Reportes();


        public frm_proveedores()
        {
            InitializeComponent();
            //definicion de la ayuda visual con tooltip
            this.toolTip1.SetToolTip(this.btn_contactos, "Gestionar Contactos");
            this.toolTip1.SetToolTip(this.btn_reporte, "Crear Reporte");
            this.toolTip1.SetToolTip(this.btn_nuevoUsuario, "Agregar Proveedor");
            this.toolTip1.SetToolTip(this.txt_buscar, "Buscar");

        }

        private void btn_nuevoUsuario_Click(object sender, EventArgs e) //llamamos el formulario en modo nuevo registro
        {
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_AñadirProveedores);

            if (frm == null)
            {
                frm_AñadirProveedores añapro = new frm_AñadirProveedores(1, dgv_Productos);
                añapro.Show();
            }
            else 
            {
                frm.BringToFront();
            }
        
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e) //llamamos el formulario en modo contactos
        {
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_contactos);
            if (frm == null)
            {
                frm_contactos contac = new frm_contactos();
                contac.Show();
            }
            else 
            {
                frm.BringToFront();
            }
        }

        private void frm_proveedores_Load(object sender, EventArgs e)
        {
            Carga_Proveedores();
        }

        public void Carga_Proveedores() //se encarga de llenar el datagrid con los registros de la tabla
        {
            proveedores.consultarDatos(dgv_Productos);
            Operaciones_Datarid();
            foreach (DataGridViewColumn columna in dgv_Productos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        private void Operaciones_Datarid() //prod que se encarga de ocultar columnas y dar apariencia a el Datagrid de los proveedores
        {
            dgv_Productos.Columns[2].Visible = false;
            dgv_Productos.Columns[3].Visible = false;
            dgv_Productos.Columns[5].Visible = false;
            dgv_Productos.Columns[6].Visible = false;
            dgv_Productos.Columns[7].Visible = false;
            dgv_Productos.Columns[8].Visible = false;
            dgv_Productos.Columns[9].Visible = false;

            dgv_Productos.Columns[0].Width = 50;
            dgv_Productos.Columns[1].Width = 50;

            dgv_Productos.Columns[4].HeaderText = "Nombre";
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e) //se encarga de relizar as busqueda filtradas que se cargaran el el datagrid
        {
            proveedores.Nombre = txt_buscar.Text;
            proveedores.buscarDatos(dgv_Productos);
            Operaciones_Datarid();
        }

        private void dgv_Productos_CellContentClick(object sender, DataGridViewCellEventArgs e) //prod que verifica si tocamos el boton de editar o de eliminar
        {
            try
            {
                if (dgv_Productos.Rows[e.RowIndex].Cells["Editar"].Selected)
                {
                    //si es editar llamamos el formulario en modo actualizar y le pasamos la info del registro seleccionado  
                    frm_AñadirProveedores añaem = new frm_AñadirProveedores(2, dgv_Productos);
                    añaem.ShowDialog();


                }
                else if (dgv_Productos.Rows[e.RowIndex].Cells["Eliminar"].Selected)
                {
                    //si es eliminar y presionamos ok procedera a deshabilitar el registro
                    Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea eliminar este proveedor?", 2);
                    noti.ShowDialog();

                    if (noti.Dialogresul == DialogResult.OK)
                    {
                        proveedores.IDProveedor = int.Parse(dgv_Productos.CurrentRow.Cells[2].Value.ToString());
                        proveedores.eliminar();
                        #region Limpieza
                        lbl_id.Text = "";
                        lbl_nombre.Text = "";
                        lbl_telefono.Text = "";
                        lbl_direccion.Text = "";
                        lbl_email.Text = "";
                        lbl_depto.Text = "";
                        #endregion
                    }

                    noti.Close();
                }
                else if (dgv_Productos.Rows[e.RowIndex].Cells["nombre_proveedor"].Selected)
                {
                    //en caso de tocar cualquier otra columna, mostrara la informacion de este registro en los labels
                    lbl_id.Text = dgv_Productos.CurrentRow.Cells[2].Value.ToString();
                    lbl_nombre.Text = dgv_Productos.CurrentRow.Cells[4].Value.ToString();
                    lbl_telefono.Text = dgv_Productos.CurrentRow.Cells[5].Value.ToString();
                    lbl_direccion.Text = dgv_Productos.CurrentRow.Cells[6].Value.ToString();
                    lbl_email.Text = dgv_Productos.CurrentRow.Cells[7].Value.ToString();
                    lbl_depto.Text = dgv_Productos.CurrentRow.Cells[9].Value.ToString();

                }
            }
            catch (Exception ex) { }
        }


        private void btn_reporte_Click(object sender, EventArgs e) //mostramos el form de los reportes 
        {
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_ReportProveedores);

            if (frm == null)
            {
                Frm_ReportProveedores report = new Frm_ReportProveedores();
                report.Show();
            }
            else
            {
                frm.BringToFront();
            }
        }        
    }
}
