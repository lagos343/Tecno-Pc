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
    public partial class frm_productos : Form
    {
        Clases.Cl_Productos prod = new Clases.Cl_Productos();
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_UsuarioLogueado login = new Clases.Cl_UsuarioLogueado();
        Clases.Cl_Reportes rep = new Clases.Cl_Reportes();

        public frm_productos()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
            this.toolTip1.SetToolTip(this.btn_nuevoProducto, "Agregar Producto");
            this.toolTip1.SetToolTip(this.txt_buscar, "Buscar");
            this.toolTip1.SetToolTip(this.btn_Imprimir, "Crear Reporte");
            this.toolTip1.SetToolTip(this.btn_categorias, "Gestionar Categorias");
            this.toolTip1.SetToolTip(this.btn_Marcas, "Gestionar Marcas");
        }

        private void frm_productos_Load(object sender, EventArgs e)
        {
            Dashboard();
            Usuario_Productos();
        }

        public void Dashboard()
        {
            lbl_totalProductos.Text = sql.Consulta("select *from Productos where estado_producto = 1").Rows.Count.ToString();
            lbl_totalMarcas.Text = sql.Consulta("select *from Marcas").Rows.Count.ToString();
            lbl_TotalCategorias.Text = sql.Consulta("select *from Categorias").Rows.Count.ToString();
            lbl_ProductosTotales.Text = sql.Consulta2("select sum(stock_producto) as Stock from Inventarios i inner join Productos p on p.[id_producto] = i.[id_producto] where p.estado_producto = 1");

            prod.consultarDatos(dgv_Productos);

            foreach (DataGridViewColumn columna in dgv_Productos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            Operaciones_DataGrid();
        }

        public void Operaciones_DataGrid()        
        {            
            dgv_Productos.Columns[2].Visible = false;
            dgv_Productos.Columns[3].Visible = false;
            dgv_Productos.Columns[4].Visible = false;
            dgv_Productos.Columns[5].Visible = false;
            dgv_Productos.Columns[9].Visible = false;
            dgv_Productos.Columns[10].Visible = false;
            dgv_Productos.Columns[0].Width = 50;
            dgv_Productos.Columns[1].Width = 50;

            dgv_Productos.Columns[6].HeaderText = "Producto";
            dgv_Productos.Columns[7].HeaderText = "Modelo";
            dgv_Productos.Columns[8].HeaderText = "Precio";
            dgv_Productos.Columns[11].HeaderText = "Stock";
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
            prod.Nombre_Producto = txt_buscar.Text;
            prod.buscarDatos(dgv_Productos);
            Operaciones_DataGrid();
        }

        private void btn_nuevoProducto_Click(object sender, EventArgs e)
        {
            frm_AñadirProductos prod = new frm_AñadirProductos(1, dgv_Productos);
            prod.ShowDialog();            
        }

        private void dgv_Productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_Productos.Rows[e.RowIndex].Cells["Editar"].Selected)
                {
                    frm_AñadirProductos aña = new frm_AñadirProductos(2, dgv_Productos);
                    aña.ShowDialog();
                }
                else if (dgv_Productos.Rows[e.RowIndex].Cells["Eliminar"].Selected)
                {
                    Formularios.frm_notificacion noti = new Formularios.frm_notificacion("¿Desea eliminar este producto?", 2);
                    noti.ShowDialog();

                    if (noti.Dialogresul == DialogResult.OK)
                    {
                        prod.IDProducto = int.Parse(dgv_Productos.CurrentRow.Cells[2].Value.ToString());
                        prod.eliminarDatos();
                    }

                    Dashboard();
                    noti.Close();
                }
            }
            catch (Exception ex){}            
        }

        private async void btn_Imprimir_Click(object sender, EventArgs e)
        {
            btn_Imprimir.Enabled = false;
            frm_notificacion noti = new frm_notificacion("", 4);
            noti.Show();

            Task tar1 = new Task(Reporte_Productos);
            tar1.Start();
            await tar1;

            noti.Close();
            btn_Imprimir.Enabled = true;

            Formularios.frm_principal frm = Application.OpenForms.OfType<Formularios.frm_principal>().SingleOrDefault();
            frm.abrirPdfs(new frm_productos()); //abrimos el pdf
        }

        private void Reporte_Productos()
        {
            rep.Cadena_consulta = "select p.[nombre_producto], p.modelo_producto, CAST(p.[precio_unitario] AS decimal(9,2)), c.[nombre_categoria], m.[nombre_marca], pr.nombre_proveedor, " +
                "(select stock_producto from Inventarios Where [id_producto] = p.[id_producto]) as Stock, cod_barra from Productos p " +
                "inner join Categorias c on c.[id_categoria] = p.[id_categoria] inner join Marcas m on m.[id_marca] = p.[id_marca] inner join Proveedores pr on " +
                "pr.[id_proveedor] = p.[id_proveedor] where p.estado_producto = 1";
            rep.Cabecera =  new string[8] { "Producto", "Modelo", "Precio", "Categoria", "Marca", "Proveedor", "Stock", "Codigo de Barras"};
            rep.Titulo = "Reporte de inventarios de Productos";
            rep.Tamanios = new float[8] {6, 4, 3, 4, 4, 6, 2, 4};
            rep.Carpeta = "Productos";
            rep.Fecha = DateTime.Now.ToShortDateString();
            rep.Vertical = false;
            rep.GenerarPdf();
        }        

        private void Usuario_Productos()
        {
            if(login.Id_Rol == 2)
            {
                btn_nuevoProducto.Hide();
                btn_Imprimir.Hide();
                dgv_Productos.Columns[0].Visible = false;
                dgv_Productos.Columns[1].Visible = false;
                btn_Marcas.Hide();
                btn_categorias.Hide();
            }
        }
    }
}
