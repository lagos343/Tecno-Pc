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
        Cl_UsuarioLogueado user_log = new Cl_UsuarioLogueado();

        private string correo_recuperacion = "pctecno536@gmail.com";
        private string contraseña_correo_recuperacion = "gbpuasibhhsjxcrp";
        private MailMessage mmsg_recuperacion = new MailMessage();
        SmtpClient cliente_bd = new SmtpClient();

        public string correos_recuperacion { get => correo_recuperacion; set => correo_recuperacion = value; }
        public string contraseñas_correo_recuperacion { get => contraseña_correo_recuperacion; set => contraseña_correo_recuperacion = value; }        

        public void Enviar_correo() //procedimientoo que se encarga dde lo correos electronicos para recuperar contraseña
        {
            //creacion de el mensaje y su cuerpo 
            mmsg_recuperacion.To.Add(user_log.Correo_Usuario);
            mmsg_recuperacion.Subject = "Recuperacion de Contraseña Tecno Pc";
            mmsg_recuperacion.SubjectEncoding = Encoding.UTF8;
            mmsg_recuperacion.Body = "<p><b>Hola " +user_log.Propietario_Usuario + "</b><br><b>ha solicitado una recuperacion de contraseña</b><br><b>su contraseña actual es: " + user_log.Contraseña_Usuario +
            "</b><br><b>recomendamos solicite un cambio de contraseña al ingresar de nuevo al sistema por seguridad</b></p>";
            mmsg_recuperacion.BodyEncoding = Encoding.UTF8;
            mmsg_recuperacion.IsBodyHtml = true;

            //extraemos el corrreo destinatario de el usuario que intento loguearse
            mmsg_recuperacion.From = new MailAddress(correos_recuperacion);
            
            //configuramos el cliente stmp dependiendo del dominio de el email (Gmail en este caso)  
            cliente_bd.Credentials = new NetworkCredential(correos_recuperacion, contraseñas_correo_recuperacion);
            cliente_bd.Port = 587;
            cliente_bd.EnableSsl = true;
            cliente_bd.Host = "smtp.gmail.com";

            try  //se intenta enviar el correo 
            {
                cliente_bd.Send(mmsg_recuperacion);
                Formularios.frm_notificacion noti_recuperacion = new Formularios.frm_notificacion("Se ha enviado un Email con los datos de inicio de sesion",1);
                noti_recuperacion.ShowDialog();
                noti_recuperacion.Close();
            }
            catch (Exception ex) //si da error, se notifica 
            {
                Formularios.frm_notificacion noti_recuperacion = new Formularios.frm_notificacion("Revise su coneccion a Internet para poder enviar el Email", 3);
                noti_recuperacion.ShowDialog();
                noti_recuperacion.Close();
            }
        }        
    }
}
