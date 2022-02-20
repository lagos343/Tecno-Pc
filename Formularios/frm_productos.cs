﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using objExcel = Microsoft.Office.Interop.Excel;

namespace Tecno_Pc.Formularios
{
    public partial class frm_productos : Form
    {
        Clases.Cl_Productos prod = new Clases.Cl_Productos();
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();

        public frm_productos()
        {
            InitializeComponent();
        }

        private void frm_productos_Load(object sender, EventArgs e)
        {
            Dashboard();
        }

        public void Dashboard()
        {
            lbl_totalProductos.Text = sql.Consulta("select *from Productos where Estado = 1").Rows.Count.ToString();
            lbl_totalMarcas.Text = sql.Consulta("select *from Marcas").Rows.Count.ToString();
            lbl_TotalCategorias.Text = sql.Consulta("select *from Categorias").Rows.Count.ToString();
            lbl_ProductosTotales.Text = sql.Consulta2("select sum(Stock) as Stock from Inventarios");

            prod.consultarDatos(dgv_Productos);            
            operacionesDataGrid();
        }

        public void operacionesDataGrid()        
        {            
            dgv_Productos.Columns[2].Visible = false;
            dgv_Productos.Columns[3].Visible = false;
            dgv_Productos.Columns[4].Visible = false;
            dgv_Productos.Columns[5].Visible = false;
            dgv_Productos.Columns[9].Visible = false;

            dgv_Productos.Columns[0].Width = 50;
            dgv_Productos.Columns[1].Width = 50;            
        }

        private void btn_categorias_Click(object sender, EventArgs e)
        {
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_MarcasCategorias);
            if (frm == null)
            {
                frm_MarcasCategorias catego = new frm_MarcasCategorias(1);
                catego.Show();
            }
            else
            {
                frm.BringToFront();
            }                                 
        }

        private void btn_Marcas_Click(object sender, EventArgs e)
        {
            Form frm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_MarcasCategorias);
            if (frm == null)
            {
                frm_MarcasCategorias marcas = new frm_MarcasCategorias(2);
                marcas.Show();
            }
            else
            {
                frm.BringToFront();
            }                    
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            prod.NombreProducto = txt_buscar.Text;
            prod.buscarDatos(dgv_Productos);
            operacionesDataGrid();
        }

        private void btn_nuevoProducto_Click(object sender, EventArgs e)
        {
            frm_AñadirProductos prod = new frm_AñadirProductos(1, dgv_Productos);
            prod.ShowDialog();
            
        }

        private void dgv_Productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Productos.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                frm_AñadirProductos aña = new frm_AñadirProductos(2, dgv_Productos);
                aña.ShowDialog();
                

            } else if (dgv_Productos.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea eliminar este producto?", 2);
                noti.ShowDialog();

                if (noti.Dialogresul == DialogResult.OK)
                {
                    prod.IDProducto = int.Parse(dgv_Productos.CurrentRow.Cells[2].Value.ToString());
                    prod.eliminarDatos();
                }

                noti.Close();
            }
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            frm_reportes repo = new frm_reportes(3);
            repo.Show();
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ruta = saveFileDialog1.FileName;
                objExcel.Application objAplicacion = new objExcel.Application();
                Workbook objLibro = objAplicacion.Workbooks.Add(XlSheetType.xlWorksheet);
                Worksheet objHoja = (Worksheet)objAplicacion.ActiveSheet;

                objAplicacion.Visible = false;//si es true se abrira automaticamente si es false no se abrira              

                //creacion de la hoja de calculo                   
                foreach (DataGridViewColumn columna in dgv_Productos.Columns)
                {
                    objHoja.Cells[1, columna.Index + 1] = columna.HeaderText;

                    foreach (DataGridViewRow fila in dgv_Productos.Rows)
                    {
                        objHoja.Cells[fila.Index + 2, columna.Index + 1] = fila.Cells[columna.Index].Value;
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
    }
}
