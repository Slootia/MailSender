using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using MahApps.Metro.Controls;
using WpfMailSender.ViewModel;

namespace WpfMailSender
{
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
            customControllSender.Dictionary = EmailsClass.Senders;
            customControllSmtp.Dictionary = SmtpClass.SmtpDictionary;
        }

        private void miClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnClock_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedItem = tabPlanner;
        }

        private void btnSendAtOnce_Click(object sender, RoutedEventArgs e)
        {
            var start = rtbBody.Document.ContentStart;
            var end = rtbBody.Document.ContentEnd;
            int difference = start.GetOffsetToPosition(end);
            if (difference <= 0 || difference == 4 || tbSubject.Text.Length == 0)
            {
                MessageBox.Show("Письмо или тема не заполнены");
                tabControl.SelectedIndex = 2;
                return;
            }
            string strLogin = customControllSender.SelectedItem.Key;
            string strPassword = customControllSender.SelectedItem.Value;
            if (string.IsNullOrEmpty(strLogin))
            {
                MessageBox.Show("Выберите отправителя");
                return;
            }
            if (string.IsNullOrEmpty(strPassword))
            {
                MessageBox.Show("Укажите пароль отправителя");
                return;
            }
            string richText = new TextRange(rtbBody.Document.ContentStart, rtbBody.Document.ContentEnd).Text;
            EmailSendServiceClass emailSender = new EmailSendServiceClass(strLogin,
                strPassword,
                customControllSmtp.SelectedItem.Key,
                customControllSmtp.SelectedItem.Value, richText, tbSubject.Text);
            var locator = (ViewModelLocator)FindResource("Locator");
            emailSender.SendMails(locator.Main.Emails);

        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            var start = rtbBody.Document.ContentStart; 
            var end = rtbBody.Document.ContentEnd; 
            int difference = start.GetOffsetToPosition(end);
            if (difference<=0 || difference == 4 || tbSubject.Text.Length == 0)
            {
                MessageBox.Show("Письмо или тема не заполнены");
                tabControl.SelectedIndex = 2;
                return;
            }
            SchedulerClass sc = new SchedulerClass();
            TimeSpan tsSendTime = sc.GetSendTime(tpTimeSend.Text);
            if (tsSendTime == new TimeSpan())
            {
                MessageBox.Show("Некорректный формат даты");
                return;
            }
            DateTime dtSendDateTime = (cldSchedulDateTimes.SelectedDate ?? DateTime.Today).Add(tsSendTime);
            if (dtSendDateTime < DateTime.Now)
            {
                MessageBox.Show("Дата и время отправки писем не могут быть раньше, чем настоящее время");
                return;
            }
            string strLogin = customControllSender.SelectedItem.Key;
            string strPassword = customControllSender.SelectedItem.Value;
            string richText = new TextRange(rtbBody.Document.ContentStart, rtbBody.Document.ContentEnd).Text;
            EmailSendServiceClass emailSender = new EmailSendServiceClass(strLogin,
                strPassword,
                customControllSmtp.SelectedItem.Key,
                customControllSmtp.SelectedItem.Value, richText, tbSubject.Text);
            var locator = (ViewModelLocator)FindResource("Locator");
            sc.SendEmails(dtSendDateTime, emailSender, locator.Main.Emails);
        }

        private void tscTabSwitcher_btnNextClick(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedIndex == tabControl.Items.Count - 1)
                return;
            tabControl.SelectedIndex++;
        }

        private void tscTabSwitcher_btnPreviousClick(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
                return;
            tabControl.SelectedIndex--;
        }
    }
}
