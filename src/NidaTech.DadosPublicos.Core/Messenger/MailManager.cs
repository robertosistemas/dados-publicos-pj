using System.ComponentModel;
using System.Net;
using System.Net.Mail;

namespace NidaTech.DadosPublicos.Messenger
{
    public class MailManager
    {
        public void SendMail()
        {
            var credentials = new NetworkCredential("contato@basepj.com.br", "!Robzohomail2");

            var client = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                Host = "smtp.zoho.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = credentials
            };

            //var mailMessage = new MailMessage("contato@basepj.com.br", "robertosistemas@hotmail.com", "teste envio e-mail csharp", "isso é um teste de envio de e-mail csharp");

            var mailMessage = new MailMessage
            {
                From = new MailAddress("contato@basepj.com.br", "contato-basepj"),
                Subject = "teste envio e-mail csharp",
                Body = "isso é um teste de envio de e-mail csharp",
                IsBodyHtml = false,
                BodyEncoding = System.Text.Encoding.Unicode
            };
            mailMessage.To.Add(new MailAddress("robertosistemas@hotmail.com", "Roberto Carlos"));

            string userState = System.Guid.NewGuid().ToString().ToLower();
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            client.SendAsync(mailMessage, userState);

        }

        //static bool mailSent = false;

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            string token = (string)e.UserState;
            string result;

            if (e.Cancelled)
            {
                result = string.Format("[{0}] Send canceled.", token);
            }

            if (e.Error != null)
            {
                result = string.Format("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                result = "Message sent.";
            }

            //mailSent = true;

        }

    }
}
