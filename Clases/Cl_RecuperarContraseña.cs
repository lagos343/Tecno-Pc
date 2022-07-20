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


namespace Tecno_Pc.Clases
{
    public class Cl_RecuperarContraseña
    {
        //variables que serviran para la recuperacion de contraseña
        Cl_UsuarioLogueado user = new Cl_UsuarioLogueado();

        private string correo_recuperacion = "pctecno536@gmail.com";
        private string contraseña_correo_recuperacion = "gbpuasibhhsjxcrp";
        private MailMessage mmsg = new MailMessage();
        SmtpClient cliente = new SmtpClient();

        public string Correo_recuperacion { get => correo_recuperacion; set => correo_recuperacion = value; }
        public string Contraseña_correo_recuperacion { get => contraseña_correo_recuperacion; set => contraseña_correo_recuperacion = value; }        

        public void EnviarCorreo() //procedimientoo que se encarga dde lo correos electronicos para recuperar contraseña
        {  
            //creacion de el mensaje y su cuerpo 
            mmsg.To.Add(user.Correo_);
            mmsg.Subject = "Recuperacion de Contraseña Tecno Pc";
            mmsg.SubjectEncoding = Encoding.UTF8;
            mmsg.Body = "<p><b>Hola " +user.Propietario_ + "</b><br><b>ha solicitado una recuperacion de contraseña</b><br><b>su contraseña actual es: " + user.Contraseña_ +
            "</b><br><b>recomendamos solicite un cambio de contraseña al ingresar de nuevo al sistema por seguridad</b></p>";
            mmsg.BodyEncoding = Encoding.UTF8;
            mmsg.IsBodyHtml = true;

            //extraemos el corrreo destinatario de el usuario que intento loguearse
            mmsg.From = new MailAddress(Correo_recuperacion);
            
            //configuramos el cliente stmp dependiendo del dominio de el email (Gmail en este caso)  
            cliente.Credentials = new NetworkCredential(Correo_recuperacion, Contraseña_correo_recuperacion);
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";

            try  //se intenta enviar el correo 
            {
                cliente.Send(mmsg);
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("Se ha enviado un Email con los datos de inicio de sesion",1);
                noti.ShowDialog();
                noti.Close();
            }
            catch (Exception ex) //si da error, se notifica 
            {
                Formularios.frm_notificacion noti = new Formularios.frm_notificacion("Revise su coneccion a Internet para poder enviar el Email", 3);
                noti.ShowDialog();
                noti.Close();
            }
        }        
    }
}
