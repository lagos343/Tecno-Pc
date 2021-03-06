
namespace Tecno_Pc.Formularios
{
    partial class frm_AñadirProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AñadirProveedores));
            this.txt_direccion = new System.Windows.Forms.TextBox();
            this.gunaLabel9 = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.gunaLabel5 = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txt_telefono = new System.Windows.Forms.TextBox();
            this.gunaLabel4 = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.btn_guardar = new Guna.UI.WinForms.GunaGradientButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_minimizar = new Guna.UI.WinForms.GunaPictureBox();
            this.lbl_titulo = new Guna.UI.WinForms.GunaLabel();
            this.btn_salir = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.cbo_depto = new System.Windows.Forms.ComboBox();
            this.erp_nombre = new System.Windows.Forms.ErrorProvider(this.components);
            this.erp_telefono = new System.Windows.Forms.ErrorProvider(this.components);
            this.erp_correo = new System.Windows.Forms.ErrorProvider(this.components);
            this.erp_direccion = new System.Windows.Forms.ErrorProvider(this.components);
            this.erp_departamento = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_nombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_telefono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_correo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_direccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_departamento)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_direccion
            // 
            this.txt_direccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_direccion.CausesValidation = false;
            this.txt_direccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_direccion.Location = new System.Drawing.Point(423, 308);
            this.txt_direccion.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txt_direccion.MaxLength = 100;
            this.txt_direccion.Multiline = true;
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.Size = new System.Drawing.Size(303, 92);
            this.txt_direccion.TabIndex = 5;
            this.txt_direccion.TextChanged += new System.EventHandler(this.txt_direccion_TextChanged);
            this.txt_direccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_direccion_KeyPress);
            // 
            // gunaLabel9
            // 
            this.gunaLabel9.AutoSize = true;
            this.gunaLabel9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel9.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel9.Location = new System.Drawing.Point(408, 277);
            this.gunaLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gunaLabel9.Name = "gunaLabel9";
            this.gunaLabel9.Size = new System.Drawing.Size(85, 20);
            this.gunaLabel9.TabIndex = 141;
            this.gunaLabel9.Text = "DIRECCION";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::Tecno_Pc.Properties.Resources.CajaDescripcion;
            this.pictureBox9.Location = new System.Drawing.Point(412, 300);
            this.pictureBox9.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(321, 107);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 140;
            this.pictureBox9.TabStop = false;
            // 
            // txt_email
            // 
            this.txt_email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_email.CausesValidation = false;
            this.txt_email.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_email.Location = new System.Drawing.Point(425, 219);
            this.txt_email.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txt_email.MaxLength = 30;
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(303, 20);
            this.txt_email.TabIndex = 3;
            this.txt_email.TextChanged += new System.EventHandler(this.txt_email_TextChanged);
            // 
            // gunaLabel5
            // 
            this.gunaLabel5.AutoSize = true;
            this.gunaLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel5.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel5.Location = new System.Drawing.Point(408, 186);
            this.gunaLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gunaLabel5.Name = "gunaLabel5";
            this.gunaLabel5.Size = new System.Drawing.Size(70, 20);
            this.gunaLabel5.TabIndex = 132;
            this.gunaLabel5.Text = "CORREO ";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox5.Location = new System.Drawing.Point(412, 209);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(327, 38);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 131;
            this.pictureBox5.TabStop = false;
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel2.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel2.Location = new System.Drawing.Point(17, 277);
            this.gunaLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(120, 20);
            this.gunaLabel2.TabIndex = 126;
            this.gunaLabel2.Text = "DEPARTAMENTO";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox3.Location = new System.Drawing.Point(21, 300);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(327, 38);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 125;
            this.pictureBox3.TabStop = false;
            // 
            // txt_telefono
            // 
            this.txt_telefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_telefono.CausesValidation = false;
            this.txt_telefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_telefono.Location = new System.Drawing.Point(33, 219);
            this.txt_telefono.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txt_telefono.MaxLength = 8;
            this.txt_telefono.Name = "txt_telefono";
            this.txt_telefono.Size = new System.Drawing.Size(303, 20);
            this.txt_telefono.TabIndex = 2;
            this.txt_telefono.TextChanged += new System.EventHandler(this.txt_telefono_TextChanged);
            this.txt_telefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_telefono_KeyPress);
            // 
            // gunaLabel4
            // 
            this.gunaLabel4.AutoSize = true;
            this.gunaLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel4.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel4.Location = new System.Drawing.Point(17, 186);
            this.gunaLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gunaLabel4.Name = "gunaLabel4";
            this.gunaLabel4.Size = new System.Drawing.Size(80, 20);
            this.gunaLabel4.TabIndex = 123;
            this.gunaLabel4.Text = "TELEFONO";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox4.Location = new System.Drawing.Point(21, 209);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(327, 38);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 122;
            this.pictureBox4.TabStop = false;
            // 
            // txt_nombre
            // 
            this.txt_nombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_nombre.CausesValidation = false;
            this.txt_nombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_nombre.Location = new System.Drawing.Point(425, 128);
            this.txt_nombre.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txt_nombre.MaxLength = 20;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(303, 20);
            this.txt_nombre.TabIndex = 1;
            this.txt_nombre.TextChanged += new System.EventHandler(this.txt_nombre_TextChanged);
            this.txt_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_nombre_KeyPress);
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel1.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel1.Location = new System.Drawing.Point(408, 95);
            this.gunaLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(70, 20);
            this.gunaLabel1.TabIndex = 120;
            this.gunaLabel1.Text = "NOMBRE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox1.Location = new System.Drawing.Point(412, 118);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 119;
            this.pictureBox1.TabStop = false;
            // 
            // txt_id
            // 
            this.txt_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_id.CausesValidation = false;
            this.txt_id.Enabled = false;
            this.txt_id.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_id.Location = new System.Drawing.Point(33, 127);
            this.txt_id.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(303, 20);
            this.txt_id.TabIndex = 118;
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel3.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel3.Location = new System.Drawing.Point(17, 95);
            this.gunaLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(24, 20);
            this.gunaLabel3.TabIndex = 117;
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
            this.btn_guardar.Location = new System.Drawing.Point(21, 367);
            this.btn_guardar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btn_guardar.OnHoverBaseColor2 = System.Drawing.Color.MediumBlue;
            this.btn_guardar.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btn_guardar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_guardar.OnHoverImage = null;
            this.btn_guardar.OnPressedColor = System.Drawing.Color.Transparent;
            this.btn_guardar.Radius = 3;
            this.btn_guardar.Size = new System.Drawing.Size(327, 41);
            this.btn_guardar.TabIndex = 6;
            this.btn_guardar.Text = "GUARDAR";
            this.btn_guardar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox2.Location = new System.Drawing.Point(21, 118);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(327, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 116;
            this.pictureBox2.TabStop = false;
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
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 49);
            this.panel1.TabIndex = 114;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btn_minimizar
            // 
            this.btn_minimizar.BaseColor = System.Drawing.Color.White;
            this.btn_minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_minimizar.Image = global::Tecno_Pc.Properties.Resources.minimizar;
            this.btn_minimizar.Location = new System.Drawing.Point(667, 0);
            this.btn_minimizar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
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
            this.lbl_titulo.Size = new System.Drawing.Size(144, 20);
            this.lbl_titulo.TabIndex = 1;
            this.lbl_titulo.Text = "AÑADIR EMPLEADO";
            // 
            // btn_salir
            // 
            this.btn_salir.BaseColor = System.Drawing.Color.White;
            this.btn_salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salir.Image = global::Tecno_Pc.Properties.Resources.CerrarForm;
            this.btn_salir.Location = new System.Drawing.Point(713, 2);
            this.btn_salir.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
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
            this.gunaPictureBox1.Location = new System.Drawing.Point(5, 7);
            this.gunaPictureBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(37, 36);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gunaPictureBox1.TabIndex = 2;
            this.gunaPictureBox1.TabStop = false;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
            // 
            // cbo_depto
            // 
            this.cbo_depto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbo_depto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_depto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_depto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_depto.FormattingEnabled = true;
            this.cbo_depto.Location = new System.Drawing.Point(35, 305);
            this.cbo_depto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbo_depto.Name = "cbo_depto";
            this.cbo_depto.Size = new System.Drawing.Size(301, 28);
            this.cbo_depto.TabIndex = 4;
            this.cbo_depto.SelectedIndexChanged += new System.EventHandler(this.cbo_depto_SelectedIndexChanged);
            // 
            // erp_nombre
            // 
            this.erp_nombre.ContainerControl = this;
            // 
            // erp_telefono
            // 
            this.erp_telefono.ContainerControl = this;
            // 
            // erp_correo
            // 
            this.erp_correo.ContainerControl = this;
            // 
            // erp_direccion
            // 
            this.erp_direccion.ContainerControl = this;
            // 
            // erp_departamento
            // 
            this.erp_departamento.ContainerControl = this;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Tecno_Pc.Properties.Resources.FondoFormProd1;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(-1, -75);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(763, 538);
            this.panel2.TabIndex = 142;
            // 
            // frm_AñadirProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(761, 463);
            this.Controls.Add(this.cbo_depto);
            this.Controls.Add(this.txt_direccion);
            this.Controls.Add(this.gunaLabel9);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.gunaLabel5);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txt_telefono);
            this.Controls.Add(this.gunaLabel4);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.gunaLabel3);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frm_AñadirProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Añadir Proveedores";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_nombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_telefono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_correo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_direccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp_departamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_direccion;
        private Guna.UI.WinForms.GunaLabel gunaLabel9;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.TextBox txt_email;
        private Guna.UI.WinForms.GunaLabel gunaLabel5;
        private System.Windows.Forms.PictureBox pictureBox5;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txt_telefono;
        private Guna.UI.WinForms.GunaLabel gunaLabel4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox txt_nombre;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_id;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI.WinForms.GunaGradientButton btn_guardar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaPictureBox btn_minimizar;
        private Guna.UI.WinForms.GunaLabel lbl_titulo;
        private Guna.UI.WinForms.GunaPictureBox btn_salir;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private System.Windows.Forms.ComboBox cbo_depto;
        private System.Windows.Forms.ErrorProvider erp_nombre;
        private System.Windows.Forms.ErrorProvider erp_telefono;
        private System.Windows.Forms.ErrorProvider erp_correo;
        private System.Windows.Forms.ErrorProvider erp_direccion;
        private System.Windows.Forms.ErrorProvider erp_departamento;
        private System.Windows.Forms.Panel panel2;
    }
}