using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using objExcel = Microsoft.Office.Interop.Excel;


namespace Repuestos_Arias.Formularios
{
    public partial class frm_MarcasCategorias : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
                        
        bool editar = false;
        int reporte;

        public frm_MarcasCategorias(int valor)
        {          
            InitializeComponent();

            if (valor == 1)
            {
                lbl_titulo.Text = "CATEGORIAS";
                btn_guardar.Click += btn_guardarCategorias;
                txt_buscar.TextChanged += txt_buscarCategorias_TextChanged;
                btn_editar.Click += btn_editarCategorias_Click;
                btn_eliminar.Click += btn_eliminarCategorias_Click;               
                this.Text = "Categorias";
                reporte = 1;
            }
            else if (valor == 2)
            {
                lbl_titulo.Text = "MARCAS";
                btn_guardar.Click += btn_guardarMarcas;
                txt_buscar.TextChanged += txt_buscarMarcas_TextChanged;
                btn_editar.Click += btn_editarMarcas_Click;
                btn_eliminar.Click += btn_eliminarMarcas_Click;                
                this.Text = "Marcas";
                reporte = 2;
            }
        }

        private void frm_MarcasCategorias_Load(object sender, EventArgs e)
        {
                  
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        #region Botones del form

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            limpiarDatos();
            editar = false;
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void limpiarDatos()
        {
            txt_descripcion.Clear();
            txt_id.Clear();
            
        }

        private void operacionesDatagrid()
        {
            dgv_datos.Columns[0].Visible = false;
            dgv_datos.Columns[1].Width = 230;
            dgv_datos.ClearSelection();
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ruta = saveFileDialog1.FileName;
                objExcel.Application objAplicacion = new objExcel.Application();
                Workbook objLibro = objAplicacion.Workbooks.Add(XlSheetType.xlWorksheet);
                Worksheet objHoja = (Worksheet)objAplicacion.ActiveSheet;

                objAplicacion.Visible = false;//si es true se abrira automaticamente si es false no se abrira              

                //creacion de la hoja de calculo                   
                foreach (DataGridViewColumn columna in dgv_datos.Columns)
                {
                    objHoja.Cells[1, columna.Index+1] = columna.HeaderText;                   

                    foreach (DataGridViewRow fila in dgv_datos.Rows)
                    {
                        objHoja.Cells[fila.Index+2, columna.Index + 1] = fila.Cells[columna.Index].Value;                        
                    }
                }

                //guardado del libro
                objLibro.SaveAs(ruta);
                objLibro.Close();
                objAplicacion.Quit();
                frm_notificacion noti = new frm_notificacion("Se ha guardado el excel con los datos", 1);
                noti.ShowDialog();
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            frm_reportes rep = new frm_reportes(reporte);
            rep.Show();
        }

        #endregion

        #region Categorias Botones
        private void btn_guardarCategorias (object sender, EventArgs e)
        {
            if (txt_descripcion.Text == "" )
            {                
                frm_notificacion noti = new frm_notificacion("Llene todos los datos antes de guardar", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
               
                btn_guardar.Text="Guardar";
            }           
        }

        private void txt_buscarCategorias_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_editarCategorias_Click(object sender, EventArgs e)
        {
            if (dgv_datos.CurrentRow == null)
            {
                frm_notificacion noti = new frm_notificacion("Escoja algo antes para poder modificarlo", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                txt_id.Text = dgv_datos.CurrentRow.Cells[0].Value.ToString();                
                txt_descripcion.Text = dgv_datos.CurrentRow.Cells[2].Value.ToString();
                editar = true;
                btn_guardar.Text = "Actualizar";
            }
        }

        private void btn_eliminarCategorias_Click(object sender, EventArgs e)
        {
            if (dgv_datos.CurrentRow == null)
            {
                frm_notificacion noti = new frm_notificacion("Escoja algo antes", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea eliminar esta categoria?", 2);
                noti.ShowDialog();

                if (noti.Dialogresul == DialogResult.OK)
                {
                    
                }
                noti.Close();
            }                        
        }
        #endregion

        #region Marcas Botones
        private void btn_guardarMarcas(object sender, EventArgs e)
        {
            if (txt_descripcion.Text == "" )
            {
                frm_notificacion noti = new frm_notificacion("Llene todos los datos antes de guardar", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                
                btn_guardar.Text = "Guardar";
            }
        }

        private void txt_buscarMarcas_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_editarMarcas_Click(object sender, EventArgs e)
        {
            if (dgv_datos.CurrentRow == null)
            {
                frm_notificacion noti = new frm_notificacion("Escoja algo antes para poder modificarlo", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                txt_id.Text = dgv_datos.CurrentRow.Cells[0].Value.ToString();
                txt_descripcion.Text = dgv_datos.CurrentRow.Cells[2].Value.ToString();
                editar = true;
                btn_guardar.Text = "Actualizar";
            }
        }

        private void btn_eliminarMarcas_Click(object sender, EventArgs e)
        {
            if (dgv_datos.CurrentRow == null)
            {
                frm_notificacion noti = new frm_notificacion("Escoja algo antes", 3);
                noti.ShowDialog();
                noti.Close();
            }
            else
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea eliminar esta Marca?", 2);
                noti.ShowDialog();

                if (noti.Dialogresul == DialogResult.OK)
                {
                   
                }

                noti.Close();
            }
        }
        #endregion        
    }
}
