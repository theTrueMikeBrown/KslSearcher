using System.Net.Mail;

namespace KslSearcher
{
    public class Sender
    {
        private string _emailAddress;
        private string _smtpServer;
        private string _userName;
        private string _password;

        public Sender(string emailAddress, string userName, string password, string smtpServer = "smtp.gmail.com")
        {
            _emailAddress = emailAddress;
            _userName = userName;
            _password = password;
            _smtpServer = smtpServer;
        }

        public void SendEmail(string toAddress, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(_smtpServer);
            
            mail.From = new MailAddress(_emailAddress);
            mail.To.Add(toAddress);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(_userName, _password);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}