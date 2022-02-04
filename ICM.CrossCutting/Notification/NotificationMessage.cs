using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.CrossCutting.Notification
{
    public class NotificationMessage : INotification
    {
        public Message Message { get; set; }

        public NotificationMessage(Message message)
        {
            this.Message = message;
        }
    }
}
