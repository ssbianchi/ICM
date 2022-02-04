using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.CrossCutting.Notification
{
    public interface INotification
    {
        Message Message { get; set; }
    }
}
