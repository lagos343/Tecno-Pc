using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc.Formularios
{
    public partial class frm_pdfs : Form
    {
        //variable que almacena el form anterior que se reabrira al salir de la vista del pdf
        Form Form_Anterior;
        public frm_pdfs(string filepath, Form frm) //contructor que recibe la ruta del reporte y el form desde el cual se llama
        {
            InitializeComponent();
            toolTip1.SetToolTip(this.btn_cerar, "Cerrar Vista");
            vizulizarPdf(filepath);
            Form_Anterior = frm;
        }

        private void vizulizarPdf(string filepath) //se envcarga de mostrar el pdf seleccionado
        {
            byte[] bytes = System.IO.File.ReadAllBytes(filepath);
            var stream = new System.IO.MemoryStream(bytes);
            PdfDocument pdf = PdfDocument.Load(stream);
            pdfViewer1.Document = pdf;
        }

        private void btn_cerar_Click(object sender, EventArgs e)
        {
            // Abrimos el Form anterior que mando a vizualizar el pdf
            Formularios.frm_principal frm = Application.OpenForms.OfType<Formularios.frm_principal>().SingleOrDefault();
            frm.AbrirFormulario(Form_Anterior);
        }       

        //apariencia de el boton de cerrado
        private void btn_cerar_MouseLeave(object sender, EventArgs e)
        {
            btn_cerar.FlatAppearance.BorderSize = 0;
        }

        private void btn_cerar_MouseEnter(object sender, EventArgs e)
        {
            btn_cerar.FlatAppearance.BorderSize = 1;
        }
    }
}
