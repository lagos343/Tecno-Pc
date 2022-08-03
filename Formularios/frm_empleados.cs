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
    public partial class frm_empleados : Form
    {
        //definicion de objetos de las clases necesarias 
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Empleados empleados = new Clases.Cl_Empleados();
        Clases.Cl_Reportes rep = new Clases.Cl_Reportes();

        public frm_empleados()
        {
            InitializeComponent();
            //definicion de la ayuda visual con tooltip
            this.toolTip1.SetToolTip(this.btn_nuevoUsuario, "Agregar Empleado");
            this.toolTip1.SetToolTip(this.btn_reporte, "Crear Reporte");
            this.toolTip1.SetToolTip(this.txt_buscar, "Buscar");
        }

        private void btn_nuevoUsuario_Click(object sender, EventArgs e) //llamamos el formulario en modo nuevo registro
        {
            Form frm_nuevo = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_AñadirEmpleado);
            if (frm_nuevo == null)
            {
                frm_AñadirEmpleado añaem_nuevo = new frm_AñadirEmpleado(1, dgv_Productos);
                añaem_nuevo.Show();
            }
            else 
            {
                frm_nuevo.BringToFront();
            }
        }

        private void frm_empleados_Load(object sender, EventArgs e)
        {
            Carga_Empleado();
        }

        public void Carga_Empleado() //se encarga de llenar el datagrid con los registros de la tabla
        {
            empleados.Consultar_Datos(dgv_Productos);
            Operaciones_Data_Grid();
            foreach (DataGridViewColumn columna_data in dgv_Productos.Columns)
            {
                columna_data.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        private void Operaciones_Data_Grid() //prod que se encarga de ocultar columnas y dar apariencia a el Datagrid de los empleados
        {
            dgv_Productos.Columns[2].Visible = false;
            dgv_Productos.Columns[3].Visible = false;
            dgv_Productos.Columns[4].Visible = false;
            dgv_Productos.Columns[8].Visible = false;
            dgv_Productos.Columns[9].Visible = false;
            dgv_Productos.Columns[10].Visible = false;
            dgv_Productos.Columns[11].Visible = false;
            dgv_Productos.Columns[12].Visible = false;
            dgv_Productos.Columns[13].Visible = false;
            dgv_Productos.Columns[0].Width = 50;
            dgv_Productos.Columns[1].Width = 50;

            dgv_Productos.Columns[5].HeaderText = "Identidad";
            dgv_Productos.Columns[6].HeaderText = "Nombre";
            dgv_Productos.Columns[7].HeaderText = "Apellido";
        }

        private void txt_buscar_TextChanged(object sender_buscar, EventArgs e)//se encarga de relizar as busqueda filtradas que se cargaran el el datagrid
        {
            empleados.Nombre_Empleado = txt_buscar.Text;
            empleados.Buscar_Datos(dgv_Productos);
            Operaciones_Data_Grid();
            empleados.Nombre_Empleado = txt_buscar.Text;
            empleados.Buscar_Datos(dgv_Productos);
            Operaciones_Data_Grid();
            
        }


        private void dgv_Productos_CellContentClick_1(object sender_buscar, DataGridViewCellEventArgs index_e) //prod que verifica si tocamos el boton de editar o de eliminar
        {
            try
            {
                if (dgv_Productos.Rows[index_e.RowIndex].Cells["Editar"].Selected)
                {
                    //si es editar llamamos el formulario en modo actualizar y le pasamos la info del registro seleccionado
                    frm_AñadirEmpleado añaem_productos = new frm_AñadirEmpleado(2, dgv_Productos);
                    añaem_productos.ShowDialog();
                }
                else if (dgv_Productos.Rows[index_e.RowIndex].Cells["Eliminar"].Selected)
                {
                    //si es eliminar y presionamos ok procedera a deshabilitar el registro
                    Formularios.frm_notificacion noti_producto = new Formularios.frm_notificacion("¿Desea eliminar este empleado?", 2);
                    noti_producto.ShowDialog();

                    if (noti_producto.dialogs_resul == DialogResult.OK)
                    {
                        empleados.Id_Empleado = int.Parse(dgv_Productos.CurrentRow.Cells[2].Value.ToString());
                        empleados.Eliminar_Empleado();
                        #region Limpieza
                        lbl_id.Text = lbl_email.Text = "";
                        lbl_depto.Text = lbl_email.Text = "";
                        lbl_direccion.Text = lbl_email.Text = "";
                        lbl_puesto.Text = lbl_email.Text = "";
                        lbl_email.Text = "";
                        lbl_email.Text = "";
                        lbl_telefono.Text = "";
                        #endregion
                    }

                    noti_producto.Close();
                }
                else if (dgv_Productos.Rows[index_e.RowIndex].Cells["nombre_empleado"].Selected || dgv_Productos.Rows[index_e.RowIndex].Cells["identidad_empleado"].Selected || dgv_Productos.Rows[index_e.RowIndex].Cells["apellido_empleado"].Selected)
                {
                    //en caso de tocar cualquier otra columna, mostrara la informacion de este registro en los labels
                    lbl_id.Text = dgv_Productos.CurrentRow.Cells[6].Value.ToString();
                    lbl_depto.Text = dgv_Productos.CurrentRow.Cells[13].Value.ToString();
                    lbl_direccion.Text = dgv_Productos.CurrentRow.Cells[10].Value.ToString();
                    lbl_puesto.Text = dgv_Productos.CurrentRow.Cells[12].Value.ToString();
                    lbl_telefono.Text = dgv_Productos.CurrentRow.Cells[8].Value.ToString();
                    lbl_email.Text = dgv_Productos.CurrentRow.Cells[9].Value.ToString();

                }

            }
            catch(Exception ex_catch){}            
        }

        private void btn_reporte_Click(object sender_reporte, EventArgs e) //abre el form de reportes de esta pantalla
        {
            Form frm_reporte = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_ReportVendedor);

            if (frm_reporte == null)
            {
                frm_ReportVendedor report_report = new frm_ReportVendedor();
                report_report.Show();
            }
            else
            {
                frm_reporte.BringToFront();
            }
        }
    }         
}
