using ElectronicBookingSystem.Application.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Decorators
{
    public class EmailDecorator : NotificationDecorator
    {
        private readonly EmailHandler _baseObject;
        private readonly IHubContext<NotificationHub> _hub;

        public EmailDecorator(EmailHandler baseObject, IHubContext<NotificationHub> hub) : base(baseObject)
        {
            _baseObject = baseObject;
            _hub = hub;
        }

        public override async Task Notify()
        {
            await base.Notify();
            await SendMessage();
        }

        public async Task SendMessage()
        {
           
        }
    }
}
