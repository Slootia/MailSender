using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodePasswordDLL;

namespace WpfMailSender
{
    public static class EmailsClass
    {
        public static Dictionary<string, string> Senders => dicSenders;

        private static Dictionary<string, string> dicSenders = new Dictionary<string, string>()
        {
            {"test@mail.ru", CodePassword.getPassword("1234")},
            {"test1@mail.ru", CodePassword.getPassword("1234")},
            {"test2@mail.ru", CodePassword.getPassword("1234")}
        };
    }
}
