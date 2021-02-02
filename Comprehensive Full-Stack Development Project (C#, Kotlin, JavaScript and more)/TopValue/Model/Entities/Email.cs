using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Email
    {
        public string EmailFrom { get; set; }
        public string CarbonCopy { get; set; }
        public string EmailSubject { get; set; }

        public string EmailTo { get; set; }
        public string EmailBody { get; set; }
        public DateTime LastReminderDate { get; set; }
    }
}
