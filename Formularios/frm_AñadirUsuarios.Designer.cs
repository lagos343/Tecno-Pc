﻿
namespace Tecno_Pc.Formularios
{
    partial class frm_AñadirUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AñadirUsuarios));
            this.btn_minimizar = new Guna.UI.WinForms.GunaPictureBox();
            this.lbl_titulo = new Guna.UI.WinForms.GunaLabel();
            this.btn_salir = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gunaLabel7 = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.gunaLabel4 = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.btn_guardar = new Guna.UI.WinForms.GunaGradientButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.cboempleado = new System.Windows.Forms.ComboBox();
            this.cborol = new System.Windows.Forms.ComboBox();
            this.erp_usuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.erp_contra = new System.Windows.Forms.ErrorProvider(this.components);
            this.erp_empleado = new System.Windows.Forms.ErrorProvider(this.components);
            this.erp_rol = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_usuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_contra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_empleado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_rol)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_minimizar
            // 
            this.btn_minimizar.BaseColor = System.Drawing.Color.White;
            this.btn_minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_minimizar.Image = global::Tecno_Pc.Properties.Resources.minimizar;
            this.btn_minimizar.Location = new System.Drawing.Point(669, 2);
            this.btn_minimizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_minimizar.Name = "btn_minimizar";
            this.btn_minimizar.Size = new System.Drawing.Size(37, 46);
            this.btn_minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_minimizar.TabIndex = 4;
            this.btn_minimizar.TabStop = false;
            this.btn_minimizar.Click += new System.EventHandler(this.btn_minimizar_Click);
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_titulo.ForeColor = System.Drawing.Color.White;
            this.lbl_titulo.Location = new System.Drawing.Point(49, 12);
            this.lbl_titulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(130, 20);
            this.lbl_titulo.TabIndex = 1;
            this.lbl_titulo.Text = "AÑADIR USUARIO";
            // 
            // btn_salir
            // 
            this.btn_salir.BaseColor = System.Drawing.Color.White;
            this.btn_salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salir.Image = global::Tecno_Pc.Properties.Resources.CerrarForm;
            this.btn_salir.Location = new System.Drawing.Point(709, 4);
            this.btn_salir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(41, 44);
            this.btn_salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_salir.TabIndex = 3;
            this.btn_salir.TabStop = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaPictureBox1.Image = global::Tecno_Pc.Properties.Resources.LogoTecnoPc;
            this.gunaPictureBox1.Location = new System.Drawing.Point(4, 6);
            this.gunaPictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(37, 36);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gunaPictureBox1.TabIndex = 2;
            this.gunaPictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.panel1.Controls.Add(this.btn_minimizar);
            this.panel1.Controls.Add(this.lbl_titulo);
            this.panel1.Controls.Add(this.btn_salir);
            this.panel1.Controls.Add(this.gunaPictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 49);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // gunaLabel7
            // 
            this.gunaLabel7.AutoSize = true;
            this.gunaLabel7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel7.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel7.Location = new System.Drawing.Point(11, 265);
            this.gunaLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gunaLabel7.Name = "gunaLabel7";
            this.gunaLabel7.Size = new System.Drawing.Size(36, 20);
            this.gunaLabel7.TabIndex = 79;
            this.gunaLabel7.Text = "ROL";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox6.Location = new System.Drawing.Point(16, 292);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(327, 38);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 70;
            this.pictureBox6.TabStop = false;
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel2.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel2.Location = new System.Drawing.Point(408, 174);
            this.gunaLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(85, 20);
            this.gunaLabel2.TabIndex = 68;
            this.gunaLabel2.Text = "EMPLEADO";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox3.Location = new System.Drawing.Point(413, 201);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(327, 38);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 67;
            this.pictureBox3.TabStop = false;
            // 
            // txt_pass
            // 
            this.txt_pass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_pass.CausesValidation = false;
            this.txt_pass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_pass.Location = new System.Drawing.Point(25, 210);
            this.txt_pass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_pass.MaxLength = 20;
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(303, 20);
            this.txt_pass.TabIndex = 66;
            this.txt_pass.TextChanged += new System.EventHandler(this.txt_pass_TextChanged);
            // 
            // gunaLabel4
            // 
            this.gunaLabel4.AutoSize = true;
            this.gunaLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel4.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel4.Location = new System.Drawing.Point(11, 174);
            this.gunaLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gunaLabel4.Name = "gunaLabel4";
            this.gunaLabel4.Size = new System.Drawing.Size(108, 20);
            this.gunaLabel4.TabIndex = 65;
            this.gunaLabel4.Text = "CONTRASEÑA ";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox4.Location = new System.Drawing.Point(16, 201);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(327, 38);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 64;
            this.pictureBox4.TabStop = false;
            // 
            // txt_usuario
            // 
            this.txt_usuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_usuario.CausesValidation = false;
            this.txt_usuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_usuario.Location = new System.Drawing.Point(423, 119);
            this.txt_usuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_usuario.MaxLength = 15;
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(303, 20);
            this.txt_usuario.TabIndex = 63;
            this.txt_usuario.TextChanged += new System.EventHandler(this.txt_usuario_TextChanged);
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel1.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel1.Location = new System.Drawing.Point(408, 82);
            this.gunaLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(71, 20);
            this.gunaLabel1.TabIndex = 62;
            this.gunaLabel1.Text = "USUARIO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox1.Location = new System.Drawing.Point(413, 110);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            // 
            // txt_id
            // 
            this.txt_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_id.CausesValidation = false;
            this.txt_id.Enabled = false;
            this.txt_id.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_id.Location = new System.Drawing.Point(25, 119);
            this.txt_id.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(303, 20);
            this.txt_id.TabIndex = 60;
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel3.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel3.Location = new System.Drawing.Point(11, 82);
            this.gunaLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(24, 20);
            this.gunaLabel3.TabIndex = 59;
            this.gunaLabel3.Text = "ID";
            // 
            // btn_guardar
            // 
            this.btn_guardar.AnimationHoverSpeed = 0.07F;
            this.btn_guardar.AnimationSpeed = 0.03F;
            this.btn_guardar.BackColor = System.Drawing.Color.Transparent;
            this.btn_guardar.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btn_guardar.BaseColor2 = System.Drawing.Color.MediumBlue;
            this.btn_guardar.BorderColor = System.Drawing.Color.Black;
            this.btn_guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_guardar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_guardar.FocusedColor = System.Drawing.Color.Empty;
            this.btn_guardar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_guardar.ForeColor = System.Drawing.Color.White;
            this.btn_guardar.Image = global::Tecno_Pc.Properties.Resources.Guardar;
            this.btn_guardar.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_guardar.Location = new System.Drawing.Point(15, 398);
            this.btn_guardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btn_guardar.OnHoverBaseColor2 = System.Drawing.Color.MediumBlue;
            this.btn_guardar.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btn_guardar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_guardar.OnHoverImage = null;
            this.btn_guardar.OnPressedColor = System.Drawing.Color.Transparent;
            this.btn_guardar.Radius = 3;
            this.btn_guardar.Size = new System.Drawing.Size(724, 42);
            this.btn_guardar.TabIndex = 57;
            this.btn_guardar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox2.Location = new System.Drawing.Point(16, 110);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(327, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 58;
            this.pictureBox2.TabStop = false;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
            // 
            // cboempleado
            // 
            this.cboempleado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboempleado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboempleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboempleado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboempleado.FormattingEnabled = true;
            this.cboempleado.Location = new System.Drawing.Point(425, 206);
            this.cboempleado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboempleado.Name = "cboempleado";
            this.cboempleado.Size = new System.Drawing.Size(301, 28);
            this.cboempleado.TabIndex = 85;
            this.cboempleado.SelectedIndexChanged += new System.EventHandler(this.cboempleado_SelectedIndexChanged);
            // 
            // cborol
            // 
            this.cborol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cborol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cborol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cborol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cborol.FormattingEnabled = true;
            this.cborol.Location = new System.Drawing.Point(28, 297);
            this.cborol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cborol.Name = "cborol";
            this.cborol.Size = new System.Drawing.Size(301, 28);
            this.cborol.TabIndex = 86;
            this.cborol.SelectedIndexChanged += new System.EventHandler(this.cborol_SelectedIndexChanged);
            // 
            // erp_usuario
            // 
            this.erp_usuario.ContainerControl = this;
            // 
            // erp_contra
            // 
            this.erp_contra.ContainerControl = this;
            // 
            // erp_empleado
            // 
            this.erp_empleado.ContainerControl = this;
            // 
            // erp_rol
            // 
            this.erp_rol.ContainerControl = this;
            // 
            // frm_AñadirUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(756, 454);
            this.Controls.Add(this.cborol);
            this.Controls.Add(this.cboempleado);
            this.Controls.Add(this.gunaLabel7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.gunaLabel4);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.txt_usuario);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.gunaLabel3);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_AñadirUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_usuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_contra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_empleado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_rol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaPictureBox btn_minimizar;
        private Guna.UI.WinForms.GunaLabel lbl_titulo;
        private Guna.UI.WinForms.GunaPictureBox btn_salir;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaLabel gunaLabel7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txt_pass;
        private Guna.UI.WinForms.GunaLabel gunaLabel4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox txt_usuario;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_id;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI.WinForms.GunaGradientButton btn_guardar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private System.Windows.Forms.ComboBox cborol;
        private System.Windows.Forms.ComboBox cboempleado;
        private System.Windows.Forms.ErrorProvider erp_usuario;
        private System.Windows.Forms.ErrorProvider erp_contra;
        private System.Windows.Forms.ErrorProvider erp_empleado;
        private System.Windows.Forms.ErrorProvider erp_rol;
    }
}