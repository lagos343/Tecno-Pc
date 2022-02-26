
namespace Tecno_Pc.Formularios
{
    partial class frm_empleados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_Productos = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.btn_nuevoUsuario = new Guna.UI.WinForms.GunaGradientButton();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.gunaPictureBox2 = new Guna.UI.WinForms.GunaPictureBox();
            this.lbl_direccion = new System.Windows.Forms.Label();
            this.txt_direccion = new System.Windows.Forms.Label();
            this.lbl_depto = new System.Windows.Forms.Label();
            this.txt_depto = new System.Windows.Forms.Label();
            this.lbl_id = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.txt_emal = new System.Windows.Forms.Label();
            this.lbl_telefono = new System.Windows.Forms.Label();
            this.txt_telefono = new System.Windows.Forms.Label();
            this.lbl_puesto = new System.Windows.Forms.Label();
            this.txt_puesto = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Productos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Productos
            // 
            this.dgv_Productos.AllowUserToAddRows = false;
            this.dgv_Productos.AllowUserToDeleteRows = false;
            this.dgv_Productos.AllowUserToResizeColumns = false;
            this.dgv_Productos.AllowUserToResizeRows = false;
            this.dgv_Productos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Productos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Productos.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Productos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Productos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_Productos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Productos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Productos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.Eliminar});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Productos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Productos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_Productos.Location = new System.Drawing.Point(114, 334);
            this.dgv_Productos.Name = "dgv_Productos";
            this.dgv_Productos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_Productos.RowHeadersVisible = false;
            this.dgv_Productos.RowHeadersWidth = 51;
            this.dgv_Productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Productos.Size = new System.Drawing.Size(861, 336);
            this.dgv_Productos.TabIndex = 21;
            this.dgv_Productos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Productos_CellContentClick_1);
            // 
            // Editar
            // 
            this.Editar.HeaderText = "";
            this.Editar.Image = global::Tecno_Pc.Properties.Resources.EditarProducto;
            this.Editar.MinimumWidth = 6;
            this.Editar.Name = "Editar";
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "";
            this.Eliminar.Image = global::Tecno_Pc.Properties.Resources.EliminarProducto;
            this.Eliminar.MinimumWidth = 6;
            this.Eliminar.Name = "Eliminar";
            // 
            // btn_nuevoUsuario
            // 
            this.btn_nuevoUsuario.AnimationHoverSpeed = 0.07F;
            this.btn_nuevoUsuario.AnimationSpeed = 0.03F;
            this.btn_nuevoUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btn_nuevoUsuario.BaseColor1 = System.Drawing.Color.MediumBlue;
            this.btn_nuevoUsuario.BaseColor2 = System.Drawing.Color.MediumBlue;
            this.btn_nuevoUsuario.BorderColor = System.Drawing.Color.Black;
            this.btn_nuevoUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_nuevoUsuario.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_nuevoUsuario.FocusedColor = System.Drawing.Color.Empty;
            this.btn_nuevoUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_nuevoUsuario.ForeColor = System.Drawing.Color.White;
            this.btn_nuevoUsuario.Image = null;
            this.btn_nuevoUsuario.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_nuevoUsuario.Location = new System.Drawing.Point(809, 288);
            this.btn_nuevoUsuario.Name = "btn_nuevoUsuario";
            this.btn_nuevoUsuario.OnHoverBaseColor1 = System.Drawing.Color.Teal;
            this.btn_nuevoUsuario.OnHoverBaseColor2 = System.Drawing.Color.Teal;
            this.btn_nuevoUsuario.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btn_nuevoUsuario.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_nuevoUsuario.OnHoverImage = null;
            this.btn_nuevoUsuario.OnPressedColor = System.Drawing.Color.Transparent;
            this.btn_nuevoUsuario.Radius = 5;
            this.btn_nuevoUsuario.Size = new System.Drawing.Size(166, 32);
            this.btn_nuevoUsuario.TabIndex = 22;
            this.btn_nuevoUsuario.Text = "Nuevo Empleado";
            this.btn_nuevoUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_nuevoUsuario.Click += new System.EventHandler(this.btn_nuevoUsuario_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Editar";
            this.dataGridViewImageColumn1.Image = global::Tecno_Pc.Properties.Resources.EditarProducto;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 592;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Eliminar";
            this.dataGridViewImageColumn2.Image = global::Tecno_Pc.Properties.Resources.EliminarProducto;
            this.dataGridViewImageColumn2.MinimumWidth = 6;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 592;
            // 
            // txt_buscar
            // 
            this.txt_buscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_buscar.CausesValidation = false;
            this.txt_buscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_buscar.Location = new System.Drawing.Point(152, 293);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(310, 16);
            this.txt_buscar.TabIndex = 77;
            this.txt_buscar.TextChanged += new System.EventHandler(this.txt_buscar_TextChanged);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::Tecno_Pc.Properties.Resources.Buscar;
            this.pictureBox6.Location = new System.Drawing.Point(117, 286);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(30, 30);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 76;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox5.Location = new System.Drawing.Point(114, 284);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(354, 34);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 75;
            this.pictureBox5.TabStop = false;
            // 
            // gunaPictureBox2
            // 
            this.gunaPictureBox2.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox2.Image = global::Tecno_Pc.Properties.Resources.Empleado;
            this.gunaPictureBox2.Location = new System.Drawing.Point(187, 63);
            this.gunaPictureBox2.Name = "gunaPictureBox2";
            this.gunaPictureBox2.Size = new System.Drawing.Size(183, 165);
            this.gunaPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gunaPictureBox2.TabIndex = 90;
            this.gunaPictureBox2.TabStop = false;
            // 
            // lbl_direccion
            // 
            this.lbl_direccion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lbl_direccion.Location = new System.Drawing.Point(496, 175);
            this.lbl_direccion.Name = "lbl_direccion";
            this.lbl_direccion.Size = new System.Drawing.Size(210, 79);
            this.lbl_direccion.TabIndex = 88;
            // 
            // txt_direccion
            // 
            this.txt_direccion.AutoSize = true;
            this.txt_direccion.Font = new System.Drawing.Font("Segoe UI Black", 9.5F);
            this.txt_direccion.Location = new System.Drawing.Point(394, 175);
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.Size = new System.Drawing.Size(67, 17);
            this.txt_direccion.TabIndex = 83;
            this.txt_direccion.Text = "Direccion";
            // 
            // lbl_depto
            // 
            this.lbl_depto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lbl_depto.Location = new System.Drawing.Point(493, 127);
            this.lbl_depto.Name = "lbl_depto";
            this.lbl_depto.Size = new System.Drawing.Size(182, 27);
            this.lbl_depto.TabIndex = 87;
            // 
            // txt_depto
            // 
            this.txt_depto.AutoSize = true;
            this.txt_depto.Font = new System.Drawing.Font("Segoe UI Black", 9.5F);
            this.txt_depto.Location = new System.Drawing.Point(394, 127);
            this.txt_depto.Name = "txt_depto";
            this.txt_depto.Size = new System.Drawing.Size(98, 17);
            this.txt_depto.TabIndex = 82;
            this.txt_depto.Text = "Departamento";
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lbl_id.Location = new System.Drawing.Point(492, 84);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(0, 17);
            this.lbl_id.TabIndex = 86;
            // 
            // txt_id
            // 
            this.txt_id.AutoSize = true;
            this.txt_id.Font = new System.Drawing.Font("Segoe UI Black", 9.5F);
            this.txt_id.Location = new System.Drawing.Point(394, 84);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(60, 17);
            this.txt_id.TabIndex = 81;
            this.txt_id.Text = "Nombre";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lbl_email.Location = new System.Drawing.Point(808, 175);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(0, 17);
            this.lbl_email.TabIndex = 85;
            // 
            // txt_emal
            // 
            this.txt_emal.AutoSize = true;
            this.txt_emal.Font = new System.Drawing.Font("Segoe UI Black", 9.5F);
            this.txt_emal.Location = new System.Drawing.Point(712, 175);
            this.txt_emal.Name = "txt_emal";
            this.txt_emal.Size = new System.Drawing.Size(42, 17);
            this.txt_emal.TabIndex = 80;
            this.txt_emal.Text = "Email";
            // 
            // lbl_telefono
            // 
            this.lbl_telefono.AutoSize = true;
            this.lbl_telefono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lbl_telefono.Location = new System.Drawing.Point(808, 127);
            this.lbl_telefono.Name = "lbl_telefono";
            this.lbl_telefono.Size = new System.Drawing.Size(0, 17);
            this.lbl_telefono.TabIndex = 84;
            // 
            // txt_telefono
            // 
            this.txt_telefono.AutoSize = true;
            this.txt_telefono.Font = new System.Drawing.Font("Segoe UI Black", 9.5F);
            this.txt_telefono.Location = new System.Drawing.Point(712, 127);
            this.txt_telefono.Name = "txt_telefono";
            this.txt_telefono.Size = new System.Drawing.Size(64, 17);
            this.txt_telefono.TabIndex = 79;
            this.txt_telefono.Text = "Telefono";
            // 
            // lbl_puesto
            // 
            this.lbl_puesto.AutoSize = true;
            this.lbl_puesto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lbl_puesto.Location = new System.Drawing.Point(808, 84);
            this.lbl_puesto.Name = "lbl_puesto";
            this.lbl_puesto.Size = new System.Drawing.Size(0, 17);
            this.lbl_puesto.TabIndex = 89;
            // 
            // txt_puesto
            // 
            this.txt_puesto.AutoSize = true;
            this.txt_puesto.Font = new System.Drawing.Font("Segoe UI Black", 9.5F);
            this.txt_puesto.Location = new System.Drawing.Point(712, 84);
            this.txt_puesto.Name = "txt_puesto";
            this.txt_puesto.Size = new System.Drawing.Size(51, 17);
            this.txt_puesto.TabIndex = 78;
            this.txt_puesto.Text = "Puesto";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(92, 257);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 1);
            this.panel1.TabIndex = 91;
            // 
            // frm_empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Tecno_Pc.Properties.Resources.SombraPanelProductos;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1114, 705);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gunaPictureBox2);
            this.Controls.Add(this.lbl_direccion);
            this.Controls.Add(this.txt_direccion);
            this.Controls.Add(this.lbl_depto);
            this.Controls.Add(this.txt_depto);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.txt_emal);
            this.Controls.Add(this.lbl_telefono);
            this.Controls.Add(this.txt_telefono);
            this.Controls.Add(this.lbl_puesto);
            this.Controls.Add(this.txt_puesto);
            this.Controls.Add(this.txt_buscar);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.btn_nuevoUsuario);
            this.Controls.Add(this.dgv_Productos);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_empleados";
            this.Text = "frm_empleados";
            this.Load += new System.EventHandler(this.frm_empleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Productos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_Productos;
        private Guna.UI.WinForms.GunaGradientButton btn_nuevoUsuario;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox2;
        private System.Windows.Forms.Label lbl_direccion;
        private System.Windows.Forms.Label txt_direccion;
        private System.Windows.Forms.Label lbl_depto;
        private System.Windows.Forms.Label txt_depto;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.Label txt_id;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label txt_emal;
        private System.Windows.Forms.Label lbl_telefono;
        private System.Windows.Forms.Label txt_telefono;
        private System.Windows.Forms.Label lbl_puesto;
        private System.Windows.Forms.Label txt_puesto;
        private System.Windows.Forms.Panel panel1;
    }
}