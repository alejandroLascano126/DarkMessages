using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Session
{
    public class session
    {
        public int sessionId { get; set; }
        public string ipName { get; set; }
        public bool enabled { get; set; }
        public DateTime lastConnection { get; set; }
        public string username { get; set; }
        public bool onlineStatus { get; set; }
    }
}
