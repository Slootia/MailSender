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
using MahApps.Metro.Controls;

namespace WpfMailSender
{
    public partial class MailSender
    {
        public MailSender()
        {
            InitializeComponent();
        }

        private void BtnSendEmail_OnClick(object sender, RoutedEventArgs e)
        {
            List<string> listStrMails = new List<string> { "kuzminyh.ivan@gmail.com", "realnoob@mail.ru" };  // Список email'ов //кому мы отправляем письмо
            string strPassword = passwordBox.Password;
            foreach (string mail in listStrMails)
            {
                // Используем using, чтобы гарантированно удалить объект MailMessage после использования
                using (MailMessage mm = new MailMessage("ralnoob@yandex.ru", mail))
                {
                    // Формируем письмо
                    mm.Subject = "Привет из C#"; // Заголовок письма
                    mm.Body = "Hello, world!";       // Тело письма
                    mm.IsBodyHtml = false;           // Не используем html в теле письма
                    // Авторизуемся на smtp-сервере и отправляем письмо
                    // Оператор using гарантирует вызов метода Dispose, даже если при вызове 
                    // методов в объекте происходит исключение.
                    using (SmtpClient sc = new SmtpClient("smtp.yandex.ru", 25))
                    {
                        sc.EnableSsl = true;
                        sc.UseDefaultCredentials = false;
                        sc.Credentials = new NetworkCredential("ralnoob@yandex.ru", strPassword);
                        sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                        }
                    }
                }
            }
            SendEndWindow sew = new SendEndWindow();
            sew.ShowDialog();

        }
    }
}
