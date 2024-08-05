using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Login
{
    public class rqLogin
    {
        public string username { get; set; }
        public string password { get; set; }
        public int securityCode { get; set; }
    }
}
