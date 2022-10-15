using ElectronicBookingSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfiguration;

        public EmailSender(EmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (var client = new SmtpClient() { EnableSsl = true, Port = _emailConfiguration.Port, Host = _emailConfiguration.Host, UseDefaultCredentials = false, Credentials = new NetworkCredential(_emailConfiguration.Username, _emailConfiguration.Password)})
            {
                try
                {
                    await client.SendMailAsync(new MailMessage(_emailConfiguration.Username, email, subject, htmlMessage));
                }
                catch(Exception e)
                {
                    Console.WriteLine();
                }   
            }
        }
    }
}
