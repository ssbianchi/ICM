using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.CrossCutting.Notification
{
    public interface IEvent
    {
        String EventName { get; set; }
        INotification Notification { get; }
    }
}
