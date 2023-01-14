using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("yes");
        }
    }
}
