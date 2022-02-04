using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.CrossCutting.Notification
{
    public class Message
    {
        public Object Body { get; }

        public Message(object body)
        {
            this.Body = body;
        }
    }
}
