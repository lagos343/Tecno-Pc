using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tecno_Pc
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary  
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form frm = new Form();
            frm = new Formularios.frm_ConfigurarDB(false);

            if (Properties.Settings.Default.Servidor == string.Empty)
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("Detectamos que es su primer inicio de Sesion, antes de empezar debe llenar correctamente el siguiente formulario", 1);
                noti.ShowDialog();
                noti.Close();
                Application.Run(frm);
            }
            else
            {
                Application.Run(new Form1());
            }                       
        }
    }
}
