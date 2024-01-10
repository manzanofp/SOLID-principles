using System.Net.Mail;

namespace SOLID._1_SRP.SRP_JeitoCerto.Services
{

    // essa classe está sendo responsável apenas por Validar e enviar o email!
    public class EmailService
    {
        public static bool IsValid(string email)
        {
            return email.Contains("@");
        }

        public static void Enviar(string de, string para, string assunto, string mensagem)
        {
            var mail = new MailMessage(de, para);
            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };

            mail.Subject = assunto;
            mail.Body = mensagem;
            client.Send(mail);
        }
    }
}
