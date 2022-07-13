
namespace Tecno_Pc.Formularios
{
    partial class frm_ReportVendedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ReportVendedor));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.salir = new Guna.UI.WinForms.GunaPictureBox();
            this.minimizar = new Guna.UI.WinForms.GunaPictureBox();
            this.btn_minimizar = new Guna.UI.WinForms.GunaPictureBox();
            this.lbl_titulo = new Guna.UI.WinForms.GunaLabel();
            this.btn_salir = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio_gen = new System.Windows.Forms.RadioButton();
            this.radio_ventas = new System.Windows.Forms.RadioButton();
            this.btn_imprimir = new Guna.UI.WinForms.GunaGradientButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Tecno_Pc.Properties.Resources.FondoFormRep1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btn_imprimir);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 358);
            this.panel1.TabIndex = 62;
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
            this.panel2.Size = new System.Drawing.Size(348, 40);
            this.panel2.TabIndex = 63;
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
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_titulo.ForeColor = System.Drawing.Color.White;
            this.lbl_titulo.Location = new System.Drawing.Point(37, 13);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(141, 15);
            this.lbl_titulo.TabIndex = 1;
            this.lbl_titulo.Text = "REPORTE DE EMPLEADOS";
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.radio_gen);
            this.groupBox1.Controls.Add(this.radio_ventas);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Gray;
            this.groupBox1.Location = new System.Drawing.Point(13, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 183);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TIPO DE REPORTE";
            // 
            // radio_gen
            // 
            this.radio_gen.AutoSize = true;
            this.radio_gen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_gen.ForeColor = System.Drawing.Color.Gray;
            this.radio_gen.Location = new System.Drawing.Point(30, 50);
            this.radio_gen.Margin = new System.Windows.Forms.Padding(2);
            this.radio_gen.Name = "radio_gen";
            this.radio_gen.Size = new System.Drawing.Size(75, 19);
            this.radio_gen.TabIndex = 50;
            this.radio_gen.TabStop = true;
            this.radio_gen.Text = "GENERAL";
            this.radio_gen.UseVisualStyleBackColor = true;
            // 
            // radio_ventas
            // 
            this.radio_ventas.AutoSize = true;
            this.radio_ventas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_ventas.ForeColor = System.Drawing.Color.Gray;
            this.radio_ventas.Location = new System.Drawing.Point(30, 96);
            this.radio_ventas.Margin = new System.Windows.Forms.Padding(2);
            this.radio_ventas.Name = "radio_ventas";
            this.radio_ventas.Size = new System.Drawing.Size(155, 19);
            this.radio_ventas.TabIndex = 51;
            this.radio_ventas.TabStop = true;
            this.radio_ventas.Text = "VENTAS POR VENDEDOR";
            this.radio_ventas.UseVisualStyleBackColor = true;
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
            this.btn_imprimir.TabIndex = 64;
            this.btn_imprimir.Text = "REPORTES";
            this.btn_imprimir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
            // 
            // frm_ReportVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 355);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_ReportVendedor";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Empleados";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaGradientButton btn_imprimir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radio_gen;
        private System.Windows.Forms.RadioButton radio_ventas;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaPictureBox salir;
        private Guna.UI.WinForms.GunaPictureBox minimizar;
        private Guna.UI.WinForms.GunaPictureBox btn_minimizar;
        private Guna.UI.WinForms.GunaLabel lbl_titulo;
        private Guna.UI.WinForms.GunaPictureBox btn_salir;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
    }
}