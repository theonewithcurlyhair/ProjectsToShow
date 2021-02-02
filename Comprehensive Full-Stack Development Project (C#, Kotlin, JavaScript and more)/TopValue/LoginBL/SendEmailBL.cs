using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SendEmailBL
    {
        public bool SendEmail(Email e, string username, string password, List<string>cc = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(e.EmailFrom);
                mail.To.Add(e.EmailTo);
                if (cc != null && cc.Count > 0)
                {
                    foreach (string ccemail in cc)
                    {
                        mail.CC.Add(ccemail);
                    }
                }
                mail.Subject = e.EmailSubject;
                mail.Body = e.EmailBody;
                mail.IsBodyHtml = true;
                SmtpServer.Port = 25;
                SmtpServer.Host = "127.0.0.1";
                SmtpServer.Credentials = new System.Net.NetworkCredential(username, password);
                SmtpServer.EnableSsl = false;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
