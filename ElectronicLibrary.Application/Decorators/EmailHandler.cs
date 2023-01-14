using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Decorators
{
    public class EmailHandler : NotificationHandler
    {
        public string Email { get; set; }
        public string Subject{ get; set; }
        public string Content { get; set; }
        public IEmailSender EmailSender { get; set; }

        public EmailHandler(string email, string subject, string content, IEmailSender emailSender)
        {
            Email = email;
            Subject = subject;
            Content = content;
            EmailSender = emailSender;
        }

        public override async Task Notify()
        {
            await EmailSender.SendEmailAsync(Email, Subject, Content);
        }
    }
}
