
namespace Repuestos_Arias.Formularios
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
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.dgv_Productos = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.btn_Imprimir = new Guna.UI.WinForms.GunaGradientButton();
            this.btn_nuevoUsuario = new Guna.UI.WinForms.GunaGradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Productos)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_buscar
            // 
            this.txt_buscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_buscar.CausesValidation = false;
            this.txt_buscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_buscar.Location = new System.Drawing.Point(71, 49);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(289, 18);
            this.txt_buscar.TabIndex = 20;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::Repuestos_Arias.Properties.Resources.Buscar;
            this.pictureBox6.Location = new System.Drawing.Point(35, 43);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(30, 30);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 19;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Repuestos_Arias.Properties.Resources.CajaTexto;
            this.pictureBox5.Location = new System.Drawing.Point(31, 39);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(340, 39);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 18;
            this.pictureBox5.TabStop = false;
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
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Productos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Productos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_Productos.Location = new System.Drawing.Point(31, 116);
            this.dgv_Productos.Name = "dgv_Productos";
            this.dgv_Productos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_Productos.RowHeadersVisible = false;
            this.dgv_Productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Productos.Size = new System.Drawing.Size(1184, 660);
            this.dgv_Productos.TabIndex = 21;
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Image = global::Repuestos_Arias.Properties.Resources.EditarProducto;
            this.Editar.Name = "Editar";
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Image = global::Repuestos_Arias.Properties.Resources.EliminarProducto;
            this.Eliminar.Name = "Eliminar";
            // 
            // btn_Imprimir
            // 
            this.btn_Imprimir.AnimationHoverSpeed = 0.07F;
            this.btn_Imprimir.AnimationSpeed = 0.03F;
            this.btn_Imprimir.BackColor = System.Drawing.Color.Transparent;
            this.btn_Imprimir.BaseColor1 = System.Drawing.Color.Purple;
            this.btn_Imprimir.BaseColor2 = System.Drawing.Color.Purple;
            this.btn_Imprimir.BorderColor = System.Drawing.Color.Black;
            this.btn_Imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Imprimir.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Imprimir.FocusedColor = System.Drawing.Color.Empty;
            this.btn_Imprimir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Imprimir.ForeColor = System.Drawing.Color.White;
            this.btn_Imprimir.Image = null;
            this.btn_Imprimir.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Imprimir.Location = new System.Drawing.Point(1051, 43);
            this.btn_Imprimir.Name = "btn_Imprimir";
            this.btn_Imprimir.OnHoverBaseColor1 = System.Drawing.Color.Magenta;
            this.btn_Imprimir.OnHoverBaseColor2 = System.Drawing.Color.Magenta;
            this.btn_Imprimir.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btn_Imprimir.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_Imprimir.OnHoverImage = null;
            this.btn_Imprimir.OnPressedColor = System.Drawing.Color.Transparent;
            this.btn_Imprimir.Radius = 5;
            this.btn_Imprimir.Size = new System.Drawing.Size(164, 32);
            this.btn_Imprimir.TabIndex = 23;
            this.btn_Imprimir.Text = "Puestos";
            this.btn_Imprimir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.btn_nuevoUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_nuevoUsuario.ForeColor = System.Drawing.Color.White;
            this.btn_nuevoUsuario.Image = null;
            this.btn_nuevoUsuario.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_nuevoUsuario.Location = new System.Drawing.Point(391, 43);
            this.btn_nuevoUsuario.Name = "btn_nuevoUsuario";
            this.btn_nuevoUsuario.OnHoverBaseColor1 = System.Drawing.Color.Teal;
            this.btn_nuevoUsuario.OnHoverBaseColor2 = System.Drawing.Color.Teal;
            this.btn_nuevoUsuario.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btn_nuevoUsuario.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_nuevoUsuario.OnHoverImage = null;
            this.btn_nuevoUsuario.OnPressedColor = System.Drawing.Color.Transparent;
            this.btn_nuevoUsuario.Radius = 5;
            this.btn_nuevoUsuario.Size = new System.Drawing.Size(189, 32);
            this.btn_nuevoUsuario.TabIndex = 22;
            this.btn_nuevoUsuario.Text = "Nuevo Empleado";
            this.btn_nuevoUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frm_empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1247, 808);
            this.Controls.Add(this.btn_Imprimir);
            this.Controls.Add(this.btn_nuevoUsuario);
            this.Controls.Add(this.dgv_Productos);
            this.Controls.Add(this.txt_buscar);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_empleados";
            this.Text = "frm_empleados";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Productos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.DataGridView dgv_Productos;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
        private Guna.UI.WinForms.GunaGradientButton btn_Imprimir;
        private Guna.UI.WinForms.GunaGradientButton btn_nuevoUsuario;
    }
}