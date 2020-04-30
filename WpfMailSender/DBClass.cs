using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender
{
    class DBClass
    {
        private EmailsDataContext emails = new EmailsDataContext();
        public IQueryable<Email> Emails => from c in emails.Email select c;
    }
}
