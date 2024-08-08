using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Friends
{
    public class Friend
    {
        public string username { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string lastChatMessage { get; set; }
        public bool online { get; set; }
        public string email { get; set; }
    }
}
