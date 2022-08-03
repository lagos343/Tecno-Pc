
namespace Tecno_Pc.Formularios
{
    partial class frm_notificacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_notificacion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pic_exclamation = new System.Windows.Forms.PictureBox();
            this.pic_confirmation = new System.Windows.Forms.PictureBox();
            this.lbl_Mensaje = new Guna.UI.WinForms.GunaLabel();
            this.btn_confirmar = new Guna.UI.WinForms.GunaButton();
            this.btn_cancelar = new Guna.UI.WinForms.GunaButton();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaCircleProgressBar1 = new Guna.UI.WinForms.GunaCircleProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_exclamation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_confirmation)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.pic_exclamation);
            this.panel1.Controls.Add(this.pic_confirmation);
            this.panel1.Location = new System.Drawing.Point(-2, -7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 128);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // pic_exclamation
            // 
            this.pic_exclamation.Image = ((System.Drawing.Image)(resources.GetObject("pic_exclamation.Image")));
            this.pic_exclamation.Location = new System.Drawing.Point(18, 19);
            this.pic_exclamation.Name = "pic_exclamation";
            this.pic_exclamation.Size = new System.Drawing.Size(161, 95);
            this.pic_exclamation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_exclamation.TabIndex = 1;
            this.pic_exclamation.TabStop = false;
            this.pic_exclamation.Visible = false;
            this.pic_exclamation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_exclamation_MouseDown);
            // 
            // pic_confirmation
            // 
            this.pic_confirmation.Image = ((System.Drawing.Image)(resources.GetObject("pic_confirmation.Image")));
            this.pic_confirmation.Location = new System.Drawing.Point(18, 19);
            this.pic_confirmation.Name = "pic_confirmation";
            this.pic_confirmation.Size = new System.Drawing.Size(161, 95);
            this.pic_confirmation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_confirmation.TabIndex = 0;
            this.pic_confirmation.TabStop = false;
            this.pic_confirmation.Visible = false;
            this.pic_confirmation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_confirmation_MouseDown);
            // 
            // lbl_Mensaje
            // 
            this.lbl_Mensaje.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Mensaje.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Mensaje.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Mensaje.Location = new System.Drawing.Point(12, 133);
            this.lbl_Mensaje.Name = "lbl_Mensaje";
            this.lbl_Mensaje.Size = new System.Drawing.Size(167, 102);
            this.lbl_Mensaje.TabIndex = 2;
            this.lbl_Mensaje.Text = "lbl_Mensaje";
            this.lbl_Mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_confirmar
            // 
            this.btn_confirmar.AnimationHoverSpeed = 0.07F;
            this.btn_confirmar.AnimationSpeed = 0.03F;
            this.btn_confirmar.BackColor = System.Drawing.Color.Transparent;
            this.btn_confirmar.BaseColor = System.Drawing.Color.Teal;
            this.btn_confirmar.BorderColor = System.Drawing.Color.Transparent;
            this.btn_confirmar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_confirmar.FocusedColor = System.Drawing.Color.Empty;
            this.btn_confirmar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirmar.ForeColor = System.Drawing.Color.White;
            this.btn_confirmar.Image = null;
            this.btn_confirmar.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_confirmar.Location = new System.Drawing.Point(12, 238);
            this.btn_confirmar.Name = "btn_confirmar";
            this.btn_confirmar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_confirmar.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btn_confirmar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_confirmar.OnHoverImage = null;
            this.btn_confirmar.OnPressedColor = System.Drawing.Color.Transparent;
            this.btn_confirmar.Radius = 3;
            this.btn_confirmar.Size = new System.Drawing.Size(63, 24);
            this.btn_confirmar.TabIndex = 3;
            this.btn_confirmar.Text = "Aceptar";
            this.btn_confirmar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_confirmar.Visible = false;
            this.btn_confirmar.Click += new System.EventHandler(this.btn_confirmar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.AnimationHoverSpeed = 0.07F;
            this.btn_cancelar.AnimationSpeed = 0.03F;
            this.btn_cancelar.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancelar.BaseColor = System.Drawing.Color.Maroon;
            this.btn_cancelar.BorderColor = System.Drawing.Color.Transparent;
            this.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_cancelar.FocusedColor = System.Drawing.Color.Empty;
            this.btn_cancelar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.ForeColor = System.Drawing.Color.White;
            this.btn_cancelar.Image = null;
            this.btn_cancelar.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_cancelar.Location = new System.Drawing.Point(85, 238);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_cancelar.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btn_cancelar.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_cancelar.OnHoverImage = null;
            this.btn_cancelar.OnPressedColor = System.Drawing.Color.Transparent;
            this.btn_cancelar.Radius = 3;
            this.btn_cancelar.Size = new System.Drawing.Size(63, 24);
            this.btn_cancelar.TabIndex = 4;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_cancelar.Visible = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaCircleProgressBar1
            // 
            this.gunaCircleProgressBar1.AnimationSpeed = 0.6F;
            this.gunaCircleProgressBar1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gunaCircleProgressBar1.IdleColor = System.Drawing.Color.Empty;
            this.gunaCircleProgressBar1.IdleOffset = 20;
            this.gunaCircleProgressBar1.IdleThickness = 15;
            this.gunaCircleProgressBar1.Image = null;
            this.gunaCircleProgressBar1.ImageSize = new System.Drawing.Size(52, 52);
            this.gunaCircleProgressBar1.Location = new System.Drawing.Point(35, 133);
            this.gunaCircleProgressBar1.Name = "gunaCircleProgressBar1";
            this.gunaCircleProgressBar1.ProgressMaxColor = System.Drawing.Color.Teal;
            this.gunaCircleProgressBar1.ProgressMinColor = System.Drawing.Color.Teal;
            this.gunaCircleProgressBar1.ProgressOffset = 20;
            this.gunaCircleProgressBar1.ProgressThickness = 15;
            this.gunaCircleProgressBar1.Size = new System.Drawing.Size(121, 120);
            this.gunaCircleProgressBar1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Tecno_Pc.Properties.Resources.FondoFormNoti;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(0, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(193, 274);
            this.panel2.TabIndex = 6;
            // 
            // frm_notificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(194, 274);
            this.ControlBox = false;
            this.Controls.Add(this.gunaCircleProgressBar1);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_confirmar);
            this.Controls.Add(this.lbl_Mensaje);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_notificacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_notificacion_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_exclamation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_confirmation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaLabel lbl_Mensaje;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pic_confirmation;
        private Guna.UI.WinForms.GunaButton btn_cancelar;
        private Guna.UI.WinForms.GunaButton btn_confirmar;
        private System.Windows.Forms.PictureBox pic_exclamation;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaCircleProgressBar gunaCircleProgressBar1;
        private System.Windows.Forms.Panel panel2;
    }
}