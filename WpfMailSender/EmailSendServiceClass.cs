using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMailSender
{
    class EmailSendServiceClass
    {
        public void StartMailing()
        {
            try
            {
                foreach (var email in Letter.ReceiverList)
                {
                    SendMail(email);
                }
            }
            catch
            {
                var errorWindow = new SendErrorWindow();
                errorWindow.ShowDialog();
            }
            var endWindow = new SendEndWindow();
            endWindow.ShowDialog();
        }

        private void SendMail(string mail)
        {
            using (var mm = new MailMessage(Letter.SenderEmail, mail))
            {
                mm.Subject = Letter.Subject;
                mm.Body = Letter.Body;
                mm.IsBodyHtml = false;
                using (var sc = new SmtpClient(ConnectionData.SmtpClient, ConnectionData.SmtpPort))
                {
                    sc.EnableSsl = true;
                    sc.UseDefaultCredentials = false;
                    sc.Credentials = new NetworkCredential(Letter.SenderEmail, Letter.SenderPassword);
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.Send(mm);
                }
            }
        }
    }
}
