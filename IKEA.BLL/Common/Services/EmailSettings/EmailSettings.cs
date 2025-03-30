using IKEA.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Common.Services.EmailSettings
{
    public class EmailSettings : IEmailSettings
    {
        public void Send(Email email)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("first99ali@gmail.com"
                , "ftvcivsjwwnihqvb");



            smtpClient.Send("first99ali@gmail.com", email.To, email.Subject, email.Body);
        }
    }
}
