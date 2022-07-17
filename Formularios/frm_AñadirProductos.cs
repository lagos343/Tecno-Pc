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
using BarcodeLib;

namespace Tecno_Pc.Formularios
{
    public partial class frm_AñadirProductos : Form
    {
        //Importacion de libreias propias de windows para movimiento del formulario  
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //definicion de objetos de las clases necesarias
        Clases.Cl_Productos prod = new Clases.Cl_Productos(); 
        Clases.Cl_SqlMaestra sql = new Clases.Cl_SqlMaestra();
        Clases.Cl_Validacion vld = new Clases.Cl_Validacion();

        public frm_AñadirProductos(int estado, DataGridView dat) //el contructor recibe dos parametros, el primeo indicara si lo abrimos en modo nuevo registro o en modo actualizacion
        {                                                        //el segundo recibe los datos del datagrid para llenar los campos en el modo actualizacion
        
            InitializeComponent();
            if (estado == 1)
            {
                lbl_titulo.Text = "NUEVO PRODUCTO";
                btn_guardar.Click += btn_guardarGuardado_Click; //definimos el proceso subrogado para que el boton relice el proceso de guardar
                InicializarCombobox();
            }
            else if (estado == 2)
            {
                InicializarCombobox();
                lbl_titulo.Text = "ACTUALIZAR PRODUCTO";
                btn_guardar.Text = "ACTUALIZAR";
                btn_guardar.Click += btn_guardarActualizado_Click; //definimos el proceso subrogado para que el boton relice el proceso de actualizar

                //llenado de los datos en cada control para luego hacer las modificaciones
                txt_id.Text = dat.CurrentRow.Cells[0+2].Value.ToString();
                cbo_marca.SelectedValue = dat.CurrentRow.Cells[2 + 2].Value.ToString();
                cbo_categoria.SelectedValue = dat.CurrentRow.Cells[1 + 2].Value.ToString();
                cbo_proveedor.SelectedValue = dat.CurrentRow.Cells[3 + 2].Value.ToString();
                txt_nombre.Text = dat.CurrentRow.Cells[4 + 2].Value.ToString();
                txt_modelo.Text = dat.CurrentRow.Cells[5 + 2].Value.ToString();
                txt_precio.Text = dat.CurrentRow.Cells[6 + 2].Value.ToString();
                swt_estado.Checked = Convert.ToBoolean(dat.CurrentRow.Cells[7 + 2].Value.ToString());
                txt_codBarra.Text = dat.CurrentRow.Cells[8 + 2].Value.ToString();
                txt_stock.Text = sql.Consulta2("Select stock_producto from Inventarios where [id_producto] = " + txt_id.Text);
                this.Text = "Actualizar Producto";
            }

            this.cbo_proveedor.SelectedIndexChanged += new System.EventHandler(this.cbo_proveedor_SelectedIndexChanged);
            this.cbo_categoria.SelectedIndexChanged += new System.EventHandler(this.cbo_categoria_SelectedIndexChanged);
            this.cbo_marca.SelectedIndexChanged += new System.EventHandler(this.cbo_marca_SelectedIndexChanged);
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        public void InicializarCombobox() //llena los combobox desde la DB e indica el valor desplegado y el valor de selecion
        {
            cbo_marca.DataSource = sql.Consulta("select *from Marcas order by [nombre_marca] asc");
            cbo_marca.DisplayMember = "nombre_marca";
            cbo_marca.ValueMember = "id_marca";
            cbo_marca.SelectedIndex = -1;

            cbo_categoria.DataSource = sql.Consulta("select *from Categorias order by [nombre_categoria] asc");
            cbo_categoria.DisplayMember = "nombre_categoria";
            cbo_categoria.ValueMember = "id_categoria";
            cbo_categoria.SelectedIndex = -1;

            cbo_proveedor.DataSource = sql.Consulta("select *from Proveedores where estado_proveedor = 1 order by nombre_proveedor asc");
            cbo_proveedor.DisplayMember = "nombre_proveedor";
            cbo_proveedor.ValueMember = "id_proveedor";
            cbo_proveedor.SelectedIndex = -1;
        }

        public void definicionarray() //define las propiedades enviadas a la clase de Validaciones mediante Arrays con todos los Textbox y sus correspondientes expresiones regulares 
        {
            vld.Text = new TextBox[5] {txt_codBarra, txt_modelo, txt_nombre, txt_precio, txt_stock};
            vld.Error = new ErrorProvider[5] {erp5, erp4, erp, erp2, erp3};
            vld.Minimo = new int[5] {12, 3, 4, 5, 1};
            vld.Regular = new string[5] {"[0-9]", "[A-Z, a-z, 0-9]", "[A-Z, a-z, 0-9]", "[0-9]{1,7}\\.[0-9]{1,4}", "[0-9]"};
            vld.Msj = new string[5] { "Solo digitos numericos", "Caracteres especiales no validos", "Solo caracteres", "Solo formatos de precio\nEjemplo: 1000000.00", "Solo digitos numericos"};
        }

        private void btn_guardarGuardado_Click(object sender, EventArgs e) // proceso subrogado que usara el boton cuando requiramos guardar
        {
            definicionarray();

            if (vld.comprobartxt() == true && cbo_categoria.SelectedIndex != -1 && cbo_marca.SelectedIndex != -1 && cbo_proveedor.SelectedIndex != -1 && int.Parse(txt_stock.Text) != 0 && float.Parse(txt_precio.Text) >= 10.00 )
            {
                prod.IDMarca = int.Parse(cbo_marca.SelectedValue.ToString());
                prod.IDCategoria = int.Parse(cbo_categoria.SelectedValue.ToString());
                prod.IDProveedor = int.Parse(cbo_proveedor.SelectedValue.ToString());
                prod.NombreProducto = txt_nombre.Text;
                prod.Modelo = txt_modelo.Text;
                prod.PrecioUnitario = Convert.ToDouble(txt_precio.Text);
                prod.Estado = Convert.ToBoolean(swt_estado.Checked);
                prod.Codbarra = txt_codBarra.Text;

                if (prod.guardar()) //verificamos que no devuelva error el comando sql
                {
                    sql.Sql_Querys("insert into Inventarios values((select top 1 [id_producto] from Productos order by[id_producto] desc), " + txt_stock.Text + ")"); //actualizamos inventarios
                    Limnpiado();
                }
            }
            else
            {
                frm_notificacion noti = new frm_notificacion("Error al guardar, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                escoger_erp();                                
            }

            Formularios.frm_productos frm = Application.OpenForms.OfType<Formularios.frm_productos>().SingleOrDefault();
            frm.Dashboard();
        }

        private void escoger_erp() //muestra los errores que puedan ocurrir en los combobox
        {           
            if (cbo_categoria.SelectedIndex == -1)
            {
                erp6.Clear();
                erp6.SetError(cbo_categoria, "Seleccione algo valido");
            }

            if (cbo_marca.SelectedIndex == -1)
            {
                erp7.Clear();
                erp7.SetError(cbo_marca, "Seleccione algo valido");
            }

            if (cbo_proveedor.SelectedIndex == -1)
            {
                erp8.Clear();
                erp8.SetError(cbo_proveedor, "Seleccione algo valido");
            }

            if (txt_stock.Text != string.Empty)
            {
                try
                {
                    if (int.Parse(txt_stock.Text) <= 0)
                    {
                        erp3.Clear();
                        erp3.SetError(txt_stock, "El stock debe ser mayor a 0");
                    }
                }
                catch (Exception){}                
            }
            
            if (txt_precio.Text != string.Empty)
            {
                try
                {
                    if (!(float.Parse(txt_precio.Text) >= 10.00))
                    {
                        erp2.Clear();
                        erp2.SetError(txt_precio, "El precio debe ser mayor\no igual a 10.00");
                    }
                }
                catch (Exception){}                
            }            
        }  

        private void btn_guardarActualizado_Click(object sender, EventArgs e) // proceso subrogado que usara el boton cuando requiramos actualizar
        {
            definicionarray();

            if (vld.comprobartxt() == true && cbo_categoria.SelectedIndex != -1 && cbo_marca.SelectedIndex != -1 && cbo_proveedor.SelectedIndex != -1 && int.Parse(txt_stock.Text) != 0 && float.Parse(txt_precio.Text) >= 10.00)
            {
                prod.IDProducto = int.Parse(txt_id.Text);
                prod.IDMarca = int.Parse(cbo_marca.SelectedValue.ToString());
                prod.IDCategoria = int.Parse(cbo_categoria.SelectedValue.ToString());
                prod.IDProveedor = int.Parse(cbo_proveedor.SelectedValue.ToString());
                prod.NombreProducto = txt_nombre.Text;
                prod.Modelo = txt_modelo.Text;
                prod.PrecioUnitario = Convert.ToDouble(txt_precio.Text);
                prod.Estado = swt_estado.Checked;
                prod.Codbarra = txt_codBarra.Text;

                if (prod.actualizarDatos()) //verifimacmos que no devuelva error el comando sql
                {
                    sql.Sql_Querys("update Inventarios set stock_producto = " + txt_stock.Text + " where [id_producto] = " + txt_id.Text); //actulizamos inventarios
                    this.Close();
                }                
            }
            else
            {
                frm_notificacion noti = new frm_notificacion("Error al actualizar, ¡Corrija todas las advertencias!", 3);
                noti.ShowDialog();
                noti.Close();
                escoger_erp();                                
            }

            Formularios.frm_productos frm = Application.OpenForms.OfType<Formularios.frm_productos>().SingleOrDefault();
            frm.Dashboard(); //recargar el form
        }        

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //llamado de las librerias ddl para mover el form desde este panel
        }

        private void Limnpiado()
        {
            txt_nombre.Clear();
            txt_id.Clear();
            txt_modelo.Clear();
            txt_precio.Clear();
            txt_stock.Clear();
            txt_codBarra.Clear();
            cbo_categoria.SelectedIndex = -1;
            cbo_marca.SelectedIndex = -1;
            cbo_proveedor.SelectedIndex = -1;
        }

        #region KeyPress        

        private void txt_precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)))
            {
                e.Handled = true;
            }
            else
            {
                erp2.Clear();
            }            
        }

        private void txt_stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            else
            {
                erp3.Clear();
            }
        }

        private void txt_codBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_guardar.PerformClick();
            }
                        
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            else
            {
                erp5.Clear();
            }
        }

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            erp.Clear();
        }

        private void txt_modelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            erp4.Clear();
        }

        private void cbo_proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                erp8.Clear();
            }
            catch (Exception ex)
            {}            
        }

        private void cbo_marca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                erp7.Clear();
            }
            catch (Exception ex)
            {}            
        }

        private void cbo_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                erp6.Clear();
            }
            catch (Exception ex)
            {}            
        }

        #endregion

        private void txt_codBarra_TextChanged(object sender, EventArgs e)
        {
            if (txt_codBarra.Text != "") //se encargara de generar el codigo de barras del producto
            {
                BarcodeLib.Barcode cod = new BarcodeLib.Barcode();
                cod.IncludeLabel = true;
                pic_CodBar.Image = cod.Encode(BarcodeLib.TYPE.CODE128, txt_codBarra.Text, Color.Black, Color.FromArgb(224, 224, 224), 245, 101);
            } 
        }                       
    }
}
