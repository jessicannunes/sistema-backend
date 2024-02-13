using System.Net;
using System.Net.Mail;

namespace Programacaodozero.Common
{
    public class Emailsender
    {
        public void Enviar(string assunto, string corpo, string emailDestino)
        {
            var fromEmail = "contato@renatogava.com.br";
            var fromPassword = "";
            var fromHost = "";
            var fromPort = 587;

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(fromEmail);

            mail.To.Add(new MailAddress(emailDestino));

            mail.Subject = assunto;

            mail.Body = corpo;

            using (SmtpClient smtp = new SmtpClient(fromHost, fromPort)){

                smtp.UseDefaultCredentials = false;

                smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);

                smtp.EnableSsl = true;

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(mail);

            }
            
        }
    }
}
