using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;


namespace Repuestos_Arias.Clases
{
    public class Cl_RecuperarContraseña
    {
        Cl_UsuarioLogueado user = new Cl_UsuarioLogueado();
        private string correo_recuperacion = "repuestosarias343@gmail.com";
        private string contraseña_correo_recuperacion = "Arias4820_Licona";
        private MailMessage mmsg = new MailMessage();
        SmtpClient cliente = new SmtpClient();

        public string Correo_recuperacion { get => correo_recuperacion; set => correo_recuperacion = value; }
        public string Contraseña_correo_recuperacion { get => contraseña_correo_recuperacion; set => contraseña_correo_recuperacion = value; }        

        public void EnviarCorreo()
        {              
            mmsg.To.Add(user.Correo_);
            mmsg.Subject = "Recuperacion de Datos";
            mmsg.SubjectEncoding = Encoding.UTF8;
            mmsg.Body = "Señor " +user.Propietario_ + ", su contraseña es: " + user.Contraseña_;
            mmsg.BodyEncoding = Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new MailAddress(Correo_recuperacion);
            
            cliente.Credentials = new NetworkCredential(Correo_recuperacion, Contraseña_correo_recuperacion);
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";

            try
            {
                cliente.Send(mmsg);
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("Se ha enviado un Email con los datos de inicio de sesion",1);
                noti.ShowDialog();
                noti.Close();
            }
            catch (Exception ex)
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("Revise su coneccion a Internet para poder enviar el Email", 3);
                noti.ShowDialog();
                noti.Close();
            }

        }
        
    }
}
