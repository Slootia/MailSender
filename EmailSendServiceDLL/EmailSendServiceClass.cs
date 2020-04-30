using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmailSendServiceDLL
{
    public class EmailSendServiceClass
    {
        #region vars
        private string strLogin;
        private string strPassword;
        private string strSmtp;
        private int iSmtpPort;
        private string strBody;
        private string strSubject;
        #endregion
        public EmailSendServiceClass(string sLogin,
            string sPassword,
            string smtp,
            int smtpPort,
            string body,
            string subject)
        {
            strLogin = sLogin;
            strPassword = sPassword;
            strSmtp = smtp;
            iSmtpPort = smtpPort;
            strBody = body;
            strSubject = subject;
        }
        public void SendMail(string mail, string name) // Отправка email конкретному адресату
        {
            using (MailMessage mm = new MailMessage(strLogin, mail))
            {
                mm.Subject = strSubject;
                mm.IsBodyHtml = false;
                mm.Body = strBody;
                SmtpClient sc = new SmtpClient(strSmtp, iSmtpPort)
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(strLogin, strPassword)
                };
                sc.Send(mm);
            }
        }
    }
}
