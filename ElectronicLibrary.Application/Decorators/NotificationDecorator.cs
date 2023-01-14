using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Decorators
{
    public class NotificationDecorator : NotificationHandler
    {
        private readonly NotificationHandler baseObject;

        public NotificationDecorator(NotificationHandler baseObject)
        {
            this.baseObject = baseObject;
        }

        public override async Task Notify()
        {
            if (baseObject != null)
            {
                await baseObject.Notify();
            }

        }
    }
}
