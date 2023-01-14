using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Decorators
{
    public abstract class NotificationHandler
    {
        public abstract Task Notify();
    }
}
