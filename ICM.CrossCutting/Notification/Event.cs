using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.CrossCutting.Notification
{
    public class Event : IEvent
    {
        public string EventName { get; set; }
        public INotification Notification { get; private set; }

        public Event(string eventName, INotification notification)
        {
            EventName = eventName;
            Notification = notification;
        }

    }
}
