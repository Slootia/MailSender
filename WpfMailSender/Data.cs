using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender
{
    public static class ConnectionData
    {
        public static string SmtpClient { get; set; } = "smtp.yandex.ru";
        public static int SmtpPort { get; set; } = 25;
    }

    public static class Letter
    {
        public static string SenderEmail { get; set; }
        public static string SenderPassword { get; set; }
        public static List<string> ReceiverList { get; set; }
        public static string Subject { get; set; } = "TestSubj";
        public static string Body { get; set; } = "TestBody";
    }
}
