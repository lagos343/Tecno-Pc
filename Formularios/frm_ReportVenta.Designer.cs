
namespace Tecno_Pc.Formularios
{
    partial class frm_ReportVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ReportVenta));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_titulo = new Guna.UI.WinForms.GunaLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_imprimir = new Guna.UI.WinForms.GunaGradientButton();
            this.salir = new Guna.UI.WinForms.GunaPictureBox();
            this.minimizar = new Guna.UI.WinForms.GunaPictureBox();
            this.btn_minimizar = new Guna.UI.WinForms.GunaPictureBox();
            this.btn_salir = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio_fecha = new System.Windows.Forms.RadioButton();
            this.radio_hoy = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_hasta = new Tecno_Pc.Clases.RJDatePicker();
            this.dtp_desde = new Tecno_Pc.Clases.RJDatePicker();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.panel2.TabIndex = 1;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_titulo.ForeColor = System.Drawing.Color.White;
            this.lbl_titulo.Location = new System.Drawing.Point(37, 13);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(98, 15);
            this.lbl_titulo.TabIndex = 1;
            this.lbl_titulo.Text = "REPORTE VENTAS";
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
            this.btn_imprimir.Image = global::Tecno_Pc.Properties.Resources.Excel;
            this.btn_imprimir.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_imprimir.Location = new System.Drawing.Point(12, 312);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btn_imprimir.OnHoverBaseColor2 = System.Drawing.Color.MediumBlue;
            this.btn_imprimir.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btn_imprimir.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_imprimir.OnHoverImage = null;
            this.btn_imprimir.OnPressedColor = System.Drawing.Color.Transparent;
            this.btn_imprimir.Radius = 3;
            this.btn_imprimir.Size = new System.Drawing.Size(324, 31);
            this.btn_imprimir.TabIndex = 43;
            this.btn_imprimir.Text = "REPORTES";
            this.btn_imprimir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
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
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp_hasta);
            this.groupBox1.Controls.Add(this.dtp_desde);
            this.groupBox1.Controls.Add(this.radio_hoy);
            this.groupBox1.Controls.Add(this.radio_fecha);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Gray;
            this.groupBox1.Location = new System.Drawing.Point(12, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 214);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RANGO DE FECHAS";
            // 
            // radio_fecha
            // 
            this.radio_fecha.AutoSize = true;
            this.radio_fecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_fecha.ForeColor = System.Drawing.Color.Gray;
            this.radio_fecha.Location = new System.Drawing.Point(19, 82);
            this.radio_fecha.Margin = new System.Windows.Forms.Padding(2);
            this.radio_fecha.Name = "radio_fecha";
            this.radio_fecha.Size = new System.Drawing.Size(118, 19);
            this.radio_fecha.TabIndex = 51;
            this.radio_fecha.TabStop = true;
            this.radio_fecha.Text = "PERSONALIZADO";
            this.radio_fecha.UseVisualStyleBackColor = true;
            this.radio_fecha.CheckedChanged += new System.EventHandler(this.radio_fecha_CheckedChanged);
            // 
            // radio_hoy
            // 
            this.radio_hoy.AutoSize = true;
            this.radio_hoy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_hoy.ForeColor = System.Drawing.Color.Gray;
            this.radio_hoy.Location = new System.Drawing.Point(19, 36);
            this.radio_hoy.Margin = new System.Windows.Forms.Padding(2);
            this.radio_hoy.Name = "radio_hoy";
            this.radio_hoy.Size = new System.Drawing.Size(50, 19);
            this.radio_hoy.TabIndex = 50;
            this.radio_hoy.TabStop = true;
            this.radio_hoy.Text = "HOY";
            this.radio_hoy.UseVisualStyleBackColor = true;
            this.radio_hoy.CheckedChanged += new System.EventHandler(this.radio_hoy_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 59;
            this.label2.Text = "DESDE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 60;
            this.label3.Text = "HASTA";
            // 
            // dtp_hasta
            // 
            this.dtp_hasta.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.dtp_hasta.BorderSize = 2;
            this.dtp_hasta.CustomFormat = "yyyy-MM-dd";
            this.dtp_hasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtp_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_hasta.Location = new System.Drawing.Point(108, 162);
            this.dtp_hasta.MinimumSize = new System.Drawing.Size(4, 25);
            this.dtp_hasta.Name = "dtp_hasta";
            this.dtp_hasta.Size = new System.Drawing.Size(189, 25);
            this.dtp_hasta.SkinColor = System.Drawing.Color.White;
            this.dtp_hasta.TabIndex = 57;
            this.dtp_hasta.TextColor = System.Drawing.Color.Gray;
            // 
            // dtp_desde
            // 
            this.dtp_desde.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.dtp_desde.BorderSize = 2;
            this.dtp_desde.CalendarTitleForeColor = System.Drawing.Color.Gray;
            this.dtp_desde.CustomFormat = "yyyy-MM-dd";
            this.dtp_desde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtp_desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_desde.Location = new System.Drawing.Point(108, 121);
            this.dtp_desde.MinimumSize = new System.Drawing.Size(4, 25);
            this.dtp_desde.Name = "dtp_desde";
            this.dtp_desde.Size = new System.Drawing.Size(189, 25);
            this.dtp_desde.SkinColor = System.Drawing.Color.White;
            this.dtp_desde.TabIndex = 56;
            this.dtp_desde.TextColor = System.Drawing.Color.Gray;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
            // 
            // frm_ReportVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(348, 355);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frm_ReportVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_ReportVenta";
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

        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaPictureBox btn_minimizar;
        private Guna.UI.WinForms.GunaLabel lbl_titulo;
        private Guna.UI.WinForms.GunaPictureBox btn_salir;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private Guna.UI.WinForms.GunaPictureBox minimizar;
        private Guna.UI.WinForms.GunaPictureBox salir;
        private Guna.UI.WinForms.GunaGradientButton btn_imprimir;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Clases.RJDatePicker dtp_hasta;
        private Clases.RJDatePicker dtp_desde;
        private System.Windows.Forms.RadioButton radio_hoy;
        private System.Windows.Forms.RadioButton radio_fecha;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
    }
}