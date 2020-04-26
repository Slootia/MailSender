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

namespace WpfMailSender
{
    public partial class MailSender
    {
        public MailSender()
        {
            InitializeComponent();
            DBClass db = new DBClass();
            dgEmails.ItemsSource = db.Emails;
            cbSenderSelect.ItemsSource = EmailsClass.Senders;
            cbSenderSelect.DisplayMemberPath = "Key";
            cbSenderSelect.SelectedValuePath = "Value";
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
            string strLogin = cbSenderSelect.Text;
            string strPassword = cbSenderSelect.SelectedValue.ToString();
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

            EmailSendServiceClass emailSender = new EmailSendServiceClass(strLogin, strPassword);
            emailSender.SendMails((IQueryable<Email>)dgEmails.ItemsSource);

        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            SchedulerClass sc = new SchedulerClass();
            TimeSpan tsSendTime = sc.GetSendTime(tbTimePicker.Text);
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
            EmailSendServiceClass emailSender = new EmailSendServiceClass(cbSenderSelect.Text, cbSenderSelect.SelectedValue.ToString());
            sc.SendEmails(dtSendDateTime, emailSender, (IQueryable<Email>)dgEmails.ItemsSource);

        }


        //Блок ниже можно переписать, если вынести свитчер в общий блок и скрывать кнопки в зависимости от SelectedIndex
        private void tscTabSwitcherForming_btnNextClick(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void tscTabSwitcherPlanner_btnNextClick(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }

        private void tscTabSwitcherPlanner_btnPreviousClick(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }

        private void tscTabSwitcherEdit_btnNextClick(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 3;
        }

        private void tscTabSwitcherEdit_btnPreviousClick(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void tscTabSwitcherStatistic_btnPreviousClick(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }
    }
}
