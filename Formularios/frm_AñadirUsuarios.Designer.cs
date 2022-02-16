
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
            this.cbo_categorias = new Guna.UI.WinForms.GunaComboBox();
            this.gunaLabel7 = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.gunaLabel4 = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.btn_guardar = new Guna.UI.WinForms.GunaGradientButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.gunaComboBox1 = new Guna.UI.WinForms.GunaComboBox();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_salir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_minimizar
            // 
            this.btn_minimizar.BaseColor = System.Drawing.Color.White;
            this.btn_minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_minimizar.Image = global::Tecno_Pc.Properties.Resources.minimizar;
            this.btn_minimizar.Location = new System.Drawing.Point(502, 2);
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
            this.lbl_titulo.Location = new System.Drawing.Point(37, 10);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(102, 15);
            this.lbl_titulo.TabIndex = 1;
            this.lbl_titulo.Text = "AÑADIR USUARIO";
            // 
            // btn_salir
            // 
            this.btn_salir.BaseColor = System.Drawing.Color.White;
            this.btn_salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salir.Image = global::Tecno_Pc.Properties.Resources.CerrarForm;
            this.btn_salir.Location = new System.Drawing.Point(532, 3);
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
            this.panel1.Size = new System.Drawing.Size(567, 40);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // cbo_categorias
            // 
            this.cbo_categorias.BackColor = System.Drawing.Color.White;
            this.cbo_categorias.BaseColor = System.Drawing.Color.White;
            this.cbo_categorias.BorderColor = System.Drawing.Color.Transparent;
            this.cbo_categorias.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_categorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_categorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_categorias.FocusedColor = System.Drawing.Color.Empty;
            this.cbo_categorias.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbo_categorias.ForeColor = System.Drawing.Color.Black;
            this.cbo_categorias.FormattingEnabled = true;
            this.cbo_categorias.Location = new System.Drawing.Point(19, 241);
            this.cbo_categorias.Name = "cbo_categorias";
            this.cbo_categorias.OnHoverItemBaseColor = System.Drawing.Color.Blue;
            this.cbo_categorias.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbo_categorias.Size = new System.Drawing.Size(227, 24);
            this.cbo_categorias.TabIndex = 81;
            // 
            // gunaLabel7
            // 
            this.gunaLabel7.AutoSize = true;
            this.gunaLabel7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel7.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel7.Location = new System.Drawing.Point(8, 215);
            this.gunaLabel7.Name = "gunaLabel7";
            this.gunaLabel7.Size = new System.Drawing.Size(29, 15);
            this.gunaLabel7.TabIndex = 79;
            this.gunaLabel7.Text = "ROL";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox6.Location = new System.Drawing.Point(12, 237);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(245, 31);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 70;
            this.pictureBox6.TabStop = false;
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel2.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel2.Location = new System.Drawing.Point(306, 141);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(68, 15);
            this.gunaLabel2.TabIndex = 68;
            this.gunaLabel2.Text = "EMPLEADO";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox3.Location = new System.Drawing.Point(310, 163);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(245, 31);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 67;
            this.pictureBox3.TabStop = false;
            // 
            // txt_nombre
            // 
            this.txt_nombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_nombre.CausesValidation = false;
            this.txt_nombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_nombre.Location = new System.Drawing.Point(19, 171);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(227, 16);
            this.txt_nombre.TabIndex = 66;
            // 
            // gunaLabel4
            // 
            this.gunaLabel4.AutoSize = true;
            this.gunaLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel4.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel4.Location = new System.Drawing.Point(8, 141);
            this.gunaLabel4.Name = "gunaLabel4";
            this.gunaLabel4.Size = new System.Drawing.Size(86, 15);
            this.gunaLabel4.TabIndex = 65;
            this.gunaLabel4.Text = "CONTRASEÑA ";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox4.Location = new System.Drawing.Point(12, 163);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(245, 31);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 64;
            this.pictureBox4.TabStop = false;
            // 
            // txt_codigo
            // 
            this.txt_codigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_codigo.CausesValidation = false;
            this.txt_codigo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_codigo.Location = new System.Drawing.Point(317, 97);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(227, 16);
            this.txt_codigo.TabIndex = 63;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel1.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel1.Location = new System.Drawing.Point(306, 67);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(56, 15);
            this.gunaLabel1.TabIndex = 62;
            this.gunaLabel1.Text = "USUARIO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox1.Location = new System.Drawing.Point(310, 89);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 31);
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
            this.txt_id.Location = new System.Drawing.Point(19, 97);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(227, 16);
            this.txt_id.TabIndex = 60;
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel3.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel3.Location = new System.Drawing.Point(8, 67);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(18, 15);
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
            this.btn_guardar.Location = new System.Drawing.Point(11, 323);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            this.btn_guardar.OnHoverBaseColor2 = System.Drawing.Color.MediumBlue;
            this.btn_guardar.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btn_guardar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_guardar.OnHoverImage = null;
            this.btn_guardar.OnPressedColor = System.Drawing.Color.Transparent;
            this.btn_guardar.Radius = 3;
            this.btn_guardar.Size = new System.Drawing.Size(543, 34);
            this.btn_guardar.TabIndex = 57;
            this.btn_guardar.Text = "MODIFICAR";
            this.btn_guardar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Tecno_Pc.Properties.Resources.CajaTexto;
            this.pictureBox2.Location = new System.Drawing.Point(12, 89);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(245, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 58;
            this.pictureBox2.TabStop = false;
            // 
            // gunaComboBox1
            // 
            this.gunaComboBox1.BackColor = System.Drawing.Color.White;
            this.gunaComboBox1.BaseColor = System.Drawing.Color.White;
            this.gunaComboBox1.BorderColor = System.Drawing.Color.Transparent;
            this.gunaComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gunaComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gunaComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gunaComboBox1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaComboBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaComboBox1.ForeColor = System.Drawing.Color.Black;
            this.gunaComboBox1.FormattingEnabled = true;
            this.gunaComboBox1.Location = new System.Drawing.Point(317, 167);
            this.gunaComboBox1.Name = "gunaComboBox1";
            this.gunaComboBox1.OnHoverItemBaseColor = System.Drawing.Color.Blue;
            this.gunaComboBox1.OnHoverItemForeColor = System.Drawing.Color.White;
            this.gunaComboBox1.Size = new System.Drawing.Size(227, 24);
            this.gunaComboBox1.TabIndex = 84;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
            // 
            // frm_AñadirUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(567, 369);
            this.Controls.Add(this.gunaComboBox1);
            this.Controls.Add(this.cbo_categorias);
            this.Controls.Add(this.gunaLabel7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.gunaLabel4);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.txt_codigo);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.gunaLabel3);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_AñadirUsuarios";
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaPictureBox btn_minimizar;
        private Guna.UI.WinForms.GunaLabel lbl_titulo;
        private Guna.UI.WinForms.GunaPictureBox btn_salir;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaComboBox cbo_categorias;
        private Guna.UI.WinForms.GunaLabel gunaLabel7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txt_nombre;
        private Guna.UI.WinForms.GunaLabel gunaLabel4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox txt_codigo;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_id;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI.WinForms.GunaGradientButton btn_guardar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI.WinForms.GunaComboBox gunaComboBox1;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
    }
}