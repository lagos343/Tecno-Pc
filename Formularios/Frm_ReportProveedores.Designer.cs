
namespace Tecno_Pc.Formularios
{
    partial class Frm_ReportProveedores
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ReportProveedores));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_titulo = new Guna.UI.WinForms.GunaLabel();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.salir = new Guna.UI.WinForms.GunaPictureBox();
            this.minimizar = new Guna.UI.WinForms.GunaPictureBox();
            this.btn_minimizar = new Guna.UI.WinForms.GunaPictureBox();
            this.btn_salir = new Guna.UI.WinForms.GunaPictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radio_gen = new System.Windows.Forms.RadioButton();
            this.radio_filtrado = new System.Windows.Forms.RadioButton();
            this.btn_imprimir = new Guna.UI.WinForms.GunaGradientButton();
            this.cbo_proveedor = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Tecno_Pc.Properties.Resources.FondoFormRep1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btn_imprimir);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 358);
            this.panel1.TabIndex = 62;
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_titulo.ForeColor = System.Drawing.Color.White;
            this.lbl_titulo.Location = new System.Drawing.Point(37, 13);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(152, 15);
            this.lbl_titulo.TabIndex = 1;
            this.lbl_titulo.Text = "REPORTE DE PROVEEDORES";
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.gunaPictureBox1.Image = global::Tecno_Pc.Properties.Resources.LogoTecnoPc;
            this.gunaPictureBox1.Location = new System.Drawing.Point(3, 5);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(28, 29);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gunaPictureBox1.TabIndex = 2;
            this.gunaPictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel2.Controls.Add(this.salir);
            this.panel2.Controls.Add(this.minimizar);
            this.panel2.Controls.Add(this.btn_minimizar);
            this.panel2.Controls.Add(this.lbl_titulo);
            this.panel2.Controls.Add(this.btn_salir);
            this.panel2.Controls.Add(this.gunaPictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 40);
            this.panel2.TabIndex = 56;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // salir
            // 
            this.salir.BaseColor = System.Drawing.Color.White;
            this.salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.salir.Image = global::Tecno_Pc.Properties.Resources.CerrarForm;
            this.salir.Location = new System.Drawing.Point(314, 2);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(31, 36);
            this.salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.salir.TabIndex = 6;
            this.salir.TabStop = false;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // minimizar
            // 
            this.minimizar.BaseColor = System.Drawing.Color.White;
            this.minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizar.Image = global::Tecno_Pc.Properties.Resources.minimizar;
            this.minimizar.Location = new System.Drawing.Point(280, 1);
            this.minimizar.Name = "minimizar";
            this.minimizar.Size = new System.Drawing.Size(28, 37);
            this.minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.minimizar.TabIndex = 5;
            this.minimizar.TabStop = false;
            this.minimizar.Click += new System.EventHandler(this.minimizar_Click);
            // 
            // btn_minimizar
            // 
            this.btn_minimizar.BaseColor = System.Drawing.Color.White;
            this.btn_minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_minimizar.Image = global::Tecno_Pc.Properties.Resources.minimizar;
            this.btn_minimizar.Location = new System.Drawing.Point(808, 1);
            this.btn_minimizar.Name = "btn_minimizar";
            this.btn_minimizar.Size = new System.Drawing.Size(28, 37);
            this.btn_minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_minimizar.TabIndex = 4;
            this.btn_minimizar.TabStop = false;
            // 
            // btn_salir
            // 
            this.btn_salir.BaseColor = System.Drawing.Color.White;
            this.btn_salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salir.Image = global::Tecno_Pc.Properties.Resources.CerrarForm;
            this.btn_salir.Location = new System.Drawing.Point(841, 2);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(31, 36);
            this.btn_salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_salir.TabIndex = 3;
            this.btn_salir.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cbo_proveedor);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.radio_gen);
            this.groupBox1.Controls.Add(this.radio_filtrado);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Gray;
            this.groupBox1.Location = new System.Drawing.Point(13, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 214);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TIPO DE REPORTE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 59;
            this.label2.Text = "PROVEEDOR";
            // 
            // radio_gen
            // 
            this.radio_gen.AutoSize = true;
            this.radio_gen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_gen.ForeColor = System.Drawing.Color.Gray;
            this.radio_gen.Location = new System.Drawing.Point(19, 36);
            this.radio_gen.Margin = new System.Windows.Forms.Padding(2);
            this.radio_gen.Name = "radio_gen";
            this.radio_gen.Size = new System.Drawing.Size(75, 19);
            this.radio_gen.TabIndex = 50;
            this.radio_gen.TabStop = true;
            this.radio_gen.Text = "GENERAL";
            this.radio_gen.UseVisualStyleBackColor = true;
            this.radio_gen.CheckedChanged += new System.EventHandler(this.radio_gen_CheckedChanged);
            // 
            // radio_filtrado
            // 
            this.radio_filtrado.AutoSize = true;
            this.radio_filtrado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_filtrado.ForeColor = System.Drawing.Color.Gray;
            this.radio_filtrado.Location = new System.Drawing.Point(19, 82);
            this.radio_filtrado.Margin = new System.Windows.Forms.Padding(2);
            this.radio_filtrado.Name = "radio_filtrado";
            this.radio_filtrado.Size = new System.Drawing.Size(187, 19);
            this.radio_filtrado.TabIndex = 51;
            this.radio_filtrado.TabStop = true;
            this.radio_filtrado.Text = "PRODUCTOS POR PROVEEDOR";
            this.radio_filtrado.UseVisualStyleBackColor = true;
            this.radio_filtrado.CheckedChanged += new System.EventHandler(this.radio_filtrado_CheckedChanged);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.AnimationHoverSpeed = 0.07F;
            this.btn_imprimir.AnimationSpeed = 0.03F;
            this.btn_imprimir.BackColor = System.Drawing.Color.Transparent;
            this.btn_imprimir.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btn_imprimir.BaseColor2 = System.Drawing.Color.MediumBlue;
            this.btn_imprimir.BorderColor = System.Drawing.Color.Black;
            this.btn_imprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_imprimir.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_imprimir.FocusedColor = System.Drawing.Color.Empty;
            this.btn_imprimir.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_imprimir.ForeColor = System.Drawing.Color.White;
            this.btn_imprimir.Image = null;
            this.btn_imprimir.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_imprimir.Location = new System.Drawing.Point(13, 314);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btn_imprimir.OnHoverBaseColor2 = System.Drawing.Color.MediumBlue;
            this.btn_imprimir.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btn_imprimir.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_imprimir.OnHoverImage = null;
            this.btn_imprimir.OnPressedColor = System.Drawing.Color.Transparent;
            this.btn_imprimir.Radius = 3;
            this.btn_imprimir.Size = new System.Drawing.Size(324, 31);
            this.btn_imprimir.TabIndex = 57;
            this.btn_imprimir.Text = "REPORTES";
            this.btn_imprimir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // cbo_proveedor
            // 
            this.cbo_proveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbo_proveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_proveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_proveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_proveedor.FormattingEnabled = true;
            this.cbo_proveedor.Location = new System.Drawing.Point(65, 159);
            this.cbo_proveedor.Name = "cbo_proveedor";
            this.cbo_proveedor.Size = new System.Drawing.Size(227, 23);
            this.cbo_proveedor.TabIndex = 97;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox3.Location = new System.Drawing.Point(56, 155);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(245, 31);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 98;
            this.pictureBox3.TabStop = false;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
            // 
            // Frm_ReportProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 355);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_ReportProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes de Proveedores";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaPictureBox salir;
        private Guna.UI.WinForms.GunaPictureBox minimizar;
        private Guna.UI.WinForms.GunaPictureBox btn_minimizar;
        private Guna.UI.WinForms.GunaLabel lbl_titulo;
        private Guna.UI.WinForms.GunaPictureBox btn_salir;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radio_gen;
        private System.Windows.Forms.RadioButton radio_filtrado;
        private Guna.UI.WinForms.GunaGradientButton btn_imprimir;
        private System.Windows.Forms.ComboBox cbo_proveedor;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ToolTip toolTip1;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
    }
}