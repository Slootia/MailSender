using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender
{
    class SmtpClass
    {
        public static Dictionary<string, string> SmtpDictionary => dicSmtp;

        private static Dictionary<string, string> dicSmtp = new Dictionary<string, string>()
        {
            {"smtp.yandex.ru", "25"},
            {"smtp.mail.ru", "465"},
            {"smtp.gmail.com",  "587"}
        };
    }
}
