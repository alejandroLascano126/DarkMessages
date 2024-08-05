using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Message
{
    public class message
    {
        public string senderUser { get; set; }
        public string receiverUser { get; set; }
        public string messageContent { get; set; }
        public DateTime createdAt { get; set; }
        
    }
}
