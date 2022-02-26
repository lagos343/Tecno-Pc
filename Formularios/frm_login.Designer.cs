
namespace Tecno_Pc
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btn_CerrarLogin = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chk_paswordChar = new Guna.UI.WinForms.GunaCheckBox();
            this.txt_userName = new Guna.UI.WinForms.GunaLineTextBox();
            this.txt_pasword = new Guna.UI.WinForms.GunaLineTextBox();
            this.btn_ingresar = new Guna.UI.WinForms.GunaButton();
            this.lnk_Re_usu_contra = new Guna.UI.WinForms.GunaLinkLabel();
            this.error_usuario = new System.Windows.Forms.ErrorProvider(this.components);
            this.error_contraseña = new System.Windows.Forms.ErrorProvider(this.components);
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.elipseControl3 = new Tecno_Pc.Clases.ElipseControl();
            this.elipseControl1 = new Tecno_Pc.Clases.ElipseControl();
            this.elipseComponent1 = new Tecno_Pc.Clases.ElipseComponent();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_CerrarLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_usuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_contraseña)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.guna2PictureBox1);
            this.panel1.Controls.Add(this.btn_CerrarLogin);
            this.panel1.Controls.Add(this.elipseControl1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-8, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 227);
            this.panel1.TabIndex = 0;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Teal;
            this.guna2PictureBox1.BackgroundImage = global::Tecno_Pc.Properties.Resources.Repuestos_Arias;
            this.guna2PictureBox1.Image = global::Tecno_Pc.Properties.Resources.LogoTecnoPc;
            this.guna2PictureBox1.Location = new System.Drawing.Point(3, 38);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(84, 52);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 3;
            this.guna2PictureBox1.TabStop = false;
            // 
            // btn_CerrarLogin
            // 
            this.btn_CerrarLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CerrarLogin.Image = global::Tecno_Pc.Properties.Resources.cerrar;
            this.btn_CerrarLogin.Location = new System.Drawing.Point(284, 17);
            this.btn_CerrarLogin.Name = "btn_CerrarLogin";
            this.btn_CerrarLogin.Size = new System.Drawing.Size(37, 36);
            this.btn_CerrarLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_CerrarLogin.TabIndex = 1;
            this.btn_CerrarLogin.TabStop = false;
            this.btn_CerrarLogin.Click += new System.EventHandler(this.btn_CerrarLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tecno_Pc.Properties.Resources.perfil_avatar_hombre_icono_redondo;
            this.pictureBox1.Location = new System.Drawing.Point(91, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 159);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(128, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(109, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "DATOS USUARIO";
            // 
            // chk_paswordChar
            // 
            this.chk_paswordChar.BaseColor = System.Drawing.Color.DarkGray;
            this.chk_paswordChar.CheckedOffColor = System.Drawing.Color.Gray;
            this.chk_paswordChar.CheckedOnColor = System.Drawing.Color.Teal;
            this.chk_paswordChar.FillColor = System.Drawing.Color.Transparent;
            this.chk_paswordChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_paswordChar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chk_paswordChar.Location = new System.Drawing.Point(74, 383);
            this.chk_paswordChar.Name = "chk_paswordChar";
            this.chk_paswordChar.Radius = 3;
            this.chk_paswordChar.Size = new System.Drawing.Size(119, 20);
            this.chk_paswordChar.TabIndex = 8;
            this.chk_paswordChar.Text = "ver contraseña";
            this.chk_paswordChar.CheckedChanged += new System.EventHandler(this.chk_paswordChar_CheckedChanged);
            // 
            // txt_userName
            // 
            this.txt_userName.BackColor = System.Drawing.Color.White;
            this.txt_userName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_userName.FocusedLineColor = System.Drawing.Color.Teal;
            this.txt_userName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_userName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_userName.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_userName.LineSize = 2;
            this.txt_userName.Location = new System.Drawing.Point(60, 293);
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.PasswordChar = '\0';
            this.txt_userName.SelectedText = "";
            this.txt_userName.Size = new System.Drawing.Size(200, 30);
            this.txt_userName.TabIndex = 10;
            this.txt_userName.Text = "Usuario";
            this.txt_userName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_userName.TextChanged += new System.EventHandler(this.txt_userName_TextChanged);
            this.txt_userName.Enter += new System.EventHandler(this.txt_userName_Enter);
            this.txt_userName.Leave += new System.EventHandler(this.txt_userName_Leave);
            // 
            // txt_pasword
            // 
            this.txt_pasword.Animated = true;
            this.txt_pasword.BackColor = System.Drawing.Color.White;
            this.txt_pasword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_pasword.FocusedLineColor = System.Drawing.Color.Teal;
            this.txt_pasword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_pasword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_pasword.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_pasword.LineSize = 2;
            this.txt_pasword.Location = new System.Drawing.Point(60, 334);
            this.txt_pasword.Name = "txt_pasword";
            this.txt_pasword.PasswordChar = '\0';
            this.txt_pasword.SelectedText = "";
            this.txt_pasword.Size = new System.Drawing.Size(200, 30);
            this.txt_pasword.TabIndex = 11;
            this.txt_pasword.Text = "Contraseña";
            this.txt_pasword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_pasword.TextChanged += new System.EventHandler(this.txt_pasword_TextChanged);
            this.txt_pasword.Enter += new System.EventHandler(this.txt_pasword_Enter);
            this.txt_pasword.Leave += new System.EventHandler(this.txt_pasword_Leave);
            // 
            // btn_ingresar
            // 
            this.btn_ingresar.AnimationHoverSpeed = 0.07F;
            this.btn_ingresar.AnimationSpeed = 0.03F;
            this.btn_ingresar.BaseColor = System.Drawing.Color.Teal;
            this.btn_ingresar.BorderColor = System.Drawing.Color.Teal;
            this.btn_ingresar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_ingresar.FocusedColor = System.Drawing.Color.Empty;
            this.btn_ingresar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_ingresar.ForeColor = System.Drawing.Color.White;
            this.btn_ingresar.Image = null;
            this.btn_ingresar.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_ingresar.Location = new System.Drawing.Point(201, 445);
            this.btn_ingresar.Name = "btn_ingresar";
            this.btn_ingresar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_ingresar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_ingresar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_ingresar.OnHoverImage = null;
            this.btn_ingresar.OnPressedColor = System.Drawing.Color.Black;
            this.btn_ingresar.Size = new System.Drawing.Size(111, 30);
            this.btn_ingresar.TabIndex = 12;
            this.btn_ingresar.Text = "INGRESAR";
            this.btn_ingresar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_ingresar.Click += new System.EventHandler(this.btn_ingresar_Click);
            // 
            // lnk_Re_usu_contra
            // 
            this.lnk_Re_usu_contra.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnk_Re_usu_contra.AutoSize = true;
            this.lnk_Re_usu_contra.BackColor = System.Drawing.Color.Transparent;
            this.lnk_Re_usu_contra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lnk_Re_usu_contra.LinkColor = System.Drawing.Color.Teal;
            this.lnk_Re_usu_contra.Location = new System.Drawing.Point(70, 406);
            this.lnk_Re_usu_contra.Name = "lnk_Re_usu_contra";
            this.lnk_Re_usu_contra.Size = new System.Drawing.Size(170, 19);
            this.lnk_Re_usu_contra.TabIndex = 13;
            this.lnk_Re_usu_contra.TabStop = true;
            this.lnk_Re_usu_contra.Text = "he olvidado mi contraseña";
            this.lnk_Re_usu_contra.Visible = false;
            this.lnk_Re_usu_contra.VisitedLinkColor = System.Drawing.Color.Red;
            this.lnk_Re_usu_contra.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_Re_usu_contra_LinkClicked);
            // 
            // error_usuario
            // 
            this.error_usuario.ContainerControl = this;
            // 
            // error_contraseña
            // 
            this.error_contraseña.ContainerControl = this;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 3;
            this.gunaElipse1.TargetControl = this.btn_ingresar;
            // 
            // elipseControl3
            // 
            this.elipseControl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.elipseControl3.CornerRadius = 10;
            this.elipseControl3.ForeColor = System.Drawing.Color.Teal;
            this.elipseControl3.Location = new System.Drawing.Point(44, 239);
            this.elipseControl3.Name = "elipseControl3";
            this.elipseControl3.Size = new System.Drawing.Size(237, 39);
            this.elipseControl3.TabIndex = 4;
            this.elipseControl3.Text = "elipseControl3";
            // 
            // elipseControl1
            // 
            this.elipseControl1.BackColor = System.Drawing.Color.Teal;
            this.elipseControl1.CornerRadius = 15;
            this.elipseControl1.ForeColor = System.Drawing.Color.Teal;
            this.elipseControl1.Location = new System.Drawing.Point(0, 29);
            this.elipseControl1.Name = "elipseControl1";
            this.elipseControl1.Size = new System.Drawing.Size(87, 70);
            this.elipseControl1.TabIndex = 2;
            this.elipseControl1.Text = "elipseControl1";
            // 
            // elipseComponent1
            // 
            this.elipseComponent1.CornerRadius = 15;
            this.elipseComponent1.TargetControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(324, 487);
            this.ControlBox = false;
            this.Controls.Add(this.lnk_Re_usu_contra);
            this.Controls.Add(this.btn_ingresar);
            this.Controls.Add(this.txt_pasword);
            this.Controls.Add(this.txt_userName);
            this.Controls.Add(this.chk_paswordChar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.elipseControl3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_CerrarLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_usuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error_contraseña)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Clases.ElipseComponent elipseComponent1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Clases.ElipseControl elipseControl1;
        private System.Windows.Forms.PictureBox btn_CerrarLogin;
        private System.Windows.Forms.Label label2;
        private Clases.ElipseControl elipseControl3;
        private Guna.UI.WinForms.GunaCheckBox chk_paswordChar;
        private Guna.UI.WinForms.GunaLineTextBox txt_userName;
        private Guna.UI.WinForms.GunaLineTextBox txt_pasword;
        private Guna.UI.WinForms.GunaButton btn_ingresar;
        private Guna.UI.WinForms.GunaLinkLabel lnk_Re_usu_contra;
        private System.Windows.Forms.ErrorProvider error_usuario;
        private System.Windows.Forms.ErrorProvider error_contraseña;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private System.Windows.Forms.ToolTip ttMensaje;
    }
}

