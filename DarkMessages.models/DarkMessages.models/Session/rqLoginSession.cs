using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Session
{
    public class rqLoginSession
    {
        public string ip_name { get; set; }
        public string username { get; set; }
        public bool saveSession { get; set; }
        public string option { get; set; }
    }
}
