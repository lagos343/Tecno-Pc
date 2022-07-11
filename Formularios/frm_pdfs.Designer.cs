
namespace Tecno_Pc.Formularios
{
    partial class frm_pdfs
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
            this.pdfViewer1 = new PdfiumViewer.PdfViewer();
            this.btn_cerar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.BackColor = System.Drawing.Color.White;
            this.pdfViewer1.Location = new System.Drawing.Point(12, 0);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Size = new System.Drawing.Size(1090, 705);
            this.pdfViewer1.TabIndex = 0;
            // 
            // btn_cerar
            // 
            this.btn_cerar.BackColor = System.Drawing.Color.White;
            this.btn_cerar.BackgroundImage = global::Tecno_Pc.Properties.Resources.EliminarProducto;
            this.btn_cerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_cerar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btn_cerar.FlatAppearance.BorderSize = 0;
            this.btn_cerar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            this.btn_cerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            this.btn_cerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerar.Location = new System.Drawing.Point(10, 0);
            this.btn_cerar.Name = "btn_cerar";
            this.btn_cerar.Size = new System.Drawing.Size(25, 25);
            this.btn_cerar.TabIndex = 1;
            this.btn_cerar.UseVisualStyleBackColor = false;
            this.btn_cerar.Click += new System.EventHandler(this.btn_cerar_Click);
            this.btn_cerar.MouseEnter += new System.EventHandler(this.btn_cerar_MouseEnter);
            this.btn_cerar.MouseLeave += new System.EventHandler(this.btn_cerar_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(1056, -10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(79, 35);
            this.panel1.TabIndex = 2;
            // 
            // frm_pdfs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1114, 705);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_cerar);
            this.Controls.Add(this.pdfViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_pdfs";
            this.Text = "frm_pdfs";
            this.ResumeLayout(false);

        }

        #endregion

        private PdfiumViewer.PdfViewer pdfViewer1;
        private System.Windows.Forms.Button btn_cerar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
    }
}