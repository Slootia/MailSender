﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EmailSendServiceDLL;

namespace WpfMailSender
{
    class EmailSendServiceClass
    {
        #region vars
        private string strLogin;         // email, c которого будет рассылаться почта
        private string strPassword;  // пароль к email, с которого будет рассылаться почта
        private string strSmtp; // smtp-server
        private int iSmtpPort;                // порт для smtp-server
        private string strBody;                    // текст письма для отправки
        private string strSubject;                 // тема письма для отправки
        #endregion
        public EmailSendServiceClass(string sLogin, string sPassword,
            string smtp,
            string smtpPort,
            string body,
            string subject)
        {
            strLogin = sLogin;
            strPassword = sPassword;
            strSmtp = smtp;
            iSmtpPort = Convert.ToInt32(smtpPort);
            strBody = body;
            strSubject = subject;
        }
        private void SendMail(string mail, string name) // Отправка email конкретному адресату
        {
            EmailSendServiceDLL.EmailSendServiceClass emailSendService = new EmailSendServiceDLL.EmailSendServiceClass(
                strLogin,
                strPassword,
                strSmtp,
                iSmtpPort,
                strBody,
                strSubject);
            emailSendService.SendMail(mail, name);
        }
        public void SendMails(ObservableCollection<Email> emails)
        {
            try
            {
                foreach (Email email in emails)
                {
                    SendMail(email.Email1, email.Name);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при отправке сообщения");
            }
        }

    }
}
