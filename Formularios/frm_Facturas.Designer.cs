
namespace Tecno_Pc.Formularios
{
    partial class frm_Facturas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.cbo_filtro = new Guna.UI.WinForms.GunaComboBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.dgv_Facturas = new System.Windows.Forms.DataGridView();
            this.Mostrar = new System.Windows.Forms.DataGridViewImageColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Facturas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::Tecno_Pc.Properties.Resources.SombraPanelProductos;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Controls.Add(this.txt_buscar);
            this.panel5.Controls.Add(this.pictureBox6);
            this.panel5.Controls.Add(this.pictureBox5);
            this.panel5.Controls.Add(this.cbo_filtro);
            this.panel5.Controls.Add(this.pictureBox7);
            this.panel5.Controls.Add(this.dgv_Facturas);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1114, 705);
            this.panel5.TabIndex = 5;
            // 
            // txt_buscar
            // 
            this.txt_buscar.BackColor = System.Drawing.Color.White;
            this.txt_buscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_buscar.CausesValidation = false;
            this.txt_buscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_buscar.Location = new System.Drawing.Point(136, 49);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(310, 16);
            this.txt_buscar.TabIndex = 61;
            this.txt_buscar.TextChanged += new System.EventHandler(this.txt_buscar_TextChanged_1);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::Tecno_Pc.Properties.Resources.Buscar;
            this.pictureBox6.Location = new System.Drawing.Point(101, 42);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(30, 30);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 60;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox5.Location = new System.Drawing.Point(98, 40);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(354, 34);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 59;
            this.pictureBox5.TabStop = false;
            // 
            // cbo_filtro
            // 
            this.cbo_filtro.BackColor = System.Drawing.Color.White;
            this.cbo_filtro.BaseColor = System.Drawing.Color.White;
            this.cbo_filtro.BorderColor = System.Drawing.Color.Transparent;
            this.cbo_filtro.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_filtro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_filtro.FocusedColor = System.Drawing.Color.Empty;
            this.cbo_filtro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbo_filtro.ForeColor = System.Drawing.Color.Black;
            this.cbo_filtro.FormattingEnabled = true;
            this.cbo_filtro.Items.AddRange(new object[] {
            "ID Factura",
            "Cliente"});
            this.cbo_filtro.Location = new System.Drawing.Point(760, 45);
            this.cbo_filtro.Name = "cbo_filtro";
            this.cbo_filtro.OnHoverItemBaseColor = System.Drawing.Color.Blue;
            this.cbo_filtro.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbo_filtro.Size = new System.Drawing.Size(230, 24);
            this.cbo_filtro.TabIndex = 58;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox7.Location = new System.Drawing.Point(752, 40);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(245, 34);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 57;
            this.pictureBox7.TabStop = false;
            // 
            // dgv_Facturas
            // 
            this.dgv_Facturas.AllowUserToAddRows = false;
            this.dgv_Facturas.AllowUserToDeleteRows = false;
            this.dgv_Facturas.AllowUserToResizeColumns = false;
            this.dgv_Facturas.AllowUserToResizeRows = false;
            this.dgv_Facturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Facturas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Facturas.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Facturas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Facturas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_Facturas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Facturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Facturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mostrar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Facturas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Facturas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_Facturas.Location = new System.Drawing.Point(98, 125);
            this.dgv_Facturas.Name = "dgv_Facturas";
            this.dgv_Facturas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_Facturas.RowHeadersVisible = false;
            this.dgv_Facturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Facturas.Size = new System.Drawing.Size(899, 529);
            this.dgv_Facturas.TabIndex = 11;
            this.dgv_Facturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Facturas_CellContentClick);
            // 
            // Mostrar
            // 
            this.Mostrar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Mostrar.Frozen = true;
            this.Mostrar.HeaderText = "";
            this.Mostrar.Image = global::Tecno_Pc.Properties.Resources.EditarProducto;
            this.Mostrar.Name = "Mostrar";
            this.Mostrar.ReadOnly = true;
            this.Mostrar.Width = 50;
            // 
            // frm_Facturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1114, 705);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Facturas";
            this.Text = "frm_Facturas";
            this.Load += new System.EventHandler(this.frm_Facturas_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Facturas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private Guna.UI.WinForms.GunaComboBox cbo_filtro;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.DataGridView dgv_Facturas;
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewImageColumn Mostrar;
    }
}