﻿
namespace Tecno_Pc.Formularios
{
    partial class frm_ConfigurarDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ConfigurarDB));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_minimizar = new Guna.UI.WinForms.GunaPictureBox();
            this.lbl_titulo = new Guna.UI.WinForms.GunaLabel();
            this.btn_salir = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.cbo_servers = new System.Windows.Forms.ComboBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.btn_servers = new Guna.UI.WinForms.GunaGradientButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.cbo_autenticaciones = new System.Windows.Forms.ComboBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gunaLabel4 = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txt_ruta = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btn_ruta = new Guna.UI.WinForms.GunaGradientButton();
            this.gunaLabel5 = new Guna.UI.WinForms.GunaLabel();
            this.btn_guardar = new Guna.UI.WinForms.GunaGradientButton();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.erp_servidor = new System.Windows.Forms.ErrorProvider(this.components);
            this.erp_auten = new System.Windows.Forms.ErrorProvider(this.components);
            this.erp_usu = new System.Windows.Forms.ErrorProvider(this.components);
            this.erp_contra = new System.Windows.Forms.ErrorProvider(this.components);
            this.erp_rutReports = new System.Windows.Forms.ErrorProvider(this.components);
            this.erp_bd = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_servidor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_auten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_usu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_contra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_rutReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_bd)).BeginInit();
            this.SuspendLayout();
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 40);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btn_minimizar
            // 
            this.btn_minimizar.BaseColor = System.Drawing.Color.White;
            this.btn_minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_minimizar.Image = global::Tecno_Pc.Properties.Resources.minimizar;
            this.btn_minimizar.Location = new System.Drawing.Point(459, 1);
            this.btn_minimizar.Name = "btn_minimizar";
            this.btn_minimizar.Size = new System.Drawing.Size(28, 37);
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
            this.lbl_titulo.Location = new System.Drawing.Point(38, 13);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(145, 15);
            this.lbl_titulo.TabIndex = 1;
            this.lbl_titulo.Text = "CONFIGURACION INICIAL";
            // 
            // btn_salir
            // 
            this.btn_salir.BaseColor = System.Drawing.Color.White;
            this.btn_salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salir.Image = global::Tecno_Pc.Properties.Resources.CerrarForm;
            this.btn_salir.Location = new System.Drawing.Point(492, 2);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(31, 36);
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
            this.gunaPictureBox1.Location = new System.Drawing.Point(3, 5);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(28, 29);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gunaPictureBox1.TabIndex = 2;
            this.gunaPictureBox1.TabStop = false;
            // 
            // cbo_servers
            // 
            this.cbo_servers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_servers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_servers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_servers.FormattingEnabled = true;
            this.cbo_servers.Location = new System.Drawing.Point(29, 90);
            this.cbo_servers.Name = "cbo_servers";
            this.cbo_servers.Size = new System.Drawing.Size(339, 23);
            this.cbo_servers.TabIndex = 117;
            this.cbo_servers.SelectedIndexChanged += new System.EventHandler(this.cbo_servers_SelectedIndexChanged);
            this.cbo_servers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbo_servers_KeyPress);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox6.Location = new System.Drawing.Point(22, 86);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(357, 31);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 116;
            this.pictureBox6.TabStop = false;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel1.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel1.Location = new System.Drawing.Point(19, 68);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(60, 15);
            this.gunaLabel1.TabIndex = 118;
            this.gunaLabel1.Text = "SERVIDOR";
            // 
            // btn_servers
            // 
            this.btn_servers.AnimationHoverSpeed = 0.07F;
            this.btn_servers.AnimationSpeed = 0.03F;
            this.btn_servers.BackColor = System.Drawing.Color.Transparent;
            this.btn_servers.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btn_servers.BaseColor2 = System.Drawing.Color.MediumBlue;
            this.btn_servers.BorderColor = System.Drawing.Color.Black;
            this.btn_servers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_servers.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_servers.FocusedColor = System.Drawing.Color.Empty;
            this.btn_servers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btn_servers.ForeColor = System.Drawing.Color.White;
            this.btn_servers.Image = null;
            this.btn_servers.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_servers.Location = new System.Drawing.Point(409, 86);
            this.btn_servers.Name = "btn_servers";
            this.btn_servers.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btn_servers.OnHoverBaseColor2 = System.Drawing.Color.MediumBlue;
            this.btn_servers.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btn_servers.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_servers.OnHoverImage = null;
            this.btn_servers.OnPressedColor = System.Drawing.Color.Transparent;
            this.btn_servers.Radius = 3;
            this.btn_servers.Size = new System.Drawing.Size(95, 31);
            this.btn_servers.TabIndex = 119;
            this.btn_servers.Text = "ACTUALIZAR";
            this.btn_servers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_servers.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_password);
            this.groupBox1.Controls.Add(this.gunaLabel3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.gunaLabel2);
            this.groupBox1.Controls.Add(this.cbo_autenticaciones);
            this.groupBox1.Controls.Add(this.txt_user);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.gunaLabel4);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Gray;
            this.groupBox1.Location = new System.Drawing.Point(22, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 194);
            this.groupBox1.TabIndex = 120;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CONECCION CON EL SERVIDOR";
            // 
            // txt_password
            // 
            this.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_password.CausesValidation = false;
            this.txt_password.Enabled = false;
            this.txt_password.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_password.Location = new System.Drawing.Point(160, 136);
            this.txt_password.MaxLength = 50;
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(227, 16);
            this.txt_password.TabIndex = 126;
            this.txt_password.TextChanged += new System.EventHandler(this.txt_password_TextChanged);
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel3.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel3.Location = new System.Drawing.Point(51, 137);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(83, 15);
            this.gunaLabel3.TabIndex = 125;
            this.gunaLabel3.Text = "CONTRASEÑA";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox2.Location = new System.Drawing.Point(153, 128);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(245, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 124;
            this.pictureBox2.TabStop = false;
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel2.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel2.Location = new System.Drawing.Point(16, 43);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(98, 15);
            this.gunaLabel2.TabIndex = 123;
            this.gunaLabel2.Text = "AUTENTICACION";
            // 
            // cbo_autenticaciones
            // 
            this.cbo_autenticaciones.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_autenticaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_autenticaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_autenticaciones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_autenticaciones.FormattingEnabled = true;
            this.cbo_autenticaciones.Items.AddRange(new object[] {
            "Windows Autentication",
            "Sql Server Autentication"});
            this.cbo_autenticaciones.Location = new System.Drawing.Point(128, 40);
            this.cbo_autenticaciones.Name = "cbo_autenticaciones";
            this.cbo_autenticaciones.Size = new System.Drawing.Size(328, 23);
            this.cbo_autenticaciones.TabIndex = 122;
            this.cbo_autenticaciones.SelectedIndexChanged += new System.EventHandler(this.cbo_autenticaciones_SelectedIndexChanged);
            // 
            // txt_user
            // 
            this.txt_user.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_user.CausesValidation = false;
            this.txt_user.Enabled = false;
            this.txt_user.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_user.Location = new System.Drawing.Point(160, 90);
            this.txt_user.MaxLength = 50;
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(227, 16);
            this.txt_user.TabIndex = 98;
            this.txt_user.TextChanged += new System.EventHandler(this.txt_user_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox1.Location = new System.Drawing.Point(121, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 121;
            this.pictureBox1.TabStop = false;
            // 
            // gunaLabel4
            // 
            this.gunaLabel4.AutoSize = true;
            this.gunaLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel4.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel4.Location = new System.Drawing.Point(51, 91);
            this.gunaLabel4.Name = "gunaLabel4";
            this.gunaLabel4.Size = new System.Drawing.Size(56, 15);
            this.gunaLabel4.TabIndex = 97;
            this.gunaLabel4.Text = "USUARIO";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox4.Location = new System.Drawing.Point(153, 82);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(245, 31);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 96;
            this.pictureBox4.TabStop = false;
            // 
            // txt_ruta
            // 
            this.txt_ruta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ruta.CausesValidation = false;
            this.txt_ruta.Enabled = false;
            this.txt_ruta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_ruta.Location = new System.Drawing.Point(29, 395);
            this.txt_ruta.MaxLength = 50;
            this.txt_ruta.Name = "txt_ruta";
            this.txt_ruta.Size = new System.Drawing.Size(339, 16);
            this.txt_ruta.TabIndex = 128;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox3.Location = new System.Drawing.Point(22, 387);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(357, 31);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 127;
            this.pictureBox3.TabStop = false;
            // 
            // btn_ruta
            // 
            this.btn_ruta.AnimationHoverSpeed = 0.07F;
            this.btn_ruta.AnimationSpeed = 0.03F;
            this.btn_ruta.BackColor = System.Drawing.Color.Transparent;
            this.btn_ruta.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btn_ruta.BaseColor2 = System.Drawing.Color.MediumBlue;
            this.btn_ruta.BorderColor = System.Drawing.Color.Black;
            this.btn_ruta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ruta.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_ruta.FocusedColor = System.Drawing.Color.Empty;
            this.btn_ruta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btn_ruta.ForeColor = System.Drawing.Color.White;
            this.btn_ruta.Image = null;
            this.btn_ruta.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_ruta.Location = new System.Drawing.Point(409, 387);
            this.btn_ruta.Name = "btn_ruta";
            this.btn_ruta.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btn_ruta.OnHoverBaseColor2 = System.Drawing.Color.MediumBlue;
            this.btn_ruta.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btn_ruta.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_ruta.OnHoverImage = null;
            this.btn_ruta.OnPressedColor = System.Drawing.Color.Transparent;
            this.btn_ruta.Radius = 3;
            this.btn_ruta.Size = new System.Drawing.Size(95, 31);
            this.btn_ruta.TabIndex = 129;
            this.btn_ruta.Text = "ESCOGER";
            this.btn_ruta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_ruta.Click += new System.EventHandler(this.gunaGradientButton1_Click);
            // 
            // gunaLabel5
            // 
            this.gunaLabel5.AutoSize = true;
            this.gunaLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel5.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel5.Location = new System.Drawing.Point(19, 369);
            this.gunaLabel5.Name = "gunaLabel5";
            this.gunaLabel5.Size = new System.Drawing.Size(108, 15);
            this.gunaLabel5.TabIndex = 130;
            this.gunaLabel5.Text = "RUTA DE REPORTES";
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
            this.btn_guardar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btn_guardar.ForeColor = System.Drawing.Color.White;
            this.btn_guardar.Image = global::Tecno_Pc.Properties.Resources.Guardar;
            this.btn_guardar.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_guardar.Location = new System.Drawing.Point(22, 450);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btn_guardar.OnHoverBaseColor2 = System.Drawing.Color.MediumBlue;
            this.btn_guardar.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btn_guardar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_guardar.OnHoverImage = null;
            this.btn_guardar.OnPressedColor = System.Drawing.Color.Transparent;
            this.btn_guardar.Radius = 3;
            this.btn_guardar.Size = new System.Drawing.Size(482, 33);
            this.btn_guardar.TabIndex = 131;
            this.btn_guardar.Text = "GUARDAR";
            this.btn_guardar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // erp_servidor
            // 
            this.erp_servidor.ContainerControl = this;
            // 
            // erp_auten
            // 
            this.erp_auten.ContainerControl = this;
            // 
            // erp_usu
            // 
            this.erp_usu.ContainerControl = this;
            // 
            // erp_contra
            // 
            this.erp_contra.ContainerControl = this;
            // 
            // erp_rutReports
            // 
            this.erp_rutReports.ContainerControl = this;
            // 
            // erp_bd
            // 
            this.erp_bd.ContainerControl = this;
            // 
            // frm_ConfigurarDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 502);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.gunaLabel5);
            this.Controls.Add(this.btn_ruta);
            this.Controls.Add(this.txt_ruta);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_servers);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.cbo_servers);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_ConfigurarDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion Inicial";
            this.Load += new System.EventHandler(this.frm_ConfigurarDB_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_servidor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_auten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_usu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_contra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_rutReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_bd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaPictureBox btn_minimizar;
        private Guna.UI.WinForms.GunaLabel lbl_titulo;
        private Guna.UI.WinForms.GunaPictureBox btn_salir;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private System.Windows.Forms.ComboBox cbo_servers;
        private System.Windows.Forms.PictureBox pictureBox6;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaGradientButton btn_servers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_user;
        private Guna.UI.WinForms.GunaLabel gunaLabel4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox txt_password;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private System.Windows.Forms.ComboBox cbo_autenticaciones;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_ruta;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Guna.UI.WinForms.GunaGradientButton btn_ruta;
        private Guna.UI.WinForms.GunaLabel gunaLabel5;
        private Guna.UI.WinForms.GunaGradientButton btn_guardar;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider erp_servidor;
        private System.Windows.Forms.ErrorProvider erp_auten;
        private System.Windows.Forms.ErrorProvider erp_usu;
        private System.Windows.Forms.ErrorProvider erp_contra;
        private System.Windows.Forms.ErrorProvider erp_rutReports;
        private System.Windows.Forms.ErrorProvider erp_bd;
    }
}