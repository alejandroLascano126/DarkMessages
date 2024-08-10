using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Groups
{
    public class groupMessage
    {
        public int messageId { get; set; }
        public DateTime dateCreated { get; set; }
        public string messageContent { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
    }
}
